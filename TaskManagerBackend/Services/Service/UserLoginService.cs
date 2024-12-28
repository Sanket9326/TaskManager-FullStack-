using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Data.DataDbContext;
using TaskManagerBackend.Data.Dto;
using TaskManagerBackend.Data.Entity;
using TaskManagerBackend.Services.IServices;

namespace TaskManagerBackend.Services.Service
{
    public class UserLoginService : IUserLoginService
    {
        public readonly UserDbContext _context;
        public readonly IMailService _mailService;

        public UserLoginService(UserDbContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        public bool isUserExist(string username)
        {
            try
            {
                var result = _context.user.FromSqlRaw("Select * from [User] where Email = {0}", username);
                if (result.Any())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool login(string username, string password)
        {
            try
            {
                if (username == null || password == null)
                {
                    return false;
                }
                var res = _context.user.FromSqlRaw("Select * from [user] where Email = {0} AND Password = {1}", username, password);

                if (res.Any())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool addUser(NewUserDto user)
        {
            try
            {
                if (isUserExist(user.Email))
                {
                    return false;
                }

                User u = new User();
                u.Email = user.Email;
                u.Password = user.Password;
                u.FullName = user.FullName;
                u.Contact = user.Contact;
                _context.Add(u);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool passwordRecovery(string username)
        {
            try
            {
                if (!isUserExist(username))
                {
                    return false;
                }

                var user = _context.user.FromSqlRaw("Select * from [User] where Email = {0}", username).FirstOrDefault();

                if (user == null || string.IsNullOrEmpty(user.Password))
                {
                    return false;
                }

                _mailService.passwordRecovery(username, user.Password);
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
        }


        public bool deleteUser(int id)
        {
            try
            {
                var u = _context.user.Find(id);
                if (u != null) { 
                    _context.Remove(u);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
