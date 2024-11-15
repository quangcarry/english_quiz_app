using form_net.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form_net.Model
{
    public class TestsModel
    {
        public int testId {  get; set; }
        public int userId {  get; set; }
        public float score { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public string topic { get; set; }
        public string levels { get; set; }
        public int socauhoi {  get; set; }

        static SqlConnection con = Connect.getSqlConnection();
        public static int count(int testid,string s)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM ( SELECT {s} FROM questions WHERE question_id IN (SELECT question_id FROM test_questions WHERE test_id = @id) GROUP BY {s} ) as restult",con);
            cmd.Parameters.AddWithValue("@id", testid);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
        public static string getTopicOrLevels(int testid, string s)
        {
            if (count(testid, s) == 1)
            {
                SqlCommand cmd = new SqlCommand($"SELECT distinct {s} FROM questions WHERE question_id IN (SELECT question_id FROM test_questions WHERE test_id = @id)", con);
                cmd.Parameters.AddWithValue("@id", testid);
                return cmd.ExecuteScalar().ToString();
            }
            else return "Combine";

        }
        public static int getNumberQuestionById(int testid)
        {
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(question_id) FROM test_questions WHERE test_id = @id",con);
            cmd.Parameters.AddWithValue("@id",testid);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
        public static List<TestsModel> getAllTestByUserId(int id)
        {
            List<TestsModel> list = new List<TestsModel>();
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tests WHERE user_id = @id",con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader  reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TestsModel model = new TestsModel();
                int testId = Convert.ToInt32(reader["test_id"]);
                model.testId = testId;
                model.userId = Convert.ToInt32(reader["user_id"]);
                model.score = float.Parse(reader["score"].ToString());
                model.startTime = DateTime.Parse(reader["start_time"].ToString());
                model.endTime = DateTime.Parse(reader["end_time"].ToString()) ;
                model.levels = getTopicOrLevels(Convert.ToInt32(reader["test_id"]), "levels");
                model.topic = getTopicOrLevels(testId, "categories");
                model.socauhoi = getNumberQuestionById(testId);
                list.Add(model);
            }
            if(reader != null) 
                reader.Close();
            return list;
        }
    }
}
