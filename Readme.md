# CalculatorService
CalculatorService is a simple RESTful web service for performing basic arithmetic operations. The service allows clients to send HTTP GET requests with two numerical arguments and receive the result of the operation.

# Getting Started
To get started with CalculatorService, you will need to have the .NET Core SDK installed on your machine. You can download the latest version of the SDK from the .NET Core downloads page.

Once you have installed the .NET Core SDK, follow these steps:

1. Clone the CalculatorService repository to your local machine:
```git clone https://github.com/Mirotivo/calculator.git```
2. Navigate into the project directory:
```cd CalculatorService```
3. Run the following command to start the application:
```dotnet run```
4. Once the application is running, you can send HTTP GET requests to the appropriate endpoints to perform arithmetic operations.
 
For example, to add two numbers, you can send a request to http://92.205.162.126:8050/calculator/add/5/3 and expect to receive a response with the value 8.

# Endpoints
The following endpoints are available in the CalculatorService API:

```GET /api/Calculator/add/{a}/{b}``` - Adds two numbers and returns the result.  
```GET /api/Calculator/subtract/{a}/{b}``` - Subtracts two numbers and returns the result.  
```GET /api/Calculator/multiply/{a}/{b}``` - Multiplies two numbers and returns the result.  
```GET /api/Calculator/divide/{a}/{b}``` - Divides two numbers and returns the result. Returns a 400 Bad Request response if the second number is zero.

# License
CalculatorService is released under the MIT License. See LICENSE for details.