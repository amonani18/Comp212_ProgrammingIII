using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant_Bill_Calculator_
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<MenuItem> BeverageMenu { get; set; }
        public ObservableCollection<MenuItem> AppetizerMenu { get; set; }
        public ObservableCollection<MenuItem> MainCourseMenu { get; set; }
        public ObservableCollection<MenuItem> DessertMenu { get; set; }
        public ObservableCollection<MenuItem> Items { get; set; }

        private decimal subTotal;
        public decimal SubTotal
        {
            get { return subTotal; }
            set
            {
                subTotal = value;
                OnPropertyChanged(nameof(SubTotal));
                OnPropertyChanged(nameof(Tax));
                OnPropertyChanged(nameof(Total));
            }
        }

        public decimal Tax => SubTotal * 0.10m;
        public decimal Total => SubTotal + Tax;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            BeverageMenu = new ObservableCollection<MenuItem>
            {
                new MenuItem { Name = "Soda", Category = "Beverage", Price = 1.95m },
                new MenuItem { Name = "Tea", Category = "Beverage", Price = 1.50m },
                new MenuItem { Name = "Coffee", Category = "Beverage", Price = 1.25m },
                new MenuItem { Name = "Mineral Water", Category = "Beverage", Price = 2.95m },
                new MenuItem { Name = "Juice", Category = "Beverage", Price = 2.50m },
                new MenuItem { Name = "Milk", Category = "Beverage", Price = 1.50m }
            };
            AppetizerMenu = new ObservableCollection<MenuItem>
            {
                new MenuItem { Name = "Buffalo Wings", Category = "Appetizer", Price = 5.95m },
                new MenuItem { Name = "Buffalo Fingers", Category = "Appetizer", Price = 6.95m },
                new MenuItem { Name = "Potato Skins", Category = "Appetizer", Price = 8.95m },
                new MenuItem { Name = "Nachos", Category = "Appetizer", Price = 8.95m },
                new MenuItem { Name = "Mushroom Caps", Category = "Appetizer", Price = 10.95m },
                new MenuItem { Name = "Shrimp Cocktail", Category = "Appetizer", Price = 12.95m },
                new MenuItem { Name = "Chips and Salsa", Category = "Appetizer", Price = 6.95m }
            };
            MainCourseMenu = new ObservableCollection<MenuItem>
            {
                new MenuItem { Name = "Seafood Alfredo", Category = "Main Course", Price = 15.95m },
                new MenuItem { Name = "Chicken Alfredo", Category = "Main Course", Price = 13.95m },
                new MenuItem { Name = "Chicken Picatta", Category = "Main Course", Price = 13.95m },
                new MenuItem { Name = "Turkey Club", Category = "Main Course", Price = 11.95m },
                new MenuItem { Name = "Lobster Pie", Category = "Main Course", Price = 19.95m },
                new MenuItem { Name = "Prime Rib", Category = "Main Course", Price = 20.95m },
                new MenuItem { Name = "Shrimp Scampi", Category = "Main Course", Price = 18.95m },
                new MenuItem { Name = "Turkey Dinner", Category = "Main Course", Price = 13.95m },
                new MenuItem { Name = "Stuffed Chicken", Category = "Main Course", Price = 14.95m }
            };
            DessertMenu = new ObservableCollection<MenuItem>
            {
                new MenuItem { Name = "Apple Pie", Category = "Dessert", Price = 5.95m },
                new MenuItem { Name = "Sundae", Category = "Dessert", Price = 3.95m },
                new MenuItem { Name = "Carrot Cake", Category = "Dessert", Price = 5.95m },
                new MenuItem { Name = "Mud Pie", Category = "Dessert", Price = 4.95m },
                new MenuItem { Name = "Apple Crisp", Category = "Dessert", Price = 5.95m }
            };

            Items = new ObservableCollection<MenuItem>();

            comboBoxBeverage.ItemsSource = BeverageMenu;
            comboBoxAppetizer.ItemsSource = AppetizerMenu;
            comboBoxMainCourse.ItemsSource = MainCourseMenu;
            comboBoxDessert.ItemsSource = DessertMenu;

            dataGridItems.ItemsSource = Items;

            Items.CollectionChanged += (s, e) => UpdateBill();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is MenuItem selectedItem)
            {
                AddSelectedItem(selectedItem);
                comboBox.SelectedItem = null; // Reset ComboBox selection
            }
        }

        private void AddSelectedItem(MenuItem selectedItem)
        {
            var existingItem = Items.FirstOrDefault(i => i.Name == selectedItem.Name);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var newItem = new MenuItem
                {
                    Name = selectedItem.Name,
                    Category = selectedItem.Category,
                    Price = selectedItem.Price,
                    Quantity = 1
                };
                newItem.PropertyChanged += (s, e) => UpdateBill();
                Items.Add(newItem);
            }
            UpdateBill();
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is MenuItem selectedItem)
            {
                Items.Remove(selectedItem);
                UpdateBill();
            }
        }

        private void ClearBill_Click(object sender, RoutedEventArgs e)
        {
            Items.Clear();
            UpdateBill();
        }

        private void UpdateBill()
        {
            SubTotal = Items.Sum(i => i.Total);
            textBlockSubTotal.Text = SubTotal.ToString("C");
            textBlockTax.Text = Tax.ToString("C");
            textBlockTotal.Text = Total.ToString("C");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MenuItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(Total));
            }
        }
        public decimal Total => Price * Quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
