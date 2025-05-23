using Inlämning1Tomaso.Data;
using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;
using System.Security.Cryptography;
using System.Text;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Keys;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly TomasoDbContext _db;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepo userRepo, TomasoDbContext dbContext, IConfiguration configuration)
    {
        _userRepo = userRepo;
        _db = dbContext;
        _configuration = configuration;
    }

    public bool CreateUser(CreateUserDto dto)
    {
        var existing = _db.Users.SingleOrDefault(u => u.Email == dto.CreateUserEmail);
        if (existing != null)
            return false;

        var hashedPassword = HashPassword(dto.CreatePassword);

        var user = new User
        {
            UserName = dto.CreateUserName,
            Email = dto.CreateUserEmail,
            Password = hashedPassword,
            Phone = dto.CreateUserPhone
        };

        _userRepo.AddUser(user);
        return true;
    }

    public string Authenticate(string userName, string password)
    {
        var user = _db.Users.SingleOrDefault(u => u.UserName.ToLower() == userName.ToLower());
        if (user == null)
            return null;

        var hashedInputPassword = HashPassword(password);
        if (user.Password != hashedInputPassword)
            return null;

        return JwtToken.GenerateToken(user, _configuration);
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    public GetUserDto GetById(int id)
    {
        var user = _userRepo.GetUserById(id);
        if (user == null)
            return null;

        return new GetUserDto
        {   UserID = user.UserID,
            UserName = user.UserName,
            
        };
    }
    public void UpdateUser(int id, CreateUserDto dto)
    {
        var hashedPassword = HashPassword(dto.CreatePassword);

        var user = new User
        {
            UserID = id,
            UserName = dto.CreateUserName,
            Email = dto.CreateUserEmail,
            Password = hashedPassword,
            Phone = dto.CreateUserPhone
        };

        _userRepo.UpdateUser(user);
    }
    public void DeleteUser(int id)
    {
        _userRepo.DeleteUser(id);
    }

}