namespace CBU2SINIFPROJE.ViewModels.Login
{
    public enum LoginState
    {
        Success,
        NotFound,
        Error
    }
    public class LoginResult
    {
        public string ErrorMessage { get; set; }
        public LoginState State { get; set; }
    }
}
