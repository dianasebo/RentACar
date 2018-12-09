using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Shared.Models
{
    public class Message
    {
        [Required] [Column("id")] public int MessageId { get; set; }
        [Required] [Column("sender")] public int SenderId { get; set; }
        [Required] [Column("receiver")] public int ReceiverId { get; set; }
        [Required] [Column("text")] public string Text { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
