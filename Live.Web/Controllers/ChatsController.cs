using Common.ViewModels;
using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Live.Web.Controllers
{
    public class ChatsController : BaseController
    {

        IRepository<Chat, int> _chatRepository;
        public ChatsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _chatRepository = unitOfWork.GetRepository<Chat, int>();
        }
        // GET: Chants
        public ActionResult Index()
        {

            //var chats = GetChatsForUser(GetCurrentUser().Id);
            var chats = GetCurrentUser().Chats;
            var chatsViewModel = chats.Select(x => new ChatViewModel() { Id = x.Id, Name = GetChatName(x) }).ToList();

            return View(chatsViewModel);
        }
        [HttpPost]
        public ActionResult Create(Chat chat)
        {
            var user = _unitOfWork.GetRepository<User, int>().GetFirstOrDefault(x => x.Name == User?.Identity?.Name);
            Chat newChat = new Chat()
            {
                Users = chat.Users,
                Name = chat.Name,
            };
            newChat.Users.Add(user);
            _chatRepository.Create(newChat);
            return Index();
        }
        public ActionResult Show(int userId)
        {
            var user = GetCurrentUser();
            var chats = _chatRepository.GetAll() ;
            var chat = chats.FirstOrDefault(x => x.Users.First().Id == userId);
          
            if (chat == null)
            {
                chat = new Chat()
                {
                 
                    Users = new List<DAL.DataBase.User>() { _unitOfWork.GetRepository<User, int>().Find(userId) }
                };
                chat.Users.Add(user);
                _chatRepository.Create(chat);
            }


            return View(chat);

        }
        public ActionResult Chat(int chatId)
        {
            //for mapping Autor of message
            var users = _unitOfWork.GetRepository<User, int>().GetAll();

            Chat res = _chatRepository.Find(chatId);
            return View("show", res);

        }
        [HttpPost]
        public void SentMessage(string text, int chatId)
        {
            var rep = _unitOfWork.GetRepository<Message, int>();
            var chat = _chatRepository.Find(chatId);
            Message message = new Message()
            {
                Author = GetCurrentUser(),
                Text = text,
                Chat = chat
            };
            rep.Create(message);
        }
        private List<Chat> GetChatsForUser(int userId)
        {
            User user = _unitOfWork.GetRepository<User, int>().Find(userId);
            var chats = new List<Chat>();
            chats.AddRange(_chatRepository.GetWhere(x => x.Users.Contains(user)));
            return chats;
        }
        private string GetChatName(Chat chat)
        {
            if (chat.Name != null)
                return chat.Name;
       
            string[] names = chat.Users?.Select(x => x.Name).ToArray();
            return string.Join(", ", names);
           
        }
        //[HttpGet]
        //public List<User> GetFriendsForNewChat()
        //{
        //    var user = GetCurrentUser();
        //    var friends = user.Friendships;
        //    var ls = user.Chats.Where(x => x.Users.Count == 1);
        //    friends = friends.Where(x => ls.All(c => !c.Users.Contains(x))).ToList();

        //    return friends;
        //}
    }
}