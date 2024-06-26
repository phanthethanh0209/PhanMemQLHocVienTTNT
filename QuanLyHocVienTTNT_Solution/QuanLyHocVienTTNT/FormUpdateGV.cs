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
    public partial class FormUpdateGV : Form
    {
        string maGV;
        DBConnect db = new DBConnect();
        DataTable dt;
        public FormUpdateGV(string maGV)
        {
            this.maGV = maGV;
            InitializeComponent();
        }

        void hienThiThongTinGV()
        {
            string chuoitruyvan = "SELECT * FROM GIAOVIEN WHERE MaGV = '" + maGV + "'";
            dt = db.getDataTable(chuoitruyvan);
            txt_MaGV.Text = dt.Rows[0].ItemArray[0].ToString();
            txt_TenGV.Text = dt.Rows[0].ItemArray[1].ToString();
            txt_TenTK.Text = dt.Rows[0].ItemArray[2].ToString();
            txt_MatKhau.Text = dt.Rows[0].ItemArray[3].ToString();
        }

        private void FormUpdateGV_Load(object sender, EventArgs e)
        {
            hienThiThongTinGV();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {

            string chuoitruyvan = "UPDATE GIAOVIEN SET TenGV = N'" + txt_TenGV.Text + "', TenTKGV = '" + txt_TenTK.Text + "', MatKhau = '" + txt_MatKhau.Text + "' WHERE MaGV = '" + maGV + "'";
            int k = db.getNonQuery(chuoitruyvan);
            if (k > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                hienThiThongTinGV();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
