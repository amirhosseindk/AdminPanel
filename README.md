# AdminPanel

AdminPanel is a comprehensive ASP.NET Core project utilizing the Razor Pages architecture. This project provides a robust backend for managing various entities including airplanes, board of directors (BOD), blog posts, slideshow images, and texts. It also includes a file upload service.

## Features

### Airplane Management
The project includes services for creating, updating, deleting, and retrieving airplane information. Each airplane has a model, register, and an optional image link. The `AirplaneService` class in the `Services` folder contains the implementation of these operations. The `IAirplaneService` interface in the `IServices` folder defines the contract for the service.

### Board of Directors (BOD) Management
Services for managing the board of directors are included. You can create, update, delete, and retrieve information about a BOD member. Each member has a name, position, and an optional image link. The `BODService` class in the `Services` folder contains the implementation of these operations. The `IBODService` interface in the `IServices` folder defines the contract for the service.

### Blog Post Management
Blog posts can be managed using the provided services. You can create, update, delete, and retrieve blog posts. Each blog post has an author, title, text, and an optional image link. The `BlogPostService` class in the `Services` folder contains the implementation of these operations. The `IBlogPostService` interface in the `IServices` folder defines the contract for the service.

### Slideshow Management
The project includes services for managing slideshow images. You can create, update, delete, and retrieve slideshow images. Each image has an optional image link. The `SliderService` class in the `Services` folder contains the implementation of these operations. The `ISliderService` interface in the `IServices` folder defines the contract for the service.

### Text Management
Services for managing text are included. You can update and retrieve texts. The `TextService` class in the `Services` folder contains the implementation of these operations. The `ITextService` interface in the `IServices` folder defines the contract for the service.

### File Upload
The project includes a file upload service. You can upload files to the server. The `FileUploadService` class in the `Services` folder contains the implementation of this operation. The `IFileUploadService` interface in the `IServices` folder defines the contract for the service.

## User Management
The project uses ASP.NET Identity for user management. The `ApplicationUser` class in the root folder extends the `IdentityUser` class to represent users in the application. The `ApplicationDbContext` class in the root folder extends the `IdentityDbContext<ApplicationUser>` class to represent the database context of the application.
