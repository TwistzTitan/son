using System.Text.Json;
using System.Linq;
using Domain.User;

public class UserRepository : IUserRepository<User>
{   
    private readonly IList<User>? users;
    public UserRepository (){
        var fileName = "Data\\UserDatabase.json";
        var jsonString = File.ReadAllText(fileName);
        try {
            users = JsonSerializer.Deserialize<List<User>>(jsonString);
        }
        catch {
            User user = new User("x123x","Andrew","teste@mail.com",1);
            users = new List<User>(){user};
        }
    }

    public Task<User?> getByEmail(string email)
       {
         
         return Task.FromResult(users!.FirstOrDefault<User>(u => u.email == email)); 
         
       }
    

   public Task<User?> getUser(int id)
        => Task.FromResult(users!.FirstOrDefault<User>( u => u.id == id));
    
}