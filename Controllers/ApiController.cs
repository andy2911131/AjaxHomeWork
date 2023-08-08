using Microsoft.AspNetCore.Mvc;
using MSIT150Site.Models;
using MSIT150Site.ViewModels;

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
            System.Threading.Thread.Sleep(5000); //睡5秒鐘，再往下執行
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

        public IActionResult Regestier(Members members,IFormFile file) 
        {
          

           

            string filePath = Path.Combine(_host.WebRootPath, "images", file.FileName);

            using (var filestream = new FileStream(filePath, FileMode.Create)) 
            {
            file.CopyTo(filestream);
            }
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream()) 
            {
                file.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            members.FileName = file.FileName;
            members.FileData= imgByte;

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
    }
}
