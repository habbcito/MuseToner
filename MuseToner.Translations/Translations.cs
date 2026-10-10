using System.Diagnostics.SymbolStore;
using System.Globalization;

namespace MuseToner.Translations
{
    public static class Translator
    {
        // Extract just the 2 letters of the language (example: "es", "pt").
        static string lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;



        public static string ChargeButtonTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "Examinar Archivo";

                case "pt":
                    return "Procurar Arquivo";

                case "fr":
                    return "Parcourir un fichier";

                case "it":
                    return "Sfoglia file";

                case "de":
                    return "Datei durchsuchen";

                default:
                    return "Load File";
            }
        }



        public static string SelectorTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "Selecciona un archivo";

                case "pt":
                    return "Selecione um arquivo";

                case "fr":
                    return "Sélectionne un fichier";

                case "it":
                    return "Seleziona un file";

                case "de":
                    return "Wähle eine Datei aus";

                default:
                    return "Choose any file";
            }
        }



        public static string SaveButtonTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "Guardar Archivo";

                case "pt":
                    return "Salvar Arquivo";

                case "fr":
                    return "Enregistrer le fichier";

                case "it":
                    return "Salva file";

                case "de":
                    return "Datei speichern";

                default:
                    return "Save File";
            }
        }



        public static string WelcomeTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "¡Te damos la bienvenida a MuseToner! Carga un archivo MIDI para comenzar";

                case "pt":
                    return "Boas-vindas ao MuseToner! Carregue um arquivo MIDI para começar";

                case "fr":
                    return "Bienvenue sur MuseToner ! Charge un fichier MIDI pour commencer";

                case "it":
                    return "Benvenuto su MuseToner! Carica un file MIDI per iniziare";

                case "de":
                    return "Willkommen bei MuseToner! Lade eine MIDI-Datei, um zu beginnen";

                default:
                    return "Welcome to MuseToner! Load a MIDI file to get started.";
            }
        }



        public static string NoteTranslateText(int note)
        {
            string[] notesText = new string[12];

            switch (lang)
            {
                case "es":
                    notesText[00] = "DO";
                    notesText[01] = "DO# / REb";
                    notesText[02] = "RE";
                    notesText[03] = "RE# / MIb";
                    notesText[04] = "MI";
                    notesText[05] = "FA";
                    notesText[06] = "FA# / SOLb";
                    notesText[07] = "SOL";
                    notesText[08] = "SOL# / LAb";
                    notesText[09] = "LA";
                    notesText[10] = "LA# / SIb";
                    notesText[11] = "SI";
                    break;

                case "pt":
                    notesText[00] = "DÓ";
                    notesText[01] = "DÓ# / RÉb";
                    notesText[02] = "RÉ";
                    notesText[03] = "RÉ# / MIb";
                    notesText[04] = "MI";
                    notesText[05] = "FÁ";
                    notesText[06] = "FÁ# / SOLb";
                    notesText[07] = "SOL";
                    notesText[08] = "SOL# / LÁb";
                    notesText[09] = "LÁ";
                    notesText[10] = "LÁ# / SIb";
                    notesText[11] = "SI";
                    break;

                case "fr":
                    notesText[00] = "DO";
                    notesText[01] = "DO# / RÉb";
                    notesText[02] = "RÉ";
                    notesText[03] = "RÉ# / MIb";
                    notesText[04] = "MI";
                    notesText[05] = "FA";
                    notesText[06] = "FA# / SOLb";
                    notesText[07] = "SOL";
                    notesText[08] = "SOL# / LAb";
                    notesText[09] = "LA";
                    notesText[10] = "LA# / SIb";
                    notesText[11] = "SI";
                    break;

                case "it":
                    notesText[00] = "DO";
                    notesText[01] = "DO# / REb";
                    notesText[02] = "RE";
                    notesText[03] = "RE# / MIb";
                    notesText[04] = "MI";
                    notesText[05] = "FA";
                    notesText[06] = "FA# / SOLb";
                    notesText[07] = "SOL";
                    notesText[08] = "SOL# / LAb";
                    notesText[09] = "LA";
                    notesText[10] = "LA# / SIb";
                    notesText[11] = "SI";
                    break;

                case "de":
                    notesText[00] = "C";
                    notesText[01] = "Cis / Des";
                    notesText[02] = "D";
                    notesText[03] = "Dis / Es";
                    notesText[04] = "E";
                    notesText[05] = "F";
                    notesText[06] = "Fis / Ges";
                    notesText[07] = "G";
                    notesText[08] = "Gis / As";
                    notesText[09] = "A";
                    notesText[10] = "Ais / B";
                    notesText[11] = "H";
                    break;

                default:
                    notesText[00] = "C";
                    notesText[01] = "C# / Db";
                    notesText[02] = "D";
                    notesText[03] = "D# / Eb";
                    notesText[04] = "E";
                    notesText[05] = "F";
                    notesText[06] = "F# / Gb";
                    notesText[07] = "G";
                    notesText[08] = "G# / Ab";
                    notesText[09] = "A";
                    notesText[10] = "A# / Bb";
                    notesText[11] = "B";
                    break;
            }

            return notesText[note];
        }



        public static string ScaleTranslateText(int scale)
        {
            string[] scalesText = new string[20];

            switch (lang)
            {
                case "es":
                    scalesText[00] = "Jónico (MAYOR)";
                    scalesText[01] = "Dórico";
                    scalesText[02] = "Frigio";
                    scalesText[03] = "Lidio";
                    scalesText[04] = "Mixolidio";
                    scalesText[05] = "Eólico (MENOR NATURAL)";
                    scalesText[06] = "Locrio";
                    scalesText[07] = "Menor armónico";
                    scalesText[08] = "Mayor armónico";
                    scalesText[09] = "Frigio dominante";
                    scalesText[10] = "Dórico ucraniano";
                    scalesText[11] = "Doble armónico mayor (Bizantino o Árabe)";
                    scalesText[12] = "Pentatónico* mayor";
                    scalesText[13] = "Enigmático";
                    scalesText[14] = "Persa";
                    scalesText[15] = "Húngaro mayor";
                    scalesText[16] = "Mixolidio b6";
                    scalesText[17] = "Lidio #2";
                    scalesText[18] = "Locrio natural 6";
                    scalesText[19] = "Mayor napolitano";
                    break;

                case "pt":
                    scalesText[00] = "Jônio (MAIOR)";
                    scalesText[01] = "Dórico";
                    scalesText[02] = "Frígio";
                    scalesText[03] = "Lídio";
                    scalesText[04] = "Mixolídio";
                    scalesText[05] = "Eólio (MENOR NATURAL)";
                    scalesText[06] = "Lócrio";
                    scalesText[07] = "Menor harmônico";
                    scalesText[08] = "Maior harmônico";
                    scalesText[09] = "Frígio dominante";
                    scalesText[10] = "Dórico ucraniano";
                    scalesText[11] = "Duplo harmônico maior (Bizantino ou Árabe)";
                    scalesText[12] = "Pentatônico* maior";
                    scalesText[13] = "Enigmático";
                    scalesText[14] = "Persa";
                    scalesText[15] = "Húngaro maior";
                    scalesText[16] = "Mixolídio b6";
                    scalesText[17] = "Lídio #2";
                    scalesText[18] = "Lócrio natural 6";
                    scalesText[19] = "Maior napolitano";
                    break;

                case "fr":
                    scalesText[00] = "Ionien (MAJEUR)";
                    scalesText[01] = "Dorien";
                    scalesText[02] = "Phrygien";
                    scalesText[03] = "Lydien";
                    scalesText[04] = "Mixolydien";
                    scalesText[05] = "Éolien (MINEUR NATUREL)";
                    scalesText[06] = "Locrien";
                    scalesText[07] = "Mineur harmonique";
                    scalesText[08] = "Majeur harmonique";
                    scalesText[09] = "Phrygien dominant";
                    scalesText[10] = "Dorien ukrainien";
                    scalesText[11] = "Double harmonique majeur (Byzantin ou Arabe)";
                    scalesText[12] = "Pentatonique* majeur";
                    scalesText[13] = "Énigmatique";
                    scalesText[14] = "Persan";
                    scalesText[15] = "Hongrois majeur";
                    scalesText[16] = "Mixolydien b6";
                    scalesText[17] = "Lydien #2";
                    scalesText[18] = "Locrien naturel 6";
                    scalesText[19] = "Majeur napolitain";
                    break;

                case "it":
                    scalesText[00] = "Ionico (MAGGIORE)";
                    scalesText[01] = "Dorico";
                    scalesText[02] = "Frigio";
                    scalesText[03] = "Lidio";
                    scalesText[04] = "Misolidio";
                    scalesText[05] = "Eolio (MINORE NATURALE)";
                    scalesText[06] = "Locrio";
                    scalesText[07] = "Minore armonico";
                    scalesText[08] = "Maggiore armonico";
                    scalesText[09] = "Frigio dominante";
                    scalesText[10] = "Dorico ucraino";
                    scalesText[11] = "Doppio armonico maggiore (Bizantino o Arabo)";
                    scalesText[12] = "Pentatonico* maggiore";
                    scalesText[13] = "Enigmatico";
                    scalesText[14] = "Persiano";
                    scalesText[15] = "Ungherese maggiore";
                    scalesText[16] = "Misolidio b6";
                    scalesText[17] = "Lidio #2";
                    scalesText[18] = "Locrio naturale 6";
                    scalesText[19] = "Maggiore napoletano";
                    break;

                case "de":
                    scalesText[00] = "Ionisch (DUR)";
                    scalesText[01] = "Dorisch";
                    scalesText[02] = "Phrygisch";
                    scalesText[03] = "Lydisch";
                    scalesText[04] = "Mixolydisch";
                    scalesText[05] = "Äolisch (NATÜRLICHES MOLL)";
                    scalesText[06] = "Lokrisch";
                    scalesText[07] = "Harmonisch Moll";
                    scalesText[08] = "Harmonisch Dur";
                    scalesText[09] = "Phrygisch dominant";
                    scalesText[10] = "Ukrainisch Dorisch";
                    scalesText[11] = "Doppelt harmonisch Dur (Byzantinisch oder Arabisch)";
                    scalesText[12] = "Pentatonik* Dur";
                    scalesText[13] = "Enigmatisch";
                    scalesText[14] = "Persisch";
                    scalesText[15] = "Ungarisch Dur";
                    scalesText[16] = "Mixolydisch b6";
                    scalesText[17] = "Lydisch #2";
                    scalesText[18] = "Lokrisch natürliche 6";
                    scalesText[19] = "Neapolitanisch Dur";
                    break;

                default:
                    scalesText[00] = "Ionian (MAJOR)";
                    scalesText[01] = "Dorian";
                    scalesText[02] = "Phrygian";
                    scalesText[03] = "Lydian";
                    scalesText[04] = "Mixolydian";
                    scalesText[05] = "Aeolian (NATURAL MINOR)";
                    scalesText[06] = "Locrian";
                    scalesText[07] = "Harmonic Minor";
                    scalesText[08] = "Harmonic Major";
                    scalesText[09] = "Phrygian Dominant";
                    scalesText[10] = "Ukrainian Dorian";
                    scalesText[11] = "Double Harmonic Major (Byzantine or Arabic)";
                    scalesText[12] = "Major Pentatonic*";
                    scalesText[13] = "Enigmatic";
                    scalesText[14] = "Persian";
                    scalesText[15] = "Hungarian Major";
                    scalesText[16] = "Mixolydian b6";
                    scalesText[17] = "Lydian #2";
                    scalesText[18] = "Locrian Natural 6";
                    scalesText[19] = "Neapolitan Major";
                    break;
            }

            return scalesText[scale];
        }



        public static string NoRootTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "No se pudo obtener la ruta del archivo";

                case "pt":
                    return "Não foi possível obter o caminho do arquivo";

                case "fr":
                    return "Impossible d'obtenir le chemin du fichier";

                case "it":
                    return "Impossibile ottenere il percorso del file";

                case "de":
                    return "Der Dateipfad konnte nicht ermittelt werden";

                default:
                    return "Could not get the file path";
            }
        }



        public static string UploadedFileTranslateText(string fileroot)
        {
            switch (lang)
            {
                case "es":
                    return "Se cargó el archivo: " + fileroot;

                case "pt":
                    return "Arquivo carregado: " + fileroot;

                case "fr":
                    return "Fichier chargé : " + fileroot;

                case "it":
                    return "File caricato: " + fileroot;

                case "de":
                    return "Datei geladen: " + fileroot;

                default:
                    return "File loaded: " + fileroot;
            }
        }



        public static string FirstUploadTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "Primero debes cargar un archivo";

                case "pt":
                    return "Primeiro você deve carregar um arquivo";

                case "fr":
                    return "Tu dois d'abord charger un fichier";

                case "it":
                    return "Devi prima caricare un file";

                case "de":
                    return "Du musst zuerst eine Datei laden";

                default:
                    return "You must load a file first";
            }
        }



        public static string ErrorReadFileTranslateText(string errMessage)
        {
            switch (lang)
            {
                case "es":
                    return "Error al leer el archivo: " + errMessage;

                case "pt":
                    return "Erro ao ler o arquivo: " + errMessage;

                case "fr":
                    return "Erreur de lecture du fichier : " + errMessage;

                case "it":
                    return "Errore durante la lettura del file: " + errMessage;

                case "de":
                    return "Fehler beim Lesen der Datei: " + errMessage;

                default:
                    return "Error reading the file: " + errMessage;
            }
        }



        public static string SameTonicScaleTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "La tonalidad original y la tonalidad desada son la misma";

                case "pt":
                    return "A tonalidade inicial e a tonalidade desejada são a mesma";

                case "fr":
                    return "La tonalité initiale et la tonalité souhaitée sont identiques";

                case "it":
                    return "La tonalità iniziale e la tonalità desiderata sono le stesse";

                case "de":
                    return "Die Ausgangstonart und die Zieltonart sind identisch";

                default:
                    return "The original key and the target key are the same";
            }
        }



        public static string OutOfScaleTranslateText(int count)
        {
            switch (lang)
            {
                case "es":
                    return "Hay " + count + " notas fuera de la escala. El archivo no pudo ser convertido";

                case "pt":
                    return "Há " + count + " notas fora da escala. Não foi possível converter o arquivo";

                case "fr":
                    return "Il y a " + count + " notes hors de la gamme. Le fichier n'a pas pu être converti";

                case "it":
                    return "Ci sono " + count + " note fuori dalla scala. Non è stato possibile convertire il file";

                case "de":
                    return "Es gibt " + count + " Noten außerhalb der Tonleiter. Die Datei konnte nicht konvertiert werden";

                default:
                    return "There are " + count + " notes outside the scale. The file could not be converted";
            }
        }



        public static string ExportedTranslateText(string root)
        {
            switch (lang)
            {
                case "es":
                    return "Se exportó el archivo con los cambios: " + root;

                case "pt":
                    return "Arquivo exportado com as alterações: " + root;

                case "fr":
                    return "Fichier exporté avec les modifications : " + root;

                case "it":
                    return "File esportato con le modifiche: " + root;

                case "de":
                    return "Datei mit den Änderungen exportiert: " + root;

                default:
                    return "File exported with the changes: " + root;
            }
        }



        public static string ErrorExportingTranslateText(string errMessage)
        {
            switch (lang)
            {
                case "es":
                    return "Error al exportar: " + errMessage;

                case "pt":
                    return "Erro ao exportar: " + errMessage;

                case "fr":
                    return "Erreur lors de l'exportation : " + errMessage;

                case "it":
                    return "Errore durante l'esportazione: " + errMessage;

                case "de":
                    return "Fehler beim Exportieren: " + errMessage;

                default:
                    return "Error exporting: " + errMessage;
            }
        }



        public static string OriginalKeyTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "Tonalidad Inicial";

                case "pt":
                    return "Tonalidade Inicial";

                case "fr":
                    return "Tonalité Initiale";

                case "it":
                    return "Tonalità Iniziale";

                case "de":
                    return "Ausgangstonart";

                default:
                    return "Original Key";
            }
        }



        public static string FinalKeyTranslateText()
        {
            switch (lang)
            {
                case "es":
                    return "Tonalidad Final";

                case "pt":
                    return "Tonalidade Final";

                case "fr":
                    return "Tonalité Finale";

                case "it":
                    return "Tonalità Finale";

                case "de":
                    return "Zieltonart";

                default:
                    return "Final Key";
            }
        }



        // Translations of Notes in ComboBox.
        public static string[] AllNotes()
        {
            string[] result = new string[12];
            for (int i = 0; i < 12; i++)
                result[i] = NoteTranslateText(i);
            return result;
        }




        // Translations of Scale names in ComboBox.
        public static string[] AllScales()
        {
            string[] result = new string[20];
            for (int i = 0; i < 20; i++)
                result[i] = ScaleTranslateText(i);
            return result;
        }
    }
}