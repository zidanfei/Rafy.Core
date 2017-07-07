using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Rafy.Data.Providers
{
    //https://github.com/dotnet/corefx/issues/6476
    //public abstract class DbProviderFactories
    //{

    //    internal static readonly Dictionary<string, Func<DbProviderFactory>> _configs = new Dictionary<string, Func<DbProviderFactory>>();

    //    public static DbProviderFactory GetFactory(string providerInvariantName)
    //    {
    //        ADP.CheckArgumentLength(providerInvariantName, nameof(providerInvariantName));

    //        if (_configs.ContainsKey(providerInvariantName))
    //        {
    //            return _configs[providerInvariantName]();
    //        }

    //        throw ADP.ConfigProviderNotFound();
    //    }

    //    public static DbProviderFactory GetFactory(DbConnection connection)
    //    {
    //        ADP.CheckArgumentNull(connection, nameof(connection));
    //        return connection.ProviderFactory;
    //    }

    //    public static void RegisterFactory(string providerInvariantName, DbProviderFactory factory)
    //    {
    //        ADP.CheckArgumentNull(providerInvariantName, nameof(providerInvariantName));
    //        ADP.CheckArgumentNull(constructorDelegate, nameof(constructorDelegate));

    //        _configs[providerInvariantName] = factory;
    //    }

    //    public static IEnumerable<string> GetFactoryProviderNames()
    //    {
    //        return _configs.Keys.toArray();
    //    }
    //}
    public class DbProviderFactories
    {
        public static DbProviderFactory GetFactory(string provider)
        {
            switch (provider)
            {
                case DbSetting.Provider_SqlClient:
                    return SqlClientFactory.Instance;
                //PatrickLiu增加的有关获取MySql的Provider工厂类
                case DbSetting.Provider_MySql:
                    return MySql.Data.MySqlClient.MySqlClientFactory.Instance;
                default:
                    return SqlClientFactory.Instance;
            }


        }
    }
}