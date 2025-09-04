# CivicPlus Code Challenge

### Built Using
* .Net 9
* Node 24.7.0 (should be ok with relatively new versions)

### Installing
* Clone the repo `git clone git@github.com:missitnoonan/civicplus-dotnet.git`

### Running dev servers
* From the root `cd EventsApi`
  * `dotnet run`
* In a separate terminal, from the root `cd frontend`
  * `npm install` && `npm run dev` 

### Using the App
* Navigate to http://localhost:3001/
* This will navigate to the home screen
* Click on the "Events" tab to see the events
* You can navigate to the next page by clicking the "Next Page" button on the bottom
* Click on the "Create New Event" button to create a new event
  * There is basic js validation, but no handling of server errors
* Click on the "View Details" link on any event card to enter the details view

### Running tests for backend
* From the root `cd EventsApiTest`
  * `dotnet test`

### Running tests for frontend
* From the root `cd frontend`
  * `npm run test:unit`

### What is missing
* Frontend caching of events to reduce calls
* Logging on the backend
* Notifications on the frontend
* Better backend validation (checking if end date is after start date)