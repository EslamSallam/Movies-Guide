using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < 100)
            {
                
                bunifuProgressBar1.Value++;
            }
            else
            {
                timer2.Start();
            }
        }

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.001)
            {
                this.Opacity -= 0.2;
            }
            else
            {
                this.Close();
            }
        }
    }
}
