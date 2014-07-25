using System;
namespace OpenCBS.Online.Service.Security.Encryption
{
    public interface IPasswordHash : IDisposable
    {
        PasswordHash.HashInfo CreateHash(string password);
        bool ValidatePassword(string password, string goodHash);
    }
}
