using System.ComponentModel;
using TestBinding.Views;

namespace TestBinding.ViewModels;

public class AddItemWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private string _grafcet;
    public string Grafcet
    {
        get => _grafcet;
        set
        {
            if (_grafcet != value)
            {
                _grafcet = value;
                OnPropertyChanged(nameof(Grafcet));
            }
        }
    }
    
    private string _type;
    public string Type
    {
        get => _type;
        set
        {
            if (_type != value)
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
    }
    
    private string _libelle;
    public string Libelle
    {
        get => _libelle;
        set
        {
            if (_libelle != value)
            {
                _libelle = value;
                OnPropertyChanged(nameof(Libelle));
            }
        }
    }
    
    public void AddItem()
    {
        var item = new Item() { Grafcet = Grafcet, Type = Type, Libelle = Libelle };
        //Items.Add(item);
    }
}