# Pluto investigation

This is a test API service built on top of [.Net Core Framework](https://dotnet.microsoft.com/download/dotnet/3.1) **3.1** exposing an endpoint simulating a rover controller.<br><br>
The project structure and implementation follow a DDD approach where the Domain layer is the center of everything, using Rich Domain models performing businesslogic and maintaining their internal state.

Requests validation has been decoupled by using [FluentValidation](https://fluentvalidation.net/).

## Project dependencies

   * <a href="https://fluentvalidation.net/" target="_blank">FluentValidation.AspNetCore 10.3.3</a>
   * <a href="https://www.nuget.org/packages/xunit" target="_blank">xUnit 2.4.1</a>
   * <a href="https://www.nuget.org/packages/FluentAssertions/" target="_blank">FluentAssertions 6.1.0</a>

## Tests
Tests are covering the whole <a href="https://github.com/pregoli/Pluto.Investigation/tree/master/Pluto.Investigation.Tests/Application" target="_blank">Application</a> and <a href="https://github.com/pregoli/Pluto.Investigation/tree/master/Pluto.Investigation.Tests/Domain" target="_blank">Domain</a> layers.
<br>
Test cases covering the requirements are available <a href="https://github.com/pregoli/Pluto.Investigation/blob/master/Pluto.Investigation.Tests/Domain/Entities/RoverTests.cs" target="_blank">here</a>.

## Usage

   * Open the Pluto.Investigation solution
   * Build the solution
   * Run the tests from your favourite IDE or command line
      * <a href="https://www.jetbrains.com/help/rider/Unit_Testing__Index.html" target="_blank">Rider</a>
      * <a href="https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019" target="_blank">Visual Studio</a>
      * <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test" target="_blank">dotnet test</a>
    
## Notes
The .Net Core 3.1 has been choosen because LTS, see <a href="https://dotnet.microsoft.com/platform/support/policy/dotnet-core" target="_blank">here</a>.

