using sekolahku_jude.DataAkses;
using sekolahku_jude.Models;
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
    public partial class NilaiSiswaForm : Form
    {
        private readonly KelasDal _kelasDal;        
        private readonly SiswaDal _siswaDal;
        private readonly MapelDal _mapelDal;
        private readonly NilaiSiswaDal _nilaisiswaDal;

        private BindingList<NilaiSiswaDto> _listMapel;


        public NilaiSiswaForm() 
        {
            InitializeComponent();
            _kelasDal = new KelasDal();            
            _siswaDal = new SiswaDal();
            _mapelDal = new MapelDal();
            _nilaisiswaDal = new NilaiSiswaDal();

            InitKelasGrid();
            IniNilaiSiswaGrid();
            InitSiswaCombo();
            RegisterEventHandler();
        }


        private void RegisterEventHandler()
        {
            KelasGrid.CellDoubleClick += KelasGrid_CellDoubleClick;            
            SiswaCombo.SelectedIndexChanged += SiswaCombo_SelectedIndexChanged;

            NilaiSiswaGrid.CellValidated += NilaiSiswaGrid_CellValidated;
            KelasIdText.Validated += KelasIdText_Validated;

            SaveButton.Click += SaveButton_Click;
            NewButton.Click += NewButton_Click;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            KelasIdText.Text = string.Empty;
            KelasNameText.Text = string.Empty;
            SiswaCombo.SelectedIndex = 0;
            _listMapel.Clear();
            LoadNilai();

        }



        #region GRID-KELAS
        private void InitKelasGrid()
        {
            var listKelas = _kelasDal.ListData().ToList();
            var dataSource = (
                from c in listKelas
                select new
                {
                    Id = c.KelasId,
                    Name = c.KelasName
                }).ToList();
            KelasGrid.DataSource = dataSource;
            KelasGrid.DefaultCellStyle.BackColor = Color.AliceBlue;

            KelasGrid.Columns["Id"].ReadOnly = true;
            KelasGrid.Columns["Id"].Width = 50;
            KelasGrid.Columns["Name"].ReadOnly = true;
            KelasGrid.Columns["Name"].Width = 100;
        }
        private void KelasGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (KelasGrid.CurrentRow is null)
                return;

            var kelasId = KelasGrid.CurrentRow.Cells["Id"].Value.ToString();
            var kelasName = KelasGrid.CurrentRow.Cells["Name"].Value.ToString();


            KelasIdText.Text = kelasId;
            KelasNameText.Text = kelasName;

            _listMapel.Clear();
            NilaiSiswaGrid.Refresh();
            LoadNilai();

        }
        #endregion

        #region HEADER-NILAI SISWA
        private void SiswaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listMapel.Clear();
            NilaiSiswaGrid.Refresh();
            LoadNilai();
        }

        private void KelasIdText_Validated(object sender, EventArgs e)
        {
            _listMapel.Clear();
            NilaiSiswaGrid.Refresh();
            LoadNilai();
        }

        private void InitSiswaCombo()
        {

            var listSiswa = _siswaDal.ListData();
            SiswaCombo.DataSource = listSiswa;
            SiswaCombo.DisplayMember = "SiswaName";
            SiswaCombo.ValueMember = "SiswaId";

        }

        private void LoadNilai()
        {
            var kelas = KelasIdText.Text;
            var hari = SiswaCombo.SelectedItem.ToString();

            var listMapel = _nilaisiswaDal.ListData(kelas, hari);
            if (listMapel is null)
                return;

            foreach (var item in listMapel)
            {
                _listMapel.Add(new NilaiSiswaDto
                {
                    SiswaId = item.SiswaId,
                    MapelId = item.MapelId,
                    MapelName = item.MapelName,
                    Nilai =item.Nilai,
                }) ;
            }
            NilaiSiswaGrid.Refresh();

        }
        #endregion

        #region GRID-JADWAL
        private void IniNilaiSiswaGrid()
        {
            _listMapel = new BindingList<NilaiSiswaDto>();
            var binding = new BindingSource();
            binding.DataSource = _listMapel;
            NilaiSiswaGrid.DataSource = binding;

            NilaiSiswaGrid.Columns["MapelId"].Width = 50;
            NilaiSiswaGrid.Columns["MapelId"].HeaderText = "Id Mapel";
                 
            NilaiSiswaGrid.Columns["MapelName"].Width = 150;
            NilaiSiswaGrid.Columns["MapelName"].HeaderText = "Nama Mata Pelajaran";
            NilaiSiswaGrid.Columns["MapelName"].ReadOnly = true;
            NilaiSiswaGrid.Columns["MapelName"].DefaultCellStyle.BackColor = Color.Beige;

            NilaiSiswaGrid.Columns["Nilai"].Width = 40;
            NilaiSiswaGrid.Columns["Nilai"].HeaderText = "Nilai";

        }

        private void NilaiSiswaGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.CurrentCell.ColumnIndex == grid.Columns["MapelId"].Index)
            {
                var mapelId = grid?.CurrentCell?.Value?.ToString() ?? string.Empty;
                var mapel = _mapelDal.GetData(mapelId);
                if (mapel != null)
                {
                    _listMapel[e.RowIndex].MapelName = mapel.MapelName;
                    NilaiSiswaGrid.Refresh();
                }
            }
            else
                _listMapel[e.RowIndex].MapelName = string.Empty;
        }
        #endregion

        #region SAVE
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var kelas = KelasIdText.Text;
            var siswa = SiswaCombo.SelectedItem.ToString();
            if (KelasNameText.Text == string.Empty)
            {
                MessageBox.Show("'KELAS ID' tidak benar");
                return;
            }
            if (SiswaCombo.Text == string.Empty)
            {
                MessageBox.Show("'Siswa' tidak benar");
                return;
            }


            _nilaisiswaDal.Delete(kelas, siswa);
            foreach (var item in _listMapel)
            {
                var nilaiSiswa = new NilaiSiswa

                {
                    KelasId = kelas,
                    SiswaId = siswa,
                    Nilai = item.Nilai,
                    MapelId = item.MapelId,
                };
                _nilaisiswaDal.Insert(nilaiSiswa);
            }
            MessageBox.Show("Save berhasil");

        }
        #endregion
    }

    public class NilaiSiswaDto
    {
        public string SiswaId { get; set; }
        public string MapelId { get; set; }
        public string MapelName { get; set; }
        public decimal Nilai { get; set; }

    }
}
