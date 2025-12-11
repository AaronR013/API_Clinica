CREATE DATABASE IF NOT EXISTS apiclinica;
USE apiclinica;

CREATE TABLE IF NOT EXISTS paciente (
  `Id` varchar(45) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Cedula` varchar(45) DEFAULT NULL,
  `Fecha_nacimiento` varchar(45) DEFAULT NULL,
  `Genero` varchar(45) DEFAULT NULL,
  `Direccion` varchar(45) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `Correo` varchar(45) DEFAULT NULL,
  `Estado_clinico` varchar(45) DEFAULT 'Activo',
  `Fecha_registro` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
);

CREATE TABLE IF NOT EXISTS medico (
  `Id` varchar(45) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Cedula_profesional` varchar(45) DEFAULT NULL,
  `Especialidad` varchar(45) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `Correo` varchar(45) DEFAULT NULL,
  `Horario_consulta` varchar(45) DEFAULT NULL,
  `Estado` varchar(45) DEFAULT 'Activo',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
);

CREATE TABLE IF NOT EXISTS cita (
  `Id` varchar(45) NOT NULL,
  `Id_paciente` varchar(45) DEFAULT NULL,
  `Id_medico` varchar(45) DEFAULT NULL,
  `Fecha` varchar(45) DEFAULT NULL,
  `Hora` varchar(45) DEFAULT NULL,
  `Especialidad` varchar(45) DEFAULT NULL,
  `Estado` varchar(45) DEFAULT 'Pendiente',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
);

CREATE TABLE IF NOT EXISTS historial (
  `Id` varchar(45) NOT NULL,
  `Id_paciente` varchar(45) DEFAULT NULL,
  `Id_medico` varchar(45) DEFAULT NULL,
  `Diagnostico` varchar(200) DEFAULT NULL,
  `Tratamiento` varchar(200) DEFAULT NULL,
  `Fecha_consulta` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
);

DROP PROCEDURE IF EXISTS obtenerTodosLosPacientes;
DROP PROCEDURE IF EXISTS insertPaciente;
DROP PROCEDURE IF EXISTS consultarPacientePorCedula;
DROP PROCEDURE IF EXISTS actualizarPacientePorId;
DROP PROCEDURE IF EXISTS inactivarPacientePorId;

DROP PROCEDURE IF EXISTS obtenerTodosLosMedicos;
DROP PROCEDURE IF EXISTS insertMedico;
DROP PROCEDURE IF EXISTS consultarMedicoPorId;
DROP PROCEDURE IF EXISTS actualizarMedicoPorId;
DROP PROCEDURE IF EXISTS inactivarMedicoPorId;

DROP PROCEDURE IF EXISTS obtenerTodosLasCitas;
DROP PROCEDURE IF EXISTS insertCita;
DROP PROCEDURE IF EXISTS consultarCitaPorId;
DROP PROCEDURE IF EXISTS actualizarCitaPorId;
DROP PROCEDURE IF EXISTS inactivarCitaPorId;

DROP PROCEDURE IF EXISTS obtenerTodosLosHistoriales;
DROP PROCEDURE IF EXISTS insertHistorial;
DROP PROCEDURE IF EXISTS consultarHistorialPorId;
DROP PROCEDURE IF EXISTS actualizarHistorialPorId;

-- PROCEDIMIENTOS PARA PACIENTE
CREATE PROCEDURE obtenerTodosLosPacientes()
BEGIN
    SELECT * FROM paciente WHERE Estado_clinico != 'Inactivo';
END;

CREATE PROCEDURE insertPaciente(
    IN Id VARCHAR(45),
    IN Nombre VARCHAR(45),
    IN Cedula VARCHAR(45),
    IN Fecha_nacimiento VARCHAR(45),
    IN Genero VARCHAR(45),
    IN Direccion VARCHAR(45),
    IN Telefono VARCHAR(45),
    IN Correo VARCHAR(45),
    IN Estado_clinico VARCHAR(45),
    IN Fecha_registro VARCHAR(45)
)
BEGIN 
    INSERT INTO paciente VALUES (Id, Nombre, Cedula, Fecha_nacimiento, Genero, 
            Direccion, Telefono, Correo, Estado_clinico, Fecha_registro);
END;

CREATE PROCEDURE consultarPacientePorCedula(IN p_cedula VARCHAR(45))
BEGIN
    SELECT * FROM paciente WHERE Cedula = p_cedula AND Estado_clinico != 'Inactivo';
END;

CREATE PROCEDURE actualizarPacientePorId(
    IN p_id VARCHAR(45),
    IN nombre VARCHAR(45),
    IN cedula VARCHAR(45),
    IN fecha_nacimiento VARCHAR(45),
    IN genero VARCHAR(45),
    IN direccion VARCHAR(45),
    IN telefono VARCHAR(45),
    IN correo VARCHAR(45),
    IN estado_clinico VARCHAR(45),
    IN fecha_registro VARCHAR(45)
)
BEGIN
    UPDATE paciente
    SET 
    Nombre = COALESCE(nombre, Nombre),
    Cedula = COALESCE(cedula, Cedula),
    Fecha_nacimiento = COALESCE(fecha_nacimiento, Fecha_nacimiento),
    Genero = COALESCE(genero, Genero),
    Direccion = COALESCE(direccion, Direccion),
    Telefono = COALESCE(telefono, Telefono),
    Correo = COALESCE(correo, Correo),
    Estado_clinico = COALESCE(estado_clinico, Estado_clinico),
    Fecha_registro = COALESCE(fecha_registro, Fecha_registro)
    WHERE Id = p_id;
END;

CREATE PROCEDURE inactivarPacientePorId(IN p_id VARCHAR(45))
BEGIN
    UPDATE paciente SET Estado_clinico = 'Inactivo' WHERE Id = p_id;
