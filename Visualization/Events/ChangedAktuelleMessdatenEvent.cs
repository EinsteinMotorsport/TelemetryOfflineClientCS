using System.Collections.ObjectModel;
using Prism.Events;
using TestWpf.DataGeneration;

namespace TestWpf.Visualization.Events
{
    public class ChangedAktuelleMessdatenEvent : PubSubEvent<ObservableCollection<Datensatz>>
    {
    }
}
