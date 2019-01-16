using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_PROJECT
{
    public partial class DiagramForm : Form
    {
        public DiagramForm()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
        }

        private void DiagramForm_Load(object sender, EventArgs e)
        {
            
        }

        Pen pen = null;

        public void Update(double temp , double score)
        {
            if(this.IsDisposed)
                return;
            var Ttemp =temp*picDiag.Width;
            var tScore = picDiag.Height - score;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            using(var g= picDiag.CreateGraphics())
            {
                
                g.FillEllipse(myBrush,new RectangleF((float)Ttemp, (float)tScore, 4, 4));
            }

            myBrush.Dispose();
        }

        private void picDiag_Click(object sender, EventArgs e)
        {            
        }
    }
}
