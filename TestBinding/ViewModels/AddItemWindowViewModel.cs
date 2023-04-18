using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using TestBinding.Models;

namespace TestBinding.ViewModels;

public class AddItemWindowViewModel : ViewModelBase
{

    private string _title = "Ajouter un item"; 
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private string _textButton = "Ajouter"; 
    public string TextButton
    {
        get => _textButton;
        set => this.RaiseAndSetIfChanged(ref _textButton, value);
    } 
    
    private ObservableCollection<Item> Items { get; set; }
    private bool EditMode { get; set; }
    private int Index { get; set; } = -1;
    
    public AddItemWindowViewModel()
    {
        Items = new ObservableCollection<Item>();
        EditMode = false;
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

    private string? _grafcet;
    public string? Grafcet
    {
        get => _grafcet;
        set => this.RaiseAndSetIfChanged(ref _grafcet, value);
    }
    
    private bool? _type;
    public bool? Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }
    
    private string? _libelle;
    public string? Libelle
    {
        get => _libelle;
        set => this.RaiseAndSetIfChanged(ref _libelle, value);
    }
    
    public void AddItem()
    {
        var item = new Item { Grafcet = Grafcet, Type = Type, Libelle = Libelle };

        if (EditMode)
        {
            // Remplace l'item à l'index
            Items[Index] = item; 
            
            // Fermer la fenêtre AddItemWindow
            /* TODO */
        }
        else
        {
            // Ajoute l'item à la fin de la liste
            Items.Add(item);
            
            // Reset les champs
            Grafcet = "";
            Type = false;
            Libelle = "";
        }
    }
}