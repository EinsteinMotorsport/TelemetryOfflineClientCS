using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using NLog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using TestWpf.DataGeneration;
using TestWpf.Visualization.Events;

namespace TestWpf.Visualization.ViewModels
{
    /// <summary>
    /// Erstellt ein LabelViewModel mit den zugehörigen Properties und Methoden
    /// </summary>
    public class LabelViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private List<string> anzuzeigendeMessdaten = new List<string>();

        public DelegateCommand AddNewMessdatenCommand { get; }
        public DelegateCommand DeleteMessdatenCommand { get; }
        public DelegateCommand ShowMessdatenCommand { get; }
        public DelegateCommand CheckedCheckboxCommand { get; }

        private SolidColorBrush backgroundColorLabel1;
        public SolidColorBrush BackgroundColorLabel1
        {
            get { return this.backgroundColorLabel1; }
            set { this.SetProperty(ref this.backgroundColorLabel1, value); }
        }

        private SolidColorBrush foregroundColorLabel1;
        public SolidColorBrush ForegroundColorLabel1
        {
            get { return this.foregroundColorLabel1; }
            set { this.SetProperty(ref this.foregroundColorLabel1, value); }
        }

        private SolidColorBrush backgroundColorLabel2;
        public SolidColorBrush BackgroundColorLabel2
        {
            get { return this.backgroundColorLabel2; }
            set { this.SetProperty(ref this.backgroundColorLabel2, value); }
        }

        private SolidColorBrush foregroundColorLabel2;
        public SolidColorBrush ForegroundColorLabel2
        {
            get { return this.foregroundColorLabel2; }
            set { this.SetProperty(ref this.foregroundColorLabel2, value); }
        }

        private SolidColorBrush backgroundColorLabel3;
        public SolidColorBrush BackgroundColorLabel3
        {
            get { return this.backgroundColorLabel3; }
            set { this.SetProperty(ref this.backgroundColorLabel3, value); }
        }

        private SolidColorBrush foregroundColorLabel3;
        public SolidColorBrush ForegroundColorLabel3
        {
            get { return this.foregroundColorLabel3; }
            set { this.SetProperty(ref this.foregroundColorLabel3, value); }
        }

        private ObservableCollection<Datensatz> alleMessdaten;

        public ObservableCollection<Datensatz> AlleMessdaten
        {
            get { return this.alleMessdaten; }
            set { this.SetProperty(ref this.alleMessdaten, value); }
        }

        private ObservableCollection<Datensatz> aktuelleMessdaten;

        public ObservableCollection<Datensatz> AktuelleMessdaten
        {
            get { return this.aktuelleMessdaten; }
            set { this.SetProperty(ref this.aktuelleMessdaten, value); }
        }

        private Datensatz selectedMessdatenAlleMessdaten;

        public Datensatz SelectedMessdatenAlleMessdaten
        {
            get { return this.selectedMessdatenAlleMessdaten; }
            set { this.SetProperty(ref this.selectedMessdatenAlleMessdaten, value); }
        }

        private Datensatz selectedMessdatenAktuelleMessdaten;

        public Datensatz SelectedMessdatenAktuelleMessdaten
        {
            get { return this.selectedMessdatenAktuelleMessdaten; }
            set { this.SetProperty(ref this.selectedMessdatenAktuelleMessdaten, value); }
        }


        private string nameMesswert;

        public string NameMesswert
        {
            get { return this.nameMesswert; }
            set { this.SetProperty(ref this.nameMesswert, value); }
        }

        private string itemToDelete;

        public string ItemToDelete
        {
            get { return this.itemToDelete; }
            set { this.SetProperty(ref this.itemToDelete, value); }
        }

        private bool isCheckBoxChecked;

        public bool IsCheckBoxChecked
        {
            get { return this.isCheckBoxChecked; }
            set { this.SetProperty(ref isCheckBoxChecked, value); }
        }

        private Datensatz dragAddMessdaten;

        public Datensatz DragAddMessdaten
        {
            get { return this.dragAddMessdaten; }
            set { this.SetProperty(ref this.dragAddMessdaten, value); }
        }

        private string inhaltSuche;

        public string InhaltSuche
        {
            get { return this.inhaltSuche; }
            set
            {
                this.SetProperty(ref this.inhaltSuche, value);
                OnInhaltSucheChanged();
            }
        }

        private ObservableCollection<Datensatz> durchsuchteMessdaten;

        public ObservableCollection<Datensatz> DurchsuchteMessdaten
        {
            get { return this.durchsuchteMessdaten; }
            set { this.SetProperty(ref this.durchsuchteMessdaten, value); }
        }




