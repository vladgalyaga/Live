using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var userRep = _unitOfWork.GetRepository<User, int>();
            var user = userRep.GetSingleOrDefault(x => x.Name == User.Identity.Name);
            var Chats = user?.Chats;
            return View(Chats);
        }
        [HttpPost]
        public ActionResult Create(Chat chat)
        {
            var user = _unitOfWork.GetRepository<User, int>().GetFirstOrDefault(x => x.Name == User?.Identity?.Name);
            Chat newChat = new Chat()
            {
                Creator = user,
                Users = chat.Users,
                Name = chat.Name,
            };
            _chatRepository.Create(newChat);
            return Index();
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