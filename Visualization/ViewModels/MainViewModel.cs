using NLog;
using Prism.Events;

namespace TestWpf.Visualization.ViewModels
{
    public class MainViewModel
    {
        private IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ButtonViewModel ButtonViewModel { get; }
        public LabelViewModel LabelViewModel { get; }
        public MenuBarViewModel MenuBarViewModel { get; }
        public SettingsViewModel SettingsViewModel { get; }
        public GaugeViewModel GaugeViewModel { get; }
        public PieViewModel PieViewModel { get; }
        public BarViewModel BarViewModel { get; }
        public CartesianViewModel CartesianViewModel { get; }

        public MainViewModel(IEventAggregator eventAggregator)
        {
            logger.Info("");
            logger.Info("Started new Programm");

            this.eventAggregator = eventAggregator;

            this.ButtonViewModel = new ButtonViewModel(eventAggregator);
            logger.Info("Created ButtonViewModel");
            this.LabelViewModel = new LabelViewModel(eventAggregator);
            logger.Info("Created LabelViewModel");
            this.MenuBarViewModel = new MenuBarViewModel(eventAggregator);
            logger.Info("Created MenuBarViewModel");
            this.SettingsViewModel = new SettingsViewModel(eventAggregator);
            logger.Info("Created SettingsViewModel");
            this.GaugeViewModel = new GaugeViewModel(eventAggregator);
            logger.Info("Created GaugeViewModel");
            this.PieViewModel = new PieViewModel(eventAggregator);
            logger.Info("Created PieViewModel");
            this.BarViewModel = new BarViewModel(eventAggregator);
            logger.Info("Created BarViewModel");
            this.CartesianViewModel = new CartesianViewModel(eventAggregator);
            logger.Info("Created CartesianViewModel");
        }
    }
}
