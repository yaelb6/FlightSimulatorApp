using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ex1_JennyAndYael.View.Controls
{
    public partial class Joystick : UserControl 
    {
        //bool mousePressed;
        private Point point = new Point();

        public Joystick()
        {
            InitializeComponent();
        }
        void centerKnob_Completed(object sender, EventArgs e){ }

        private void Knob_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                point = e.GetPosition(this);
            }
        }

        private void Knob_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
        }        

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - point.X;
                double y = e.GetPosition(this).Y - point.Y;
                if (Math.Sqrt(x * x + y * y) < Base.Width/2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                }

            }
        }

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
    }
}
