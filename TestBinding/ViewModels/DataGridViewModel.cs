using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;
using Serilog;
using TestBinding.Models;
using TestBinding.Views;

namespace TestBinding.ViewModels;

public class DataGridViewModel : ViewModelBase
{
    public ObservableCollection<Item> Items { get; }
    public ObservableCollection<Item> ItemsCopy { get; set; } = new();
    public Item SelectedItem { get; set; }
    
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

    public DataGridViewModel()
    {
        Items = new ObservableCollection<Item>();
    }
    
    public DataGridViewModel(ObservableCollection<Item> items)
    {
        Items = items;
    }

    public void AddButtonClicked()
    {
        var addItemWindow = new AddItemWindow();
        var addItemViewModel = new AddItemWindowViewModel(Items, ItemsCopy,addItemWindow);
        addItemWindow.DataContext = addItemViewModel;
        addItemWindow.Show();
    }

    public void DeleteButtonClick()
    {
        // Remove the selected item from the list
        var selectedItem = SelectedItem;
        Items.Remove(selectedItem);
        if (ItemsCopy.Contains(selectedItem))
        {
            ItemsCopy.Remove(selectedItem);
        }
    }

    public void EditButtonClicked()
    {
        var selectedItem = SelectedItem;
        
        // Open the edit window
        var addItemWindow = new AddItemWindow();
        var addItemViewModel = new AddItemWindowViewModel(Items, ItemsCopy, selectedItem, addItemWindow);
        addItemWindow.DataContext = addItemViewModel; 
        addItemWindow.Show();
        
    }
}