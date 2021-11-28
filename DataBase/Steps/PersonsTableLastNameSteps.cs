using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;


namespace DataBase.Steps
{
    [Binding]
    public class PersonsTableLastNameSteps
    {
        private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext _scenarioContext;

        public PersonsTableLastNameSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

        [When(@"I select LastName between ID_Persons (.*) and (.*) in ""(.*)"" table")]
        public void WhenISelectLastNameBetweenID_PersonsAndInTable(int amount, int amount2, string tableName)
        {
            string query = "SELECT LastName FROM Persons WHERE ID_Persons BETWEEN 15 AND 18";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["PersonsTable"] = responseTable;
        }

        [Then(@"the table contains data on the selected delivery ID")]
        public void ThenTheTableContainsDataOnTheSelectedDeliveryID(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastLastName = responseTable.Rows[numOfRows - 1]["LastName"].ToString();
            Assert.AreEqual(lastLastName, table.Rows[0]["LastName"]);
        }
    }
}
