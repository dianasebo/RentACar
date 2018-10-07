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
            return TryDatabaseQuery(() => db.Users.ToList());
        }

        public void AddUser (User user) 
        {
            TryDatabaseQuery(() => {
                db.Users.Add (user);
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

        public User GetUserById (int id) 
        {
            return TryDatabaseQuery(() => db.Users.Find (id));
        }

        public void DeleteById (int id) 
        {
            TryDatabaseQuery(() => {
                User user = db.Users.Find (id);
                db.Users.Remove (user);
                db.SaveChanges ();
            });
        }
    }
}