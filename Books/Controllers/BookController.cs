using Books.DataModel;
using Books.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Books.Controllers
{

    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices service)
        {
            _bookServices = service;
        }

        #region Books Categories
        [HttpGet]
        [Route("Categories")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBookCategories()
        {
            try
            {
                var booksCategory = _bookServices.GetBooksCategories<BookCategories>();

                if (booksCategory != null)
                {
                    return Ok(booksCategory.ToList());
                }

                return NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Categories/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBookCategories(int id)
        {
            try
            {
                var booksCategory = _bookServices.GetBooksCategories<BookCategories>(id);

                if (booksCategory != null)
                {
                    return Ok(booksCategory);
                }

                return NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Books 
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBooks(int id)
        {
            try
            {
                var booksCategory = _bookServices.GetBooks((BookCategories)id);

                if (booksCategory != null)
                {
                    return Ok(booksCategory);
                }

                return NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
        #endregion

        [HttpGet("GetBooks")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var booksCategory = _bookServices.GetBooks();
                if (booksCategory != null)
                {
                    return Ok(booksCategory);
                }

                return NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
