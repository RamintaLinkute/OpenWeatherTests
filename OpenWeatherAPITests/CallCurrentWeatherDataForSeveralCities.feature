Feature: CallCurrentWeatherDataForSeveralCities
	In order to get weather data from the API
	As an API consumer
	I want to get weather data for several cities

Scenario: Call for several city IDs
	Given IDs '524901 703448 2643743' exists in the system
	When I request to get the weather data by ids
	Then Count '3' is returned in the response
	And the status code 'OK' is returned in the response

Scenario: Call for more than 20 city IDs
	Given IDs '524901,703448,2643743,524901,703448,2643743,524901,703448,2643743,524901,703448,2643743,524901,703448,2643743,524901,703448,2643743,524901,703448,2643743' exists in the system
	When I request to get the weather data by ids
	Then Message 'id list must be in range from 1 to 20' is returned in the response



	