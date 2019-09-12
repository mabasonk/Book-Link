using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Link.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Link.Controllers
{
    [Route("/api/books")]
    public class BooksController: Controller
    {
        private readonly CommentsBoxDbContext _commentsBoxDbContext;

        public BooksController(CommentsBoxDbContext commentsBoxDbContext)
        {
            _commentsBoxDbContext =  commentsBoxDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]Book book)
        {
            if(ModelState.IsValid)
            {
                book.DateCreated = DateTime.Now.Date;
                _commentsBoxDbContext.Books.Add(book);
               await _commentsBoxDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public  IEnumerable<Book> GetBookList()
        {
            var bookList =   _commentsBoxDbContext.Books.ToList()
                                    .Where(x=> x.IsDeleted == false);
            return bookList;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _commentsBoxDbContext.Books.FindAsync(id);
            if(book != null)
            {
                book.IsDeleted = true;
                await _commentsBoxDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}