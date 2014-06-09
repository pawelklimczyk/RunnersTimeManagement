  // -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TimeService.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-06 09:45">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.Services
{
    using System;

    using NPoco;

    using RunnersTimeManagement.Core.Domain;

    public class TimeService : AbstractDatabaseService
    {
        public TimeService(IDatabaseProvider provider = null)
            : base(provider)
        {

        }

        public OperationStatus InsertTimeEntry(TimeEntry timeEntry, object token)
        {
            try
            {
                using (IDatabase db = this.CurrentDatabase)
                {
                    var existingUser = db.SingleOrDefault<User>("where accesstoken=@0", token);

                    if (existingUser == null)
                    {
                        return OperationStatus.Failed("Token is invalid");
                    }

                    timeEntry.UserId = existingUser.Id;

                    db.Insert(timeEntry);

                    return OperationStatus.Passed("Time entry added");
                }
            }
            catch (Exception exc)
            {
                Logger.LogException(exc);

                return OperationStatus.Failed("Error adding time entry");
            }
        }

        public OperationStatus GetTimeEntryList(object token)
        {
            try
            {
                using (IDatabase db = this.CurrentDatabase)
                {
                    var existingUser = db.SingleOrDefault<User>("where accesstoken=@0", token);

                    if (existingUser == null)
                    {
                        return OperationStatus.Failed("Token is invalid");
                    }

                    var entries = db.Fetch<TimeEntry>("where userId=@0", existingUser.Id);

                    return OperationStatus.Passed("Time entries fetched", entries);
                }
            }
            catch (Exception exc)
            {
                Logger.LogException(exc);

                return OperationStatus.Failed("Error fetching time entries");
            }
        }
    }
}
