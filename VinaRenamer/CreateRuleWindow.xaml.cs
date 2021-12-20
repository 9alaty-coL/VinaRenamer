using MyRuleContract;
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

namespace VinaRenamer
{
    /// <summary>
    /// Interaction logic for CreateRuleWindow.xaml
    /// </summary>
    public partial class CreateRuleWindow : Window
    {
        MyRule selectedRule;
        Dictionary<string, string> response;
        ColorTheme crr;
        public CreateRuleWindow(MyRule gui, Dictionary<string, string> res, ColorTheme currentTheme)
        {
            crr = currentTheme;
            response = res;
            selectedRule = gui;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            response["flag"] = "0";
            var control = selectedRule.GetMainWindow(response, crr);
            
            Content.Children.Add(control);
            Content.Width = control.Width;
            Content.Height = control.Height;
            
            //MainWindow.DataContext = control;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Application.Current.Shutdown();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (response["flag"] == "1")
                DialogResult = true;
            else
                DialogResult = false;
        }
    }
}
