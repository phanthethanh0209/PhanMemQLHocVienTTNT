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
    /*
     * FORM NÀY CÓ:
     * Khởi tạo tự động mã hoá đơn, mã học viên
     * Kiểm tra học viên đã tồn tại hay chưa (thông qua số điện thoại)
     * Chặn không cho nhập số điện thoại chứa chữ, không cho nhập tên chứa số
     * Kiểm tra sđt 10 kí tự
     * Kiểm tra nhập đầy đủ các trường và chọn lớp tương ứng thì mới thêm được
     * Khi chọn lớp học phần thì phải hiện sỉ số, tình trạng đầy/trống, học phí, thành tiền tương ứng
     * Khi chọn mã km thì thành tiền được tự động tính lại
     * Hiển thị xem trước hoá đơn khi click checkbox
     * */
    public partial class FormNhapHV : Form
    {
        public FormNhapHV()
        {
            InitializeComponent();
        }
        DBConnect db = new DBConnect();
        DataTable dt;

        void hienThi_DSLop()
        {
            string nht = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
            string chuoitruyvan = "select MaLopHP from LOPHOCPHAN where NGAYKHAIGIANG >= '"+nht+"'";
            dt = db.getDataTable(chuoitruyvan);

            DataRow dr = dt.NewRow();
            dr["MaLopHP"] = "Hãy chọn";
            dt.Rows.InsertAt(dr, 0);

            cboLopHP.DataSource = dt;
            cboLopHP.DisplayMember = "MaLopHP";
            cboLopHP.ValueMember = "MaLopHP";
        }

        void hienThi_DSMaKM()
        {
            string chuoitruyvan = "select MAKM from KHUYENMAI";
            dt = db.getDataTable(chuoitruyvan);

            DataRow dr = dt.NewRow();
            dr["MAKM"] = "Không có";
            dt.Rows.InsertAt(dr, 0);

            cboMaKM.DataSource = dt;
            cboMaKM.DisplayMember = "MAKM";
            cboMaKM.ValueMember = "MAKM";
        }

        private void FormNhapHV_Load(object sender, EventArgs e)
        {
            cb_gioiTinh.Items.Add("Nam");
            cb_gioiTinh.Items.Add("Nữ");
            hienThi_DSLop();
            hienThi_DSMaKM();

            //tạo mã học viên tự động 
            string chuoitv= "Select TOP 1 MaHV from HOCVIEN WHERE MaHV LIKE 'HV%' ORDER BY MaHV DESC";
            txtMaHv.Text = Function.TaoMa("HV", chuoitv);

            txtNgayLap.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);

            //hiển thị mã hoá đơn tự động
            string maHD = "HD" + DateTime.Now.ToString("ddMMyyyy_").Trim() + "_" + "%";
            string sql = "Select TOP 1 MAHD from HOADON WHERE MAHD LIKE '" + maHD + "' ORDER BY MAHD DESC";
            txtMaHD.Text = Function.CreateKey(sql);
            txtNguoiLap.Text = FormChinh.tentk;
            
        }

        int flag = 0; //lớp đầy
        private void cboLopHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chuoitv= "select count(*) from PHANLOP where MALOPHP= '"+cboLopHP.SelectedValue.ToString()+"'";
            dt = db.getDataTable(chuoitv);
            
            DataTable dt2;
            string chuoitv2= "select SISO, FORMAT(HOCPHI,'N0') AS HOCPHI from LOPHOCPHAN where MALOPHP = '" + cboLopHP.SelectedValue.ToString() + "'";
            dt2 = db.getDataTable(chuoitv2);

            if (dt != null && dt.Rows.Count > 0 && dt2 != null && dt2.Rows.Count > 0)
            {
                txtSiSo.Text = dt.Rows[0][0].ToString() + "/" + dt2.Rows[0]["SISO"].ToString();
                txtHocPhi.Text = dt2.Rows[0]["HOCPHI"].ToString();
                //hiển thị thông báo tình trạng
                if (int.Parse(dt.Rows[0][0].ToString()) < int.Parse(dt2.Rows[0]["SISO"].ToString()))
                {
                    lbTinhTrang2.Text = "Lớp còn trống, có thể đăng kí!";
                    flag = 1;
                } 
                else
                {
                    lbTinhTrang2.Text = "Lớp đầy, không thể đăng kí!";
                    flag = 0;
                }
                    
            }

            //hiện thành tiền
            if ( cboLopHP.SelectedIndex != 0)
            {
                if(cboMaKM.SelectedIndex != 0)
                {
                    string chuoitv3 = "select FORMAT(SOTIENGIAM,'N0') AS SOTIENGIAM from KHUYENMAI where MAKM = '" + cboMaKM.SelectedValue.ToString() + "'";
                    dt = db.getDataTable(chuoitv3);
                    decimal tt = decimal.Parse(txtHocPhi.Text) - decimal.Parse(dt.Rows[0]["SOTIENGIAM"].ToString());
                    txtThanhTien.Text = string.Format("{0:0,0}", tt);
                }else //không có km
                {
                    txtThanhTien.Text = txtHocPhi.Text;
                }  
            }
            else
                txtThanhTien.Clear();
              
        }

        //nếu đã chọn mã lớp và đã chọn mã km thì tính thành tiền
        private void cboMaKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hiện thành tiền
            if (cboLopHP.SelectedIndex != 0)
            {
                if (cboMaKM.SelectedIndex != 0)
                {
                    string chuoitv3 = "select FORMAT(SOTIENGIAM,'N0') AS SOTIENGIAM from KHUYENMAI where MAKM = '" + cboMaKM.SelectedValue.ToString() + "'";
                    dt = db.getDataTable(chuoitv3);
                    decimal tt = decimal.Parse(txtHocPhi.Text) - decimal.Parse(dt.Rows[0]["SOTIENGIAM"].ToString());
                    txtThanhTien.Text = string.Format("{0:0,0}", tt);
                }
                else //không có km
                {
                    txtThanhTien.Text = txtHocPhi.Text;
                }
            }
            else
                txtThanhTien.Clear();

        }

        bool kTTruocKhiThem()
        {
            if (txtTenHv.Text.Length != 0 && txtSDT.Text.Length != 0 && txtEmail.Text.Length != 0 && txtDiaChi.Text.Length != 0 && cb_gioiTinh.SelectedIndex >=0 && cboLopHP.SelectedIndex > 0)
                return true;
            else
                return false;
        }

        //thêm hv mới : ko dc nếu sdt trùng --> đã tồn tại, hoặc lớp đầy
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (kTTruocKhiThem() == true) //TH đã nhập đủ thông tin
            {
                string chuoitv = "select count(*) from HOCVIEN where SDT = '" + txtSDT.Text + "'";
                dt = db.getDataTable(chuoitv);
                if (int.Parse(dt.Rows[0][0].ToString()) == 0 && flag == 1) //không tồn tại sđt trùng -> hv chưa có mã, flag = 1 --> lớp còn trống
                {
                    string gt;
                    if (cb_gioiTinh.SelectedIndex == 0)
                        gt = "Nam";
                    else
                        gt = "Nữ";
                    //thêm hv vào bảng HOCVIEN
                    string chuoitruyvan = "Insert into HOCVIEN values('" + txtMaHv.Text + "',N'" + txtTenHv.Text + "',N'" + gt + "','" + txtDiaChi.Text + "', '" + txtEmail.Text + "', '" + txtSDT.Text + "')";
                    int k = db.getNonQuery(chuoitruyvan);
                    if (k == 1)
                    {
                        MessageBox.Show("Thêm học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }

                    //Phân lớp
                    string chuoitruyvan2 = "Insert into PHANLOP values('" + cboLopHP.SelectedValue.ToString() + "',N'" + txtMaHv.Text + "')";
                    int k2 = db.getNonQuery(chuoitruyvan2);
                    if (k2 == 1)
                    {
                        MessageBox.Show("Phân lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Phân lớp thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }

                    //Tạo hoá đơn
                    string nl = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    string chuoitruyvan3 = "INSERT INTO HOADON VALUES('" + txtMaHD.Text + "',N'" + txtMaHv.Text + "','" + nl + "','" + cboLopHP.SelectedValue.ToString() + "', ";

                    if (cboMaKM.SelectedIndex != 0)
                        chuoitruyvan3 += "'" + cboMaKM.SelectedValue.ToString() + "',";
                    else
                        chuoitruyvan3 += "null,";
                    chuoitruyvan3 += "'"+txtNguoiLap.Text+"','" + txtThanhTien.Text + "')";

                    int k3 = db.getNonQuery(chuoitruyvan3);
                    if (k3 == 1)
                    {
                        MessageBox.Show("Tạo hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Tạo hoá đơn thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("\t Lỗi!!\nCó thể xảy ra các lỗi sau: \n- Học viên đã tồn tại \n- Lớp đầy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        //xem trước hoá đơn
        private void ckXemHD_CheckedChanged(object sender, EventArgs e)
        {
            if (kTTruocKhiThem())
            {
                string hd = "\n\tThông Tin Hoá Đơn";
                hd += "\n______________________________________________________";
                hd = hd + "\nMã hoá đơn: " + txtMaHD.Text;
                hd += "\nMã học viên: " + txtMaHv.Text;
                hd += "\nNgày lập: " + txtNgayLap.Text;
                hd += "\nMã lớp: " + cboLopHP.SelectedValue.ToString();
                hd += "\nMã khuyến mãi: " + cboMaKM.SelectedValue.ToString();
                hd += "\nNhân viên: " + txtNguoiLap.Text;
                hd += "\nThành tiền: " + txtThanhTien.Text;
                if (ckXemHD.Checked)
                {
                    MessageBox.Show(hd, "Thông tin hoá đơn", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ckXemHD.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                ckXemHD.Checked = false;
            }  
                
        }

        //không cho nhập kí tự khác số
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                this.errorProvider1.SetError(txtSDT, "Không nhập kí tự khác số!");
                e.Handled = true;
            }
            else
                this.errorProvider1.Clear();
        }
        //không cho nhập kí tự số
        private void txtTenHV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                this.errorProvider1.SetError(txtTenHv, "Không nhập kí tự số!");
                e.Handled = true;
            }
            else
                this.errorProvider1.Clear();
        }

        //số điện thoại phải đủ 10 kí tự
        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if( txtSDT.Text.Length != 10)
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
