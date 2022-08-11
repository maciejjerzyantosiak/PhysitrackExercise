# PhysitrackExercise
## How to run the project
### 1. Localy on Windows:
    Prerequisites:
    1. Java is installed.
    2. Selenium server is installed: https://github.com/SeleniumHQ/selenium/releases/download/selenium-4.4.0/selenium-server-4.4.0.jar
    3. Chrome browser is installed.
    4. Chrome driver is installed: https://chromedriver.chromium.org/downloads
    5. NUnit Console Runner is installed: https://github.com/nunit/nunit-console/releases
    6. .NET Framework 4.5 might have to be installed: https://www.microsoft.com/pl-pl/download/details.aspx?id=30653
    7. .NET Core 3.1 SDK is installed: https://dotnet.microsoft.com/en-us/download/dotnet/3.1
    8. .NET Runtime 3.1 is installed: https://dotnet.microsoft.com/en-us/download/dotnet/3.1
    9. Build Tools (MSBuild) for Visual Studio 2022 are installed: https://aka.ms/vs/17/release/vs_BuildTools.exe
    10. Environment variables are set up correctly:
        1. System/User variable: Path should contain directory where Chrome driver is installed.
        2. New variable: MSBuildSDKsPath with value: C:\Program Files\dotnet\sdk\3.1.421\Sdks (default path pointing to .NET Core 3.1 SDK install location) should be     added. 
    
### 2. Localy on Linux:

### 3. Remotely on Windows:
    1. Login via Remote Desktop Connection to: ec2-3-80-30-46.compute-1.amazonaws.com 
            Login: Administrator 
            Password: Sent in the email.
    2. Make sure that java server is running on http://localhost:4444/ui, if not, start StartSeleniumServer.bat on the desktop.
    3. Fresh copy copy of the project should be in C:\physitrack.
    4. To build it, please run BuildAutomatedScript.bat on the desktop.
    5. To run the solution, please run RunAutomatedScript.bat on the desktop.
    6. Test results should be displayed in the console and in "C:\physitrack\Physitrack.WebAutomation\bin\Release\netcoreapp3.1\TestResult.xml".
    
    Notes: Host is running in NAM, because of that automation step: Pick USA as your country (server selection), is not appearing in the browser.

    
