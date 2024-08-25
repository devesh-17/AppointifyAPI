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
            PersonRepository = new PersonRepository(Context);
            RoleRepository = new RoleRepository(Context);
            ModuleRepository = new ModuleRepository(Context);
            RoleModuleRepository = new RoleModuleRepository(Context);
            AccessModuleRepository = new AccessModuleRepository(Context); 

AspNetRoleClaimsRepository = new AspNetRoleClaimsRepository(Context); 

AspNetRolesRepository = new AspNetRolesRepository(Context); 

AspNetUserClaimsRepository = new AspNetUserClaimsRepository(Context); 

AspNetUserLoginsRepository = new AspNetUserLoginsRepository(Context); 

AspNetUserRolesRepository = new AspNetUserRolesRepository(Context); 

AspNetUsersRepository = new AspNetUsersRepository(Context); 

AspNetUserTokensRepository = new AspNetUserTokensRepository(Context); 

ModuleRepository = new ModuleRepository(Context); 

PersonRepository = new PersonRepository(Context); 

RoleRepository = new RoleRepository(Context); 

RoleModuleRepository = new RoleModuleRepository(Context); 

            
        }        
        public IPersonRepository PersonRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IModuleRepository ModuleRepository { get; }
        public IAccessModuleRepository AccessModuleRepository { get; }
        public IRoleModuleRepository RoleModuleRepository { get; }

        public IAccessModuleRepository AccessModuleRepository { get; }

public IAspNetRoleClaimsRepository AspNetRoleClaimsRepository { get; }

public IAspNetRolesRepository AspNetRolesRepository { get; }

public IAspNetUserClaimsRepository AspNetUserClaimsRepository { get; }

public IAspNetUserLoginsRepository AspNetUserLoginsRepository { get; }

public IAspNetUserRolesRepository AspNetUserRolesRepository { get; }

public IAspNetUsersRepository AspNetUsersRepository { get; }

public IAspNetUserTokensRepository AspNetUserTokensRepository { get; }

public IModuleRepository ModuleRepository { get; }

public IPersonRepository PersonRepository { get; }

public IRoleRepository RoleRepository { get; }

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