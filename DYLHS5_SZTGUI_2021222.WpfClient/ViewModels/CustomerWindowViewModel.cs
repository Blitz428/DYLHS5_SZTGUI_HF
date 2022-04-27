using DYLHS5_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    class CustomerWindowViewModel : ObservableRecipient
    {
        public RestCollection<Customer> Customers { get; set; }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        CustomerId = value.CustomerId,
                        CustomerName = value.CustomerName,
                        Address = value.Address,
                        PhoneNumber = value.PhoneNumber
                    };
                    OnPropertyChanged();
                    (DeleteCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand UpdateCustomerCommand { get; set; }
        public ICommand CreateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public CustomerWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Customers = new RestCollection<Customer>("http://localhost:27588/", "customer");
                CreateCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Add(new Customer() { CustomerName = SelectedCustomer.CustomerName, Address = SelectedCustomer.Address, PhoneNumber = SelectedCustomer.PhoneNumber });
                });
                DeleteCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Delete((int)SelectedCustomer.CustomerId);
                }, () => { return SelectedCustomer != null; });
                UpdateCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Update(SelectedCustomer);
                }, () => { return SelectedCustomer != null; });
            }
            SelectedCustomer = new Customer();
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
