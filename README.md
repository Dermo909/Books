# Books
API and basic React front end for the viewing and maintenance of Authors, Genres, Books and ReadingLists.

## Basic Architecture
The API contains methods which will accept various Http requests in order to GET, POST, PUT and DELETE for objects listed above.

Database connections and querying are via EntityFrameWorkCore with a Code First approach being taken. Migrations are used to update the objects in the database.

React web app is limited to showing a list of books with placeholder icons for edit, delete and addition of a new record.

## Azure hosting
The web app is hosted on Azure at this [location](https://books-app-dg.azurewebsites.net).


## How to run locally
### API
Download and open the solution file in Visual Studio. Build all and run

### React Web App
In VS Code, open the web app folder. Open a terminal and run the following line:
```
npm install
```
Once all packages are installed, then run the app using:
```
npm start
```

## How to query the API
Once the API is running then you can use the swagger page that is opened automatically. From here you can execute a GET, POST, PUT or DELETE request.

Same is also possible via Postman.

## Restrictions
Maintenance options are included for Books and ReadingLists only. Authors and Genres are read only.
