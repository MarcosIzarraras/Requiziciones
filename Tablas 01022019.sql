CREATE DATABASE Cotizaciones

CREATE TABLE Departamento
(
	dpto_id INT IDENTITY (1,1) PRIMARY KEY,
	dpto_nombre VARCHAR(100)
)

CREATE TABLE TipoUsuario
(
	tusu_id INT IDENTITY (1,1) PRIMARY KEY,
	tusu_nombre VARCHAR(50)
)

CREATE TABLE Usuario
(
	usu_id INT IDENTITY(1,1) PRIMARY KEY,
	usu_nombre VARCHAR(300),
	usu_apellido VARCHAR(300),
	usu_usuario VARCHAR(50) UNIQUE,
	usu_contrasenia VARCHAR(50),
	usu_numeroEmpleado INT,
	usu_tipoUsuario_id INT FOREIGN KEY REFERENCES TipoUsuario(tusu_id),
	usu_departamento_id INT FOREIGN KEY REFERENCES Departamento(dpto_id)
)

CREATE TABLE Estatus
(
	est_id INT IDENTITY (1,1) PRIMARY KEY,
	est_descripcion VARCHAR(150)
)

CREATE TABLE Solicitud
(
	sol_id INT IDENTITY (1,1) PRIMARY KEY,
	sol_fecha DATETIME,
	sol_tipoPedido VARCHAR(50),
	sol_cotizador_id INT FOREIGN KEY REFERENCES Usuario(usu_id),
	sol_solicitante_id INT FOREIGN KEY REFERENCES Usuario(usu_id),
	sol_estatus_id INT FOREIGN KEY REFERENCES Estatus(est_id)
)

CREATE TABLE DetalleSolicitud
(
	dsol_id INT IDENTITY (1,1) PRIMARY KEY,
	dsol_producto VARCHAR(150),
	dsol_cantidad DECIMAL(10, 4),
	dsol_rutaDibujo VARCHAR(300),
	dsol_modelo VARCHAR(300),
	dsol_descripcion VARCHAR(300),
	dsol_comentario VARCHAR(500),
	dsol_estacionTrabajo VARCHAR(200),
	dsol_urgente BIT,
	dsol_solicitud_id INT FOREIGN KEY REFERENCES Solicitud(sol_id)
)

CREATE TABLE Cotizacion
(
	cot_id INT IDENTITY (1,1) PRIMARY KEY,
	cot_fecha DATETIME,
	cot_tipoCambio VARCHAR(50),
	cot_proveedor VARCHAR(250),
	cot_contacto VARCHAR(250),
	cot_correo VARCHAR(250),
	cot_telefono VARCHAR(20),
	cot_urgente BIT,
	cot_total DECIMAL(10, 4),
	cot_comprador_id INT FOREIGN KEY REFERENCES Usuario(usu_id),
	cot_aprobacion1_id INT FOREIGN KEY REFERENCES Usuario(usu_id) NULL,
	cot_aprobacion2_id INT FOREIGN KEY REFERENCES Usuario(usu_id) NULL,
	cot_estatus_id INT FOREIGN KEY REFERENCES Estatus(est_id)
)

CREATE TABLE DetalleCotizacion
(
	dcot_id INT IDENTITY (1,1) PRIMARY KEY,
	dcot_cantidad DECIMAL(10, 4),
	dcot_rutaDibujo VARCHAR(300),
	dcot_modelo VARCHAR(300),
	dcot_descripcion VARCHAR(300),
	dcot_comentario VARCHAR(500),
	dcot_estacionTrabajo VARCHAR(200),
	dcot_precioUnitario DECIMAL(10, 4),
	dcot_subTotal DECIMAL(10, 4),
	dcot_cotizacion_id INT FOREIGN KEY REFERENCES Cotizacion(cot_id)
)