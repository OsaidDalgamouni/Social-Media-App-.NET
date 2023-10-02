using Domain.Models;

namespace Repository.IRepository
{
    public interface IMessageRepository : IRepository<Message>
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Message GetMessage(int id);
        IEnumerable<Message> GetMessagesForUser();
        IEnumerable<Message> GetMessageThread(string currentUserName,string RecipientName);
    }
}
