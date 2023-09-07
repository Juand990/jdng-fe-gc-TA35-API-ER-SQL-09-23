drop database Inves;
Create database Inves;
use Inves;

Create Table Facultad(
Codigo Int AUTO_INCREMENT PRIMARY KEY,
Nombre Varchar(100) Not Null
);

Create Table Investigadores(
DNI Varchar(8) PRIMARY KEY,
NomApels Varchar(255) Not Null,
FacultadCod Int,
FOREIGN KEY (FacultadCod) REFERENCES Facultad(Codigo) on delete cascade on update cascade
);

Create Table Equipos(
NumSerie char(4) PRIMARY KEY,
Nombre Varchar(100) Not Null,
FacultadCod Int,
FOREIGN KEY (FacultadCod) REFERENCES Facultad(Codigo) on delete cascade on update cascade
);

Create Table Reserva(
DniInves Varchar(8),
NumSerieEq char(4),
Comienzo date,
Fin date,
PRIMARY KEY(DniInves, NumSerieEq),
FOREIGN KEY (DniInves) REFERENCES Investigadores(DNI) on delete cascade on update cascade,
FOREIGN KEY (NumSerieEq) REFERENCES Equipos(NumSerie) on delete cascade on update cascade
);

Insert Into Facultad(Nombre) 
Values ('pablo garcia');

Insert Into Investigadores(DNI, NomApels, FacultadCod) 
Values ('1234567a','pablo garcia',1);

Insert Into Equipos(NumSerie,Nombre,FacultadCod) 
Values ('1234','equipo 1',1);

Insert Into Reserva(DniInves, NumSerieEq, Comienzo,Fin) 
Values ('1234567a','1234','2023-01-01','2023-12-31');
