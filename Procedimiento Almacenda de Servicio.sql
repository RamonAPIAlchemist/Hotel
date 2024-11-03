DELIMITER //
CREATE PROCEDURE sp_ObtenerServicio(IN id INT)
BEGIN
    SELECT * FROM servicio WHERE id_servicio = id;
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE sp_InsertarServicio(
    IN Nom VARCHAR(255),
    IN Descrip TEXT,
    IN Preci DECIMAL(10,2)
)
BEGIN
    INSERT INTO servicio (nombre, descripcion, precio)
    VALUES (Nom, Descrip, Preci);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_ActualizarServicio(
    IN id_s INT,
    IN Nom VARCHAR(255),
    IN Descrip TEXT,
    IN Preci DECIMAL(10,2)
)
BEGIN
    UPDATE servicio
    SET nombre = Nom, descripcion = Descrip, precio = Preci
    WHERE id_servicio = id_s;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_EliminarServicio(IN id_s INT)
BEGIN
    DELETE FROM servicio WHERE id_servicio = id_s;
END //
DELIMITER ;


