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
    public partial class alert : Form
    {
        public alert(string _message, AlertType type)
        {
            InitializeComponent();

            message.Text = _message;

            switch (type)
            {
                case AlertType.success:
                    this.BackColor = Color.FromArgb(46, 204, 113);
                    icon.Image = imageList1.Images[0];
                    break;
                case AlertType.info:
                    this.BackColor = Color.Gray;
                    icon.Image = imageList1.Images[1];
                    break;
                case AlertType.error:
                    this.BackColor = Color.FromArgb(233, 10, 37);
                    icon.Image = imageList1.Images[2];
                    break;
                case AlertType.warning:
                    this.BackColor = Color.FromArgb(255,128,0);
                    icon.Image = imageList1.Images[2];
                    break;

            }
        }

        public static void AlertPob(string message,AlertType type)
        {
            new WindowsFormsApp7.alert(message, type).Show();
        }


        public enum AlertType
        {
            success,info,warning,error
        }

        private void alert_Load(object sender, EventArgs e)
        {
            this.Top =  0;
            this.Left = 400;  
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            closealert.Start();
        }

        int interval = 0;
        private void showtimer_Tick(object sender, EventArgs e)
        {
            if (this.Top <250)
            {
                this.Top += interval;
                interval += 2;
            }
            else
            {
                showtimer.Stop();
            }
        }

        private void closealert_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.001)
            {
                this.Opacity-=0.2;
            }
            else
            {
                this.Close();
            }
            
        }
    }
}
