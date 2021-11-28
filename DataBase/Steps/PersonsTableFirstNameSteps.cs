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
        [When(@"I select FirstName between age ""(.*)"" from the Airport DB")]
        public void WhenISelectToFirstNameFromTable(int amount, int amount2, string tableName)
        {
            string query = "SELECT FirstName FROM Persons WHERE Age BETWEEN 1 AND 10";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["PersonsTable"] = responseTable;
        }
        
        [Then(@"Table contains FirstName")]
        public void ThenTableContainsFirstName(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastFirstName = responseTable.Rows[numOfRows - 1]["FirstName"].ToString();
            Assert.AreEqual(lastFirstName, table.Rows[0]["FirstName"]);
        }
    }
}

/*
 private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext _scenarioContext;

        public OrderTableStepsDelivery(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

        [When(@"I select Delivery between Amount (.*) and (.*) in ""(.*)"" table")]
        public void WhenISelectDeliveryBetweenAmountAndFromTable(int amount, int amount2, string tableName)
        {
            string query = "SELECT Delivery FROM Orders WHERE Amount BETWEEN 400 AND 890";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["OrdersTable"] = responseTable;
        }

        [Then(@"Table contains a delivery data")]
        public void ThenTableContainsDeliveryData(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["OrdersTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastDelievery = responseTable.Rows[numOfRows - 1]["Delivery"].ToString();
            Assert.AreEqual(lastDelievery, table.Rows[0]["Delivery"]);
 */