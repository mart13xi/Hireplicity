Prerequisite
--Windows 10 and up, MacOS and Linux
--Visual Studio 2022
--.Net 8

For Visual Studio 2022
-Open the solution file "Hireplicity.sln."
-This will open Visual Studio 2022.
-Build and run the application.
-It will open an Aspire project a new tool for developers
-Select the "Hireplicity.CodeChallenge.Api" endpoint from the list.

For Command line
-Since I don't have a MacOS or Linux machine, I am unable to test this method on those systems, but you can use CMD to build the application. However, you'll need to have the .NET 8 framework installed on your computer.
-Go to the root folder of the project.
-Open the terminal.
-Run the command dotnet restore.
-Next, run dotnet build and ignore any warnings
-Navigate to the AppHost folder by running "cd .\Hireplicity.AppHost\"
-Execute dotnet run.
-Copy the URL provided under "Login to the dashboard."
-Finally, click on the "Hireplicity.CodeChallenge.Api" endpoint in the list

In Visual Studio 2022, you can run the unit test. However, due to time constraints, I was only able to create a positive scenario.