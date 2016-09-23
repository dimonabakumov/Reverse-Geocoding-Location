# Readme

## Build and run project

This instruction contains the manual how to build and run current project to test Reverse Geocoding Location request of the http://thai-api-staging.mapsynq.com API.

**For successful running of the tests you need to have Visual Studio 2015 Enterprise Edition.**

1) Clone this repository and restore Nuget packages. Open the command line interface and change default directory to the project one. Execute the following command from command line:

```powershell
nuget restore ThaiApiTesting.sln
```

![restorepackages](https://cloud.githubusercontent.com/assets/11733022/18777338/168195cc-81a1-11e6-9ffd-9bbb2866357d.png)

2) To build project you should use MSbuild.exe tool.

```powershell
$path = C:\Repository
msbuild $path\ThaiApiTesting.sln
```

![buildsollution](https://cloud.githubusercontent.com/assets/11733022/18778375/8d7c4fdc-81a6-11e6-8c1a-a109d8e33fed.png)

3) To execute the program we have compiled you should use `MSTest.exe`:

```powershell
$path = C:\Repository
MStest /testcontainer:$path\ThaiApiTesting\bin\Debug\ThaiApiTesting.dll /resultsfile:$path\TestResults.trx
```

![testsresults](https://cloud.githubusercontent.com/assets/11733022/18778864/0623db24-81a9-11e6-8966-cac5a6282a2f.png)

## Test output

TestResults.trx is a file, which contains all tests results and we can extract a lot of information from it:
![testsresults1](https://cloud.githubusercontent.com/assets/11733022/18778904/563e0ca6-81a9-11e6-8b25-78cd6fa32ffd.png)

Result of particular test and what exactly has been sent to the server:
![requestinfo](https://cloud.githubusercontent.com/assets/11733022/18780783/c41b2346-81b1-11e6-9c76-916853e0c5f5.png)

Server response in details:
![responseinfo](https://cloud.githubusercontent.com/assets/11733022/18780860/074dfabc-81b2-11e6-85cc-f95a89c29f46.png)

What kind of validation rules were executed:
![validationrules](https://cloud.githubusercontent.com/assets/11733022/18780886/2a87fb7c-81b2-11e6-8f86-158f59c946e7.png)

The root cause of the faulty test:
![failedtest](https://cloud.githubusercontent.com/assets/11733022/18780976/7838a59c-81b2-11e6-99f2-dc1be3555314.png)