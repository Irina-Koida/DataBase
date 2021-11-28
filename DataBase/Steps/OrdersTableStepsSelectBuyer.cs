using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase.Steps
{
    [Binding]
    public class OrdersTableSteps
    {
        private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext _scenarioContext;

        public OrdersTableSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

        [When(@"I select Buyer from ""(.*)"" table")]
        public void WhenISelectBuyerFromTable(string tableName)
        {
            string query = "SELECT Buyer FROM Orders";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["OrdersTable"] = responseTable;
        }
        
        [Then(@"Table contains buyer data")]
        public void ThenTableContainsBuyerData(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["OrdersTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastBuyer = responseTable.Rows[numOfRows - 1]["Buyer"].ToString();
            Assert.AreEqual(lastBuyer, table.Rows[0]["Buyer"]);
        }
    }
}
