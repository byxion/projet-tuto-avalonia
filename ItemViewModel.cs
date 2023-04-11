using System.Collections.ObjectModel;
using Avalonia.Media;
using Serilog;

namespace MyApp.ViewModels
{
    public partial class ItemViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public ItemViewModel()
        {
            Items = new ObservableCollection<Item>()
            {
                new Item() { Grafcet = "A", Type = "Type 1", Libelle = "Libellé 1", Background = Brushes.White },
                new Item() { Grafcet = "B", Type = "Type 2", Libelle = "Libellé 2", Background = Brushes.LightGray },
                new Item() { Grafcet = "C", Type = "Type 3", Libelle = "Libellé 3", Background = Brushes.White },
                new Item() { Grafcet = "D", Type = "Type 4", Libelle = "Libellé 4", Background = Brushes.LightGray }
            };
        }

        public void AddItem()
        {
            var item = new Item() { Grafcet = Grafcet, Type = Type, Libelle = Libelle };
            Items.Add(item);
        }

        private string ?_grafcet;
        public string ?Grafcet
        {
            get => _grafcet;
            set{
                _grafcet = value;
            }
        }
        private string ?_type;
        public string ?Type
        {
            get => _type;
            set{ _type = value; }
        }

        private string ?_libelle;
        public string ?Libelle
        {
            get => _libelle;
            set{ _libelle = value; }
        }

    }
}
