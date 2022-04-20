create table tbl_Sufragantes (
Id bigint identity(1,1) not null,
Tipo_Identificacion int,
Identificacion nvarchar(50),
Nombres nvarchar(200),
Apellidos nvarchar(400),
FechaNacimiento date,
Sexo int,
CorreoElectronico nvarchar(200),
)

create table tbl_Candidatos (
Id bigint identity(1,1) not null,
Tipo_Identificacion int,
Identificacion nvarchar(50),
Nombres nvarchar(200),
Apellidos nvarchar(400),
FechaNacimiento date,
Foto int,
CorreoElectronico nvarchar(200),
Propuesta nvarchar(200),
DescripcionPropuesta nvarchar(500),
)

create table Tbl_Elecciones (
Id bigint identity(1,1) not null,
Titulo nvarchar(200),
DescripcionTitulo nvarchar(500),
orden int,
Estado int,
)

create table Tbl_EleccionesXSufragantes (
Id bigint identity(1,1) not null,
Id_Eleccion bigint, 
Id_Sufragante bigint,
Estado int,
)

ALTER TABLE Tbl_EleccionesXSufragantes
ADD FOREIGN KEY (Id_Eleccion) REFERENCES Tbl_Elecciones(Id);

ALTER TABLE Tbl_EleccionesXSufragantes
ADD FOREIGN KEY (Id_Sufragante) REFERENCES tbl_Sufragantes(Id);

create table Tbl_EleccionesXCandidato (
Id bigint identity(1,1) not null,
Id_Eleccion bigint, 
Id_Candidato bigint,
Estado int,
)

ALTER TABLE Tbl_EleccionesXCandidato
ADD FOREIGN KEY (Id_Eleccion) REFERENCES Tbl_Elecciones(Id);

ALTER TABLE Tbl_EleccionesXCandidato
ADD FOREIGN KEY (Id_Candidato) REFERENCES tbl_Candidatos(Id);

create table Tbl_Votacion (
Id bigint identity(1,1) not null,
Id_Eleccion bigint, 
Id_Candidato bigint,
Id_Sufragante bigint,
Salto int,
)

ALTER TABLE Tbl_Votacion
ADD FOREIGN KEY (Id_Eleccion) REFERENCES Tbl_Elecciones(Id);

ALTER TABLE Tbl_Votacion
ADD FOREIGN KEY (Id_Candidato) REFERENCES tbl_Candidatos(Id);

ALTER TABLE Tbl_Votacion
ADD FOREIGN KEY (Id_Sufragante) REFERENCES tbl_Sufragantes(Id);


Create table tbl_TipoIdentificacion(
id bigint identity(1,1) not null,
descripcion nvarchar(100),
Estado int)

Create table tbl_sexo(
id bigint identity(1,1) not null,
descripcion nvarchar(100),
Estado int)