using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RentACar.Shared.Models
{
    public class Message
    {
        [Required] [Column("id")] public int MessageId { get; set; }
        [Required] [Column("sender")] public int SenderId { get; set; }
        [Required] [Column("receiver")] public int ReceiverId { get; set; }
        [Required] [Column("text")] public string Text { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required] [Column("timestamp")] public DateTime Timestamp { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
