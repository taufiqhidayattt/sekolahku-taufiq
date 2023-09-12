using sekolahku_jude.DataAkses;
using sekolahku_jude.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sekolahku_jude.Forms
{
    public partial class SiswaForm : Form
    {
        private readonly SiswaDal _siswaDal;
        public SiswaForm()
        {
            InitializeComponent();
            _siswaDal = new SiswaDal();

            RefreshGrid();
            PhotoPic.DoubleClick += PhotoPic_DoubleClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

      
        private void PhotoPic_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|All Files (*.*)|*.*"; ;
            var filename = openFileDialog1.ShowDialog();

            PhotoPic.SizeMode = PictureBoxSizeMode.StretchImage;
            PhotoPic.Load(openFileDialog1.FileName);
            label7.Text = openFileDialog1.FileName;
        }

        private void RefreshGrid()
        {
            var list = _siswaDal.ListData()?.ToList() ?? new List<SiswaModel>();
            var binding = new BindingSource();
            binding.DataSource = list;
            dataGridView1.DataSource = binding;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("ID Siswa tidak boleh kosong");
                return;
            }

            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Nama Siswa tidak boleh kosong");
                return;
            }

            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("Alamat Siswa tidak boleh kosong");
                return;
            }

            if (textBox6.Text == string.Empty)
            {
                MessageBox.Show("Kota Siswa tidak boleh kosong");
                return;
            }

            if (textBox1.Text.Length > 3)
            {
                MessageBox.Show("ID Siswa maximal 3 digit");
                return;
            }
            if (textBox2.Text.Length > 30)
            {
                MessageBox.Show("Nama Siswa maximal 30 huruf");
                return;
            }

            if (textBox4.Text.Length > 30)
            {
                MessageBox.Show("Alamat Siswa maximal 30 huruf");
                return;
            }

            if (textBox6.Text.Length > 30)
            {
                MessageBox.Show("Kota Siswa maximal 30 huruf");
                return;
            }

            var Siswa = new SiswaModel();
            Siswa.SiswaId = textBox1.Text;
            Siswa.SiswaName = textBox2.Text;
            Siswa.Alamat = textBox4.Text;
            Siswa.TglLahir = dateTimePicker1.Value;
            Siswa.Alamat2 = textBox5.Text;
            Siswa.Kota = textBox6.Text;
            Siswa.Photo = label7.Text;

            var db = _siswaDal.GetData(textBox1.Text);
            if (db is null)
                _siswaDal.Insert(Siswa);
            else
                _siswaDal.Update(Siswa);
            clearform();
            RefreshGrid();
        }
        private void clearform()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            PhotoPic.Image = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var siswaid = dataGridView1.Rows[e.RowIndex].Cells["SiswaId"].Value.ToString();
            var siswa = _siswaDal.GetData(siswaid);
            if (siswa is null)
                return;
            showdata(siswa);

            label7.Text = siswa.Photo;
            PhotoPic.SizeMode = PictureBoxSizeMode.StretchImage;
            if (label7.Text != "")
            {
                try
                {
                    PhotoPic.Load(label7.Text);
                }
                catch (Exception)
                {

                    PhotoPic.Image = null;
                }

            }
            else
                PhotoPic.Image = null;
        }

        private void showdata(SiswaModel siswa)
        {
            if (siswa is null)
                return;
            textBox1.Text = siswa.SiswaId;
            textBox2.Text = siswa.SiswaName;
            dateTimePicker1.Value = siswa.TglLahir;
            textBox4.Text = siswa.Alamat;
            textBox5.Text = siswa.Alamat2;
            textBox6.Text = siswa.Kota;
            label7.Text = siswa.Photo;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null)
                return;
            var siswaId = dataGridView1.CurrentRow.Cells["SiswaId"].Value.ToString();
            var siswa = _siswaDal.GetData(siswaId);
            if (siswa is null)
                return;

            if (MessageBox.Show($"Hapus data {siswa.SiswaName}?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                _siswaDal.Delete(siswa.SiswaId);

            clearform();
            RefreshGrid();
        }

    }
}
