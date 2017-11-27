using Common.ViewModels;
using Dal.Core.Interfaces;
using Live.BLL;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public HappeningController(IUnitOfWork unitOfWork, CityManager cityManager)
        {
            _unitOfWork = unitOfWork;
            _happeningRepository = unitOfWork.GetRepository<Happening, int>();
            _cityManager = cityManager;
        }
        // GET: Event
        public ActionResult Index()
        {
            return GetHappenings();
        }
        public async Task<string> GetImageEventById(int Id)
        {
            // Products prod = m_storeRepository.GetProduct(productId);
            Happening happaning = await _unitOfWork.GetRepository<Happening, int>().FindByIdAsync(Id);
            if (happaning.PhotoUrl != null)
            {
                return happaning.PhotoUrl;
            }
            else
            {
                return _photo;
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
            var a = _unitOfWork.GetRepository<User, int>().GetFirstOrDefault(x => x.Name == User.Identity.Name);
            Happening happening = new Happening()
            {
                City = _cityManager.GetOrCreateCity(happeningViewModel.City),
                Creater = _unitOfWork.GetRepository<User, int>().GetFirst(x => x.Name == User.Identity.Name),
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
                event1.Participants.Add(user);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}