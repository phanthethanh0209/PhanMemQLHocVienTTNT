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
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            DanhSach rpt = new DanhSach();
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
            loadcbbMa();
        }
        bool data = false;//Thực hiện một hành động nếu data là true
        void loadcbbMa()//Load dữ liệu lên cobobox
        {
            DBConnect db = new DBConnect();
            string chuoitruyvan = "select * from LOPHOCPHAN";
            DataTable dt = db.getDataTable(chuoitruyvan);
            DataRow r = dt.NewRow();
            r["MALOPHP"] = "All";
            dt.Rows.InsertAt(r, 0);
            Cbo_MaHP.DataSource = dt;
            Cbo_MaHP.DisplayMember = "MALOPHP";
            Cbo_MaHP.ValueMember = "MALOPHP";
            Cbo_MaHP.SelectedIndex = 0;
            data = true;
        }


        private void BT_DanhSachHV_Click(object sender, EventArgs e)
        {
            DanhSach rpt = new DanhSach();
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa", "123456", "TRISS/SQLEXPRESS", "QL_HOCVIEN_CNET");
            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayToolbar = false;
            crystalReportViewer1.DisplayStatusBar = false;
        }
        private void BT_DoanhThu_Click(object sender, EventArgs e)
        {
            DoanhThu rpt1 = new DoanhThu();
            crystalReportViewer1.ReportSource = rpt1;
            rpt1.SetDatabaseLogon("sa", "123456", "TRISS/SQLEXPRESS", "QL_HOCVIEN_CNET");
            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayToolbar = false;
            crystalReportViewer1.DisplayStatusBar = false;
        }
        private void Cbo_MaHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (data)
            {
                string mahv = Cbo_MaHP.SelectedValue.ToString();
                CrystalReport2 rpt = new CrystalReport2();
                rpt.SetDatabaseLogon("sa", "123456", "TRISS/SQLEXPRESS", "QL_HOCVIEN_CNET");
                rpt.SetParameterValue("pMaLopHP", mahv);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
        }


    }
}