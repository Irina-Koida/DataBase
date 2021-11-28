Feature: OuterJoin
	As a user
    I want to work with DB data
    In order to operate the data the way I need 


@OuterJoinData
Scenario Outline: ability to contain all rows from both tables in DB Airport
When I create a row in the Persons table with some data

			When I create row in table "Persons" with data
		| FirstName | LastName | Age   | City   |
		| <name>    | <family> | <age> | <city> |
	When I create a row in the Orders table with some data
	
			When I create row in table "Orders" with data
		| Buyer | Amount | Delivery   |
		| <name>    | <amount> | <delivery> |

		1	John	123,00	Airplane
2	Cena	234,00	Pigeon
3	Dwayne	345,00	Auto
4	Paulo	456,00	Ship
5	Enrique	567,00	Car
6	Justin	678,00	Airplane
7	Sofia	789,00	Pigeon
		Examples: