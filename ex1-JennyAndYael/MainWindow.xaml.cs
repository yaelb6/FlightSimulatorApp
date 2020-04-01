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
        BoardViewModel boardVm;
        JoyStickViewModel joyVM;

        public MainWindow()
        {

            //try the server
            MyModel model = new MyModel(client);
            mapVm = new MapViewModel(model);
            boardVm = new BoardViewModel(model);
            joyVM = new JoyStickViewModel(model);
            model.start();
            InitializeComponent();
            map.DataContext = mapVm;
            board.DataContext = boardVm;
            joystickSlider.DataContext = joyVM;
            joystickSlider.setVmJoyS(joyVM);
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
        private void map_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
