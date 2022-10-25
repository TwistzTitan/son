namespace Domain.User;

public class User {
    public readonly int id;

    public string code {get; private set;} 

    public string? name {get; private set;}

    public string? email {get; set;} 

    public int verified {get; set;}

    public User(string code, string name, string email, int verified){
        this.id = (int) Random.Shared.NextInt64(1,1000);
        this.code = code; 
        this.name = name;
        this.email = email;
        this.verified = verified;
    }

    public void GenerateUserCode(){

        this.code = String.Concat(this.email![0],this.email![1],this.name![0],this.name![1],Random.Shared.NextInt64(1,200).ToString());
        this.verified = 0;
    }
}