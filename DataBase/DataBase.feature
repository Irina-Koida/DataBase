Feature: DataBase
	As a user
    I want to work with DB data
    In order to operate the data the way I need 

@InsertData
Scenario Outline:  It is possible to insert data to Airport DB
	When I create row in table "Persons" with data
		| FirstName | LastName | Age   | City   |
		| <name>    | <family> | <age> | <city> |
	When I select whole "Persons" table
	Then Table contains data
		| FirstName | LastName | Age   | City   |
		| <name>    | <family> | <age> | <city> |

	Examples:
		| name    | family      | age | city       |
		| Lucius  | Malfoy      | 35  | Aberdeen   |
		| Tom     | Riddle      | 50  | Armagh     |
		| Lily    | Evans       | 35  | Bristol    |
		| Severus | Snape       | 35  | Birmingham |
		| Albus   | Doumbledore | 78  | Lisburn    |

@InsertData
Scenario Outline:  It is possible to insert data to DB Airport 
	When I create row in table "Orders" with some data
		| Buyer   | Amount   | Delivery   |
		| <buyer> | <amount> | <delivery> |
	When I select all "Orders" table
	Then Table contains some data
		| Buyer   | Amount   | Delivery   |
		| <buyer> | <amount> | <delivery> |

	Examples:
		| buyer   | amount  | delivery   |
		| Lucius  | 456,00  | Aconite    |
		| Tom     | 934,98  | Asphodel   |
		| Lily    | 3218,00 | Badian     |
		| Severus | 457,89  | Belladonna |
		| Albus   | 231,00  | Bubontuber |