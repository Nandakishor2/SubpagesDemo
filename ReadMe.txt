Employee Page Documentation:
Url :- https://localhost:7294/employeeMasters

Controller File name :- employeeMastersController.cs
Directory For View :- SubpagesMVCArchitecture(projectName)/Controllers/employeeMastersController.cs
File Type :- Class File 

Index()
Directory For View :- SubpagesMVCArchitecture(projectName)/Views/employeeMasters/Index.cshtml
=> It is the first page that appears on to the screen when the above url is requested 
=> Parameters :- None
=> Purpose :- Using DbContext it gets all employees and loads upon returns to the view Index.cshtml
=> At the top there is a Create Button used to create employees 
=> In Index.csHtml we list all the rows of the database into a table 
=> Each Table has its own edit | viewDetails | Delete button

Create()
Parameters :- 
onClick Of "Create" Button :
	=>Create.cshtml will be called with input fields for 
		1. EmployeeName 
		2. Employee Designation
		3. Employee Department 
		4. Employee Phone Number 
		5. Employee Email 
		Input Validation protocol goes like this 
		1. EmployeeName :- Only Alphabets no digits 
		2. EmployeeName :- Only Alphabets no digits 
		3. EmployeeName :- Only Alphabets no digits 
		4. PhoneNumber :- Only Numbers length = 10
		5. Email Id :- Combination of alphabets numbers and special Charectes but must contain "@" and "."  and must end with atleast 2 charecters
	=> On saving the data If valid gets added into database 
	=> Else returns back with errror messges

Edit()
onclick Of edit Button 
	=> Edit.cshtml will be called up with the get request
	=> 
