# E-commerce REST API Endpoints

## **Users API Endpoints**

### 1. **Create a User**

- **Endpoint**: `POST /api/v1/user`
- **Description**: Register a new user
- **Authentication**: No
- **Request Body**:

  ```json
  {
    "user_name": "johndoe",
    "email": "john@doe.com",
    "password": "se2345r",
    "phone_number": "123456",
    "role": "user",
    "user_address": {
      "is_default": true,
      "address": {
        "unit_number": "sdun",
        "street_number": 23,
        "address_line1": "wall street",
        "address_line2": "Marlin street",
        "city": "Helsinki",
        "postal_code": "00100",
        "country": "Finland"
      }
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
      "phone_number": "123456",
      "role": "user",
      "user_address": {
        "is_default": true,
        "address": {
          "unit_number": "sdun",
          "street_number": 23,
          "address_line1": "wall street",
          "address_line2": "Marlin street",
          "city": "Helsinki",
          "postal_code": "00100",
          "country": "Finland"
        }
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
            "phone_number": "123456",
            "role": "user",
            "user_address": {
              "is_default": true,
              "address":
                {
                  "unit_number": "sdun",
                  "street_number": 23,
                  "address_line1": "wall street",
                  "address_line2": "Marlin street",
                  "city": "Helsinki",
                  "postal_code": "00100",
                  "country": "Finland"
                }
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
    "phone_number": "123456",
    "role": "user",
    "user_address": {
      "is_default": true,
      "address": {
        "unit_number": "sdun",
        "street_number": 23,
        "address_line1": "wall street",
        "address_line2": "Marlin street",
        "city": "Helsinki",
        "postal_code": "00100",
        "country": "Finland"
      }
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
      "phone_number": "123456",
      "role": "user",
      "user_address": {
        "is_default": true,
        "address": {
          "unit_number": "sdun",
          "street_number": 23,
          "address_line1": "wall street",
          "address_line2": "Marlin street",
          "city": "Helsinki",
          "postal_code": "00100",
          "country": "Finland"
        }
      }
    }
    ```
  - **404 Not Found**: User not found.

## Hard Delete User

- **Endpoint**: `DELETE /api/v1/users/{user_id}`
- **Description**: Permanently deletes a user and associated records.
- **Responses**:
  - **204 No Content**: Successfully deleted.
  - **404 Not Found**: User not found.

## Soft Delete User (optional)

- **Endpoint**: `DELETE /api/v1/users/{user_id}`
- **Description**: Marks a user as deleted without removing the record.
- **Responses**:
  - **204 No Content**: Successfully marked as deleted.
  - **404 Not Found**: User not found.

## Categories API Endpoints

### **1. Create a Category**

- **Endpoint**: `POST /api/v1/category`
- **Description**: Creates a new product category.
- **Request Body**:
  ```json
  {
    "name": "Men's clothing",
    "parent_category_id": 12456
  }
  ```
- **Response**:
  - **201 Created**:
    ```json
    {
      "id": 12345,
      "name": "Men's clothing",
      "parent_category_id": 12456
    }
    ```
  - **400 Bad Request**: Invalid input data.

### **2. Get All Categories**

- **Endpoint**: `GET /api/v1/categories`
- **Description**: Retrieves a list of all product categories.
- **Query Parameters** (optional):
  - `?parent_category_id={parent_category_id}`: Filter categories by parent category.
- **Response**:
  - **200 OK**:
    ```json
    [
        {
            "id": 12345,
            "name": "Men's clothing",
            "parent_category_id": 12456
        },
        {
            "id": 12346,
            "name": "Women's clothing",
            "parent_category_id": 12458
        },
        ...
    ]
    ```

### **3. Get Category by ID**

- **Endpoint**: `GET /api/v1/categories/{categoryId}`
- **Description**: Retrieves details of a specific category by its ID.
- **Response**:
  - **200 OK**:
    ```json
    {
      "id": 12456,
      "name": "Men's clothing",
      "parent_category_id": 12456
    }
    ```
  - **404 Not Found**: Category not found.

### **4. Update a Category**

