using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using TestBinding.ViewModels;
using TestBinding.Models;

namespace TestBinding.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        DataContext = new MainWindowViewModel();
    }
    
    public void DeleteButton(object? sender, RoutedEventArgs e)
    {
        var item = (sender as Button)?.DataContext as Item;
        if (item != null)
        {
            (DataContext as MainWindowViewModel)?.Items.Remove(item);
        }
    }
}