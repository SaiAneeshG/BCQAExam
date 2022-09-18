Feature: RegisterNewUserTest
	As a registered user
	I want to be able to login to the website
	So that I can view my account details

@tag1
Scenario Outline: Register a New User
	Given I am in the home page of the system
	When I enter a valid "<EmailAddress>" and click on create account
	Then I should be navigated to the create an account page
	And I enter details and click on Register
	And I am navigated to My Account Page
	And I click on signout button
	And I click on signin button to verify login
	And I signin with my new account
	And I am navigated to My Account Page
	Examples: 
	| EmailAddress |
	| email1       |
	| email2       |
	| email3       |
	| email4       |
	| email5       |