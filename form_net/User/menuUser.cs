using form_net.Connection;
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
using form_net.Model;
using form_net.Admin;

namespace form_net.User
{
    
    public partial class menuUser : Form
    {
        SqlConnection con = Connect.getSqlConnection();
        public int id;
        public menuUser()
        {
            InitializeComponent();
            innit();
            this.id = 0;
            initLabel();
        }
        public menuUser(int id)
        {
            InitializeComponent();
            innit();
            this.id = id;
            initLabel();
        }
        void innit()
        {
            panelProfile.MouseHover += new EventHandler(Control_MouseHover);
            panelProfile.MouseLeave += new EventHandler(Control_MouseLeave);
            lbltext.MouseHover += new EventHandler(Control_MouseHover);
            lbltext.MouseLeave += new EventHandler(Control_MouseLeave);
            panelManager.MouseHover += new EventHandler(Control_MouseHover);
            panelManager.MouseLeave += new EventHandler(Control_MouseLeave);
            lblmanager.MouseHover += new EventHandler(Control_MouseHover);
            lblmanager.MouseLeave += new EventHandler(Control_MouseLeave);
            panelTest.MouseHover += new EventHandler(Control_MouseHover);
            panelTest.MouseLeave += new EventHandler(Control_MouseLeave);
            lblstartTest.MouseHover += new EventHandler(Control_MouseHover);
            lblstartTest.MouseLeave += new EventHandler(Control_MouseLeave);
            panelChangepassword.MouseHover += new EventHandler(Control_MouseHover);
            panelChangepassword.MouseLeave += new EventHandler(Control_MouseLeave);
            lblChangepassword.MouseHover += new EventHandler(Control_MouseHover);
            lblChangepassword.MouseLeave += new EventHandler(Control_MouseLeave);
            panelLogout.MouseHover += new EventHandler(Control_MouseHover);
            panelLogout.MouseLeave += new EventHandler(Control_MouseLeave);
            lblLogout.MouseHover += new EventHandler(Control_MouseHover);
            lblLogout.MouseLeave += new EventHandler(Control_MouseLeave);
            panelTest.Click += new EventHandler(Click_DoAnExam);
            lblstartTest.Click += new EventHandler(Click_DoAnExam); 
            panelLogout.Click += new EventHandler(Click_Logout);
            lblLogout.Click += new EventHandler(Click_Logout);
            panelProfile.Click += new EventHandler(Click_MyProfile);
            lbltext.Click += new EventHandler(Click_MyProfile);
            panelManager.Click += new EventHandler(Click_ManagerExam);
            lblmanager.Click += new EventHandler(Click_ManagerExam);
            lblChangepassword.Click += new EventHandler(Click_ChangePassword);
            panelChangepassword.Click += new EventHandler(Click_ChangePassword);
        }
        void initLabel()
        {
            UserModel user = getUser(this.id);
            txtName.Text = user.FullName;
            lblFullname.Text = user.FullName;
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            getTopic();
        }
        public UserModel getUser(int id)
        {
            UserModel userModel = new UserModel();
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE user_id = @ma",con);
            cmd.Parameters.AddWithValue("@ma",this.id);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                userModel.Id_user = int.Parse(reader["user_id"].ToString());
                userModel.FullName = reader["full_name"].ToString();
                userModel.Username = reader["username"].ToString();
                userModel.Password = reader["password"].ToString();
                userModel.Role = reader["role"].ToString();
                userModel.Email = reader["email"].ToString();
                if (reader["created_at"] != DBNull.Value)
                {
                    userModel.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
                }
                else
                {
                    userModel.CreatedAt = DateTime.Now;
                }
            }
            if (reader != null)
            {
                reader.Close();
            }
            con.Close();
            return userModel;
        }
        public void getTopic()
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT categories FROM questions where status = 1", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbxTopic.Items.Add(reader["categories"].ToString());
            }
            cbxTopic.Items.Add("Combine");
            if (reader != null)
            {
                reader.Close();
            }
            con.Close();
        }
        private void Control_MouseHover(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.ForeColor = Color.Blue;
            }
            if (sender is Panel panel)
            {
                foreach (Control contro in panel.Controls)
                {
                    contro.ForeColor = Color.Blue;
                }
            }
        }
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.BackColor = Color.Transparent;
                foreach (Control contro in panel.Controls)
                {
                    contro.ForeColor = Color.FromArgb(88, 88, 88);
                }
            }
            if (sender is Control control)
            {
                control.ForeColor = Color.FromArgb(88,88,88);   
            }
            
        }
        public void Click_ManagerExam(object sender, EventArgs e)
        {
            Quanlybaikiemtra f = new Quanlybaikiemtra(id);
            f.Show();
            this.Hide();
        }
        public void Click_DoAnExam(object sender, EventArgs e)
        {
            panelVienExam.Visible = true;
            panelPushDoAnExam.Visible = true;
            panelPushProfile.Visible = false;
            panelVienProfile.Visible = false;
            panelVienChangePassword.Visible = false;
            panelPushChangePassword.Visible = false;
        }
        public void Click_ChangePassword(object sender, EventArgs e)
        {
            panelVienChangePassword.Visible = true;
            panelPushChangePassword.Visible = true;
            panelPushProfile.Visible = false;
            panelVienProfile.Visible = false;
            panelPushDoAnExam.Visible = false;
            panelVienExam.Visible = false;
        }
        public void Click_MyProfile(object sender, EventArgs e)
        {
            panelVienExam.Visible = false;
            panelPushProfile.Visible = true;
            panelPushDoAnExam.Visible = false;
            panelVienProfile.Visible = true;
            panelVienChangePassword.Visible = false;
            panelPushChangePassword.Visible = false;
        }
        public void Click_Logout(object sender, EventArgs e)
        {
            dangnhap f = new dangnhap();
            f.ShowDialog();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtUsername.Enabled = true;
            txtEmail.Enabled = true;
            txtName.Focus();
        }
       
        public List<AnswerQuestionUserModel> getAllQuestion(string levels,string topic ,int numberquestion)
        {
            
            Connect.OpenConnection();
            SqlCommand cmd;
            int n = (int)Math.Ceiling((decimal)numberquestion / 3);
            
            int n1 = n;
            int n2 = n;
            int n3 = numberquestion - n*2;
            if (topic.Trim().Equals("Combine"))
            {
                if (levels.Trim().Equals("Combine"))
                {
                    cmd = new SqlCommand($@"SELECT * FROM (SELECT TOP {n1} * FROM questions WHERE levels = 'Easy'  AND status = 1  ORDER BY NEWID() ) AS EasyQuestions UNION ALL SELECT * FROM (SELECT TOP {n2} * FROM questions    WHERE levels = 'Medium'   AND status = 1    ORDER BY NEWID() ) AS MediumQuestions UNION ALL SELECT * FROM (   SELECT TOP {n3} * FROM questions      WHERE levels = 'Hard'   AND status = 1     ORDER BY NEWID() ) AS HardQuestions;", con);
                    
                }
                else
                {
                    cmd = new SqlCommand($"SELECT TOP {numberquestion} * FROM questions WHERE levels = @lv  AND status = 1   ORDER BY NEWID()", con);
                    cmd.Parameters.AddWithValue("@lv", levels);
                }

            }
            else
            {
                if (levels.Trim().Equals("Combine"))
                {

                    cmd = new SqlCommand($@"SELECT * FROM (SELECT TOP {n1} * FROM questions WHERE levels = 'Easy' AND categories = @topic AND status = 1  ORDER BY NEWID()) AS EasyQuestions UNION ALL  SELECT * FROM (SELECT TOP {n2} * FROM questions    WHERE levels = 'Medium'  AND categories = @topic  AND status = 1  ORDER BY NEWID() ) AS MediumQuestions UNION ALL SELECT * FROM (    SELECT TOP {n3} * FROM questions    WHERE levels = 'Hard'  AND categories = @topic  AND status = 1    ORDER BY NEWID() ) AS HardQuestions;", con);
                    cmd.Parameters.AddWithValue("@topic", topic);
                }
                else { 
                    cmd = new SqlCommand($"SELECT TOP {numberquestion} * FROM questions WHERE levels = @lv AND categories = @topic  AND status = 1  ORDER BY NEWID()", con);
                    cmd.Parameters.AddWithValue("@topic", topic);
                    cmd.Parameters.AddWithValue("@lv", levels);
                }
            }
            List<AnswerQuestionUserModel> list = new List<AnswerQuestionUserModel>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AnswerQuestionUserModel tmp = new AnswerQuestionUserModel();
                tmp.QuestionId = int.Parse( reader["question_id"].ToString());
                tmp.QuestionContent = reader["contents"].ToString();
                tmp.levels = reader["levels"].ToString();
                tmp.categories = reader["categories"].ToString();
                list.Add(tmp);
            }
            if (reader != null)
            {
                reader.Close();
            }
            Connect.CloseConnection();
            return list;
        }                                
        
        public List<AnswerQuestionUserModel> getQuestionAndAnswer(string levels, string topic, int numberquestion)
        {
            Connect.OpenConnection();
            List<AnswerQuestionUserModel> questions = new List<AnswerQuestionUserModel>();

            List<AnswerQuestionUserModel> listtmp = getAllQuestion(levels,topic,numberquestion);
            if(listtmp.Count > 0)
            {
                foreach (var item in listtmp)
                {
                    AnswerQuestionUserModel tmp = new AnswerQuestionUserModel();
                    tmp.QuestionId = item.QuestionId;
                    tmp.QuestionContent = item.QuestionContent;
                    tmp.UserId = this.id;
                    Connect.OpenConnection();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM answers WHERE question_id = @id ORDER BY NEWID()",con);
                    sqlCommand.Parameters.AddWithValue("@id", tmp.QuestionId);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        tmp.Answers.Add(reader["contents"].ToString()); 
                        if((bool)reader["is_correct"])
                        {
                            tmp.AnswerCorrect = reader["contents"].ToString();
                        }
                    }
                    tmp.AnswerUserSelected = "";
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    questions.Add(tmp);
                   
                }
                con.Close();
            }
            return questions;
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            
            List<AnswerQuestionUserModel> listAnswer = new List<AnswerQuestionUserModel>();
            if (cbLever.SelectedIndex != -1 && cbxTopic.SelectedIndex != -1 && cbxQuestionNumber.SelectedIndex != -1)
            {
                listAnswer = getQuestionAndAnswer(cbLever.SelectedItem.ToString(), cbxTopic.SelectedItem.ToString(), int.Parse(cbxQuestionNumber.SelectedItem.ToString()));
                
                if (listAnswer.Count < int.Parse(cbxQuestionNumber.Text))
                {
                    MessageBox.Show("The number of questions is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    listAnswer[0].UserId = this.id;
                    lambaithi f = new lambaithi(listAnswer);
                    f.ShowDialog();
                    this.Hide();
                }
            }
            else MessageBox.Show("Please select complete information!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void panelPushDoAnExam_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSaveUser.Visible = true;
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            UserModel us = getUser(id);
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please do not leave information blank!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                us.FullName = txtName.Text;
                us.Username = txtUsername.Text;
                us.Email = txtEmail.Text;
                int res = UserModel.updateUser(us);
                if (res > 0)
                    MessageBox.Show("Save successfull!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Save failer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initLabel();
            }
            
        }
        public string getPasswordById(int id)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT password FROM users WHERE user_id = @id", con);
            cmd.Parameters.AddWithValue("@id",id);
            return cmd.ExecuteScalar().ToString();
        }
        public int updatePassword(string pw)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("UPDATE users SET password = @pw WHERE user_id = @id", con);
            cmd.Parameters.AddWithValue("@pw", pw);
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            return res;
        }
        public bool checkOldPassword(string pw)
        {
            return pw.Equals(getPasswordById(this.id));
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldpassword = txtOldPassword.Text;
            string newpassword1 = txtNewPassword1.Text;
            string newpassword2 = txtNewPassword2.Text;
            if (string.IsNullOrWhiteSpace(oldpassword) || string.IsNullOrWhiteSpace(newpassword1) || string.IsNullOrWhiteSpace(newpassword2))
            {
                MessageBox.Show("Please do not leave information blank!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!checkOldPassword(oldpassword))
                {
                    MessageBox.Show("The old password is incorrect!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (newpassword1.Equals(newpassword2))
                    {
                        int res = updatePassword(newpassword1);
                        MessageBox.Show(
                            res > 0 ? "Password changed successfully!" : "Password change failed!",
                            "Information",
                            MessageBoxButtons.OK,
                            res > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                        );
                    }
                    else
                        MessageBox.Show("Password does not match!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
