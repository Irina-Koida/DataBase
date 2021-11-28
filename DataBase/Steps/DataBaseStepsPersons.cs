using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase
{
    [Binding]
    public class DataBaseStepsPersons
    {
        private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext _scenarioContext;

        public DataBaseStepsPersons(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

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
            _scenarioContext["PersonsTable"] = responseTable;
        }

        [Then(@"Table contains data")]
        public void ThenTableContainsData(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastName = responseTable.Rows[numOfRows - 1]["FirstName"].ToString();
            Assert.AreEqual(lastName, table.Rows[0]["FirstName"]);
        }
    }
}
