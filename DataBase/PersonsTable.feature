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


@SelectData
Scenario Outline: It is possible to select LastName data between ID_Persons 15 and 18 from Airport DB
	When I select LastName between ID_Persons 15 and 18 in "Persons" table
	Then the table contains data on the selected delivery ID 
		| LastName   |
		| <lastname> |

	Examples:
		| lastname |
		| Robin    |

@Select
Scenario Outline: It is possible to select Age, where LastName located between Johnson and Tom from Airport DB
	When I select Age between LastName Johnson and Tom in "Persons" table
	Then Table contains amount age
		| Age   |
		| <age> |

	Examples:
		| age |
		| 35  |

@Select
Scenario Outline: It is possible to select FirstName, between age from the Airport DB
	When I select FirstName between Age 1 and 10 from the Airport DB
	Then The table displays the data for the selected name 
		| FirstName |
		| <name>    |

	Examples:
		| name      |
		| Karsinski |