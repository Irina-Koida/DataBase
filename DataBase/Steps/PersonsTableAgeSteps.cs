using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase.Steps
{
    [Binding]
    public class PersonsTableAgeSteps
    {
        private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext _scenarioContext;

        public PersonsTableAgeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

        [When(@"I select Age between LastName Johnson and Tom in ""(.*)"" table")]
        public void WhenISelectAgeBetweenLastNameJohnsonAndTomInTable(string tableName)
        {
            string query = "SELECT Age FROM Persons WHERE LastName BETWEEN 'Johnson' AND 'Tom'";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["PersonsTable"] = responseTable;
        }
        
        [Then(@"Table contains amount age")]
        public void ThenTableContainsAmountAge(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastAm = responseTable.Rows[numOfRows - 1]["Age"].ToString();
            Assert.AreEqual(lastAm, table.Rows[0]["Age"]);
        }
    }
}
