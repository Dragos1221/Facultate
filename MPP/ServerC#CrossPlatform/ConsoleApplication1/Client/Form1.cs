using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Service;

namespace Client
{
    public partial class Form1 : Form 
    {
       
        private IserviceOficiu ofServ;
        private Form2 f2;
        private Form1 f1;
    


        public Form1()
        {
            InitializeComponent();
        }

       public void setData(Form2 f,Form1 ff, IserviceOficiu of)
        {
            ofServ = of;
            f1 = ff;
            f2 = f;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string user = textBox1.Text;
            string pass = textBox2.Text;
            if(!(user.Equals("") || pass.Equals("")))
            {
                Oficiu of = new Oficiu(user, pass);
                if(ofServ.logIn(of, f2))
                {
                    textBox2.Clear();
                    f1.Hide();
                    f2.ShowDialog();
                    f1.Show();
                    
                }
                else
                {
                    textBox2.Clear();
                }
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofServ.closeConection();
        }
    }
}
