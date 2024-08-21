# E-commerce REST API Endpoints

## **Users API Endpoints**

### 1. **Create a User**

- **Endpoint**: `POST /api/v1/users`
- **Description**: Register a new user
- **Authentication**: No
- **Request Body**:

  ```json
  {
    "user_name": "johndoe",
    "email": "john@doe.com",
    "password": "se2345r",
    "phone_number": 123456,
    "role": "user",
    "user_address": {
      "is_default": true,
      "unit_number": "sdun",
      "street_number": 23,
      "address_line1": "wall street",
      "address_line2": "Marlin street",
      "city": "Helsinki",
      "postal_code": 00100,
      "country": "Finland"
    }
  }
  ```

- **Response**:
  - **201 created**:
    ```json
    {
      "user_id": 23456,
      "email": "john@doe.com",
      "user_name": "johndoe",
      "password": "se2345r",
      "phone_number": 123456,
      "role": "user",
      "user_address": {
        "is_default": true,
        "unit_number": "sdun",
        "street_number": 23,
        "address_line1": "wall street",
        "address_line2": "Marlin street",
        "city": "Helsinki",
        "postal_code": 00100,
        "country": "Finland"
      }
    }
    ```
  - **400 Bad Request**: Invalid input data

### 2. **Get All Users**

- **Endpoint**: `GET /api/v1/users`
- **Description**: Retrieves a list of all users.
- **Authorization**: yes
- **Query Parameters**:
  - `?role={admin}` : filter by admin role
  - `?role={user}` : filter by user role
  - `?limit={number}` : Limit the number of result
- **Response**:
  - **200 OK**:
    ```json
    [
        {
            "user_id": 23456,
            "email": "john@doe.com",
            "user_name": "johndoe",
            "password": "se2345r",
            "phone_number": 123456,
            "role": "user",
            "user_address":
                {
                    "is_default": true,
                    "unit_number": "sdun",
                    "street_number": 23,
                    "address_line1": "wall street",
                    "address_line2": "Marlin street",
                    "city": "Helsinki",
                    "postal_code": 00100,
                    "country": "Finland"
                }
        },
        ...
    ]
    ```

### 3. **Get a Single User by ID**

- **Endpoint**: `GET /api/v1/users/{userId}`
- **Description**: Retrieves details of a specific user.
- **Authentication**: no
- **Response**:

  - **200 OK**:

  ```json
  {
    "user_id": 23456,
    "user_name": "johndoe",
    "email": "john@doe.com",
    "password": "se2345r",
    "phone_number": 123456,
    "role": "user",
    "user_address": {
      "is_default": true,
      "unit_number": "sdun",
      "street_number": 23,
      "address_line1": "wall street",
      "address_line2": "Marlin street",
      "city": "Helsinki",
      "postal_code": 00100,
      "country": "Finland"
    }
  }
  ```

  - **404 Not Found**: User not found.

### 4. **Update a User**

- **Endpoint**: `PUT /api/v1/users/{userId}`
- **Description**: Updates the details of an existing user.
- **Authentication**: yes
- **Request Body**:
  ```json
  {
    "user_name": "Updated John Doe",
    "email": "updatedjohndoe@examp"
  }
  ```
- **Response**:
  - **200 OK**:
    ```json
    {
      "user_id": 23456,
      "user_name": "Updated John Doe",
      "email": "updatedjohndoe@examp",
      "password": "se2345r",
      "phone_number": 123456,
      "role": "user",
      "user_address": {
        "is_default": true,
        "unit_number": "sdun",
        "street_number": 23,
        "address_line1": "wall street",
        "address_line2": "Marlin street",
        "city": "Helsinki",
        "postal_code": 00100,
        "country": "Finland"
      }
    }
    ```
  - **404 Not Found**: User not found.

### 5. **Delete a User**

- **Endpoint**: `DELETE /api/v1/users/{userId}`
- **Description**: Deletes a user.
- **Authorization**: yes
- **Response**:
  - **204 No Content**: Successfully deleted.
  - **404 Not Found**: User not found.

## **Products API Endpoints**

### 1. **Create a Product**

- **Endpoint**: `POST /api/v1/products`
- **Description**: Adds a new product to the inventory.
- **Authorization**: yes
- **Request Body**:
  ```json
  {
    "name": "Product Name",
    "description": "Product Description",
    "price": 29.99,
    "category": {
      "name": "Men's Clothing"
    },
    "stock": 100,
    "product_line": "footwear",
    "product_images": {
      "imageUrl": "http://example.com/image.jpg",
      "isPrimary": true,
      "image_text": "image text"
    },
    "product_sizes": {
      "size_value": "L"
    },
    "product_colors": {
      "color_name": "red"
    }
  }
  ```
