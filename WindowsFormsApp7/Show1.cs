using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Show1 : UserControl
    {
        public movie mv;
        public Show1(movie mov)
        {
            InitializeComponent();
            mv = mov;
        }
        private void Show1_Load(object sender, EventArgs e)
        {
            label2.Text = "ID: " + mv.id;
            label1.Text = "Title: " + mv.title;
            label3.Text = "Director: " + mv.director;
            label4.Text = "Genres: " + mv.genres;
            label5.Text = "Year: " + mv.year;
            bunifuFlatButton2.Text = mv.rating;
            pictureBox1.ImageLocation = mv.poster;
            pictureBox1.Image = Image.FromFile(pictureBox1.ImageLocation);
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
