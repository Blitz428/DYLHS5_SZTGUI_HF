using System.ComponentModel;
using System.Windows;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    class MainWindowViewModel
    {
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
