DELIMITER //
CREATE PROCEDURE sp_ObtenerHabitacion(IN id INT)
BEGIN
    SELECT * FROM habitacion WHERE id_habitacion = id;
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE sp_InsertarHabitacion(
    IN Num VARCHAR(50),
    IN Tip VARCHAR(50),
    IN Cap INT,
    IN Preciob DECIMAL(10,2),
    IN Estad VARCHAR(20)
)
BEGIN
    INSERT INTO habitacion (numero, tipo, capacidad, precio_base, estado)
    VALUES (Num, Tip, Cap, Preciob, Estad);
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE sp_ActualizarHabitacion(
    IN id INT,
    IN Num VARCHAR(50),
    IN Tip VARCHAR(50),
    IN Cap INT,
    IN Preciob DECIMAL(10,2),
    IN Estad VARCHAR(20)
)
BEGIN
    UPDATE habitacion
    SET numero = Num, tipo = Tip, capacidad = Cap, precio_base = Preciob, estado = Estad
    WHERE id_habitacion = id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_EliminarHabitacion(IN id_h INT)
BEGIN
    DELETE FROM habitacion WHERE id_habitacion = id_h;
END //
DELIMITER ;
