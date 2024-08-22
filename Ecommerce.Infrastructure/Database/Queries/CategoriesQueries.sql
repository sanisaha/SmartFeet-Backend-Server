-- Create new category
CREATE OR REPLACE FUNCTION create_category(
    _category_name VARCHAR
) RETURNS UUID AS $$
DECLARE
    new_category_id UUID;
BEGIN
    INSERT INTO public.categories (category_name)
    VALUES (_category_name)
    RETURNING category_id INTO new_category_id;

    RETURN new_category_id;
END;
$$ LANGUAGE plpgsql;

-- Get all categories
CREATE OR REPLACE FUNCTION get_all_categories() 
RETURNS TABLE (
    category_id UUID, 
    category_name VARCHAR
) AS $$
BEGIN
    RETURN QUERY SELECT * FROM public.categories;
END;
$$ LANGUAGE plpgsql;

-- Get one category
CREATE OR REPLACE FUNCTION get_category(_category_id UUID) 
RETURNS TABLE (
    category_id UUID, 
    category_name VARCHAR
) AS $$
BEGIN
    RETURN QUERY SELECT * FROM public.categories WHERE category_id = _category_id;
END;
$$ LANGUAGE plpgsql;

-- Update category
CREATE OR REPLACE FUNCTION update_category(
    _category_id UUID, 
    _category_name VARCHAR
) RETURNS VOID AS $$
BEGIN
    UPDATE public.categories
    SET category_name = _category_name
    WHERE category_id = _category_id;
END;
$$ LANGUAGE plpgsql;

-- Delete category
CREATE OR REPLACE FUNCTION delete_category(
  _category_id UUID
) RETURNS VOID AS 
$$
BEGIN
    DELETE FROM public.categories WHERE category_id = _category_id;
END;
$$ LANGUAGE plpgsql;
