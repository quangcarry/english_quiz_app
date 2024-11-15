using form_net.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace form_net.Model
{
    public class AnswerQuestionUserModel
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string levels { get; set; }
        public string categories { get; set; }
        public string QuestionContent { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
        public string AnswerUserSelected { get; set; }
        public string AnswerCorrect { get; set; }
        public DateTime created_at { get; set; }

        static SqlConnection con = Connect.getSqlConnection();

        public static int getIdTestByStartTime(int userId, List<int> time)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT test_id FROM tests WHERE user_id = @userId and Day(start_time) = @day and MONTH(start_time) = @month and YEAR(start_time) = @year and DATEPART(HOUR, start_time) = @hour and DATEPART(MINUTE, start_time) = @minute", con);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@day", time[0]);
            cmd.Parameters.AddWithValue("@month", time[1]);
            cmd.Parameters.AddWithValue("@year", time[2]);
            cmd.Parameters.AddWithValue("@hour", time[3]);
            cmd.Parameters.AddWithValue("@minute", time[4]);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                return int.Parse(result.ToString());
            }
            return -1;
        }
        public  AnswerQuestionUserModel Clone()
        {
            return new AnswerQuestionUserModel
            {
                QuestionContent = this.QuestionContent,
                Answers = new List<string>(this.Answers),
                AnswerCorrect = this.AnswerCorrect
            };
        }
        public static List<int> getlistQuestionIdByTestId(int testId)
        {
            Connect.OpenConnection();
            List<int> list = new List<int>();
            SqlCommand cmd = new SqlCommand("SELECT question_id FROM test_questions WHERE test_id = @id ", con);
            cmd.Parameters.AddWithValue("@id", testId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(int.Parse(reader["question_id"].ToString()));
            }
            if (reader != null)
                reader.Close();
            return list;
        }
        public static string getConetentById(int id)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT contents FROM questions WHERE question_id = @id ", con);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteScalar().ToString();
        }
        public static List<string[]> getAnswerByIdQuestion(int id)
        {
            Connect.OpenConnection();
            List<string[]> list = new List<string[]>();
            SqlCommand cmd = new SqlCommand("SELECT contents,is_correct FROM answers WHERE question_id = @id ", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new[] { reader["contents"].ToString(), reader["is_correct"].ToString() });
            }
            if (reader != null)
                reader.Close();
            return list;
        }
        public static int getAnswerIdByTestIdAndQuestionId(int testId, int questionId)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT answer_id FROM user_answers WHERE test_id = @testId AND question_id = @questionId", con);
            cmd.Parameters.AddWithValue("@testId", testId);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            if (cmd.ExecuteScalar() != null)
                return int.Parse(cmd.ExecuteScalar().ToString());
            return -1;
        }
        public static string getContentAnswerUserByIdAnswer(int id)
        {
            if (id == -1)
                return "";
            SqlCommand cmd = new SqlCommand("SELECT contents FROM answers WHERE answer_id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteScalar().ToString();
        }
        public static List<AnswerQuestionUserModel> getAllQuestionByUserIdAndStartTime(int userId, List<int> time)
        {
            List<AnswerQuestionUserModel> list = new List<AnswerQuestionUserModel>();
            int testId = getIdTestByStartTime(userId, time);
            List<int> listIdQuestion = getlistQuestionIdByTestId(testId);

            if (testId > 0)
            {
                foreach (var i in listIdQuestion)
                {
                    AnswerQuestionUserModel tmp = new AnswerQuestionUserModel();
                    tmp.UserId = userId;
                    tmp.QuestionId = i;
                    tmp.QuestionContent = getConetentById(i);
                    tmp.Answers = new List<string>();
                    List<string[]> strings = getAnswerByIdQuestion(i);
                    foreach (var s in strings)
                    {
                        tmp.Answers.Add(s[0]);
                        if (s[1].Equals("True"))
                        {
                            tmp.AnswerCorrect = s[0];
                        }
                    }
                    int idAnswer = getAnswerIdByTestIdAndQuestionId(testId, i);
                    tmp.AnswerUserSelected = getContentAnswerUserByIdAnswer(idAnswer);
                    list.Add(tmp);
                }
            }
            return list;
        }

        public static List<AnswerQuestionUserModel> getAllQuestionAndAnswer(string where)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM questions " + where, con);
            List<AnswerQuestionUserModel> list = new List<AnswerQuestionUserModel>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AnswerQuestionUserModel tmp = new AnswerQuestionUserModel();
                int questionId = int.Parse(reader["question_id"].ToString());
                tmp.QuestionId = questionId;
                tmp.QuestionContent = reader["contents"].ToString();
                tmp.categories = reader["categories"].ToString();
                tmp.levels = reader["levels"].ToString();
                List<string[]> answer = getAnswerByIdQuestion(questionId);
                foreach (string[] s in answer)
                {
                    tmp.Answers.Add(s[0]);
                    if (s[1].Equals("True"))
                        tmp.AnswerCorrect = s[0];
                }
                list.Add(tmp);
            }
            return list;
        }
        public static List<AnswerQuestionUserModel> getQuestionToString(string str)
        {
            List<AnswerQuestionUserModel> list = new List<AnswerQuestionUserModel>();
            try
            {
                if (!str.Equals(""))
                {
                    string[] lines = str.Trim().Split('\n');
                    foreach (string line in lines)
                    {
                        if (!line.Trim().Equals(""))
                        {

                            string[] a = line.Split(';');
                            if (a.Length > 0 && a.Length < 9)
                            {
                                AnswerQuestionUserModel tmp = new AnswerQuestionUserModel();
                                tmp.QuestionContent = a[0];
                                tmp.levels = a[1].Trim();
                                tmp.categories = a[2].Trim();
                                tmp.Answers = new List<string>();
                                tmp.Answers.Add(a[3].Trim());
                                tmp.Answers.Add(a[4].Trim());
                                tmp.Answers.Add(a[5].Trim());
                                tmp.Answers.Add(a[6].Trim());
                                tmp.AnswerCorrect = a[7].Trim();
                                list.Add(tmp);
                            }
                            else System.Windows.Forms.MessageBox.Show("Add question failer because the file structure was not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    return list;
                }
            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Add question failer because the file structure was not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            return null;

        }
        public static int getIdByContent(string content)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT question_id FROM questions WHERE contents = @content", con);
            cmd.Parameters.AddWithValue("@content", content);
            int id = int.Parse(cmd.ExecuteScalar().ToString());
            if (id != null)
                return id;
            return -1;
        }
        public static bool iscorrec(string correct, string a)
        {
            return correct.Equals(a);
        }
        public static bool checkTrung(string s)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM questions WHERE contents = @content",con);
            cmd.Parameters.AddWithValue("@content", s);
            if (cmd.ExecuteNonQuery() == -1)
                return false; ;
            return true;
        }
        public static void addQuestionToQuestions(List<AnswerQuestionUserModel> questions)
        {
            if (questions == null) return;
            Connect.OpenConnection();
            string s = "";

            SqlCommand cmd = new SqlCommand("INSERT INTO questions VALUES(@conten,@level,@topic,@create,1)", con);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO answers VALUES(@questionId,@content,@iscorrect)", con);
            if (questions.Count > 0)
            {
                try
                {
                    foreach (var item in questions)
                    {
                        if (!checkTrung(item.QuestionContent))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@conten", item.QuestionContent);
                            cmd.Parameters.AddWithValue("@level", item.levels);
                            cmd.Parameters.AddWithValue("@topic", item.categories);
                            cmd.Parameters.AddWithValue("@create", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            int id = getIdByContent(item.QuestionContent);
                            foreach (string i in item.Answers)
                            {
                                cmd2.Parameters.Clear();
                                cmd2.Parameters.AddWithValue("@questionId", id);
                                cmd2.Parameters.AddWithValue("@content", i);
                                cmd2.Parameters.AddWithValue("@iscorrect", iscorrec(item.AnswerCorrect, i));
                                cmd2.ExecuteNonQuery();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        public static int deleteQuestion(AnswerQuestionUserModel model)
        {
            SqlCommand cmd = new SqlCommand("UPDATE questions SET contents = @content, status = 0 WHERE question_id = @id" , con);
            SqlCommand answers = new SqlCommand("DELETE FROM answers WHERE question_id IN (SELECT question_id FROM questions WHERE status = 0)", con);
            SqlCommand questions = new SqlCommand("DELETE questions WHERE status = 0 ", con);
            cmd.Parameters.AddWithValue("@content",model.QuestionContent);
            cmd.Parameters.AddWithValue("@topic", model.categories);
            cmd.Parameters.AddWithValue("@level", model.levels);
            cmd.Parameters.AddWithValue("@id", model.QuestionId);
            try
            {
                if(answers.ExecuteNonQuery() > 0)
                 questions.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
            }
            return cmd.ExecuteNonQuery();
            
        }
        public static bool contains(List<AnswerQuestionUserModel> list, AnswerQuestionUserModel x)
        {
            foreach (AnswerQuestionUserModel item in list)
            {
                {
                    if (item.QuestionContent.Equals(x.QuestionContent) && item.categories.Equals(x.categories) && item.levels.Equals(x.levels) &&
                       item.AnswerCorrect.Equals(x.AnswerCorrect) && item.Answers[0].Equals(x.Answers[0]) && item.Answers[1].Equals(x.Answers[1])&&
                       item.Answers[2].Equals(x.Answers[2]) && item.Answers[3].Equals(x.Answers[3]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
    
}
