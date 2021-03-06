﻿// -------------------------------------------------------------------------------------------------------------------
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
        public static explicit operator bool(OperationStatus status)
        {
            return status.Status == 0;
        }

        public static OperationStatus Failed(string message, object data = null)        {
            return new OperationStatus()
                       {
                           Status = StatusCode.Failed,
                           StatusDescription = message,
                           Data = data
                       };
        }

        public static OperationStatus Passed(string message, object data = null)
        {
            return new OperationStatus()
            {
                Status = StatusCode.Successful,
                StatusDescription = message,
                Data = data
            };
        }

        private struct StatusCode
        {
            public const int Failed = -1;
            public const int Successful = 0;
        }
    }
}