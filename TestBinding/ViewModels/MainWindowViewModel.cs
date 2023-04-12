using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Serilog;
using TestBinding.Views;

namespace TestBinding.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private string _title = "Diagramme Grafcet"; 
    public string Title
    {
        get { return _title; }
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }
    
    public ObservableCollection<Item> Items { get; }
    
    public MainWindowViewModel()
    {
        Items = new ObservableCollection<Item>(GenerateMockPeopleTable());
    }

    private IEnumerable<Item> GenerateMockPeopleTable()
    {
        var defaultItems = new List<Item>()
        {
            new Item() { Grafcet = "G1", Type = "Type1", Libelle = "Libelle1" },
            new Item() { Grafcet = "G2", Type = "Type2", Libelle = "Libelle2" },
            new Item() { Grafcet = "G3", Type = "Type3", Libelle = "Libelle3" }
        };
        
        return defaultItems;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void AddButtonClicked()
    {
        var addItemWindow = new AddItemWindow();
        addItemWindow.Show();
    }
}