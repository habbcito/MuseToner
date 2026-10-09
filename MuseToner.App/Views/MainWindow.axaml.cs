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

    public MainWindow() => InitializeComponent();



    // Botón de Cargado.
    private async void OnButtonClick(object? sender, RoutedEventArgs e)
    {
        // 1. Filtro de tipos de archivo
        List<string> patrones = new List<string>();
        patrones.Add("*.mid");
        patrones.Add("*.midi");

        FilePickerFileType filtroMidi = new FilePickerFileType("MIDI");
        filtroMidi.Patterns = patrones;

        List<FilePickerFileType> filtros = new List<FilePickerFileType>();
        filtros.Add(filtroMidi);

        // 2. Opciones del selector
        FilePickerOpenOptions opciones = new FilePickerOpenOptions();
        opciones.Title = "Selecciona un archivo";
        opciones.AllowMultiple = false;
        opciones.FileTypeFilter = filtros;

        // 3. Abrir el selector
        IReadOnlyList<IStorageFile> archivos = await StorageProvider.OpenFilePickerAsync(opciones);

        // 4. Si el usuario canceló, salir
        if (archivos.Count == 0)
        {
            return;
        }

        // 5. Guardar la ruta y mostrar el mensaje
        fileroot = archivos[0].TryGetLocalPath();
        StatusText.Text = "Se cargó el archivo: " + fileroot;
    }



    // Botón de Guardado.
    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        // 1. Validar que haya archivo.
        if (fileroot == null)
        {
            StatusText.Text = "Primero debes cargar un archivo";
            return;
        }

        // 2. Leer lo elegido en los ComboBox.
        int tonicaOriginal = Tonic_Input.SelectedIndex;
        int tonicaFinal = Tonic_Output.SelectedIndex;
        int[] escalaOriginal = ScaleCatalog.Scales[Type_Input.SelectedIndex].Degrees;
        int[] escalaFinal = ScaleCatalog.Scales[Type_Output.SelectedIndex].Degrees;

        // 3. Validar que haya algo que convertir.
        bool mismaTonica = tonicaOriginal == tonicaFinal;
        bool mismaEscala = Type_Input.SelectedIndex == Type_Output.SelectedIndex;
        if (mismaTonica && mismaEscala)
        {
            StatusText.Text = "La tonalidad original es la misma que la tonalidad deseada";
            return;
        }

        // 4. Ruta de salida: misma carpeta, prefijo "output_".
        string? carpeta = Path.GetDirectoryName(fileroot);
        string nombreSalida = "output_" + Path.GetFileName(fileroot);
        string rutaSalida = nombreSalida;
        if (carpeta != null)
        {
            rutaSalida = Path.Combine(carpeta, nombreSalida);
        }

        // 5. Leer, validar, convertir y escribir.
        try
        {
            MidiFile original = MidiFile.Read(fileroot);

            List<Note> fuera = MidiTransposer.FindOutOfScaleNotes(original, tonicaOriginal, escalaOriginal);
            if (fuera.Count >  0)
            {
                StatusText.Text = "Existen " + fuera.Count + " notas fuera de la escala, no se puede convertir el archivo";
                return;
            }

            MidiFile convertido = MidiTransposer.Convert(original, tonicaOriginal, escalaOriginal, tonicaFinal, escalaFinal);
            convertido.Write(rutaSalida, true);

            StatusText.Text = "Se exportó el archivo con los cambios: " + rutaSalida;
        }
        catch (Exception ex)
        {
            StatusText.Text = "Error al exportar: " + ex.Message;
        }
    }
}