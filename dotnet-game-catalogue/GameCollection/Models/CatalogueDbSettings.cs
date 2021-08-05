using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Models
{
    public class CatalogueDbSettings : ICatalogueDbSettings
    {
        public string GamesCollectionName { get; set; }

        public string UserCollectionName { get; set; }

        public string UserRatingsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DbName { get; set; }
    }

    public interface ICatalogueDbSettings
    {
        public string GamesCollectionName { get; set; }

        public string UserCollectionName { get; set; }

        public string UserRatingsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DbName { get; set; }
    }
}
