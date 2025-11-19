# hackernews-angular-dotnet

## How to Run the Project

### Backend (ASP.NET Core API)

1. Open a terminal and navigate to the `backend` directory:
   ```sh
   cd backend
   ```
2. Restore dependencies (if not already done):
   ```sh
   dotnet restore
   ```
3. Run the API:
   ```sh
   dotnet run --project HackerNews.Api/HackerNews.Api.csproj
   ```
   The API will start, usually on `https://localhost:5001` or `http://localhost:5000`.

### Frontend (Angular)

1. Open a new terminal and navigate to the frontend UI directory:
   ```sh
   cd frontend/hackernews-ui
   ```
2. Install dependencies:
   ```sh
   npm install
   ```
3. Start the Angular development server:
   ```sh
   npm start
   ```
   The app will be available at `http://localhost:4200`.
