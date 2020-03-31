using System.Windows;


namespace ex1_JennyAndYael
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClient client = new MyClient();
        MapViewModel mapVm;

        public MainWindow()
        {

            //try the server
            MyModel model = new MyModel(client);
            mapVm = new MapViewModel(model);
            //map.DataContext = mapViewModel;
            model.start();
            InitializeComponent();
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
