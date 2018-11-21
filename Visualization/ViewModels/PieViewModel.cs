using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using NLog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace TestWpf.Visualization.ViewModels
{
    public class PieViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private Random rand = new Random();

        public DelegateCommand SektorHinzufuegenCommand { get; }
        public DelegateCommand KreisdiagrammInBalkendiagrammCommand { get; }

        private SeriesCollection pieValues;

        public SeriesCollection PieValues
        {
            get { return this.pieValues; }
            set { this.SetProperty(ref this.pieValues, value); }
        }

        private SeriesCollection barValues;

        public SeriesCollection BarValues
        {
            get { return this.barValues; }
            set { this.SetProperty(ref this.barValues, value); }
        }



        public PieViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            PieValues = new SeriesCollection();
            BarValues = new SeriesCollection();

            this.SektorHinzufuegenCommand = new DelegateCommand(this.SektorHinzufuegen);
            this.KreisdiagrammInBalkendiagrammCommand=new DelegateCommand(this.KreisdiagrammInBalkendiagramm);
        }

        private void KreisdiagrammInBalkendiagramm()
        {
            BarValues.Clear();
            foreach (var value in PieValues)
            {
                BarValues.Add(
                    new ColumnSeries
                    {
                        Values = value.Values
                    });
            }
        }

        private void SektorHinzufuegen()
        {
            var zahl = rand.Next(1, 10);

            PieValues.Add(new PieSeries
            {
                Values = new ChartValues<int> { zahl },
                Title = $"Sektor {PieValues.Count + 1}"
            });
        }
    }
}
