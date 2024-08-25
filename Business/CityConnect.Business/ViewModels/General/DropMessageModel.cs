using CityConnect.Business.Enums.General;

namespace CityConnect.Business.ViewModels.General
{
    public class DropMessageModel
    {
        public string Message { get; set; }

        public string Description { get; set; }

        public DropMessageType DropMessageType { get; set; }
    }
}