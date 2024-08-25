namespace CityConnect.Interfaces.Background
{
    public interface IBackgroundMailerJobs : IBackgroundJobs
    {
        void SendWelcomeEmail();
    }
}