using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live.Web.Controllers
{
    public class ChatsController : Controller
    {

        IUnitOfWork _unitOfWork;
        IRepository<Chat, int> _chatRepository;
        public ChatsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
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
    }
}