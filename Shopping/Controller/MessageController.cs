using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Helpers;
using Service.IService;
using Service.Extentions;
using Domain.Models;
using AutoMapper;

namespace Shopping.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;

        public MessageController(IUnitOfWorkService unitOfWorkService, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult<MessageDTO> CreateMessage(CreateMessageDto createMessageDto)
        {
            var UserName = User.GetUserName();
            if (UserName == createMessageDto.RecipientUserName.ToLower()) {
                return BadRequest("You can't send a message to your self");
            }
            var sender = _unitOfWorkService.UserService.SearchByusername(UserName);
            var recipient = _unitOfWorkService.UserService.SearchByusername(createMessageDto.RecipientUserName);
            if (recipient == null) { return NotFound(); }
            var message = new Message
            {
                Sender = sender,
                Recipient = recipient,
                Senderusername = sender.Username,
                Recipientusername = createMessageDto.RecipientUserName,
                Content = createMessageDto.Content
            };
            _unitOfWorkService.MessageService.add(message);
            _unitOfWorkService.Save();
            return Ok(_mapper.Map<MessageDTO>(message));

        }
        [HttpGet]
        public ActionResult<PagedList<MessageDTO>> GetMessagesForUser([FromQuery]MessageParams messageParams)
        {
            messageParams.UserName = User.GetUserName();
           var message= _unitOfWorkService.MessageService.GetMessagesForUser(messageParams);

            Response.AddPagenationHeader(header: new PaginationHeader
                (message.CurrentPage, message.PageSize, message.TotalCount, message.TotalPages));

            return message;

        }
        [HttpGet("thread/{userName}")]
        public ActionResult<IEnumerable<MessageDTO>> GetMesaageThread(string userName)
        {
           var CurrentUserName = User.GetUserName();
            return Ok( _unitOfWorkService.MessageService.GetMessageThread(CurrentUserName, userName));
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMessage(decimal id)
        {
            var username = User.GetUserName();
            _unitOfWorkService.MessageService.DeleteMessage(id, username);
           
            return Ok();
        }
    }
}
