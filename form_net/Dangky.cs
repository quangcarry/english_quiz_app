using form_net.Connection;
using form_net.Utils;
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
namespace form_net
{
    public partial class Dangky : Form
    {
        SqlConnection con = Connect.getSqlConnection();
        public Dangky()
        {
            InitializeComponent();
            txtMatkhau.UseSystemPasswordChar = true;
            txtMatkhauAgain.UseSystemPasswordChar = true;
        }

        public List<string> getAllUsername()
        {
            Connect.OpenConnection();
            List<string> list = new List<string>();
            String sql = "SELECT username FROM users";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader["username"].ToString());
            }
            if (reader != null)
            {
                reader.Close();
            }
            return list;
        }
        public bool checkUsername(string username)
        {
            List<string> list = getAllUsername();
            return list.Contains(username);
        }
        private void label8_MouseHover(object sender, EventArgs e)
        {
            back.BackColor = Color.FromArgb(20, 0, 0, 0);
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            back.BackColor = Color.Transparent;
        }

        private void back_Click(object sender, EventArgs e)
        {
            dangnhap f = new dangnhap();
            f.Show();
            this.Hide();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string fullname = txtHoten.Text;
            string user = txtUsername.Text;
            string pass = txtMatkhau.Text;
            string passAgain = txtMatkhauAgain.Text;
            DateTime dateTime = DateTime.Now;
            if (!StringUtil.isEmpty(fullname) && !StringUtil.isEmpty(user) && !StringUtil.isEmpty(pass) && !StringUtil.isEmpty(passAgain))
            {
                if (!checkUsername(user))
                {
                    if (pass.Equals(passAgain))
                    {
                        Connect.OpenConnection();
                        SqlCommand cmd = new SqlCommand("INSERT INTO users VALUES(@us,@pw,@email,@name,'user',@date)", con);
                        cmd.Parameters.AddWithValue("@name", fullname);
                        cmd.Parameters.AddWithValue("@us", user);
                        cmd.Parameters.AddWithValue("@pw", pass);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@date", dateTime);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registered successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dangnhap f = new dangnhap();
                        f.Show();
                        this.Hide();

                    }
                    else MessageBox.Show("Passwords do not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Username is already taken, please re-enter!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else MessageBox.Show("Please do not leave information blank!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
