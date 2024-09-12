using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.Net.Configuration;
using System.Net.Sockets;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnGoing_Processes
{
    public partial class Form1 : Form
    {
        #region 변수 및 객체들
        bool popupFlag = false;  // 내리기 & 올리기모드
        // List<string> procs = new List<string>();  // 프로세스 임시저장
        List<ListViewItem> goingProcs = new List<ListViewItem>(); // 실행중인 프로세스들
        Point startPoint = new Point();  // 시작 위치를 기록, 위치 조정시 기준이됨
        OpenProcs op = new OpenProcs();
        #endregion

        public Form1()
        {
            InitializeComponent();

         // Properties.Settings.Default.Favorites = "";
         // Properties.Settings.Default.Save();
            #region 초기화
            imgList = new ImageList();
            imgList.ImageSize = new Size(80, 80);
            listView1.SmallImageList = imgList;
            listView1.View = View.SmallIcon;
            //CallBack 델리게이트 생성
            EnumWindowCallback callback = new EnumWindowCallback(EnumWindowsProc);
            EnumWindows(callback, 0);

            // 프로세스 목록추가
            foreach (var i in goingProcs)
                listView1.Items.Add(i);

            // 폼 시작 위치
            this.StartPosition = FormStartPosition.CenterScreen;

            // 타이머 설정
            timer1.Interval= 1000;
            timer1.Enabled= true;
            timer2.Interval= 15000;
            timer2.Enabled= true;

            // 실행중인 프로세스 개수
            lblogProc.Text = string.Format("실행중인 프로세스 {0}개", Process.GetProcesses().Length);

            // 메모리
            lblmem.Text = string.Format("총메모리 사용량 {0}MB", Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024);

           /* // 콤보박스
            string[] savedFavo = Properties.Settings.Default.Favorites.Split('%');
            foreach (string fav in savedFavo)
                cBFovorites.Items.Add(fav);
            cBFovorites.SelectedIndex = 0;*/
            #endregion
        }

        #region API및 델리게이트
        public delegate bool EnumWindowCallback(int hwnd, int lParam);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowCallback callback, int y);

        [DllImport("user32.dll")]
        public static extern int GetParent(int hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        public static extern long GetWindowLong(int hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr GetClassLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        #endregion

        #region 실행중인 프로세스 찾기
        const int GCL_HICON = -14; //GetWindowLong을 호출할 때 쓸 인자
        const int GCL_HMODULE = -16;
        ImageList imgList;//ListView의 Image로 쓸 리스트

        public bool EnumWindowsProc(int hWnd, int lParam)
        {
            //윈도우 핸들로 그 윈도우의 스타일을 얻어옴
            UInt32 style = (UInt32)GetWindowLong(hWnd, GCL_HMODULE);
            //해당 윈도우의 캡션이 존재하는지 확인
            if ((style & 0x10000000L) == 0x10000000L && (style & 0x00C00000L) == 0x00C00000L)
            {
                //부모가 바탕화면인지 확인
                if (GetParent(hWnd) == 0)
                {
                    StringBuilder Buf = new StringBuilder(256);
                    //응용프로그램의 이름을 얻어온다
                    if (GetWindowText(hWnd, Buf, 256) > 0)
                    {
                        try
                        {
                            //HICON 아이콘 핸들을 얻어온다
                            IntPtr hIcon = GetClassLong((IntPtr)hWnd, GCL_HICON);
                            //아이콘 핸들로 Icon 객체를 만든다
                            Icon icon = Icon.FromHandle(hIcon);
                            imgList.Images.Add(icon);
                        }
                        catch (ArgumentException)
                        {
                            //예외의 경우는 자기 자신의 윈도우인 경우이다.
                            imgList.Images.Add(this.Icon);
                        }
                        goingProcs.Add(new ListViewItem(Buf.ToString(), listView1.Items.Count));
                    }
                }
            }
            return true;
        }

        #endregion

        #region 이벤트들

        private void Form1_Load(object sender, EventArgs e)
        {
            startPoint = this.Location;  // 시작위치 기록

            // 폼 시작위치 오른쪽 아래로 지정
            this.Location = new Point(this.Location.X * 2, this.Location.Y * 2);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)  // 클릭한 프로그램 맨 위로 보내기
        {
            // 제대로 선택 안 되면 리턴
            if (listView1.SelectedItems.Count == 0) return;

            IntPtr hWnd = FindWindow(null, listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text.ToString());
            if (hWnd.Equals(IntPtr.Zero))
            {
                ShowWindowAsync(hWnd, 1);
            }
            SetForegroundWindow(hWnd);
        }

        private void timer1_Tick(object sender, EventArgs e)  // 프로세스들 실시간으로 실행, 닫힘 감지
        {
            goingProcs.Clear();

            //CallBack 델리게이트 생성
            EnumWindowCallback callback = new EnumWindowCallback(EnumWindowsProc);
            EnumWindows(callback, 0);

            if (listView1.Items.Count != goingProcs.Count) // 실행중인 프로세스 수와 리스트뷰 저장된 수가 다르면
            {
                // 리스트머시기들 리로딩
                imgList = new ImageList();
                imgList.ImageSize = new Size(80, 80);
                listView1.SmallImageList = imgList;
                listView1.View = View.SmallIcon;
                listView1.Items.Clear();

                // 리스트뷰에 프로세스들 리로딩
                foreach (var i in goingProcs)
                    listView1.Items.Add(i);
            }

            // 실행중인 프로세스 개수
            lblogProc.Text = string.Format("실행중인 프로세스 {0}개", Process.GetProcesses().Length);

            // 메모리
            lblmem.Text = string.Format("총메모리 사용량 {0}MB", Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024);
        }

        private void pictureBox1_Click(object sender, EventArgs e)  // 폼 크기
        {
            if (popupFlag)  // true면
            {
                pictureBox1.Image = Properties.Resources.내리기;
                this.Size = new Size(Width, 420);
                this.Location = new Point(startPoint.X * 2, startPoint.Y * 2);
                Thread.Sleep(100);

                popupFlag = false;
            }
            else  // false면
            {
                pictureBox1.Image = Properties.Resources.올리기;
                this.Size = new Size(Width, 130);
                this.Location = new Point(this.Location.X, (this.Bottom * 3 - this.Location.Y) / 2);
                Thread.Sleep(100);
                   
                popupFlag = true;
            }
        }

        private void pBClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)  // 아이템 우클릭시 '닫기'버튼 보이기
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)  // 해당 프로세스 닫기
        {
			string processFullName = listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text.ToString();
            string processRealName = (processFullName.Contains("-")) ? processFullName.Split('-')[1].Trim() : processFullName;
			Process[] getProcessByName = Process.GetProcessesByName(processRealName);

            if (getProcessByName.Length != 0)
                foreach (Process p in getProcessByName)
                    p.Kill();
            else
                MessageBox.Show("해당 프로세스를 찾을 수 없습니다.");

			/*
			 * 프로세스명 != 실행중인 어플리케이션의 이름
			 * 내가 가져온거 == 실행중인 어플리케이션의 이름
			 * 또 가져와야 할거 == 프로세스명 == (ex)chrome, visual studio... != (ex) chat gpt-Chrome, 스택 저축앱 - Figma
			 */

			/*foreach(Process p in Process.GetProcesses())
            {
                if(p.ProcessName.StartsWith(listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text.ToString()))
                {
                    p.Kill();

                    break;
                }    
            }*/
		}

		private void pBSet_Click(object sender, EventArgs e)  // 메인 폼 설정
        {
            settingForm sf = new settingForm((double)this.Opacity * 10);
            sf.ShowDialog();

            this.Opacity = ((double)sf.MyProperty * 10 / 100);
        }

        private void 즐겨찾기저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pro = listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text.ToString();

            Properties.Settings.Default.Favorites += string.Format("%{0}", pro);
            Properties.Settings.Default.Save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            op.ShowDialog();
        }
        
        // 실행중인 프로세스 표시
        private void timer2_Tick(object sender, EventArgs e)
        {
            goingProcs.Clear();

            //CallBack 델리게이트 생성
            EnumWindowCallback callback = new EnumWindowCallback(EnumWindowsProc);
            EnumWindows(callback, 0);
           
            // 리스트머시기들 리로딩
            imgList = new ImageList();
            imgList.ImageSize = new Size(80, 80);
            listView1.SmallImageList = imgList;
            listView1.View = View.SmallIcon;
            listView1.Items.Clear();

            // 리스트뷰에 프로세스들 리로딩
            foreach (var i in goingProcs)
                listView1.Items.Add(i);

        } // 리소스들 리로딩
        #endregion
    }
}
