using System;
using System.Collections.Generic;
using System.Text;

namespace Rafy.Data
{
    public class ConnectionStringSettings
    {
        //
        // 摘要:
        //     Initializes a new instance of a System.Configuration.ConnectionStringSettings
        //     class.
        public ConnectionStringSettings() { }
        //
        // 摘要:
        //     Initializes a new instance of a System.Configuration.ConnectionStringSettings
        //     class.
        //
        // 参数:
        //   name:
        //     The name of the connection string.
        //
        //   connectionString:
        //     The connection string.
        public ConnectionStringSettings(string name, string connectionString)
        {

            this.Name = name;
            this.ConnectionString = connectionString;
        }
        //
        // 摘要:
        //     Initializes a new instance of a System.Configuration.ConnectionStringSettings
        //     object.
        //
        // 参数:
        //   name:
        //     The name of the connection string.
        //
        //   connectionString:
        //     The connection string.
        //
        //   providerName:
        //     The name of the provider to use with the connection string.
        public ConnectionStringSettings(string name, string connectionString, string providerName) : this(name, connectionString)
        {
            this.ProviderName = providerName;
        }

        //
        // 摘要:
        //     Gets or sets the System.Configuration.ConnectionStringSettings name.
        //
        // 返回结果:
        //     The string value assigned to the System.Configuration.ConnectionStringSettings.Name
        //     property.
        //[ConfigurationProperty("name", Options = ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsKey, DefaultValue = "")]
        public string Name { get; set; }
        //
        // 摘要:
        //     Gets or sets the connection string.
        //
        // 返回结果:
        //     The string value assigned to the System.Configuration.ConnectionStringSettings.ConnectionString
        //     property.
        //[ConfigurationProperty("connectionString", Options = ConfigurationPropertyOptions.IsRequired, DefaultValue = "")]
        public string ConnectionString { get; set; }
        //
        // 摘要:
        //     Gets or sets the provider name property.
        //
        // 返回结果:
        //     Gets or sets the System.Configuration.ConnectionStringSettings.ProviderName property.
        //[ConfigurationProperty("providerName", DefaultValue = "System.Data.SqlClient")]
        public string ProviderName { get; set; }
        //protected internal override ConfigurationPropertyCollection Properties { get; }

        //
        // 摘要:
        //     Returns a string representation of the object.
        //
        // 返回结果:
        //     A string representation of the object.
        //public override string ToString()
        //{
        //    return 
        //}
    }
}
