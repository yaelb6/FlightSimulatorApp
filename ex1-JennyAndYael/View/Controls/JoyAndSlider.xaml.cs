using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ex1_JennyAndYael.View.Controls
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
        public void setVmJoyS(JoyStickViewModel joyvm)
        {

            JoyStickElement.setVm(joyvm);
        }

        private void T_Copy2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
