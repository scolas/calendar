using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.BusinessLayer
{
    public class BusinessCalendar : IBusinessCalendar
    {
        public Month nextMonth(int month)
        {
            Month m1 = new Month();
            DateTime nMonths = new DateTime(2019,month,1);
            DateTime newMonth = new DateTime(nMonths.AddMonths(1).Year, nMonths.AddMonths(1).Month, 1);
        
            
            m1.name = newMonth.ToString("MMMM");
            m1.days = DateTime.DaysInMonth(newMonth.Year, newMonth.Month);
            m1.number = 6;



            return m1;
        }

        public Month preMonth()
        {
            Month m1 = new Month();
            m1.name = "June";
            m1.days = 30;
            m1.number = 6;

            Month m2 = new Month();
            m1.name = "July";
            m1.days = 31;
            m1.number = 7;

            return m2;

        }
    }
}