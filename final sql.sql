-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 03-07-2024 a las 22:17:26
-- Versión del servidor: 10.4.22-MariaDB
-- Versión de PHP: 8.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `final`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `ClienteId` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Direccion` varchar(255) DEFAULT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Email` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_pedido`
--

CREATE TABLE `detalle_pedido` (
  `Id` int(11) NOT NULL,
  `Id_pedido` int(11) DEFAULT NULL,
  `Id_Producto` int(11) DEFAULT NULL,
  `Cantidad_producto` int(11) DEFAULT NULL,
  `Subtotal` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `facturas`
--

CREATE TABLE `facturas` (
  `FacturaId` int(11) NOT NULL,
  `ClienteId` int(11) NOT NULL,
  `Fecha` date NOT NULL,
  `Monto` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedido_compra`
--

CREATE TABLE `pedido_compra` (
  `Id` int(11) NOT NULL,
  `Id_Proveedor` int(11) DEFAULT NULL,
  `Id_Sucursal` int(11) DEFAULT NULL,
  `Fecha_Hora` datetime DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(255) DEFAULT NULL,
  `Cantidad_minima` int(11) DEFAULT NULL,
  `Cantidad_stock` int(11) DEFAULT NULL,
  `Precio_compra` decimal(10,2) DEFAULT NULL,
  `Precio_venta` decimal(10,2) DEFAULT NULL,
  `Categoria` varchar(100) DEFAULT NULL,
  `Marca` varchar(100) DEFAULT NULL,
  `Estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`Id`, `Descripcion`, `Cantidad_minima`, `Cantidad_stock`, `Precio_compra`, `Precio_venta`, `Categoria`, `Marca`, `Estado`) VALUES
(1, 'Telefono', 10, NULL, '500.00', '700.00', 'electronica', 'Samsung', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE `proveedor` (
  `Id` int(11) NOT NULL,
  `RazonSocial` varchar(255) NOT NULL,
  `TipoDocumento` varchar(50) DEFAULT NULL,
  `NumeroDocumento` varchar(100) DEFAULT NULL,
  `Direccion` varchar(255) DEFAULT NULL,
  `Mail` varchar(100) DEFAULT NULL,
  `Celular` varchar(50) DEFAULT NULL,
  `Estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`Id`, `RazonSocial`, `TipoDocumento`, `NumeroDocumento`, `Direccion`, `Mail`, `Celular`, `Estado`) VALUES
(1, 'Alex s.a', 'RUC', '8.456.355-6', 'Asuncion, Barrio Santisima Trinidad', 'alex@gmail.com', '0987652341', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sucursal`
--

CREATE TABLE `sucursal` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(255) DEFAULT NULL,
  `Direccion` varchar(255) DEFAULT NULL,
  `Telefono` varchar(50) DEFAULT NULL,
  `Mail` varchar(100) DEFAULT NULL,
  `WhatsApp` varchar(50) DEFAULT NULL,
  `Estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`ClienteId`);

--
-- Indices de la tabla `detalle_pedido`
--
ALTER TABLE `detalle_pedido`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id_pedido` (`Id_pedido`),
  ADD KEY `Id_Producto` (`Id_Producto`);

--
-- Indices de la tabla `facturas`
--
ALTER TABLE `facturas`
  ADD PRIMARY KEY (`FacturaId`),
  ADD KEY `ClienteId` (`ClienteId`);

--
-- Indices de la tabla `pedido_compra`
--
ALTER TABLE `pedido_compra`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id_Proveedor` (`Id_Proveedor`),
  ADD KEY `Id_Sucursal` (`Id_Sucursal`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `sucursal`
--
ALTER TABLE `sucursal`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `clientes`
--
ALTER TABLE `clientes`
  MODIFY `ClienteId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalle_pedido`
--
ALTER TABLE `detalle_pedido`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `facturas`
--
ALTER TABLE `facturas`
  MODIFY `FacturaId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `pedido_compra`
--
ALTER TABLE `pedido_compra`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `sucursal`
--
ALTER TABLE `sucursal`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `detalle_pedido`
--
ALTER TABLE `detalle_pedido`
  ADD CONSTRAINT `detalle_pedido_ibfk_1` FOREIGN KEY (`Id_pedido`) REFERENCES `pedido_compra` (`Id`),
  ADD CONSTRAINT `detalle_pedido_ibfk_2` FOREIGN KEY (`Id_Producto`) REFERENCES `productos` (`Id`);

--
-- Filtros para la tabla `facturas`
--
ALTER TABLE `facturas`
  ADD CONSTRAINT `facturas_ibfk_1` FOREIGN KEY (`ClienteId`) REFERENCES `clientes` (`ClienteId`);

--
-- Filtros para la tabla `pedido_compra`
--
ALTER TABLE `pedido_compra`
  ADD CONSTRAINT `pedido_compra_ibfk_1` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id`),
  ADD CONSTRAINT `pedido_compra_ibfk_2` FOREIGN KEY (`Id_Sucursal`) REFERENCES `sucursal` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
