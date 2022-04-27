using DYLHS5_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    class OrderWindowViewModel : ObservableRecipient
    {
        public RestCollection<Order> Orders { get; set; }
        public RestCollection<Customer> Customers { get; set; }
        public RestCollection<Product> Products { get; set; }

        private int? customerIndex;

        public int? CustomerIndex
        {
            get { return customerIndex; }
            set 
            { 
                customerIndex = value;
                OnPropertyChanged();
            }
        }

        private int? productIndex;

        public int? ProductIndex
        {
            get { return productIndex; }
            set
            {
                productIndex = value;
                OnPropertyChanged();
            }
        }



        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (value != null)
                {
                    selectedOrder = new Order()
                    {
                        OrderId = value.OrderId,
                        OrderTime = value.OrderTime,
                        IsPrePaid = value.IsPrePaid,
                        IsTransportRequired = value.IsTransportRequired,
                        Product = value.Product,
                        Customer = value.Customer,
                        ProductId = value.ProductId,
                        CustomerId = value.CustomerId
                    };
                    if (selectedOrder!=null)
                    {
                        CustomerIndex = selectedOrder.CustomerId - 1;
                        ProductIndex = selectedOrder.ProductId - 1;
                    }
                    
                    OnPropertyChanged();
                    (DeleteOrderCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateOrderCommand as RelayCommand).NotifyCanExecuteChanged();
                }


            }
        }



        public ICommand UpdateOrderCommand { get; set; }
        public ICommand CreateOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }



        public OrderWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Orders = new RestCollection<Order>("http://localhost:27588/", "order", "hub");
                Customers = new RestCollection<Customer>("http://localhost:27588/", "customer", "hub");
                Products = new RestCollection<Product>("http://localhost:27588/", "product", "hub");

                CreateOrderCommand = new RelayCommand(() =>
                {
                    Orders.Add(new Order()
                    {
                        IsPrePaid = SelectedOrder.IsPrePaid,
                        IsTransportRequired = SelectedOrder.IsTransportRequired,
                        OrderTime = SelectedOrder.OrderTime,
                        Customer = SelectedOrder.Customer,
                        Product = SelectedOrder.Product
                    });
                });
                DeleteOrderCommand = new RelayCommand(() =>
                {
                    Orders.Delete((int)SelectedOrder.OrderId);
                }, () => { return SelectedOrder != null; });
                UpdateOrderCommand = new RelayCommand(() =>
                {
                    Orders.Update(SelectedOrder);
                }, () => { return SelectedOrder != null; });
            }
            SelectedOrder = new Order();
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

