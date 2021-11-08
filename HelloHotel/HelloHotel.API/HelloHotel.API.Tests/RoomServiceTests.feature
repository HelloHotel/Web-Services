Feature: RoomServiceTests
    As a developer
    I want to update the cost of a room
    So the clients can be informate of the update
	
    Background: 
        Given The developer is in the endpoint https://localhost:5001/api/v1/rooms
        And A room is already stored
          | Id | RoomNumber | Available | Client      | Phone     | DataIn     | DateOut    | Mont |
          | 11  | 303        | false     | Maria Ferre | 997656690 | 28/29/2021 | 05/29/2021 | 1600 |
		
    @update_room_cost
    Scenario: update the cost of a room
        When The deveveper select put
        And update the cost
          | Id | RoomNumber | Available | Client      | Phone     | DataIn     | DateOut    | Mont |
          | 11 | 303        | false     | Maria Ferre | 997656690 | 28/29/2021 | 05/29/2021 | 1800 |
        Then The system save the information
  		
    @error_message
    Scenario: show a error message
        When The deveveper select put
        And update the cost
          | Id | RoomNumber | Available | Client      | Phone     | DataIn     | DateOut    | Mont |
          | 11 | 303        | false     | Maria Ferre | 997656690 | 28/29/2021 | 05/29/2021 | 1800 |
        Then The show a message "unable to update data"