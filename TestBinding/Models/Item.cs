namespace TestBinding.Models;

public class Item
{
    public string? Grafcet { get; set; }
    public bool? Export { get; set; }
    public string? Libelle { get; set; }
    
    public override string ToString()
    {
        return $"Grafcet: {Grafcet}, Export: {Export}, Libelle: {Libelle}";
    }
}