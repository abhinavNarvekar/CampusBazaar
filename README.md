🛒 CampusBazaar

A student-focused marketplace web application built using ASP.NET Core MVC where users can list items for sale and connect with buyers within their campus.

🚀 Features
🔐 User Authentication (Register / Login)
📦 Create, Edit, Delete Listings
🖼️ Image Upload using Cloudinary
📄 View Listing Details
💬 Contact Seller
👤 User-specific Listings
🏷️ Categorized Listings (optional future feature)
🔍 Search & Filter (planned)

🛠️ Tech Stack

Backend

ASP.NET Core MVC
Entity Framework Core

Frontend

Razor Views
Bootstrap

Database

PostgreSQL / MySQL (configurable)

Other Services

Cloudinary (for image storage)
📂 Project Structure
ECommerceMVC/
│
├── Controllers/        # Handles HTTP requests
├── Models/             # Data models (Listing, User, etc.)
├── Views/              # Razor UI files
├── Data/               # Database context
├── Services/           # External services (Cloudinary)
├── Migrations/         # EF Core migrations
├── wwwroot/            # Static files (CSS, JS, images)
└── Program.cs          # Entry point
⚙️ Setup Instructions
1. Clone the repository
git clone https://github.com/your-username/campusbazaar.git
cd campusbazaar
2. Configure Database

Update appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Your_Database_Connection_String"
}
3. Apply Migrations
dotnet ef database update
4. Run the Application
dotnet run

Visit:

http://localhost:5000
☁️ Cloudinary Setup (for images)

Add your credentials in .env or appsettings.json:

CLOUDINARY_URL=your_cloudinary_url


Images:
<img width="1440" height="705" alt="image" src="https://github.com/user-attachments/assets/6d165455-697a-4626-a04c-b325395c2bc5" />
<img width="1440" height="820" alt="image" src="https://github.com/user-attachments/assets/11211139-164e-493a-a9ac-d0d6b39eb411" />
<img width="1438" height="863" alt="image" src="https://github.com/user-attachments/assets/4f7648f5-37bf-4bc3-8c28-c9efad9c9edb" />
<img width="1440" height="854" alt="image" src="https://github.com/user-attachments/assets/48927d2b-a639-4d2d-83e4-a5abd8cd0b8f" />
