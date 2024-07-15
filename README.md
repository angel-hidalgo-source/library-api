## LibraryAPI: A SOLID Example

This repository showcases a simple API for managing a library's book collection, built with C# and adhering to SOLID principles.

**SOLID Principles:**

-   **Single Responsibility Principle:**  Each class has a single, well-defined responsibility. For example, the  `BookRepository`  class is solely responsible for managing book data, while the  `LibraryContext`  class handles database interactions.
-   **Open/Closed Principle:**  The code is designed to be open for extension but closed for modification. New functionalities can be added without altering existing code. For instance, adding a new book type wouldn't require changes to the  `BookRepository`  class.
-   **Liskov Substitution Principle:**  Subclasses can be used interchangeably with their base classes without breaking the application. This is achieved by ensuring that all classes adhere to the same interface and behavior.
-   **Interface Segregation Principle:**  Interfaces are specific and tailored to the needs of the classes that implement them. This prevents classes from being forced to depend on methods they don't use.
-   **Dependency Inversion Principle:**  High-level modules should not depend on low-level modules. Both should depend on abstractions. This is achieved through the use of interfaces and dependency injection.

**Project Structure:**

-   **Data:**  Contains the  `LibraryContext`  class, responsible for database interactions.
-   **Models:**  Defines the  `Book`  model, representing a book in the library.
-   **Repositories:**  Contains the  `IBookRepository`  interface and the  `BookRepository`  class, responsible for managing book data.
-   **Program.cs:**  The main entry point of the application, setting up the API and defining endpoints.

**Key Features:**

-   **CRUD Operations:**  The API supports basic CRUD operations for books, including creating, reading, updating, and deleting.
-   **Book Lending and Returning:**  The API allows users to lend and return books, updating the available copies accordingly.
-   **Error Handling:**  The API handles potential errors gracefully, returning appropriate HTTP status codes and error messages.
-   **Swagger Documentation:**  The API is documented using Swagger, providing a user-friendly interface for exploring the available endpoints.

**How to Run:**

1.  Clone the repository.
2.  Install the required NuGet packages.
3.  Run the application.

**Future Improvements:**

-   Implement user authentication and authorization.
-   Add support for different book types (e.g., fiction, non-fiction).
-   Integrate with a real database instead of in-memory database.

This project serves as a starting point for building a more robust and feature-rich library management system. By adhering to SOLID principles, the code is maintainable, extensible, and easy to understand.
