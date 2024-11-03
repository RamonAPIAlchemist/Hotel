DELIMITER $$

DELIMITER $$

CREATE PROCEDURE sp_InsertarHuesped(
    IN nombres VARCHAR(20),
    IN apellidos VARCHAR(20),
    IN email VARCHAR(30),
    IN telefono VARCHAR(15),
    IN direccion VARCHAR(100)
)
BEGIN
    INSERT INTO huesped (nombres, apellidos, email, telefono, direccion)
    VALUES (nombres, apellidos, email, telefono, direccion);
END $$

DELIMITER ;InsertHabitacion



DELIMITER $$

CREATE PROCEDURE sp_ActualizarHuesped(
    IN idO INT,
    IN Nombres VARCHAR(20),
    IN Apellidos VARCHAR(20),
    IN Email VARCHAR(30),
    IN Telefono VARCHAR(15),
    IN Direccion VARCHAR(100)
)
BEGIN
    UPDATE huesped 
    SET nombres = Nombres, apellidos = Apellidos, email = Email, telefono = Telefono, direccion = Direccion
    WHERE id_huesped = idO;
END $$

DELIMITER ;


DELIMITER $$

CREATE PROCEDURE sp_EliminarHuesped(
    IN idToDelete INT
)
BEGIN
    DELETE FROM huesped WHERE id_huesped = idToDelete;
END $$

DELIMITER ;



