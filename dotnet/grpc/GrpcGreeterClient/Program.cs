using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;
using GrpcEmailler;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7224");

var emailClient = new Emailler.EmaillerClient(channel);

// Console.WriteLine("Change Email Service\n");
// Console.WriteLine("Type the old email: \n");
// string? oldEmail = Console.ReadLine();
// Console.WriteLine("Type the new email: \n");
// string? newEmail = Console.ReadLine();
// Console.WriteLine("Type the user code: \n");
// string? code = Console.ReadLine();


var changeEmailRequest = new ChangeEmailRequest(){
    UserCode = "x21s5",
    OlEmail = "teste1@mail.com",
    NewEmail = "twtz875@mail.com"
};

var emailReply = emailClient.ChangeEmail(changeEmailRequest);
Console.WriteLine("Status: {0}",emailReply.Changed.ToString());
Console.WriteLine("New Email: {0} \t  Code: {1}", emailReply.NewEmail, emailReply.VeryfyCode);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();