﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyPath.Service.Data
{
    public interface IReadOnlySession
    {
        T Single<T>(Expression<Func<T, bool>> expression) where T : class, new();
        System.Linq.IQueryable<T> All<T>() where T : class, new();
    }
}
