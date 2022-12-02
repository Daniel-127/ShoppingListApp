Iteration 1
- Implement a program where you can list, add and remove products through a console window.
- The products need to be stored in a in-memory database and accessed through the .net entity framework core.
- A product consists of a name.
- Listing, adding and removing products each need a corresponding unit test.

Iteration 2
- Refactor the list, add and remove methods to follow the rest protocol and expose them with a web api.
- Add unit tests that cover the new posibilties of the refactored methods.
- Implement integration tests that access the web api through a HttpClient.
- Disallow products having the same name (case insensitive)

Iteration 3
- Implement a UI application with .net MAUI and the following requirements
	- The application is a single page
	- It lists all currently added products as a grid
	- Every product can be inspected with a pop-up by clicking on it
	- Deleting a product is done through a button exposed when inspecting it
	- Creating and adding a product is done through a pop-up