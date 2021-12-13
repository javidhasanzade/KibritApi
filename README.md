# KibritApi
Web API(using CQRS and Mediator patterns) for storing and updating books in the library.
Models: Author, Genre, Book(relationships Book-Author(many-to-many), Book-Genre(many-to-many))
API Endpoints: 
1. Inserting the book
2. Get information about a book(by Id)
3. Updating information about a book(You send a json with updated book, it cheks id of a book and then updates it in DB)
4. Deleting a book(by Id)
5. Get list of the books by genre(Returns a json with genre and books inside)
6. Get top 5 favorite genres(greatest number of the books) - You can send "Type" as a parameter(boolean) by default it is true and it will return you 5 genres ordered by descending, otherwise by ascending
7. Get top 5 favorite authors(greatest number of the books) - You can send "Type" as a parameter(boolean) by default it is true and it will return you 5 authors ordered by descending, otherwise by ascending

JWT authentication: Register then login and you will get the JWT token with which you can access books

Database created with code first. You can see migrations there.

Stack: ASP.NET Core Web API, .NET 5, EF Core 5.0.12, MySQL
