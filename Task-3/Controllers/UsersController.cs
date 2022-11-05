using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Task_3.Entities;
using Task_3.Models;
using Task_3.Options;
using Task_3.Services;

namespace Task_3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly GetFileNamesService _getFileNamesService;
    private readonly IConfiguration _configuration;
    private readonly FileNamesOption _fileNamesOption;
    private readonly UsersService _usersService;
    public UsersController(GetFileNamesService getFileNamesService, IOptions<FileNamesOption> fileNamesOption,
        UsersService usersService)
    {
        _usersService = usersService;
        _getFileNamesService = getFileNamesService;
        _fileNamesOption = fileNamesOption.Value;
    }

    [HttpPost]
    public IActionResult AddUser(CreateUserModel createUserModel)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User
        {
            Name = createUserModel.Name,
            Email = createUserModel.Email,
            Roles = createUserModel.Roles,
            Token = Guid.NewGuid().ToString(),
        };

        _usersService.AddUser(user);

        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _usersService.GetAllUsers();

        return Ok(users);
    }

    [HttpGet("getfilename")]
    public IActionResult GetJsonFilePath()
    {
        var filePath = _fileNamesOption.JsonFilePath;

        return Ok(filePath);
    }

}
