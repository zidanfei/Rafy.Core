/*******************************************************
 * 
 * 作者：胡庆访
 * 创建时间：20110102
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20110102
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rafy;
using Rafy.Data;
using Rafy.DbMigration;
using Rafy.DbMigration.History;
using Rafy.DbMigration.Model;
using Rafy.DbMigration.Operations;
using Rafy.DbMigration.SqlServer;


namespace RafyUnitTest
{
    [TestClass]
    public class DbMigrationDataBaseTest
    {
        [ClassInitialize]
        public static void DbMigrationTest_ClassInitialize(TestContext context)
        {
            ServerTestHelper.ClassInitialize(context);
        }

        [TestMethod]
        public void DMDBT_CreateDatabase()
        {
            using (var context = new DbMigrationContext(DbSetting.FindOrCreate( "Test_TestingDataBase")))
            {
                //context.HistoryRepository = new HistoryRepository();
                context.RunDataLossOperation = DataLossOperation.All;

                if (!context.DatabaseExists())
                {
                    var destination = new DestinationDatabase("Test_TestingDataBase");
                    var tmpTable = new Table("TestingTable", destination);
                    tmpTable.AddColumn("Id", DbType.Int32, isPrimaryKey: true);
                    tmpTable.AddColumn("Name", DbType.String);
                    destination.Tables.Add(tmpTable);

                    context.MigrateTo(destination);

                    //历史记录
                    //var histories = context.GetHistories();
                    //Assert.IsTrue(histories.Count == 3);
                    //Assert.IsTrue(histories[2] is CreateDatabase);

                    //数据库结构
                    Assert.IsTrue(context.DatabaseExists());
                }
            }
        }

        [TestMethod]
        public void DMDBT_DropDatabase()
        {
            //以下代码不能运行，会提示数据库正在被使用
            using (var context = new DbMigrationContext(DbSetting.FindOrCreate("Test_TestingDataBase")))
            {
                //context.HistoryRepository = new DbHistoryRepository();
                context.RunDataLossOperation = DataLossOperation.All;

                if (context.DatabaseExists() && !(context.DbVersionProvider is EmbadedDbVersionProvider))
                {
                    //context.DeleteDatabase();
                    var database = new DestinationDatabase("Test_TestingDataBase") { Removed = true };
                    context.MigrateTo(database);

                    //历史记录
                    var histories = context.GetHistories();
                    Assert.IsTrue(histories[0] is DropDatabase);

                    //数据库结构
                    Assert.IsTrue(!context.DatabaseExists());
                }

                context.ResetHistory();
            }

            
        }

        
    }
}