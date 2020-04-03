using System.Windows;


namespace ex1_JennyAndYael
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClient client = new MyClient();
        MapViewModel mapVM;
        BoardViewModel boardVm;
        JoyStickViewModel joyVM;

        public MainWindow()
        {
            //try the server
            MyModel model = new MyModel(client);
            mapVM = new MapViewModel(model);
            boardVm = new BoardViewModel(model);
            joyVM = new JoyStickViewModel(model);
            model.start();
            InitializeComponent();
            this.DataContext = mapVM;
            map.DataContext = mapVM;
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
