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

    public partial class Form1 : Form
    {
        private string str = "server=DESKTOP-N6I4HKO;database=Magazin_v2 ; Integrated security=True";
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        SqlDataAdapter da2 = new SqlDataAdapter();
        DataSet ds2 = new DataSet();



        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           Console.WriteLine( dataGridView1.CurrentRow.Cells[1].Value.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
                string comanda = "Select * from angajat";
                SqlConnection con = new SqlConnection(str);
                SqlCommand comand = new SqlCommand(comanda, con);
                da.SelectCommand = comand;
                con.Open();
                da.Fill(ds, "angajat");
                dataGridView1.DataSource = ds.Tables["angajat"];
                con.Close();
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ds2.Clear();
            

                Console.WriteLine(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                string comanda = "Select * from concediu Where idAngajat=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlConnection con = new SqlConnection(str);
                SqlCommand comand = new SqlCommand(comanda, con);
                da2.SelectCommand = comand;
                con.Open();
                da2.Fill(ds2, "concediu");
                dataGridView2.DataSource = ds2.Tables["concediu"];
                con.Close();
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 f2 = new Form2();
            f2.textBox1.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            f2.textBox2.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            f2.textBox3.Text = this.dataGridView2.CurrentRow.Cells[2].Value.ToString();
            f2.textBox4.Text = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
            f2.setF1(this);
            f2.ShowDialog();
        }

        public void LoadGrid2()
        {
            
                string comanda = "Select * from concediu Where idAngajat=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlConnection con = new SqlConnection(str);
                SqlCommand comand = new SqlCommand(comanda, con);
                da2.SelectCommand = comand;
                ds2.Clear();
                con.Open();
                da2.Fill(ds2, "concediu");
                dataGridView2.DataSource = ds2.Tables["concediu"];
                con.Close();
            

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateRow();
        }

        private void UpdateRow()
        {
           
           
                using (SqlConnection conn = new SqlConnection { ConnectionString = str })
                {
                    dataGridView2.CurrentRow.Cells[3].Value = dataGridView1.CurrentRow.Cells[0].Value;
                    da2.SelectCommand.Connection = conn;
                    conn.Open();
                    SqlCommandBuilder builder = new SqlCommandBuilder(da2);
                    SqlCommand cmd = builder.GetUpdateCommand(true);
                    da2.UpdateCommand = cmd;
                    da2.Update(ds2, "concediu");
                    conn.Close();
                }
           

        }
    }
}
