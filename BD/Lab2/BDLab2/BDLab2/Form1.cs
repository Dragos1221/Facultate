using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDLab2;
using System.Data.SqlClient;

namespace BDLab2
{
    public partial class Form1 : Form
    {
        private Informatii inf;

        private string parinte;

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        internal Informatii Inf
        {
            get
            {
                return inf;
            }

            set
            {
                inf = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void setInf()
        {

            String tabel1 = System.Configuration.ConfigurationManager.AppSettings["Parinte"];
            String tabel2 = System.Configuration.ConfigurationManager.AppSettings["Copil"];
            String con = System.Configuration.ConfigurationManager.AppSettings["StringConnection"];
            String colo = System.Configuration.ConfigurationManager.AppSettings["Coloana"];

            Informatii inff = new Informatii(tabel1, tabel2, con, colo);
            inf = inff;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadParent()
        {
            string comanda = "Select * from" + inf.tabel11;
            SqlConnection con = new SqlConnection(inf.StringConnection1);
            SqlCommand com = new SqlCommand( comanda,con);
            da.SelectCommand = com;
            con.Open();
            da.Fill(ds, inf.tabel11);
            dataGridView1.DataSource = ds.Tables[inf.tabel11];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string comanda = "Select * from " + inf.tabel11;
            SqlConnection con = new SqlConnection(inf.StringConnection1);
            SqlCommand com = new SqlCommand(comanda, con);
            da.SelectCommand = com;
            con.Open();
            da.Fill(ds, inf.tabel11);
            dataGridView1.DataSource = ds.Tables[inf.tabel11];
            con.Close();
        }

        public void LoadGrid2()
        {

            string comanda = "Select * from " + inf.Tabel22+" Where " + inf.Coloana1+ "= @id";
            SqlConnection con = new SqlConnection(inf.StringConnection1);
            SqlCommand comand = new SqlCommand(comanda, con);

            var paramId = comand.CreateParameter();
            paramId.Value = parinte;
            paramId.ParameterName ="id";
            comand.Parameters.Add(paramId);
            
            da.SelectCommand = comand;
            con.Open();
            da.Fill(ds, inf.Tabel22);
            dataGridView2.DataSource = ds.Tables[inf.Tabel22];
            con.Close();


        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            parinte = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView2.RowCount != 0)
            {
                ds.Tables[inf.Tabel22].Clear();
            }
            LoadGrid2();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(ds, inf.Tabel22);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int rows = dataGridView2.SelectedRows[0].Index;
                dataGridView2.Rows.RemoveAt(rows);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds, inf.Tabel22);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(ds, inf.Tabel22);
        }
    }
}
