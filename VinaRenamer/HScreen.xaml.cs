using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using MyRuleContract;
//using MyThreeLayerContract;

namespace VinaRenamer
{
    /// <summary>
    /// Interaction logic for HScreen.xaml
    /// </summary>
    /// 
    

    public partial class HScreen : Window
    {
        public BindingList<FileName> originFName = new BindingList<FileName>();
        public BindingList<FileName> originFolder = new BindingList<FileName>();
        public BindingList<MyRule> MyRules = new BindingList<MyRule>();
        public Dictionary<string, string> res = new Dictionary<string, string>();
        public BindingList<MyRule> rules = new BindingList<MyRule>();
        public ColorTheme darkTheme = new ColorTheme();
        public ColorTheme lightTheme = new ColorTheme();
        public ColorTheme currentTheme;
        public bool folderMode = false;
        public HScreen(List<ColorTheme> colorThemes, String languageTag)
        {
            InitializeComponent();
            currentTheme = colorThemes[0];
            darkTheme = colorThemes[1];
            lightTheme = colorThemes[2];
            if (languageTag == "vi-VN")
            {
                currentLanguage.Tag = "vi-VN";
                currentLanguage.Source = new BitmapImage(new Uri("./Images/MainWindow/Vie.png", UriKind.Relative));
                ApplyLanguage();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            origin.ItemsSource = originFName;
            preview.ItemsSource = originFName;
            rule.ItemsSource = MyRules;
            originF.ItemsSource = originFolder;

            // Đặt dark mode và ngôn ngữ
            ApplyLanguage(currentLanguage.Tag.ToString());
            if (currentTheme == darkTheme)
                darkModeBtn.Switch();

            this.DataContext = currentTheme;
            toggleListviewColor();
            folderM.Visibility = Visibility.Collapsed;
            // load các dll

            //var buses = new BindingList<IBus>();
            //var daos = new BindingList<IData>();

            // Get list of DLL files in main executable folder
            string exePath = Assembly.GetExecutingAssembly().Location;
            string folder = System.IO.Path.GetDirectoryName(exePath);
            FileInfo[] fis = new DirectoryInfo(folder).GetFiles("*.dll");

            // Load all assemblies from current working directory
            foreach (FileInfo fileInfo in fis)
            {
                var domain = AppDomain.CurrentDomain;
                Assembly assembly = domain.Load(AssemblyName.GetAssemblyName(fileInfo.FullName));

                // Get all of the types in the dll
                Type[] types = assembly.GetTypes();

                // Only create instance of concrete class that inherits from IGUI, IBus or IDao
                foreach (var type in types)
                {
                    if (type.IsClass && !type.IsAbstract)
                    {
                        if (typeof(MyRule).IsAssignableFrom(type))
                            rules.Add(Activator.CreateInstance(type) as MyRule);

                        //else if (typeof(IBus).IsAssignableFrom(type))
                        //    buses.Add(Activator.CreateInstance(type) as IBus);
                        //else if (typeof(IData).IsAssignableFrom(type))
                        //    daos.Add(Activator.CreateInstance(type) as IData);
                    }
                }
            }

            cmbGUIList.ItemsSource = rules;
            cmbGUIList.SelectedIndex = 0;
            //cmbBusList.ItemsSource = buses;
            //cmbDaoList.ItemsSource = daos;
        }


        //private void closeBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (App.Current.Windows[1] != this)
        //        return;
        //    for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
        //        App.Current.Windows[intCounter].Close();
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

        private void ToggleButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.DataContext == darkTheme)
            {
                currentTheme = lightTheme;
            }
            else
                currentTheme = darkTheme;
            this.DataContext = currentTheme;
            toggleListviewColor();
        }

        //private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    //this.WindowStyle = WindowStyle.SingleBorderWindow;
        //    this.WindowState = WindowState.Minimized;
        //}


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

