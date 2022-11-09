using BUS;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapChieuPhim
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NhanVienBUS nv = new NhanVienBUS();
            if (nv.checkDs() == true)
            {
                listBox1.DataSource = nv.getDSNhanVien();
                listBox1.DisplayMember = "TenNhanVien";
                listBox1.ValueMember = "IDNhanVien";
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtPassWord.Text == ""&& txtPassAdmin.Text == "")
            {
                MessageBox.Show("Nhập Thông Tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                nv = new NhanVienBUS();
                if (nv.checkLogin(txtUserName.Text, txtPassWord.Text) == true)
                {
                    MessageBox.Show("Xin chào: " + listBox1.Text, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (nv.checkLoginAdmin(txtUserName.Text, txtPassAdmin.Text) == true)
                {
                    MessageBox.Show("Xin chào quản trị!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sai Mật Khẩu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        NhanVienBUS nv;
        private void rbNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNhanVien.Checked == true)
            {
                rbQuanTri.Checked = false;
                txtPassAdmin.Enabled = false;
                groupBox1.Enabled = true;
                label3.Text = "";
                txtPassAdmin.Text = "";
            }
        }

        private void rbQuanTri_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQuanTri.Checked == true)
            {
                rbNhanVien.Checked = false;
                groupBox1.Enabled = false;
                txtPassAdmin.Enabled = true;
                txtPassWord.Text = "";
                label3.Text = "PassWord";
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nv = new NhanVienBUS();
            string user = nv.getUser(listBox1.Text);
            txtUserName.Text = user;
            txtUserName.Enabled = false;
            if (user != "Không có username")
            {
                txtPassWord.Enabled = true;
            }
            else
            {
                txtPassWord.Enabled = false;
            }
            
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                chkShowPass.Text = "Ẩn mật khẩu";
                txtPassAdmin.UseSystemPasswordChar = false; 
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                chkShowPass.Text = "Hiển thị mật khẩu";
                txtPassAdmin.UseSystemPasswordChar = true;
                txtPassWord.UseSystemPasswordChar = true;
            }
        }
    }
}
