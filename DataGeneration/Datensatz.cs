namespace TestWpf.DataGeneration
{
    public class Datensatz
    {
        private int nummer;

        public int Nummer   
        {
            get { return nummer; }
            set { nummer = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string einheit;

        public string Einheit
        {
            get { return einheit; }
            set { einheit = value; }
        }

        public Datensatz(int nummer, string name, string einheit)
        {
            this.Nummer = nummer;
            this.Name = name;
            this.Einheit = einheit;
        }

        public override string ToString() => $"{nummer}~{name}~{einheit}";
    }
}
