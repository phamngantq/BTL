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
using Guna.UI2.WinForms;

namespace WindowsFormsApp1
{
    public partial class FrmLogin : Form
    {
        string loginMode; // Biến lưu kiểu đăng nhập (USER hoặc ADMIN)

        public FrmLogin(string mode)
        {
            InitializeComponent();
            loginMode = mode;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                txtEmail.Focus(); // Đưa con trỏ về ô trống
                return; // Ngừng không cho chạy tiếp
            }


            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Email!");
                txtEmail.Focus(); // Đưa con trỏ về ô trống
                return; // Ngừng không cho chạy tiếp
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu!");
                txtPassword.Focus();
                return;
            }

            //Tạo một đối tượng chứa kết nối
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-D4IEITM3\\SQLEXPRESS02;Initial Catalog=DOAN;User ID=sa;Password=Sa@12345;TrustServerCertificate=True"); //khởi tạo đối tượng kết nối
           //tạo chuỗi truy vấn 
            string sql = " ";

            if (loginMode == "ADMIN")
            {
                sql = "SELECT * FROM TAIKHOAN WHERE EMAIL='" + txtEmail.Text +
                      "' AND MATKHAU='" + txtPassword.Text +
                      "' AND VAITRO='QUANLY'";
            }
            else // loginMode == "USER"
            {
                sql = "SELECT * FROM TAIKHOAN WHERE EMAIL='" + txtEmail.Text +
                      "' AND MATKHAU='" + txtPassword.Text +
                      "' AND (VAITRO='SINHVIEN' OR VAITRO='GIANGVIEN')";
            }
            // Mở kết nối Sql
            conn.Open();
            //Thực hiện thao tác với csdl chứa câu truy vấn sql và biết dùng kết nối conn để thực thi
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet(); 
            da.Fill(ds); // thực thi cmd và đổ (fill) kết quả trả về vào DataSet ds.
            conn.Close();
            int count = ds.Tables[0].Rows.Count;  //kiểm tra số dòng trả về trong bảng đầu tiên của DataSet ds.
            if (count == 1)
            {
                MessageBox.Show("Đăng nhập thành công!");
                //string role = ds.Tables[0].Rows[0]["VAITRO"].ToString();

                //if (role == "SINHVIEN")
                //{
                //    FrmSinhVien f = new FrmSinhVien();
                //    f.Show();
                //}
                //else if (role == "GIANGVIEN")
                //{
                //    FrmGiangVien f = new FrmGiangVien();
                //    f.Show();
                //}
                //else if (role == "ADMIN")
                //{
                //    FrmAdmin f = new FrmAdmin();
                //    f.Show();
                //}

                this.Hide();
            }
            else
            {
                MessageBox.Show("Email hoặc mật khẩu không chính xác. Hãy thử lại");
            }
        }
        

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
