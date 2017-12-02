using Common.ViewModels;
using Dal.Core.Interfaces;
using Live.BLL;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Live.Web.Controllers
{
    public class HappeningController : Controller
    {

        IUnitOfWork _unitOfWork;
        int _pageSize = 18;
        IRepository<Happening, int> _happeningRepository;
        CityManager _cityManager;
        string _photo = "someUrl";
        WebClient _webClient = new WebClient();
        byte[] m_photo;
        public HappeningController(IUnitOfWork unitOfWork, CityManager cityManager)
        {
            _unitOfWork = unitOfWork;
            _happeningRepository = unitOfWork.GetRepository<Happening, int>();
            _cityManager = cityManager;

            m_photo = _webClient.DownloadData("http://www.mencapliverpool.org.uk/wp-content/uploads/2014/12/activities.png");

        }
        // GET: Event
        public ActionResult Index()
        {
            return GetHappenings();
        }
        public async Task<FileContentResult> GetImageEventById(int Id)
        {
            // Products prod = m_storeRepository.GetProduct(productId);
            Happening happaning = await _unitOfWork.GetRepository<Happening, int>().FindByIdAsync(Id);
            if (happaning.PhotoUrl != null)
            {
                return new FileContentResult(_webClient.DownloadData(happaning.PhotoUrl), "image/jpeg");
            }
            else
            {
                return new FileContentResult(m_photo, "image/jpeg");
            }
        }
        [HttpGet]
        public ActionResult AddHappening()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHappening(HappeningViewModel happeningViewModel)
        {
            var a = _unitOfWork.GetRepository<User, int>().GetFirstOrDefault(x => x.Name == User?.Identity?.Name);
            Happening happening = new Happening()
            {
                City = _cityManager.GetOrCreateCity(happeningViewModel.City),
                Creater = a,
                EventType = _cityManager.GetOrCreateHappeningType(happeningViewModel.EventType),
                Name = happeningViewModel.Name,
                PhotoUrl = happeningViewModel.PhotoUrl,
                TimeOfConduction = happeningViewModel.TimeOfConduction,
            };
            _happeningRepository.Create(happening);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ViewResult GetHappenings(int page = 1, string type = null)
        {
            List<Happening> events;
            if (type == null)
                events = _happeningRepository.GetAll();
            else
                events = _happeningRepository.GetWhere(x => x.EventType.Name == type);
            if (page <= 0)
                page = 1;
            ViewBag.Page = page;
            ViewBag.EnablePrevButton = page != 1;
            ViewBag.EnableNextButton = events.Count > ((page) * _pageSize);
            events = events.OrderBy(x => x.Id)
                .Skip((page - 1) * _pageSize)
                .Take(_pageSize).ToList();
            return View("Index", events);
        }
        public ViewResult EnterEventType(string type)
        {
            ViewBag.Type = type;
            return GetHappenings(1, type);
        }

        public RedirectToRouteResult JoinToEvent(int Id, string returnUrl)
        {
            var event1 = _happeningRepository.Find(Id);

            if (event1 != null)
            {
                var rep = _unitOfWork.GetRepository<User, int>();
                var user = rep.GetFirstOrDefault(x => x.Name == User.Identity.Name);
                if (!event1.Participants.Contains(user))
                {
                    event1.Participants.Add(user);
                    _unitOfWork.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ActionResult Show(int id)
        {
            var users = _unitOfWork.GetRepository<User, int>().GetAll();
            var eventTypes = _unitOfWork.GetRepository<HappeningType, int>().GetAll();
            var cities = _unitOfWork.GetRepository<City, int>().GetAll();
            var rep = _unitOfWork.GetRepository<Happening, int>();
            Happening happening = rep.Find(id);

            return View(happening);
        }
    }
}