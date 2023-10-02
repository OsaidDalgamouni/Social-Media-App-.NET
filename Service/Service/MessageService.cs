using AutoMapper;
using Domain.Models;
using Repository.IRepository;
using Service.DTO;
using Service.Helpers;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void add(Message item)
        {
           _unitOfWork.Message.AddMessage(item);
        }

        public MessageDTO CreateMessage(CreateMessageDto createMessageDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(decimal id, string username)
        {
            var message = _unitOfWork.Message.GetFirstOrDefualt(X => X.Id == id);

            if (message.Senderusername != username && message.Recipientusername != username) return;
            if (message.Senderusername == username) message.Senderdeleted = true;
            if (message.Recipientusername == username) message.Recipientdeleted = true;
            if (message.Senderdeleted && message.Recipientdeleted)
            {
                _unitOfWork.Message.Remove(message);

            }
            _unitOfWork.Message.Update(message);
            _unitOfWork.Save();
        }

            public IEnumerable<Message> GetAll(string? Includeproperities = null)
        {
            throw new NotImplementedException();
        }

        public Message GetbyId(Expression<Func<Message, bool>> filter, string? Includeproperities = null)
        {
            return _unitOfWork.Message.GetFirstOrDefualt(filter);
        }

        public Message GetMessageById(decimal id)
        {
            return _unitOfWork.Message.GetFirstOrDefualt(x => x.Id == id);
        }

        public PagedList<MessageDTO> GetMessagesForUser(MessageParams messageParams)
        {
            var query = _unitOfWork.Message.GetMessagesForUser();

            query = messageParams.Container switch
            {
               "Inbox" => query.Where(u => u.Recipientusername == messageParams.UserName && u.Recipientdeleted==false),
               "Outbox" => query.Where(u => u.Senderusername == messageParams.UserName && u.Senderdeleted==false),
               _=>query.Where(u=>u.Recipientusername==messageParams.UserName
              &&u.Recipientdeleted==false  && u.Dateread==null)
            };
            query.ToList();
            var MessageToReturn = _mapper.Map<IEnumerable<MessageDTO>>(query);
            return PagedList<MessageDTO>.Create(MessageToReturn, messageParams.PageNumber, messageParams.PageSize);
        }

        public IEnumerable<MessageDTO> GetMessageThread(string currentUserName, string RecipientName)
        {
            var Message=_unitOfWork.Message.GetMessageThread(currentUserName, RecipientName);
            var messageToReturn= _mapper.Map<IEnumerable<MessageDTO>>(Message);
            return messageToReturn;
        }

        public void Remove(Message item)
        {
            _unitOfWork.Message.Remove(item);
        }

        public void update(Message item)
        {
            throw new NotImplementedException();
        }
    }
}
