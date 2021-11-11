Feature: ClientServiceTests
    As a developer
    I want to get all the information of the clients
    So I can make searchs to find a client
	
    Background: 
        Given The developer is in the endpoint https://localhost:5001/api/v1/clients
       		
    @get_all_clients
    Scenario: get all the clients o the hotel
        When The deveveper select get
        Then The system shows the information of the clients
          | Id | Name           | LastName            | Dni      | Age | Email                | Phone     | Room |
          | 2  | Ramon Lero     | Aznar Urik          | 66372609 | 30  | r.aznar@gmail.com    | 938589708 | 102  |
          | 5  | Elsa Esther    | Guardiola Pacheco   | 81805757 | 28  | eester25@gmail.com   | 958755035 | 206  |
          | 10 | Jeremy Luis    | Torres Brocha       | 79563246 | 28  | jeremytb@gmail.com   | 966985585 | 401  |
          | 13 | Edward         | Alburqueque Paredes | 32154697 | 35  | edwardap@gmail.com   | 988888526 | 404  |
          | 18 | Noelia Viviana | Ruiz Mancco         | 58745996 | 27  | tachinoe16@gmail.com | 965227853 | 506  |
          | .  | ...            | ...                 | ...      | ..  | ......               | .....     | ...  |
          | .  | ...            | ...                 | ...      | ..  | ......               | .....     | ...  |
          | .  | ...            | ...                 | ...      | ..  | ......               | .....     | ...  |
  		
    @error_message
    Scenario: show a error message
        When The deveveper select get
        Then The show a message "no registered customers found"