using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live.Web.Controllers
{
    public class FriendsController : BaseController
    {
        IRepository<User, int> _userRepository;
        public FriendsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<User, int>();
        }


        // GET: Frands
        public ActionResult Index()
        {
            return View(GetFriends());
        }
        [HttpPost]
        public ActionResult AddFriend(string name)
        {
            var newFrand = _userRepository.GetFirstOrDefault(x => x.Name == name);
            if (newFrand != null || !GetFriends().Contains(newFrand))
            {
                GetCurrentUser().Frands.Add(newFrand);
                _unitOfWork.SaveChanges();
            }
            return Index();
        }




        private List<User> GetFriends()
        {
            var user = GetCurrentUser();
            if (user == null)
                return new List<User>();
            return user.Frands;
        }
    }
}