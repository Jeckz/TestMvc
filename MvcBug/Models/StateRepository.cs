using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBug.Models
{
    public class StateRepository
    {
        private MvcBugDataContext _datacontext;

        public StateRepository(MvcBugDataContext DataContext)
        {
            this._datacontext = DataContext;
        }

        public IEnumerable<States> GetStates()
        {
            return _datacontext.States.OrderBy(s => s.Title);
        }
    }
}