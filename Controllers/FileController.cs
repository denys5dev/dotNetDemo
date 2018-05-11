using System.Collections.Generic;
using System.IO;
using DatingApp.API.Data;
using DatingApp.API.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Reports;
using System.Linq;

namespace DatingApp.API.Controllers 
{

    [Route("api/[controller]")]
    public class FileController: Controller 
    {
        private readonly DataContext _context;

        public FileController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Report(User user) {
            UserReport userReport = new UserReport();
            var users = _context.Users.ToList();
       
            byte[] abytes = userReport.PrepareReport(users);
            return File(abytes, "application/pdf");
        }
    }
}