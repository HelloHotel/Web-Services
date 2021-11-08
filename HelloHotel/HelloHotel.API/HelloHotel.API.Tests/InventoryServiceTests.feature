Feature: InventoryServiceTests
	As a Developer
	I want to add a product
	So that I can have it registered 

	Background: 
		Given The Endpoint https://localhost:5001/api/v1/inventory is available
 
@product-adding
Scenario: Add Inventory
	When A Post request is sent
	  | Name     | Stock | MontUnit | Supplier |
	  | Pringles | 20    | 5        | Pringles |
	Then A Response with Status 200 is received
	And A Inventory Resource is included in Response Body
	  | Name     | Stock | MontUnit | Supplier |
	  | Pringles | 20    | 5        | Pringles |  
   
	Scenario: Add Inventory with existing Name
		Given A Inventory is already stored
		  | Name     | Stock | MontUnit | Supplier |
		  | Pringles | 20    | 5        | Pringles | 
		When A Post request is sent
		  | Name     | Stock | MontUnit | Supplier |
		  | Pringles | 30    | 5        | Pringles | 
		Then A Response with Status 400 is received
		And A Message is included in Response Body with values "Inventory Name already existing." 