- **Response**:
  - **201 Created**:
    ```json
    {
      "id": "12345",
      "name": "Product Name",
      "description": "Product Description",
      "price": 29.99,
      "category": {
        "name": "Men's Clothing"
      },
      "stock": 100,
      "product_line": "footwear",
      "product_images": {
        "imageUrl": "http://example.com/image.jpg",
        "isPrimary": true,
        "image_text": "image text"
      },
      "product_sizes": {
        "size_value": "L"
      },
      "product_colors": {
        "color_name": "red"
      }
    }
    ```
  - **400 Bad Request**: Invalid input data.

### 2. **Get All Products**

- **Endpoint**: `GET /api/v1/products`
- **Description**: Retrieves a list of all products.
- **Query Parameters** (optional):
  - `?category={categoryName}`: Filter products by category.
  - `?page={pageNumber}&limit={pageSize}`: Pagination options.
- **Response**:
  - **200 OK**:
    ```json
    [
        {
            "id": "12345",
            "name": "Product Name",
            "description": "Product Description",
            "price": 29.99,
            "category":
                {
                    "name": "Men's Clothing"
                },
            "stock": 100,
            "product_line": "footwear",
            "product_images":
                {
                    "imageUrl": "http://example.com/image.jpg",
                    "isPrimary": true,
                    "image_text": "image text"
                },
            "product_sizes":
                {
                    "size_value": "L"
                },
            "product_colors":
                {
                    "color_name": "red"
                }
        },
        ...
    ]
    ```

### 3. **Get a Single Product by ID**

- **Endpoint**: `GET /api/v1/products/{productId}`
- **Description**: Retrieves details of a specific product.
- **Response**:
  - **200 OK**:
    ```json
    {
      "id": "12345",
      "name": "Product Name",
      "description": "Product Description",
      "price": 29.99,
      "category": {
        "name": "Men's Clothing"
      },
      "stock": 100,
      "product_line": "footwear",
      "product_images": {
        "imageUrl": "http://example.com/image.jpg",
        "isPrimary": true,
        "image_text": "image text"
      },
      "product_sizes": {
        "size_value": "L"
      },
      "product_colors": {
        "color_name": "red"
      }
    }
    ```
  - **404 Not Found**: Product not found.

### 4. **Update a Product**

- **Endpoint**: `PUT /api/v1/products/{productId}`
- **Description**: Updates the details of an existing product.
- **Authentication**: yes
- **Request Body**:
  ```json
  {
    "name": "Updated Product Name",
    "description": "Updated Product Description",
    "price": 34.99,
    "stock": 80
  }
  ```
- **Response**:
  - **200 OK**:
    ```json
    {
      "id": "12345",
      "name": "Updated Product Name",
      "description": "Updated Product Description",
      "price": 34.99,
      "category": {
        "name": "Men's Clothing"
      },
      "stock": 80,
      "product_line": "footwear",
      "product_images": {
        "imageUrl": "http://example.com/image.jpg",
        "isPrimary": true,
        "image_text": "image text"
      },
      "product_sizes": {
        "size_value": "L"
      },
      "product_colors": {
        "color_name": "red"
      }
    }
    ```
  - **404 Not Found**: Product not found.

### 5. **Delete a Product**

- **Endpoint**: `DELETE /api/v1/products/{productId}`
- **Description**: Deletes a product from the inventory.
- **Authentication**: yes
- **Response**:
  - **204 No Content**: Successfully deleted.
  - **404 Not Found**: Product not found.

### 6. **Get Most Purchased Products**

- **Endpoint**: `GET /api/v1/products/most-purchased`
- **Description**: Retrieves the most purchased products.
- **Query Parameters**:
  - `?limit={x}`: The number of top purchased products to retrieve.
- **Response**:
  - **200 OK**:
    ```json
    [
        {
        "id": "12345",
        "name": "Product Name",
        "description": "Product Description",
        "price": 29.99,
        "category":
            {
                "name": "Men's Clothing"
            },
        "stock": 100,
        "product_line": "footwear",
        "product_images":
            {
                "imageUrl": "http://example.com/image.jpg",
                "isPrimary": true,
                "image_text": "image text"
            },
        "product_sizes":
            {
                "size_value": "L"
            },
        "product_colors":
            {
                "color_name": "red"
            }
    },
        ...
    ]
    ```
