using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestBinding.ViewModels;

namespace TestBinding.Views;

public partial class AddItemWindow : Window
{
    public AddItemWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}