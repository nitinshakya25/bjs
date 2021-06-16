
Step to execute the Testcase as follows:

	1. Launch the Command Prompt in your system.
	2. Use below command in the command prompt :
		cd C:\xxxxxxxxxxxxxx\MakeMyTrip\packages\NUnit.ConsoleRunner.3.9.0\tools
		cls
		nunit3-console.exe --params:Browser=chrome;Language=English "C:\xxxxxxxxxxxxxx\MakeMyTrip\MakeMyTrip\bin\Debug\MakeMyTrip.dll" --where cat='Pre_Requisites'
		
	3. Report will be found at location in the system: 
		C:xxxxxxxxxxxxxx\MakeMyTrip\packages\NUnit.ConsoleRunner.3.9.0\tools\reports
		