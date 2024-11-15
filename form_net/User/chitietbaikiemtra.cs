using form_net.Admin;
using form_net.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_net.User
{
    public partial class chitietbaikiemtra : Form
    {
        public List<AnswerQuestionUserModel> Answers { get; set; }
        public string parent;
        public chitietbaikiemtra()
        {
            InitializeComponent();
            load();
            setDatagrid();
        }
        
        public chitietbaikiemtra(List<AnswerQuestionUserModel> Answers,string parent)
        {
            InitializeComponent();
            this.Answers = Answers;
            this.parent = parent ;
            load();
            setDatagrid();
        }
        public void setDatagrid()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(109, 122, 224);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 10, 5, 10);
            dataGridView1.Paint += dataGridView1_Paint;
            
        }
        public string getAlphaAnswer(List<string> answers, string useranswer)
        {
            int idx = answers.IndexOf(useranswer);
            if (idx == -1)
                return "";
            else if (idx == 0)
                return "A";
            else if (idx == 1)
                return "B";
            else if (idx == 2)
                return "C";
            else return "D";
        }
        public bool iscorrect(string answercorrect, string useranswer)
        {
            if(answercorrect == null || useranswer == null) return false;
            if (answercorrect.Equals(useranswer))
                return true;
            return false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            if (Answers != null)
            { 
                dataGridView1.Rows.Clear();
                foreach (var item in Answers)
                {
                    if (item.QuestionContent.Contains(txtSearch.Text) && item.Answers.Count > 3)
                    {
                        int stt = Answers.IndexOf(item) + 1;
                            dataGridView1.Rows.Add(stt, item.QuestionContent, item.Answers[0], item.Answers[1], item.Answers[2], item.Answers[3], getAlphaAnswer(item.Answers, item.AnswerUserSelected), getAlphaAnswer(item.Answers, item.AnswerCorrect), iscorrect(item.AnswerCorrect, item.AnswerUserSelected));
                    }
                }
            }
        } 

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            int radius = 8;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(dataGridView1.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(dataGridView1.Width - radius, dataGridView1.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, dataGridView1.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            dataGridView1.Region = new Region(path);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int id = Answers[0].UserId;
            if(!parent.Equals("Menu"))
            {
                Quanlybaikiemtra f = new Quanlybaikiemtra(id);
                f.Show();
                this.Hide();
            }
            else
            { 
                menuUser f1 = new menuUser(id);
                f1.Show();
                this.Hide();
            }
          
        }

        
    }
}
