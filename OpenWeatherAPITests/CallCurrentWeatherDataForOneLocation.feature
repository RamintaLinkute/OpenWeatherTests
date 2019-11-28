Feature: CallCurrentWeatherDataForOneLocation
	In order to get weather data from the API
	As an API consumer
	I want to get weather data for one location

Scenario: Call current weather data for one location by city name
	Given City 'London' exists in the system
	When I request to get the weather data by city
	Then City 'London' is returned in the response
	And description 'moderate rain' is returned in the response
	And status code 'OK' is returned in the response 

Scenario: Call current weather data for one location by non-existing city name
	Given City 'NonExistingCityName' does not exist in the system
	When I request to get the weather data by city
	Then status code 'NotFound' is returned in the response 

Scenario: Call current weather data for one location by city name and country code
	Given City 'London' exists in the system
	And country code 'uk' exists in the system
	When I request to get the weather data by city and country code
	Then City 'London' is returned in the response
	And status code 'OK' is returned in the response 

Scenario: Call current weather data for one location by city name and non-existing country code
	Given City 'London' exists in the system
	And country code 'cccccc' does not exist in the system
	When I request to get the weather data by city and country code
	Then status code 'NotFound' is returned in the response 

Scenario: Call current weather data for one location by city ID
	Given ID '2172797' exists in the system
	When I request to get the weather data by id 
	Then City 'Cairns' is returned in the response