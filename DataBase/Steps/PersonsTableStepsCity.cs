using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase.Steps
{
    [Binding]
    public class PersonsTableStepsCity
    {
        private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext _scenarioContext;

        public PersonsTableStepsCity(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

        [When(@"I select to City from ""(.*)"" table")]
        public void WhenISelectToCityFromTable(string tableName)
        {
            string query = "SELECT City FROM Persons";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["PersonsTable"] = responseTable;
        }
        [Then(@"Table contains city data")]
        public void ThenTableContainsCityData(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastCity = responseTable.Rows[numOfRows - 1]["City"].ToString();
            Assert.AreEqual(lastCity, table.Rows[0]["City"]);
        }
    }
}
