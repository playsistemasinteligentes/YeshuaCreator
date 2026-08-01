using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Migration
{
    public class MigrationDiscovery
    {
        public IEnumerable<MigrationBase> DiscoverMigrations()
        {
            var migrations = new List<MigrationBase>();

            var migrationTypes = from type in AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(a => a.GetTypes())
                                 where type.GetCustomAttributes(typeof(MigrationAttribute), false).Any()
                                 let attribute = (MigrationAttribute)type.GetCustomAttributes(typeof(MigrationAttribute), false).First()
                                 select new
                                 {
                                     Type = type,
                                     Version = attribute.Id
                                 };

            foreach (var item in migrationTypes)
            {
                // Use Activator to create an instance of the migration and set the ID
                var migrationInstance = (MigrationBase)Activator.CreateInstance(item.Type);
                migrationInstance.SetID(item.Type.Name);

                migrations.Add(migrationInstance);
            }
            return migrations;
        }
    }
}
