using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Serilog;
using TestBinding.Views;

namespace TestBinding.ViewModels;

public class AddItemWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public ObservableCollection<Item> Items { get; set; }
    public AddItemWindowViewModel(ObservableCollection<Item> items)
    {
        Items = items;
    }

    
    private string _grafcet;
    public string Grafcet
    {
        get => _grafcet;
        set
        {
            if (_grafcet != value)
            {
                _grafcet = value;
                OnPropertyChanged(nameof(Grafcet));
            }
        }
    }
    
    private string _type;
    public string Type
    {
        get => _type;
        set
        {
            if (_type != value)
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
    }
    
    private string _libelle;
    public string Libelle
    {
        get => _libelle;
        set
        {
            if (_libelle != value)
            {
                _libelle = value;
                OnPropertyChanged(nameof(Libelle));
            }
        }
    }
    public void AddItem()
    {
        // Ajoute un item à la liste
        Items.Add(new Item { Grafcet = Grafcet, Type = Type, Libelle = Libelle });
    
        // Reset les champs
        Grafcet = "";
        Type = "";
        Libelle = "";
    }


}