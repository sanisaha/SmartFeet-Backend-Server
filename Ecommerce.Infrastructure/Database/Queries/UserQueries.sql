-- Create new user
CREATE OR REPLACE FUNCTION fun_create_user(
    _user_name VARCHAR, 
    _email VARCHAR, 
    _password VARCHAR, 
    _phone_number VARCHAR, 
    _role role_type
) RETURNS UUID AS 
$$
DECLARE
    new_user_id UUID;
BEGIN
    INSERT INTO public.users (user_name, email, password, phone_number, role)
    VALUES (_user_name, _email, _password, _phone_number, _role)
    RETURNING user_id INTO new_user_id;

    RETURN new_user_id;
END;
$$ LANGUAGE plpgsql;

-- Get all Users
CREATE OR REPLACE FUNCTION get_all_users() 
RETURNS TABLE (
    user_id UUID, 
    user_name VARCHAR, 
    email VARCHAR, 
    phone_number VARCHAR, 
    role role_type
) AS 
$$
BEGIN
    RETURN QUERY SELECT user_id, user_name, email, phone_number, role FROM public.users;
END;
$$ LANGUAGE plpgsql;

-- Get user by id
CREATE OR REPLACE FUNCTION get_user(_user_id UUID) 
RETURNS TABLE (
    user_id UUID, 
    user_name VARCHAR, 
    email VARCHAR, 
    phone_number VARCHAR, 
    role role_type
) AS 
$$
BEGIN
    RETURN QUERY SELECT user_id, user_name, email, phone_number, role FROM public.users WHERE user_id = _user_id;
END;
$$ LANGUAGE plpgsql;

-- Update user information
CREATE OR REPLACE FUNCTION update_user(
    _user_id UUID,
    _user_name VARCHAR, 
    _email VARCHAR, 
    _phone_number VARCHAR, 
    _role role_type
) RETURNS VOID AS 
$$
BEGIN
    UPDATE public.users
    SET user_name = _user_name, email = _email, phone_number = _phone_number, role = _role
    WHERE user_id = _user_id;
END;
$$ LANGUAGE plpgsql;

-- Delete user
CREATE OR REPLACE FUNCTION delete_user(
  _user_id UUID
) RETURNS VOID AS $$
BEGIN
    DELETE FROM public.users WHERE user_id = _user_id;
END;
$$ LANGUAGE plpgsql;



