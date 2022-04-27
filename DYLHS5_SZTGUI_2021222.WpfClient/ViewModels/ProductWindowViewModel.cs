using DYLHS5_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    class ProductWindowViewModel : ObservableRecipient
    {
        public RestCollection<Product> Products { get; set; }


        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (value != null)
                {
                    selectedProduct = new Product()
                    {
                        ProductId = value.ProductId,
                        Color = value.Color,
                        Orders = value.Orders,
                        Price = value.Price,
                        ProductName = value.ProductName,
                        Size = value.Size,
                    };
                    OnPropertyChanged();
                    (DeleteProductCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateProductCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand UpdateProductCommand { get; set; }
        public ICommand CreateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }



        public ProductWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Products = new RestCollection<Product>("http://localhost:27588/", "product", "hub");
                CreateProductCommand = new RelayCommand(() =>
                {
                    Products.Add(new Product() { Size = SelectedProduct.Size, ProductName = SelectedProduct.ProductName, Price = SelectedProduct.Price, Color = SelectedProduct.Color, Orders = SelectedProduct.Orders });
                });
                DeleteProductCommand = new RelayCommand(() =>
                {
                    Products.Delete((int)SelectedProduct.ProductId);
                }, () => { return SelectedProduct != null; });
                UpdateProductCommand = new RelayCommand(() =>
                {
                    Products.Update(SelectedProduct);
                }, () => { return SelectedProduct != null; });
            }
            SelectedProduct = new Product();
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }

        }
    }
}

