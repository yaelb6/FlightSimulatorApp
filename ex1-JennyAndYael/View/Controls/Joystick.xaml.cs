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
    /// Interaction logic for Joystick.xaml.
    /// </summary>
    public partial class Joystick : UserControl
    {
        //bool mousePressed;
        private Point point = new Point();
        private JoyStickViewModel joyVM;

        public Joystick()
        {
            InitializeComponent();
        }
        //This function set the Joystick's view model be the given view model.
        public void setVm(JoyStickViewModel joyvm)
        {
            joyVM = joyvm;
        }
        
        void centerKnob_Completed(object sender, EventArgs e) { }

        //This function define the actions when the mouse is down.
        private void Knob_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                point = e.GetPosition(this);
            }
        }
        //This function define the actions when the mouse is up and alocate it position to the starting point.
        private void Knob_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
        }
        //This function define the actions when the mouse  is moving.
        //It calculated the new posotion and check if its in the frame and update the VM accordingly.
        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - point.X;
                double y = e.GetPosition(this).Y - point.Y;
                if ((Math.Sqrt(x * x + y * y) < Base.Width / 2) && (Math.Sqrt(x * x + y * y) < 140))
                {

                    knobPosition.X = x;
                    knobPosition.Y = y;
                    joyVM.JoyStickMoved(x, y);

                }
                else
                {
                    knobPosition.X = 0;
                    knobPosition.Y = 0;
                }
            }
        }
        //This function dbring the mouse position to the starting point.
        private void ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Throttle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Aileron_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Throttle_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
