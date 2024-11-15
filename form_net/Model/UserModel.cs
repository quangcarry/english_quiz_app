using form_net.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace form_net.Model
{
    public class UserModel
    {
        public int Id_user { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        static SqlConnection con = Connect.getSqlConnection();
        public static List<UserModel> getAllUser(string where)
        {
            List<UserModel> list = new List<UserModel>();
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users " + where, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserModel tmp = new UserModel();
                tmp.Id_user = int.Parse(reader["user_id"].ToString());
                tmp.FullName = reader["full_name"].ToString();
                tmp.Username = reader["username"].ToString();
                tmp.Password = reader["password"].ToString();
                tmp.Role = reader["role"].ToString();
                tmp.Email = reader["email"].ToString();
                tmp.CreatedAt = reader["created_at"] != DBNull.Value ? DateTime.Parse(reader["created_at"].ToString()) : DateTime.MinValue;
                list.Add(tmp);
            }
            if (reader != null)
                reader.Close();
            return list;
        }


        public static int insertUser(UserModel model)
        {
            Connect.OpenConnection();
            int res = 0;
            SqlCommand cmd = new SqlCommand("INSERT INTO users VALUES(@username,@password,@email,@fullname,@role,@creatat)", con);
            cmd.Parameters.AddWithValue("@fullname", model.FullName);
            cmd.Parameters.AddWithValue("@username", model.Username);
            cmd.Parameters.AddWithValue("@password", model.Password);
            cmd.Parameters.AddWithValue("@role", model.Role.ToLower());
            cmd.Parameters.AddWithValue("@email", model.Email);
            cmd.Parameters.AddWithValue("@creatat", model.CreatedAt);
            List<UserModel> list = getAllUser("where username = '" + model.Username + "'");
            if (list.Count == 0)
                res = cmd.ExecuteNonQuery();
            else
                MessageBox.Show("Username is already in use!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return res;

        }
        public static int deleteUser(int id)
        {
            int result = 0;
            Connect.OpenConnection();
                
            SqlCommand testQuestions = new SqlCommand("DELETE FROM test_questions WHERE test_id IN (SELECT test_id FROM tests WHERE user_id = @id)", con);
            SqlCommand userAnswers = new SqlCommand("DELETE FROM user_answers WHERE test_id IN (SELECT test_id FROM tests WHERE user_id = @id)", con);
            SqlCommand tests = new SqlCommand("DELETE FROM tests WHERE user_id = @id", con);
            SqlCommand users = new SqlCommand("DELETE FROM users WHERE user_id = @id", con);
            SqlCommand answers = new SqlCommand("DELETE FROM answers WHERE question_id IN (SELECT question_id FROM questions WHERE status = 0)", con);
            SqlCommand questions = new SqlCommand("DELETE FROM questions WHERE status = 0", con); 

            testQuestions.Parameters.AddWithValue("@id", id);
            userAnswers.Parameters.AddWithValue("@id", id);
            tests.Parameters.AddWithValue("@id", id);
            users.Parameters.AddWithValue("@id", id);

            DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                testQuestions.ExecuteNonQuery();
                userAnswers.ExecuteNonQuery();
                tests.ExecuteNonQuery();
                result = users.ExecuteNonQuery();
                try
                { 
                    if(answers.ExecuteNonQuery() > 0)
                        questions.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
                
            
        
            return result;
        }
        
        public static int updateUser(UserModel model)
        {
            Connect.OpenConnection();
            int res = 0;
            SqlCommand cmd = new SqlCommand("UPDATE users SET full_name = @fullname ,username = @username,password = @password,role = @role,email = @email, created_at = @createat WHERE user_id = @id", con);
            cmd.Parameters.AddWithValue("@id", model.Id_user);
            cmd.Parameters.AddWithValue("@fullname", model.FullName);
            cmd.Parameters.AddWithValue("@username", model.Username);
            cmd.Parameters.AddWithValue("@password", model.Password);
            cmd.Parameters.AddWithValue("@role", model.Role);
            cmd.Parameters.AddWithValue("@email", model.Email);
            cmd.Parameters.AddWithValue("@createat", model.CreatedAt);
            List<UserModel> list = getAllUser("where username = '" + model.Username + "' AND user_id != " + model.Id_user );
            if (list.Count == 0)
                res = cmd.ExecuteNonQuery();
            else
                MessageBox.Show("Username is already in use!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            return res;
        }
    }
    
}
