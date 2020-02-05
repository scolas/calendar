using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Calendar.DataLayer
    {
        public class Repository : IRepositoryAuthentication, IRepositoryEvent
        {
            IDataAccess _idac = null;

            public Repository()
            {
                _idac = new DataAccess();
            }

            public Repository(IDataAccess idac)
            {
                _idac = idac;
            }




            public bool DeleteEvent(Event events)
            {
            bool ret = false;
            try
            {
                DateTime dates = DateTime.Now;
                string location = events.location;
                string setBy = events.setBy;
                string sql =  String.Format("Delete from [dbo].[Events] where eventId ={0}", events.id);



                        object obj = _idac.InsertUpdateDelete(sql);
                        if (obj != null)
                        {
                            ret = true;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return ret;
        }

            public Event GetEvent(int id)
            {
                Object ret = false;
                try
                {
                    string sql = "select username from dbo.Event where " +
                        "eventId='" + id + "' ";
                    object obj = _idac.GetSingleAnswer(sql);
                    if (obj != null)
                    {
                        ret = obj;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return (Event)ret;
            }

        public List<Event> GetEvents()
        {
            List<Event> ret = new List<Event>();
            try
            {
                string sql = "select * from dbo.Events";
                DataSet obj = _idac.DataSetXEQDynamicSql(sql);

  
                foreach (DataRow row in obj.Tables[0].Rows)
                {
                    object[] data = row.ItemArray;
                    int id = (int)data[0];
                    DateTime date = (DateTime)data[1];
                    string location = data[2].ToString();
                    string setby = data[3].ToString();
                    string name = data[4].ToString();

                    Event tempEvent = new Event();
                    tempEvent.id = id;
                    tempEvent.location = location;
                    tempEvent.setBy = setby;
                    tempEvent.name = name;
                    tempEvent.day = date;
                    ret.Add(tempEvent);

                }

         
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public bool SaveEvent(Event events)
            {

                bool ret = false;
                try
                {
                    DateTime dates = DateTime.Now;
                    string location = events.location;
                    string setBy = events.setBy;
                    string sql = "INSERT INTO[dbo].[Events] ([date], [location],[setBy],[title]) VALUES ('" + dates + "' ,'" + location + "' ,'" + setBy + "', '" + events.name + "')";


                    object obj = _idac.InsertUpdateDelete(sql);
                    if (obj != null)
                    {
                        ret = true;
                    }
                }
                catch (Exception)
                {
                ret = false;
                }
                return ret;

            }

            public bool UpdateEvent(Event events)
            {
                bool ret = false;
                try
                {
                    DateTime dates = events.day;
                    string location = events.location;
                    string setBy = events.setBy;
                    string sql = String.Format(@"UPDATE [dbo].[Events] set date = '{0}', location = '{1}', setBy = '{2}', title = '{3}' where eventId = {4}",
                        dates, location, setBy, events.name, events.id);

                
                    object obj = _idac.InsertUpdateDelete(sql);
                    if (obj != null && (int)obj != 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception)
                {
                    ret = false;
                }
                return ret;
            }




            public bool VerifyLogin(string name, string pwd)
            {
                bool ret = false;
                try
                {
                    string sql = "select username from dbo.Users where " +
                        "Username='" + name + "' and pass='" +
                        pwd + "'";
                    object obj = _idac.GetSingleAnswer(sql);
                    if (obj != null)
                    {
                        ret = true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return ret;
            }
        }
    }