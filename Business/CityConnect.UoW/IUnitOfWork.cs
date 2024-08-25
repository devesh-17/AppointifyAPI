using CityConnect.Interfaces.Repositories;
using System;

namespace CityConnect.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        IRoleRepository RoleRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IAccessModuleRepository AccessModuleRepository { get; }
        IRoleModuleRepository RoleModuleRepository { get; }
        IAccessModuleRepository AccessModuleRepository { get; }

IAspNetRoleClaimsRepository AspNetRoleClaimsRepository { get; }

IAspNetRolesRepository AspNetRolesRepository { get; }

IAspNetUserClaimsRepository AspNetUserClaimsRepository { get; }

IAspNetUserLoginsRepository AspNetUserLoginsRepository { get; }

IAspNetUserRolesRepository AspNetUserRolesRepository { get; }

IAspNetUsersRepository AspNetUsersRepository { get; }

IAspNetUserTokensRepository AspNetUserTokensRepository { get; }

IModuleRepository ModuleRepository { get; }

IPersonRepository PersonRepository { get; }

IRoleRepository RoleRepository { get; }

IRoleModuleRepository RoleModuleRepository { get; }


        
    }
}