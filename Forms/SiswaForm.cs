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
        private SiswaDal _siswaDal;
        public SiswaForm()
        {
            InitializeComponent();
            _siswaDal = new SiswaDal();
            ListDataSiswa();
        }

        private void ListDataSiswa()
        {
            var listSiswa = _siswaDal.ListData()?.ToList();
            var binding = new BindingSource();
            binding.DataSource = listSiswa;
            dataGridView1.DataSource = binding;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //var grid = (DataGridView)sender;
            //if (grid.CurrentRow is null)
            //    return;
            //var guruId = grid.CurrentRow.Cells["GuruId"].Value.ToString();
            //var guru = _guruDal.GetData(guruId);
            //if (guru is null)
            //    return;
            //textBox1.Text = guru.GuruId;
            //textBox2.Text = guru.GuruName;

        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void SaveButton_Click(object sender, EventArgs e)
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


            var siswa = new SiswaModel
            {
                SiswaId = textBox1.Text,
                SiswaName = textBox2.Text,
                TglLahir = dateTimePicker1.Text,
                Alamat = textBox4.Text,
                Alamat2 = textBox5.Text,
                Kota = textBox6.Text
            };
            var siswaDb = _siswaDal.GetData(siswa.SiswaId);
            if (siswaDb is null)
                _siswaDal.Insert(siswa);
            else
                _siswaDal.Update(siswa);

            ClearForm();
            ListDataSiswa();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.CurrentRow is null)
                return;
            var siswaId = grid.CurrentRow.Cells["SiswaId"].Value.ToString();
            var siswa = _siswaDal.GetData(siswaId);
            if (siswa is null)
                return;
            textBox1.Text = siswa.SiswaId;
            textBox2.Text = siswa.SiswaName;
            dateTimePicker1.Text = siswa.TglLahir;
            textBox4.Text = siswa.Alamat;
            textBox5.Text = siswa.Alamat2;
            textBox6.Text = siswa.Kota;


        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null)
                return;
            var siswaId = dataGridView1.CurrentRow.Cells["SiswaId"].Value.ToString();
            var siswa = _siswaDal.GetData(siswaId);
            if (siswa is null)
                return;

            if (MessageBox.Show($"Hapus data {siswa.SiswaName}?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                _siswaDal.Delete(siswa.SiswaId);

            ClearForm();
            ListDataSiswa();
        }
    }
}
