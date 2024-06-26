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
    public partial class FormTraCuu : Form
    {
        public FormTraCuu()
        {
            InitializeComponent();
        }

        DBConnect db = new DBConnect();
        DataTable dt;

        void hienThi_DSLop()
        {
            string chuoitruyvan = "select MaLopHP from LOPHOCPHAN";
            dt = db.getDataTable(chuoitruyvan);

            DataRow dr = dt.NewRow();
            dr["MaLopHP"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);

            cboLop.DataSource = dt;
            cboLop.DisplayMember = "MaLopHP";
            cboLop.ValueMember = "MaLopHP";
        }

        void hienThi_DSHocVien()
        {
            string chuoitruyvan = "select MAHV, HOTENHV, GIOITINH, SDT from HOCVIEN";
            dt = db.getDataTable(chuoitruyvan);
            dgvTraCuu.DataSource = dt;

        }

        private void FormTraCuu_Load(object sender, EventArgs e)
        {
            hienThi_DSHocVien();
            hienThi_DSLop();

            //khởi tạo cbo lọc
            cboLuaChon.Items.Add("Tổng ngày vắng");
            cboLuaChon.Items.Add("Tổng số lần làm bài tập");
        }


        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex > 0)
            {
                if (cboLuaChon.SelectedIndex == 0) //tổng ngày vắng
                {
                    string chuoitv = "SELECT HV.MAHV, HOTENHV, GIOITINH, SDT, COALESCE(COUNT(DD.NGAYVANG), 0) AS N'Số ngày vắng' FROM PHANLOP PL LEFT JOIN DIEMDANH DD ON PL.MALOPHP = DD.MALOPHP AND PL.MAHV = DD.MAHV AND DD.NGAYVANG BETWEEN '" + ngayBD.Value.ToString("yyyy-MM-dd") + "' AND '" + ngayKT.Value.ToString("yyyy-MM-dd") + "' LEFT JOIN HOCVIEN HV ON PL.MAHV = HV.MAHV WHERE PL.MALOPHP = '" + cboLop.SelectedValue.ToString() + "' GROUP BY HV.MAHV, HOTENHV, GIOITINH, SDT";
                    dt = db.getDataTable(chuoitv);
                    dgvTraCuu.DataSource = dt;
                }
                else if (cboLuaChon.SelectedIndex == 1) //tổng số lần làm bài tập
                {
                    string chuoitv = "SELECT HV.MAHV, HOTENHV, GIOITINH, SDT, COUNT(CASE WHEN HT.DIEM IS NOT NULL THEN 1 ELSE NULL END) AS N'Số lần làm bài' FROM PHANLOP PL LEFT JOIN HOCTAP HT ON PL.MAHV = HT.MAHV AND PL.MALOPHP = HT.MALOPHP LEFT JOIN HOCVIEN HV ON PL.MAHV = HV.MAHV WHERE PL.MALOPHP = '" + cboLop.SelectedValue.ToString() + "' GROUP BY HV.MAHV, HOTENHV, GIOITINH, SDT";
                    dt = db.getDataTable(chuoitv);
                    dgvTraCuu.DataSource = dt;
                }
                else
                    MessageBox.Show("Hãy chọn lựa chọn thích hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            }
            else
            {
                MessageBox.Show("Hãy chọn lớp thích hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void cboLuaChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLuaChon.SelectedIndex == 0)
            {
                ngayBD.Enabled = true;
                ngayKT.Enabled = true;
            }
            else
            {
                ngayBD.Enabled = false;
                ngayKT.Enabled = false;
            }
        }
    }
}
