// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="AccessTokenProvider.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-06 09:22">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.AccessTokenProvider
{
    using System;
    using System.Globalization;

    public class AccessTokenProvider : IAccessTokenProvider
    {
        public string GenerateToken(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("username");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("password");
            }

            return (username+password).GetHashCode().ToString(CultureInfo.InvariantCulture);
        }
    }

    public interface IAccessTokenProvider
    {
        string GenerateToken(string username, string password);
    }
}
