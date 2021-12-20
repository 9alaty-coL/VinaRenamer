using MyRuleContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VinaRenamer
{
    class Numerical:MyRule
    {
        public static int curCount = 1;
        public string name { get; set; }
        public string description { get; set; }
        public Numerical(int k)
        {
            curCount = k;
            name = "Numerical";
            description = "1, 2, ...";
        }
        public void SetCount(int i)
        {
            curCount = i;
        }
        public override string Rename(string original)
        {
            string result = $"{curCount}_{original}";
            curCount++;
            return result;
        }
        public override UserControl GetMainWindow(Dictionary<string, string> res, ColorTheme theme)
        {
            return null;
        }
        public override MyRule CreateNew(Dictionary<string, string> res)
        {
            return new Numerical(1);
        }
        public override bool haveUI()
        {
            return false;
        }
        public override string saveRule()
        {
            return "Numerical ";
        }
        public override MyRule parseRule(string savedString)
        {
            return new Numerical(1);
        }
        public override string getMagicWord()
        {
            return "Numerical";
        }
        public override string ToString()
        {
            return "Numerical";
        }
    }
}
