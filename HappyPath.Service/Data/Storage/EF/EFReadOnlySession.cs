using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPath.Service.Data.Storage.EF
{
    public class EFReadOnlySession : IReadOnlySession
    {
        ObjectContext _context;
        public EFReadOnlySession(ObjectContext context)
        {
            _context = context;
        }
        string GetSetName<T>()
        {
            var entitySetProperty =
            _context.GetType().GetProperties()
               .Single(p => p.PropertyType.IsGenericType && typeof(IQueryable<>)
               .MakeGenericType(typeof(T)).IsAssignableFrom(p.PropertyType));

            return entitySetProperty.Name;
        }
        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new()
        {
            return new ObjectQuery<T>(GetSetName<T>(), _context, MergeOption.NoTracking).SingleOrDefault();
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            return new ObjectQuery<T>(GetSetName<T>(), _context, MergeOption.NoTracking);
        }
    }
}
