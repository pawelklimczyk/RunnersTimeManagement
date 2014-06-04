// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="User.cs" project="RunnersTimeManagement.Core" date="2014-06-04 08:44">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.Core.Domain
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
    }
}
