using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrack
{
    class DailyTask
    {

        private string taskName;
        private double taskDuration;
        private string taskCode;
        private DateTime taskDate;


        public DailyTask()
        {

        }

        public DailyTask(string taskName, double taskDuration, string taskCode,
                        DateTime taskDate)
        {
            this.TaskName = taskName;
            this.TaskDuration = taskDuration;
            this.TaskCode = taskCode;
            this.TaskDate = taskDate;
        }


        public string TaskName
        {
            get
            {
                return taskName;
            }

            set
            {
                taskName = value;
            }
        }

        public double TaskDuration
        {
            get
            {
                return taskDuration;
            }

            set
            {
                taskDuration = value;
            }
        }

        internal string TaskCode
        {
            get
            {
                return taskCode;
            }

            set
            {
                taskCode = value;
            }
        }

        public DateTime TaskDate
        {
            get
            {
                return taskDate;
            }

            set
            {
                taskDate = value;
            }
        }

        ~DailyTask()
        {

        }

        
    }
}
