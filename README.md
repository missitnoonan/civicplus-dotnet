# CivicPlus Code Challenge

### Built Using
* .Net 9
* Node 24.7.0
  * You can delete the node_modules folder and run npm install to use a different version

### Running dev servers
* From the root `cd EventsApi`
  * `dotnet run`
* In a separate terminal, from the root `cd frontend`
  * `npm run dev` 

### Using the App
* Navigate to http://localhost:3001/
* This will navigate to the home screen
* Click on the "Events" tab to see the events
* You can navigate to the next page by clicking the "Next Page" button on the bottom
* Click on the "Create New Event" button to create a new event
  * There is basic js validation, but no handling of server errors
* Click on the "View Details" link on any event card to enter the details view