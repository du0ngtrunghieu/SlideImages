using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideImage
{
    public partial class Form1 : Form
    {
        private string[] fordelFile = null;
        private int selected = 0;
        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "//Image";
        public Form1()
        {
            InitializeComponent();
          
            fordelFile = Directory.GetFiles(path, "*.jpg");
            if(fordelFile.Length == 0)
            {
                MessageBox.Show("Không có ảnh trong fordel Image", "Lỗi");
            }
            else if(fordelFile.Length < 6)
            {
                MessageBox.Show("Fordel có ít nhất là 6 ảnh", "Lỗi");
            }
            else
            {
                showImage(fordelFile[selected], fordelFile[(selected +1) % 6], fordelFile[(selected + 2) % 6], fordelFile[(selected + 3) % 6], fordelFile[(selected + 4) % 6], fordelFile[(selected + 5) % 6]);
                selected = selected + 1;
                timer2.Start();
            }
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void showImage(string p1,string p2 , string p3 , string p4 , string p5 , string p6)
        {
            Image img1 = Image.FromFile(p1);
            Image img2 = Image.FromFile(p2);
            Image img3 = Image.FromFile(p3);
            Image img4 = Image.FromFile(p4);
            Image img5 = Image.FromFile(p5);
            Image img6 = Image.FromFile(p6);
            pictureBox1.Image = img1;
            pictureBox2.Image = img2;
            pictureBox3.Image = img3;
            pictureBox4.Image = img4;
            pictureBox5.Image = img5;
            pictureBox6.Image = img6;
        }
        private void nextImage()
        {
            
            if (fordelFile.Length == 0)
            {
                timer2.Enabled = false;
            }
            else
            {
                if (selected == fordelFile.Length)
                {
                    selected = 0;
                }
                showImage(fordelFile[selected], fordelFile[(selected + 5) % 6], fordelFile[(selected + 4) % 6], fordelFile[(selected + 3) % 6], fordelFile[(selected + 2) % 6], fordelFile[(selected + 1) % 6]);
                selected++;

            }
        }
        private void prevImage()
        {

            if (fordelFile.Length == 0)
            {
                timer2.Enabled = false;
            }
            else
            {
                if (selected == fordelFile.Length)
                {
                    selected = 0;
                }
                showImage(fordelFile[selected], fordelFile[(selected + 1) % 6], fordelFile[(selected + 2) % 6], fordelFile[(selected + 3) % 6], fordelFile[(selected + 4) % 6], fordelFile[(selected + 5) % 6]);
                selected++;

            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            nextImage();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            nextImage();
            timer2.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            prevImage();
            timer2.Enabled = true;
        }
    }
}
