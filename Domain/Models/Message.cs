using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Message
    {
        public decimal Id { get; set; }
        public decimal? Senderid { get; set; }
        public string? Senderusername { get; set; }
        public decimal? Recipientid { get; set; }
        public string? Recipientusername { get; set; }
        public string? Content { get; set; }
        public DateTime? Dateread { get; set; }
        public DateTime? Messagesent { get; set; }
        public bool Senderdeleted { get; set; }
        public bool Recipientdeleted { get; set; }

        public virtual User? Recipient { get; set; }
        public virtual User? Sender { get; set; }
    }
}
