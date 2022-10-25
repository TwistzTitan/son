namespace Domain.User;
public interface IUserRepository<T> {

    Task<T?> getUser(int id);

    Task<T?> getByEmail(string email);
    
    
}