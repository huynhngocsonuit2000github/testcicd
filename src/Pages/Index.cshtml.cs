using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Collections.Generic;

namespace myWebApp.Pages;

public class IndexModel : PageModel
    {
        public string StudentName { get; private set; } = "PageModel in C#";
        private readonly ILogger<IndexModel> _logger;
        private readonly myWebApp.Data.SchoolContext _context;

        public IndexModel(ILogger<IndexModel> logger, myWebApp.Data.SchoolContext context)
        {
            _logger = logger;
            _context= context;
        }

        public void OnGet()
        {
            Random rnd = new Random();
            var ses =_context.Students?.ToList();
            int n  = rnd.Next(0, ses.Count);
            var s = ses[n];
            this.StudentName = $"{s?.FirstMidName} {s?.LastName}";
        }
    }