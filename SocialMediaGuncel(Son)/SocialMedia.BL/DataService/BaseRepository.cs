using SocialMedia.DAL.Models.Data.Context;
using SocialMedia.DAL.Models.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.BL.DataService
{
    //Entitybaseden kalıtım alan sınıflar ve instance alınabilen sınıflara göre servisi filitrelemiş olduk
    public class BaseRepository<T> where T:EntityBase,new()
    {
        protected DbContext _db;
        protected DbSet<T> _dbset;

        public BaseRepository()
        {
            _db = new ProjectContext();
            _dbset = _db.Set<T>();
        }

        public virtual void Insert(T entity)
        {
            entity.IsActive = true;
            entity.IsDeleted = false;
            _dbset.Add(entity);
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var T = _dbset.Find(id);
            T.IsDeleted = true;
            T.IsActive = false;
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        //Aktif herşeyin listesi
        public IEnumerable<T> GetAll()
        {
            return _dbset.Where(x=> x.IsActive && !x.IsDeleted).AsEnumerable();
        }

        //verilen id ye göre aktif olan objenin kendisi
        public T FirstOrDefault(int id)
        {
            return _dbset.FirstOrDefault(x => x.IsActive && !x.IsDeleted && x.ID==id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> lamda)
        {
            return _dbset.FirstOrDefault(lamda);
        }

        public bool Any(Expression<Func<T, bool>> lamda)
        {
            return _dbset.Where(x=> x.IsActive && !x.IsDeleted).Any(lamda);
        }

        public IEnumerable<T> SelectMany(Expression<Func<T,bool>> _lamda)
        {
            return _dbset.Where(x => x.IsActive && !x.IsDeleted).Where(_lamda).AsEnumerable();
        } 


    }
}
