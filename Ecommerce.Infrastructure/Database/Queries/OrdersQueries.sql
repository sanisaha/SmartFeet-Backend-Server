-- Create new order
CREATE OR REPLACE PROCEDURE fun_create_order(
    p_user_id UUID,
    p_order_items order_item_type[],
    p_order_date TIMESTAMP,
    p_total_price NUMERIC,
    p_shipment shipment_type,
    p_order_status VARCHAR
)
LANGUAGE plpgsql AS
$$
DECLARE
    new_order_id UUID;
    new_shipment_id UUID;
    new_address_id UUID;
    item order_item_type;
    item_price NUMERIC;
BEGIN
    -- Check if user exists
    PERFORM 1 FROM users WHERE user_id = p_user_id;
    IF NOT FOUND THEN
        RAISE EXCEPTION 'User does not exist';
    END IF;

    -- Insert Address
    INSERT INTO address(
        unit_number, street_number, address_line1, address_line2, city, postal_code, country
    ) VALUES (
        p_shipment.address.unit_number, 
        p_shipment.address.street_number, 
        p_shipment.address.address_line1, 
        p_shipment.address.address_line2, 
        p_shipment.address.city, 
        p_shipment.address.postal_code, 
        p_shipment.address.country
    ) RETURNING address_id INTO new_address_id;

    -- Insert new order
    INSERT INTO orders(user_id, order_date, total_price, shipping_address_id, order_status)
    VALUES (p_user_id, p_order_date, p_total_price, new_address_id, p_order_status)
    RETURNING order_id INTO new_order_id;

    -- Insert Shipment
    INSERT INTO shipments(order_id, shipment_date, address_id)
    VALUES (new_order_id, p_shipment.shipment_date, new_address_id)
    RETURNING shipment_id INTO new_shipment_id;

    -- Process each order item
    FOREACH item IN ARRAY p_order_items
    LOOP
        -- Check if product exists
        PERFORM 1 FROM products WHERE product_id = item.product_id;
        IF NOT FOUND THEN
            RAISE EXCEPTION 'Product with id % does not exist', item.product_id;
        END IF;

        -- Check if there is enough stock
        IF (SELECT stock FROM products WHERE product_id = item.product_id) < item.quantity THEN
            RAISE EXCEPTION 'Not enough inventory for product_id %', item.product_id;
        END IF;

        -- Get the price of the product
        SELECT price INTO item_price FROM products WHERE product_id = item.product_id;

        -- Insert into order_items
        INSERT INTO order_items(order_id, product_id, quantity, price)
        VALUES (new_order_id, item.product_id, item.quantity, item_price);

        -- Update product stock
        UPDATE products
        SET stock = stock - item.quantity
        WHERE product_id = item.product_id;
    END LOOP;

    -- Update the total price if necessary
    UPDATE orders
    SET total_price = (
        SELECT SUM(price * quantity)
        FROM order_items
        WHERE order_id = new_order_id
    )
    WHERE order_id = new_order_id;

END; LANGUAGE plpgsql;

-- Get all orders
CREATE OR REPLACE FUNCTION fun_get_all_orders() 
RETURNS TABLE (
    order_id UUID, 
    user_id UUID, 
    order_date TIMESTAMP, 
    total_price NUMERIC, 
    shipping_address_id UUID, 
    order_status order_status
) AS $$
BEGIN
    RETURN QUERY SELECT * FROM orders;
END;
$$ LANGUAGE plpgsql;

-- Get one order
CREATE OR REPLACE FUNCTION fun_get_order(_order_id UUID) 
RETURNS TABLE (
    order_id UUID, 
    user_id UUID, 
    order_date TIMESTAMP, 
    total_price NUMERIC, 
    shipping_address_id UUID, 
    order_status order_status
) AS $$
BEGIN
    RETURN QUERY SELECT * FROM orders WHERE order_id = _order_id;
END;
$$ LANGUAGE plpgsql;

-- update order status
CREATE OR REPLACE FUNCTION fun_update_order_status(
    _order_id UUID, 
    _order_status order_status
) RETURNS VOID AS $$
BEGIN
    UPDATE orders
    SET order_status = _order_status
    WHERE order_id = _order_id;
END;
$$ LANGUAGE plpgsql;

-- Delete one order
CREATE OR REPLACE FUNCTION fun_delete_order(_order_id UUID) RETURNS VOID AS $$
BEGIN
    DELETE FROM orders WHERE order_id = _order_id;
END;
$$ LANGUAGE plpgsql;









CREATE OR REPLACE PROCEDURE order_processing(user_id int, order_items  order_item_type[])
LANGUAGE plpgsql AS
$$
DECLARE
      new_order_id int
      item order_item_type
      item_price numeric
BEGIN
      
      IF IS NOT EXISTS (SELECT * FROM users WHERE id= user_id) THEN RAISE EXCEPTION 'User does not exist';
      END IF;

      INSERT INTO orders(user_id) VALUES(user_id) returning id INTO new_order_id;

      FOREACH item IN array order_items
      LOOP
            SELECT * FROM products where product_id = item.product_id;

            IF NOT EXISTS then raise exception 'Product_id does not exists';
            END IF;

            IF(SELECT stock FROM products where product_id = item.product_id) < item.orders then raise exception 'Not enough inventory.';
            END IF;

            SELECT price into item_price FROM products WHERE product_id= item.product;
            INSERT INTO order_items(order_id, produt_id, quantity, price) VALUES(new_order_id, item.produxt_id, item.quantity, item_price)
            UPDATE products SET stock = stock - item.quantity where id = item.product_id;

      END LOOP;
END;
$$;