using System.Windows;
using Prism.Events;
using TestWpf.Visualization.ViewModels;

namespace TestWpf.Visualization
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var eventAggregator = new EventAggregator();

            this.DataContext = new MainViewModel(eventAggregator);
        }
    }
}
