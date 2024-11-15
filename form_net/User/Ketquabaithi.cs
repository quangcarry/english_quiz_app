using form_net.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_net.User
{
    public partial class Ketquabaithi : Form
    {

        public List<AnswerQuestionUserModel> Answers { get; set; }
        public ResultModel result {  get; set; }
        public Ketquabaithi()
        {
            InitializeComponent();
            this.Answers = new List<AnswerQuestionUserModel>();
            this.result = new ResultModel();
            result.time = "00:00:00";
            result.soCauDung = 0;
            result.score = 0;
        }
        public Ketquabaithi(List<AnswerQuestionUserModel> Answers, ResultModel result)
        {
            InitializeComponent();
            this.Answers = Answers;
            this.result = result;
            innit();
        }
        void innit()
        {
            lblScore.Text = result.score.ToString();
            int persent = (int)((float)result.soCauDung / Answers.Count * 100);
            lblSoDapAnDung.Text = result.soCauDung + "/" + Answers.Count + "(" + persent + "%)"; 
            lblTime.Text = result.time;
        }
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            chitietbaikiemtra f = new chitietbaikiemtra(Answers,"Menu");
            f.ShowDialog();
            this.Hide();
        }

    }
}
