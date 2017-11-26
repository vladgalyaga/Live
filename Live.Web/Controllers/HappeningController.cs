using Dal.Core.Interfaces;
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
        string _photo = "someUrl";
        public HappeningController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _happeningRepository = unitOfWork.GetRepository<Happening, int>();
        }
        // GET: Event
        public ActionResult Index()
        {
            var events = _happeningRepository.GetAll();
            return View(events);
        }
        public async Task<string> GetImageProductById(int Id)
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
        public ActionResult AddHappening(Happening happening)
        {
            _happeningRepository.Create(happening);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ViewResult GetHappening(string type, int page = 1)
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
            return View(events);
        }
        public ViewResult EnterEventType(string type)
        {
            ViewBag.Type = type;
            return GetHappening(type, 1);
        }
    }
}