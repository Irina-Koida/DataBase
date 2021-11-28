using System;
using TechTalk.SpecFlow;

namespace DataBase.Steps
{
    [Binding]
    public class PersonsTableSteps
    {
        [When(@"I select Sity from ""(.*)"" table")]
        public void WhenISelectBuyerFromTable(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Table contains sity data")]
        public void ThenTableContainsBuyerData(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
