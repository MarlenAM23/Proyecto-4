CREATE DATABASE  IF NOT EXISTS `puntoventa`;
USE `puntoventa`;

DROP TABLE IF EXISTS `productos`;
DROP TABLE IF EXISTS `categorias`;
CREATE TABLE `categorias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),employees
  UNIQUE KEY `nombre` (`nombre`)
);

INSERT INTO `categorias` VALUES (5,'Abarrotes'),(3,'Bebidas'),(4,'Botanas'),(2,'Carnes Frías'),(1,'Lacteos');

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
)