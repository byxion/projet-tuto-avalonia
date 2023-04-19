using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using Serilog;
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
    
    private string _grafcet;
    public string Grafcet
    {
        get => _grafcet;
        set => this.RaiseAndSetIfChanged(ref _grafcet, value);
    }
    
    private bool _export;
    public bool Export
    {
        get => _export;
        set => this.RaiseAndSetIfChanged(ref _export, value);
    }
    
    private string _libelle;
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

    public ObservableCollection<Item> Items { get; }
    public ObservableCollection<Item> ItemsCopy { get; set; } = new();
    public ICommand AddButtonClicked { get; }
    public ICommand DeleteButtonClick { get; }
    public ICommand EditButtonClicked { get; }
    public MainWindowViewModel()
    {
        Items = new ObservableCollection<Item>
        {
            new Item { Grafcet = "Grafcet 1", Export = true, Libelle = "Libellé 4" },
            new Item { Grafcet = "Grafcet 2", Export = true, Libelle = "Libellé 1" },
            new Item { Grafcet = "Grafcet 3", Export = false, Libelle = "Libellé 2" }
        };
        
        AddButtonClicked = ReactiveCommand.Create(() =>
        {
            // Créer une nouvelle fenêtre AddItem et donne la liste d'items
            var addItemWindow = new AddItemWindow();
            var addItemViewModel = new AddItemWindowViewModel(Items, ItemsCopy,addItemWindow);
            addItemWindow.DataContext = addItemViewModel;
            addItemWindow.Show();
        });
        
        DeleteButtonClick = ReactiveCommand.Create(() =>
        {
            // Récupérer l'élément de la ligne sélectionnée
            var selectedItem = SelectedItem as Item;
        
            if (selectedItem != null)
            {
                Items.Remove(selectedItem);
                if (ItemsCopy.Contains(selectedItem))
                {
                    ItemsCopy.Remove(selectedItem);
                }
            }
        });
        
        EditButtonClicked = ReactiveCommand.Create(() =>
        {
            var selectedItem = SelectedItem as Item;
            if (selectedItem != null)
            {
                // Créer une nouvelle fenêtre AddItem et donne la liste d'items et l'élément sélectionné
                var addItemWindow = new AddItemWindow();
                var addItemViewModel = new AddItemWindowViewModel(Items, ItemsCopy, selectedItem, addItemWindow);
                addItemWindow.DataContext = addItemViewModel;
                addItemWindow.Show();
            }
        });
    }
    
    /* Sort information */
    private string _filterText;
    public string FilterText
    {
        get => _filterText;
        set
        {
            this.RaiseAndSetIfChanged(ref _filterText, value);
            if (!string.IsNullOrEmpty(_filterText))
            {
                IsVisible = true;
            }
            else
            {
                IsVisible = false;
            }
        }
    }
    
    private bool _isVisible = false;
    public bool IsVisible
    {
        get => _isVisible;
        set => this.RaiseAndSetIfChanged(ref _isVisible, value);
    }
}