using BooksManagement.API.Controllers;
using BooksManagement.Communication.Requests;
using BooksManagement.Communication.Responses;
using BooksManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagement.Controllers;

public class BooksController : BooksManagementBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedBookJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateBookJson request)
    {
        var response = new ResponseCreatedBookJson
        {
            Id = 1,
            Title = request.Title,
        };

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult FetchAll()
    {
        var response = new List<Book>
        {
            new Book { 
                Id = 1,
                Title = "A revolução dos bichos",
                Author = "George Orwell",
                Genre = "Sátira",
                Price = new Decimal(24.90),
                QuantityAvailable = 20
            },
            new Book
            {
                Id = 2,
                Title = "1984",
                Author = "George Orwell",
                Genre = "Distopia",
                Price = new Decimal(24.90),
                QuantityAvailable = 20
            }
        };

        return Ok(response);
    }
}
