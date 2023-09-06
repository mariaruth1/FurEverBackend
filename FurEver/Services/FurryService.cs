using FurEver.Infrastructure;
using FurEver.Models;
using FurEver.Models.GetDtos;
using FurEver.Models.SendDtos;

namespace FurEver.Services;

public class FurryService
{
    private readonly FurryRepository _furryRepository;
    
    public FurryService(FurryRepository furryRepository)
    {
        _furryRepository = furryRepository;
    }
    
    public RetrieveFurryDto AddFurry(CreateFurryDto furry)
    {
        try
        {
            return _furryRepository.AddFurry(furry);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.InnerException);
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            throw new Exception("Could not add furry :(");
        }
    }
    
    public RetrieveFurryDto GetFurryFromId(Guid id)
    {
        try
        {
            return _furryRepository.GetFurryFromId(id);
        }
        catch (Exception)
        {
            throw new Exception("Could not load furry :(");
        }
    }

    public RetrieveFurryWithProfileDto GetFurryWithProfileFromId(Guid id)
    {
        try
        {
            return _furryRepository.GetFurryWithProfileFromId(id);
        }
        catch (Exception)
        {
            throw new Exception("Could not load furry profile :(");
        }
    }
    
    public IEnumerable<RetrieveFurryDto> GetAllFurries()
    {
        try
        {
            return _furryRepository.GetAllFurries();
        }
        catch (Exception)
        {
            throw new Exception("Could not load furries :(");
        }
    }

    public IEnumerable<RetrieveFurryWithProfileDto> GetAllFurryProfiles()
    {
        try
        {
            return _furryRepository.GetAllFurryProfiles();
        }
        catch (Exception)
        {
            throw new Exception("Could not load furry profiles :(");
        }
    }

    public RetrieveFurryDto UpdateFurryBasicInfo(UpdateFurryBasicInfoDto updateFurryBasicInfoDto)
    {
        try
        {
            return _furryRepository.UpdateFurryBasicInfo(updateFurryBasicInfoDto);
        }
        catch (Exception)
        {
            throw new Exception("Could not update furry basic info :(");
        }
    }

    public RetrieveFurryProfileDto UpdateFurryProfile(UpdateFurryProfileDto updateFurryProfileDto)
    {
        try
        {
            return _furryRepository.UpdateFurryProfile(updateFurryProfileDto);
        }
        catch (Exception)
        {
            throw new Exception("Could not update furry profile :(");
        }
    }
    
    public bool DeleteFurry(Guid id)
    {
        try
        {
            return _furryRepository.DeleteFurry(id);
        }
        catch (Exception)
        {
            throw new Exception("Could not delete furry :(");
        }
    }
    
}