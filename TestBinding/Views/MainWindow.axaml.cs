using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using NP.Utilities;
using Serilog;
using TestBinding.Components;
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
}