        private void Window_Closed(object sender, EventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
            MyRule selectedRule = cmbGUIList.SelectedItem as MyRule;

            if (selectedRule.haveUI())
            {
                var program = new CreateRuleWindow(selectedRule, res, currentTheme);
                if (program.ShowDialog() == true)
                {
                    MyRule newR = selectedRule.CreateNew(res);

                    MyRules.Add(newR);
                    updateName();
                }
            }
            else
            {
                MyRule newR = selectedRule.CreateNew(res);

                MyRules.Add(newR);
                updateName();
            }
            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //string newName = Prefix.Text;
            //foreach(var rule in MyRules)
            //{
            //    newName = rule.Rename(newName);
            //}
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int sl = origin.SelectedIndex;
            originFName.RemoveAt(sl);
            
        }

        



        private void browse_file_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.InitialDirectory = "c:\\";
            myDialog.Multiselect = true;
            myDialog.Title = "select file to rename";
            myDialog.ShowDialog();
            string[] resultName = myDialog.SafeFileNames;
            string[] resultPath = myDialog.FileNames;
            

            for(int i = 0; i < resultName.Length; i++)
            {
                originFName.Add(new FileName() { origin = resultName[i] ,path=resultPath[i] });
            }

            updateName();
        }
        public void updateName()
        {
            foreach (var file in originFName)
            {
                string temp = file.origin;
                foreach (var rule in MyRules)
                {
                    temp = rule.Rename(temp);
                }
                file.newName = temp;
            }

            foreach (var file in originFolder)
            {
                string temp = file.origin;
                foreach (var rule in MyRules)
                {
                    temp = rule.Rename(temp);
                }
                file.newName = temp;
            }
        }

        public void toggleListviewColor()
        {
            rule.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(currentTheme.textColor1));
            origin.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(currentTheme.textColor1));
            preview.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(currentTheme.textColor1));
            originF.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(currentTheme.textColor1));
        }

        private void browse_folder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string a = dialog.SelectedPath;
            if (a != "" && !folderMode)
            {
                string[] resultPath2;
                string[] resultName2;
                resultPath2 = Directory.GetFiles(a, "*.*", SearchOption.AllDirectories);
                resultName2 = Directory.GetFiles(a, "*.*", SearchOption.AllDirectories);
                for (int i = 0; i < resultName2.Length; i++)
                {
                    resultName2[i] = resultName2[i].Substring(resultName2[i].LastIndexOf(@"\")+1);
                }
                for (int i = 0; i < resultName2.Length; i++)
                {
                    originFName.Add(new FileName() { origin = resultName2[i], path = resultPath2[i] });
                }

                updateName();
            }
            else if (a != "" && folderMode)
            {
                string resultFolder = a.Substring(a.LastIndexOf(@"\") + 1);
                originFolder.Add(new FileName() { origin = resultFolder, path = a });
                updateName();
            }
            //foreach(var i in filesne)
            //{
            //    MessageBox.Show(i);
            //}
            //foreach(MyRule r in MyRules)
            //{
            //    MessageBox.Show(r.pareseRule("Addprefix xin chao"));
            //}

            //MyRule t = rules[0].pareseRule("addprefix xin chao");
            //MyRules.Add(t);

            //RuleParserFactory parser = new RuleParserFactory();
            //MyRules.Add(parser.parse(rules, "AddPrefix xin chao moi nguoi"));
        }

        private void load_click(object sender, RoutedEventArgs e)
        {
            //String line;
            //try
            //{
            //    //Pass the file path and file name to the StreamReader constructor
            //    StreamReader sr = new StreamReader("./rule.txt");
            //    //Read the first line of text
            //    line = sr.ReadLine();
            //    //Continue to read until you reach end of file
            //    while (line != null)
            //    {
            //        //write the line to console window
            //        Console.WriteLine(line);
            //        //Read the next line
            //        line = sr.ReadLine();
            //    }
            //    //close the file
            //    sr.Close();
            //    Console.ReadLine();
            //}
            //catch (Exception er)
            //{
            //    Console.WriteLine("Exception: " + er.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}
            Dictionary<string,string> myDic = new Dictionary<string,string>();
            myDic["filename"] = "";
            var load = new LoadRules(currentTheme, myDic);
            
            var loadResult = load.ShowDialog();
            if (loadResult == true)
            {
                MyRules.Clear();
                if (myDic["filename"] != "")
                {                   
                    using (var reader = new StreamReader($"data/{myDic["filename"]}.txt"))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            RuleParserFactory parser = new RuleParserFactory();
                            MyRules.Add(parser.parse(rules, line));
                        }
                    }
                    updateName();
                }
            }
            else if (loadResult == false)
            {

            }
        }

        private void rename_click(object sender, RoutedEventArgs e)
        {
            if (folderMode)
            {
                if (MyRules.Count() == 0 || originFolder.Count() == 0)
                    return;

            }
            else
            {
                if (MyRules.Count() == 0 || originFName.Count() == 0)
                    return;

                //foreach(var f in originFName)
                //{
                //    File.Move(f.path, f.path.Substring(0, f.path.LastIndexOf("\\") + 1) + f.newName);
                //}
            }

            
           

            //var save = new saveRules(currentTheme);
            //var saveResult = save.ShowDialog();
            //if (saveResult == true)
            //{
            //    MessageBox.Show("ok");
            //}
            //else if (saveResult == false)
            //{
            //    MessageBox.Show("no");
            //}
            //using (StreamWriter writetext = new StreamWriter("./data/root.txt"))
            //{
            //    writetext.WriteLine("writing in text file");
            //}
            MessageBoxResult result;
            result= MessageBox.Show("Bạn muốn lưu lại tập luật không?", "Question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                string Name = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                using (StreamWriter writetext = new StreamWriter("./data/root.txt", true))
                {
                    writetext.WriteLine(Name + " | " + MyRules.Count());
                }
                using (StreamWriter writetext2 = new StreamWriter("./data/" + Name + ".txt"))
                {
                    foreach(MyRule i in MyRules)
                    {
                        //writetext2.WriteLine(Name + " | " + MyRules.Count());
                        writetext2.WriteLine(i.saveRule());
                    }
                }
                originFName.Clear();
                MyRules.Clear();
                MessageBox.Show("Rename successfully!");
            }
            else if (result == MessageBoxResult.No)
            {
                originFName.Clear();
                MyRules.Clear();
                MessageBox.Show("Rename successfully!");

            }
            else if (result == MessageBoxResult.Cancel)
            {

            }
        }

        private void Delete_rule_Click(object sender, RoutedEventArgs e)
        {
            int sl = rule.SelectedIndex;
            MyRules.RemoveAt(sl);
            updateName();
        }

        private void ToggleButtonFolder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (folderMode)
            {
                fileM.Visibility = Visibility.Visible;
                folderM.Visibility = Visibility.Collapsed;
                preview.ItemsSource = originFName;
                folderMode = false;
            }
            else
            {
                fileM.Visibility = Visibility.Collapsed;
                folderM.Visibility = Visibility.Visible;
                preview.ItemsSource = originFolder;
                folderMode = true;
            }
        }

        private void Edit_rule_Click(object sender, RoutedEventArgs e)
        {
            MyRule selectedRule = MyRules[rule.SelectedIndex];
            int index = rule.SelectedIndex;

            if (selectedRule.haveUI())
            {
                var program = new CreateRuleWindow(selectedRule, res, currentTheme);
                if (program.ShowDialog() == true)
                {
                    MyRule newR = selectedRule.CreateNew(res);

                    MyRules[index] = newR;
                    updateName();
                    rule.ItemsSource = null; 
                    rule.ItemsSource = MyRules;
                }
            }
            else
            {
                MessageBox.Show("This rule can't be edited");
            }
        }

        private void Delete_Folder_Click(object sender, RoutedEventArgs e)
        {
            int sl = originF.SelectedIndex;
            originFolder.RemoveAt(sl);
        }
    }
}

