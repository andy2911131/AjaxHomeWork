using Microsoft.AspNetCore.Mvc;
using MSIT150Site.Models;
using MSIT150Site.ViewModels;
using System.Security.Policy;

namespace MSIT150Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context,IWebHostEnvironment host) 
        {
        _context = context;
            _host = host;
        }
        public IActionResult Index()
        {
          /*  System.Threading.Thread.Sleep(5000);*/ //睡5秒鐘，再往下執行
            return Content("Hello Ajax!!");
        }

        public IActionResult GetDemo(CUser cUser) 
        {
            if (string.IsNullOrEmpty(cUser.name)) 
            {
                cUser.name = "guest";
            }
            return Content($"HEllo, {cUser.name}，你今年{cUser.age}歲");
        }

        public IActionResult Register(Members members,IFormFile file) 
        {
            


            //存路徑
            string filePath = Path.Combine(_host.WebRootPath, "images", file.FileName);

            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(filestream);
            }
            members.FileName = file.FileName;

            ////存二進位
            //byte[]? imgByte = null;
            //using (var memoryStream = new MemoryStream())
            //{
            //    file.CopyTo(memoryStream);
            //    imgByte = memoryStream.ToArray();
            //}

            //members.FileData = imgByte;

            _context.Members.Add(members);
            _context.SaveChanges();
            return Content("新增成功");
        }

        public IActionResult CheckAccount(Members members, CUser cUser)
        {
            if (members.Name == cUser.name)
            {
                return Content("帳號已存在");
            }
            else 
            {
                return Content("OK");
            }
        }

        //二進位讀資料
        public IActionResult GetImageByte(int id = 1)
        {
            Members? member = _context.Members.Find(id);
            byte[]? img = member.FileData;
            return File(img, "image/jpeg");

        }

        public IActionResult Cities() 
        {
        var cities =_context.Address.Select(x => x.City).Distinct();

            return Json(cities);
        }
        public IActionResult Districts(string city) 
        {
        var disricts=_context.Address.Where(x=>x.City==city).Select(x=>x.SiteId).Distinct();

            return Json(disricts);
        }

        public IActionResult Roads(string Siteid) 
        {
            var roads = _context.Address.Where(a => a.SiteId == Siteid).Select(c => c.Road).Distinct();

            return Json(roads);
        }
    }
}
