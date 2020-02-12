﻿using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.BusinessLayer
{
    interface IBusinessCalendar
    {
        Month preMonth(int month);
        Month nextMonth(int month);
    }
}
