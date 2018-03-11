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
            layncc();
            layKH();
            layPN();
            layNVtdung();
            layMH();
        }
        // Phan Phieu Xuat
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
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "DeletePX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_idPX", txtidpx.Text);
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    layPX();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
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
        // Ket thuc Phieu Xuat
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet5.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter1.Fill(this.quanLyBanHangDataSet5.SanPham);
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet4.NCC' table. You can move, or remove it, as needed.
            this.nCCTableAdapter1.Fill(this.quanLyBanHangDataSet4.NCC);
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet31.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.quanLyBanHangDataSet31.NhanVien);
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet2.NCC' table. You can move, or remove it, as needed.
            this.nCCTableAdapter.Fill(this.quanLyBanHangDataSet2.NCC);
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet1.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.quanLyBanHangDataSet1.KhachHang);
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter.Fill(this.quanLyBanHangDataSet.SanPham);

        }
        // Phan Nha Cung Cap
        void Khoancc()
        {
            btnthemncc.Enabled = false;
            btnsuancc.Enabled = false;
            btnxoancc.Enabled = false;
            btnbackncc.Enabled = false;
            btntimkiemncc.Enabled = false;
            btnquoctencc.Enabled = false;
            btntrongnuocncc.Enabled = false;
            btnluuncc.Enabled = true;
            btnhuyncc.Enabled = true;
        }
        void Khoahongncc()
        {
            btntrongnuocncc.Enabled = true;
            btnquoctencc.Enabled = true;
            btntimkiemncc.Enabled = true;
            btnthemncc.Enabled = true;
            btnsuancc.Enabled = true;
            btnxoancc.Enabled = true;
            btnbackncc.Enabled = true;
            btnluuncc.Enabled = false;
            btnhuyncc.Enabled = false;
        }
        void autoidNCC()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sqlSelect = "showncc";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsncc = new DataTable();
            adapter.Fill(dsncc);
            string g = "";
            if (dsncc.Rows.Count <= 0)
            {
                g = "NCC01";
            }
            else
            {
                int k;
                g = "NCC";
                k = Convert.ToInt32(dsncc.Rows[dsncc.Rows.Count - 1][0].ToString().Substring(3, 2));
                k = k + 1;
                if (k < 10)
                    g = g + "0";
                g = g + k.ToString();
            }
            txtidncc.Text = g;
        }
        void layncc()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "showncc";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dsncc = new DataSet();
                adapter.Fill(dsncc);
                dgvNCC.DataSource = dsncc.Tables[0];
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
        private void btnthemncc_Click(object sender, EventArgs e)
        {
            autoidNCC();
            flag = "add";
            Khoancc();
        }
        private void btnsuancc_Click(object sender, EventArgs e)
        {
            flag = "edit";
            Khoancc();
        }
        private void btnxoancc_Click(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "XoaNCC";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_idNCC", txtidncc.Text);
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    layncc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }
        private void btnluuncc_Click(object sender, EventArgs e)
        {
            if (flag == "edit")
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand("SuaNCC", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        if (string.IsNullOrEmpty(txtidncc.Text) || string.IsNullOrEmpty(txttenncc.Text) || string.IsNullOrEmpty(txtdcncc.Text) || string.IsNullOrEmpty(txtsdtncc.Text) || string.IsNullOrEmpty(txtdongiancc.Text))
                        {
                            MessageBox.Show("Bạn chưa nhập dữ liệu đầy đủ");
                            return;
                        }
                        command.Parameters.AddWithValue("@_idNCC", txtidncc.Text);
                        command.Parameters.AddWithValue("@_TenNCC", txttenncc.Text);
                        command.Parameters.AddWithValue("@_DC", txtdcncc.Text);
                        command.Parameters.AddWithValue("@_SDT", txtsdtncc.Text);
                        command.Parameters.AddWithValue("@_DonGia", txtdongiancc.Text);
                        command.ExecuteNonQuery();
                        layncc();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        if (conn != null && conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            if (flag == "add")
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("ThemNCC", con);
                        command.CommandType = CommandType.StoredProcedure;
                        if (string.IsNullOrEmpty(txtidncc.Text) || string.IsNullOrEmpty(txttenncc.Text) || string.IsNullOrEmpty(txtdcncc.Text) || string.IsNullOrEmpty(txtsdtncc.Text) || string.IsNullOrEmpty(txtdongiancc.Text))
                        {
                            MessageBox.Show("Bạn chưa nhập dữ liệu đầy đủ");
                            return;
                        }
                        command.Parameters.AddWithValue("@_idNCC", txtidncc.Text);
                        command.Parameters.AddWithValue("@_tenNCC", txttenncc.Text);
                        command.Parameters.AddWithValue("@_DC", txtdcncc.Text);
                        command.Parameters.AddWithValue("@_SDT", txtsdtncc.Text);
                        command.Parameters.AddWithValue("@_DonGia", txtdongiancc.Text);
                        command.ExecuteNonQuery();
                        layncc();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (con != null && con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            Khoahongncc();
        }
        private void btnhuyncc_Click(object sender, EventArgs e)
        {
            Khoahongncc();
        }
        private void btntimkiemncc_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("TimTenNCC", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_TenNCC", "%" + cbtimkiemncc.Text + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dsNCC = new DataSet();
                    adapter.Fill(dsNCC);
                    dgvNCC.DataSource = dsNCC.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }
            }
        }
        private void btntrongnuocncc_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "TrongNuoc";
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet tkncc = new DataSet();
              adapter.Fill(tkncc);
            dgvNCC.DataSource = tkncc.Tables[0];
            adapter.Dispose();
            con.Close();
        }
        private void btnquoctencc_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "QuocTe";
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet tkncc = new DataSet();
            adapter.Fill(tkncc);
            dgvNCC.DataSource = tkncc.Tables[0];
            adapter.Dispose();
            con.Close();
        }
        private void btnbackncc_Click(object sender, EventArgs e)
        {
            layncc();
        }
        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidncc.Text = dgvNCC.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttenncc.Text = dgvNCC.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtdongiancc.Text = dgvNCC.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtdcncc.Text = dgvNCC.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsdtncc.Text = dgvNCC.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        // Ket Thuc Nha Cung Cap
        // Phan Nhan Vien
        void Khoatdung()
        {
            btnthemnvtdung.Enabled = false;
            btnsuanvtdung.Enabled = false;
            btnxoanvtdung.Enabled = false;
            btnluunvtdung.Enabled = true;
            btnhuynvtdung.Enabled = true;
        }
        void Khoahongtdung()
        {
            btnthemnvtdung.Enabled = true;
            btnsuanvtdung.Enabled = true;
            btnxoanvtdung.Enabled = true;
            btnluunvtdung.Enabled = false;
            btnhuynvtdung.Enabled = false;
        }
        void layNVtdung()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "HTNV";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dsnv = new DataSet();
                adapter.Fill(dsnv);
                dgvnvtdung.DataSource = dsnv.Tables[0];
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
        void Tusinhmatdung()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sqlSelect = "HTNV";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dsnv = new DataTable();
            adapter.Fill(dsnv);
            string g = "";
            if (dsnv.Rows.Count <= 0)
            {
                g = "NV01";
            }
            else
            {
                int k;
                g = "NV";
                k = Convert.ToInt32(dsnv.Rows[dsnv.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                    g = g + "0";
                g = g + k.ToString();
            }
            txtidnvtd.Text = g;
        }
        private void btnthemnvtdung_Click_1(object sender, EventArgs e)
        {
            Tusinhmatdung();
            flag = "add";
            Khoatdung();

        }
        private void btnbacktdung_Click_1(object sender, EventArgs e)
        {
            layNVtdung();
        }
        private void cbbtimkiemtdung_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("TimNV", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Ca", "%" + cbbtimkiemtdung.Text + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dsNV = new DataSet();
                    adapter.Fill(dsNV);
                    dgvnvtdung.DataSource = dsNV.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }
            }
        }
        private void btntimkiemtdung_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("TimNV", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Ca", "%" + cbbtimkiemtdung.Text + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dsNV = new DataSet();
                adapter.Fill(dsNV);
                dgvnvtdung.DataSource = dsNV.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }
        private void btnsuanvtdung_Click_1(object sender, EventArgs e)
        {
            flag = "edit";
            Khoatdung();
        }
        private void btnxoanvtdung_Click_1(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Xoa_NV";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_idNV", txtidnvtd.Text);
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    layNVtdung();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }
        private void btnluunvtdung_Click_1(object sender, EventArgs e)
        {
            if (flag == "edit")
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {

                        conn.Open();
                        SqlCommand command = new SqlCommand("Sua_NV", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        if (string.IsNullOrEmpty(txtidnvtd.Text) || string.IsNullOrEmpty(txttennvtd.Text) || string.IsNullOrEmpty(txtcanvtdung.Text) || string.IsNullOrEmpty(txtdcnvtdung.Text) || string.IsNullOrEmpty(txtsdtnvtdung.Text))
                        {
                            MessageBox.Show("Bạn chưa nhập dữ liệu đầy đủ");
                            return;
                        }
                        command.Parameters.AddWithValue("@_idNV", txtidnvtd.Text);
                        command.Parameters.AddWithValue("@_TenNV", txttennvtd.Text);
                        command.Parameters.AddWithValue("@_Ca", txtcanvtdung.Text);
                        command.Parameters.AddWithValue("@_DC", txtdcnvtdung.Text);
                        command.Parameters.AddWithValue("@_SDT", txtsdtnvtdung.Text);
                        command.ExecuteNonQuery();
                        layNVtdung();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        if (conn != null && conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            if (flag == "add")
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("Them_NV", con);
                        command.CommandType = CommandType.StoredProcedure;
                        if (string.IsNullOrEmpty(txtidnvtd.Text) || string.IsNullOrEmpty(txttennvtd.Text) || string.IsNullOrEmpty(txtcanvtdung.Text) || string.IsNullOrEmpty(txtdcnvtdung.Text) || string.IsNullOrEmpty(txtsdtnvtdung.Text))
                        {
                            MessageBox.Show("Bạn chưa nhập dữ liệu đầy đủ");
                            return;
                        }
                        command.Parameters.AddWithValue("@_idNV", txtidnvtd.Text);
                        command.Parameters.AddWithValue("@_TenNV", txttennvtd.Text);
                        command.Parameters.AddWithValue("@_Ca", txtcanvtdung.Text);
                        command.Parameters.AddWithValue("@_DC", txtdcnvtdung.Text);
                        command.Parameters.AddWithValue("@_SDT", txtsdtnvtdung.Text);
                        command.ExecuteNonQuery();
                        layNVtdung();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (con != null && con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            Khoahongtdung();
        }
        private void btnhuynvtdung_Click_1(object sender, EventArgs e)
        {
            Khoahongtdung();
        }
        private void dgvnvtdung_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtidnvtd.Text = dgvnvtdung.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttennvtd.Text = dgvnvtdung.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtcanvtdung.Text = dgvnvtdung.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtdcnvtdung.Text = dgvnvtdung.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsdtnvtdung.Text = dgvnvtdung.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
 
        // Ket Thuc Phan Nhan Vien
        // Phan San Pham
        void Khoamh()
        {
            btntrangchumh.Enabled = false;
            btntimkiemmh.Enabled = false;
            btnthemmh.Enabled = false;
            btnsuamh.Enabled = false;
            btnxoamh.Enabled = false;
            btnluumh.Enabled = true;
            btnhuymh.Enabled = true;
        }
        void KhoaHongmh()
        {
            btnhuymh.Enabled = false;
            btnluumh.Enabled = false;
            btnsuamh.Enabled = true;
            btnthemmh.Enabled = true;
            btntimkiemmh.Enabled = true;
            btntrangchumh.Enabled = true;
            btnxoamh.Enabled = true;
        }
        void layMH()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "ShowSP";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dssp = new DataSet();
                adapter.Fill(dssp);
                dgvspmh.DataSource = dssp.Tables[0];
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
        void layCTSP()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "ShowCTSP";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dssp = new DataSet();
                adapter.Fill(dssp);
                dgvctspmh.DataSource = dssp.Tables[0];
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
        private void btnthemmh_Click_1(object sender, EventArgs e)
        {
            Tusinhmamh();
            flag = "add";
            Khoamh();
        }
        private void btnsuamh_Click_1(object sender, EventArgs e)
        {
            flag = "edit";
            Khoamh();
        }
        private void btnxoamh_Click_1(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "XoaSP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_idMH", txtidmh.Text);
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    layMH();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }
        private void btnluumh_Click_1(object sender, EventArgs e)
        {
            if (flag == "edit")
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    try
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand("Sua_SP", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        if (string.IsNullOrEmpty(txtidmh.Text) || string.IsNullOrEmpty(txttenmh.Text) || string.IsNullOrEmpty(txtnguongmh.Text) || string.IsNullOrEmpty(cbbidnccmh.Text))
                        {
                            MessageBox.Show("Bạn chưa nhập dữ liệu đầy đủ");
                            return;
                        }
                        command.Parameters.AddWithValue("@_idMH", txtidmh.Text);
                        command.Parameters.AddWithValue("@_TenHang", txttenmh.Text);
                        command.Parameters.AddWithValue("@_Nguong", txtnguongmh.Text);
                        command.Parameters.AddWithValue("@_idNCC", cbbidnccmh.Text);
                        command.ExecuteNonQuery();
                        layMH();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        if (conn != null && conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }

            if (flag == "add")
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("ThemSP", con);
                        command.CommandType = CommandType.StoredProcedure;
                        if (string.IsNullOrEmpty(txtidmh.Text) || string.IsNullOrEmpty(txttenmh.Text) || string.IsNullOrEmpty(txtnguongmh.Text) || string.IsNullOrEmpty(cbbidnccmh.Text))
                        {
                            MessageBox.Show("Bạn chưa nhập dữ liệu đầy đủ");
                            return;
                        }
                        command.Parameters.AddWithValue("@_idMH", txtidmh.Text);
                        command.Parameters.AddWithValue("@_TenHang", txttenmh.Text);
                        command.Parameters.AddWithValue("@_Nguong", txtnguongmh.Text);
                        command.Parameters.AddWithValue("@_idNCC", cbbidnccmh.Text);
                        command.ExecuteNonQuery();
                        layMH();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if (con != null && con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            KhoaHongmh();
        }
        private void btntimkiemmh_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("TimSP", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_TenHang", "%" + cbtimkiemmh.Text + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dssp = new DataSet();
                    adapter.Fill(dssp);
                    dgvspmh.DataSource = dssp.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }
            }
        }
        private void btnctspmh_Click_1(object sender, EventArgs e)
        {
            layCTSP();
        }
        private void btntrangchumh_Click_1(object sender, EventArgs e)
        {
            layMH();
        }
        private void dgvspmh_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtidmh.Text = dgvspmh.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttenmh.Text = dgvspmh.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtnguongmh.Text = dgvspmh.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbidnccmh.Text = dgvspmh.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private void btnhuymh_Click(object sender, EventArgs e)
        {
            KhoaHongmh();
        }
        void Tusinhmamh()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sqlSelect = "ShowSP";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dssp = new DataTable();
            adapter.Fill(dssp);
            string g = "";
            if (dssp.Rows.Count <= 0)
            {
                g = "MH01";
            }
            else
            {
                int k;
                g = "MH";
                k = Convert.ToInt32(dssp.Rows[dssp.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                    g = g + "0";
                g = g + k.ToString();
            }
            txtidmh.Text = g;
        }

        // Ket Thuc Phan San Pham
        // Phan Phieu Nhap
        void layPN()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlSelect = "ShowPN";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsnv = new DataSet();
            adapter.Fill(dsnv);
            dgvPhieuNhap.DataSource = dsnv.Tables[0];
        }
        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlSelect = "ThongKe";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsnv = new DataSet();
            adapter.Fill(dsnv);
            dgvThongKe.DataSource = dsnv.Tables[0];
            adapter.Dispose();
            dgvThongKe.Visible = true;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            layPN();
        }
        private void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlSelect = "Chuyen Khoan";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsnv = new DataSet();
            adapter.Fill(dsnv);
            dgvPhieuNhap.DataSource = dsnv.Tables[0];
        }
        private void btnTrucTiep_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string sqlSelect = "TrucTiep";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsnv = new DataSet();
            adapter.Fill(dsnv);
            dgvPhieuNhap.DataSource = dsnv.Tables[0];
        }
        // Ket Thuc Phan Phieu Nhap

        // Phan Khach Hang

         void layKH()
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
                dgvdskh.DataSource = dsKhachHang.Tables[0];
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
         void lockcontrolKH()
        {
            btnthemKH.Enabled = false;
            btnsuakh.Enabled = false;
            btnxoakh.Enabled = false;
            btnluukh.Enabled = true;
            btnhuykh.Enabled = true;
        }
         void unlockcontrolKH()
        {
            btnthemKH.Enabled = true;
            btnsuakh.Enabled = true;
            btnxoakh.Enabled = true;
            btnluukh.Enabled = false;
            btnhuykh.Enabled = false;
        }
         void themKH()

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                {
                    if (txttenkh.Text == "")
                        MessageBox.Show("Bạn Chưa Nhập Tên");
                    if (txtdckh.Text == "")
                        MessageBox.Show("Bạn Chưa Nhập Địa Chỉ");
                    if (txtsdtkh.Text == "")
                        MessageBox.Show("Bạn Chưa Nhập SĐT");
                    if (txtsdtkh.Text != "" && txtdckh.Text != "" && txttenkh.Text != "")
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("AddKH", con);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idkhachhang", txtidkh.Text);
                        command.Parameters.AddWithValue("@tenkh", txttenkh.Text);
                        command.Parameters.AddWithValue("@DC", txtdckh.Text);
                        command.Parameters.AddWithValue("@SDT", txtsdtkh.Text);
                        command.ExecuteNonQuery();
                        layKH();
                        con.Close();
                        MessageBox.Show("Thêm Thành Công", "Thông Báo");
                    }
                }
            }
        }
         void suaKH()
        {

            if (txttenkh.Text == "")
                MessageBox.Show("Tên KH không được để trống");
            if (txtdckh.Text == "")
                MessageBox.Show("ĐC không được để trống");
            if (txtsdtkh.Text == "")
                MessageBox.Show("Địa Chỉ Không được để trống");
            if (txtsdtkh.Text != "" && txtdckh.Text != "" && txttenkh.Text != "")
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("UpdateKH", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idkhachhang", txtidkh.Text);
                    command.Parameters.AddWithValue("@tenkh", txttenkh.Text);
                    command.Parameters.AddWithValue("@DC", txtdckh.Text);
                    command.Parameters.AddWithValue("@SDT", txtsdtkh.Text);
                    command.ExecuteNonQuery();
                    layKH();
                    conn.Close();
                    MessageBox.Show("Sửa Thành Công", "Thông Báo");
                }
            }
            else
            {
                MessageBox.Show("Xảy Ra Lỗi !");
            }
        }
         void xoaKH()
        {

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeleteKH";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@_idkhachhang", txtidkh.Text);
            command.Connection = conn;
            command.ExecuteNonQuery();
            layKH();
            conn.Close();
        }
         void autoidKH()
        {
            int count = 0;
            count = dgvdskh.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvdskh.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32(chuoi.Remove(0, 2));
            chuoi = chuoi + chuoi2.ToString();
            chuoi = chuoi + "0";
            if (chuoi2 + 1 < 10)
            {
                txtidkh.Text = "KH0" + (chuoi2 + 1).ToString();
            }
            else if (chuoi2 + 1 < 100)
            {
                txtidkh.Text = "KH" + (chuoi2 + 1).ToString();
            }
        }
        private void btnthemKH_Click(object sender, EventArgs e)
        {
            autoidKH();
            txtidkh.ReadOnly = true;
            lockcontrolKH();
            flag = "add";
        }
        private void btnsuakh_Click(object sender, EventArgs e)
        {
            txtidkh.ReadOnly = true;
            lockcontrolKH();
            flag = "edit";
        }
        private void btnxoakh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                xoaKH();
                MessageBox.Show("Xóa Thành Công");
            }
        }
        private void btnluukh_Click(object sender, EventArgs e)
        {
            txtidkh.ReadOnly = false;
            unlockcontrolKH();
            if (flag == "add")
            {
                themKH();
            }
            if (flag == "edit")
            {
                suaKH();
            }
        }
        private void btnhuykh_Click(object sender, EventArgs e)
        {
            txtidkh.ReadOnly = false;
            unlockcontrolKH();
        }
        private void btnlammoi_Click(object sender, EventArgs e)
        {
             txtidkh.ReadOnly = false;
             unlockcontrolKH();
        }
        private void btntimkiemkh_Click(object sender, EventArgs e)
        {
             using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("findkhbyname", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TenKH", "%" + txttimkiemkh.Text + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dskh = new DataSet();
                    adapter.Fill(dskh);
                    dgvdskh.DataSource = dskh.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }
            }
        }
        private void dgvdskh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             txtidkh.Text = dgvdskh.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttenkh.Text = dgvdskh.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtdckh.Text = dgvdskh.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsdtkh.Text = dgvdskh.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        // Ket Thuc Phan Khach Hang
    }

        
}
