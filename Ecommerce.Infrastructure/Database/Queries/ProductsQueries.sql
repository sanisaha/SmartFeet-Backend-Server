--Insert product
CREATE OR REPLACE FUNCTION create_product(
    p_category_id UUID,
    p_description VARCHAR(100),
    p_price DECIMAL(10,2),
    p_stock INT,
    p_product_line VARCHAR(100),
    p_image_URL VARCHAR(200),
    p_isPrimary BOOLEAN,
    p_image_text VARCHAR(200),
    p_size_value ENUM, 
    p_stock_quantity INT,
    p_color_name VARCHAR(100)
) RETURNS BOOLEAN AS $$
DECLARE
    new_product_id UUID;
BEGIN
    INSERT INTO products (product_id, category_id, description, price, stock, product_line)
    VALUES (p_product_id, p_category_id, p_description, p_price, p_stock, p_product_line);

	INSERT INTO product_images (product_id, image_URL, isPrimary, image_text)
    VALUES (new_product_id, p_image_URL, p_isPrimary, p_image_text);

	INSERT INTO product_sizes (product_id, size_value, stock_quantity)
    VALUES (new_product_id, p_size_value, p_stock_quantity);

	INSERT INTO product_colors (product_id, color_name)
    VALUES (new_product_id, p_color_name);
	
    IF FOUND THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END;
$$ LANGUAGE plpgsql;


--Retrieve Products
CREATE OR REPLACE FUNCTION get_all_products()
RETURNS TABLE (
    product_id UUID,
    category_id UUID,
    description CHAR(100),
    price DECIMAL(10,2),
    stock INT,
    product_line CHAR(100),
    image_URL CHAR(200),
    isPrimary BOOL,
    image_text CHAR(200),
    size_value CHAR(100),
    stock_quantity INT,
    color_name CHAR(100)
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
        p.product_id,
        p.category_id,
        p.description,
        p.price,
        p.stock,
        p.product_line,
        pi.image_URL,
        pi.isPrimary,
        pi.image_text,
        ps.size_value,
        ps.stock_quantity,
        pc.color_name
    FROM 
        products p
    LEFT JOIN 
        product_images pi ON p.product_id = pi.product_id
    LEFT JOIN 
        product_sizes ps ON p.product_id = ps.product_id
    LEFT JOIN 
        product_colors pc ON p.product_id = pc.product_id;
END;
$$ LANGUAGE plpgsql;



--get product by id
CREATE OR REPLACE FUNCTION get_product_byId(
    p_product_id UUID
)
RETURNS TABLE (
    product_id UUID,
    category_id UUID,
    description CHAR(100),
    price DECIMAL(10,2),
    stock INT,
    product_line CHAR(100),
    image_URL CHAR(200),
    isPrimary BOOL,
    image_text CHAR(200),
    size_value CHAR(100),
    stock_quantity INT,
    color_name CHAR(100)
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
        p.product_id,
        p.category_id,
        p.description,
        p.price,
        p.stock,
        p.product_line,
        pi.image_URL,
        pi.isPrimary,
        pi.image_text,
        ps.size_value,
        ps.stock_quantity,
        pc.color_name
    FROM 
        products p
    LEFT JOIN 
        product_images pi ON p.product_id = pi.product_id
    LEFT JOIN 
        product_sizes ps ON p.product_id = ps.product_id
    LEFT JOIN 
        product_colors pc ON p.product_id = pc.product_id
    WHERE 
        p.product_id = p_product_id;
END;
$$ LANGUAGE plpgsql;


--update product
CREATE OR REPLACE FUNCTION update_product(
    p_product_id UUID,
    p_category_id UUID,
    p_description CHAR(100),
    p_price DECIMAL(10,2),
    p_stock INT,
    p_product_line CHAR(100),
    p_image_URL CHAR(200) DEFAULT NULL,
    p_isPrimary BOOL DEFAULT NULL,
    p_image_text CHAR(200) DEFAULT NULL,
    p_size_value CHAR(100) DEFAULT NULL,
    p_stock_quantity INT DEFAULT NULL,
    p_color_name CHAR(100) DEFAULT NULL
) RETURNS BOOLEAN AS $$
BEGIN
    
    UPDATE products
    SET category_id = p_category_id,
        description = p_description,
        price = p_price,
        stock = p_stock,
        product_line = p_product_line
    WHERE product_id = p_product_id;

    IF p_image_URL IS NOT NULL OR p_isPrimary IS NOT NULL OR p_image_text IS NOT NULL THEN
        UPDATE product_images
        SET image_URL = COALESCE(p_image_URL, image_URL),
            isPrimary = COALESCE(p_isPrimary, isPrimary),
            image_text = COALESCE(p_image_text, image_text)
        WHERE product_id = p_product_id;
    END IF;

    IF p_size_value IS NOT NULL OR p_stock_quantity IS NOT NULL THEN
        UPDATE product_sizes
        SET size_value = COALESCE(p_size_value, size_value),
            stock_quantity = COALESCE(p_stock_quantity, stock_quantity)
        WHERE product_id = p_product_id;
    END IF;

    IF p_color_name IS NOT NULL THEN
        UPDATE product_colors
        SET color_name = COALESCE(p_color_name, color_name)
        WHERE product_id = p_product_id;
    END IF;

    IF FOUND THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END;
$$ LANGUAGE plpgsql;


-- delete product
CREATE OR REPLACE FUNCTION delete_product(
    p_product_id UUID
) RETURNS BOOLEAN AS $$
BEGIN
 
    DELETE FROM product_images
    WHERE product_id = p_product_id;
    
    DELETE FROM product_sizes
    WHERE product_id = p_product_id;

    DELETE FROM product_colors
    WHERE product_id = p_product_id;

    DELETE FROM products
    WHERE product_id = p_product_id;
  
    IF SQL%ROWCOUNT > 0 THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END;
$$ LANGUAGE plpgsql;

--get most purchased products
