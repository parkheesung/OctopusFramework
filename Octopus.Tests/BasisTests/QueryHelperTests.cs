using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octopus.Database.MSSQL;

namespace Octopus.Tests
{
    [TestClass]
    public class QueryHelperTests
    {
        [TestMethod]
        public void Select_Query_Test_1()
        {
            Human sample = new Human();
            string query = sample.toSelect().Write();
            string result = "Select * From human with (nolock)";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void Select_Query_Test_2()
        {
            Human sample = new Human();
            string query = sample.toSelect("seq > 0").Write();
            string result = "Select * From human with (nolock) where seq > 0";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void Select_Query_Test_3()
        {
            Human sample = new Human();
            string query = sample.toSelect("Gender='F'", "seq desc").Write();
            string result = "Select * From human with (nolock) where Gender='F' order by seq desc";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void GroupBy_Query_Test_1()
        {
            Human sample = new Human();
            string query = sample.toGroupBy("Gender").Write();
            string result = "Select Gender From human with (nolock) group by Gender";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void GroupBy_Query_Test_2()
        {
            Human sample = new Human();
            string query = sample.toGroupBy("Gender", "seq > 0").Write();
            string result = "Select Gender From human with (nolock) where seq > 0 group by Gender";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void GroupBy_Query_Test_3()
        {
            Human sample = new Human();
            string query = sample.toGroupBy("Gender", "seq > 0", "seq asc").Write();
            string result = "Select Gender From human with (nolock) where seq > 0 group by Gender order by seq asc";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void List_Query_Test_1()
        {
            Human sample = new Human();
            string query = sample.toList(1).Write();
            StringBuilder builder = new StringBuilder(200);
            builder.Append("Select Top 10 A.* From (");
            builder.Append("Select Top (10 * 1) ROW_NUMBER() OVER (Order by idx) as rowNumber, * ");
            builder.Append("From [human] with (nolock)");
            builder.Append(" ) as A where rowNumber > ((1 - 1) * 10)");

            Assert.AreEqual(builder.ToString(), query);
        }

        [TestMethod]
        public void List_Query_Test_2()
        {
            Human sample = new Human();
            string query = sample.toList(2, 20).Write();
            StringBuilder builder = new StringBuilder(200);
            builder.Append("Select Top 20 A.* From (");
            builder.Append("Select Top (20 * 2) ROW_NUMBER() OVER (Order by idx) as rowNumber, * ");
            builder.Append("From [human] with (nolock)");
            builder.Append(" ) as A where rowNumber > ((2 - 1) * 20)");

            Assert.AreEqual(builder.ToString(), query);
        }

        [TestMethod]
        public void List_Query_Test_3()
        {
            Human sample = new Human();
            string query = sample.toList(2, "Gender='F'", 20).Write();
            StringBuilder builder = new StringBuilder(200);
            builder.Append("Select Top 20 A.* From (");
            builder.Append("Select Top (20 * 2) ROW_NUMBER() OVER (Order by idx) as rowNumber, * ");
            builder.Append("From [human] with (nolock)");
            builder.Append(" where Gender='F'");
            builder.Append(") as A where rowNumber > ((2 - 1) * 20)");

            Assert.AreEqual(builder.ToString(), query);
        }

        [TestMethod]
        public void List_Query_Test_4()
        {
            Human sample = new Human();
            string query = sample.toList(2, "Gender='F'", "idx desc", 20).Write();
            StringBuilder builder = new StringBuilder(200);
            builder.Append("Select Top 20 A.* From (");
            builder.Append("Select Top (20 * 2) ROW_NUMBER() OVER (Order by idx desc) as rowNumber, * ");
            builder.Append("From [human] with (nolock)");
            builder.Append(" where Gender='F'");
            builder.Append(" order by idx desc");
            builder.Append(") as A where rowNumber > ((2 - 1) * 20)");

            Assert.AreEqual(builder.ToString(), query);
        }

        [TestMethod]
        public void Count_Query_Test_1()
        {
            Human sample = new Human();
            string query = sample.toCount().Write();
            string result = "Select Count(1) as [Count] From human with (nolock)";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void Count_Query_Test_2()
        {
            Human sample = new Human();
            string query = sample.toCount("Gender='F'").Write();
            string result = "Select Count(1) as [Count] From human with (nolock) where Gender='F'";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void Update_Query_Test_1()
        {
            Human sample = new Human();
            string query = sample.toUpdate("Gender='F'").Write();
            string result = "Update human Set Gender='F'";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void Update_Query_Test_2()
        {
            Human sample = new Human();
            string query = sample.toUpdate("Gender='F'", "seq=3").Write();
            string result = "Update human Set Gender='F' where seq=3";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void Insert_Query_Test_1()
        {
            Human sample = new Human();
            string query = sample.toInsert("Gender, Age, Name", "@Gender, @Age, @Name").Write();
            string result = "Insert into human (Gender, Age, Name) values (@Gender, @Age, @Name)";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void Delete_Query_Test_1()
        {
            Human sample = new Human();
            string query = sample.toDelete("Gender='F'").Write();
            string result = "Delete From human where Gender='F'";

            Assert.AreEqual(result, query);
        }

        [TestMethod]
        public void TryCatch_Query_Test_1()
        {
            Human sample = new Human();
            string query = sample.toDelete("Gender='F'").toTryCatch("select @@identity", "select -1");
            string result = @"BEGIN TRY
Delete From human where Gender='F'

select @@identity
END TRY
BEGIN CATCH
select -1
END CATCH";

            Assert.AreEqual(result, query);
        }
    }
}
