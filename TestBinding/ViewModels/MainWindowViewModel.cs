using System.Collections.ObjectModel;
using ReactiveUI;
using TestBinding.Views;
using TestBinding.Models;

namespace TestBinding.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _title = "Diagramme Grafcet"; 
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private string _grafcet = "Grafcet 1";
    public string Grafcet
    {
        get => _grafcet;
        set => this.RaiseAndSetIfChanged(ref _grafcet, value);
    }
    
    private string _type = "Type 1";
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }
    
    private string _libelle = "Libellé 1";
    public string Libelle
    {
        get => _libelle;
        set => this.RaiseAndSetIfChanged(ref _libelle, value);
    }
    
    private object? _selectedItem;
    public object? SelectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
    }
    
    public MainWindowViewModel()
    {
        Items = new ObservableCollection<Item>
        {
            new Item { Grafcet = "Grafcet 1", Type = "Type 2", Libelle = "Libellé 4" },
            new Item { Grafcet = "Grafcet 2", Type = "Type 3", Libelle = "Libellé 1" },
            new Item { Grafcet = "Grafcet 3", Type = "Type 1", Libelle = "Libellé 2" },
            new Item { Grafcet = "Grafcet 4", Type = "Type 4", Libelle = "Libellé 3" }
        };
    }

    public ObservableCollection<Item> Items { get; }

    public void AddButtonClicked()
    {
        // Créer une nouvelle fenêtre AddItem et donne la liste d'items
        var addItemWindow = new AddItemWindow();
        var addItemViewModel = new AddItemWindowViewModel(Items);
        addItemWindow.DataContext = addItemViewModel;
        addItemWindow.Show();
    }
    
    private void DeleteButtonClick()
    {
        // Récupérer l'élément de la ligne sélectionnée
        var selectedItem = SelectedItem as Item;
        
        if (selectedItem != null)
        {
            Items.Remove(selectedItem);
        }
    }

    public void EditButtonClicked()
    {
        var selectedItem = SelectedItem as Item;
        if (selectedItem != null)
        {
            // Créer une nouvelle fenêtre AddItem et donne la liste d'items et l'élément sélectionné
            var addItemWindow = new AddItemWindow();
            var addItemViewModel = new AddItemWindowViewModel(Items, selectedItem);
            addItemWindow.DataContext = addItemViewModel;
            addItemWindow.Show();
        }
    }
}