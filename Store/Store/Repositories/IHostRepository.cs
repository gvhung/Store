﻿/*
 * Created by: Kassym Gapur
 * Created: 26.01.2015
 */

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Store.Repositories
{
    public interface IHostRepository
    {
        IEnumerable<T> Set<T>(Expression<Func<T, bool>> lamda) where T : class;
        IEnumerable<TE> Set<T, TE>(Expression<Func<T, bool>> lamda)
            where T : class
            where TE : class;
        T Entity<T>(Expression<Func<T, bool>> lamda) where T : class;
        IEnumerable<TE> Set<T, TE>(Expression<Func<T, TE>> lamda)
            where T : class
            where TE : class;

        T Add<T>(T entity) where T : class;
        bool Add<T>(ref T entity) where T : class;
        bool Add<T>(IEnumerable<T> entities) where T : class;
        bool Add<T, TS, TT>(T firstEntity, TS secondEntity, TT thirdEntity)
            where T : class
            where TS : class
            where TT : class;

        T Update<T>(T entity) where T : class;
        bool Update<T>(ref T entity) where T : class;

        bool Delete<T>(T entity) where T : class;
        bool Delete<T, TS, TT>(T firstEntity, TS secondEntity, TT thirdEntity)
            where T : class
            where TS : class
            where TT : class;

        IDisposable Context();
    }
}