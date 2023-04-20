using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;
using NP.Utilities;
using Serilog;
using TestBinding.Models;
using TestBinding.ViewModels;
using TestBinding.Views;

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
        new Item(){Grafcet = "Graf1", Export = true, Libelle = "Lib1"},
        new Item(){Grafcet = "Graf2", Export = true, Libelle = "Lib2"},
        new Item(){Grafcet = "Graf3", Export = false, Libelle = "Lib3"},
        new Item(){Grafcet = "Graf1", Export = true, Libelle = "Lib1"},
        new Item(){Grafcet = "Graf2", Export = true, Libelle = "Lib2"},
        new Item(){Grafcet = "Graf3", Export = false, Libelle = "Lib3"},
        new Item(){Grafcet = "Graf1", Export = true, Libelle = "Lib1"},
        new Item(){Grafcet = "Graf2", Export = true, Libelle = "Lib2"},
        new Item(){Grafcet = "Graf3", Export = false, Libelle = "Lib3"}
    };
    
    public DataGridComponent()
    {
        InitializeComponent();
        
        /* Default columns name */
        Headers = "Grafcet,Export,Libellé";
        
        MyDataGridComponent = this.FindControl<DataGrid>("MyDataGridComponent");
        this.GetObservable(HeadersProperty).Subscribe(x => UpdateDataGrid());
        
        DataContext = new DataGridViewModel(ItemsGrid);
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
            if (header == "Export")
            {
                DataGridTemplateColumn customColumn = new DataGridTemplateColumn();
                customColumn.Header = "Export";
                customColumn.CellTemplate = (DataTemplate)Resources["ExportTemplate"];
                MyDataGridComponent?.Columns.Add(customColumn);
            }
            else if (header == "Grafcet")
            {
                DataGridTemplateColumn customColumn = new DataGridTemplateColumn();
                customColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                customColumn.HeaderTemplate = (DataTemplate)Resources["GrafcetHeaderTemplate"]; 
                customColumn.CellTemplate = (DataTemplate)Resources["GrafcetCellTemplate"];
                MyDataGridComponent.Columns.Add(customColumn);
            }
            else
            {
                MyDataGridComponent.Columns.Add(new DataGridTextColumn()
                {
                    Header = header,
                    Binding = new Binding(header),
                    Width = new DataGridLength(1, DataGridLengthUnitType.Star)
                });
            }
        }
        MyDataGridComponent.Items = ItemsGrid;
    }
    
    private void ShowPopup(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as DataGridViewModel;
        if (viewModel == null)
        {
            return;
        }

        viewModel.ItemsCopy.Clear();
        foreach (var item in viewModel.Items)
        {
            viewModel.ItemsCopy.Add(item);
        }
        var sortDataGrid = new SortDataGrid();
        var sortDataGridViewModel = new SortDataGridViewModel(viewModel.Items, sortDataGrid);
        sortDataGrid.DataContext = sortDataGridViewModel;
        sortDataGrid.Show();
        sortDataGrid.Closed += (sender, e) =>
        {
            if (sortDataGridViewModel.FilteredItems != null)
            {
                string selectedGrafcet = sortDataGridViewModel.SelectedGrafcet;
                viewModel.FilterText = selectedGrafcet;
                viewModel.Items.Clear();
                foreach (var item in sortDataGridViewModel.FilteredItems)
                {
                    viewModel.Items.Add(item);
                }
            }
        };
    }
    
    private void ResetFilterButton(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as DataGridViewModel;
        if (viewModel != null && !viewModel.ItemsCopy.IsNullOrEmpty())
        {
            viewModel.Items.Clear();
            viewModel.FilterText = "";
            foreach (var item in viewModel.ItemsCopy)
            {
                viewModel.Items.Add(item);
            }
        }
    }
    
    private void DeleteButton(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as DataGridViewModel;
        if (viewModel != null)
        {
            viewModel.Items.Remove(viewModel.SelectedItem);
        }
    }

}
