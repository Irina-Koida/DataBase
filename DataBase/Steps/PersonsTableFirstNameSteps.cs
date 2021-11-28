using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase.Steps
{
    [Binding]
    public class PersonsTableFirstNameSteps
    {
        private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext _scenarioContext;

        public PersonsTableFirstNameSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }
        [When(@"I select FirstName between Age (.*) and (.*) from the Airport DB")]
        public void WhenISelectFirstNameBetweenAgeAndFromTheAirportDB(int amount, int amount1)
        { 
            string query = "SELECT FirstName FROM Persons WHERE Age BETWEEN 1 AND 10";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["PersonsTable"] = responseTable;
        }

        [Then(@"The table displays the data for the selected name")]
        public void ThenTheTableDisplaysTheDataForTheSelectedName(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastFirstName = responseTable.Rows[numOfRows - 1]["FirstName"].ToString();
            Assert.AreEqual(lastFirstName, table.Rows[0]["FirstName"]);
        }
    }
}



