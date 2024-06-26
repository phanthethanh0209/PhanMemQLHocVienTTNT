using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocVienTTNT
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }

        DBConnect db = new DBConnect();
        DataTable dt;

        void HienThiHoaDon()
        {
            string chuoitruyvan = "Select HoaDon.MaHD, LOPHOCPHAN.MaLopHP, NgayLap, HOCVIEN.MaHV, NHANVIEN.TENTKNV, HoTenHV, KHUYENMAI.MaKM, FORMAT(SoTienGiam,'N0') as SoTienGiam, FORMAT((LOPHOCPHAN.HocPhi-SoTienGiam),'N0') as ThanhTien from HOADON, HOCVIEN,LOPHOCPHAN, NHANVIEN, KHUYENMAI where HOADON.MAHV = HOCVIEN.MAHV AND LOPHOCPHAN.MaLopHP = HOADON.MaLopHP AND HOADON.MAKM = KHUYENMAI.MAKM AND HOADON.TENTKNV = NHANVIEN.TENTKNV ";
            dt = db.getDataTable(chuoitruyvan);
            dgv_HoaDon.DataSource = dt;

        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            HienThiHoaDon();
            //txt_MaHD.Text = Function.CreateKey("HD", "Select * From HOADON");
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            //string chuoitruyvan = "Select MaHD, LOPHOCPHAN.MaLopHP, NgayLap, HOCVIEN.MaHV, HoTenHV, KHUYENMAI.MaKM, SoTienGiam, (LOPHOCPHAN.HocPhi-SoTienGiam) as ThanhTien from HOADON, HOCVIEN,LOPHOCPHAN, KHUYENMAI, NHANVIEN where MAHD = '" + txt_TimKiem.Text + "' AND HOADON.MAHV = HOCVIEN.MAHV AND LOPHOCPHAN.MaLopHP = HOADON.MaLopHP AND HOADON.MAKM = KHUYENMAI.MAKM AND HOADON.TENTKNV = NHANVIEN.TENTKNV";
            string chuoitruyvan = "Select MaHD, HOADON.TenTKNV, LOPHOCPHAN.MaLopHP, NgayLap, HOCVIEN.MaHV, HoTenHV, KHUYENMAI.MaKM, SoTienGiam, (LOPHOCPHAN.HocPhi-SoTienGiam) as ThanhTien from HOADON, HOCVIEN,LOPHOCPHAN, KHUYENMAI where MAHD = '" + txt_TimKiem.Text + "' AND HOCVIEN.MAHV = HOADON.MAHV AND LOPHOCPHAN.MALOPHP = HOADON.MALOPHP AND HOADON.MAKM = KHUYENMAI.MAKM";
            DataTable dt = db.getDataTable(chuoitruyvan);

            if (dt.Rows.Count == 1)
            {
                dgv_HoaDon.DataSource = dt;
                txt_MaHD.Text = dt.Rows[0]["MAHD"].ToString();
                txt_MaHV.Text = dt.Rows[0]["MAHV"].ToString();
                txt_NgayLap.Text = string.Format("{0:dd/MM/yyyy}", dt.Rows[0]["NgayLap"]);
                txt_MaLop.Text = dt.Rows[0]["MALOPHP"].ToString();
                txt_TenHV.Text = dt.Rows[0]["HOTENHV"].ToString();
                txt_MaKM.Text = dt.Rows[0]["MAKM"].ToString();
                txt_TenTK.Text = dt.Rows[0]["TENTKNV"].ToString();
                txt_ThanhTien.Text = string.Format("{0:0,0}", dt.Rows[0]["ThanhTien"]);
            }
        }

    }
}
