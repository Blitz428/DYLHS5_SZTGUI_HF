using System.Windows;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CustomerWindow().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new OrderWindow().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new ProductWindow().Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
