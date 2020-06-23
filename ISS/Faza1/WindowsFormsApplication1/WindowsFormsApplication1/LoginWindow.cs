using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Service;

namespace WindowsFormsApplication1
{
    public partial class LoginWindow : Form
    {

        private ServiceBibliotecar servBibliotecar;
        private ServiceAbonat servAbonat;
        private ServiceCarte servCarte;
        private ServiceImprumut servImpr;

        public LoginWindow()
        {
            InitializeComponent();
        }
    
        public void setService(ServiceBibliotecar bibl , ServiceAbonat abo,ServiceCarte servC , ServiceImprumut imprumut)
        {
            servBibliotecar = bibl;
            servAbonat = abo;
            servCarte = servC;
            servImpr = imprumut;
        }


        private void loginIn(object sender, EventArgs e)
        {
            Anobat a = servAbonat.find(username.Text, Password.Text);
            if(AbonatRadio.Checked && servAbonat.find(username.Text,Password.Text)!=null)
            {
                AbonatWindow f2 = new AbonatWindow();
                f2.setService(servCarte, servImpr);
                f2.setAbonat(a);
                f2.Show();
                this.Hide();
            }
            else
            {
                Bibliotecar b = servBibliotecar.find(username.Text, Password.Text);
                if (BibliotecarRadio.Checked && b!=null)
                {
                    BibliotecarWindow f1 = new BibliotecarWindow();
                    f1.setData(servCarte,servImpr);
                    f1.setBibliotecar(b);
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username sau porola incorect");
                }
            }
           
        }

        private void LoginWindow_Load(object sender, EventArgs e){}
    }
}
