using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBU2SINIFPROJE.ViewModels.Login;

namespace CBU2SINIFPROJE.BLL.Interfaces
{
    public interface IAuthService
    {
        public LoginResult Login(LoginViewModel model);
    }
}
