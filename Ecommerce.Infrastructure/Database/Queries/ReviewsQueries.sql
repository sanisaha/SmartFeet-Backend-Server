-- Create new review
CREATE OR REPLACE FUNCTION fun_create_review(
    _user_id UUID, 
    _product_id UUID, 
    _comment_text VARCHAR, 
    _rating INTEGER
) RETURNS UUID AS $$
DECLARE
    new_review_id UUID;
BEGIN
    INSERT INTO reviews (user_id, product_id, comment_text, rating)
    VALUES (_user_id, _product_id, _comment_text, _rating)
    RETURNING review_id INTO new_review_id;

    RETURN new_review_id;
END;
$$ LANGUAGE plpgsql;

-- Get all reviews
CREATE OR REPLACE FUNCTION fun_get_all_reviews() 
RETURNS TABLE (
    review_id UUID, 
    user_id UUID, 
    product_id UUID, 
    comment_text VARCHAR, 
    rating INTEGER, 
    review_date TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY SELECT * FROM reviews;
END;
$$ LANGUAGE plpgsql;

-- Get one review of a product
CREATE OR REPLACE FUNCTION fun_get_reviews_by_product(_product_id UUID) 
RETURNS TABLE (
    review_id UUID, 
    user_id UUID, 
    comment_text VARCHAR, 
    rating INTEGER, 
    review_date TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY SELECT review_id, user_id, comment_text, rating, review_date 
    FROM reviews WHERE product_id = _product_id;
END;
$$ LANGUAGE plpgsql;

-- Update One Review
CREATE OR REPLACE FUNCTION fun_update_review(
    _review_id UUID,
    _comment_text VARCHAR, 
    _rating INTEGER
) RETURNS VOID AS $$
BEGIN
    UPDATE reviews
    SET comment_text = _comment_text, rating = _rating
    WHERE review_id = _review_id;
END;
$$ LANGUAGE plpgsql;

-- Delete one review
CREATE OR REPLACE FUNCTION fun_delete_review(_review_id UUID) RETURNS VOID AS $$
BEGIN
    DELETE FROM reviews WHERE review_id = _review_id;
END;
$$ LANGUAGE plpgsql;
