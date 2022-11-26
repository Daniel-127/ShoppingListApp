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
