using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyPath.Service.Data.Storage.EFCF
{
    public class EFCFReadOnlySession : IReadOnlySession
    {
        DbContext _context;
        public EFCFReadOnlySession(DbContext context)
        {
            _context = context;

            _context.Configuration.AutoDetectChangesEnabled = false;
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            return All<T>().FirstOrDefault(expression);
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            return _context.Set<T>().AsQueryable<T>();
        }
    }
}
