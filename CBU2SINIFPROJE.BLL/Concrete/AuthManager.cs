using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.ViewModels.Login;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IGenericService<Credential> credentialService;

        public AuthManager(IGenericService<Credential> credentialService)
        {
            this.credentialService = credentialService;
        }

        public LoginResult Login(LoginViewModel model)
        {
            if (model.UserName.IsEmpty() || model.Password.IsEmpty())
                return new()
                {
                    State = LoginState.Error,
                    ErrorMessage = "Kullanıcı adı veya Parolanız boş olamaz"
                };

            List<Credential> credentials = credentialService.GetAll();
            Credential found = credentials.FirstOrDefault(x => x.UserName.Equals(model.UserName) && x.Password.Equals(model.Password));
            if (found.IsNull())
                return new()
                {
                    State = LoginState.NotFound,
                    ErrorMessage = "Girdiğiniz bilgiler ile eşleşen bir kullanıcı bulunamadı"
                };
            SessionContext.LoginManager = found.Manager;
            return new()
            {
                State = LoginState.Success
            };
        }
    }
}
