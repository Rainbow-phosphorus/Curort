using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игора
{
    public partial class Admin : Form
    {
        Sqlconection c;
        public Admin()
        {
            InitializeComponent();
            c = new Sqlconection();
            Up();
        }

        int seconds;
        int minutes;
        int hours;
        int k;
        DobavlKlienta dobavlKlienta;
        LoginHistory log;
        DobavSotrudnica dobavSotrudnica;
        Othot othot;
        AboutBox1 aboutBox1;

        public void Up()
        {
            c.Sqlopen();
     
            MySqlCommand cmd = new MySqlCommand("CALL Inputs", c.conection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource= dataTable;


            c.Sqlclose();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        
        public void NameS(string name, string famil, string rol)
        {
            label1.Text = name;
            label2.Text = famil;
            label3.Text = rol;
            try {
                pictureBox1.BackgroundImage = Image.FromFile(@"D:\Инженерно техническая поддержка\Игора\Игора\image\" + famil + ".jpeg");
            } catch  (Exception ex) {
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((k == 0) && (minutes == 5))
            {
                k++;
                MessageBox.Show("Через 5 минут завершится сеанс");
            }

            seconds++;
            if (minutes == 60)
            {
                hours++;
                minutes = 0;
                label7.Text = hours + ":" + minutes + ":" + seconds;
            }
            else if (seconds < 60)
            {
                label7.Text = hours + ":" + minutes + ":" + seconds;

            }
            else if (seconds == 60)
            {
                minutes++;
                seconds = 0;
                label7.Text = hours + ":" + minutes + ":" + seconds;
            }

            if (minutes == 10)
            {
                minutes++;
                Entrance f = new Entrance();
                f.Bloc();

                ForClosing();
 
                this.Close();
            }
        }
        private void ForClosing()
        {
            Form[] forms = { dobavlKlienta, log, dobavSotrudnica, othot, aboutBox1 };
            for(int i = 0; i < forms.Length; i++)
            {
                if (forms[i] != null)
                {
                    forms[i].Close();
                    //Application.OpenForms[forms[i].Name].Close();
                }
            }
        }

        private void HistoryTool_Click(object sender, EventArgs e)
        {
            log = new LoginHistory();
            log.Show();
        }

        private void GlavButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ForClosing();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dobavlKlienta = new DobavlKlienta();
            dobavlKlienta.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            dobavSotrudnica = new DobavSotrudnica();
            dobavSotrudnica.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            othot = new Othot();
            othot.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            aboutBox1 = new AboutBox1();
            aboutBox1.Show();   
        }
    }
}
