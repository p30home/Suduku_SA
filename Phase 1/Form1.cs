using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AI_PROJECT
{
    public partial class Form1 : Form
    {
        private Suduku currentSuduku = null;
        private Thread MainThread = null;
        private System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        private bool Processing = false;
        private int CurrnetDepth = 0;
        private int ProcessedStates = 0;
        private double MemoryUsage = 0;
        private double EllapsedTime = 0;
        private int[,] latestTable = null;
        private System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        private Thread thrdMemoryCheck = null;
        private Stack<Suduku> stackSuduku = new Stack<Suduku>();

        public DiagramForm Diagram { get; private set; }

        public Form1()
        {
            InitializeComponent();
            cboSusukuType.DataSource = new SudukuType[] { SudukuType.Four_Four, SudukuType.Nine_Nine };
            cboSusukuType.SelectedIndex = 0;
            tmr.Tick += Tmr_Tick;
            tmr.Interval = 1000;
            thrdMemoryCheck = new Thread(() =>
            {
                while(true)
                {
                    MemoryUsage = (GC.GetTotalMemory(true) / 1000000.0);
                    Thread.Sleep(10000);
                }
            });
            thrdMemoryCheck.IsBackground = true;
            thrdMemoryCheck.Start();
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            if(watch.Elapsed.TotalSeconds < 60)
                txtEllapsedTime.Text = watch.Elapsed.TotalSeconds + " s";
            else if(watch.Elapsed.TotalMinutes < 60)
                txtEllapsedTime.Text = watch.Elapsed.TotalMinutes + " m";
            else
                txtEllapsedTime.Text = watch.Elapsed.TotalHours + " h";
            txtCurrentDepth.Text = "~ " + CurrnetDepth;
            txtProcessedStates.Text = "~ " + ProcessedStates;
            txtMemoryUsage.Text = MemoryUsage.ToString();
            if(latestTable != null)
            {
                DrawSuduku(new Suduku(latestTable));
            }
        }

        private void DrawSuduku(Suduku su)
        {
            var upper = (int)su.SudukuType;
            bool loaded = upper * upper == pnlSuduku.Controls.Count;
            if(!loaded)
                pnlSuduku.Controls.Clear();
            var spiliter = su.SudukuType == SudukuType.Nine_Nine ? 3 : 2;
            Color[] spltColor = new Color[] { Color.LightGray, Color.LightSlateGray };
            var width = pnlSuduku.Width / upper;
            var height = pnlSuduku.Height / upper;
            var conficts = su.GetConflicts();
            for(int i = 0;i < upper;i++)
            {
                for(int j = 0;j < upper;j++)
                {
                    if(loaded)
                    {
                        var l = pnlSuduku.Controls[(i * upper) + j] as Label;
                        l.Text = su.Table[i, j].ToString();
                        l.ForeColor = conficts[i, j] > 0 ? Color.Red : Control.DefaultForeColor;
                    }
                    else
                    {
                        Label lbl = new Label
                        {
                            Text = su.Table[i, j].ToString(),
                            Width = width,
                            Height = height,
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = spltColor[Math.Abs((i / spiliter) - (j / spiliter)) % 2],
                            ForeColor = conficts[i, j] > 0 ? Color.Red : Control.DefaultForeColor,
                            Font = new Font(Control.DefaultFont, FontStyle.Bold),
                            Location = new Point(width * j, height * i),
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        pnlSuduku.Controls.Add(lbl);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void cboSusukuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSuduku = new Suduku((SudukuType)(sender as ComboBox).SelectedItem);
            Reset();
        }

        private void Loading(bool Wait)
        {
            tmr.Enabled = Wait;
            pnlSetting.Enabled = !Wait;
            picLoading.Visible = Wait;
            button1.Enabled = !Wait;
            btnNext.Enabled = !Wait;
            btnLastStates.Enabled = !Wait;
        }

        private void Reset()
        {
            this.Text = "<<<<Mojtaba Goodarzi>>>>  <<<<97422216>>>> <<<<Solving Suduku using Simulated annealing>>>>";
            txtCurrentDepth.Text =
                txtEllapsedTime.Text =
                txtMemoryUsage.Text =
                txtProcessedStates.Text = "N/A";
            this.stackSuduku.Clear();
            pnlInfo.BackColor = Control.DefaultBackColor;
            DrawSuduku(currentSuduku);
            this.latestTable = currentSuduku.Table;
            watch.Reset();
            tmr.Stop();
        }

  
        private void Slv_ProblemSolved(Suduku goalState, int ProcessedState)
        {
            currentSuduku = goalState;
            watch.Stop();
            this.InvokeIfRequired(f =>
            {
                pnlInfo.BackColor = Color.LightGreen;
                DrawSuduku(goalState);
                this.Text = "Suduku Solved!";
                txtCurrentDepth.Text = "=" + goalState.Depth.ToString();
                txtProcessedStates.Text = "=" + ProcessedState;
                txtEllapsedTime.Text = watch.Elapsed.TotalSeconds + " s";
                Loading(false);
            });
        }

        private void Slv_InfoEvent(Suduku su, int ProcessedCount)
        {
            CurrnetDepth = su.Depth;
            ProcessedStates = ProcessedCount;
            this.latestTable = su.Table;
        }

        private void Slv_ErrorHappend(Exception ex)
        {
            this.InvokeIfRequired(form =>
            {
                pnlInfo.BackColor = Color.Red;
                Loading(false);
                MessageBox.Show(form, ex.Message);
            });
        }

        private void btnSA_Click(object sender, EventArgs e)
        {
            Reset();
            SimulatedAnnealing slv = new SimulatedAnnealing();
            slv.ErrorHappend += Slv_ErrorHappend;
            slv.Report += Slv_Report;
            slv.ProblemSolved += Slv_ProblemSolved;
            MainThread = new Thread(() =>
            {
                watch.Start();
                slv.Start(currentSuduku,double.Parse(txtSALimit.Text.ToLower().Replace("min","").Trim()));
            });
            this.Diagram = new DiagramForm();
            this.Diagram.Show();
            MainThread.IsBackground = true;
            Loading(true);
            MainThread.Start();
        }

        private void Slv_Report(Suduku current, double temperature, double score)
        {
            this.latestTable = current.Table;
            if(this.Diagram.IsDisposed)
            {
                this.Diagram = new DiagramForm();
                this.Diagram.Show();
            }
            this.Diagram.Update(temperature, current.ConflictCount);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(currentSuduku != null && currentSuduku.Parent != null)
            {
                stackSuduku.Push(currentSuduku);
                currentSuduku = currentSuduku.Parent;
                txtCurrentDepth.Text = " =" + currentSuduku.Depth;
                DrawSuduku(currentSuduku);
            }
        }

        private void btnLastStates_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(() =>
            {
                WriteAndShowFile();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\states.txt");
            });
            thrd.IsBackground = true;
            thrd.Start();
        }

        private void WriteAndShowFile()
        {
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\states.txt");
            var current = currentSuduku;
            while(current != null)
            {
                sw.WriteLine(current.ToString());
                current = current.Parent;
            }
            sw.Flush();
            sw.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(this.stackSuduku.Count > 0)
            {
                currentSuduku = stackSuduku.Pop();
                txtCurrentDepth.Text = "= " + currentSuduku.Depth;
                DrawSuduku(currentSuduku);
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
                button1.PerformClick();
            else if(e.KeyCode == Keys.Right)
                btnNext.PerformClick();
        }



        private void Vs_solve_Report(Suduku current,int ProcessedStates,int Radius)
        {
            this.ProcessedStates = ProcessedStates;
            
            this.CurrnetDepth = Radius;
            this.latestTable = current.Table;
        }
    }
}