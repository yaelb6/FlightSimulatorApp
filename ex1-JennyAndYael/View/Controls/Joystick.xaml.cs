using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ex1_JennyAndYael.View.Controls
{
    public partial class Joystick : UserControl 
    {
        public Joystick()
        {
            InitializeComponent();
        }
        void centerKnob_Completed(object sender, EventArgs e){ }

        private void Knob_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
