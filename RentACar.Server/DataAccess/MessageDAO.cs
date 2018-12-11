using System.Collections.Generic;
using RentACar.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RentACar.Server.DataAccess {
    public class MessageDAO : BaseDAO {
        public IEnumerable<Message> GetMessagesForUser(int userId) => TryDatabaseQuery(() => db.Messages.Where(m => m.SenderId == userId || m.ReceiverId == userId).Include(m => m.Sender).Include(m => m.Receiver));

        public void AddMessage(Message message)
        {
            TryDatabaseQuery(() => 
                {
                    db.Messages.Add (message);
                    db.SaveChanges ();
                });
        }
    }
}