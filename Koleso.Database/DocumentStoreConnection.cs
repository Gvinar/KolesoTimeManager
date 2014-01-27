namespace Koleso.Database
{
    using System;

    using Koleso.Database.Exceptions;

    using Raven.Client;
    using Raven.Client.Document;

    public class DocumentStoreConnection
    {
        private static volatile DocumentStoreConnection instance;

        private static DocumentStore store;

        private static object syncRoot;

        private static string connStringName;

        public static DocumentStoreConnection Current
        {
            get
            {
                if (instance == null && string.IsNullOrEmpty(connStringName))
                {
                    return null;
                }

                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DocumentStoreConnection();
                    }
                }

                return instance;
            }
        }

        static DocumentStoreConnection()
        {
            syncRoot = new object();
        }

        private DocumentStoreConnection()
        {
            store = new DocumentStore { ConnectionStringName = connStringName };
            store.Initialize();
        }

        public static void SetupDatabaseContext(string connectionStringName)
        {
            if (!string.IsNullOrEmpty(connStringName))
                throw new ConnectionStringNameException("Database context is already setup");
            else
            {
                lock (syncRoot)
                {
                    if (!string.IsNullOrEmpty(connStringName))
                        throw new ConnectionStringNameException("Database context is already setup");
                    else
                    {
                        if (string.IsNullOrWhiteSpace(connectionStringName))
                            throw new ArgumentNullException("connectionStringName");

                        connStringName = connectionStringName;
                    }
                }
            }
        }

        public IDocumentSession OpenSession()
        {
            return store.OpenSession();
        }
    }
}
