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
    public class BarViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DelegateCommand AddBarCommand { get; }

        private SeriesCollection barValues;

        public SeriesCollection BarValues
        {
            get { return this.barValues; }
            set { this.SetProperty(ref this.barValues, value); }
        }

        private int valueNewBar;

        public int ValueNewBar
        {
            get { return this.valueNewBar; }
            set { this.SetProperty(ref this.valueNewBar, value); }
        }

        private string nameNewBar;

        public string NameNewBar
        {
            get { return this.nameNewBar; }
            set { this.SetProperty(ref this.nameNewBar, value); }
        }




        public BarViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.AddBarCommand = new DelegateCommand(this.AddBar);

            this.BarValues = new SeriesCollection();
        }

        private void AddBar()
        {
            BarValues.Add(
                new ColumnSeries
                {
                    Values = new ChartValues<int> { this.ValueNewBar },
                    Title = NameNewBar
                });
        }
    }
}
