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
    public partial class BibliotecarWindow : Form
    {
        private ServiceCarte servCarte;
        private ServiceImprumut servImpr;
        private Bibliotecar bibliotecar;
        public BibliotecarWindow()
        {
            InitializeComponent();
        }
        public void setData(ServiceCarte carte , ServiceImprumut imprumut)
        {
            servCarte=carte;
            servImpr=imprumut;
        }
        public void setBibliotecar(Bibliotecar bibl)
        {
            bibliotecar=bibl;
        }

        private void saveCarte(object sender, EventArgs e)
        {
            string titlu = titluBox.Text;
            string autor = autorBox.Text;
            int id = servCarte.maxId();
            Carte c = new Carte();
            c.id = id;
            c.titlu = titlu;
            c.autor = autor;
            c.Imprumutata = false;
            c.IdBiblioteca2 = bibliotecar.id;
            servCarte.save(c);
            loadCarti();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            List<Carte> l = servCarte.getLista();
            dataGridView1.Rows.Clear();
            foreach (Carte c in l)
            {
                dataGridView1.Rows.Add(c.id, c.titlu, c.autor, c.Imprumutata, c.IdBiblioteca2);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }
        public void loadCarti()
        {
            dataGridView1.Rows.Clear();
            List<Carte> l = servCarte.getLista();
            dataGridView1.Rows.Clear();
            foreach (Carte c in l)
            {
                dataGridView1.Rows.Add(c.id, c.titlu, c.autor, c.Imprumutata, c.IdBiblioteca2);
            }
        }

        private void updateCarte(object sender, EventArgs e)
        {
            Carte c = new Carte();
            c.id = Int32.Parse(idBox.Text);
            c.titlu = titluBox.Text;
            c.autor = autorBox.Text;
            if (stareCombo.SelectedItem.ToString().Equals("True"))
                c.Imprumutata = true;
            else
                c.Imprumutata = false;
            c.IdBiblioteca2 = Int32.Parse(titluBox.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            servCarte.update(c);
            loadCarti();

        }

        private void CellClickDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            titluBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            autorBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            idBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Equals("False"))
                stareCombo.SelectedItem = stareCombo.Items[0];
            else
                stareCombo.SelectedItem = stareCombo.Items[1];
        }

        private void deleteCarte(object sender, EventArgs e)
        {
            int id = Int32.Parse( idBox.Text);
            servCarte.delete(id);
            loadCarti();
        }

        private void ReturneazaEvent(object sender, EventArgs e)
        {
            int idAbonat = Int32.Parse(textBox5.Text);
            int idCarte =  Int32.Parse(textBox4.Text);
            if(servImpr.exist(idAbonat,idCarte)!=null)
            {
                Imprumut i = servImpr.exist(idAbonat, idCarte);
                if (i!=null)
                {
                    i.idBibliotecar = bibliotecar.id;
                    i.dataReturnare = DateTime.Now.ToString();
                    i.stareCarteReturnare = comboBox1.Text;
                    Carte c = servCarte.getCarte(idCarte);
                    c.Imprumutata = false;
                    c.stare = i.stareCarteReturnare;
                    servCarte.update(c);
                    servImpr.update(i);
                    loadCarti();      
                }   
            }
            else
            {
                MessageBox.Show("Nu exista acest imprumut");
            }

        }

        private void Stare_Click(object sender, EventArgs e)
        {

        }
    }
}
