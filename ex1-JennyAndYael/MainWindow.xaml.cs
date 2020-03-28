using System.Windows;


namespace ex1_JennyAndYael
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClient client = new MyClient();

        public MainWindow()
        {
            InitializeComponent();

            //try the server
            client.set("set /controls/engines/current-engine/throttle 0.5\n");
            client.get("get /controls/engines/current-engine/throttle\n");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DataTable_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
