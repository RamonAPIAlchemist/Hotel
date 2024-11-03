CREATE DATABASE db_hotel;
USE db_hotel;

CREATE TABLE huesped (
    id_huesped INT PRIMARY KEY AUTO_INCREMENT,
    nombres VARCHAR(20),sp_ActualizarHabitacionsp_ActualizarHuesped
    apellidos VARCHAR (20),
    email VARCHAR(30),
    telefono INT,  -- Cambiado a VARCHAR para mayor flexibilidad
    direccion VARCHAR(100)
);

CREATE TABLE habitacion (
    id_habitacion INT PRIMARY KEY AUTO_INCREMENT,
    numero VARCHAR(50),
    tipo VARCHAR(20),
    capacidad INT,
    precio_base INT,
    estado VARCHAR(20)
);

CREATE TABLE servicio (
    id_servicio INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(50),
    descripcion VARCHAR(500),
    precio INT
);

CREATE TABLE reserva (
    id_reserva INT PRIMARY KEY AUTO_INCREMENT,
    id_huesped INT,
    id_servicio INT,
    fecha_reserva VARCHAR(8),
    fecha_ingreso VARCHAR(8),
    fecha_salida VARCHAR(8),
    estado VARCHAR(20),
    FOREIGN KEY (id_huesped) REFERENCES huesped(id_huesped),
    FOREIGN KEY (id_servicio) REFERENCES servicio(id_servicio)
);

CREATE TABLE habitacion_reserva (
    id_habitacion_reserva INT PRIMARY KEY AUTO_INCREMENT,
    id_reserva INT,
    id_habitacion INT,
    precio_noche INT,
    cantidad_noches INT,
    FOREIGN KEY (id_reserva) REFERENCES reserva(id_reserva),
    FOREIGN KEY (id_habitacion) REFERENCES habitacion(id_habitacion)
);
