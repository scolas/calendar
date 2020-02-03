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
                DataTable obj2 = _idac.GetManyRowsCols(sql);
                DataSet obj = _idac.DataSetXEQDynamicSql(sql);
                DataTable dt = obj.Tables[0];

  
                foreach (DataRow row in obj.Tables[0].Rows)
                {
                    object[] data1 = row.ItemArray;
                    int id = (int)data1[0];
                    string date = data1[1].ToString();
                    string location = data1[2].ToString();
                    string name = data1[3].ToString();

                    Event tempEvent = new Event();
                    tempEvent.id = id;
                    tempEvent.location = location;
                    tempEvent.setBy = name;
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
                    string sql = "INSERT INTO[dbo].[Events] ([date], [location],[setBy]) VALUES ('" + dates + "' ,'" + location + "' ,'" + setBy + "')";


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
                    DateTime dates = DateTime.Now;
                    string location = events.location;
                    string setBy = events.setBy;
                    string sql = String.Format(@"UPDATE [dbo].[Events] set date = '{0}', location = '{1}', setBy = '{2}' where eventId = {3}",
                        dates,location,setBy, events.id);

                
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