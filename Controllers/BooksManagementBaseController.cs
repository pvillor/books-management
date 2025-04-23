using BooksManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BooksManagementBaseController : ControllerBase
{
    public static List<Book> Books = [];
}
