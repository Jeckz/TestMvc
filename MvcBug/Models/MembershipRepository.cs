using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcBug.Models
{
    public class MembershipRepository
    {
        public MembershipUserCollection GetUsers()
        {
            return Membership.GetAllUsers();
        }
    }
}