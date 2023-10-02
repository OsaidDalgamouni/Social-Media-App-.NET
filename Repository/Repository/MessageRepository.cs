using Domain.Models;
using Repository.IRepository;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly ModelContext _db;
        public MessageRepository(ModelContext db) : base(db)
        {
            _db = db;
        }

        public void AddMessage(Message message)
        {
            _db.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _db.Messages.Remove(message);
        }

        public Message GetMessage(int id)
        {
            return _db.Messages.Find(id);
        }

        public IEnumerable<Message> GetMessagesForUser()
        {
            var query = _db.Messages.Include(x => x.Sender).ThenInclude(x => x.Photos).Include(x => x.Recipient).ThenInclude(x => x.Photos).OrderByDescending(x => x.Messagesent).AsQueryable();
            return query;
        }

        public IEnumerable<Message> GetMessageThread(string currentUserName, string RecipientName)
        {
            var messages = _db.Messages.Where(
                m => m.Recipientusername == currentUserName && m.Senderusername == RecipientName &&m.Recipientdeleted==false
                || m.Recipientusername == RecipientName && m.Senderusername == currentUserName && m.Senderdeleted==false)
                 .OrderBy(m => m.Messagesent).AsNoTracking().ToList();

            var unreadMessage = messages.Where(x => x.Dateread == null && x.Recipientusername == currentUserName).ToList();
            if (unreadMessage.Any())
            {
                var temp = unreadMessage;
                foreach (var message in temp)
                {
                    message.Dateread = DateTime.Now;
                }
                _db.Messages.UpdateRange(temp);


                _db.SaveChanges();
            }
            return _db.Messages.Include(x => x.Sender).ThenInclude(u => u.Photos).Include(z => z.Recipient)
                 .ThenInclude(y => y.Photos).Where(
                m => m.Recipientusername == currentUserName && m.Senderusername == RecipientName && m.Recipientdeleted == false
                || m.Recipientusername == RecipientName && m.Senderusername == currentUserName && m.Senderdeleted == false)
                 .OrderBy(m => m.Messagesent).AsNoTracking().ToList();
        }
    }
}
