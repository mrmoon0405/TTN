using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ThucTapNhom1
{
    public partial class Form1 : Form
    {
        string flag = "";
        string connectionString = @"Data Source=HOME-PC\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            layPX();
        }
        void lockcontrol()
        {
            btnthempx.Enabled = false;
            btnsuapx.Enabled = false;
            btnxoapx.Enabled = false;
            btnluupx.Enabled = true;
            btnhuypx.Enabled = true;
        }
        void unlockcontrol()
        {
            btnthempx.Enabled = true;
            btnsuapx.Enabled = true;
            btnxoapx.Enabled = true;
            btnluupx.Enabled = false;
            btnhuypx.Enabled = false;
        }
        void layPX()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "HTPX";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dsKhachHang = new DataSet();
                adapter.Fill(dsKhachHang);
                dgvPX.DataSource = dsKhachHang.Tables[0];
            }
            catch
            {
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        void themPX()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                {
                    if (txttenpx.Text == "")
                        MessageBox.Show("Bạn Chưa Nhập Tên");
                    if (txttienpx.Text == "")
                        MessageBox.Show("Bạn Chưa Nhập Tổng Tiền");
                    if (txthtttpx.Text == "")
                        MessageBox.Show("Bạn Chưa Nhập HTTT");
                    if (txttenpx.Text != "" && txttienpx.Text != "" && txthtttpx.Text != "")
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("ThemPX", con);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idPX", txtidpx.Text);
                        command.Parameters.AddWithValue("@NgayBan", dtpngaypx.Value);
                        command.Parameters.AddWithValue("@TongTien", txttienpx.Text);
                        command.Parameters.AddWithValue("@HTTT", txthtttpx.Text);
                        command.Parameters.AddWithValue("@TenHang", txttenpx.Text);
                        command.Parameters.AddWithValue("@idkhachhang", cbbidkhpx.Text);
                        command.ExecuteNonQuery();
                        layPX();
                        con.Close();
                        MessageBox.Show("Thêm Thành Công", "Thông Báo");
                    }
                }
            }
        }
        void suaPX()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SuaPX", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPX", txtidpx.Text);
                    command.Parameters.AddWithValue("@NgayBan", dtpngaypx.Value);
                    command.Parameters.AddWithValue("@TongTien", txttienpx.Text);
                    command.Parameters.AddWithValue("@HTTT", txthtttpx.Text);
                    command.Parameters.AddWithValue("@TenHang", txttenpx.Text);
                    command.Parameters.AddWithValue("@idkhachhang", cbbidkhpx.Text);
                    command.ExecuteNonQuery();
                    layPX();
                    con.Close();
                    MessageBox.Show("Sửa Thành Công", "Thông Báo");
                }
            }
        }
        void xoaPX()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeletePX";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idpx", txtidpx.Text);
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();
            layPX();
        }
        void autoid()
        {
            int count = 0;
            count = dgvPX.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvPX.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32(chuoi.Remove(0, 2));
            chuoi = chuoi + chuoi2.ToString();
            chuoi = chuoi + "0";
            if (chuoi2 + 1 < 10)
            {
                txtidpx.Text = "PX0" + (chuoi2 + 1).ToString();
            }
            else if (chuoi2 + 1 < 100)
            {
                txtidpx.Text = "PX" + (chuoi2 + 1).ToString();
            }
        }
        private void btnthempx_Click(object sender, EventArgs e)
        {
            txtidpx.ReadOnly = true;
            lockcontrol();
            flag = "add";
            autoid();
            txthtttpx.Clear();
            txttenpx.Clear();
            txttienpx.Clear();
        }
        private void btnsuapx_Click(object sender, EventArgs e)
        {
            txtidpx.ReadOnly = true;
            lockcontrol();
            flag = "edit";
        }
        private void btnxoapx_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                xoaPX();
                MessageBox.Show("Xóa Thành Công");
            }
        }
        private void btnluupx_Click(object sender, EventArgs e)
        {
            txtidpx.ReadOnly = true;
            unlockcontrol();
            if (flag == "add")
            {
                themPX();
            }
            if (flag == "edit")
            {
                suaPX();
            }

            txthtttpx.Clear();
            txtidpx.Clear();
            txttenpx.Clear();
            txttienpx.Clear();
        }
        private void btnhuypx_Click(object sender, EventArgs e)
        {
            txtidpx.ReadOnly = false;
            unlockcontrol();
        }
        private void btnluupx_Click_1(object sender, EventArgs e)
        {
            txtidpx.ReadOnly = true;
            unlockcontrol();
            if (flag == "add")
            {
                themPX();
            }
            if (flag == "edit")
            {
                suaPX();
            }

            txthtttpx.Clear();
            txtidpx.Clear();
            txttenpx.Clear();
            txttienpx.Clear();
        }
        private void btnhuypx_Click_1(object sender, EventArgs e)
        {
            txtidpx.ReadOnly = false;
            unlockcontrol();
        }
        private void btnloadpx_Click_1(object sender, EventArgs e)
        {
            layPX();
        }
        private void btntongpx_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "TongTienPX";
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dsKhachHang = new DataSet();
            adapter.Fill(dsKhachHang);
            dgvPX.DataSource = dsKhachHang.Tables[0];
            con.Close();
        }
        private void khhn_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "PX0HN";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dsKhachHang = new DataSet();
                adapter.Fill(dsKhachHang);
                dgvPX.DataSource = dsKhachHang.Tables[0];
            }
            catch
            {
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private void khnothn_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "PXHN";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dsKhachHang = new DataSet();
                adapter.Fill(dsKhachHang);
                dgvPX.DataSource = dsKhachHang.Tables[0];
            }
            catch
            {
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private void btnshowkh_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "HTKH";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dsKhachHang = new DataSet();
                adapter.Fill(dsKhachHang);
                dgvkhpx.DataSource = dsKhachHang.Tables[0];
            }
            catch
            {
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private void dgvPX_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtidpx.Text = dgvPX.Rows[e.RowIndex].Cells[0].Value.ToString();
            dtpngaypx.Text = dgvPX.Rows[e.RowIndex].Cells[1].Value.ToString();
            txttienpx.Text = dgvPX.Rows[e.RowIndex].Cells[2].Value.ToString();
            txthtttpx.Text = dgvPX.Rows[e.RowIndex].Cells[3].Value.ToString();
            txttenpx.Text = dgvPX.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbbidkhpx.Text = dgvPX.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        private void cbbfindpx_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("TimPX", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tenhang", cbbfindpx.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dshang = new DataSet();
                adapter.Fill(dshang);
                dgvPX.DataSource = dshang.Tables[0];
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet1.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.quanLyBanHangDataSet1.KhachHang);
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter.Fill(this.quanLyBanHangDataSet.SanPham);

        }
    }
}
