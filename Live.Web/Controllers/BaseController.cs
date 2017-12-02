using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live.Web.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User GetCurrentUser()
        {
          return _unitOfWork.GetRepository<User,int>().GetFirstOrDefault(x => x.Name == User?.Identity?.Name);
        }
    }
}