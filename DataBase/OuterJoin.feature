#Feature: OuterJoin
#	As a user
#      I want to work with DB data from a selected table
#      In order to join the data with the way I need
#
#
#@OuterJoinData
#Scenario Outline: Ability to contain all rows from both tables in DB Airport
#When I select a  Persons table with some data
#
#			When I create row in table "Persons" with data
#		| FirstName | LastName | Age   | 
#		| <name>    | <family> | <age> | 
#	When I select a Orders table with some data
#	
#			When I create row in table "Orders" with data
#		| Buyer | Amount | Delivery   |
#		| <buyer>    | <amount> | <delivery> |
#		Then all the data will be combined into one table
#		| FirstName | LastName | Age   | Buyer | Amount | Delivery   |
#		| <name>    | <family> | <age> |<buyer>    | <amount> | <delivery> |
#		Examples:
#		| <name> | <family> | <age> | <buyer> | <amount> | <delivery> |
#		| NULL   | NULL     | 21    | Cena    | 234,00   | Pigeon     |
#		| NULL   | NULL     | 22    | Dwane   | 345,00   | Auto       |
#		| NULL   | NULL     | 23    | Paulo   | 456,00   | Ship       |
#		| NULL   | NULL     | 24    | Enrique | 567,00   | Car        |
#		| NULL   | NULL     | 25    | Justin  | 678,00   | Airplane   |
