using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//=========================NỘI DUNG====
//// Thêm giáo viên mới => Button Thêm
///  Xóa giáo viên, click chọn dòng cần xóa => Button xóa
///  Update thông tin giáo viên => Double click vào dòng
///  Tìm kiếm giáo viên bằng Mã GV hoặc tên GV

namespace QuanLyHocVienTTNT
{
    public partial class FormDS_GV : Form
    {
        public FormDS_GV()
        {
            InitializeComponent();
        }

        DBConnect db = new DBConnect();
        DataTable dt;
        string selectedMaGV = "";

        void hienThiDanhSachGV()
        {
            string chuoitruyvan = "Select * From GIAOVIEN";
            dt = db.getDataTable(chuoitruyvan);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            dgv_GiaoVien.DataSource = dt;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            new FormNhapGV().ShowDialog();
            hienThiDanhSachGV();

        }

        private void FormDS_GV_Load(object sender, EventArgs e)
        {
            hienThiDanhSachGV();
        }

        private void dgv_GiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgv_GiaoVien.Rows[e.RowIndex];

                // Lấy giá trị trong cột MaLopHP (hoặc ID của dòng) của dòng được chọn
                selectedMaGV = selectedRow.Cells["MaGV"].Value.ToString();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedMaGV))//Kiểm tra đã chọn được giá trị trên dòng
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string chuoitruyvan_PC = "DELETE FROM GIAOVIEN WHERE MaGV = '" + selectedMaGV + "'";
                    int kq = db.getNonQuery(chuoitruyvan_PC);

                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        hienThiDanhSachGV(); // Cập nhật DataGridView sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgv_GiaoVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new FormUpdateGV(selectedMaGV).ShowDialog();
            hienThiDanhSachGV();
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string chuoitruyvan = "Select * From GIAOVIEN WHERE MaGV LIKE '%" + txt_TimKiem.Text + "%' OR TenGV LIKE N'%" + txt_TimKiem.Text + "%'";
            dt = db.getDataTable(chuoitruyvan);
            dgv_GiaoVien.DataSource = dt;
        }
    }
}
