using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live.Web.Controllers
{
    public class ProfileController : Controller
    {
        IUnitOfWork _unitOfWork;
        public ProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Profile
        public ActionResult Index()
        {
            User user = _unitOfWork.GetRepository<User, int>().GetFirstOrDefault(x => x.Email == User.Identity.Name);


            return View();
        }
    }
}