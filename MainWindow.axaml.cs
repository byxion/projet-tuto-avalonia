using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using MyApp.Views;
using MyApp.ViewModels;
using Avalonia.Media;
using Serilog;
using Avalonia.Data;

namespace MyApp;

public class Item
{
    public string ?Grafcet { get; set; }
    public string ?Type { get; set; }
    public string ?Libelle { get; set; }
    public IBrush ?Background { get; set; }
}
public partial class MainWindow : Window
{
    public ObservableCollection<Item> Items { get; set; }
    public Item ?SelectedItem { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        #if DEBUG
        this.AttachDevTools();
        #endif
        Items = new ObservableCollection<Item>();
        // Ajouter un élément en dur dans le tableau pour tester l'affichage
        Items.Add(new Item { Grafcet = "Grafcet1", Type = "Type1", Libelle = "Libellé1" });
        DataContext = this;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void AddButton_Click(object sender, RoutedEventArgs e)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .WriteTo.Console()
            .CreateLogger();

        Log.Error("Click 1er ajout.");
        Log.CloseAndFlush();
        var addItemWindow = new AddItemWindow();
        addItemWindow.ItemViewModel = new ItemViewModel();
        addItemWindow.DataContext = addItemWindow.ItemViewModel;

        await addItemWindow.ShowDialog(this);

        Items.Clear();
        Log.Error("Clear");
        foreach (var item in addItemWindow.ItemViewModel.Items)
        {
            Log.Error("Add " + item.Grafcet);
            Items.Add(item);
        }
        Log.Error("End");
        Log.CloseAndFlush();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedItem != null)
        {
            Items.Remove(SelectedItem);
        }
    }
}