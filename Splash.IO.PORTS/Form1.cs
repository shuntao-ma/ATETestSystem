using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash.IO.PORTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var aa = USB.AllHostControllers;
            var bb = USB.AllUsbHubs;
            USB.GetHcdDriverKeyName(aa[0].PNPDeviceID);
        }
    }
}
