namespace BookWise.Infrastructure.Services;

public interface IAuthService
{
    string GenerateJwtToken(string email);
    string ComputeSha256Hash(string password);
    string? ValidarSenha(string password, string passwordConfirm);
}