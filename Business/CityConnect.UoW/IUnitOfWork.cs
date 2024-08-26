using CityConnect.Interfaces.Repositories;
using System;

namespace CityConnect.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository RoleRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IAccessModuleRepository AccessModuleRepository { get; }
        IRoleModuleRepository RoleModuleRepository { get; }
    }
}