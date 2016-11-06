using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrack
{
    class WeeklyTask:DailyTask
    {
        private DailyTask[] weeklyTasks;

        public WeeklyTask()
        {
            weeklyTasks = new DailyTask[7];
        }

        public WeeklyTask(DailyTask[] weeklyTasks)
        {
            weeklyTasks = new DailyTask[7];
            for(int x = 0; x < weeklyTasks.Length; x++)
            {
                this.weeklyTasks[x] = weeklyTasks[x];
            }
        }
    }
}
