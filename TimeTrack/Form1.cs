using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrack
{
    public partial class TimeTracking : Form
    {
        private string[] tasks = new string[6];
        private double[] durations = new double[6];
        private string[] taskCodes = new string[6];
        private double decimalWorkTime = 0.0;
        private int totalTasks = 0;
        private double totalDuration = 0.0;
        private DailyTask[] pullDailyTasks; 

        public TimeTracking()
        {
            InitializeComponent();
        }

        private void TimeTracking_Load(object sender, EventArgs e)
        {
            //DateTime currentTime = DateTime.Now;
            //endTimePicker.Text = currentTime.ToString();
            initialCalcs();
        }

        private void initialCalcs()
        {
            string workHoursStr = "";
            double breakTime = 0.0;
            breakTime = Convert.ToDouble(breakNumericUpDown.Value);
            TimeSpan workHoursTimeSpan = endTimePicker.Value - startTimePicker.Value;
            double decimalTime = (double)workHoursTimeSpan.Hours
                + (double)workHoursTimeSpan.Minutes / 60 - (breakTime / 60);
            workHoursStr = decimalTime.ToString("#.##");
            calWkHrLbl.Text = workHoursStr;
            UnAlDurationLbl.Text = workHoursStr;
            countTasks();
        }

        private void calWkHrBtn_Click(object sender, EventArgs e)
        {
            initialCalcs();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trackTimeBtn_Click(object sender, EventArgs e)
        {
            countTasks();
            calculateDuration();
        }

        private void calculateDuration()
        {
            totalDuration = 0.0;
            decimalWorkTime = Convert.ToDouble(calWkHrLbl.Text);
            durations[0] = Convert.ToDouble(durOneTxtBox.Text);
            durations[1] = Convert.ToDouble(durTwoTxtBox.Text);
            durations[2] = Convert.ToDouble(durThreeTxtBox.Text);
            durations[3] = Convert.ToDouble(durFourTxtBox.Text);
            durations[4] = Convert.ToDouble(durFiveTxtBox.Text);
            durations[5] = Convert.ToDouble(durSixTxtBox.Text);
            for(int x = 0; x < durations.Length; x++)
            {
                totalDuration += durations[x];
            }
            double UnAlDurDbl = decimalWorkTime - totalDuration;
            UnAlDurationLbl.Text = UnAlDurDbl.ToString("#.##");
        }

        private void countTasks()
        {
            totalTasks = 0;
            tasks[0] = taskOneTxtBox.Text;
            tasks[1] = taskTwoTxtBox.Text;
            tasks[2] = taskThreeTxtBox.Text;
            tasks[3] = taskFourTxtBox.Text;
            tasks[4] = taskFiveTxtBox.Text;
            tasks[5] = taskSixTxtBox.Text;
            for (int x = 0; x < tasks.Length; x++)
            {
                if(tasks[x] != "")
                {
                    totalTasks += 1;
                }
            }
            totalTasksLbl.Text = totalTasks.ToString(); ;
        }

        private void pullTasksBtn_Click(object sender, EventArgs e)
        {
            //  private string taskName;
            //    private double taskDuration;
            //      private TaskCode taskCode;
            //        private DateTime taskDate;
            DailyTask tempDT;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            taskCodes[0] = comboBox1.Text;
            taskCodes[1] = comboBox2.Text;
            taskCodes[2] = comboBox3.Text;
            taskCodes[3] = comboBox4.Text;
            taskCodes[4] = comboBox5.Text;
            taskCodes[5] = comboBox6.Text;
            pullDailyTasks = new DailyTask[totalTasks];
            for (int x = 0; x < pullDailyTasks.Length; x++)
            {
                
                tempDT = new DailyTask(tasks[x], durations[x], taskCodes[x], 
                    DailyDateTimePicker.Value);
                pullDailyTasks[x] = tempDT;
            }
            for(int x = 0; x < pullDailyTasks.Length; x++)
            {
                this.dataGridView1.Rows.Add(lastTxtBox.Text,
                    pullDailyTasks[x].TaskDate.ToString("MMMM"),
                    pullDailyTasks[x].TaskDate.ToString("dd/MMM/yy"),
                    pullDailyTasks[x].TaskCode,
                    pullDailyTasks[x].TaskDuration,
                    0,
                    0,
                    pullDailyTasks[x].TaskName);
            }

        }

        private void pullEdoBtn_Click(object sender, EventArgs e)
        {
            if(totalTasks>0)
            {
                string commentsList = "";
                for(int x = 0; x < totalTasks; x++)
                {
                    commentsList += tasks[x] + "/";
                }
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                this.dataGridView2.Rows.Add(DailyDateTimePicker.Value.Date.ToString("dd-MMM-yy"),
                    startTimePicker.Value.TimeOfDay.ToString("hhmm"),
                    endTimePicker.Value.TimeOfDay.ToString("hhmm"),
                    breakNumericUpDown.Value,
                    0,
                    0,
                    0,
                    commentsList);
            }
        }
    }
}
