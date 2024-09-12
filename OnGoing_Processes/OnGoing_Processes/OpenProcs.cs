using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Sql;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGoing_Processes
{
    public partial class OpenProcs : Form
    {
        string favorite;

        public OpenProcs()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)  // 검색
        {
            if (comboBox1.Text.Trim() == "")
            {
                initializeLV();
                return;
            }

            listView1.Items.Clear();
            
            // 검색 조건에 부합한 프로세스 가져오기 process In Query
            foreach(var j in listView1.Items)
            {
                listView1.Items.Add(j.ToString());
            }

            // 검색결과가 없다면 도메인으로 간주하고 실행
            if(listView1.Items.Count == 0)
            {
                try
                {
                    Process.Start(comboBox1.Text.Trim());
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error@");
                }
            }    
        }

        // 리스트뷰 초기화
        private void initializeLV()
        {
            listView1.Items.Clear();
            foreach (var i in favorite.Split('%'))
            {
                listView1.Items.Add(i);
            }
        }

        // 프로세스 시작
        private void beginProcs(string p)
        {
            try
            {
                // 크롬창이면 크롬열기
                string[] c = p.Split('-');
                if (c[c.Length - 1].Trim().ToLower() == "chrome")
                    Process.Start($"https://www.google.com/search?q={c[0]}");

                // 아니면 프로세스 열기
                Process.Start(p);
            }
            catch/*(Exception e)*/
            {
               /* MessageBox.Show(e.Message, "Error!");

                if (MessageBox.Show("검색 결과가 없습니다. 인터넷으로 검색하시겠습니까?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Process.Start($"https://www.google.com/search?q={p.Split('-')[0]}");

                if (p.Trim() == "")
                {
                    comboBox1.Items.Remove(p);
                }*/
            }
        }

        private void OpenProcs_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            // 즐겨찾기 프로세스들 가져와서 콤보박스에 추가
            favorite = Properties.Settings.Default.Favorites.Replace("%%", "%").Replace("% %", "%");

            string[] favorites = favorite.Split('%');
            foreach (var i in favorites)
            {
                comboBox1.Items.Add(i);
                listView1.Items.Add(i);
            }

            // 초기화
            comboBox1.Text = "";
            initializeLV();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // 텍스트 없으면 리스트뷰 원상복구
            if (comboBox1.Text.Trim() == "")
                initializeLV();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            beginProcs(comboBox1.SelectedItem.ToString());
            comboBox1.Text = "";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e) // 즐겨찾기 추가
        {
            if(e.KeyCode == Keys.Enter)
            {
                favorite += string.Format("%{0}", comboBox1.Text);
                comboBox1.Items.Add(comboBox1.Text);
                initializeLV();
                beginProcs(comboBox1.Text);
                comboBox1.Text = "";

                // settings에 저장
                Properties.Settings.Default.Favorites = favorite.TrimStart('%').TrimEnd('%');
                Properties.Settings.Default.Save();
            }
        }

        private void pBClear_Click(object sender, EventArgs e)  // 즐겨찾기 전체삭제
        {
            Properties.Settings.Default.Favorites = "";
            Properties.Settings.Default.Save();

            initializeLV();
            comboBox1.Items.Clear();
            listView1.Items.Clear();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(!listView1.SelectedItems.Count.Equals(0) && e.Button == MouseButtons.Left)
            {
                beginProcs(listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text.ToString());
            }
        }
    }
}
