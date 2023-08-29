using Dapper;
using FurEver.Models;
using Npgsql;

namespace FurEver.Infrastructure;

public class FurryRepository
{
    //Add new furry with profile
    public Furry AddFurry(Furry furry)
    {
        throw new NotImplementedException();
    }
    
    
    //Get all furries
    public IEnumerable<Furry> GetAllFurries()
    {
        var sql = @$"SELECT * FROM .AspNetUsers";
            
        using var connection = new NpgsqlConnection();
        var result = connection.Query<Furry>(sql);
        return result;
    }
    
    //Get all furries username/profile picture/age/gender/furry type
    
    //Get all furry profiles
    
    
    //Get furry by ID
    
    //Get furry profile by user ID
    
    //Get full furry info by ID
    
    
    //Update furry
    
    //Update furry profile
    
    
    //Delete furry/profile
}