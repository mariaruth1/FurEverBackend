using System.Diagnostics;
using Dapper;
using FurEver.Models;
using Npgsql;

namespace FurEver.Infrastructure;

public class FurryRepository
{
    private NpgsqlDataSource _dataSource;

    public FurryRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    //Add new furry without profile
    public RetrieveFurryDto AddFurry(CreateFurryDto createFurry)
    {
        var sql = $@"INSERT INTO furever.furries 
    (id, username, fursona, age, genderid) 
VALUES (@id, @username, @fursona, @age, @genderid)";

        using var connection = _dataSource.OpenConnection();
        connection.Execute(sql, new {id = createFurry.Id, username = createFurry.Username, 
            fursona = createFurry.Fursona, age = createFurry.Age, genderid = createFurry.GenderId});

        sql = $@"SELECT furries.id as {nameof(RetrieveFurryDto.FurryId)}, 
username as {nameof(RetrieveFurryDto.Username)}, 
fursona as {nameof(RetrieveFurryDto.Fursona)},
age as {nameof(RetrieveFurryDto.Age)},
g.gendername as {nameof(RetrieveFurryDto.GenderName)} 
FROM furever.furries JOIN furever.genders g on g.id = furries.genderid WHERE furries.id = @id;";
        var result = connection.QuerySingle<RetrieveFurryDto>(sql, new {id = createFurry.Id});
        return result;
    }
    
    
    //Get all furries
    public IEnumerable<Furry> GetAllFurries()
    {
        var sql = @$"SELECT * FROM furever.furries JOIN furever.genders g on g.id = furries.genderid";
            
        using var connection = _dataSource.OpenConnection();
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