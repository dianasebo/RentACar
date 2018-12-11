using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RentACar.Server.DataAccess;
using RentACar.Shared.Models;

namespace RentACar.Server.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageDAO messageDAO = new MessageDAO();

        [Authorize]
        [HttpGet]
        [Route("api/Messages/{userId}")]
        public IEnumerable<Message> GetMessagesForUser(int userId)
        {
            return messageDAO.GetMessagesForUser(userId);
        }

        [Authorize]
        [HttpPost]
        [Route("api/Messages/Send")]
        public GenericResponse SendMessage([FromBody] Message message)
        {
            if (!ModelState.IsValid)
                return new GenericResponse { IsSuccessful = false };

            messageDAO.AddMessage(message);
            return new GenericResponse { IsSuccessful = true };
        }
    }
}
