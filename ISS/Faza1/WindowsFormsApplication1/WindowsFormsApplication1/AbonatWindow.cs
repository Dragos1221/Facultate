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
    
    public partial class AbonatWindow : Form
    {
        ServiceCarte servCarte;
        ServiceImprumut servImpr;
        Anobat abonat;
        public AbonatWindow()
        {
            InitializeComponent();
        }
        public void setService(ServiceCarte c , ServiceImprumut i )
        {
            servCarte = c;
            servImpr = i;
        }
        public void setAbonat(Anobat a )
        {
            abonat = a;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            List<Carte> l = servCarte.getLista();
            dataGridView1.Rows.Clear();
            foreach (Carte c in l)
            {
                dataGridView1.Rows.Add(c.id, c.titlu, c.autor, c.Imprumutata);
            }
        }
        private void loadLista()
        {
            List<Carte> l = servCarte.getLista();
            dataGridView1.Rows.Clear();
            foreach (Carte c in l)
            {
                dataGridView1.Rows.Add(c.id, c.titlu, c.autor, c.Imprumutata);
            }
        }

        private void Imprumuta(object sender, EventArgs e)
        {
            int idCarte = Int32.Parse(textBox3.Text);
            Imprumut i = new Imprumut();
            Carte c = servCarte.getCarte(idCarte);
            if (c!=null &&  c.Imprumutata==false)
            {
                Imprumut impr = new Imprumut();
                impr.dataInprumut = DateTime.Now.ToString();
                impr.idCarte2 = idCarte;
                impr.idBibliotecar = 1;
                impr.stareCartePrimire = c.stare;
                impr.idAbonat = abonat.Id;
                impr.dataReturnare = "-";
                impr.stareCarteReturnare = "-";
                impr.id = 11;
                servImpr.save(impr);
                c.Imprumutata = true;
                servCarte.update(c);
                loadLista();
            }
            else
            {
                MessageBox.Show("Aceasta carte nu poate fi imprumutata");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
