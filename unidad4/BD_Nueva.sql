CREATE DATABASE  IF NOT EXISTS `puntoventa`;
USE `puntoventa`;

DROP TABLE IF EXISTS `productos`;
DROP TABLE IF EXISTS `categorias`;
CREATE TABLE `categorias` (
  `id` 		int(11) 		NOT NULL 		AUTO_INCREMENT,
  `nombre` 	varchar(30) 	NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre` (`nombre`)
);

INSERT INTO `categorias` VALUES (5,'Abarrotes'),(3,'Bebidas'),(4,'Botanas'),(2,'Carnes Frías'),(1,'Lacteos');

select p.Id, p.nombre, p.existencia, p.precio, c.nombre as Categoria
from Productos p
join Categorias c on p.idCategoria=c.id 
order by p.nombre;

CREATE TABLE `empleados` (
`id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `apellidos` varchar(40) NOT NULL,
  `usuario` varchar(15) NOT NULL,
  `contrasenia` varchar(15) NOT NULL,
   `puesto` varchar(20) NOT NULL,
	PRIMARY KEY (`id`),
	UNIQUE KEY `usuario` (`usuario`)
);
UPDATE empleados SET nombre='Juanito', apellidos='Carmona', puesto='Almacenista' WHERE id=1;
select * from empleados; 

insert into empleados
values(1, 'Juan', 'Perez', 'admid', '123', 'administrador');
insert into empleados
values(2, 'Lorena', 'Dominguez', 'loredo', '456', 'cajero');
insert into empleados
values(default, 'Marlen', 'Alcaraz', 'Maral', '789', 'cajero');

CREATE TABLE `productos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `existencia` int(11) NOT NULL,
  `precio` decimal(5,2) NOT NULL,
  `idCategoria` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre` (`nombre`),
  KEY `idCategoria` (`idCategoria`),
  CONSTRAINT `fkCategoria` FOREIGN KEY (`idCategoria`) REFERENCES `categorias` (`id`)
);

drop table productos;

insert into productos
values(1, 'Chelas', 200, 20, 3);
insert into productos
values(2, 'Cigarros', 1000, 66, 5);
insert into productos
values(3, 'Chetos', 50, 10, 4);

select * from productos;
select id from categorias where nombre='Bebidas';

select puesto from empleados where usuario='Maral';