- **Endpoint**: `PUT /api/v1/categories/{categoryId}`
- **Description**: Updates the details of an existing category.
- **Request Body**:
  ```json
  {
    "name": "Updated Men's clothing",
    "parent_category_id": 12456
  }
  ```
- **Response**:
  - **200 OK**:
    ```json
    {
      "id": 12345,
      "name": "Updated Men's clothing",
      "parent_category_id": 12456
    }
    ```
  - **404 Not Found**: Category not found.

### **5. Delete a Category**

- **Endpoint**: `DELETE /api/v1/categories/{categoryId}`
- **Description**: Deletes a category by its ID.
- **Response**:
  - **204 No Content**: Successfully deleted.
  - **404 Not Found**: Category not found.

## **Products API Endpoints**

### 1. **Create a Product**

- **Endpoint**: `POST /api/v1/product`
- **Description**: Adds a new product to the inventory.
- **Authorization**: yes
- **Request Body**:
  ```json
  {
    "name": "Product Name",
    "description": "Product Description",
    "price": 29.99,
    "category": {
      "category_id": 12376
    },
    "stock": 100,
    "product_line": "footwear",
    "product_images": {
      "image_id": 12345,
      "imageUrl": "http://example.com/image.jpg",
      "isPrimary": true,
      "image_text": "image text"
    },
    "product_sizes": {
      "size_id": 12345,
      "size_value": "L",
      "quantity": 5
    },
    "product_colors": {
      "color_id": 234567,
      "color_name": "red"
    }
  }
  ```
- **Response**:
  - **201 Created**:
    ```json
    {
      "product_id": "12345",
      "name": "Product Name",
      "description": "Product Description",
      "price": 29.99,
      "category": {
        "category_id": 12376
      },
      "stock": 100,
      "product_line": "footwear",
      "product_images": {
        "image_id": 12456,
        "imageUrl": "http://example.com/image.jpg",
        "isPrimary": true,
        "image_text": "image text"
      },
      "product_sizes": {
        "size_id": 12345,
        "size_value": "L",
        "quantity": 5
      },
      "product_colors": {
        "color_id": 234567,
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
            "product_id": "12345",
            "name": "Product Name",
            "description": "Product Description",
            "price": 29.99,
            "category":
                {
                    "category_id": 12345
                },
            "stock": 100,
            "product_line": "footwear",
            "product_images":
                {
                    "image_id": 12456,
                    "imageUrl": "http://example.com/image.jpg",
                    "isPrimary": true,
                    "image_text": "image text"
                },
            "product_sizes":
                {
                    "size_id": 12345,
                    "size_value": "L",
                    "quantity": 5
                },
            "product_colors":
                {
                    "color_id": 12346,
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
      "product_id": "12345",
      "name": "Product Name",
      "description": "Product Description",
      "price": 29.99,
      "category": {
        "category_id": 12345
      },
      "stock": 100,
      "product_line": "footwear",
      "product_images": {
        "image_id": 12456,
        "imageUrl": "http://example.com/image.jpg",
        "isPrimary": true,
        "image_text": "image text"
      },
      "product_sizes": {
        "size_id": 12345,
        "size_value": "L",
        "quantity": 5
      },
      "product_colors": {
        "color_id": 12345,
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
      "product_id": "12345",
      "name": "Updated Product Name",
      "description": "Updated Product Description",
      "price": 34.99,
      "category": {
        "category_id": 12345
      },
      "stock": 80,
      "product_line": "footwear",
      "product_images": {
        "image_id": 12456,
        "imageUrl": "http://example.com/image.jpg",
        "isPrimary": true,
        "image_text": "image text"
      },
      "product_sizes": {
        "size_id": 12345,
        "size_value": "L",
        "quantity": 5
      },
      "product_colors": {
        "color_id": 12345,
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
        "product_id": "12345",
        "name": "Product Name",
        "description": "Product Description",
        "price": 29.99,
        "category":
            {
                "category_id": 12345
            },
        "stock": 100,
        "product_line": "footwear",
        "product_images":
            {
                "image_id": 12456,
                "imageUrl": "http://example.com/image.jpg",
                "isPrimary": true,
                "image_text": "image text"
            },
        "product_sizes":
            {
                "size_id": 12345,
                "size_value": "L",
                "quantity": 5
            },
        "product_colors":
            {
                "color_id": 12345,
                "color_name": "red"
            }
    },
        ...
    ]
    ```

