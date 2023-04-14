using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    
    private string _title = "Ajouter un item";
    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }
    private string _textButton = "Ajouter";
    public string TextButton
    {
        get => _textButton;
        set
        {
            if (_textButton != value)
            {
                _textButton = value;
                OnPropertyChanged(nameof(TextButton));
            }
        }
    }
    public ObservableCollection<Item> Items { get; set; }
    public bool EditMode { get; set; }
    
    public int Index { get; set; } = 1;
    
    public AddItemWindowViewModel()
    {
        Items = new ObservableCollection<Item>();
    }
    public AddItemWindowViewModel(ObservableCollection<Item> items)
    {
        Items = items;
        EditMode = false;
    }
    public AddItemWindowViewModel(ObservableCollection<Item> items,Item item)
    {
        Items = items;
        Grafcet = item.Grafcet;
        Type = item.Type;
        Libelle = item.Libelle;
        
        Index = Items.IndexOf(Items.First(x => x.Grafcet == Grafcet));
        
        EditMode = true;

        Title = "Modifier un item";
        TextButton = "Modifier";
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
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        var item = new Item { Grafcet = Grafcet, Type = Type, Libelle = Libelle };
        
        if (EditMode)
        {
            /* TODO */
        }
        else
        {
            Items.Add(item);
        }

        // Reset les champs
        Grafcet = "";
        Type = "";
        Libelle = "";
    }
}