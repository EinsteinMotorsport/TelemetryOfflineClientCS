using System;
using System.Collections.ObjectModel;
using System.IO;

namespace OfflineTelemetrie.DataGeneration.Dataset
{
    class DataSetGenerator
    {
        private FileStream fileStream;
        private StreamReader reader;
        private string datasetConfigFilePath;
        private ObservableCollection<Dataset> datasets;

        private ObservableCollection<Dataset> dataset;
        public ObservableCollection<Dataset> Dataset
        {
            get { return this.dataset; }
            set { this.dataset = value; }
        }

        public DataSetGenerator()
        {
            this.datasetConfigFilePath = "..\\..\\..\\..\\_Configs\\DatasetConfig.txt";

            this.fileStream = new FileStream(datasetConfigFilePath, FileMode.Open, FileAccess.Read);
            this.reader = new StreamReader(fileStream);
            this.datasets = new ObservableCollection<Dataset>();
        }

        public ObservableCollection<Dataset> ReadDatasetConfigFile()
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (!string.IsNullOrEmpty(line))
                {
                    var id = Convert.ToInt32(line.Substring(0, 3));
                    var lengthName = line.LastIndexOf('~') - 4;
                    var name = line.Substring(4, lengthName);
                    var unit = line.Substring(5 + lengthName, line.Length - 5 - lengthName);

                    Dataset.Add(new Dataset(id, name, unit));
                }
            }

            return Dataset;
        }


    }
}
