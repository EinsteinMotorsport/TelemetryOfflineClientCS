using System.Collections.ObjectModel;
using System.Windows.Media;
using NLog;
using Prism.Events;
using Prism.Mvvm;
using TestWpf.DataGeneration;

namespace TestWpf.Visualization.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private int lineThickness;

        public int LineThickness
        {
            get { return this.lineThickness; }
            set { this.SetProperty(ref this.lineThickness, value); }
        }

        private Color lineColor;

        public Color LineColor
        {
            get { return this.lineColor; }
            set { this.SetProperty(ref this.lineColor, value); }
        }

        private Datensatz ausgwaehlteMessdaten;

        public Datensatz AusgewaehlteMessdaten
        {
            get { return this.ausgwaehlteMessdaten; }
            set { this.SetProperty(ref this.ausgwaehlteMessdaten, value); }
        }

        private ObservableCollection<Datensatz> aktuelleMessdaten;

        public ObservableCollection<Datensatz> AktuelleMessdaten
        {
            get { return this.aktuelleMessdaten; }
            set { this.SetProperty(ref this.aktuelleMessdaten, value); }
        }




        public SettingsViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            
        }
    }
}