        private bool isLabel1Checked = false;
        private bool isLabel2Checked = false;
        private bool isLabel3Checked = false;


        public LabelViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.eventAggregator.GetEvent<ChangeLabelTextColorEvent>().Subscribe(this.OnChangeLabelTextColorEvent);
            this.eventAggregator.GetEvent<ChangeLabelBackgroundColorEvent>()
                .Subscribe(this.OnChangeLabelBackgroundColorEvent);
            this.eventAggregator.GetEvent<LabelSelectionChangedEvent>().Subscribe(this.OnLabel1SelectionChangedEvent);

            this.AddNewMessdatenCommand = new DelegateCommand(this.AddNewMessdaten);
            this.ShowMessdatenCommand = new DelegateCommand(this.ShowMessdaten);
            this.DeleteMessdatenCommand = new DelegateCommand(this.DeleteMessdaten);
            this.CheckedCheckboxCommand=new DelegateCommand(this.CheckedCheckbox);

            this.ForegroundColorLabel1 = Brushes.Black;
            this.ForegroundColorLabel2 = Brushes.Black;
            this.ForegroundColorLabel3 = Brushes.Black;

            AlleMessdaten = DataGenerator.MessdatenConfigAuslesen();

            AktuelleMessdaten = new ObservableCollection<Datensatz>();
            DurchsuchteMessdaten=new ObservableCollection<Datensatz>();

            foreach (var datensatz in AlleMessdaten)
            {
                DurchsuchteMessdaten.Add(datensatz);
            }
        }

        private void CheckedCheckbox()
        {
            OnChangeLabelTextColorEvent(Colors.Brown);
        }

        private void DeleteMessdaten()
        {
            this.AktuelleMessdaten.Remove(SelectedMessdatenAktuelleMessdaten);
        }

        private void ShowMessdaten()
        {
            this.OnChangeLabelTextColorEvent(Colors.Brown);
        }

        private void AddNewMessdaten()
        {
            AktuelleMessdaten.Add(SelectedMessdatenAlleMessdaten);
        }

        private void OnLabel1SelectionChangedEvent(int whichButton)
        {
            if (whichButton == 1)
            {
                isLabel1Checked = true;
                isLabel2Checked = false;
                isLabel3Checked = false;
            }
            else if (whichButton == 2)
            {
                isLabel1Checked = false;
                isLabel2Checked = true;
                isLabel3Checked = false;
            }
            else if (whichButton == 3)
            {
                isLabel1Checked = false;
                isLabel2Checked = false;
                isLabel3Checked = true;
            }
        }

        private void OnChangeLabelBackgroundColorEvent(SolidColorBrush color)
        {
            if (isLabel1Checked)
            {
                BackgroundColorLabel1 = color;
                logger.Info($"Changed background color of label1 to {color}");
            }
            if (isLabel2Checked)
            {
                this.BackgroundColorLabel2 = color;
                logger.Info($"Changed background color of label2 to {color}");
            }

            if (isLabel3Checked)
            {
                this.BackgroundColorLabel3 = color;
                logger.Info($"Changed background color of label3 to {color}");
            }

        }

        private void OnChangeLabelTextColorEvent(Color color)
        {
            if (isLabel1Checked)
            {
                this.ForegroundColorLabel1 = new SolidColorBrush(color);
                logger.Info($"Changed foreground color of label1 to {color}");
            }

            if (isLabel2Checked)
            {
                this.ForegroundColorLabel2 = new SolidColorBrush(color);
                logger.Info($"Changed foreground color of label2 to {color}");
            }

            if (isLabel3Checked)
            {
                this.ForegroundColorLabel3 = new SolidColorBrush(color);
                logger.Info($"Changed foreground color of label3 to {color}");
            }
        }

        private void OnInhaltSucheChanged()
        {
            DurchsuchteMessdaten.Clear();

            if (string.IsNullOrWhiteSpace(InhaltSuche))
            {
                foreach (var datensatz in AlleMessdaten)
                {
                    DurchsuchteMessdaten.Add(datensatz);
                }
                return;
            }

            foreach (var datensatz in AlleMessdaten)
            {
                if (datensatz.Name.ToLower().Contains(InhaltSuche.ToLower()))
                {
                    DurchsuchteMessdaten.Add(datensatz);
                }
            }
        }

        public ObservableCollection<Datensatz> GetAktuelleMessdaten()
        {
            return AktuelleMessdaten;
        }
    }
}
