// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="AccessTokenProvider.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-06 09:22">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.AccessTokenProvider
{
    public class AccessTokenProvider : IAccessTokenProvider
    {
        public string GenerateToken()
        {
            //TODO
            return "default_token";
        }
    }

    public interface IAccessTokenProvider
    {
        string GenerateToken();
    }
}
