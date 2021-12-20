using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for LoadRules.xaml
    /// </summary>
    public partial class LoadRules : Window

    {
        public class ruleInf{
            public string fileName { get; set; }
            public string Name { get; set; }
            public int quantity { get; set; }
        }
        BindingList<ruleInf> ruleSet = new BindingList<ruleInf>();
        Dictionary<string, string> dic;
        ColorTheme cr;
        public LoadRules(ColorTheme currentTheme, Dictionary<string, string> FN)
        {
            InitializeComponent();
            this.DataContext = currentTheme;
            cr = currentTheme;
            rule.ItemsSource = ruleSet;
            num.ItemsSource = ruleSet;
            dic = FN;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (rule.SelectedItem != null)
            {
                ruleInf choosed = rule.SelectedItem as ruleInf;
                dic["filename"] = choosed.fileName;
            }
            DialogResult = true;
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var reader = new StreamReader("./data/root.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int quantity2 = Int32.Parse(line.Substring(line.LastIndexOf(" ") + 1));
                    string newLine = line.Substring(0, line.LastIndexOf("|") - 1);
                    string displayName = "";
                    string[] tokens = newLine.Split(new string[] { "_" }, StringSplitOptions.None);
                    displayName = $"Date: {tokens[2]}/{tokens[1]}/{tokens[0]}   Time: {tokens[3]}:{tokens[4]}:{tokens[5]}";

                    ruleSet.Add(new ruleInf() { Name = displayName, quantity=quantity2, fileName=newLine });
                }
            }
            toggleListviewColor();
        }
        private void toggleListviewColor()
        {
            rule.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(cr.textColor1));
            num.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(cr.textColor1));
        }
    }
}
