using HappyPath.Service.Data.Storage;
using HappyPath.Service.Data.Storage.EFCF;
using HappyPath.Service.Data.Storage.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPath.Service.Data.Context
{
    public interface IHappyPathSession : ISession { }

    public class HappyPathSession : EFCFSession, IHappyPathSession
    {
        public HappyPathSession() : base(new HappyPathContext()) { }
    }

    public class HappyPathInMemorySession : InMemorySession, IHappyPathSession
    {
    }

    public interface IHappyPathReadOnlySession : IReadOnlySession { }

    public class HappyPathReadOnlySession : EFCFReadOnlySession, IHappyPathReadOnlySession
    {
        public HappyPathReadOnlySession() : base(new HappyPathContext()) { }
    }
}
