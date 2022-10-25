using Grpc.Core;
using GrpcEmailler;
using Domain.User;

namespace GrpcEmailler.Services;

    public class EmaillerService : Emailler.EmaillerBase {
    
    private readonly ILogger _logger;
    private readonly IUserRepository<Domain.User.User> _userRepo;

    private readonly IUserFactory<Domain.User.User> _userFact;

    public EmaillerService(
        ILogger<EmaillerService> logger, 
        IUserRepository<Domain.User.User> userRepo,
        IUserFactory<Domain.User.User> userFactory
        ){
        _logger = logger;
        _userRepo = userRepo;
        _userFact = userFactory;
    }
        public override async Task<ChangeEmailReply>ChangeEmail(ChangeEmailRequest request,
                                     ServerCallContext context)
        {
            Domain.User.User? user = await _userRepo.getByEmail(request.OlEmail);

            if(user == null){
                return new ChangeEmailReply(){
                    Changed = EmailChanged.EcFailed,
                    NewEmail = "",
                    VeryfyCode = "",
                };
            }
            if(user.code != request.UserCode){
                return new ChangeEmailReply(){
                    Changed = EmailChanged.EcUseriderror,
                    NewEmail = "", 
                    VeryfyCode = ""
                };
            }

            ChangeEmail changeEmail = new ChangeEmail(request.NewEmail,user.id);

            user = await _userFact.updateEmail(changeEmail);

            return new ChangeEmailReply(){
                Changed = EmailChanged.EcSuccess,
                VeryfyCode = user.code,
                NewEmail = user.email,
            };
        }

        public override Task<VerifyEmailReply>VerifyEmail(VerifyEmailRequest request, ServerCallContext context){
            return Task.FromResult(new VerifyEmailReply{});
        }  
        
    }
