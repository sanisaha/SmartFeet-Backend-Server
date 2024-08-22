-- Create new order
CREATE OR REPLACE FUNCTION fun_create_order(
    _user_id UUID, 
    _total_price NUMERIC, 
    _shipping_address_id UUID, 
    _order_status order_status DEFAULT 'pending'
) RETURNS UUID AS $$
DECLARE
    new_order_id UUID;
BEGIN
    INSERT INTO public.orders (user_id, total_price, shipping_address_id, order_status)
    VALUES (_user_id, _total_price, _shipping_address_id, _order_status)
    RETURNING order_id INTO new_order_id;

    RETURN new_order_id;
END;
$$ LANGUAGE plpgsql;

-- Get all orders
CREATE OR REPLACE FUNCTION get_all_orders() 
RETURNS TABLE (
    order_id UUID, 
    user_id UUID, 
    order_date TIMESTAMP, 
    total_price NUMERIC, 
    shipping_address_id UUID, 
    order_status order_status
) AS $$
BEGIN
    RETURN QUERY SELECT * FROM public.orders;
END;
$$ LANGUAGE plpgsql;

-- Get one order
CREATE OR REPLACE FUNCTION get_order(_order_id UUID) 
RETURNS TABLE (
    order_id UUID, 
    user_id UUID, 
    order_date TIMESTAMP, 
    total_price NUMERIC, 
    shipping_address_id UUID, 
    order_status order_status
) AS $$
BEGIN
    RETURN QUERY SELECT * FROM public.orders WHERE order_id = _order_id;
END;
$$ LANGUAGE plpgsql;

-- update order status
CREATE OR REPLACE FUNCTION update_order_status(
    _order_id UUID, 
    _order_status order_status
) RETURNS VOID AS $$
BEGIN
    UPDATE public.orders
    SET order_status = _order_status
    WHERE order_id = _order_id;
END;
$$ LANGUAGE plpgsql;

-- Delete one order
CREATE OR REPLACE FUNCTION delete_order(_order_id UUID) RETURNS VOID AS $$
BEGIN
    DELETE FROM public.orders WHERE order_id = _order_id;
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