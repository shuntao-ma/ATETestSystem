using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATETestSystem
{
    class ControlInfo
    {
        public Point location;
        public int Width;
        public int Height;
        public string Name;
        public Font CtrFont;
        public List<ControlInfo> OldCtrl;
        public ControlInfo()
        {
            location = new Point(0, 0);
            Width = 0;
            Height = 0;
            Name = "";
            CtrFont = null;
            OldCtrl = new List<ControlInfo>();
        }
        public ControlInfo(Control control) : this()
        {
            OldCtrl = GetAllControls(control);
        }
        private List<ControlInfo> GetAllControls(Control control)
        {
            List<ControlInfo> list = new List<ControlInfo>();
            ControlInfo temp = new ControlInfo();
            temp.location = new Point(control.Location.X, control.Location.Y);
            temp.Width = control.Width;
            temp.Height = control.Height;
            temp.Name = control.Name;
            temp.CtrFont = control.Font;
            list.Add(temp);
            foreach (Control con in control.Controls)
            {
                temp = new ControlInfo();
                temp.location = new Point(con.Location.X, con.Location.Y);
                temp.Width = con.Width;
                temp.Height = con.Height;
                temp.Name = con.Name;
                temp.CtrFont = con.Font;
                list.Add(temp);
                if (con.Controls.Count > 0)
                {
                    list.AddRange(GetAllControls(con));
                }
            }
            return list;
        }
        public int FindCtr(string name)
        {
            for (int i = 0; i < OldCtrl.Count; i++)
            {
                if (OldCtrl[i].Name == name)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
