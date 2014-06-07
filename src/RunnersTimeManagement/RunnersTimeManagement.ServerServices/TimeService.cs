  // -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TimeService.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-06 09:45">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices
{
    using RunnersTimeManagement.ServerServices.Services;

    public class TimeService : AbstractDatabaseService
    {
        public TimeService(IDatabaseProvider provider)
            : base(provider)
        {
        }
         
    }
}
