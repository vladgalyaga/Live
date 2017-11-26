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
        public ChatsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Chants
        public ActionResult Index()
        {
            var userRep = _unitOfWork.GetRepository<User, int>();
            var user = userRep.GetSingleOrDefault(x => x.Name == User.Identity.Name);
            var Chats = user?.Chats;
            return View(Chats);
        }

    }
}