using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHocVienTTNT
{
    class DBConnect
    {
        //khai bao thuoc tinh ket noi
        public string chuoiketnoi = @"Data Source=LAPTOP-ID1K50C3\SQLEXPRESS;Initial Catalog = QL_HOCVIEN_CNET;User = sa; Password = 123456";
        SqlConnection conn;

        //Pt khoi tao
        public DBConnect()
        {
            conn = new SqlConnection(chuoiketnoi);
        }

        public DBConnect(string chuoikn)
        {
            conn = new SqlConnection(chuoikn);
        }

        //Pt xu ly
        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }
        }

        public int getNonQuery(string chuoitruyvan)
        {
            Open();

            SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);
            int kq = cmd.ExecuteNonQuery();

            Close();
            return kq;
        }

        public object getScalar(string chuoitruyvan)
        {
            Open();
            SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);
            object kq = cmd.ExecuteScalar();

            Close();
            return kq;
        }

        public DataTable getDataTable(string chuoitruyvan)
        {
            SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0]; //data table

        }

        public SqlDataReader getReader(string chuoitruyvan)
        {
            Open();
            SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public int updateDataTable(DataTable dtnew, string chuoitruyvan)
        {
            SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, chuoiketnoi);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kq = da.Update(dtnew);//luu csdl
            return kq;
        }
    }
}
