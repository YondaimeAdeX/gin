using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    
        private void Doldur() {
            var arabalar = db.tblArabalar.ToList();
            dataGridView1.DataSource = arabalar;

            var modeller = db.tblmodeller.Select(x => new
            {
                x.id,
                model = x.modeladi
            }).ToList();
            cmbModel.DataSource = modeller;
            cmbModel.DisplayMember = "model";
            dataGridView3.DataSource = modeller;

            var markalar = db.tblmarkalar.Select(x => new
            {
                x.id,
                marka = x.markaadi

            }).ToList();
            cmbMarka.DataSource = markalar;
            cmbMarka.DisplayMember = "marka";
            dataGridView2.DataSource = markalar;
        
        }
        dbArabaEntities db = new dbArabaEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            tblArabalar araba = new tblArabalar();
            araba.marka = cmbMarka.Text;
            araba.modeli = cmbModel.Text;
            araba.modelTarihi = txtmodelTarihi.Text;
            araba.rengi = txtRengi.Text;
            araba.yakit = txtYakit.Text;
            araba.durumu = checkDurum.Checked;
            db.tblArabalar.Add(araba);
            db.SaveChanges();
            Doldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tblmarkalar marka = new tblmarkalar();
            marka.markaadi = txtMarka.Text;
            db.tblmarkalar.Add(marka);
            db.SaveChanges();
            Doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tblmodeller model = new tblmodeller();

            model.modeladi = txtModel.Text;
            db.tblmodeller.Add(model);
            db.SaveChanges();
            Doldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var guncelle = (from x in db.tblArabalar where x.id == arabaid select x).FirstOrDefault();
            guncelle.marka = cmbMarka.Text;
            guncelle.modeli = cmbModel.Text;
            guncelle.modelTarihi = txtmodelTarihi.Text;
            guncelle.rengi = txtRengi.Text;
            guncelle.yakit = txtYakit.Text;
            guncelle.durumu = checkDurum.Checked;
            db.SaveChanges();
            Doldur();
        }
        int arabaid, markaid, modelid;

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var guncelle = (from x in db.tblmarkalar where x.id == markaid select x).FirstOrDefault();
            guncelle.markaadi = txtMarka.Text;
            db.SaveChanges();
            Doldur();
          
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
             markaid = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            var marka1 = db.tblmarkalar.Where(x => x.id == markaid).FirstOrDefault();
            txtMarka.Text = marka1.markaadi;
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            modelid = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            var model1= db.tblmodeller.Where(x => x.id == modelid).FirstOrDefault();
            txtModel.Text = model1.modeladi;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var guncelle = (from x in db.tblmodeller where x.id == modelid select x).FirstOrDefault();
            guncelle.modeladi = txtModel.Text;
            db.SaveChanges();
            Doldur();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            var aramasoonucu = from x in db.tblmarkalar where x.markaadi.Contains(textBox1.Text) select x;
            dataGridView2.DataSource = aramasoonucu.ToList();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var aramasoonucu = from x in db.tblmodeller where x.modeladi.Contains(textBox2.Text) select x;
            dataGridView3.DataSource = aramasoonucu.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var aramasoonucu = from x in db.tblArabalar where x.modeli.Contains(txtara1.Text) select x;
            dataGridView1.DataSource = aramasoonucu.ToList();


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            arabaid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var araba1 = db.tblArabalar.Where(x => x.id == arabaid).FirstOrDefault();
            txtMarka.Text = araba1.marka;
            txtModel.Text = araba1.modeli;
            txtmodelTarihi.Text = araba1.modelTarihi;
            txtRengi.Text = araba1.rengi;
            txtYakit.Text = araba1.yakit;
            if (araba1.durumu==true)
            {
                checkDurum.Checked = true;
            }
            else
            {
                checkDurum.Checked = false;
            }
        }
    }
}
