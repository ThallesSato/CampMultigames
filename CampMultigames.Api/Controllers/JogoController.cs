using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JogoController : ControllerBase
{
    private readonly IJogoService _jogoService;
    private readonly IUnitOfWork _unitOfWork;
    public JogoController(IJogoService jogoService, IUnitOfWork unitOfWork)
    {
        _jogoService = jogoService;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _jogoService.GetAllAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> Post(JogoBase jogoBase)
    {
        try
        {
            var result = await _jogoService.PostAsync(jogoBase);
            await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}