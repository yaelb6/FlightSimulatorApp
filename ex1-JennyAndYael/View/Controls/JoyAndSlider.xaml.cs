using System.Windows;
using System.Windows.Controls;

namespace FlightSimulator.View.Controls
{
    /// <summary>
    /// Interaction logic for JoyAndSlider.xaml
    /// </summary>
    public partial class JoyAndSlider : UserControl
    {
        public JoyAndSlider()
        {
            InitializeComponent();
        }
        public void SetVmJoyStick(JoyStickViewModel joyvm)
        {
            JoyStickElement.SetVm(joyvm);
        }

        private void TCopy2ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
