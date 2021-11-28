using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace DataBase.Steps
{
    [Binding]
    public class PersonsTableStepsCity
    {
        private readonly SqlConnectorHelper _sqlHelper = (SqlConnectorHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"I select to Sity from ""(.*)"" table")]
        public void WhenISelectBuyerFromTable(string tableName)
        {
            string query = "SELECT City FROM Persons";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonsTable"] = responseTable;
        }
        
        [Then(@"Table contains sity data")]
        public void ThenTableContainsBuyerData(Table table)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastCity = responseTable.Rows[numOfRows - 1]["City"].ToString();
            Assert.AreEqual(lastCity, table.Rows[0]["City"]);
        }
    }
}
/*

namespace DataBase.Steps
{
    [Binding]
    public class OrdersTableSteps
    {
       
        [When(@"I select Buyer from ""(.*)"" table")]
        public void WhenISelectBuyerFromTable()
        {
            string query = "SELECT Buyer FROM Orders";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["OrdersTable"] = responseTable;
        }
        
        [Then(@"Table contains buyer data")]
        public void ThenTableContainsBuyerData(Table table)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["OrdersTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastBuyer = responseTable.Rows[numOfRows - 1]["Buyer"].ToString();
            Assert.AreEqual(lastBuyer, table.Rows[0]["Buyer"]);
        }
    }
}
*/