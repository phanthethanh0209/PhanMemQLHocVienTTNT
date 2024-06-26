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
    public partial class FormHocVien : Form
    {
        /*
         * NỘI DUNG:
         * Thêm mới 1 học viên vào trung tâm ==> Nút Thêm 1 học viên mới
         * Thêm/Xoá học viên ra khỏi lớp ==> Click chuột phải vô 1 dòng
         * Sửa thông tin học viên ==> Nháy đúp chuột vô 1 dòng
         * Tìm kiếm: Nhập tên hoặc số điện thoại
         * Xem danh sách học viên trong 1 lớp bất kì ==> Chọn combobox Xem ds học viên
         * Xem danh sách học viên chưa phân lớp (do vừa bị xoá ra khỏi lớp) ==> Chọn combobox Lọc
         * Đối với form Thêm/Xoá
         */

        public FormHocVien()
        {
            InitializeComponent();
        }

        DBConnect db = new DBConnect();
        DataTable dt;

        void hienThi_DSLop()
        {
            string chuoitruyvan = "select MaLopHP from LOPHOCPHAN";

            if (FormChinh.loaitk == "Giáo viên")
            {
                chuoitruyvan = "select MaLopHP from PHANCONG where PHANCONG.MAGV = '" + FormChinh.magv + "' ";
            }
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
            string chuoitruyvan = "select * from HOCVIEN";
            if (FormChinh.loaitk == "Giáo viên")
            {
                chuoitruyvan = "select HOCVIEN.MAHV, HOTENHV, GIOITINH, DIACHI, EMAIL, SDT from HOCVIEN, PHANLOP, LOPHOCPHAN, PHANCONG where PHANCONG.MAGV = '" + FormChinh.magv + "' and PHANCONG.MALOPHP = LOPHOCPHAN.MALOPHP and PHANLOP.MALOPHP = LOPHOCPHAN.MALOPHP and PHANLOP.MAHV = HOCVIEN.MAHV";
            }
            dt = db.getDataTable(chuoitruyvan);
            dgvHocVien.DataSource = dt;

        }

        private void FormHocVien_Load(object sender, EventArgs e)
        {
            hienThi_DSHocVien();
            hienThi_DSLop();

            //khởi tạo cbo lọc
            cboLoc.Items.Add("Học viên chưa có lớp");
            cboLoc.Items.Add("Học viên đã có lớp");

            if (FormChinh.loaitk == "Giáo viên")
            {
                btnThemHV.Enabled = false;
                cboLoc.Enabled = false;
                dgvHocVien.CellDoubleClick -= dgvHocVien_CellDoubleClick;
                dgvHocVien.CellMouseDown -= dgvHocVien_CellMouseDown;

            }
        }

        //Thêm mới 1 học viên
        private void btnThemHV_Click(object sender, EventArgs e)
        {
            new FormNhapHV().ShowDialog();

            //hiển thị ds học viên theo cbo lọc
            string chuoitruyvan = "select PHANLOP.MAHV, HOTENHV, GIOITINH, DIACHI, EMAIL, SDT from HOCVIEN, PHANLOP where HOCVIEN.MAHV = PHANLOP.MAHV and PHANLOP.MaLopHP = '" + cboLop.SelectedValue.ToString() + "'";
            dt = db.getDataTable(chuoitruyvan);
            dgvHocVien.DataSource = dt;
            hienThi_DSHocVien();
        }

        //Xử lí sự kiện click chuột phải vào datagridview thì hiện button
        string MaHV = "";
        private void dgvHocVien_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvHocVien.CurrentCell = dgvHocVien.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewRow selectedRow = dgvHocVien.Rows[e.RowIndex];
                MaHV = selectedRow.Cells["MAHV"].Value.ToString();

                ContextMenuStrip contextMenu = new ContextMenuStrip();

                ToolStripMenuItem toolStripItemAdd = new ToolStripMenuItem("Thêm học viên vào lớp");
                toolStripItemAdd.Click += (s, args) => { AddButton_Click(MaHV); };
                contextMenu.Items.Add(toolStripItemAdd);

                ToolStripMenuItem toolStripItemDelete = new ToolStripMenuItem("Xoá học viên khỏi lớp");
                toolStripItemDelete.Click += (s, args) => { DeleteButton_Click(MaHV); };
                contextMenu.Items.Add(toolStripItemDelete);

                Rectangle cellRectangle = dgvHocVien.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                contextMenu.Show(dgvHocVien, cellRectangle.Location);
            }
        }

        //Thêm hv vô lớp khác
        private void AddButton_Click(string maHV)
        {
            new FormNhapHvVoLop(maHV).ShowDialog();
            hienThi_DSHocVien();
        }
        //Xoá hv ra khỏi lớp
        private void DeleteButton_Click(string maHV)
        {
            new FormXoaHvRaLop(maHV).ShowDialog();
            hienThi_DSHocVien();
        }

        //Click 2 lần vào dòng tương ứng thì nó sẽ lấy dữ liệu dòng đó đưa vào form mới
        private void dgvHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvHocVien.Rows[e.RowIndex];
                MaHV = selectedRow.Cells["MAHV"].Value.ToString();
            }
        }

        //Cập nhật thông tin hv
        private void dgvHocVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new FormUpdateHV(MaHV).ShowDialog();

            //hiển thị ds học viên theo cbo lọc
            string chuoitruyvan = "select PHANLOP.MAHV, HOTENHV, GIOITINH, DIACHI, EMAIL, SDT from HOCVIEN, PHANLOP where HOCVIEN.MAHV = PHANLOP.MAHV and PHANLOP.MaLopHP = '" + cboLop.SelectedValue.ToString() + "'";
            dt = db.getDataTable(chuoitruyvan);
            hienThi_DSHocVien();
            dgvHocVien.DataSource = dt;
        }

        //Tìm kiếm theo tên hoặc sđt
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string chuoitv = "select * from HOCVIEN where SDT= '" + txtTimKiem.Text + "' or HOTENHV LIKE '%" + txtTimKiem.Text + "%' or EMAIL= '" + txtTimKiem.Text + "'";

            if (FormChinh.loaitk == "Giáo viên")
            {
                chuoitv = "select HOCVIEN.MAHV, HOTENHV, GIOITINH, DIACHI, EMAIL, SDT from HOCVIEN, PHANLOP, LOPHOCPHAN, PHANCONG where PHANCONG.MAGV = '" + FormChinh.magv + "' and PHANCONG.MALOPHP = LOPHOCPHAN.MALOPHP and PHANLOP.MALOPHP = LOPHOCPHAN.MALOPHP and PHANLOP.MAHV = HOCVIEN.MAHV and (SDT= '" + txtTimKiem.Text + "' or HOTENHV LIKE '%" + txtTimKiem.Text + "%' or EMAIL= '" + txtTimKiem.Text + "')";
            }
            dt = db.getDataTable(chuoitv);
            if (dt.Rows.Count > 0)
            {
                dgvHocVien.DataSource = dt;
            }
            else
                hienThi_DSHocVien();
        }

        //Lọc xem hv theo ds lớp
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue.ToString().Substring(0, 2) == "HP")
            {
                string chuoitruyvan = "select HOCVIEN.MAHV, HOTENHV, GIOITINH, DIACHI, EMAIL, SDT from HOCVIEN, PHANLOP where HOCVIEN.MAHV = PHANLOP.MAHV and PHANLOP.MALOPHP= '" + cboLop.SelectedValue.ToString() + "'";

                dt = db.getDataTable(chuoitruyvan);
                dgvHocVien.DataSource = dt;
            }
            else
            {
                hienThi_DSHocVien();
            }
        }

        //Lọc xem hv chưa có lớp/đã có lớp
        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoc.SelectedIndex == 0)
            {
                string chuoitruyvan = "SELECT HOCVIEN.MAHV, HOTENHV, GIOITINH, DIACHI, EMAIL, SDT FROM HOCVIEN LEFT JOIN PHANLOP ON HOCVIEN.MAHV = PHANLOP.MAHV WHERE PHANLOP.MAHV IS NULL";
                dt = db.getDataTable(chuoitruyvan);
                dgvHocVien.DataSource = dt;
            }
            else
            {
                string chuoitruyvan = "select HOCVIEN.MAHV, HOTENHV, GIOITINH, DIACHI, EMAIL, SDT from HOCVIEN, PHANLOP where HOCVIEN.MAHV = PHANLOP.MAHV";
                dt = db.getDataTable(chuoitruyvan);
                dgvHocVien.DataSource = dt;
            }
        }
    }
}
