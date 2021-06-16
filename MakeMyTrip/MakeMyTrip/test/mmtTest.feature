Feature: MMT flight test

#MMT flight test
@mmt_test
Scenario Outline: MMT flight test
	Given Prerequisites of the testcase
	When Launch browser for MMM_TEST
	Then Click on tab <Flight> on homepage
	And Click on from city drop down
	And Fetch all of the cities in the drop-down
	And Select city <FromCity> from From city drop down
	And Select city <ToCity> from To city drop down
	And Select departure <DepartureDate> and return <ReturnDate> date
	And Click on Search button
	And Sort from the departure column for departure flight list
	And Sort from the departure column for return  flight list
	And Select first flight from both of the options
	And Click on BookNow  and Continue button
	And Display the fare summary
	And Close the second tab
	And Close the testcase

Examples:
	| Flight | FromCity | ToCity | DepartureDate | ReturnDate | 
	| Flight | Delhi | Chandigarh | 26-06-2021 | 30-06-2021 |