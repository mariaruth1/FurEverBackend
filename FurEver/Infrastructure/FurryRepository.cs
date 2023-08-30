using System.Diagnostics;
using Dapper;
using FurEver.Models;
using Npgsql;

namespace FurEver.Infrastructure;

public class FurryRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public FurryRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    //Add new furry without profile
    public RetrieveFurryDto AddFurry(CreateFurryDto createFurry)
    {
        var sql = $@"INSERT INTO furever.furries 
    (id, username, email, passwordhash, fursona, age, genderid) 
VALUES (@id, @username, @email, @passwordhash, @fursona, @age, @genderid)";

        using var connection = _dataSource.OpenConnection();
        connection.Execute(sql, new {id = createFurry.FurryId, 
            username = createFurry.Username, 
            email = createFurry.Email, 
            passwordhash = createFurry.PasswordHash, 
            fursona = createFurry.Fursona, 
            age = createFurry.Age, 
            genderid = createFurry.GenderId});
        
        return GetFurryFromId(createFurry.FurryId);
    }
    
    //Get basic furry info from id
    public RetrieveFurryDto GetFurryFromId(Guid id)
    {
        var sql = $@"SELECT furries.id as {nameof(RetrieveFurryDto.FurryId)}, 
username as {nameof(RetrieveFurryDto.Username)}, 
email as {nameof(RetrieveFurryDto.Email)},  
fursona as {nameof(RetrieveFurryDto.Fursona)},
age as {nameof(RetrieveFurryDto.Age)},
g.gendername as {nameof(RetrieveFurryDto.GenderName)} 
FROM furever.furries JOIN furever.genders g on g.id = furries.genderid WHERE furries.id = @id;";
        
            using var connection = _dataSource.OpenConnection();
            var result = connection.QuerySingle<RetrieveFurryDto>(sql, new {id = id});
            return result;
    }
    
    
    //Get all furries
    public IEnumerable<RetrieveFurryDto> GetAllFurries()
    {
        var sql = @$"SELECT furries.id as {nameof(RetrieveFurryDto.FurryId)}, 
username as {nameof(RetrieveFurryDto.Username)}, 
email as {nameof(RetrieveFurryDto.Email)},  
fursona as {nameof(RetrieveFurryDto.Fursona)},
age as {nameof(RetrieveFurryDto.Age)},
g.gendername as {nameof(RetrieveFurryDto.GenderName)} FROM furever.furries JOIN furever.genders g on g.id = furries.genderid";
            
        using var connection = _dataSource.OpenConnection();
        var result = connection.Query<RetrieveFurryDto>(sql);
        return result;
    }
    
    //Get all furries username/profile picture/age/gender/furry type
    
    //Get all furry profiles
    
    
    //Get furry profile by user ID
    
    //Get full furry info by ID
    
    
    //Update furry
    
    //Update furry profile
    
    
    //Delete furry/profile
}