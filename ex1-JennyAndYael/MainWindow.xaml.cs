using System.Windows;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClient client = new MyClient();
        MyModel model;
        MapViewModel mapVm;
        BoardViewModel boardVm;
        JoyStickViewModel joyVm;

        public MainWindow()
        {
            //try the server
            model = new MyModel(client);
            mapVm = new MapViewModel(model);
            boardVm = new BoardViewModel(model);
            joyVm = new JoyStickViewModel(model);
            model.Start();
            InitializeComponent();
            this.DataContext = mapVm;
            map.DataContext = mapVm;
            board.DataContext = boardVm;
            joystickSlider.DataContext = joyVm;
            joystickSlider.SetVmJoyStick(joyVm);
        }
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            SettingsWindow subWindow = new SettingsWindow();
            subWindow.Show();
        }
        private void DisconnectButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SetStop(true);
            client.Disconnect();
            this.Close();
        }
    }
}
