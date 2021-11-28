Feature: PersonsTable
    As a user
    I want to work with DB data from selected table
    In order to select the data with way I need

@SelectData
Scenario: It is possible to select data to Airport DB
	When I select to City from "Persons" table
	Then Table contains city data
		| City   |
		| <city> |

	Examples:
		| city    |
		| Lisburn |

#		///////////////////////////////////////////
#
#@SelectData
#Scenario Outline: It is possible to select Delivery data between Amount 400 and 890 from Airport DB
#	When I select Delivery between Amount 400 and 890 in "Orders" table
#	Then Table contains a delivery data
#		| FirstName |
#		| <name>    |
#
#	Examples:
#		| name   |
#		| Dwayne |
#
#@Select
#Scenario Outline: It is possible to select FirstName, where Delivery located between car and ship from Airport DB
#	When I select Amount between Delivery car and ship in "Orders" table
#	Then Table contains amount data
#		| Amount   |
#		| <amount> |
#
#	Examples:
#		| amount    |
#		| 4567.0000 |
@Select
Scenario outline: It is possible to select FirstName, between age from the Airport DB
	When I select FirstName between age from the Airport DB
	Then The table then contains the data by name in "Persons" table
		| FirstName |
		| <name>    |

	Examples:
		| name   |
		| Karsinski |