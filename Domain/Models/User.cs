using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            LikeSourceusers = new HashSet<Like>();
            LikeTargetusers = new HashSet<Like>();
            MessageRecipients = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
            Photos = new HashSet<Photo>();
        }

        public decimal Id { get; set; }
        public string? Username { get; set; }
        public byte[]? Hashpassword { get; set; }
        public byte[]? Saltpassword { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string? Knownas { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Lastactive { get; set; }
        public string? Gender { get; set; }
        public string? Introduction { get; set; }
        public string? Lookingfor { get; set; }
        public string? Interests { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Like> LikeSourceusers { get; set; }
        public virtual ICollection<Like> LikeTargetusers { get; set; }
        public virtual ICollection<Message> MessageRecipients { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
