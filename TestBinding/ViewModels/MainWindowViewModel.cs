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
            new Item("G1", "Type1", "Libelle1"),
            new Item("G2", "Type2", "Libelle2"),
            new Item("G3", "Type3", "Libelle3")
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