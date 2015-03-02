using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBug.Models
{
    public class DataManager
    {
        private MvcBugDataContext _datacontext;

        public DataManager()
        {
            _datacontext = new MvcBugDataContext();
        }

        private MembershipRepository _membershipRepository;
        public MembershipRepository Membership
        {
            get
            {
                if (_membershipRepository == null)
                    _membershipRepository = new MembershipRepository();
                
                return _membershipRepository;
            }
        }

        private TaskRepository _taskRepository;
        public TaskRepository Tasks
        {
            get
            {
                if (_taskRepository == null)
                    _taskRepository = new TaskRepository(_datacontext);

                return _taskRepository;
            }
        }

        private StateRepository _stateRepository;
        public StateRepository States
        {
            get
            {
                if (_stateRepository == null)
                    _stateRepository = new StateRepository(_datacontext);

                return _stateRepository;
            }
        }

    }
}