using MyEvernote.Common;
using MyEvernote.Core.DataAccess;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.DataAccessLayer.MySql
{
    //public class Repository<T> where T : class
    public class Repository<T> : RepositoryBase,IDataAccess<T> where T : class
    {
        //private DatabaseContext db;
        private DbSet<T> _objectSet;
        public Repository()
        {
            //db = RepositoryBase.CreateContext();
            _objectSet = context.Set<T>();
        }
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }
        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        /*Kullanıcı ya da yazılımcı istediği zaman istediği şekilde DB den çağırması gerektiğinde ((ilk 5i,ilk 10u gibi)...
    -o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-
        public IQueryable<T> List(Expression<Func<T, bool>> where)
        {
           return _objectSet.Where(where);
        }
    -o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-
        */
        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            if(obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                DateTime now = DateTime.Now;

                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = App.Common.GetCurrentUsername();   //TODO: İşlem yapan kullanıcı adı yazılmalı..
            }
            return Save();
        }
        public int Update(T obj)
        {
            if (obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                DateTime now = DateTime.Now;

                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = App.Common.GetCurrentUsername(); //TODO: İşlem yapan kullanıcı adı yazılmalı..
            }
            return Save();
        }
        public int Delete(T obj)
        {
            //if (obj is MyEntityBase)
            //{
            //    MyEntityBase o = obj as MyEntityBase;
            //    DateTime now = DateTime.Now;

            //    o.ModifiedOn = now;
            //    o.ModifiedUsername = App.Common.GetUsername(); //TODO: İşlem yapan kullanıcı adı yazılmalı..              
            //}
            _objectSet.Remove(obj);
            return Save();
        }
    public int Save()
        {
            return context.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }

    }

}
