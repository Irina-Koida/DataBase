//using System;
//using TechTalk.SpecFlow;

//namespace DataBase
//{
//    [Binding]
//    public class OuterJoinSteps
//    {
//        private readonly SqlConnectorHelper _sqlHelper = (SqlConnectorHelper)ScenarioContext.Current["SqlHelper"];

//        [When(@"I create a row in the Persons table with some data")]
//        public void WhenICreateARowInThePersonsTableWithSomeData(string tableName, Table table)
//        {
//            string query = $"INSERT INTO {tableName} (FirstName, LastName, Age, City ) " +
//               $"VALUES ('{table.Rows[0]["FirstName"]}', '{table.Rows[0]["LastName"]}', '{table.Rows[0]["Age"]}', '{table.Rows[0]["City"]}')";
//            _sqlHelper.MakeQuery(query);
//        }
        
//        [When(@"I create a row in the Orders table with some data")]
//        public void WhenICreateARowInTheOrdersTableWithSomeData(string tableName)
//        {
//            string query = "SELECT * FROM Persons";
//            DataTable responseTable = _sqlHelper.MakeQuery(query);
//            ScenarioContext.Current["PersonsTable"] = responseTable;
//        }

//        [Then(@"Table contains data")]
//        public void ThenTableContainsData(Table table)
//        {
//            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonsTable"];
//            int numOfRows = responseTable.Rows.Count;
//            string lastName = responseTable.Rows[numOfRows - 1]["FirstName"].ToString();
//            Assert.AreEqual(lastName, table.Rows[0]["FirstName"]);
//        }
//    }
//}
