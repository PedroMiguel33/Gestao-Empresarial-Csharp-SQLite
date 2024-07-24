using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.ComponentModel;
using Timer = System.Threading.Timer;

namespace CP
{
    [DefaultEvent("Click")]
    public partial class CBLGradientButton : UserControl
    {
        
        int wh = 20;  float ang = 45;
        Color cl0 = Color.Blue, cl1 = Color.Green;
        Timer t;
        string txt = "Text Button";
       
        public CBLGradientButton()
        {
           //t = new Timer();
           //DoubleBuffered = true;
           //t.Interval = 60;
           //t.Start();
           //t.Tick += (s, e) => { Angle = Angle % 360 + 1; };
           ForeColor = Color.White;
        }

        public float Angle
        {
            get { return ang; }
            set { ang = value; Invalidate(); }
        }

        public int borderRadius
        {
            get { return wh; }
            set { wh = value; Invalidate(); }
        }

        public Color Color0
        {
            get { return cl0; }
            set { cl0 = value; Invalidate(); }
        }
        public Color Color1
        {
            get { return cl1; }
            set { cl1 = value; Invalidate(); }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PNLGradientButton
            // 
            this.Name = "PNLGradientButton";
            this.Load += new System.EventHandler(this.PNLGradientButton_Load);
            this.ResumeLayout(false);

        }

        private void PNLGradientButton_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;                      
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(new Rectangle(0, 0, wh, wh), 180, 90);
            gp.AddArc(new Rectangle(Width-wh, 0, wh, wh), -90, 90);
            gp.AddArc(new Rectangle(Width - wh, Height-wh, wh, wh), 0, 90);
            gp.AddArc(new Rectangle(0, Height-wh, wh, wh), 90, 90);




            e.Graphics.FillPath(new LinearGradientBrush(ClientRectangle,cl0,cl1,ang), gp);
            e.Graphics.DrawString(txt, Font, new SolidBrush(ForeColor), ClientRectangle, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
            base.OnPaint(e);

        }


                  
        }
    }

