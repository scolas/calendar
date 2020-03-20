using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.BusinessLayer
{
    interface IBusinessInvite
    {
        List<Invite> getInvite();

        bool acceptInvite(int id);
        bool denyInvite(int id);
    }
}
