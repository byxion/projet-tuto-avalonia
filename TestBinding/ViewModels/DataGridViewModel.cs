using System.Collections.ObjectModel;
using ReactiveUI;
using TestBinding.Models;

namespace TestBinding.ViewModels;

public class DataGridViewModel : ViewModelBase
{
    public ObservableCollection<Item> Items { get; set; }
    public ObservableCollection<Item> SelectedItem { get; set; }
    
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

}