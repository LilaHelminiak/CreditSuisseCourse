Feature: UpdateMarketData
	In order to calculate the portfolio
	As a Timer
	I want to update market data


Scenario: Generate data
	Given I connect to Data Generator Service
	When I retrive generated data
	Then I get stock price
	And I get business date and time

Scenario: Update market data
	Given Generated data by Data Generator Service
	And Market with data before the update
	When Market updates the data
	Then Stock price is updated
	And Business date and time is updated
