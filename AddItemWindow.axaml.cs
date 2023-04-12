using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MyApp.ViewModels;
using Serilog;

namespace MyApp.Views
{
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.Console()
                .CreateLogger();

            Log.Error("Ini AddItemWindow.");
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public ItemViewModel ?ItemViewModel { get; set; }

        public void OnAddButtonClick()
        {
            Log.Error("OnAddButtonClick.");
            ItemViewModel?.AddItem();
            Close();
        }
    }
}
