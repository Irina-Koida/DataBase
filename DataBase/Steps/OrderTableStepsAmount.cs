using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase.Steps
{
    [Binding]
    public class OrderTableStepsAmount
    {
        private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext _scenarioContext;

        public OrderTableStepsAmount(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

        [When(@"I select Amount between Delivery car and ship in ""(.*)"" table")]
        public void WhenISelectAmountBetweenDeliveryCarAndShipInTable(string tableName)
        {
            string query = "SELECT Amount FROM Orders WHERE Delivery BETWEEN 'Car' AND 'Ship'";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["OrdersTable"] = responseTable;
        }
        
        [Then(@"Table contains amount data")]
        public void ThenTableContainsAmountData(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["OrdersTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastAm = responseTable.Rows[numOfRows - 1]["Amount"].ToString();
            Assert.AreEqual(lastAm, table.Rows[0]["Amount"]);
        }
    }
}