## **Reviews API Endpoints**

### 1. **Create a Review**

- **Endpoint**: `POST /api/v1/review`
- **Description**: Adds a new review to a product.
- **Authentication**: yes
- **Request Body**:
  ```json
  {
    "productId": "12345",
    "userId": "67890",
    "review_date": "2024-08-20T13:00:00Z",
    "rating": 5,
    "review": "This product is amazing!",
    "anonymize": true
  }
  ```
- **Response**:
  - **201 Created**:
    ```json
    {
      "review_id": "abc123",
      "productId": "12345",
      "userId": "67890",
      "review_date": "2024-08-20T13:00:00Z",
      "rating": 5,
      "review": "This product is amazing!",
      "anonymize": true
    }
    ```
  - **400 Bad Request**: Invalid input data.

### 2. **Get All Reviews**

- **Endpoint**: `GET /api/v1/reviews`
- **Description**: Retrieves a list of all reviews.
- **Query Parameters** (optional):
  - `?page={pageNumber}&limit={pageSize}`: Pagination options.
- **Response**:
  - **200 OK**:
    ```json
    [
        {
            "review_id": "abc123",
            "productId": "12345",
            "userId": "67890",
            "review_date": "2024-08-20T13:00:00Z",
            "rating": 5,
            "review": "This product is amazing!"
        },
        ...
    ]
    ```

### 3. **Get All Reviews of a Specific Product**

- **Endpoint**: `GET /api/v1/reviews/products/{productId}`
- **Description**: Retrieves reviews for a specific product.
- **Response**:
  - **200 OK**:
    ```json
    [
        {
            "review_id": "abc123",
            "productId": "12345",
            "userId": "67890",
            "review_date": "2024-08-20T13:00:00Z",
            "rating": 5,
            "review": "This product is amazing!"
        },
        ...
    ]
    ```

### 4. **Get All Reviews of a Specific User**

- **Endpoint**: `GET /api/v1/reviews/users/{userId}`
- **Description**: Retrieves reviews made by a specific user.
- **Authentication**: yes
- **Response**:
  - **200 OK**:
    ```json
    [
        {
            "review_id": "abc123",
            "productId": "12345",
            "userId": "67890",
            "review_date": "2024-08-20T13:00:00Z",
            "rating": 5,
            "review": "This product is amazing!"
        },
        ...
    ]
    ```

### 5. **Get a Single Review by ID**

- **Endpoint**: `GET /api/v1/reviews/{reviewId}`
- **Description**: Retrieves details of a specific review.
- **Response**:
  - **200 OK**:
    ```json
    {
      "review_id": "abc123",
      "productId": "12345",
      "userId": "67890",
      "review_date": "2024-08-20T13:00:00Z",
      "rating": 5,
      "review": "This product is amazing!"
    }
    ```
  - **404 Not Found**: Review not found.

### 6. **Update a Review**

- **Endpoint**: `PUT /api/v1/reviews/{reviewId}`
- **Description**: Updates the details of an existing review.
- **Authentication**: yes
- **Request Body**:
  ```json
  {
    "rating": 4,
    "review": "This product is great!"
  }
  ```
- **Response**:
  - **200 OK**:
    ```json
    {
      "review_id": "abc123",
      "productId": "12345",
      "userId": "67890",
      "review_date": "2024-08-20T13:00:00Z",
      "rating": 4,
      "review": "This product is great!"
    }
    ```
  - **404 Not Found**: Review not found.

### 7. **Delete a Review**

- **Endpoint**: `DELETE /api/v1/reviews/{reviewId}`
- **Description**: Deletes a review.
- **Authentication**: yes
- **Response**:
  - **204 No Content**: Successfully deleted.
  - **404 Not Found**: Review not found.

## **Orders API Endpoints**

