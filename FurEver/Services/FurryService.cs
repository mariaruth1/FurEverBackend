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
    
    public RetrieveFurryDto AddFurry(CreateFurryDto furry)
    {
        try
        {
            return _furryRepository.AddFurry(furry);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.InnerException.Message);
            throw new Exception("Could not add furry :(");
        }
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