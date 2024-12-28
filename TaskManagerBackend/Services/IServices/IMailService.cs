namespace TaskManagerBackend.Services.IServices
{
    public interface IMailService
    {
        public bool passwordRecovery(string username , string password);
    }
}
