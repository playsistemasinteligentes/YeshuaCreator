
using Repositorio.Inputs.Repositorio.Y_Company;
using Repositorio.Inputs.Repositorio.Y_User;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Read.Repository.Y_Company;
using RepositoryInterfaces.Read.Repository.Y_User;
using System.Security.Claims;
using System.Text;

namespace Command.Receivers.HubServiceMethod
{
    public partial class ContasLoginServiceMethodReceiver<T>
    {
        private readonly IY_UserReadRepository _repositoryUserRead;
        private readonly IY_CompanyReadRepository _repositoryCompanyRead;
        private readonly IUnitOfWork _unitOfWork;

        public ContasLoginServiceMethodReceiver(IY_UserReadRepository repositoryUserRead, IY_CompanyReadRepository repositoryCompanyRead, IUnitOfWork unitOfWork)
        {
            _repositoryUserRead = repositoryUserRead;
            _repositoryCompanyRead = repositoryCompanyRead;
            _unitOfWork = unitOfWork;
        }

        //partial void CustomActionHook(ref State<T> state, Command.Commands.ContasLoginServiceMethodCommand command)
        //{
        //    try
        //    {
        //        //var getUserCommand = new Commands.Y_UserCrudCommand { Email = command.Email };
        //        //var userState = new Command.Receivers.Read.GetY_UserByEmailReceiver(_repositoryUserRead).Execute(getUserCommand);
        //        //var usuario = userState.Data as Dominio.Entitys.Y_User.Y_UserEntity;

        //        //if (usuario == null || usuario.Senha != command.password)
        //        //{
        //        //    state = ValidationError("E-mail ou senha inválidos.");
        //        //    return;
        //        //}

        //        //// Geração do token JWT
        //        //var tokenHandler = new JwtSecurityTokenHandler();
        //        //var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

        //        //var claims = new List<Claim>
        //        //{
        //        //    new Claim(ClaimTypes.Name, usuario.Nome),
        //        //    new Claim(ClaimTypes.Email, usuario.Email),
        //        //    new Claim(ClaimTypes.Role, "Admin"), // Exemplo de role
        //        //    new Claim("UserId", usuario.Id.ToString()),
        //        //    new Claim("CustomClaim", "MeuValorPersonalizado")
        //        //};

        //        //var tokenDescriptor = new SecurityTokenDescriptor
        //        //{
        //        //    Subject = new ClaimsIdentity(claims),
        //        //    Expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationMinutes),
        //        //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //        //};

        //        //var token = tokenHandler.CreateToken(tokenDescriptor);
        //        //var tokenString = tokenHandler.WriteToken(token);

        //        //state = Success("Login realizado com sucesso.", new
        //        //{
        //        //    Token = tokenString
        //        //});

        //        _unitOfWork.Commit();
        //    }
        //    catch (ReceiverException<T> rex)
        //    {
        //        _unitOfWork.Rollback();
        //        state = rex.State;
        //    }
        //    catch (Exception e)
        //    {
        //        _unitOfWork.Rollback();
        //        //Error(e, T);
        //    }

        //}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHub