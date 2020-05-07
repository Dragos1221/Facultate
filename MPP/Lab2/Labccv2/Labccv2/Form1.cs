using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labccv2.Service;
using Labccv2.Domain;
using Labccv2.Repository;

namespace Labccv2
{
    public partial class Form1 : Form  
    {
       
        private OficiuService ofServ;
        private Form2 f2;
        private Form1 f1;
    


        public Form1()
        {
            InitializeComponent();
        }

       public void setData(Form2 f,Form1 ff, OficiuService of)
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
                if(ofServ.logIn(of))
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
    }
}
