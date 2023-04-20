using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
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
    private ObservableCollection<Item> ItemsCopy { get; set; }
    private bool EditMode { get; set; }
    private int Index { get; set; } = -1;
    private int IndexCopy { get; set; } = -1;
    public Window Window { get; set; }
    
    public AddItemWindowViewModel()
    {
        Items = new ObservableCollection<Item>();
        EditMode = false;
    }
    
    /* Add an Item */
    public AddItemWindowViewModel(ObservableCollection<Item> items, ObservableCollection<Item> itemsCopy, Window window)
    {
        Items = items;
        ItemsCopy = itemsCopy;
        EditMode = false;
        Window = window; /* Propre ? */
    }
    
    /* Edit an Item */
    public AddItemWindowViewModel(ObservableCollection<Item> items, ObservableCollection<Item> itemCopy, Item item, Window window)
    {
        Items = items;
        ItemsCopy = itemCopy;
        Window = window; /* Propre ? */
        Grafcet = item.Grafcet;
        Export = item.Export;
        Libelle = item.Libelle;
        
        Index = Items.IndexOf(Items.First(x => x.Grafcet == Grafcet));
        IndexCopy = ItemsCopy.IndexOf(ItemsCopy.First(x => x.Grafcet == Grafcet));
        
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
    
    private bool? _export;
    public bool? Export
    {
        get => _export;
        set => this.RaiseAndSetIfChanged(ref _export, value);
    }
    
    private string? _libelle;
    public string? Libelle
    {
        get => _libelle;
        set => this.RaiseAndSetIfChanged(ref _libelle, value);
    }
    
    public void AddItem()
    {
        var item = new Item { Grafcet = Grafcet, Export = Export, Libelle = Libelle };

        if (EditMode)
        {
            // Replace the item in the list 
            Items[Index] = item;
            ItemsCopy[IndexCopy] = item;
        }
        else
        {
            // Add the item in the list
            Items.Add(item);
            ItemsCopy.Add(item);
            
            // Reset the fields
            Grafcet = "";
            Export = false;
            Libelle = "";
        }
        Window.Close();
    }
}