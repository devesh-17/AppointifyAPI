using CityConnect.Domain;
using CityConnect.Interfaces.Repositories;
using CityConnect.Repositories;
using System;

namespace CityConnect.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CityConnectContext Context;

        public UnitOfWork(CityConnectContext context)
        {
            this.Context = context;
            RoleRepository = new RoleRepository(Context);
            ModuleRepository = new ModuleRepository(Context);
            RoleModuleRepository = new RoleModuleRepository(Context);
            AccessModuleRepository = new AccessModuleRepository(Context);
        }
        public IRoleRepository RoleRepository { get; }
        public IModuleRepository ModuleRepository { get; }
        public IAccessModuleRepository AccessModuleRepository { get; }
        public IRoleModuleRepository RoleModuleRepository { get; }
        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                Context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}