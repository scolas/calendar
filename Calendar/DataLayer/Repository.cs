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
                string sql = "select * from dbo.Event";
                DataTable obj = _idac.GetManyRowsCols(sql);
                if (obj != null)
                {
                    foreach(DataRow e in obj.Rows)
                    {
                        
                        //ret.Add(e);
                    }
                    
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



                    /*string sql = "select username from dbo.Users where " +
                        "Username='" + name + "' and pass='" +
                        pwd + "'";*/
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

            public bool UpdateEvent(Event events)
            {
                throw new NotImplementedException();
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