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

namespace Labccv2
{
    public partial class Form2 : Form
    {
        RezervareService rezServ;
        DestinatieService destServ;
        Form2 f2;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        public Form2()
        {
            InitializeComponent();
        }

        public void setData(RezervareService rezServ, DestinatieService destServ,Form2 f)
        {
            this.rezServ = rezServ;
            this.destServ = destServ;
            f2 = f;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadDestinatii();
        }

        private void loadDestinatii()
        {
            ds.Clear();
            destServ.DestinatiiRep(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)  {}
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ds2.Clear();
            int id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            loadRez(id);
        }

        private void loadRez(int id)
        {
            ds2.Clear();
            rezServ.getRezervazri(ds2, id);
            dataGridView2.DataSource = ds2.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int luna = dateTimePicker1.Value.Month;
            int an = dateTimePicker1.Value.Year;
            int zi = dateTimePicker1.Value.Day;
            int ora = dateTimePicker2.Value.Hour;
            int min = dateTimePicker2.Value.Minute;
            string dest = textBox1.Text;
            DateTime timp = new DateTime(an, luna, zi, ora, min, 0);
            int id = destServ.getIdDestinatie(dest, timp);
            loadRez(id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nrLoc = Int32.Parse(textBox3.Text);
            int nrlocd= Int32.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            string nume = textBox2.Text;
            int id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if(!(textBox3.Text.Equals("") || textBox2.Text.Equals("")))
            {
                if(nrLoc > nrlocd)
                {
                    MessageBox.Show("Nu sunt locuri1", "Titlu");
                }
                else
                {
                    Destinatie dest = destServ.getDestinatie(id);
                    dest.LocuriDisponibile1 = dest.LocuriDisponibile1 - nrLoc;
                    dest.LocuriOcupate1 = dest.LocuriOcupate1 + nrLoc;
                    destServ.update(dest);
                    rezServ.save(new Rezervare(id, nrLoc, nume));
                    loadRez(id);
                    loadDestinatii();
                }
            }
        }
    }
}
