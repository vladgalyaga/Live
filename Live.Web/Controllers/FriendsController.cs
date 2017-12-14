using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live.Web.Controllers
{
    [Authorize]
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
            var a = GetFriends();
            return View(a);
        }
        [HttpPost]
        public void AddFriend(string name)
        {
          
                var newFrand = _userRepository.GetFirstOrDefault(x => x.Name == name);
                if (newFrand != null || !GetFriends().Contains(newFrand))
                {
                    var user = GetCurrentUser();
                    var frendShip = new Friendship()
                    {
                        User2_Id = user.Id,
                        User1_Id = newFrand.Id
                    };
                    _unitOfWork.GetRepository<Friendship, int>().Create(frendShip);
                }
                var a = _unitOfWork.GetRepository<Friendship, int>().GetAll();
           // return Index();
        }




        private List<User> GetFriends()
        {
            var friends = GetFriends(GetCurrentUser().Id);
           return friends;
        }
    }
}