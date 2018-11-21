using System;
using System.Collections.ObjectModel;
using System.IO;
using NLog;

namespace TestWpf.DataGeneration
{
    public class DataGenerator
    {
        private readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        private static FileStream fileStream;
        private static StreamReader reader;
        private static string messdatennameConfigFilePath;
        private static ObservableCollection<Datensatz> ausDateiGeleseneMessdaten;
        public DataGenerator()
        {
            LOGGER.Info("started the DataLogger");
        }

        /**
         * Die Funktion MessdatenConfigAuslesen liest aus einer Textdatei alle vorkommenden IDs mit den zugehörigen Namen und Einheiten aus
         */
        public static ObservableCollection<Datensatz> MessdatenConfigAuslesen()
        {
            ausDateiGeleseneMessdaten = new ObservableCollection<Datensatz>();

            messdatennameConfigFilePath = "..\\..\\..\\Configs\\Daten_aufbereiten_konfig.txt";
            fileStream = new FileStream(messdatennameConfigFilePath, FileMode.Open);
            reader = new StreamReader(fileStream);
            
            while (!reader.EndOfStream)
            {
                var zeile = reader.ReadLine();

                if (!string.IsNullOrEmpty(zeile))
                {
                    var ID = Convert.ToInt32(zeile.Substring(0, 3));
                    var laengeName = zeile.LastIndexOf('~') - 4;
                    var name = zeile.Substring(4, laengeName);
                    var einheit = zeile.Substring(5 + laengeName, zeile.Length - 5 - laengeName);

                    ausDateiGeleseneMessdaten.Add(new Datensatz(ID, name, einheit));
                }
            }

            reader.Close();

            return ausDateiGeleseneMessdaten;
        }
    }
}
