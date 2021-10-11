Feature: Login
	Login to a sample application

@CIS-46
Scenario: Test login process to the CIS application
	Given I launch the application
	And I enter the following details
	    | UserName | Password |
	    | Farrukh  | ciscon4 |
	And I click login button
	And I should see logo image 
	And I logout application
	Then I close application

@CIS-47
Scenario: Test login process to the CIS application with wrong password
	Given I launch the application
	And I enter the following details
	    | UserName | Password  |
	    | abcd     | unknown   |
	And I click login button
	And I should see login error message 
	Then I close application