using Domain.Models;
using Service.DTO;
using Service.Helpers;

namespace Service.IService
{
    public interface IMessageService :IService<Message>
    {
        MessageDTO CreateMessage(CreateMessageDto createMessageDto);
        PagedList<MessageDTO> GetMessagesForUser(MessageParams messageParams);
        IEnumerable<MessageDTO> GetMessageThread(string currentUserName, string RecipientName);
        Message GetMessageById(decimal id);
        void DeleteMessage(decimal id,string username);

    

    }
}
