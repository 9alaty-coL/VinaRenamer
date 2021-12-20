using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyThreeLayerContract
{
    public abstract class IGUI
    {
        protected IBus _bus;

        public abstract UserControl GetMainWindow();
        public abstract IGUI CreateNew(IBus bus);
    }
}
