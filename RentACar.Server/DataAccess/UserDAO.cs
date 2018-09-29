using RentACar.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentACar.Shared.Models;

namespace RentACar.Server.DataAccess {
    public class UserDAO {
        RentACarContext db = new RentACarContext ();

        public IEnumerable<User> GetAllUsers () {
            try {
                return db.Users.ToList ();
            } catch {
                throw;
            }
        }

        public void AddUser (User user) {
            try {
                db.Users.Add (user);
                db.SaveChanges ();
            } catch {
                throw;
            }
        }

        public void UpdateUser (User user) {
            try {
                db.Entry (user).State = EntityState.Modified;
                db.SaveChanges ();
            } catch {
                throw;
            }
        }

        public User GetUserById (int id) {
            try {
                User user = db.Users.Find (id);
                return user;
            } catch {
                throw;
            }
        }

        public void DeleteById (int id) {
            try {
                User user = db.Users.Find (id);
                db.Users.Remove (user);
                db.SaveChanges ();
            } catch {
                throw;
            }
        }
    }
}