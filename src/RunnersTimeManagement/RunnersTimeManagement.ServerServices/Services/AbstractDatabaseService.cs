// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="AbstractDatabaseService.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-06 09:07">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.Services
{
    using NPoco;

    public abstract class AbstractDatabaseService
    {
        private static DatabaseMappings _mapping;

        private static bool _isMappingInitialized;

        protected IDatabaseProvider _databaseProvider;

        protected IDatabase CurrentDatabase
        {
            get
            {
                return DatabaseMappings.DbFactory.GetDatabase();
            }
        }

        protected AbstractDatabaseService(IDatabaseProvider provider)
        {
            this._databaseProvider = provider;

            this.InitializeMapping();
        }

        private void InitializeMapping()
        {
            if (_isMappingInitialized)
            {
                return;
            }

            _isMappingInitialized = true;

            _mapping = new DatabaseMappings(this._databaseProvider.ConnectionString);
            _mapping.Setup();
        }

        public void BuildDatabase()
        {
            this._databaseProvider.InitDatabase();
        }
    }
}