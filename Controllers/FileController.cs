using System.Collections.Generic;
using System.IO;
using DatingApp.API.Data;
using DatingApp.API.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Reports;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        [HttpGet]
       public IActionResult Report(User user)
       {
           UserReport userReport = new UserReport();
           byte[] abytes = userReport.PrepareReport(GetUsers());
           return File(abytes, "application/pdf");
       }

       public List<User> GetUsers()
       {
           List<User> users = new List<User>();
           User user = new User();

           for(int i = 1; i <= 6; i++)
           {
               user = new User();
               user.Username = "User" + i;
               users.Add(user);
           }


           return users;
       }
    }
}