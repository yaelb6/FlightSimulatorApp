using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlightSimulator.View.Controls
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {
        //bool mousePressed;
        private Point point = new Point();
        private JoyStickViewModel joyVm;

        public Joystick()
        {
            InitializeComponent();
        }

        public void SetVm(JoyStickViewModel joyVm)
        {
            this.joyVm = joyVm;
        }
        void CenterKnobCompleted(object sender, EventArgs e) { }

        private void KnobMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                point = e.GetPosition(this);
            }
        }

        private void KnobMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
        }

        private void KnobMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - point.X;
                double y = e.GetPosition(this).Y - point.Y;
                if ((Math.Sqrt(x * x + y * y) < Base.Width / 2) && (Math.Sqrt(x * x + y * y) < 140))
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    joyVm.JoyStickMoved(x, y);
                }
                else
                {
                    knobPosition.X = 0;
                    knobPosition.Y = 0;
                }
            }
        }

        private void EllipseMouseLeave(object sender, MouseEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
        }
    }
}
