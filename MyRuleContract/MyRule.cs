using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VinaRenamer;

namespace MyRuleContract
{
    public abstract class MyRule: INotifyPropertyChanged
    {
        public abstract string Rename(string original);
        public abstract UserControl GetMainWindow(Dictionary<string, string> res, ColorTheme theme);
        public abstract MyRule CreateNew(Dictionary<string, string> res);
        public abstract bool haveUI();
        public abstract string saveRule();
        public abstract MyRule parseRule(string savedString);
        public abstract string getMagicWord();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
