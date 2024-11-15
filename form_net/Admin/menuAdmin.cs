using form_net.Model;
using form_net.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace form_net.Admin
{
    public partial class menuAdmin : Form
    {
        public string id;
        List<AnswerQuestionUserModel> questions;
        List<AnswerQuestionUserModel> questionsAdd = new List<AnswerQuestionUserModel>();
        List<UserModel> users;
        public menuAdmin()
        {
            InitializeComponent();
            innit();
            loadPanelUser();
            loadPanelQuestion();
        }
        public menuAdmin(string id)
        {
            InitializeComponent();
            innit();
            this.id = id;
            loadPanelUser();
            loadPanelQuestion();
        }
        public void innit()
        {
            createGrid(dataGridViewQuestion);
            createGrid(dataGridViewUser);
            createGrid(dataGridViewAnswer);
            createGrid(dataGridViewAddQuestion);
            lblAnswers.Click += click_NavbarAnswer;
            lblUser.Click += click_NavbarUser;
            lblQuestion.Click += click_NavbarQuestion;
            lblLogout.Click += click_NavbarLogout;

        }
        public void createGrid(DataGridView dataGridView)
        {
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(109, 122, 224);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 10, 5, 10);
            dataGridView.RowTemplate.Height = 35;

        }
        private void click_NavbarUser(object sender, EventArgs e)
        {
            resetLabel();
            panelContentUser.Visible = true;
            lblUser.BackColor = Color.White;
            lblUser.ForeColor = Color.FromArgb(68, 81, 255);
        }
        private void click_NavbarAnswer(object sender, EventArgs e)
        {
            resetLabel();
            panelContentAnswer.Visible = true;
            lblAnswers.BackColor = Color.White;
            lblAnswers.ForeColor = Color.FromArgb(68, 81, 255);
        }
        private void click_NavbarQuestion(object sender, EventArgs e)
        {
            resetLabel();
            panelContentAddQuestion.Visible = true;
            lblQuestion.BackColor = Color.White;
            lblQuestion.ForeColor = Color.FromArgb(68, 81, 255);
        }
        private void click_NavbarLogout(object sender, EventArgs e)
        {
            lblLogout.ForeColor = Color.FromArgb(68, 81, 255);
            dangnhap f = new dangnhap();
            f.Show();
            this.Hide();
        }
        void resetLabel()
        {
            panelContentUser.Visible = false;
            panelContentAnswer.Visible = false;
            panelContentAddQuestion.Visible = false;
            lblUser.BackColor = Color.Transparent;
            lblUser.ForeColor = Color.FromArgb(224, 224, 224);
            lblAnswers.BackColor = Color.Transparent;
            lblAnswers.ForeColor = Color.FromArgb(224, 224, 224);
            lblQuestion.BackColor = Color.Transparent;
            lblQuestion.ForeColor = Color.FromArgb(224, 224, 224);
            lblLogout.BackColor = Color.Transparent;
            lblLogout.ForeColor = Color.FromArgb(224, 224, 224);
        }
        //panel User
        public bool checkInputUser(DataGridViewRow dataGridViewRow)
        {
            if (dataGridViewRow.Cells[1].Value == null ||
                string.IsNullOrWhiteSpace(dataGridViewRow.Cells[1].Value.ToString()) ||
                dataGridViewRow.Cells[2].Value == null ||
                string.IsNullOrWhiteSpace(dataGridViewRow.Cells[2].Value.ToString()) ||
                dataGridViewRow.Cells[3].Value == null ||
                string.IsNullOrWhiteSpace(dataGridViewRow.Cells[3].Value.ToString()) ||
                dataGridViewRow.Cells[4].Value == null ||
                string.IsNullOrWhiteSpace(dataGridViewRow.Cells[4].Value.ToString()))
            {
                MessageBox.Show("Please do not leave information blank!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dataGridViewRow.Cells[5].Value == null ||
                !dataGridViewRow.Cells[5].Value.ToString().ToLower().Trim().Equals("admin") &&
                !dataGridViewRow.Cells[5].Value.ToString().ToLower().Trim().Equals("user"))
            {
                MessageBox.Show("Please enter role as user or admin!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        void loadPanelUser()
        {
            users = UserModel.getAllUser("WHERE 1 = 1 ");
            dataGridViewUser.Rows.Clear();
            foreach (UserModel user in users)
            {
                int idx = users.IndexOf(user) + 1;
                dataGridViewUser.Rows.Add(idx, user.FullName, user.Username, user.Password, user.Email, user.Role, user.CreatedAt);
            }
        }
        int indexUserRowValueChange = -1;
        private void dataGridViewUser_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            indexUserRowValueChange = e.RowIndex;

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            int idx = dataGridViewUser.NewRowIndex - 1;
            if (idx > -1)
            {
                if (checkInputUser(dataGridViewUser.Rows[idx]))
                {
                    UserModel model = new UserModel();
                    model.FullName = dataGridViewUser.Rows[idx].Cells[1].Value.ToString();
                    model.Username = dataGridViewUser.Rows[idx].Cells[2].Value.ToString();
                    model.Password = dataGridViewUser.Rows[idx].Cells[3].Value.ToString();
                    model.Email = dataGridViewUser.Rows[idx].Cells[4].Value.ToString();
                    model.Role = dataGridViewUser.Rows[idx].Cells[5].Value.ToString();
                    DateTime date;
                    if (dataGridViewUser.Rows[idx].Cells[6].Value != null && DateTime.TryParse(dataGridViewUser.Rows[idx].Cells[6].Value.ToString(), out date))
                    {
                        model.CreatedAt = date;
                    }
                    else
                    {
                        model.CreatedAt = DateTime.Now;
                    }
                    int res = UserModel.insertUser(model);
                    if (res > 0)
                        MessageBox.Show("User added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadPanelUser();
                }
            }
        }
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUser.SelectedRows.Count > 0)
            {
                int idx = dataGridViewUser.SelectedRows[0].Index;
                int res = UserModel.deleteUser(users[idx].Id_user);
                if (res > 0)
                    MessageBox.Show("User deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadPanelUser();
            }
            else
            {
                MessageBox.Show("Please select the line to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (indexUserRowValueChange > -1 && indexUserRowValueChange < dataGridViewUser.RowCount)
            {
                var selectedRow = dataGridViewUser.Rows[indexUserRowValueChange];
                if (checkInputUser(selectedRow))
                {
                    int user_id = users[indexUserRowValueChange].Id_user;
                    UserModel model = new UserModel();
                    model.Id_user = user_id;
                    model.FullName = selectedRow.Cells[1].Value.ToString();
                    model.Username = selectedRow.Cells[2].Value.ToString();
                    model.Password = selectedRow.Cells[3].Value.ToString();
                    model.Email = selectedRow.Cells[4].Value.ToString();
                    model.Role = selectedRow.Cells[5].Value.ToString();
                    DateTime date;
                    if (selectedRow.Cells[6].Value != null && DateTime.TryParse(selectedRow.Cells[6].Value.ToString(), out date))
                    {
                        model.CreatedAt = date;
                    }
                    else
                    {
                        model.CreatedAt = DateTime.Now;
                    }
                    int res = UserModel.updateUser(model);
                    if (res > 0)
                        MessageBox.Show("User updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadPanelUser();
                }
            }
            else MessageBox.Show("No information has been edited yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void searchUser(string s)
        {
            string where = " WHERE username LIKE '%" + s + "%' OR full_name  LIKE '%" + s + "%' OR role LIKE '%" + s + "%' OR email LIKE '%" + s + "%'";
            users = UserModel.getAllUser(where);
            dataGridViewUser.Rows.Clear();
            foreach (UserModel user in users)
            {
                int idx = users.IndexOf(user) + 1;
                dataGridViewUser.Rows.Add(idx, user.FullName, user.Username, user.Password, user.Email, user.Role, user.CreatedAt);
            }
        }
        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            searchUser(txtSearchUser.Text);
        }
        // panel Question and Answer
        void loadPanelQuestion()
        {
            questions = AnswerQuestionUserModel.getAllQuestionAndAnswer(" WHERE status = 1 ");
            dataGridViewQuestion.Rows.Clear();
            foreach (var item in questions)
            {
                int idx = questions.IndexOf(item) + 1;
                dataGridViewQuestion.Rows.Add(idx, item.QuestionContent, item.categories, item.levels, item.created_at);
            }
        }
       
        private void dataGridViewQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            indexQuestionValueChange = e.RowIndex;
            if (row != -1)
            {
                AnswerQuestionUserModel tmp = questions[row];
                dataGridViewAnswer.Rows.Clear();
                foreach (string s in tmp.Answers)
                {
                    int idx = tmp.Answers.IndexOf(s) + 1;
                    dataGridViewAnswer.Rows.Add(idx, s, s.Equals(tmp.AnswerCorrect));
                }
            }
        }
        void searchQuestion(string s)
        {
            string where = " WHERE status = 1 AND (contents LIKE '%" + s + "%' OR categories  LIKE '%" + s + "%' OR levels  LIKE '%" + s + "%') ";
            questions = AnswerQuestionUserModel.getAllQuestionAndAnswer(where);
            dataGridViewQuestion.Rows.Clear();
            foreach (var item in questions)
            {
                int idx = questions.IndexOf(item) + 1;
                dataGridViewQuestion.Rows.Add(idx, item.QuestionContent, item.categories, item.levels, item.created_at);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchQuestion(txtSearchQuestion.Text);
        }
        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuestion.SelectedRows.Count > 0)
            {
                int idx = dataGridViewQuestion.SelectedRows[0].Index;
                DialogResult result = MessageBox.Show("Are you sure you want to delete??", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AnswerQuestionUserModel tmp = questions[idx];
                    tmp.QuestionContent = questions[idx].QuestionContent + "(*)";
                    int res = AnswerQuestionUserModel.deleteQuestion(tmp);
                    if (res > 0)
                        MessageBox.Show("Deleted successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("There is no information in the database!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadPanelQuestion();
                }
            }
            else MessageBox.Show("Please select the line to deletel!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public bool checkInPutQuestion(DataGridViewRow dataGridViewRow)
        {
            if (dataGridViewRow.Cells[1].Value == null ||
                string.IsNullOrWhiteSpace(dataGridViewRow.Cells[1].Value.ToString()) ||
                dataGridViewRow.Cells[2].Value == null ||
                string.IsNullOrWhiteSpace(dataGridViewRow.Cells[2].Value.ToString()))
            {
                MessageBox.Show("Please do not leave information blank!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            List<string> level = new List<string>{ "easy","medium","hard"};

            if (dataGridViewRow.Cells[3].Value == null || !level.Contains(dataGridViewRow.Cells[3].Value.ToString().Trim().ToLower()))
            {
                MessageBox.Show("Please enter level as easy,medium or hard!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        public bool checkInPutAnswer(DataGridView dataGridView)
        {
            int correctAnswerCount = 0;
            foreach (DataGridViewRow i in dataGridView.Rows)
            {
                if (i.Cells[1].Value == null || string.IsNullOrWhiteSpace(i.Cells[1].Value.ToString()))
                    return false;

                if (i.Cells[2].Value != null && (bool)i.Cells[2].Value)
                    correctAnswerCount++;
            }

            if (correctAnswerCount != 1)
            {
                MessageBox.Show("Please choose exactly 1 correct answer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        int indexQuestionValueChange = -1;
        int indexAnswerValueChange = -1;

        private void dataGridViewAnswer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            indexAnswerValueChange = e.RowIndex;
        }
        private void dataGridViewQuestion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            indexQuestionValueChange = e.RowIndex;
        }

        public AnswerQuestionUserModel getQuestionInGirdview(DataGridViewRow selectedRow,AnswerQuestionUserModel model)
        {
            if (checkInPutQuestion(selectedRow))
            {
                model.QuestionContent = selectedRow.Cells[1].Value.ToString();
                model.categories = selectedRow.Cells[2].Value.ToString();
                model.levels = selectedRow.Cells[3].Value.ToString();
                DateTime date;
                if (selectedRow.Cells[4].Value != null && DateTime.TryParse(selectedRow.Cells[4].Value.ToString(), out date))
                {
                    model.created_at = date;
                }
                else
                {
                    model.created_at = DateTime.Now;
                }
                if(indexAnswerValueChange > -1 && indexAnswerValueChange < dataGridViewAnswer.RowCount)
                {
                    if (checkInPutAnswer(dataGridViewAnswer))
                    {
                        List<string> answer = new List<string>();
                        foreach (DataGridViewRow item in dataGridViewAnswer.Rows)
                        {
                            answer.Add(item.Cells[1].Value.ToString());
                            if ((bool)item.Cells[2].Value)
                                model.AnswerCorrect = item.Cells[1].Value.ToString();
                        }
                        if (checkTrungDapAn(answer))
                        {
                            if (model.Answers.Except(answer).Any() || answer.Except(model.Answers).Any())
                            {
                                model.Answers = answer;
                            }
                        }
                        else
                            MessageBox.Show("The answer cannot be duplicated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                return model;
                
            }
            return null;

        }
        private void btnUpdateQuestion_Click(object sender, EventArgs e)
        {
            bool checkQuestion = indexQuestionValueChange > -1 && indexQuestionValueChange < dataGridViewQuestion.RowCount;
            
            if (checkQuestion)
            {
                int question_id = questions[indexQuestionValueChange].QuestionId;
                AnswerQuestionUserModel oldModel = questions[indexQuestionValueChange];
                AnswerQuestionUserModel newModel = getQuestionInGirdview(dataGridViewQuestion.Rows[indexQuestionValueChange], questions[indexQuestionValueChange].Clone());
                if (newModel != null)
                {
                    List<AnswerQuestionUserModel> list = new List<AnswerQuestionUserModel>();
                    list.Add(newModel);
                    if (!AnswerQuestionUserModel.contains(questions, newModel))
                    {
                        oldModel.QuestionContent += "(*)";
                        AnswerQuestionUserModel.deleteQuestion(oldModel);
                        AnswerQuestionUserModel.addQuestionToQuestions(list);
                        MessageBox.Show("Question updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadPanelQuestion();
                    }
                }
            }
            else
            {
                MessageBox.Show("No information has been edited yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool checkTrungDapAn(List<string> answer)
        {
            string a = answer[0];
            for(int i = 1; i < answer.Count; i++)
            {
                if(answer[i].Equals(a))
                     return false ; 
            }
            return true;
        }
        // panel add question
        public string getAllText(string filename)
        {
            if (File.Exists(filename))
            {
                return File.ReadAllText(filename);
            }
            return "";
        }
        public void getCorrect(AnswerQuestionUserModel s)
        {
            int index = -1;
            for (int i = 0; i < 4; i++)
            {
                if (s.Answers[i].Equals(s.AnswerCorrect))
                    index = i;
            }
            if (index == 0) checkA.Checked = true;
            else if (index == 1) checkB.Checked = true;
            else if (index == 2) checkC.Checked = true;
            else checkD.Checked = true;
        }
        public void loadGirdViewAddQuestion()
        {
            if (questionsAdd != null)
            {
                dataGridViewAddQuestion.Rows.Clear();
                int i = 0;
                foreach (var item in questionsAdd)
                {
                    dataGridViewAddQuestion.Rows.Add();
                    dataGridViewAddQuestion.Rows[i].Cells[0].Value = i + 1;
                    dataGridViewAddQuestion.Rows[i].Cells[1].Value = item.QuestionContent;
                    dataGridViewAddQuestion.Rows[i].Cells[2].Value = item.categories;
                    dataGridViewAddQuestion.Rows[i].Cells[3].Value = item.levels;
                    dataGridViewAddQuestion.Rows[i].Cells[4].Value = DateTime.Now;
                    i++;
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            string str = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(File text)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                str = getAllText(ofd.FileName);
            }
            if (!string.IsNullOrWhiteSpace(str))
            {
                questionsAdd.AddRange(AnswerQuestionUserModel.getQuestionToString(str));
                loadGirdViewAddQuestion();
            }
        }

        private void dataGridViewAddQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                int idx = e.RowIndex;
                if (idx != -1 && idx < questionsAdd.Count)
                {
                    AnswerQuestionUserModel tmp = questionsAdd[idx];
                    txtNoidung.Text = tmp.QuestionContent;
                    txtChuDe.Text = tmp.categories;
                    comboBoxLevel.SelectedItem = tmp.levels;
                    txtA.Text = tmp.Answers[0];
                    txtB.Text = tmp.Answers[1];
                    txtC.Text = tmp.Answers[2];
                    txtD.Text = tmp.Answers[3];
                    getCorrect(tmp);
                }
            
        }
        public bool checkTrungcauhoi(string s)
        {
            if (questions.Count > 0)
            {
                foreach (var i in questionsAdd)
                {
                    if (i.QuestionContent.Equals(s))
                        return true;
                }
            }
            return false;
        }
        public string iscorrect()
        {
            if (checkA.Checked)
                return txtA.Text;
            else if (checkB.Checked)
                return txtB.Text;
            else if (checkC.Checked)
                return txtC.Text;
            else 
                return txtD.Text;
        }
        public bool checkTextbox()
        {
            if (comboBoxLevel.SelectedIndex == -1)
                return false;
            return !StringUtil.isEmpty(txtNoidung.Text) && !StringUtil.isEmpty(txtChuDe.Text) && !StringUtil.isEmpty(txtA.Text) && !StringUtil.isEmpty(txtB.Text) && !StringUtil.isEmpty(txtC.Text) && !StringUtil.isEmpty(txtD.Text);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (!checkTextbox())
            {
                MessageBox.Show("Do not leave data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (checkA.Checked == false && checkB.Checked == false && checkC.Checked == false && checkD.Checked == false)
                {
                    MessageBox.Show("The answer has not been selected correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {
                        if (!checkTrungcauhoi(txtNoidung.Text))
                        {
                            AnswerQuestionUserModel tmp = new AnswerQuestionUserModel();
                            tmp.QuestionContent = txtNoidung.Text;
                            tmp.categories = txtChuDe.Text;
                            tmp.levels = comboBoxLevel.SelectedItem.ToString();
                            tmp.Answers.Add(txtA.Text);
                            tmp.Answers.Add(txtB.Text);
                            tmp.Answers.Add(txtC.Text);
                            tmp.Answers.Add(txtD.Text);
                            tmp.AnswerCorrect = iscorrect();
                            if (checkTrungDapAn(tmp.Answers))
                            {
                                questionsAdd.Add(tmp);
                                loadGirdViewAddQuestion();
                                txtNoidung.Text = txtA.Text = txtB.Text = txtC.Text = txtChuDe.Text = txtD.Text = "";
                                checkA.Checked = checkB.Checked = checkC.Checked = checkD.Checked = false;
                                comboBoxLevel.SelectedIndex = -1;
                            }
                            else MessageBox.Show("The answer cannot be duplicated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The question is already on the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm adding to database!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                AnswerQuestionUserModel.addQuestionToQuestions(questionsAdd);
                dataGridViewAddQuestion.Rows.Clear();
                questionsAdd.Clear();
                MessageBox.Show("Add question succcessful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            questionsAdd.Clear();
            txtNoidung.Text = txtA.Text = txtB.Text = txtC.Text = txtChuDe.Text = txtD.Text = "";
            comboBoxLevel.SelectedIndex = -1;
            checkA.Checked = checkB.Checked = checkC.Checked = checkD.Checked = false;
            loadGirdViewAddQuestion();
        }

        private void DeleteQuestionAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddQuestion.SelectedRows.Count > 0)
            {
                int idx = dataGridViewAddQuestion.SelectedRows[0].Index;
                questionsAdd.RemoveAt(idx);
                loadGirdViewAddQuestion();
            }
            else
            {
                MessageBox.Show("Please select the delete option!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
