using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игора
{
    public partial class Prodovex : Form
    {
        public Prodovex()
        {
            InitializeComponent();
        }

        int i;
        int h;
        int j;
        int k;

        AboutBox1 aboutBox1;
        Checkout checkout;

        private void GlavButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Prodovex_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        public void NameS(string name, string famil, string rol)
        {
            label1.Text = name;
            label2.Text = famil;
            label3.Text = rol;
            
            try
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"D:\Инженерно техническая поддержка\Игора\Игора\image\" + famil + ".jpeg");
            }
            catch (Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((k == 0) && (h == 5))
            {
                k++;
                MessageBox.Show("Через 5 минут завершится сеанс");
            }

            i++;
            if (h == 60)
            {
                j++;
                h = 0;
                label5.Text = j + ":" + h + ":" + i;
            }
            else if (i < 60)
            {
                label5.Text = j + ":" + h + ":" + i;

            }
            else if (i == 60)
            {
                h++;
                i = 0;
                label5.Text = j + ":" + h + ":" + i;
            }

            if (h == 10)
            {
                Entrance f = new Entrance();
                f.Bloc();
                ForClosing();
                this.Close();
            }
        }
        private void ForClosing()
        {
            Form[] forms = { aboutBox1, checkout };
            for(int i = 0; i < forms.Length; i++)
            {
                if (forms[i] != null)
                {
                    forms[i].Close();
                }
            }
        }

        private void GlavButton_Click_1(object sender, EventArgs e)
        {
            ForClosing();
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void CheckoutTool_Click(object sender, EventArgs e)
        {
            checkout = new Checkout();
            checkout.Show();
        }
    }
}
