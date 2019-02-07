using QLSoTietKiem.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace QLSoTietKiem.DAO
{
    public interface IBase<T> where T : class
    {
        T Add(T entity);
        IEnumerable<T> GetAll(string[] includes = null);
        T GetById(int id);
        T GetSingleByCondition(Expression<Func<T, bool>> Expression, string[] includes = null);
        T Delete(int id);
        T Delete(T entity);
        void Update(T entity);

    }
    public abstract class Base<T> : IBase<T> where T : class
    {
        private QLSoTietKiemDBContext _dataContext;
        private readonly IDbSet<T> _dataSet;
        protected QLSoTietKiemDBContext DbContext
        {
            get { return _dataContext ?? (_dataContext = new QLSoTietKiemDBContext()); }
        }
        public T Add(T entity)
        {
            return _dataSet.Add(entity);
        }
        public T Delete(int id)
        {
            var _entity = _dataSet.Find(id);
            return _dataSet.Remove(_entity);
        }
        public T Delete(T entity)
        {
            return _dataSet.Remove(entity);
        }
        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return query.AsQueryable();
            }
            return _dataContext.Set<T>().AsQueryable();
        }
        public T GetById(int id)
        {
            return _dataSet.Find(id);  
        }
        public void Update(T entity)
        {
            _dataSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        public T GetSingleByCondition(Expression<Func<T, bool>> Expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return query.FirstOrDefault(Expression);
            }
            return _dataContext.Set<T>().FirstOrDefault(Expression);
        }
    }
}
