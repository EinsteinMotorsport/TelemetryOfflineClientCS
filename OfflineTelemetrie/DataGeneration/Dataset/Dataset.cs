using System.Threading;

namespace OfflineTelemetrie.DataGeneration.Dataset
{
    public class Dataset
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private string unit;
        public string Unit
        {
            get { return this.unit; }
            set { this.unit = value; }
        }

        public Dataset(int id, string name, string unit)
        {
            this.Id = id;
            this.Name = name;
            this.Unit = unit;
        }
    }
}
