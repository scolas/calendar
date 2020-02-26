using Calendar.DataLayer;
using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.BusinessLayer
{
    public class BusinessInvite : IBusinessInvite
    {
        IRepositoryInvite _irep = null;

        public BusinessInvite() : this(new Repository())
        {

        }
        public BusinessInvite(IRepositoryInvite irep)
        {
            _irep = irep;
        }

        public List<Invite> getInvite(int id)
        {
            List<Invite> i = _irep.getInvite(id);
            return i;
        }
    }
}