### 1. **Create an Order**

- **Endpoint**: `POST /api/v1/order`
- **Description**: Places a new order.
- **Request Body**:
  ```json
  {
    "userId": "67890",
    "order_items": [
      {
        "order_item_id": "12345",
        "quantity": 2,
        "price": 30
      },
      {
        "order_item_id": "52345",
        "quantity": 2,
        "price": 30
      }
    ],
    "order_date": "2024-08-20T13:00:00Z",
    "total_price": 60.0,
    "shipments": {
      "shipment_id": 12345,
      "shipment_date": "2024-08-20T13:00:00Z",
      "address": {
        "address_id": 1234,
        "unit_number": "sdun",
        "street_number": 23,
        "address_line1": "wall street",
        "address_line2": "Marlin street",
        "city": "Helsinki",
        "postal_code": 00100,
        "country": "Finland"
      }
    },
    "order_status": "pending"
  }
  ```
- **Response**:
  - **201 Created**:
    ```json
    {
      "order_id": 1234,
      "userId": "67890",
      "order_date": "2024-08-20T13:00:00Z",
      "total_price": 60.0,
      "order_status": "pending"
      "order_items": [
        {
          "order_item_id": "12345",
          "quantity": 2,
          "price": 30
        },
        {
          "order_item_id": "52345",
          "quantity": 2,
          "price": 30
        }
      ]
    }
    ```
  - **400 Bad Request**: Invalid input data.

### 2. **Get All Orders**

- **Endpoint**: `GET /api/v1/orders`
- **Description**: Retrieves a list of orders for a user.
- **Query Parameters** (optional):
  - `?page={pageNumber}&limit={pageSize}`: Pagination options.
  - `?userId={userId}`: Filter orders by user.
  - `?order_status={order_status}`: Filter orders by user.
- **Response**:
  - **200 OK**:
    ```json
    [
        {
            "userId": "67890",
            "order_items": [
                {
                    "order_item_id": "12345",
                    "quantity": 2,
                    "price": 30
                },
                {
                    "order_item_id": "52345",
                    "quantity": 2,
                    "price": 30
                }
            ],
            "order_date": "2024-08-20T13:00:00Z",
            "total_price": 60.00,
            "shipments":
                {
                    "shipment_id": 12345,
                    "shipment_date": "2024-08-20T13:00:00Z",
                    "address":
                        {
                            "address_id": 1234,
                            "unit_number": "sdun",
                            "street_number": 23,
                            "address_line1": "wall street",
                            "address_line2": "Marlin street",
                            "city": "Helsinki",
                            "postal_code": 00100,
                            "country": "Finland"
                        }
                },
            "order_status": "pending"
        },
        ...
    ]
    ```

### 3. **Get a Single Order by ID**

- **Endpoint**: `GET /api/v1/orders/{orderId}`
- **Description**: Retrieves details of a specific order.
- **Response**:
  - **200 OK**:
    ```json
    {
      "userId": "67890",
      "order_items": [
        {
          "order_item_id": "12345",
          "quantity": 2,
          "price": 30
        },
        {
          "order_item_id": "52345",
          "quantity": 2,
          "price": 30
        }
      ],
      "order_date": "2024-08-20T13:00:00Z",
      "total_price": 60.0,
      "shipments": {
        "shipment_id": 12345,
        "shipment_date": "2024-08-20T13:00:00Z",
        "address": {
          "address_id": 1234,
          "unit_number": "sdun",
          "street_number": 23,
          "address_line1": "wall street",
          "address_line2": "Marlin street",
          "city": "Helsinki",
          "postal_code": 00100,
          "country": "Finland"
        }
      },
      "order_status": "pending"
    }
    ```
  - **404 Not Found**: Order not found.

### 4. **Update an Order**

- **Endpoint**: `PUT /api/v1/orders/{orderId}`
- **Description**: Updates the order (for example reduce order item).
- **Request Body**:
  ```json
  {
    "order_items": [
      {
        "order_item_id": "12345",
        "quantity": 2,
        "price": 30
      }
    ]
  }
  ```
