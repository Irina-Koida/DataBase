Feature: OrdersTable
    As a user
    I want to work with DB data from selected table
    In order to select the data with way I need

@SelectData
Scenario: It is possible to select data to Airport DB
	When I select Buyer from "Orders" table
	Then Table contains buyer data
		| Buyer   |
		| <buyer> |

	Examples:
		| buyer |
		| Albus |