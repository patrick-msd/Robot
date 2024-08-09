using Microsoft.AspNetCore.Mvc;

namespace PSGM.WebApp.Components.Model
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

public class File
{
    public Guid Id { get; set; }
    public string ObjectName { get; set; }
    public string Name { get; set; }
    public string Size { get; set; }
    public string Type { get; set; }
    public byte[] Image { get; set; }
}