# TriviaBackEnd
BackEnd for [TrivaFrontEnd](https://github.com/rml-80/Triviafrontend) Application in C#
Built in Visual Studio


## Nuget packeges to used / to be installed
1. Microsoft.Extensions.Caching.Memory [Link](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory/5.0.0?_src=template)
2. Newtonsoft.Json [Link](https://www.nuget.org/packages/Newtonsoft.Json/12.0.3?_src=template)
3. Swashbuckle.AspNetCore [Link](https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.6.3?_src=template)


## What does it do?
A simple API BackEnd Application in C#. Get data from [Open Trivia Database](https://opentdb.com/).
There are three ways it gets the data. 

1. Gets all categories

		Gets all categories as a alphabetically sorted list
		Stores the list in MemoryCache, for faster access
		
2. Gets questions from all categories

		Gets requested amount of numbers from all categories
		Adding a alternatives list to the json, as a alphabetically sorted list

3. Gets questions from a selected category

		Gets requested amount of numbers from selected category
		Adding a alternatives list to the json, as a alphabetically sorted list

## Error handling
If an error occurs it will send back a BadRequest.
Because the way Open Triva Database send back data I check response_code in response
and if not success, send back a BadRequest.

	Example: 
		If trying to get a category that dosen't exist. 
		Open Triva Database sends back a OK(Response) but a empty list.
		
## Solid Principle
I used Single Responsible Principle (SRP).

## Link
https://github.com/rml-80/TriviaBackEnd