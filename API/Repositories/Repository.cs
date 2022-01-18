using API.Repositories.Interface;

namespace API.Repositories;

public class Repository : IRepository
{
    private readonly AppDbContext _dbContext; 
    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        UserRepo = new UserRepo(_dbContext);
    }


    public IUserRepo UserRepo { get; private set; }

}