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
using form_net.Model;
using form_net.User;
using System.Globalization;

namespace form_net.Admin
{
    public partial class Quanlybaikiemtra : Form
    {
        public int id;
        public List<TestsModel> testsModel = new List<TestsModel>();
        public Quanlybaikiemtra()
        {
            InitializeComponent();
            setDatagrid();
            id = 0;
            load();
        }

        public Quanlybaikiemtra(int id)
        {
            InitializeComponent();
            this.id = id;
            setDatagrid();
            load();
        }
        public void load()
        {
            testsModel = TestsModel.getAllTestByUserId(id);
            if (testsModel != null)
            {
                foreach (var test in testsModel)
                {
                    int idx = testsModel.IndexOf(test) + 1;
                    dataGridView1.Rows.Add(idx, test.topic, test.levels, test.score, test.socauhoi, test.startTime, test.endTime);
                }
            }
            setStatusGrid();

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
        public void setStatusGrid()
        {
            if(testsModel.Count > 0)
            {
                lbl2.Visible = false;
            }
            else
            {
                lbl2.Visible = true;
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

        public List<int> split(DateTime date)
        {
            List<int> list = new List<int>();
            string day = date.Day.ToString("D2"); 
            string month = date.Month.ToString("D2"); 
            string year = date.Year.ToString();
            string hour = date.Hour.ToString("D2");   
            string minute = date.Minute.ToString("D2");
            list.Add(int.Parse(day));
            list.Add(int.Parse(month));
            list.Add(int.Parse(year));
            list.Add(int.Parse(hour));
            list.Add(int.Parse(minute));
            return list;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1) {
                if (dataGridView1.Rows[index].Cells[5].Value != null)
                {
                    DateTime startTime = DateTime.Parse(dataGridView1.Rows[index].Cells[5].Value.ToString());
                    List<int> time = split(startTime);
                    List<AnswerQuestionUserModel> answers = AnswerQuestionUserModel.getAllQuestionByUserIdAndStartTime(id, time);
                    chitietbaikiemtra f = new chitietbaikiemtra(answers, "Management");
                    f.Show();
                    this.Hide();
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            menuUser f = new menuUser(id);
            f.Show();
            this.Hide();
        }
    }
}
