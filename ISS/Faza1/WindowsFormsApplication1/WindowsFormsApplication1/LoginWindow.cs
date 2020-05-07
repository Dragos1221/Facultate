using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Service;

namespace WindowsFormsApplication1
{
    public partial class LoginWindow : Form
    {

        private ServiceBibliotecar servBibliotecar;
        private ServiceAbonat servAbonat;

        public LoginWindow()
        {
            InitializeComponent();
        }
    
        public void setService(ServiceBibliotecar bibl , ServiceAbonat abo)
        {
            servBibliotecar = bibl;
            servAbonat = abo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AbonatRadio.Checked && servAbonat.find(username.Text,Password.Text))
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                if(BibliotecarRadio.Checked && servBibliotecar.find(username.Text, Password.Text))
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Username sau porola incorect");
                }
            }
           
        }
    }
}
