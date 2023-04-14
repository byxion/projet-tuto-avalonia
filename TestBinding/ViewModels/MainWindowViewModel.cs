using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.Interactivity;
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
    
    private string _grafcet = "Grafcet 1";
    public string Grafcet
    {
        get { return _grafcet; }
        set
        {
            if (_grafcet != value)
            {
                _grafcet = value;
                OnPropertyChanged(nameof(Grafcet));
            }
        }
    }
    
    private string _type = "Type 1";
    public string Type
    {
        get { return _type; }
        set
        {
            if (_type != value)
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
    }
    
    private string _libelle = "Libellé 1";
    public string Libelle
    {
        get { return _libelle; }
        set
        {
            if (_libelle != value)
            {
                _libelle = value;
                OnPropertyChanged(nameof(Libelle));
            }
        }
    }
    
    private object _selectedItem;
    public object SelectedItem
    {
        get { return _selectedItem; }
        set { if(_selectedItem != value) { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); } }
    }

    
    public MainWindowViewModel()
    {
        // Initialize the collection of items
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
        var addItemWindow = new AddItemWindow();
        var addItemViewModel = new AddItemWindowViewModel(Items);
        addItemWindow.DataContext = addItemViewModel;
        addItemWindow.Show();
    }
    
    private void DeleteButtonClick()
    {
        // Récupérer l'élément de la ligne sélectionnée
        var selectedItem = SelectedItem as Item;

        // Vérifier que l'élément est non nul
        if (selectedItem != null)
        {
            // Supprimer l'élément de la liste Items
            Items.Remove(selectedItem);
        }
    }

    public void EditButtonClicked()
    {

        var selectedItem = SelectedItem as Item;
        if (selectedItem != null)
        {
            var addItemWindow = new AddItemWindow();
            var addItemViewModel = new AddItemWindowViewModel(Items, selectedItem);
            addItemWindow.DataContext = addItemViewModel;
            addItemWindow.Show();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}