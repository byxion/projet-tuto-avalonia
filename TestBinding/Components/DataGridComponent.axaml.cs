using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Serilog;
using TestBinding.Models;

namespace TestBinding.Components;

public partial class DataGridComponent : UserControl
{
    public string Headers
    {
        get { return (string)GetValue(HeadersProperty); }
        set { SetValue(HeadersProperty, value); }
    }

    public static readonly StyledProperty<string> HeadersProperty =
        AvaloniaProperty.Register<DataGridComponent, string>(nameof(Headers));

    public ObservableCollection<Item> Items { get; set; } = new()
    {
        new Item { Grafcet = "Grafcet 1", Export = true, Libelle = "Libellé 4" },
        new Item { Grafcet = "Grafcet 2", Export = true, Libelle = "Libellé 1" },
        new Item { Grafcet = "Grafcet 3", Export = false, Libelle = "Libellé 2" }
    };
    
    public DataGridComponent()
    {
        InitializeComponent();
        /* Defaut si aucune colonnes mise dans le xaml */
        Headers = "Grafcet,Export,Libellé";
        MyDataGridComponent = this.FindControl<DataGrid>("MyDataGridComponent");
        
        this.GetObservable(HeadersProperty).Subscribe(x => UpdateDataGrid());
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public void UpdateDataGrid()
    {
        if (MyDataGridComponent != null)
        {
            MyDataGridComponent.Columns.Clear();
        }
        else
        {
            Log.Error("dataGrid is null{dataGrid}", MyDataGridComponent);
        }
        foreach (var header in Headers.Split(','))
        {
            MyDataGridComponent.Columns.Add(new DataGridTextColumn()
            {
                Header = header,
                Binding = new Binding(header),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            });
        }
        MyDataGridComponent.Items = Items;
    }
}
