using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocVienTTNT
{
    public partial class FormUpdateHV : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt;
        string maHV;
        public FormUpdateHV(string maHV)
        {
            this.maHV = maHV;
            InitializeComponent();
        }

        private void FormUpdateHV_Load(object sender, EventArgs e)
        {
            //Khởi tạo giá trị cbo giới tính
            cb_gioiTinh.Items.Add("Nam");
            cb_gioiTinh.Items.Add("Nữ");

            //hiển thị thông tin học viên
            string chuoitv = "select * from HOCVIEN where MAHV= '" + maHV + "'";
            dt = db.getDataTable(chuoitv);
            txtDiaChi.Text = dt.Rows[0]["DIACHI"].ToString();
            txtTenHv.Text = dt.Rows[0]["HOTENHV"].ToString();
            txtSDT.Text = dt.Rows[0]["SDT"].ToString();
            txtMaHv.Text = maHV;
            if (dt.Rows[0]["GIOITINH"].ToString() == "Nam")
                cb_gioiTinh.SelectedIndex = 0;
            else
                cb_gioiTinh.SelectedIndex = 1;
            txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string gt = "";
            if (cb_gioiTinh.SelectedIndex == 0)
                gt = "Nam";
            else
                gt = "Nữ";
            string chuoitruyvan = "UPDATE HOCVIEN SET HOTENHV = N'" + txtTenHv.Text + "',GIOITINH = N'" + gt + "', DIACHI = N'" + txtDiaChi.Text + "', EMAIL = '" + txtEmail.Text + "', SDT = '" + txtSDT.Text + "' WHERE MAHV = '" + txtMaHv.Text + "'";
            int k = db.getNonQuery(chuoitruyvan);
            if (k > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //kiểm tra số điện thoại
        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không đúng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.errorProvider1.SetError(txtSDT, "Lỗi");
                txtSDT.Focus();
            }
            else
                this.errorProvider1.Clear();
        }


        

       
        
    }
}
