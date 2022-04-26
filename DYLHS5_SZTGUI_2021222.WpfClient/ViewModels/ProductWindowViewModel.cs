using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    class ProductWindowViewModel
    {
        public RestCollection<Product> Products { get; set; }
        public ProductWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Products = new RestCollection<Product>("http://localhost:27588/", "product");
            }
            
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
