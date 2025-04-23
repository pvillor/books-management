using BooksManagement.API.Controllers;
using BooksManagement.Communication.Requests;
using BooksManagement.Communication.Responses;
using BooksManagement.Entities;
using BooksManagement.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagement.Controllers;

public class BooksController : BooksManagementBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedBookJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateBookJson request)
    {
        var newBook = new Book
        {
            Id = IdGenerator.GenerateId(),
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price
        };

        Books.Add(newBook);

        var response = new ResponseCreatedBookJson
        {
            Id = newBook.Id,
            Title = request.Title,
        };

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult FetchAll()
    {
        return Ok(Books.ToList());
    }

    [HttpPut]
    [Route("{bookId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int bookId, [FromBody] RequestUpdateBookJson request)
    {
        var book = Books.FirstOrDefault(book => book.Id == bookId);

        if (book is null)
        {
            return NotFound();
        }

        book.Title = request.Title;
        book.Author = request.Author;
        book.Genre = request.Genre;
        book.Price = request.Price;

        return NoContent();
    }

    [HttpDelete]
    [Route("{bookId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int bookId)
    {
        var book = Books.FirstOrDefault(book => book.Id == bookId);

        if (book is null)
        {
            return NotFound();
        }

        Books.Remove(book);

        return NoContent();
    }
}
