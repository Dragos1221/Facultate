using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form2 : Form
    {
        private Form1 f1;

        public Form2()
        {
            InitializeComponent();
        }

        public void setF1(Form1 f1)
        {
            this.f1 = f1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string str = "server=DESKTOP-N6I4HKO;database=Magazin_v2 ; Integrated security=True";
            string comanda = "Delete From concediu where idConcediu =" + textBox1.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand comand = new SqlCommand(comanda, con);
            con.Open();
            comand.ExecuteNonQuery();
            con.Close();
            f1.LoadGrid2();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-N6I4HKO;database=Magazin_v2 ; Integrated security=True";
            string comanda = "Update concediu Set tip='" + textBox2.Text + "'," + " perioada ='" + textBox3.Text + "' where idConcediu =" + textBox1.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand comand = new SqlCommand(comanda, con);
            con.Open();
            comand.ExecuteNonQuery();
            con.Close();
            f1.LoadGrid2();
           this.Close();
        }
    }
}
