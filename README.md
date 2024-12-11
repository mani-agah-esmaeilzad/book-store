# Online Bookstore API

This project is an online bookstore system built with **C#** and **ASP.NET Core**. The goal of this project is to provide APIs for managing books, categories, authors, customers, orders, payments, reviews, and more. It uses **JWT** for authentication and has features for payment processing, coupon discounts, and email notifications.

## Features

- **Book Management** (Add, Remove, Update, View Books)
- **Category Management** (Add, Remove, Update Categories)
- **Author Management** (Add, Update, View Authors)
- **User Management** (Admin & Customer roles)
- **Order Management** (Create, View Orders)
- **Payment Processing** using Stripe
- **Discount Coupons** (Add and Apply Coupons)
- **Reviews & Ratings** for Books
- **JWT Authentication** (Secure APIs)
- **Email Notifications** (Sendgrid for registration & purchase confirmation)
- **Search & Filter** Books

## Prerequisites

Before setting up and running this project, ensure you have the following installed:

- **.NET SDK** (version 6 or higher)
- **Visual Studio** or any code editor (like VS Code)
- **MySQL** or **MariaDB** database server
- **Stripe API Key** for payment processing
- **SendGrid API Key** for sending emails

## Installation

### 1. Clone the project

To clone the repository, run the following command:


```
git clone https://github.com/username/bookstore-api.git
cd bookstore-api 
```
2. Install Dependencies
To install the required NuGet packages, run:
```
dotnet restore
```

3. Configure Database

The project uses MySQL or MariaDB for the database. Create a new database called bookstore. Then, update the connection string in the ``` appsettings.json ``` file:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=bookstore;User=root;Password=yourpassword;"
}
```
4. Configure Stripe and SendGrid API Keys

You need API keys for Stripe (payment processing) and SendGrid (email service). Add your keys to the ```appsettings.json ``` file:

```
"Stripe": {
  "SecretKey": "your_stripe_secret_key",
  "PublishableKey": "your_stripe_publishable_key",
  "SuccessUrl": "https://yourwebsite.com/success",
  "CancelUrl": "https://yourwebsite.com/cancel"
},
"SendGrid": {
  "ApiKey": "your_sendgrid_api_key",
  "FromEmail": "your_email@example.com"
}
```

5. Create Database and Tables

To create the necessary database tables, use the following commands:

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create the required tables based on your model.

6. Run the Project

To run the project, execute the following command:
```
dotnet run
```
The application will run on ``` localhost:5000 ``` for development purposes.

Using the API
1. Authentication (JWT)
To use most of the APIs, you need to authenticate using a JWT token. You can get a token by logging in.

Register (Create Account):
http
```
POST /api/auth/register
Content-Type: application/json
{
    "username": "newuser",
    "password": "password123"
}
```

Login (Get JWT Token):
To log in and receive a JWT token, send the following request:

```
POST /api/auth/login
Content-Type: application/json
{
    "username": "newuser",
    "password": "password123"
}
```
You will receive a JWT token on successful login.

Sending the Token in Requests:
For any request that requires authentication, include the JWT token in the ```Authorization``` 

header:
http
```
Authorization: Bearer YOUR_JWT_TOKEN
```

2. Book Management

View All Books:
To view all the books in the system, use this request:

```
GET /api/books
Authorization: Bearer YOUR_JWT_TOKEN
```

Add a New Book:

To add a new book to the system, send this request:

```
POST /api/books
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "title": "New Book",
    "author": "Author Name",
    "category": "Category Name",
    "price": 20.00,
    "stockQuantity": 10
}
```
Update a Book:

To update an existing book:

```
PUT /api/books/{bookId}
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "title": "Updated Book Title",
    "author": "Updated Author",
    "category": "Updated Category",
    "price": 25.00,
    "stockQuantity": 8
}
```
Delete a Book:

To delete a book:

```
DELETE /api/books/{bookId}
Authorization: Bearer YOUR_JWT_TOKEN
```

3. Category Management

Add a New Category:
```
POST /api/categories
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "name": "New Category"
}
```

View All Categories:
```
GET /api/categories
Authorization: Bearer YOUR_JWT_TOKEN
```
Delete a Category:
```
DELETE /api/categories/{categoryId}
Authorization: Bearer YOUR_JWT_TOKEN
```
4. Order Management

Create an Order:

To place an order for a book, use this request:
```
POST /api/orders
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "bookId": 1,
    "quantity": 2
}
```
View Orders:

To view all orders:

```
GET /api/orders
Authorization: Bearer YOUR_JWT_TOKEN
```
5. Payments with Stripe

Initiate a Payment (Checkout):

To start a payment session with Stripe:
```
POST /api/payments/checkout
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "amount": 5000,  // Amount in cents
    "productName": "Product Name"
}
```

This will return a Stripe session ID that you can use to redirect the user to the Stripe checkout page.

Payment Success Callback:

Handle payment success by implementing a webhook or capturing the success URL defined in the Stripe settings.

6. Coupons

Create a Coupon:

To create a new discount coupon:
```
POST /api/coupons
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "code": "DISCOUNT20",
    "discountAmount": 20.00,
    "expiryDate": "2024-12-31T23
}
```

Apply a Coupon:

To apply a coupon during the checkout process:

```
POST /api/coupons/apply
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "couponCode": "DISCOUNT20"
}
```

Reviews and Ratings Add a Review: To add a review for a book, use this request:
```
POST /api/reviews
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "bookId": 1,
    "rating": 4,
    "reviewText": "Great book!"
}
```
View Reviews for a Book: To view reviews for a specific book:

```
GET /api/reviews/{bookId}
Authorization: Bearer YOUR_JWT_TOKEN
```

Admin Users Add a New Admin User: To add a new admin user:
```
POST /api/admin-users
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "username": "adminuser",
    "password": "adminpassword",
    "role": "Admin"
}
```
View All Admin Users: To view all admin users:
```
GET /api/admin-users
Authorization: Bearer YOUR_JWT_TOKEN
```
Update Admin User: 

To update an existing admin user:

```
PUT /api/admin-users/{userId}
Authorization: Bearer YOUR_JWT_TOKEN
Content-Type: application/json
{
    "username": "updatedAdminUser",
    "password": "updatedAdminPassword"
}
```

Delete an Admin User:

To delete an admin user:

```
DELETE /api/admin-users/{userId}
Authorization: Bearer YOUR_JWT_TOKEN
```

Authentication (JWT)

To access most of the endpoints in the API, you will need to authenticate using a JWT token.

Register (Create Account):

You can register a new account by sending a POST request to ``` /api/auth/register ``` with the following body:

```
{
    "username": "newuser",
    "password": "password123"
}
``` 

Login (Get JWT Token):

To log in and receive a JWT token, send a POST request to ``` /api/auth/login ``` :

```
{
    "username": "newuser",
    "password": "password123"
}
```

The response will include a JWT token, which you can use to authenticate other requests.

Sending the Token:

For any request that requires authentication, include the ```JWT token``` in the Authorization header:

```
Authorization: Bearer YOUR_JWT_TOKEN
```
Testing the API

You can test this API using tools like Postman or ```Swagger```. Here’s how you can start:

Postman:

Import the Postman collection available in the repository.

Make sure to include the JWT token in the Authorization header when testing protected routes.

Swagger:

Swagger can be set up to document and test the API interactively. You can access Swagger UI by running the project and navigating to ```http://localhost:5000/swagger```.
Unit Tests:

