using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase
{
    [Binding]
    public class DataBaseSteps
    {
        private SqlConnectorHelper _sqlHelper = (SqlConnectorHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"I create row in table ""(.*)"" with data")]
        public void WhenICreateRowInTableWithData(string tableName, Table table)
        {
            string query = $"INSERT INTO {tableName} (FirstName, LastName, Age, City ) " +
                $"VALUES ('{table.Rows[0]["FirstName"]}', '{table.Rows[0]["LastName"]}', '{table.Rows[0]["Age"]}', '{table.Rows[0]["City"]}')";
            _sqlHelper.MakeQuery(query);
        }

        [When(@"I select whole ""(.*)"" table")]
        public void WhenISelectWholeTable(string tableName)
        {
            string query = "SELECT * FROM Persons";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonsTable"] = responseTable;
        }

        [Then(@"Table contains data")]
        public void ThenTableContainsData(Table table)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastAuthors = responseTable.Rows[numOfRows - 1]["FirstName"].ToString();
            Assert.AreEqual(lastAuthors, table.Rows[0]["FirstName"]);
        }
    }
}
