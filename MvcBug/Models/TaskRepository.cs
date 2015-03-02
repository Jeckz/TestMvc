using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBug.Models
{
    public class TaskRepository
    {
        private MvcBugDataContext _datacontext;

        public TaskRepository(MvcBugDataContext dataContext)
        {
            _datacontext = dataContext; 
        }

        public IEnumerable<Tasks> GetTasks()
        {
            return _datacontext.Tasks.OrderBy(t => t.CreatedOn);
        }

        public Tasks GetTask(int taskId)
        {
            return _datacontext.Tasks.SingleOrDefault(t => t.TaskId == taskId);
        }

        public Tasks CreateTask(string title, string text)
        {
            Tasks t = new Tasks { Title = title, Text = text };
            _datacontext.Tasks.InsertOnSubmit(t);
            _datacontext.SubmitChanges();
            return t;
        }

        public void UpdateTask(Tasks t)
        {
            Tasks dbTask = GetTask(t.TaskId);
            dbTask.AssignedOn = t.AssignedOn;
            dbTask.Title = t.Title;
            dbTask.Text = t.Text;
            dbTask.StateId = t.StateId;

            _datacontext.SubmitChanges();

        }

        public void DeleteTask(int taskId)
        {
            Tasks t = GetTask(taskId);
            _datacontext.Tasks.DeleteOnSubmit(t);
            _datacontext.SubmitChanges();
        }


    }
}