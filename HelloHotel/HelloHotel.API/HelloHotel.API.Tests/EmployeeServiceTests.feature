Feature: EmployeeServiceTests
	As a developer
	I want to add the information of the employees of a hotel
	So I can organanize those information
	
	Background: 
		Given The developer is in the endpoint https://localhost:5001/api/v1/employee
		
	@add_employee
	Scenario: add information of a employee
		When The deveveper select post
		And Insert the information of the employee
		| Id | Name          | LastName       | Dni      | Age | Email             | Phone     | Workstation | Events    |
		| 1  | Fabiana Diana | Flor Carbonell | 35213311 | 30  | flor_31@gmail.com | 922455688 | waiter      | serve bar |
  		Then The system save the information
  		
	@error_message
	Scenario: show a error message
		When The deveveper select post
		And Insert the information of the employee
		  | Id | Name          | LastName       | Dni      | Age | Email             | Phone     | Workstation | Events    |
		  | 1  | Fabiana Diana | Flor Carbonell | 35213311 | 30  | flor_31@gmail.com |  | waiter      | serve bar |
		Then The show a message "insufficient data"
