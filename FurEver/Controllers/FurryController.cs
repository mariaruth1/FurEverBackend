using FurEver.Models;
using FurEver.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurEver.Controllers;

[ApiController]
public class FurryController : ControllerBase
{
    private readonly FurryService _furryService;
    
    public FurryController(FurryService furryService)
    {
        _furryService = furryService;
    }
    
    [HttpGet]
    [Route("/api/furries")]
    public IEnumerable<Furry> GetFurries()
    {
        return _furryService.GetAllFurries();
    }
}