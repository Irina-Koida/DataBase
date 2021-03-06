using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase.Steps
{
    [Binding]
    public class DataBaseStepsOrders
    {
        private readonly SqlConnectorHelper _sqlHelper;
        private readonly ScenarioContext  _scenarioContext;

        public DataBaseStepsOrders(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

        [When(@"I create row in table ""(.*)"" with some data")]
        public void WhenICreateRowInTableWithSomeData(string tableName, Table table)
        {

            string query = $"INSERT INTO {tableName} (Buyer, Amount, Delivery ) " +
                $"VALUES ('{table.Rows[0]["Buyer"]}', '{table.Rows[0]["Amount"]}', '{table.Rows[0]["Delivery"]}')";
            _sqlHelper.MakeQuery(query);
        }
        
        [When(@"I select all ""(.*)"" table")]
        public void WhenISelectAllTable(string tableName)
        {
            string query = "SELECT * FROM Orders";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["OrdersTable"] = responseTable;
        }
        
        [Then(@"Table contains some data")]
        public void ThenTableContainsSomeData(Table table)
        {
            DataTable responseTable = (DataTable)_scenarioContext["OrdersTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastBuyer = responseTable.Rows[numOfRows - 1]["Buyer"].ToString();
            Assert.AreEqual(lastBuyer, table.Rows[0]["Buyer"]);
        }
    }
}
