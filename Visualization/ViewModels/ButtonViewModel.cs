using System.Windows.Media;
using NLog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using TestWpf.Visualization.Events;

namespace TestWpf.Visualization.ViewModels
{
    public class ButtonViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DelegateCommand ChangeColorToRedCommand { get; }
        public DelegateCommand ChangeColorToYellowCommand { get; }
        public DelegateCommand ChangeColorToGreenCommand { get; }
        public DelegateCommand ChangeColorToBlueCommand { get; }
        public DelegateCommand LabelSelectionChangedCommand { get; }


        private bool isSchriftfarbeChecked;
        public bool IsSchriftfarbeChecked
        {
            get { return this.isSchriftfarbeChecked; }
            set { this.SetProperty(ref this.isSchriftfarbeChecked, value); }
        }

        private bool isHintergrundfarbeChecked;
        public bool IsHintergrundfarbeChecked
        {
            get { return this.isHintergrundfarbeChecked; }
            set { this.SetProperty(ref this.isHintergrundfarbeChecked, value); }
        }

        private static bool isLabel1Checked;
        public bool IsLabel1Checked
        {
            get { return isLabel1Checked; }
            set { isLabel1Checked = value; }
        }

        private bool isLabel2Checked;
        public bool IsLabel2Checked
        {
            get { return this.isLabel2Checked; }
            set { this.SetProperty(ref this.isLabel2Checked, value); }
        }

        private bool isLabel3Checked;
        public bool IsLabel3Checked
        {
            get { return this.isLabel3Checked; }
            set { this.SetProperty(ref this.isLabel3Checked, value); }
        }

        private SolidColorBrush farbe;
        public SolidColorBrush Farbe
        {
            get { return this.farbe; }
            set { this.SetProperty(ref this.farbe, value); }
        }


        public ButtonViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.ChangeColorToRedCommand=new DelegateCommand(this.ChangeColorToRed);
            this.ChangeColorToYellowCommand=new DelegateCommand(this.ChangeColorToGYellow);
            this.ChangeColorToGreenCommand=new DelegateCommand(this.ChangeColorToGreen);
            this.ChangeColorToBlueCommand=new DelegateCommand(this.ChangeColorToBlue);
            this.LabelSelectionChangedCommand=new DelegateCommand(this.LabelSelectionChanged);
        }

        private void LabelSelectionChanged()
        {
            if (this.IsLabel1Checked)
            {
                this.eventAggregator.GetEvent<LabelSelectionChangedEvent>().Publish(1);
                logger.Info("Selected Label1");
            }
            else if (this.IsLabel2Checked)
            {
                this.eventAggregator.GetEvent<LabelSelectionChangedEvent>().Publish(2);
                logger.Info("Selected Label2");
            }
            else if (this.IsLabel3Checked)
            {
                this.eventAggregator.GetEvent<LabelSelectionChangedEvent>().Publish(3);
                logger.Info("Selected Label3");
            }

        }

        private void ChangeColorToBlue()
        {
            if (IsSchriftfarbeChecked)
            {
                this.eventAggregator.GetEvent<ChangeLabelTextColorEvent>().Publish(Colors.Blue);
            }

            if (IsHintergrundfarbeChecked)
            {
                this.eventAggregator.GetEvent<ChangeLabelBackgroundColorEvent>()
                    .Publish(new SolidColorBrush(Colors.Blue));
            }
        }

        private void ChangeColorToGreen()
        {
            if (IsSchriftfarbeChecked)
            {
                this.eventAggregator.GetEvent<ChangeLabelTextColorEvent>().Publish(Colors.Green);
            }

            if (IsHintergrundfarbeChecked)
            {
                this.eventAggregator.GetEvent<ChangeLabelBackgroundColorEvent>()
                    .Publish(new SolidColorBrush(Colors.Green));
            }
        }

        private void ChangeColorToGYellow()
        {
            if (IsSchriftfarbeChecked)
            {
                this.eventAggregator.GetEvent<ChangeLabelTextColorEvent>().Publish(Colors.Yellow);
            }

            if (IsHintergrundfarbeChecked)
            {
                this.eventAggregator.GetEvent<ChangeLabelBackgroundColorEvent>()
                    .Publish(new SolidColorBrush(Colors.Yellow));
            }
        }

        private void ChangeColorToRed()
        {
            if (IsSchriftfarbeChecked)
            {
                this.eventAggregator.GetEvent<ChangeLabelTextColorEvent>().Publish(Colors.Red);
            }

            if (IsHintergrundfarbeChecked)
            {
                this.eventAggregator.GetEvent<ChangeLabelBackgroundColorEvent>()
                    .Publish(new SolidColorBrush(Colors.Red));
            }
        }
    }
}
