using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuotesAPP.DAL;
using QuotesAPP.Services;

namespace QuotesAPP.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService auotherService;

        public AuthorController(IAuthorService auotherService)
        {
            this.auotherService = auotherService;
        }

        // GET: Author
        public async Task<IActionResult> Index()
        {
            var authors = auotherService.GetAuthors();
            return View(authors);
        }

        // GET: Author/Details/5
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

            var author = auotherService.GetAuthorById((int)id);

            if (author == null)
             {
                 return NotFound();
             }

            return RedirectToAction("Index", "Quote",  new { Author = $"{id}" });
        }

        // GET: Author/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Author author)
        {
            if (ModelState.IsValid)
            {
                auotherService.AddAuthor(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Author/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = auotherService.GetAuthorById((int)id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedAt")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                auotherService.UpdateAuthor(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Author/Delete/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = auotherService.GetAuthorById((int)id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Author/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = auotherService.GetAuthorById(id);
            auotherService.DeleteAuthor(id);
          
            return RedirectToAction(nameof(Index));
        }
    
        private bool AuthorExists(int id)
        {
            return auotherService.AuthorExists(id);
        }
    }
}
