using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CigarreriaMVC.AccesoDatos.Data.Repository
    {
    public interface IRepository<T> where T : class
        {
        T Get ( int id );

        IEnumerable<T> GetAll (
            Expression<Func<T , bool>>? filtro = null ,
            string? includeProperties = null );   // "Prop1,Prop2"

        T GetFirstOrDefault (
            Expression<Func<T , bool>> filtro ,
            string? includeProperties = null );

        void Add ( T entidad );
        void Remove ( T entidad );
        void Remove ( int id );
        }
    }
