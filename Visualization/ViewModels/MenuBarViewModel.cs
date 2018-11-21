using System.IO;
using System.Windows;
using Microsoft.Win32;
using NLog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using TestWpf.Visualization.Views;

namespace TestWpf.Visualization.ViewModels
{
    public class MenuBarViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DelegateCommand OpenCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand NewCommand { get; }
        public DelegateCommand ShowSettingsCommand { get; }

        public MenuBarViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.OpenCommand = new DelegateCommand(this.Open);
            this.SaveCommand=new DelegateCommand(this.Save);
            this.NewCommand=new DelegateCommand(this.New);
            this.ShowSettingsCommand=new DelegateCommand(this.ShowSettings);
        }

        private void Open()
        {
            //TODO try-catch einbauen für den Fall, dass Pfad nicht vorhanden oder leer ist

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt Files (*.txt)|*.txt";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.AddExtension = true;
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;

            FileStream stream=new FileStream(filename,FileMode.Open);
            StreamReader reader=new StreamReader(stream);
            MessageBox.Show(reader.ReadLine());
            reader.Close();

            logger.Info($"Opened file under {filename}");
        }

        private void Save()
        {
            //TODO try-catch einbauen für den Fall, dass Pfad nicht vorhanden oder leer ist

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Txt Files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;

            saveFileDialog.ShowDialog();
            string filename = saveFileDialog.FileName;

            FileStream stream=new FileStream(filename,FileMode.Create);
            StreamWriter writer=new StreamWriter(stream);

            writer.WriteLine(filename);
            writer.Close();

            logger.Info($"Saved file under {filename}");
        }

        private void New()
        {
           
        }

        private void ShowSettings()
        {
            SettingsView settingsView=new SettingsView();
            settingsView.Show();
        }
    }
}
