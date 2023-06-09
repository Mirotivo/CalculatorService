# CalculatorService
CalculatorService is a simple RESTful web service for performing basic arithmetic operations. The service allows clients to send HTTP GET requests with two numerical arguments and receive the result of the operation.

# Getting Started
To get started with CalculatorService, you will need to have the .NET Core SDK installed on your machine. You can download the latest version of the SDK from the .NET Core downloads page.

Once you have installed the .NET Core SDK, follow these steps:

1. Clone the CalculatorService repository to your local machine:
```https://github.com/Mirotivo/CalculatorService.git```
1. Navigate into the project directory:
```cd CalculatorService```
1. Run the following command to start the application:
```dotnet run```
1. Once the application is running, you can send HTTP GET requests to the appropriate endpoints to perform arithmetic operations.
 
For example, to add two numbers, you can send a request to http://92.205.162.126:8050/calculator/add?a=5&b=3 and expect to receive a response with the value 8.

# Deploying Application to IIS

## 1. Check .NET Core Version

- Run the following command to check the .NET Core version: ```dotnet --version```
## 2. Install the Correct Hosting Bundle

- Download and install the appropriate .NET Core Hosting Bundle for your server from the official Microsoft website.
## 3. Create a Website in IIS

- Open the Internet Information Services (IIS) Manager.
- Right-click on "Sites" and select "Add Website".
- Provide a name for the website (e.g., "calc").
- Set the physical path to the location where you want to deploy the application (e.g., "C:\inetpub\wwwroot\calc").
- Configure the necessary bindings (e.g., hostname, IP address, and port) for your website.

## 4. Publish the .NET Core Application

- Navigate to the root directory of your .NET Core project.
- Run the following command to publish the application:
```
dotnet publish --configuration Release --output "C:\inetpub\wwwroot\calc"
```
## 5. Test the Deployment

- Open a web browser.
- Navigate to the URL of your website (e.g., http://localhost).
- If everything is set up correctly, you should see your .NET Core application running in the browser.


# Endpoints
The following endpoints are available in the CalculatorService API:

```GET /calculator/add?a={a}&b={b}``` - Adds two numbers and returns the result.  
```GET /calculator/subtract?a={a}&b={b}``` - Subtracts two numbers and returns the result.  
```GET /calculator/multiply?a={a}&b={b}``` - Multiplies two numbers and returns the result.  
```GET /calculator/divide?a={a}&b={b}``` - Divides two numbers and returns the result. Returns a 400 Bad Request response if the second number is zero.

# License
CalculatorService is released under the MIT License. See LICENSE for details.