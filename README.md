# Api-cookies

# API Cookies Service

This project implements an API for managing cookie stands. It provides endpoints for creating, retrieving, updating, and deleting cookie stands.




## Usage

This API provides endpoints for managing cookie stands. It can be used in conjunction with a frontend application to allow users to perform CRUD operations on cookie stands.

## Endpoints

### POST /cookiestand

Creates a new cookie stand.

Request Body (JSON):
```json
{
  "location": "string",
  "description": "string",
  "max_Customer_Per_Hour": 0,
  "min_Customer_Pre_Hour": 0,
  "average_Cookies_Per_Sale": 0.0,
  "owner": "string"
}
```

### GET /cookiestand

Retrieves a list of all cookie stands.

Response (JSON):
```json
[
  {
    "id": 0,
    "location": "string",
    "description": "string",
    "max_Customer_Per_Hour": 0,
    "min_Customer_Pre_Hour": 0,
    "average_Cookies_Per_Sale": 0.0,
    "owner": "string"
  }
]
```

### GET /cookiestand/{id}

Retrieves a specific cookie stand by its ID.

Response (JSON):
```json
{
  "id": 0,
  "location": "string",
  "description": "string",
  "max_Customer_Per_Hour": 0,
  "min_Customer_Pre_Hour": 0,
  "average_Cookies_Per_Sale": 0.0,
  "owner": "string"
}
```

### PUT /cookiestand/{id}

Updates a specific cookie stand.

Request Body (JSON):
```json
{
  "location": "string",
  "description": "string",
  "max_Customer_Per_Hour": 0,
  "min_Customer_Pre_Hour": 0,
  "average_Cookies_Per_Sale": 0.0,
  "owner": "string"
}
```

### DELETE /cookiestand/{id}

Deletes a specific cookie stand by its ID.

## DTOs

- `CreateCookieDTO`: Data transfer object for creating a new cookie stand.

- `CookieStandDTO`: Data transfer object for returning cookie stand information.

## Models

- `CookieStand`: Represents a cookie stand with attributes such as location, description, etc.

## Services

- `ICookieStand`: Interface for the cookie stand service.

- `CookieStandService`: Implementation of the cookie stand service.

## Controllers

- `CookieStandController`: Controller handling HTTP requests for managing cookie stands.

## ER Diagram

| Entity          | Attributes                                            | Relationships         |
|-----------------|------------------------------------------------------|----------------------|
| cookiestand     | Id (PK), Location, Description, Max_Customer_Per_Hour, Min_Customer_Pre_Hour, Average_Cookies_Per_Sale, Owner |                      |
| SalesPerHour    | Id (PK), Hour, cookiestandId (FK)                    | FK to cookiestand.Id  |

