Feature: OrdersTable
    As a user
    I want to work with DB data from selected table
    In order to select the data with way I need

@SelectData
Scenario: It is possible to select Buyer data to Airport DB
	When I select Buyer from "Orders" table
	Then Table contains buyer data
		| Buyer   |
		| <buyer> |

	Examples:
		| buyer |
		| Albus |

@SelectData
Scenario: It is possible to select Delivery data between Amount 400 and 890 from Airport DB
	When I select Delivery between Amount 400 and 890 in "Orders" table
	Then Table contains a delivery data
		| Delivery   |
		| <delivery> |

	Examples:
		| delivery |
		| Ship     |

