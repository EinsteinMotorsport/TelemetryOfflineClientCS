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
    public class CartesianViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private Random rand = new Random();

        public DelegateCommand AddValuesCommand { get; }
        public DelegateCommand StopAddingValuesCommand { get; }

        private ChartValues<int> plotValues;

        public ChartValues<int> PlotValues
        {
            get { return this.plotValues; }
            set { this.SetProperty(ref this.plotValues, value); }
        }

        private ChartValues<int> plotValues2;

        public ChartValues<int> PlotValues2
        {
            get { return this.plotValues2; }
            set { this.SetProperty(ref this.plotValues2, value); }
        }

        private ChartValues<int> plotValues3;

        public ChartValues<int> PlotValues3
        {
            get { return this.plotValues3; }
            set { this.SetProperty(ref this.plotValues3, value); }
        }




        public CartesianViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.AddValuesCommand = new DelegateCommand(this.AddValues);
            this.StopAddingValuesCommand = new DelegateCommand(this.StopAddingValues);

            this.PlotValues = new ChartValues<int>();
            this.PlotValues2 = new ChartValues<int>();
            this.PlotValues3 = new ChartValues<int>();
        }

        private void StopAddingValues()
        {

        }

        private void AddValues()
        {
            for (int i = 0; i < 100; i++)
            {
                PlotValues.Add(rand.Next(0, 10));
                PlotValues2.Add(rand.Next(0,10));
                PlotValues3.Add(rand.Next(0,10));
            }
        }
    }
}
