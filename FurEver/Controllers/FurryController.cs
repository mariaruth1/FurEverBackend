using Dapper;
using FurEver.Models;
using FurEver.Services;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace FurEver.Controllers;

[ApiController]
public class FurryController : ControllerBase
{
    private readonly FurryService _furryService;
    
    public FurryController(FurryService furryService)
    {
        _furryService = furryService;
    }
    
    [HttpPost]
    [Route("/api/furries")]
    public RetrieveFurryDto AddFurry(CreateFurryDto furry)
    {
        return _furryService.AddFurry(furry);
    }
    
    [HttpGet]
    [Route("/api/furries")]
    public IEnumerable<Furry> GetFurries()
    {
        return _furryService.GetAllFurries();
    }
}