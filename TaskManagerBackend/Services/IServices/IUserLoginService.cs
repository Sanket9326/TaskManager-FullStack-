using Microsoft.AspNetCore.Mvc;
using TaskManagerBackend.Data.Dto;
using TaskManagerBackend.Data.Entity;

namespace TaskManagerBackend.Services.IServices
{
    public interface IUserLoginService
    {
        public bool isUserExist(string username);
        public  bool login(string username, string password);

        public bool addUser(NewUserDto newUser);

        public bool passwordRecovery(string username);

        public bool deleteUser(int id);
    }
}
