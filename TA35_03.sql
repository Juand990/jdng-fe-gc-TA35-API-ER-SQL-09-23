drop database GranAlmacen;
Create database GranAlmacen;
use GranAlmacen;

Create Table Cajeros(
Codigo Int AUTO_INCREMENT PRIMARY KEY,
NomApels Varchar(255) Not Null
);

Create Table Productos(
Codigo Int AUTO_INCREMENT PRIMARY KEY,
Nombre Varchar(100) Not Null,
Precio int
);

Create Table MaqRegistradoras(
Codigo Int AUTO_INCREMENT PRIMARY KEY,
Piso int
);

Create Table Venta(
CajeroId Int,
ProductosId Int,
MaquinaId Int,
PRIMARY KEY(CajeroId, ProductosId, MaquinaId),
FOREIGN KEY (CajeroId) REFERENCES Cajeros(Codigo) on delete cascade on update cascade,
FOREIGN KEY (ProductosId) REFERENCES Productos(Codigo) on delete cascade on update cascade,
FOREIGN KEY (MaquinaId) REFERENCES MaqRegistradoras(Codigo) on delete cascade on update cascade
);

Insert Into Cajeros(NomApels) 
Values ('pablo garcia');

Insert Into Productos( Nombre, Precio) 
Values ('pan',1);

Insert Into MaqRegistradoras(Piso) 
Values (1);

Insert Into Venta(CajeroId, ProductosId, MaquinaId) 
Values (1,1,1);