You can also run unit tests to ensure that the API and its logic are working as expected.

To run unit tests, execute the following command:
```
dotnet test
Troubleshooting
Common Issues
```

Database connection failed:

Ensure your ```MySQL/MariaDB``` server is running and check the connection string in appsettings.json.

If you're using Docker for the database, ensure the container is running and accessible.

JWT Authentication failed:

Ensure that the JWT token is included in the Authorization header with the correct prefix (Bearer).

If using JWT_SECRET from environment variables, check that the value matches what is configured in your app.

Stripe Payment Issue:

Double-check your Stripe API keys and ensure they are correctly configured in appsettings.json.

Invalid Coupon Code:

Ensure that the coupon code is valid, not expired, and has been added in the system.

License
This project is licensed under the MIT License - see the LICENSE file for details.

Contact
For any questions or support, you can reach out to:

Email: ```maniagahdev@gmail.com```

GitHub Repository: ```https://github.com/username/bookstore-api```

Contributing
We welcome contributions to improve this project. If you want to contribute, please follow these steps:

Fork the repository.

Create a new branch for your changes.

Make your changes and add tests if applicable.

Open a pull request with a description of the changes you've made.

Please ensure your code adheres to the coding conventions and passes all unit tests.

Thank you for your contribution!

Acknowledgments

This project uses ASP.NET Core, MySQL (or MariaDB), JWT authentication, Stripe for payment processing, and SendGrid for email notifications.
Thanks to the open-source community for making these technologies available.

Future Improvements

Here are some potential future improvements for the Online Bookstore API:


Admin Dashboard: 

A UI dashboard to manage books, orders, and users.

Wishlist: Allow 

users to save books they are interested in.

Recommendations: 

Implement personalized book recommendations based on user history.

Rating System: 

Enhance the review system to allow users to upvote/downvote reviews.

