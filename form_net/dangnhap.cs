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
using form_net.Admin;
using form_net.Connection;
using form_net.User;
using form_net.Utils;

namespace form_net {
    public partial class dangnhap : Form
    {
        public SqlConnection con = Connect.getSqlConnection();

        public dangnhap()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }
        public string[] getIdandRole(string us, string pw)
        {
            try
            {
                Connect.OpenConnection();
                String sql = "SELECT * FROM users";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string user = reader["username"].ToString();
                    string pass = reader["password"].ToString();
                    if (user.Equals(us) && pass.Equals(pw))
                    {
                        return new string[]{ reader["user_id"].ToString(), reader["role"].ToString() };
                    }
                }
                if (reader != null)
                {
                    reader.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error Database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public bool check(string us, string pw)
        {
            return getIdandRole(us, pw) != null;
        }
        private void btnDangky_Click(object sender, EventArgs e)
        {
            Dangky f = new Dangky();
            f.Show();
            this.Hide();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string us = txtUsername.Text;
            string pw = txtPassword.Text;
            if (!StringUtil.isEmpty(us) && !StringUtil.isEmpty(pw))
            {
                if(check(us,pw))
                {
                    string[] res = getIdandRole(us,pw);
                    if (res[1].Equals("admin")){
                        menuAdmin f = new menuAdmin(res[0]);
                        this.Hide(); 
                        f.Show(); 
                    }
                    else
                    {
                        menuUser f  = new menuUser(int.Parse(res[0]));
                        this.Hide();
                        f.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Account and password information is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Please do not leave information blank!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Dangky f = new Dangky();
            f.Show();
            this.Hide();
        }

        private void labehoi_MouseHover(object sender, EventArgs e)
        {
            labehoi.ForeColor = Color.Red;
        }

        private void labehoi_MouseLeave(object sender, EventArgs e)
        {
            labehoi.ForeColor = Color.Blue;
        }

        private void btnDangnhap_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_MouseEnter(object sender, EventArgs e)
        {
            lblus.ForeColor = Color.Orange;
        }

        private void txtUsername_MouseLeave(object sender, EventArgs e)
        {
            lblus.ForeColor = Color.Blue;
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            lblpw.ForeColor = Color.Orange;
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            lblpw.ForeColor = Color.Blue;
        }
    }
}
