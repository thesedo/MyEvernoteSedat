using MyEvernote.DataAccessLayer;
using MyEvernote.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.DataAccessLayer.MySql
{
    public class RepositoryBase
    {
        //private static DatabaseContext _db;
        protected static DatabaseContext context;
        private static object _lockSync = new object();
        protected RepositoryBase()
        {
            //db = CreateContext();
            CreateContext();
        }

        //private static DatabaseContext CreateContext()
        private static void CreateContext()
        {
            if (context == null)
            {
                lock (_lockSync)
                {
                    if (context == null)
                    {
                        context = new DatabaseContext();
                    }           
                }
                
            }
            //return db;
        }
    }
}
