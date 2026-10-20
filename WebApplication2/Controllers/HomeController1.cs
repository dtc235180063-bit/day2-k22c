using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
        public String Wecome(int id1, string name)
        {             
            return $"Xin chào {id1} {name},chúc bạn học tốt môn học ASP.NET Core MVC";
        }
        //IactionResult
        public IActionResult Welcome1(int id1, string name)
        {
            ViewData["Message"] = "Xin chào " + name;
            ViewData["ID"] = id1;
            return View();
        }
    }
}