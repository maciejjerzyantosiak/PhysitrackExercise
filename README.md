# Physitrack Exercise - recruitment project made during technical interview in 2022 and later refactored.
## Introduction
Welcome to the PhysitrackExercise project. This project is geared toward automation testing and aims to ensure the seamless functionality of Physitrack Web applications. Here, you'll find detailed instructions for setting up and running the project, whether you prefer a remote or local environment.

## Project Configuration:
Before we dive into the steps for running the project, here are a few essential configuration notes: 

    1. Default Selenium Server: The project is configured to connect to the Selenium server hosted at ec2-3-80-30-46.compute-1.amazonaws.com by default. You can manually adjust this configuration in the appsettings.json file.
    2. Remote Access: For remote access and monitoring of the automation progress, you can log in to the server at ec2-3-80-30-46.compute-1.amazonaws.com using Remote Desktop Connection. Credentials for login are provided via email.
    
## Running the Project
        
### Option 1: Remote Execution on Windows
    1. Login via Remote Desktop Connection to: ec2-3-80-30-46.compute-1.amazonaws.com 
            Login: Administrator 
            Password: Sent in the email.
    2. Make sure that java server is running on http://localhost:4444/ui, if not, start StartSeleniumServer.bat on the desktop.
    3. A fresh copy of the project should be in C:\physitrack.
    4. To build it, please run BuildAutomatedScript.bat on the desktop.
    5. To run the solution, please run RunAutomatedScript.bat on the desktop.
    6. Test results should be displayed in the console and in "C:\physitrack\PhysitrackExercise-main\Physitrack.WebAutomation\bin\Release\netcoreapp3.1\TestResult.xml".
    
    Notes: Host is running in NAM region, because of that automation step: Pick USA as your country (server selection), is not appearing in the browser.

### Option 2: Local Execution on Windows
    Prerequisites:
    1. .NET Core 3.1 SDK is installed: https://dotnet.microsoft.com/en-us/download/dotnet/3.1
    2. .NET Framework 4.5 might have to be installed: https://www.microsoft.com/pl-pl/download/details.aspx?id=30653
    3. .NET Runtime 3.1 is installed: https://dotnet.microsoft.com/en-us/download/dotnet/3.1
    4. NUnit Console Runner is installed: https://github.com/nunit/nunit-console/releases
    5. Build Tools (MSBuild) for Visual Studio 2022 are installed: https://aka.ms/vs/17/release/vs_BuildTools.exe 
    6. Environment variables are set up correctly:
        1. New variable: MSBuildSDKsPath with value: C:\Program Files\dotnet\sdk\3.1.421\Sdks (default path pointing to .NET Core 3.1 SDK install location) should be     added. 
    If you want to run the selenium server locally, make sure that:
    1. Java is installed.
    2. Selenium server is installed: https://github.com/SeleniumHQ/selenium/releases/download/selenium-4.4.0/selenium-server-4.4.0.jar
    3. Chrome browser is installed.
    4. Chrome driver is installed: https://chromedriver.chromium.org/downloads
    5. Environment variables are set up correctly:
            1. System/User variable: Path should contain a directory where Chrome driver is installed.
    Reboot machine.
    
        
    Building and running solution:
    1. Build solution by running: "*\MSBuild.exe" "*\Physitrack.WebAutomation.sln" /p:Configuration=Release /p:Platform="Any CPU" /restore
        Note: MSBuild default location is C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe
    2. Start the selenium server: java -jar selenium-server-4.3.0.jar standalone
    3. To run the solution:
        cd Project_Dir\Physitrack.WebAutomation\bin\Release\netcoreapp3.1
        *\nunit3-console.exe Physitrack.WebAutomation.dll
        
### Option 3: Local Execution on Linux
    Prerequisites:
    Install .NET Core 3.1 by following instructions on Microsoft page: https://docs.microsoft.com/en-us/troubleshoot/developer/webapps/aspnetcore/practice-troubleshoot-linux/1-3-install-dotnet-core-linux
    Commands to run:
    1. wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    2. sudo dpkg -i packages-microsoft-prod.deb
    3. sudo apt update
    4. sudo apt install dotnet-sdk-3.1
    5. To check if dotnet was installed correctly, please run: dotnet --info
    
    Building and running solution:
    1. Download and unzip project.
    2. Open terminal in the main directory where Physitrack.WebAutomation.sln is.
    3. Run: dotnet msbuild Physitrack.WebAutomation.sln -restore
    4. Make sure that selenium server is running on the remote host: http://ec2-3-80-30-46.compute-1.amazonaws.com:4444/ui, if not start it by using remote desktop or let me know. 
    5. Open terminal in /PhysitrackExercise-main/Physitrack.WebAutomation/bin/Debug/netcoreapp3.1
    6. Run project with command: dotnet test Physitrack.WebAutomation.dll
    
    Note. You can also trigger selenium server locally and change url in /PhysitrackExercise-main/Physitrack.WebAutomation/bin/Debug/netcoreapp3.1/appsettings.json
    Prerequisites:
        1. Java.
        2. Chrome.
        3. Chrome driver.
        4. Selenium server.

    
