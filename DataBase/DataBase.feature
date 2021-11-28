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

