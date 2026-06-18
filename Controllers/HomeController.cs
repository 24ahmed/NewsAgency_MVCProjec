using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News_Project.Models;
using QRCoder;
using System.Diagnostics;
using ZXing;
using ZXing.Common;

namespace News_Project.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        ApplicationDbContext _db;

        public HomeController(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;
        }
        
        public IActionResult Index()
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(
                "https://localhost:7199",
                QRCodeGenerator.ECCLevel.Q);

            var qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);

            ViewBag.QRCode = Convert.ToBase64String(qrCodeImage);

            var item = _db.Category.ToList();
            return View(item);
        }
       

        public IActionResult About()
        {
            
            return View();
        }
        

        public IActionResult Team()
        {
           var item =  _db.TeamMembers.ToList();
            return View(item);
        }
        

        public IActionResult TeamMembersIndex()
        {
            var item = _db.TeamMembers.ToList();
            return View(item);
        }
        [HttpGet]
        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactUs contact)
        {
            _db.ContactUs.Add(contact);
            _db.SaveChanges();
           return  RedirectToAction("Index");
        }
        public IActionResult Messages()
        {
            return View(_db.ContactUs.ToList());
        }
        public IActionResult AllNews()
        {
            var news = _db.News
                          .Include(x => x.Category)
                          .ToList();

            return View(news);
        }
        [HttpGet]
        public IActionResult News(int id)
        {
           var result =  _db.News.Where(x => x.CategoryId == id).ToList();
            ViewBag.Name = _db.Category.Find(id).Name;
            return View(result);
        }
        //public IActionResult Delete(int id)
        //{
        //    var item = _db.News.FirstOrDefault(x => x.Id == id);

        //    if (item == null)
        //        return NotFound();

        //    return View(item);
        //}

        
        public IActionResult Delete(int id)
        {
            var item = _db.News.FirstOrDefault(x => x.Id == id);

            _db.News.Remove(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id, News news)
        {
            var item = _db.News.FirstOrDefault(x => x.Id == id);
            item.Id = news.Id;
           item.Title = news.Title;
            item.Topic = news.Topic;
            item.Time = DateTime.Now;
            item.ImgUrl = news.ImgUrl;
            _db.Update(item);
            _db.SaveChanges();
            return RedirectToAction("News");
        }
        public IActionResult Details(int id)
        {
            var item = _db.News.FirstOrDefault(x => x.Id == id);
            
            return View(item);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
