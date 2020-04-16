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
using System.Windows.Shapes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private SettingsViewModel vm;

        public SettingsWindow()
        {
            InitializeComponent();
            ApplicationSettingsModel modelApp = new ApplicationSettingsModel();
            vm = new SettingsViewModel(modelApp);
            this.DataContext = vm;
        }
        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            if (vm.VmWrongDetails == null)
            {
                vm.SaveSettings();
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
            }
        }
        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    
        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            vm.ResetToDefaultSettings();
        }

        private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextPortTextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
