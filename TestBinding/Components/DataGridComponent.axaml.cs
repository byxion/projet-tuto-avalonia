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

    public ObservableCollection<Item> ItemsGrid { get; set; } = new()
    {
        new Item(){Grafcet = "Graf1", Export = true, Libelle = "Lib1",},
        new Item(){Grafcet = "Graf2", Export = true, Libelle = "Lib2",},
        new Item(){Grafcet = "Graf3", Export = false, Libelle = "Lib3",}
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
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();
        
        if (MyDataGridComponent != null)
        {
            MyDataGridComponent.Columns.Clear();
            Log.Information("dataGrid is not null {dataGrid}, {header}", MyDataGridComponent.Name , Headers);
        }
        else
        {
            Log.Error("dataGrid is null {dataGrid}", MyDataGridComponent);
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
        MyDataGridComponent.Items = ItemsGrid;
    }
}
