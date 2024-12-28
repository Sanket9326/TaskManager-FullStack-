using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Data.DataDbContext;
using TaskManagerBackend.Data.Dto;
using TaskManagerBackend.Data.Entity;
using TaskManagerBackend.Services.IServices;

namespace TaskManagerBackend.Services.Service
{
    public class AdminLogin : IAdminLogin
    {
        public UserDbContext _context;
        public AdminLogin(UserDbContext context)
        {
           _context = context;
        }

 
        public bool Login(string Email, string Password)
        {
            try
            {
                var res = _context.admins.Where(record => record.Email.Equals(Email) && record.Password.Equals(Password));
                return res.Any();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool addAdmin(NewUserDto dto)
        {
            try
            {
                Admin admin = new Admin();
                admin.Email = dto.Email;
                admin.Password = dto.Password;
                admin.FullName = dto.FullName;
                admin.Contact = dto.Contact;

                _context.admins.Add(admin);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
