using FurEver.Infrastructure;
using FurEver.Models;

namespace FurEver.Services;

public class FurryService
{
    private readonly FurryRepository _furryRepository;
    
    public FurryService(FurryRepository furryRepository)
    {
        _furryRepository = furryRepository;
    }
    
    public IEnumerable<Furry> GetAllFurries()
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
}