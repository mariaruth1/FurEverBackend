using Dapper;
using FurEver.Models;
using FurEver.Models.GetDtos;
using FurEver.Models.SendDtos;
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
    [Route("/api/furries/{id}/account")]
    public RetrieveFurryDto GetFurryFromId(Guid id)
    {
        return _furryService.GetFurryFromId(id);
    }
    
    [HttpGet]
    [Route("/api/furries/{id}/profile")]
    public RetrieveFurryWithProfileDto GetFurryWithProfileFromId(Guid id)
    {
        return _furryService.GetFurryWithProfileFromId(id);
    }
    
    [HttpGet]
    [Route("/api/furries")]
    public IEnumerable<RetrieveFurryDto> GetFurries()
    {
        return _furryService.GetAllFurries();
    }
    
    [HttpGet]
    [Route("/api/furries/profiles")]
    public IEnumerable<RetrieveFurryWithProfileDto> GetFurryProfiles()
    {
        return _furryService.GetAllFurryProfiles();
    }
    
    [HttpPut]
    [Route("/api/furries/{id}/account")]
    public RetrieveFurryDto UpdateFurry(UpdateFurryBasicInfoDto furry)
    {
        return _furryService.UpdateFurryBasicInfo(furry);
    }
    
    [HttpPut]
    [Route("/api/furries/{id}/profile")]
    public RetrieveFurryProfileDto UpdateFurryProfile(UpdateFurryProfileDto furry)
    {
        return _furryService.UpdateFurryProfile(furry);
    }
    
    [HttpDelete]
    [Route("/api/furries/{id}")]
    public bool DeleteFurry(Guid id)
    {
        return _furryService.DeleteFurry(id);
    }
}