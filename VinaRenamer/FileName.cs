using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaRenamer
{
    public class FileName : INotifyPropertyChanged
    {
        public string origin { get; set; }
        public string newName { get; set; }
        public string path { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        
            
    }
}
