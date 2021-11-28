Feature: PersonsTable
    As a user
    I want to work with DB data from selected table
    In order to select the data with way I need

@SelectData
Scenario: It is possible to select data to Airport DB
	When I select to Sity from "Persons" table
	Then Table contains sity data
		| City   |
		| <city> |

	Examples:
		| city    |
		| Lisburn |