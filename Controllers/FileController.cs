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
        [HttpGet("{id}")]
        public IActionResult Report(int id) {
            UserReport userReport = new UserReport();
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
       
            byte[] abytes = userReport.PrepareReport(user);
            return File(abytes, "application/pdf");
        }
    }
}