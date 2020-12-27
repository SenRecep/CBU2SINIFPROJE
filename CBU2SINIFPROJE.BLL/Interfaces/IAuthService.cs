
using CBU2SINIFPROJE.ViewModels.Login;

namespace CBU2SINIFPROJE.BLL.Interfaces
{
    public interface IAuthService
    {
        public LoginResult Login(LoginViewModel model);
    }
}
