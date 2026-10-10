using System;
using System.IO;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Avalonia.Interactivity;
using MuseToner.Core;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

namespace MuseToner.App.Views;

public partial class MainWindow : Window
{
    private string? fileroot;

    private MidiFile? _midi;

    public MainWindow() => InitializeComponent();



    // Charging button.
    private async void OnButtonClick(object? sender, RoutedEventArgs e)
    {
        // 1. Filter of type file.
        List<string> paterns = new List<string>();
        paterns.Add("*.mid");
        paterns.Add("*.midi");

        FilePickerFileType midiFilter = new FilePickerFileType("MIDI");
        midiFilter.Patterns = paterns;

        List<FilePickerFileType> filters = new List<FilePickerFileType>();
        filters.Add(midiFilter);

        // 2. Options of selector.
        FilePickerOpenOptions options = new FilePickerOpenOptions();
        options.Title = "Selecciona un archivo";
        options.AllowMultiple = false;
        options.FileTypeFilter = filters;

        // 3. Open selector file.
        IReadOnlyList<IStorageFile> archivos = await StorageProvider.OpenFilePickerAsync(options);

        // 4. If user cancelled, quit.
        if (archivos.Count == 0)
        {
            return;
        }

        // 5. Save the root and show the message.
        fileroot = archivos[0].TryGetLocalPath();
        if (fileroot == null)
        {
            StatusText.Text = "No se pudo obtener la ruta del archivo";
            return;
        }
        StatusText.Text = "Se cargó el archivo: " + fileroot;


        try
        {
            _midi = MidiFile.Read(fileroot);
            RefreshPianoRoll();
        }
        catch (Exception ex)
        {
            StatusText.Text = "Error al leer el archivo: " + ex.Message;
            return;
        }
    }



    // Saving Button.
    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        // 1. Verify that a file exists.
        if (fileroot == null)
        {
            StatusText.Text = "Primero debes cargar un archivo";
            return;
        }

        // 2. Read the selected config of ComboBox.
        int originalTonic = Tonic_Input.SelectedIndex;
        int finalTonic = Tonic_Output.SelectedIndex;
        int[] originalScale = ScaleCatalog.Scales[Type_Input.SelectedIndex].Degrees;
        int[] finalScale = ScaleCatalog.Scales[Type_Output.SelectedIndex].Degrees;

        // 3. Validate to convert some file.
        bool sameTonic = originalTonic == finalTonic;
        bool sameScale = Type_Input.SelectedIndex == Type_Output.SelectedIndex;
        if (sameTonic && sameScale)
        {
            StatusText.Text = "La tonalidad original y la tonalidad desada son la misma";
            return;
        }

        // 4. OUTPUT ROOT: same directory, with prefix "output_".
        string? directory = Path.GetDirectoryName(fileroot);
        string outputName = "output_" + Path.GetFileName(fileroot);
        string outputRoot = outputName;
        if (directory != null)
        {
            outputRoot = Path.Combine(directory, outputName);
        }

        // 5. Read, validate, convert and write.
        try
        {
            MidiFile original = MidiFile.Read(fileroot);

            List<Note> outOfScale = MidiTransposer.FindOutOfScaleNotes(original, originalTonic, originalScale);
            if (outOfScale.Count >  0)
            {
                StatusText.Text = "Hay " + outOfScale.Count + " notas fuera de la escala. El archivo no pudo ser convertido";
                return;
            }

            MidiFile converted = MidiTransposer.Convert(original, originalTonic, originalScale, finalTonic, finalScale);
            converted.Write(outputRoot, true);

            StatusText.Text = "Se exportó el archivo con los cambios: " + outputRoot;
        }
        catch (Exception ex)
        {
            StatusText.Text = "Error al exportar: " + ex.Message;
        }
    }


    // 
    private void OnOriginalKeyChanged(object? sender, SelectionChangedEventArgs e)
    {
        RefreshPianoRoll();
    }




    private void RefreshPianoRoll()
    {
        if (PianoRoll == null) return;
        if (Tonic_Input.SelectedIndex < 0 || Type_Input.SelectedIndex < 0) return;

        int tonic = Tonic_Input.SelectedIndex;
        int[] scale = ScaleCatalog.Scales[Type_Input.SelectedIndex].Degrees;

        PianoRoll.SetScale(tonic, scale);

        if (_midi != null)
        {
            List<NoteInfo> notes = NoteAnalyzer.Analyze(_midi, tonic, scale);
            PianoRoll.SetNotes(notes);
        }
    }
}