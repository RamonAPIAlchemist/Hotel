DELIMITER //
CREATE PROCEDURE sp_ObtenerReserva(IN id INT)
BEGIN
    SELECT * FROM reserva WHERE id_reserva = id;
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE sp_InsertarReserva(
    IN idHuesped INT,
    IN idServicio INT,
    IN fechaReserva VARCHAR(8),
    IN fechaIngreso VARCHAR(8),
    IN fechaSalida VARCHAR(8),
    IN estadoReserva VARCHAR(20)
)
BEGIN
    INSERT INTO reserva (id_huesped, id_servicio, fecha_reserva, fecha_ingreso, fecha_salida, estado)
    VALUES (idHuesped, idServicio, fechaReserva, fechaIngreso, fechaSalida, estadoReserva);
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE sp_ActualizarReserva(
    IN idR INT,
    IN idHuesped INT,
    IN idServicio INT,
    IN fechaReserva VARCHAR(8),
    IN fechaIngreso VARCHAR(8),
    IN fechaSalida VARCHAR(8),
    IN estadoReserva VARCHAR(20)
)
BEGIN
    UPDATE reserva
    SET id_huesped = idHuesped, id_servicio = idServicio, fecha_reserva = fechaReserva, 
        fecha_ingreso = fechaIngreso, fecha_salida = fechaSalida, estado = estadoReserva
    WHERE id_reserva = idR;
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE sp_EliminarReserva(IN id INT)
BEGIN
    DELETE FROM reserva WHERE id_reserva = id;
END //
DELIMITER ;