- **Response**:
  - **200 OK**:
    ```json
    {
      "userId": "67890",
      "order_items": [
        {
          "order_item_id": "12345",
          "quantity": 2,
          "price": 30
        }
      ],
      "order_date": "2024-08-20T13:00:00Z",
      "total_price": 30.0,
      "shipments": {
        "shipment_id": 12345,
        "shipment_date": "2024-08-20T13:00:00Z",
        "address": {
          "address_id": 1234,
          "unit_number": "sdun",
          "street_number": 23,
          "address_line1": "wall street",
          "address_line2": "Marlin street",
          "city": "Helsinki",
          "postal_code": 00100,
          "country": "Finland"
        }
      },
      "order_status": "pending"
    }
    ```
  - **404 Not Found**: Order not found.

### 5. **Delete an Order**

- **Endpoint**: `DELETE /api/v1/orders/{orderId}`
- **Description**: Deletes an order.
- **Response**:
  - **204 No Content**: Successfully deleted.
  - **404 Not Found**: Order not found.

## Payments API Endpoints

### **1. Create a Payment**

- **Endpoint**: `POST /api/v1/payments`
- **Description**: Initiates a new payment for an order.
- **Request Body**:
  ```json
  {
    "orderId": 12345,
    "user_id": 23453,
    "payment_date": "2024-08-20T13:00:00Z",
    "amount": 30.0,
    "payment_method": {
      "payment_method_id": 1234,
      "payment_type": "credit card",
      "provider": "nordea",
      "card_number": "4111111111111111",
      "expiry_date": "12/24",
      "isDefault": true
    }
  }
  ```
- **Response**:
  - **201 Created**:
    ```json
    {
      "orderId": 12345,
      "user_id": 23453,
      "status": "processing",
      "payment_date": "2024-08-20T13:00:00Z",
      "amount": 30.0,
      "payment_method": {
        "payment_method_id": 1234,
        "payment_type": "credit card",
        "provider": "nordea",
        "card_number": "4111111111111111",
        "expiry_date": "12/24",
        "isDefault": true
      }
    }
    ```
  - **400 Bad Request**: Invalid input data (e.g., missing fields, invalid card details).

### **2. Get Payment Details**

- **Endpoint**: `GET /api/v1/payments/{paymentId}`
- **Description**: Retrieves details of a specific payment.
- **Response**:
  - **200 OK**:
    ```json
    {
      "orderId": 12345,
      "user_id": 23453,
      "status": "completed",
      "payment_date": "2024-08-20T13:00:00Z",
      "amount": 30.0,
      "payment_method": {
        "payment_method_id": 1234,
        "payment_type": "credit card"
      }
    }
    ```
  - **404 Not Found**: Payment not found.

### **3. Get All Payments**

- **Endpoint**: `GET /api/v1/payments`
- **Description**: Retrieves a list of all payments.
- **Authorization**: yes
- **Query Parameters** (optional):
  - `?orderId={orderId}`: Filter payments by order ID.
  - `?userId={userId}`: Filter payments by user ID.
  - `?page={pageNumber}&limit={pageSize}`: Pagination options.
- **Response**:
  - **200 OK**:
    ```json
    [
        {
            "orderId": 12345,
            "user_id": 23453,
            "status": "completed",
            "payment_date": "2024-08-20T13:00:00Z",
            "amount": 30.0,
            "payment_method":
                {
                    "payment_method_id": 1234,
                    "payment_type": "credit card"
                }
        },
        ...
    ]
    ```

### **4. Update Payment Status**

- **Endpoint**: `PUT /api/v1/payments/{paymentId}`
- **Description**: Updates the status of a payment (e.g., from "processing" to "completed").
- **Authorization**: yes
- **Request Body**:
  ```json
  {
    "status": "completed"
  }
  ```
- **Response**:
  - **200 OK**:
    ```json
    {
      "orderId": 12345,
      "user_id": 23453,
      "status": "completed",
      "payment_date": "2024-08-20T13:00:00Z",
      "amount": 30.0,
      "payment_method": {
        "payment_method_id": 1234,
        "payment_type": "credit card",
        "provider": "nordea",
        "card_number": "4111111111111111",
        "expiry_date": "12/24",
        "isDefault": true
      }
    }
    ```
  - **404 Not Found**: Payment not found.

