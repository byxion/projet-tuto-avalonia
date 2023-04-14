using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using Serilog;
using TestBinding.Views;

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
    public ObservableCollection<Item> Items { get; set; }
    public bool EditMode { get; set; }
    
    public int Index { get; set; } = 1;
    
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

    
    private string _grafcet;
    public string Grafcet
    {
        get => _grafcet;
        set => this.RaiseAndSetIfChanged(ref _grafcet, value);
    }
    
    private string _type;
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }
    
    private string _libelle;
    public string Libelle
    {
        get => _libelle;
        set => this.RaiseAndSetIfChanged(ref _libelle, value);
    }
    public void AddItem()
    {
        // Ajoute un item à la liste
        var item = new Item { Grafcet = Grafcet, Type = Type, Libelle = Libelle };
        
        if (EditMode)
        {
            Items[Index] = item;
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