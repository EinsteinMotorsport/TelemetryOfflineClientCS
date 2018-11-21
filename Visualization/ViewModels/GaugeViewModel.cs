using NLog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace TestWpf.Visualization.ViewModels
{
    public class GaugeViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DelegateCommand ValueOfSliderChangedCommand { get; }

        private int valueSlider;

        public int ValueSlider
        {
            get { return this.valueSlider; }
            set { this.SetProperty(ref this.valueSlider, value); }
        }

        private int valueGauge;

        public int ValueGauge
        {
            get { return this.valueGauge; }
            set { this.SetProperty(ref this.valueGauge, value); }
        }



        public GaugeViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.ValueOfSliderChangedCommand=new DelegateCommand(ValueOfSliderChanged);

            ValueGauge = ValueSlider;
        }

        private void ValueOfSliderChanged()
        {
            ValueGauge = ValueSlider;
        }
    }
}
