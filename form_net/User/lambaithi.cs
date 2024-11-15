using form_net.Connection;
using form_net.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using form_net.Model;

namespace form_net.User
{
    public partial class lambaithi : Form
    {
        int user_Id;
        SqlConnection con = Connect.getSqlConnection();
        DateTime startTime = DateTime.Now;
        DateTime future = DateTime.Now.AddMinutes(40);
        int size,cols,rows;
        int selectedRow = 0;
        int selectedCol = 0;
        int[][] index_question; 
        bool[][] status; 
        bool[][] flag; 
        public ResultModel resultModel = new ResultModel();
        public List<AnswerQuestionUserModel> Answers { get; set; }
        public lambaithi()
        {
            
            InitializeComponent();
            timer1.Start();
            innitArray();
            setLayoutTable();
            innitLabel();
            innitRadioButon();
            size = 0;
            user_Id = 0;
        }
        public lambaithi(List<AnswerQuestionUserModel> Answers)
        {
            InitializeComponent();
            this.Answers = Answers;
            timer1.Start();
            innitArray();
            setLayoutTable();
            innitLabel();
            innitRadioButon();
            user_Id = Answers[0].UserId;
        }
        void innitButton()
        {

            if (selectedRow == 0 && selectedCol == 0)
            {
                btnTruoc.Visible = false;
            }

            else btnTruoc.Visible = true; 
            int cau = index_question[selectedRow][selectedCol];
            if (cau == size-1)
            {
                btnSau.Visible = false;
                btnNopBai.Visible = true;
            }
            else {
                btnSau.Visible = true;
                btnNopBai.Visible = false;
            }
        }
        void innitArray()
        {
            size = Answers.Count;
            cols = 3;
            rows = (int)Math.Ceiling((decimal)(size/cols)) + 1;
            index_question = new int[rows][];
            status = new bool[rows][];
            flag = new bool[rows][];
            for (int i = 0; i < rows; i++)
            {
                index_question[i] = new int[cols];
                status[i] = new bool[cols];
                flag[i] = new bool[cols];
            }
        }
        void setLayoutTable()
        {
            tableLayoutPanel1.Height = rows * 100 + (rows * 3);
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnCount = cols;
            tableLayoutPanel1.RowCount = rows;
            int number = 0;
            
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (number < size)
                        {
                        
                            Label label = new Label();
                            if (number < size)
                            {
                                label.Text = "Câu " + (number+1) + " : ";
                            }
                            else label.Text = "";
                            label.BackColor = Color.White;
                            label.Margin = new Padding(3);
                            label.TextAlign = ContentAlignment.MiddleLeft;
                            label.Size = new Size(107, 30);
                            label.Click += Label_Click;
                            tableLayoutPanel1.Controls.Add(label, j, i);
                            index_question[i][j] = number;
                            flag[i][j] = false;
                            status[i][j] = false;
                            number++;
                        }       
                    }
                }
        }
        private void cbxDatco_CheckStateChanged(object sender, EventArgs e)
        {
            if (selectedRow >= 0 && selectedCol >= 0)
            {
                Label label = (Label)tableLayoutPanel1.GetControlFromPosition(selectedCol, selectedRow);
                if (label != null)
                {
                    if (cbxDatco.Checked)
                    {
                        flag[selectedRow][selectedCol] = cbxDatco.Checked;
                        label.Image = System.Drawing.Image.FromFile("C:\\Users\\NGUYEN VINH QUANG\\OneDrive\\Hình ảnh\\icon\\Flag-red-icon.png");
                        label.ImageAlign = ContentAlignment.MiddleRight;
                       
                    }
                    else
                    {
                        label.Image = null;
                        flag[selectedRow][selectedCol] = !cbxDatco.Checked;
                    }
                }
            }
        }

        void setRowCol(int cauhoi)
        {
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (index_question[i][j] == cauhoi)
                    {
                        selectedCol = j;
                        selectedRow = i;
                        return;
                    }
                }
            }
        }
        private void btnTruoc_Click(object sender, EventArgs e)
        {
            int number = index_question[selectedRow][selectedCol];
            int pre = number - 1;
            setRowCol(pre);
            Label clickedLabel = (Label)tableLayoutPanel1.GetControlFromPosition(selectedCol, selectedRow);
            selectitem(clickedLabel);
        }
        public string getAnswerUserSelect(List<string> answer,string userSelected)
        {
            int idx = answer.IndexOf(userSelected);
            if (idx == 0)
                return "A";
            else if (idx == 1)
                return "B";
            else if (idx == 2)
                return "C";
            else if(idx == 3)
                return "D";
            else return "";
        }
        void checkedRadio(List<string> answer, string userselected)
        {
            string res = getAnswerUserSelect(answer,userselected);
            if (res.Equals(""))
                radA.Checked = radB.Checked = radC.Checked = radD.Checked = false;
            else if (res.Equals("A"))
            {
                radA.Checked = true;
                radB.Checked = radC.Checked = radD.Checked = false;
            }
            else if(res.Equals("B"))
            {
                radB.Checked = true;
                radA.Checked = radC.Checked = radD.Checked = false;
            }
            else if (res.Equals("C"))
            {
                radC.Checked = true;
                radA.Checked = radB.Checked = radD.Checked = false;
            }
            else
            {
                radD.Checked = true;
                radA.Checked = radB.Checked = radC.Checked = false;
            }
        }
        void innitLabelAndRadioBtn(AnswerQuestionUserModel answer)
        {   
            if(answer == null) return;
            lblCauSo.Text = "Question " + (index_question[selectedRow][selectedCol] + 1) + " : "; 
            lblCauHoi.Text = answer.QuestionContent;
            if (answer.Answers.Count > 3)
            {
                lblCauA.Text = answer.Answers[0];
                lblCauB.Text = answer.Answers[1];
                lblCauC.Text = answer.Answers[2];
                lblCauD.Text = answer.Answers[3];
            }
        }
        void load()
        {
            radA.Checked = radB.Checked = radC.Checked = radD.Checked = false;
            int n = index_question[selectedRow][selectedCol];
            AnswerQuestionUserModel answer = Answers[n];
            innitLabelAndRadioBtn(answer);
            checkedRadio(answer.Answers,answer.AnswerUserSelected);
            lblTrangThai.Text = status[selectedRow][selectedCol] ? "Answered" : "Not Answer";
            cbxDatco.Checked = flag[selectedRow][selectedCol];
            Label lbl = (Label)tableLayoutPanel1.GetControlFromPosition(selectedCol, selectedRow);
            lbl.Text = "Câu " + (n+1) + " : " + getAnswerUserSelect(answer.Answers,answer.AnswerUserSelected);
        }
        void selectitem(Label clickedLabel)
        {
            
            if (clickedLabel != null)
            {
                
                selectedRow = tableLayoutPanel1.GetRow(clickedLabel); 
                selectedCol = tableLayoutPanel1.GetColumn(clickedLabel);
                load();
                innitButton();
                clickedLabel.BackColor = Color.FromArgb(181, 222, 143);
                foreach (Label x in tableLayoutPanel1.Controls)
                {
                    if (x != clickedLabel)
                    {
                        x.BackColor = Color.White;
                    }
                }
                
            }
        }
        private void ClickLabel(object sender, EventArgs e)
        { 
            Label label = (Label)sender;
            if (label == lblCauA)
                radA.Checked = true;
            else if (label == lblCauB)
                radB.Checked = true;
            else if (label == lblCauC)
                radC.Checked = true;
            else radD.Checked = true;

        }
            void innitLabel()
        {
            Label clickedLabel = (Label)tableLayoutPanel1.GetControlFromPosition(selectedCol, selectedRow);
            selectitem(clickedLabel);
            lblCauA.Click += ClickLabel;
            lblCauB.Click += ClickLabel;
            lblCauC.Click += ClickLabel;
            lblCauD.Click += ClickLabel;
        }
        private void btnSau_Click(object sender, EventArgs e)
        {
            int number = index_question[selectedRow][selectedCol];
            int next = number + 1;
            setRowCol(next);
            innitLabel();
        }
        void innitRadioButon()
        {
            radA.CheckedChanged += CheckedChanged;
            radB.CheckedChanged += CheckedChanged;
            radC.CheckedChanged += CheckedChanged;
            radD.CheckedChanged += CheckedChanged;

        }
        Label getLabelReslut(RadioButton radio)
        {
            if (radio.Text.Equals("A"))
                return lblCauA;
            else if (radio.Text.Equals("B"))
                return lblCauB;
            else if (radio.Text.Equals("C"))
                return lblCauC;
            else if (radio.Text.Equals("D"))
                return lblCauD;
            return null;
        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            int n = index_question[selectedRow][selectedCol];
            AnswerQuestionUserModel tmp = Answers[n];
            RadioButton rb =  sender as RadioButton;
            Label reslut = (Label)getLabelReslut(rb);
            if (rb.Checked)
            {
                tmp.AnswerUserSelected = reslut.Text;
                status[selectedRow][selectedCol] = true;
                Label lbl = (Label)tableLayoutPanel1.GetControlFromPosition(selectedCol, selectedRow);
                lblTrangThai.Text = status[selectedRow][selectedCol] ? "Answered" : "Not Answer";
                status[selectedRow][selectedCol] = true;
                if (lbl != null)
                {
                    lbl.Text = "Câu " + (n + 1) + " : " + getAnswerUserSelect(tmp.Answers, tmp.AnswerUserSelected);
                }
            }
            
        }
        bool checkSelectAll()
        {
            foreach (var item in Answers)
            {
                if (string.IsNullOrEmpty(item.AnswerUserSelected))
                {
                    return false;
                }
            }
            return true;
        }
        public int socaudung()
        {
            int cnt = 0;
            foreach (var item in Answers)
            {
                if (item != null)
                {
                    if (item.AnswerCorrect != null && item.AnswerUserSelected != null)
                    {
                        if (item.AnswerCorrect.Equals(item.AnswerUserSelected))
                        {
                            cnt++;
                        }
                    }
                }
            }
             return cnt;
        }
        public float score()
        {
            return ((float)socaudung())/ size * 10;
        }
        public int getTestIdByUserIdAndStartTime()
        {
            SqlCommand cmd = new SqlCommand("SELECT test_id FROM tests WHERE user_id = @userid AND start_time = @time", con);
            cmd.Parameters.AddWithValue("userid", user_Id);
            cmd.Parameters.AddWithValue("time", startTime);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
        public int getAnswerIdByContent(AnswerQuestionUserModel a)
        {
            SqlCommand cmd = new SqlCommand("SELECT answer_id FROM answers WHERE contents = @content ", con);
            cmd.Parameters.AddWithValue("content",a.AnswerUserSelected);
            if(cmd.ExecuteScalar() != null)
                return int.Parse(cmd.ExecuteScalar().ToString());
            return -1;
        }
        public void addBaiLenCSDL()
        {

            DateTime endtime = DateTime.Now;
            Connect.OpenConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO tests VALUES(@userid,@score,@starttime,@endtime)", con);
            cmd.Parameters.AddWithValue("@userid", user_Id);
            cmd.Parameters.AddWithValue("@score", String.Format("{0:F1}", score()));
            cmd.Parameters.AddWithValue("@starttime", startTime);
            cmd.Parameters.AddWithValue("@endtime", endtime);
            cmd.ExecuteNonQuery();
            foreach (var item in Answers)
            {
                int testId = getTestIdByUserIdAndStartTime();
                SqlCommand cmd1 = new SqlCommand("INSERT INTO test_questions VALUES(@testId,@questionId)", con);
                cmd1.Parameters.AddWithValue("@testId", testId);
                cmd1.Parameters.AddWithValue("@questionId", item.QuestionId);
                cmd1.ExecuteNonQuery();
                int answerId = getAnswerIdByContent(item);
                if (answerId != -1)
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO user_answers VALUES(@testId,@questionId,@answerId)", con);
                    cmd2.Parameters.AddWithValue("@testId", testId);
                    cmd2.Parameters.AddWithValue("@questionId", item.QuestionId);
                    cmd2.Parameters.AddWithValue("@answerId", answerId);
                    cmd2.ExecuteNonQuery();
                }
            }
            TimeSpan remainingTime = endtime - startTime;
            resultModel.time = string.Format("{0:D2}:{1:D2}:{2:D2}",
                remainingTime.Hours,
                remainingTime.Minutes,
                remainingTime.Seconds);
            resultModel.soCauDung = socaudung();
            resultModel.score = score();
        }
        private void btnNopBai_Click(object sender, EventArgs e)
        {
            if (checkSelectAll())
            {
                DialogResult result = MessageBox.Show("Are you sure you want to submit your assignment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    addBaiLenCSDL();
                    Ketquabaithi f = new Ketquabaithi(Answers, resultModel);
                    MessageBox.Show("Submitted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.Show();
                    this.Hide();
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("There are still unanswered questions, do you still want to submit them??", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    addBaiLenCSDL();
                    Ketquabaithi f = new Ketquabaithi(Answers, resultModel);
                    MessageBox.Show("Submitted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.Show();
                    this.Hide();

                }
            }
            
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            selectitem(clickedLabel);

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan remainingTime = future - currentDate;

            if (remainingTime.TotalSeconds <= 0)
            {
                time.Text = "00:00:00";
                timer1.Stop();
                addBaiLenCSDL();
                Ketquabaithi f = new Ketquabaithi(Answers, resultModel);
                MessageBox.Show("Time's up, the exam has been submitted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                f.Show();
                this.Hide();
            }
            else
            {
                time.Text = string.Format("Time remaining:{0:D2}:{1:D2}:{2:D2}",
                    remainingTime.Hours,
                    remainingTime.Minutes,
                    remainingTime.Seconds);

            }
        }
    }
}
