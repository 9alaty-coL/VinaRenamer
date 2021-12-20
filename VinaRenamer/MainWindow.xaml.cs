using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace VinaRenamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ColorTheme darkTheme = new ColorTheme();
        public ColorTheme lightTheme = new ColorTheme();
        public ColorTheme currentTheme;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyLanguage(currentLanguage.Tag.ToString());

            darkTheme.color1 = "#0F0F2D";
            darkTheme.color2 = "#181735";
            darkTheme.buttonColor1 = "#FF6584";
            darkTheme.buttonColor1_press = "#FF4C70";
            darkTheme.buttonColor2 = "#39385D";
            darkTheme.buttonColor2_press = "#3A3952";
            darkTheme.buttonColor3 = "#39385D";
            darkTheme.buttonColor3_press = "#3A3952";
            darkTheme.textColor1 = "#ffffff";
            darkTheme.textColor2 = "LightGray";
            darkTheme.listViewColor = "#4E4E8A";


            lightTheme.color1 = "#0099CC";
            lightTheme.color2 = "#66CCFF";
            lightTheme.buttonColor1 = "#DD4553";
            lightTheme.buttonColor1_press = "#FF4C70";
            lightTheme.buttonColor2 = "#98CCC7";
            lightTheme.buttonColor2_press = "#BCEEE9";
            lightTheme.buttonColor3 = "#98CCC7";
            lightTheme.buttonColor3_press = "#BCEEE9";
            lightTheme.textColor1 = "#000000";
            lightTheme.textColor2 = "#333333";
            lightTheme.listViewColor = "#BFE9FF";

            currentTheme = lightTheme;
            this.DataContext = currentTheme;
        }

        private void ToggleButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentTheme == darkTheme)
                currentTheme = lightTheme;
            else
                currentTheme = darkTheme;
            this.DataContext = currentTheme;
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.WindowState = WindowState.Minimized;
        }


        private void Language_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (currentLanguage.Tag.ToString() == "en-US")
            {
                currentLanguage.Tag = "vi-VN";

                currentLanguage.Source = new BitmapImage(new Uri("./Images/MainWindow/Vie.png", UriKind.Relative));
            }
            else
            {
                currentLanguage.Tag = "en-US";
                currentLanguage.Source = new BitmapImage(new Uri("./Images/MainWindow/Eng.png", UriKind.Relative));
            }

            ApplyLanguage(currentLanguage.Tag.ToString());
        }
        //private void MainWindow_OnActivated(object sender, EventArgs e)
        //{
        //    //change the WindowStyle back to None, but only after the Window has been activated
        //    Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => WindowStyle = WindowStyle.None));
        //}

        public void ApplyLanguage(string cultureName = null)
        {
            if (cultureName != null)
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);

            ResourceDictionary dict = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "vi-VN":
                    dict.Source = new Uri(@".\Lang\Vietnamese.xaml", UriKind.Relative);
                    break;
                // ...
                default:
                    dict.Source = new Uri(@".\Lang\English.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dict);

            // check/uncheck the language menu items based on the current culture
            //foreach (var item in languageMenuItem.Items)
            //{
            //    MenuItem menuItem = item as MenuItem;
            //    if (menuItem.Tag.ToString() == Thread.CurrentThread.CurrentCulture.Name)
            //        menuItem.IsChecked = true;
            //    else
            //        menuItem.IsChecked = false;
            //}
            //var item = currentLanguage.Tag;
            //MenuItem menuItem = item as MenuItem;
            //if (menuItem.Tag.ToString() == Thread.CurrentThread.CurrentCulture.Name)
            //    menuItem.IsChecked = true;
            //else
            //    menuItem.IsChecked = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            List<ColorTheme> colorThemes = new List<ColorTheme>();
            colorThemes.Add(currentTheme);
            colorThemes.Add(darkTheme);
            colorThemes.Add(lightTheme);
            String languageTag = currentLanguage.Tag.ToString();
            HScreen mainScreen = new HScreen(colorThemes, languageTag);
            Visibility = Visibility.Hidden;
            mainScreen.Show();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://www.facebook.com/tanloc.tran.16");
        }
        private void TextBlock_MouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://github.com/9alaty-coL/VinaRenamer");
        }
    }
}

