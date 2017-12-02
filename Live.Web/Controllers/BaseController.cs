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
    public class BaseController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User GetCurrentUser()
        {
            return _unitOfWork.GetRepository<User, int>().GetFirstOrDefault(x => x.Name == User?.Identity?.Name);
        }
        public User GetUser(int id)
        {
            var rep = _unitOfWork.GetRepository<User, int>();
            return rep.Find(id);
        }
        public List<User> GetFriends(int id)
        {
            
            var rep = _unitOfWork.GetRepository<Friendship, int>();
            var a = rep.GetAll();

            List<int> friends = new List<int>();
            
            friends.AddRange(rep.GetWhere(x => x.User1_Id == id)?.Select(x => x.User2_Id));
            friends.AddRange(rep.GetWhere(x => x.User2_Id == id)?.Select(x => x.User1_Id));
            return _unitOfWork.GetRepository<User, int>().GetWhere(x=> friends.Contains(x.Id));
        }
    }
}