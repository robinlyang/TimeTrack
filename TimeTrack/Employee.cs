using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrack
{
    class Employee
    {
        private string firstName;
        private string lastName;
        private string email;
        private DailyTask[] dailyTasks;

        public Employee()
        {

        }

        public Employee(string firstName, string lastName, string email, int taskAmount)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.dailyTasks = new DailyTask[taskAmount];
        }

        ~Employee()
        {

        }

    }
}
