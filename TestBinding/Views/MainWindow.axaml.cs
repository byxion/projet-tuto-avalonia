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

    public void DeleteButton(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as MainWindowViewModel;
        var item = (sender as Button)?.DataContext as Item;
        if (item != null)
        {
            viewModel.Items.Remove(item);
            viewModel.ItemsCopy.Remove(item);
        }
    }

    private void ShowPopup(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as MainWindowViewModel;
        if (viewModel != null)
        {
            viewModel.ItemsCopy.Clear();
            foreach (var item in viewModel.Items)
            {
                viewModel.ItemsCopy.Add(item);
            }

            var sortDataGrid = new SortDataGrid();
            var sortDataGridViewModel = new SortDataGridViewModel(viewModel.Items, sortDataGrid);
            sortDataGrid.DataContext = sortDataGridViewModel;
            sortDataGrid.ShowDialog(this);
            sortDataGrid.Closed += (sender, e) =>
            {
                if (sortDataGridViewModel.FilteredItems != null)
                {
                    string selectedGrafcet = sortDataGridViewModel.SelectedGrafcet;
                    var viewModel = DataContext as MainWindowViewModel;
                    if (viewModel != null)
                    {
                        viewModel.FilterText = selectedGrafcet;
                    }

                    viewModel.Items.Clear();
                    foreach (var item in sortDataGridViewModel.FilteredItems)
                    {
                        viewModel.Items.Add(item);
                    }
                }
            };
        }
    }
    
    private void ResetFilterButton(object? sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as MainWindowViewModel;
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
}