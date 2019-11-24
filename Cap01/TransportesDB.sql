USE master
GO

CREATE DATABASE [TransportesDB]
GO

USE [TransportesDB]
GO

CREATE TABLE Accesos
( 
	IdAcceso             int identity (1,1) primary key,
	Descripcion          varchar(255)  NULL ,
	ParentId             int  NULL ,
	[Level]              int  NULL ,
	[Order]              int  NULL ,
	Area                 varchar(50)  NULL ,
	[Action]             varchar(50) NULL ,
	Controller           varchar(50)  NULL ,
	QueryString          varchar(50)  NULL ,
	Icon                 varchar(50)  NULL ,
	Estado               char(1)  NULL 
)
go

CREATE TABLE Cliente
( 
	IdCliente            int identity (1,1) primary key,
	Razon                varchar(255)  NULL ,
	Documento            varchar(20)  NULL ,
	Contacto             varchar(50)  NULL ,
	Telefono             varchar(15)  NULL ,
	Celular              varchar(15)  NULL ,
	Email                varchar(50)  NULL ,
	Estado               char(1)  NULL ,
	IdUsuario            int,
	Tipo_Documento       int 
)
go

CREATE TABLE Comentarios
( 
	IdComentario         int identity (1,1) primary key ,
	Fecha                datetime,
	Comentario           varchar(255)  NULL ,
	IdCotizacion         int,
	Estado               char(1)  NULL 
)
go

CREATE TABLE Conductor
( 
	IdConductor          int identity (1,1) primary key ,
	Estado               char(1),
	IdVehiculo           int,
	Licencia             varchar(50)
)
go

CREATE TABLE Cotizacion
( 
	IdCotizacion         int identity (1,1) primary key ,
	Fecha                datetime,
	Estado               char(1),
	Numero               varchar(18) ,
	Costo_Total          decimal(8,2),
	IdCliente            int
)
go

CREATE TABLE Detalle_Asignacion
( 
	IdAsignacion         int identity (1,1) primary key ,
	IdConductor          int,
	IdDetalle            int,
	Estado               char(1)
)
go

CREATE TABLE Detalle_Cotizacion
( 
	IdDetalle            int identity (1,1) primary key ,
	IdCotizacion         int,
	IdItinerario         int,
	Fecha_Inicio         datetime,
	Fecha_Fin            datetime,
	Estado               char(1),
	Origen               varchar(255)  NULL ,
	Destino              varchar(255)  NULL ,
	Costo                decimal(8,2)
)
go


CREATE TABLE Itinerarios
( 
	IdItinerario         int identity (1,1) primary key ,
	Descripcion          varchar(255)  NULL ,
	Origen               varchar(255)  NULL ,
	Destino              varchar(255)  NULL ,
	Costo                decimal(8,2),
	Estado               char(1) 
)
go

CREATE TABLE Perfil
( 
	IdPerfil             int identity (1,1) primary key ,
	Descripcion          varchar(255),
	Estado               char(1) 
)
go

CREATE TABLE Permisos
( 
	IdPermiso            int identity (1,1) primary key ,
	IdAcceso             int,
	IdPerfil             int,
	IdUsuario            int
)
go


CREATE TABLE Usuario
( 
	IdUsuario            int identity (1,1) primary key ,
	Email                varchar(50)  NULL ,
	[Password]           varchar(max),
	Estado               char(1),
	Foto                 varchar(255),
	IdPerfil             int
)
go


CREATE TABLE Vehiculo
( 
	IdVehiculo           int identity (1,1) primary key ,
	Placa                varchar(255)  NULL ,
	Modelo               varchar(255)  NULL ,
	Capacidad            int,
	Estado               char(1),
	Marca                varchar(255)  NULL 
)
go


ALTER TABLE Cliente
	ADD CONSTRAINT R_9 FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Comentarios
	ADD CONSTRAINT R_4 FOREIGN KEY (IdCotizacion) REFERENCES Cotizacion(IdCotizacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Conductor
	ADD CONSTRAINT R_5 FOREIGN KEY (IdVehiculo) REFERENCES Vehiculo(IdVehiculo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Cotizacion
	ADD CONSTRAINT R_8 FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Detalle_Asignacion
	ADD CONSTRAINT R_6 FOREIGN KEY (IdConductor) REFERENCES Conductor(IdConductor)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Detalle_Asignacion
	ADD CONSTRAINT R_7 FOREIGN KEY (IdDetalle) REFERENCES Detalle_Cotizacion(IdDetalle)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Detalle_Cotizacion
	ADD CONSTRAINT R_1 FOREIGN KEY (IdCotizacion) REFERENCES Cotizacion(IdCotizacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Detalle_Cotizacion
	ADD CONSTRAINT R_3 FOREIGN KEY (IdItinerario) REFERENCES Itinerarios(IdItinerario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Permisos
	ADD CONSTRAINT R_11 FOREIGN KEY (IdAcceso) REFERENCES Accesos(IdAcceso)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Permisos
	ADD CONSTRAINT R_12 FOREIGN KEY (IdPerfil) REFERENCES Perfil(IdPerfil)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Permisos
	ADD CONSTRAINT R_13 FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Usuario
	ADD CONSTRAINT R_10 FOREIGN KEY (IdPerfil) REFERENCES Perfil(IdPerfil)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
