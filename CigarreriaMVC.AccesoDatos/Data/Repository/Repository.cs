using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CigarreriaMVC.AccesoDatos.Data.Repository
    {
    public class Repository<T> : IRepository<T> where T : class
        {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository ( ApplicationDbContext db )
            {
            _db = db;
            dbSet = _db.Set<T> ( );
            }

        public T Get ( int id )
            {
            return dbSet.Find ( id );
            }

        public IEnumerable<T> GetAll (
            Expression<Func<T , bool>>? filtro = null ,
            string? includeProperties = null )
            {
            IQueryable<T> query = dbSet;

            if ( filtro != null )
                {
                query = query.Where ( filtro );
                }

            if ( !string.IsNullOrWhiteSpace ( includeProperties ) )
                {
                foreach ( var includeProp in includeProperties.Split (
                    new char [] { ',' } , StringSplitOptions.RemoveEmptyEntries ) )
                    {
                    query = query.Include ( includeProp );
                    }
                }

            return query.ToList ( );
            }

        public T GetFirstOrDefault (
            Expression<Func<T , bool>> filtro ,
            string? includeProperties = null )
            {
            IQueryable<T> query = dbSet.Where(filtro);

            if ( !string.IsNullOrWhiteSpace ( includeProperties ) )
                {
                foreach ( var includeProp in includeProperties.Split (
                    new char [] { ',' } , StringSplitOptions.RemoveEmptyEntries ) )
                    {
                    query = query.Include ( includeProp );
                    }
                }

            return query.FirstOrDefault ( );
            }

        public void Add ( T entidad )
            {
            dbSet.Add ( entidad );
            }

        public void Remove ( T entidad )
            {
            dbSet.Remove ( entidad );
            }

        public void Remove ( int id )
            {
            var entidad = dbSet.Find(id);
            if ( entidad != null )
                {
                Remove ( entidad );
                }
            }
        }
    }
