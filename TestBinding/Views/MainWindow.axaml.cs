using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using TestBinding.ViewModels;
using Serilog;

namespace TestBinding.Views;

public class Item
{
    public string? Grafcet { get; }

    public string? Type { get; }

    public string? Libelle { get; }
    


    public Item(string? grafcet, string? type, 
        string? libelle)
    {
        Grafcet = grafcet;
        Type = type;
        Libelle = libelle;
    }
}
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void DeleteRow(object sender, RoutedEventArgs e)
    {
        // Cast DataContext back to MainWindowViewModel to access Items property
        //var viewModel = DataContext as MainWindowViewModel;
        //viewModel.Items.Remove(SelectedItem);
    }
}