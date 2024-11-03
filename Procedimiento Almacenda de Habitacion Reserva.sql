DELIMITER //

CREATE PROCEDURE sp_ObtenerHabitacionReserva(IN id INT)
BEGIN
    SELECT * FROM habitacion_reserva WHERE id_habitacion_reserva = id;
END //

CREATE PROCEDURE sp_InsertarHabitacionReserva(
    IN idReserva INT,
    IN idHabitacion INT,
    IN precioNoche INT,
    IN cantidadNoches INT
)
BEGIN
    INSERT INTO habitacion_reserva (id_reserva, id_habitacion, precio_noche, cantidad_noches)
    VALUES (idReserva, idHabitacion, precioNoche, cantidadNoches);
END //

CREATE PROCEDURE sp_ActualizarHabitacionReserva(
    IN idHabitacionReserva INT,
    IN idReserva INT,
    IN idHabitacion INT,
    IN precioNoche INT,
    IN cantidadNoches INT
)
BEGIN
    UPDATE habitacion_reserva
    SET id_reserva = idReserva,
        id_habitacion = idHabitacion,
        precio_noche = precioNoche,
        cantidad_noches = cantidadNoches
    WHERE id_habitacion_reserva = idHabitacionReserva;
END //

CREATE PROCEDURE sp_EliminarHabitacionReserva(IN id INT)
BEGIN
    DELETE FROM habitacion_reserva WHERE id_habitacion_reserva = id;
END //

DELIMITER ;
