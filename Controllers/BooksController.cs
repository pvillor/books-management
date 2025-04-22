using BooksManagement.API.Controllers;
using BooksManagement.Communication.Requests;
using BooksManagement.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagement.Controllers;

public class BooksController : BooksManagementBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateBookJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateBookJson request)
    {
        var response = new ResponseCreateBookJson
        {
            Id = 1,
            Title = request.Title,
        };

        return Created(string.Empty, response);
    }
}
