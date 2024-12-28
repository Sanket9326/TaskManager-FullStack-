using TaskManagerBackend.Data.Dto;

namespace TaskManagerBackend.Services.IServices
{
    public interface IAdminLogin
    {
        public bool Login(string Username,string Password);

        public bool addAdmin(NewUserDto Admin);
    }
}
