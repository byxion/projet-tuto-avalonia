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
    
    public bool IsItemSelected { get; set; }
    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        // Récupérer l'élément de la ligne sélectionnée
        var selectedItem = MyDataGrid.SelectedItem as Item;

        // Vérifier que l'élément est non nul
        if (selectedItem != null)
        {
            // Mettre à jour la propriété IsItemSelected
            IsItemSelected = true;

            // Supprimer l'élément de la liste Items
            (DataContext as MainWindowViewModel).Items.Remove(selectedItem);
        }
    }


}