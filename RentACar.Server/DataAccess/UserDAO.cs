using RentACar.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentACar.Shared.Models;

namespace RentACar.Server.DataAccess 
{
    public class UserDAO : BaseDAO 
    {
        public IEnumerable<User> GetAllUsers () 
        {
            return TryDatabaseQuery(() => db.UserInfo.ToList());
        }

        public void AddUser (User user) 
        {
            TryDatabaseQuery(() => {
                db.UserInfo.Add (user);
                db.SaveChanges ();
            });
        }

        public void UpdateUser (User user) 
        {
            TryDatabaseQuery(() => {
                db.Entry (user).State = EntityState.Modified;
                db.SaveChanges ();
            });
        }

        public User GetUserByEmail(string email) => TryDatabaseQuery(() => db.UserInfo.Where(u => u.Email.Equals(email)).Single());

        public User GetUserById(int id) => TryDatabaseQuery(() => db.UserInfo.Find (id));

        public void DeleteById (int id) 
        {
            TryDatabaseQuery(() => {
                User user = db.UserInfo.Find (id);
                db.UserInfo.Remove (user);
                db.SaveChanges ();
            });
        }
    }
}