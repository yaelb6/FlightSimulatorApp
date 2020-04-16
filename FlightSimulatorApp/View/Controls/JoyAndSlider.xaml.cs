using System.Windows;
using System.Windows.Controls;

namespace FlightSimulator.View.Controls
{
    /// <summary>
    /// Interaction logic for JoyAndSlider.xaml.
    /// </summary>
    public partial class JoyAndSlider : UserControl
    {
        public JoyAndSlider()
        {
            //This function initialize all the component from the xml.
            InitializeComponent();
        }
        //This function set the Joystick's view model be the given view model.
        public void SetVmJoyStick(JoyStickViewModel joyvm)
        {
            JoyStickElement.SetVm(joyvm);
        }

        private void TCopy2ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
