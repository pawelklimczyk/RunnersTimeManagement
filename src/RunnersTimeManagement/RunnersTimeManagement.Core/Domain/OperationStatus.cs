// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="OperationStatus.cs" project="RunnersTimeManagement.Core" date="2014-06-04 16:17">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.Core.Domain
{
    public class OperationStatus
    {
        public int Status { get; set; }

        public string StatusDescription { get; set; }

        public object Data { get; set; }

        public static OperationStatus Failed(string message)
        {
            return new OperationStatus()
                       {
                           Status = StatusCode.Failed,
                           StatusDescription = message
                       };
        }

        public static OperationStatus Passed(string message)
        {
            return new OperationStatus()
            {
                Status = StatusCode.Successful,
                StatusDescription = message
            };
        }

        private struct StatusCode
        {
            public const int Failed = -1;
            public const int Successful = 0;
        }

      
    }
}