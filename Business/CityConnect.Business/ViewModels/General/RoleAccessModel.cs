using CityConnect.Business.Enums.General;

namespace CityConnect.Business.ViewModels.General
{
    public class RoleAccessModel
    {
        public RoleAccessModel(ModuleEnum module, AccessTypeEnum accessType)
        {
            Module = module;
            AccessType = accessType;
        }
        public ModuleEnum Module { get; set; }

        public AccessTypeEnum AccessType { get; set; }
    }
}
