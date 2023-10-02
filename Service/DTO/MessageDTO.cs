using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class MessageDTO
    {
        public decimal Id { get; set; }
        public decimal? Senderid { get; set; }
        public string? Senderusername { get; set; }
        public string? SenderPhotoUrl { get; set; }
        public decimal? Recipientid { get; set; }
        public string? Recipientusername { get; set; }
        public string? RecipientPhotoUrl { get; set; }
        public string? Content { get; set; }
        public DateTime? Dateread { get; set; }
        public DateTime? Messagesent { get; set; }
       

       
    }
}
