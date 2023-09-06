using Dapper;
using FurEver.Models.SendDtos;
using FurEver.Models.GetDtos;
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
    (id, username, email, passwordhash, fursona, age, genderid, profilepicurl, profileintro, profilebio, profilemood) 
VALUES (@id, @username, @email, @passwordhash, @fursona, @age, @genderid, @profilepicurl, @profileintro, @profilebio, @profilemood)";

        using var connection = _dataSource.OpenConnection();
        connection.Execute(sql, new {
            id = createFurry.FurryId, 
            username = createFurry.Username, 
            email = createFurry.Email, 
            passwordhash = createFurry.PasswordHash, 
            fursona = createFurry.Fursona, 
            age = createFurry.Age, 
            genderid = createFurry.GenderId, 
            profilepicurl = createFurry.ProfilePictureUrl, 
            profileintro = createFurry.ProfileIntro, 
            profilebio = createFurry.ProfileBio, 
            profilemood = createFurry.ProfileMood
        });
        
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
FROM furever.furries JOIN furever.genders g on g.id = furries.genderid 
WHERE furries.id = @id;";
        
            using var connection = _dataSource.OpenConnection();
            var result = connection.QuerySingle<RetrieveFurryDto>(sql, new {id});
            return result;
    }
    
    //Get furry profile from id
    public RetrieveFurryWithProfileDto GetFurryWithProfileFromId(Guid id)
    {
        var sql = $@"
SELECT furries.id as {nameof(RetrieveFurryWithProfileDto.FurryId)}, 
username as {nameof(RetrieveFurryWithProfileDto.Username)}, 
fursona as {nameof(RetrieveFurryWithProfileDto.Fursona)},
age as {nameof(RetrieveFurryWithProfileDto.Age)},
g.gendername as {nameof(RetrieveFurryWithProfileDto.GenderName)}, 
profileintro as {nameof(RetrieveFurryWithProfileDto.ProfileIntro)}, 
profilebio as {nameof(RetrieveFurryWithProfileDto.ProfileBio)}, 
profilemood as {nameof(RetrieveFurryWithProfileDto.ProfileMood)}, 
profilepicurl as {nameof(RetrieveFurryWithProfileDto.ProfilePictureUrl)} 
FROM furever.furries JOIN furever.genders g on g.id = furries.genderid 
WHERE furries.id = @id;
";
        using var connection = _dataSource.OpenConnection();
        var result = connection.QuerySingle<RetrieveFurryWithProfileDto>(sql, new {id});
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
    
    
    //Get all furry profiles
    public IEnumerable<RetrieveFurryWithProfileDto> GetAllFurryProfiles()
    {
        var sql = $@"
SELECT furries.id as {nameof(RetrieveFurryWithProfileDto.FurryId)}, 
username as {nameof(RetrieveFurryWithProfileDto.Username)}, 
fursona as {nameof(RetrieveFurryWithProfileDto.Fursona)},
age as {nameof(RetrieveFurryWithProfileDto.Age)},
g.gendername as {nameof(RetrieveFurryWithProfileDto.GenderName)}, 
profileintro as {nameof(RetrieveFurryWithProfileDto.ProfileIntro)}, 
profilebio as {nameof(RetrieveFurryWithProfileDto.ProfileBio)}, 
profilemood as {nameof(RetrieveFurryWithProfileDto.ProfileMood)}, 
profilepicurl as {nameof(RetrieveFurryWithProfileDto.ProfilePictureUrl)} 
FROM furever.furries JOIN furever.genders g on g.id = furries.genderid;
";
        using var connection = _dataSource.OpenConnection();
        var result = connection.Query<RetrieveFurryWithProfileDto>(sql);
        return result;
    }
    
    //Update furry basic info
    public RetrieveFurryDto UpdateFurryBasicInfo(UpdateFurryBasicInfoDto updateFurryBasicInfoDto)
    {
        var sql = $@"UPDATE furever.furries 
SET age = @age, fursona = @fursona, username = @username, email = @email, genderid = @genderid 
WHERE furries.id = @id";
        using var connection = _dataSource.OpenConnection();
        connection.Execute(sql, new
        {
            age = updateFurryBasicInfoDto.Age, 
            fursona = updateFurryBasicInfoDto.Fursona, 
            username = updateFurryBasicInfoDto.Username, 
            email = updateFurryBasicInfoDto.Email, 
            genderid = updateFurryBasicInfoDto.GenderId, 
            id = updateFurryBasicInfoDto.FurryId
        });

sql = @$"SELECT FROM furever.furries 
furries.id as {nameof(RetrieveFurryDto.FurryId)},
username as {nameof(RetrieveFurryDto.Username)},
email as {nameof(RetrieveFurryDto.Email)},
fursona as {nameof(RetrieveFurryDto.Fursona)},
age as {nameof(RetrieveFurryDto.Age)},
g.gendername as {nameof(RetrieveFurryDto.GenderName)} 
JOIN furever.genders g on g.id = furries.genderid;";

        var result = connection.QuerySingle<RetrieveFurryDto>(sql);
        return result;
    }
    
    
    //Update furry profile
    public RetrieveFurryProfileDto UpdateFurryProfile(UpdateFurryProfileDto updateFurryProfileDto)
    {
        var sql = $@"UPDATE furever.furries 
SET profileintro = @profileintro, profilebio = @profilebio, profilemood = @profilemood, profilepicurl = @profilepicurl 
WHERE id = @id  
RETURNING id as {nameof(RetrieveFurryProfileDto.FurryId)}, 
profilepicurl as {nameof(RetrieveFurryProfileDto.ProfilePictureUrl)}, 
profilemood as {nameof(RetrieveFurryProfileDto.ProfileMood)}, 
profilebio as {nameof(RetrieveFurryProfileDto.ProfileBio)}, 
profileintro as {nameof(RetrieveFurryProfileDto.ProfileIntro)};";

        using var connection = _dataSource.OpenConnection();
        var result = connection.QuerySingle<RetrieveFurryProfileDto>(sql, new {
            profileintro = updateFurryProfileDto.ProfileIntro, 
            profilebio = updateFurryProfileDto.ProfileBio, 
            profilemood = updateFurryProfileDto.ProfileMood, 
            profilepicurl = updateFurryProfileDto.ProfilePictureUrl, 
            id = updateFurryProfileDto.FurryId});
        return result;
    }
    
    
    //Delete furry/profile
    public bool DeleteFurry(Guid id)
    {
        var sql = $@"DELETE FROM furever.furries WHERE id = @id";
        using var connection = _dataSource.OpenConnection();
        var result = connection.Execute(sql, new {id});
        return result == 1;
    }
    
    //Search furries username/profile picture/age/gender/furry type
}