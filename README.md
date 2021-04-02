# BizStream Assignment

Goal was to create the following form:

<img width="541" alt="image" src="https://user-images.githubusercontent.com/7775950/113376750-72e91500-9340-11eb-9db6-88a46d544b3b.png">

## Technologies Used
- .NET 5
- MVC (C#)
- React (create-react-app)

## How to Run
Pull the repo and load into either Visual Studio or IntelliJ Rider.  Make sure both the `Client` and `Server` projects are set to run.  Then simply run the program.

Alternatively, using the `dotnet` CLI, open two Terminals and run:
- `dotnet run --project ./BizStream.Assignment.Client/BizStream.Assignment.Client.csproj`
- `dotnet run --project ./BizStream.Assignment.Server/BizStream.Assignment.Server.csproj`

## Known limitations
I did not have enough time to really flesh this out nor test on a variety of platforms. As such, the following are known limitations:
- Validation is mostly limited to "does the field have data"
- Validation feedback is lacking and only generally says it cannot submit
- On submit, success/fail message does not go away
- Possible code injection exists within the `message` field

Testing was only done on the latest version of Firefox from a Mac machine.  There are other possible issues with other browsers / platforms.
