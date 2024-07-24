using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CP
{
    class CBLDragControl : UserControl
    {
        private Control PNLControl;
        public Control PNLSelectTarget
        {
            get
            { 
                return PNLControl;
            }
            set
            {
                PNLControl = value;
                PNLControl.MouseDown += new MouseEventHandler(SelectedUepa);
            }
        }
        [DllImport("user32.DLL")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void RealeseCapture();
        
        private void SelectedUepa(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                CBLDragControl.RealeseCapture();
                CBLDragControl.SendMessage(PNLControl.FindForm().Handle, 0x112, 0xf012, 0);
            }
        }
    }
}