### **5. Delete a Payment**

- **Endpoint**: `DELETE /api/v1/payments/{paymentId}`
- **Description**: Deletes a payment record.
- **Authorization**: yes
- **Response**:
  - **204 No Content**: Successfully deleted.
  - **404 Not Found**: Payment not found.

## Shipments API Endpoints

### 1. Create a Shipment

- **Endpoint**: `POST /api/v1/shipment`
- **Description**: Creates a new shipment.
- **Request Body**:

  ```json
  {
    "order_id": 1234,
    "shipment_date": "2024-08-20T13:00:00Z",
    "address": {
      "address_id": 1234,
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
  - **200 OK**:

    ```json
    {
      "shipment_id": 5678,
      "order_id": 1234,
      "shipment_date": "2024-08-20T13:00:00Z",
      "address": {
        "address_id": 1234,
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

- **400 Bad Request**: Invalid input data.

### 2. Update a Shipment

- **Endpoint**: `PUT /api/v1/shipments/{shipment_id}`
- **Description**: Updates an existing shipment.
- **Request Body**:

  ```json
  {
    "shipment_date": "2024-08-21T13:00:00Z",
    "address": {
      "address_id": 1234,
      "unit_number": "new_unit",
      "street_number": 25,
      "address_line1": "new street",
      "address_line2": "New Marlin street",
      "city": "Helsinki",
      "postal_code": 00200,
      "country": "Finland"
    }
  }
  ```

  - **Response**:
  - **200 OK**:

    ```json
    {
      "shipment_id": 5678,
      "order_id": 1234,
      "shipment_date": "2024-08-21T13:00:00Z",
      "address": {
        "address_id": 1234,
        "unit_number": "new_unit",
        "street_number": 25,
        "address_line1": "new street",
        "address_line2": "New Marlin street",
        "city": "Helsinki",
        "postal_code": 00200,
        "country": "Finland"
      }
    }
    ```

    - **400 Bad Request**: Invalid input data.
    - **404 Not Found**: Shipment not found.

### 3. Delete a Shipment

- **Endpoint**: `DELETE /api/v1/shipments/{shipment_id}`
- **Description**: Deletes a shipment.
- **Responses**:
  - **204 No Content**: Successfully deleted.
  - **404 Not Found**: Shipment not found.

### 4. Get Shipment Details

- **Endpoint**: `GET /api/v1/shipments/{shipment_id}`
- **Description**: Retrieves details of a specific shipment.
- **Responses**:
  - **200 OK**:
    ```json
    {
      "shipment_id": 5678,
      "order_id": 1234,
      "shipment_date": "2024-08-20T13:00:00Z",
      "address": {
        "address_id": 1234,
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
  - **404 Not Found**: Shipment not found.

### 5. List Shipments

- **Endpoint**: `GET /api/v1/shipments`
- **Description**: Retrieves a list of all shipments.
- **Responses**:
  - **200 OK**:
    ```json
    [
      {
        "shipment_id": 5678,
        "order_id": 1234,
        "shipment_date": "2024-08-20T13:00:00Z",
        "address": {
          "address_id": 1234,
          "unit_number": "sdun",
          "street_number": 23,
          "address_line1": "wall street",
          "address_line2": "Marlin street",
          "city": "Helsinki",
          "postal_code": 00100,
          "country": "Finland"
        }
      },
      {
        "shipment_id": 5679,
        "order_id": 1235,
        "shipment_date": "2024-08-21T13:00:00Z",
        "address": {
          "address_id": 1235,
          "unit_number": "another_unit",
          "street_number": 25,
          "address_line1": "another street",
          "address_line2": "Another Marlin street",
          "city": "Helsinki",
          "postal_code": 00200,
          "country": "Finland"
        }
      }
    ]
    ```

---

### **Conclusion**

These API endpoints provide a clear, RESTful structure for interacting with products, users, reviews, orders and payments in an e-commerce system.