END;

-- PROCEDIMIENTOS PARA MÉDICO
CREATE PROCEDURE obtenerTodosLosMedicos()
BEGIN
    SELECT * FROM medico WHERE Estado != 'Inactivo';
END;

CREATE PROCEDURE insertMedico(
    IN Id VARCHAR(45),
    IN Nombre VARCHAR(45),
    IN Cedula_profesional VARCHAR(45),
    IN Especialidad VARCHAR(45),
    IN Telefono VARCHAR(45),
    IN Correo VARCHAR(45),
    IN Horario_consulta VARCHAR(45),
    IN Estado VARCHAR(45)
)
BEGIN 
    INSERT INTO medico VALUES (Id, Nombre, Cedula_profesional, Especialidad, Telefono, 
            Correo, Horario_consulta, Estado);
END;

CREATE PROCEDURE consultarMedicoPorId(IN p_id VARCHAR(45))
BEGIN
    SELECT * FROM medico WHERE Id = p_id AND Estado != 'Inactivo';
END;

CREATE PROCEDURE actualizarMedicoPorId(
    IN p_id VARCHAR(45),
    IN nombre VARCHAR(45),
    IN cedula_profesional VARCHAR(45),
    IN especialidad VARCHAR(45),
    IN telefono VARCHAR(45),
    IN correo VARCHAR(45),
    IN horario_consulta VARCHAR(45),
    IN estado VARCHAR(45)
)
BEGIN
    UPDATE medico
    SET 
    Nombre = COALESCE(nombre, Nombre),
    Cedula_profesional = COALESCE(cedula_profesional, Cedula_profesional),
    Especialidad = COALESCE(especialidad, Especialidad),
    Telefono = COALESCE(telefono, Telefono),
    Correo = COALESCE(correo, Correo),
    Horario_consulta = COALESCE(horario_consulta, Horario_consulta),
    Estado = COALESCE(estado, Estado)
    WHERE Id = p_id;
END;

CREATE PROCEDURE inactivarMedicoPorId(IN p_id VARCHAR(45))
BEGIN
    UPDATE medico SET Estado = 'Inactivo' WHERE Id = p_id;
END;

-- PROCEDIMIENTOS PARA CITA
CREATE PROCEDURE obtenerTodosLasCitas()
BEGIN
    SELECT * FROM cita;
END;

CREATE PROCEDURE insertCita(
    IN Id VARCHAR(45),
    IN Id_paciente VARCHAR(45),
    IN Id_medico VARCHAR(45),
    IN Fecha VARCHAR(45),
    IN Hora VARCHAR(45),
    IN Especialidad VARCHAR(45),
    IN Estado VARCHAR(45)
)
BEGIN 
    INSERT INTO cita VALUES (Id, Id_paciente, Id_medico, Fecha, Hora, Especialidad, Estado);
END;

CREATE PROCEDURE consultarCitaPorId(IN p_id VARCHAR(45))
BEGIN
    SELECT * FROM cita WHERE Id = p_id;
END;

CREATE PROCEDURE actualizarCitaPorId(
    IN p_id VARCHAR(45),
    IN id_paciente VARCHAR(45),
    IN id_medico VARCHAR(45),
    IN fecha VARCHAR(45),
    IN hora VARCHAR(45),
    IN especialidad VARCHAR(45),
    IN estado VARCHAR(45)
)
BEGIN
    UPDATE cita
    SET 
    Id_paciente = COALESCE(id_paciente, Id_paciente),
    Id_medico = COALESCE(id_medico, Id_medico),
    Fecha = COALESCE(fecha, Fecha),
    Hora = COALESCE(hora, Hora),
    Especialidad = COALESCE(especialidad, Especialidad),
    Estado = COALESCE(estado, Estado)
    WHERE Id = p_id;
END;

CREATE PROCEDURE inactivarCitaPorId(IN p_id VARCHAR(45))
BEGIN
    UPDATE cita SET Estado = 'Cancelada' WHERE Id = p_id;
END;

-- PROCEDIMIENTOS PARA HISTORIAL CLÍNICO
CREATE PROCEDURE obtenerTodosLosHistoriales()
BEGIN
    SELECT * FROM historial;
END;

CREATE PROCEDURE insertHistorial(
    IN Id VARCHAR(45),
    IN Id_paciente VARCHAR(45),
    IN Id_medico VARCHAR(45),
    IN Diagnostico VARCHAR(200),
    IN Tratamiento VARCHAR(200),
    IN Fecha_consulta VARCHAR(45)
)
BEGIN 
    INSERT INTO historial VALUES (Id, Id_paciente, Id_medico, Diagnostico, Tratamiento, 
    Fecha_consulta);
END;

CREATE PROCEDURE consultarHistorialPorId(IN p_id VARCHAR(45))
BEGIN
    SELECT * FROM historial WHERE Id = p_id;
END;

CREATE PROCEDURE actualizarHistorialPorId(
    IN p_id VARCHAR(45),
    IN id_paciente VARCHAR(45),
    IN id_medico VARCHAR(45),
    IN diagnostico VARCHAR(200),
    IN tratamiento VARCHAR(200),
    IN fecha_consulta VARCHAR(45)
)
BEGIN
    UPDATE historial
    SET 
    Id_paciente = COALESCE(id_paciente, Id_paciente),
    Id_medico = COALESCE(id_medico, Id_medico),
    Diagnostico = COALESCE(diagnostico, Diagnostico),
    Tratamiento = COALESCE(tratamiento, Tratamiento),
    Fecha_consulta = COALESCE(fecha_consulta, Fecha_consulta)
    WHERE Id = p_id;
END;