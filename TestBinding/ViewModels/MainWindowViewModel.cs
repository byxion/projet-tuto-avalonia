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
    public MainWindowViewModel()
    {
    }
}