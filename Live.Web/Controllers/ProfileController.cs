using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Live.Web.Controllers
{
    public class ProfileController : BaseController
    {
        IRepository<User, int> _userREpository;
        byte[] m_photo;
        public ProfileController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

            _userREpository = unitOfWork.GetRepository<User, int>();


            WebClient webClient = new WebClient();
            m_photo = webClient.DownloadData("https://pp.userapi.com/c314424/v314424856/4893/1Zt8KXbMRqo.jpg");

        }
        // GET: Profile
        public ActionResult Index()
        {
            User user = _unitOfWork.GetRepository<User, int>().GetFirstOrDefault(x => x.Name == User.Identity.Name);


           return View(user);
        }
        public async Task<FileContentResult> GetImageById(int Id)
        {
            // Products prod = m_storeRepository.GetProduct(productId);
            var user = await _userREpository.FindByIdAsync(Id);
            if (user.Photo != null)
            {
                return new FileContentResult(System.IO.File.ReadAllBytes(user.Photo), "image/jpeg");
            }
            else
            {
                return new FileContentResult(m_photo, "image/jpeg");
            }
        }
        public ActionResult ShowProfile(int id)
        {
            var user = _userREpository.Find(id);

            return View("Index",user);
        }

    }
}