drop database CientProy;
Create database CientProy;
use CientProy;

Create Table Cientificos(
DNI Varchar(8) PRIMARY KEY,
NomApels Varchar(255) Not Null
);

Create Table Proyecto(
Id char(4) PRIMARY KEY,
Nombre Varchar(255) Not Null,
Horas int Not Null
);

Create Table AsignadoA(
CientificoDni Varchar(8),
ProyectoId char(4),
PRIMARY KEY(CientificoDni, ProyectoId),
FOREIGN KEY (CientificoDni) REFERENCES Cientificos(DNI) on delete cascade on update cascade,
FOREIGN KEY (ProyectoId) REFERENCES Proyecto(Id) on delete cascade on update cascade
);

Insert Into Cientificos(DNI, NomApels) 
Values ('1234567a','pablo garcia');

Insert Into Proyecto(Id, Nombre, Horas) 
Values ('asdf','Proyecto 2000',1000);

Insert Into AsignadoA(CientificoDni, ProyectoId) 
Values ('1234567a','asdf');