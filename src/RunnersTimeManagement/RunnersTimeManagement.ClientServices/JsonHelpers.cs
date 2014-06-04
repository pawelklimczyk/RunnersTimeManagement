// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="JsonHelpers.cs" project="RunnersTimeManagement.ClientServices" date="2014-06-04 09:08">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices
{
    using System;

    using Newtonsoft.Json;

    using RunnersTimeManagement.Core.Domain;

    public class JsonHelpers
    {
        public static T ConvertFromJson<T>(string json) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonException e)
            {
                LoggingService.LogException(e);

                return null;
            }
        }

        public static string ConvertToJson(Object user)
        {
            try
            {
                return JsonConvert.SerializeObject(user);
            }
            catch (Exception e)
            {
                LoggingService.LogException(e);
                throw;
            }
        }
    }
}
