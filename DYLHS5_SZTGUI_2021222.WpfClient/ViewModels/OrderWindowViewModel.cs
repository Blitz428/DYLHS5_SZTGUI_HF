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
                        Customer = value.Customer,
                        CustomerId = value.CustomerId,
                        IsPrePaid = value.IsPrePaid,
                        IsTransportRequired = value.IsTransportRequired,
                        ProductId = value.ProductId,
                        Product = value.Product

                    };
                    OnPropertyChanged();
                    (DeleteOrderCommand as RelayCommand).NotifyCanExecuteChanged();
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
                Orders = new RestCollection<Order>("http://localhost:27588/", "order");


                CreateOrderCommand = new RelayCommand(() =>
                {
                    Orders.Add(new Order() { OrderId = SelectedOrder.OrderId, Customer = SelectedOrder.Customer, Product = SelectedOrder.Product, ProductId = SelectedOrder.ProductId, CustomerId = SelectedOrder.CustomerId, IsPrePaid = SelectedOrder.IsPrePaid, IsTransportRequired = SelectedOrder.IsTransportRequired, OrderTime = SelectedOrder.OrderTime });
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

