using System.Windows;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClient client = new MyClient();
        MyModel model;
        MapViewModel mapVm;
        BoardViewModel boardVm;
        JoyStickViewModel joyVm;

        //This method is the constructor that defines the component for the main window of the game.
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
        //This method shows the next window after the button clicked.
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            SettingsWindow subWindow = new SettingsWindow();
            subWindow.Show();
        }
        //This method close the window and the connection with the server after the button clicked.
        private void DisconnectButtonClicked(object sender, RoutedEventArgs e)
        {
            model.SetStop(true);
            client.Disconnect();
            this.Close();
        }
    }
}
