drop database PieProv;
Create database PieProv;
use PieProv;

Create Table Piezas(
Codigo Int AUTO_INCREMENT PRIMARY KEY,
Nombre Varchar(100) Not Null
);

Create Table Proveedores(
Id char(4) PRIMARY KEY,
Nombre Varchar(100) Not Null
);

Create Table Suministra(
CodigoPieza int,
IdProveedor char(4),
Precio int,
PRIMARY KEY(CodigoPieza, IdProveedor),
FOREIGN KEY (CodigoPieza) REFERENCES Piezas(Codigo) on delete cascade on update cascade,
FOREIGN KEY (IdProveedor) REFERENCES Proveedores(Id) on delete cascade on update cascade
);

Insert Into Piezas(Nombre) 
Values ('tornillo');

Insert Into Proveedores(Id, Nombre) 
Values ('aaaa','tgn');

Insert Into Suministra(CodigoPieza, IdProveedor, Precio) 
Values ('1','aaaa',25);



