using System.Collections.ObjectModel;
using TestBinding.Views;

namespace TestBinding.Models;

public class DemoItems : ObservableCollection<Item>
{
    private void AddItem(string? grafcet, string? type, 
        string? libelle)
    {
        this.Add(new Item(grafcet, type, libelle));
    }

    public DemoItems()
    {
        AddItem("G1", "Nice", "Wayne Enterprises");
        AddItem("Instant Tunnel", "Allows", "ACME Corp");
        AddItem("Brains for Scarecrow", "Provides", "OZ Production");
        AddItem("UniDock", "Multiplatform", "ACME Corp");
    }
}