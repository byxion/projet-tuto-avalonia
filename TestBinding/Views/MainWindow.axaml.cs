using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using TestBinding.ViewModels;
using Serilog;

namespace TestBinding.Views;

public class Item
{
    public string Grafcet { get; set; }
    public string Type { get; set; }
    public string Libelle { get; set; }
}
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.AttachDevTools();
#if DEBUG
#endif
        DataContext = new MainWindowViewModel();
    }

    
    private void DeleteRow(object sender, RoutedEventArgs e)
    {
        // Cast DataContext back to MainWindowViewModel to access Items property
        //var viewModel = DataContext as MainWindowViewModel;
        //viewModel.Items.Remove(SelectedItem);
    }
}