Module CrearBD

    'precios
    Public vartablaprecios As String = "CREATE TABLE IF NOT EXISTS `precios` (
                                  `Id` int(11) NOT NULL,
                                  `Codigo` varchar(20) DEFAULT '',
                                  `CodBarra` varchar(50) DEFAULT '',
                                  `Descripcion` varchar(255) DEFAULT '',
                                  `PrecioAnt` double DEFAULT '0',
                                  `Proveedor` varchar(255) DEFAULT ''
                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    'MARCAS
    Public vartablamarcas As String = "CREATE TABLE `marcas` (
                                          `Id` int(11) NOT NULL,
                                          `Nombre` varchar(100) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'nominas
    Public vartablanominass As String = "CREATE TABLE `nominas` (
                                          `Id` int(11) NOT NULL,
                                          `IdEmpleado` int(11) DEFAULT '0',
                                          `Nombre` varchar(255) DEFAULT '',
                                          `Area` varchar(70) DEFAULT '',
                                          `Puesto` varchar(70) DEFAULT '',
                                          `Sueldo` float DEFAULT '0',
                                          `Descuento` float DEFAULT '0',
                                          `Fecha` date DEFAULT NULL,
                                          `Horas` int(11) DEFAULT '0',
                                          `OtrosD` float DEFAULT '0',
                                          `OtrosP` float DEFAULT '0',
                                          `SueldoNeto` float DEFAULT '0',
                                          `Desde` date DEFAULT NULL,
                                          `Hasta` date DEFAULT NULL,
                                          `Usuario` varchar(70) DEFAULT NULL,
                                          `Corte` int(11) DEFAULT '0',
                                          `CorteU` int(10) UNSIGNED ZEROFILL DEFAULT '0000000000'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    'pedidosvendet
    Public vartablapedidosvendet As String = "CREATE TABLE `pedidosvendet` (
                                                                      `id` int(11) NOT NULL,
                                                                      `Folio` int(11) DEFAULT '0',
                                                                      `Codigo` varchar(50) DEFAULT '',
                                                                      `Nombre` varchar(255) DEFAULT '',
                                                                      `Unidad` varchar(50) DEFAULT '',
                                                                      `Cantidad` float DEFAULT '0',
                                                                      `CostoV` float DEFAULT '0',
                                                                      `Precio` float DEFAULT '0',
                                                                      `Total` float DEFAULT '0',
                                                                      `PrecioSIVA` float DEFAULT '0',
                                                                      `TotalSIVA` float DEFAULT '0',
                                                                      `Fecha` datetime DEFAULT NULL,
                                                                      `Usuario` varchar(50) DEFAULT '',
                                                                      `Depto` varchar(100) DEFAULT '',
                                                                      `Grupo` varchar(100) DEFAULT '',
                                                                      `CostVR` text,
                                                                      `Tipo` varchar(50) DEFAULT '',
                                                                      `Comisionista` varchar(100) DEFAULT '',
                                                                      `Descuento` float DEFAULT '0',
                                                                      `Descto` float DEFAULT '0',
                                                                      `Porc_Descuento` float DEFAULT '0',
                                                                      `Comentario` varchar(255) DEFAULT ''
                                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
                                                                    "

    Public vartablarangoprecios As String = "CREATE TABLE `precios_rango` (
                                                                      `id` int(11) NOT NULL,
                                                                      `Codigo` varchar(50) DEFAULT '',
                                                                      `Desde` float DEFAULT '0',
                                                                      `Precio` float DEFAULT '0',
                                                                      `Status` int(1) DEFAULT '0'
                                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1"
    'pedidosven
    Public vartablapedidosven As String = "CREATE TABLE `pedidosven` (
                                                      `Folio` int(11) NOT NULL,
                                                      `IdCliente` int(11) DEFAULT '0',
                                                      `Cliente` varchar(255) DEFAULT '',
                                                      `Direccion` varchar(255) NOT NULL DEFAULT '',
                                                      `Subtotal` float NOT NULL DEFAULT '0',
                                                      `IVA` float NOT NULL DEFAULT '0',
                                                      `Totales` float NOT NULL DEFAULT '0',
                                                      `ACuenta` float NOT NULL DEFAULT '0',
                                                      `Resta` float NOT NULL DEFAULT '0',
                                                      `Usuario` varchar(50) NOT NULL DEFAULT '',
                                                      `Fecha` date NOT NULL,
                                                      `Hora` time NOT NULL,
                                                      `Status` varchar(50) NOT NULL DEFAULT '',
                                                      `Tipo` varchar(50) NOT NULL DEFAULT '',
                                                      `Comentario` text NOT NULL,
                                                      `Formato` varchar(100) NOT NULL DEFAULT '',
                                                      `CargadoAndroid` int(11) NOT NULL DEFAULT '0',
                                                      `FolioAndroid` varchar(50) NOT NULL DEFAULT '',
                                                      `Descuento` float NOT NULL DEFAULT '0',
                                                      `FPago` date NOT NULL,
                                                      `PorcentajeDesc` float NOT NULL DEFAULT '0',
                                                      `MontoSinDesc` float NOT NULL DEFAULT '0',
                                                      `IP` varchar(250) NOT NULL DEFAULT '',
                                                      `Descto` float NOT NULL DEFAULT '0'
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
                                                    "

    'promos
    Public vartablapromos As String = "CREATE TABLE `promos` (
                                              `Id` int(11) NOT NULL,
                                              `Codigo` varchar(50) DEFAULT '',
                                              `Promo2x1` int(11) DEFAULT '0',
                                              `Lunes` int(11) DEFAULT '0',
                                              `Martes` int(11) DEFAULT '0',
                                              `Miercoles` int(11) DEFAULT '0',
                                              `Jueves` int(11) DEFAULT '0',
                                              `Viernes` int(11) DEFAULT '0',
                                              `Sabado` int(11) DEFAULT '0',
                                              `Domingo` int(11) DEFAULT '0',
                                              `HInicioL` varchar(50) DEFAULT '',
                                              `HFinL` varchar(50) DEFAULT '',
                                              `HInicioL2` varchar(50) DEFAULT '',
                                              `HFinL2` varchar(50) DEFAULT '',
                                              `HInicioM` varchar(50) DEFAULT '',
                                              `HFinM` varchar(50) DEFAULT '',
                                              `HinicioM2` varchar(50) DEFAULT '',
                                              `HFinM2` varchar(50) DEFAULT '',
                                              `HInicioMi` varchar(50) DEFAULT '',
                                              `HFinMi` varchar(50) DEFAULT '',
                                              `HinicioMi2` varchar(50) DEFAULT '',
                                              `HFinMi2` varchar(50) DEFAULT '',
                                              `HInicioJ` varchar(50) DEFAULT '',
                                              `HFinJ` varchar(50) DEFAULT '',
                                              `HInicioJ2` varchar(50) DEFAULT '',
                                              `HFinJ2` varchar(50) DEFAULT '',
                                              `HInicioV` varchar(50) DEFAULT '',
                                              `HFinV` varchar(50) DEFAULT '',
                                              `HInicioV2` varchar(50) DEFAULT '',
                                              `HFinV2` varchar(50) DEFAULT '',
                                              `HInicioS` varchar(50) DEFAULT '',
                                              `HFinS` varchar(50) DEFAULT '',
                                              `HInicioS2` varchar(50) DEFAULT '',
                                              `HFinS2` varchar(50) DEFAULT '',
                                              `HInicioD` varchar(50) DEFAULT '',
                                              `HFinD` varchar(50) DEFAULT '',
                                              `HInicioD2` varchar(50) DEFAULT '',
                                              `HFinD2` varchar(50) DEFAULT '',
                                              `Promo3x2` int(11) DEFAULT '0',
                                              `Lunes2` int(11) DEFAULT '0',
                                              `Martes2` int(11) DEFAULT '0',
                                              `Miercoles2` int(11) DEFAULT '0',
                                              `Jueves2` int(11) DEFAULT '0',
                                              `Viernes2` int(11) DEFAULT '0',
                                              `Sabado2` int(11) DEFAULT '0',
                                              `Domingo2` int(11) DEFAULT '0',
                                              `HInicioL3` varchar(50) DEFAULT '',
                                              `HFinL3` varchar(50) DEFAULT '',
                                              `HInicioL33` varchar(50) DEFAULT '',
                                              `HFinL33` varchar(50) DEFAULT '',
                                              `HInicioM3` varchar(50) DEFAULT '',
                                              `HFinM3` varchar(50) DEFAULT '',
                                              `HInicioM33` varchar(50) DEFAULT '',
                                              `HFinM33` varchar(50) DEFAULT '',
                                              `HInicioMi3` varchar(50) DEFAULT '',
                                              `HFinMi3` varchar(50) DEFAULT '',
                                              `HInicioMi33` varchar(50) DEFAULT '',
                                              `HFinMi33` varchar(50) DEFAULT '',
                                              `HInicioJ3` varchar(50) DEFAULT '',
                                              `HFinJ3` varchar(50) DEFAULT '',
                                              `HInicioJ33` varchar(50) DEFAULT '',
                                              `HFinJ33` varchar(50) DEFAULT '',
                                              `HInicioV3` varchar(50) DEFAULT '',
                                              `HFinV3` varchar(50) DEFAULT '',
                                              `HInicioV33` varchar(50) DEFAULT '',
                                              `HFinV33` varchar(50) DEFAULT '',
                                              `HInicioS3` varchar(50) DEFAULT '',
                                              `HFinS3` varchar(50) DEFAULT '',
                                              `HInicioS33` varchar(50) DEFAULT '',
                                              `HFinS33` varchar(50) DEFAULT '',
                                              `HInicioD3` varchar(50) DEFAULT '',
                                              `HFinD3` varchar(50) DEFAULT '',
                                              `HInicioD33` varchar(50) DEFAULT '',
                                              `HFinD33` varchar(50) DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    'clienteeliminado
    Public vartablaclienteeliminado As String = "CREATE TABLE `clienteeliminado` (
                                                  `Id` int(11) NOT NULL,
                                                  `Nombre` varchar(50) DEFAULT '',
                                                  `CargadoAndroid` int(11) DEFAULT '0'
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'productoeliminado
    Public vartablaproductoeliminado As String = "CREATE TABLE `productoeliminado` (
                                                  `Id` int(11) NOT NULL,
                                                  `Codigo` varchar(50) NOT NULL DEFAULT '',
                                                  `Nombre` varchar(255) NOT NULL DEFAULT '',
                                                  `CargadoAndroid` int(11) NOT NULL DEFAULT '0',
                                                  `Departamento` varchar(100) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'pedidostemporal
    Public vartablapedidostemporal As String = "CREATE TABLE `pedidostemporal` (
                                                  `Id` int(11) NOT NULL,
                                                  `IdNube` int(11) NOT NULL DEFAULT '0',
                                                  `IdPedido` int(11) NOT NULL DEFAULT '0',
                                                  `IdVenta` int(11) NOT NULL DEFAULT '0',
                                                  `Codigo` varchar(50) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                                  `Cantidad` float NOT NULL DEFAULT '0',
                                                  `Precio` float NOT NULL DEFAULT '0',
                                                  `FechaHora` varchar(50) NOT NULL DEFAULT '',
                                                  `Usuario` varchar(50) NOT NULL DEFAULT '',
                                                  `FVenta` varchar(50) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'pedidoseliminados

    Public vartablaPedidoEliminado As String = "CREATE TABLE `pedidoeliminado` (
                                                  `Id` int(11) NOT NULL,
                                                  `IdPedido` varchar(50) NOT NULL DEFAULT '',
                                                  `IdPedidoA` varchar(50) NOT NULL DEFAULT '',
                                                  `CargadoAndroid` int(11) NOT NULL DEFAULT '0'
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'detalle_nomina
    Public vartabladetallenomina As String = "CREATE TABLE `detalle_nomina` (
                                                  `Id_detalle` int(11) NOT NULL,
                                                  `id_empleado` int(11) DEFAULT '0',
                                                  `id_percepcion` varchar(50) DEFAULT '',
                                                  `id_deduccion` varchar(50) DEFAULT '',
                                                  `importe` float DEFAULT '0',
                                                  `id_nomina` int(11) DEFAULT '0',
                                                  `fecha` datetime DEFAULT NULL,
                                                  `gravado` varchar(100) DEFAULT '',
                                                  `exento` varchar(100) DEFAULT '',
                                                  `concepto` varchar(100) DEFAULT '',
                                                  `id_otropago` varchar(50) DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'tipoincapacidadsat
    Public vartablatipoincapacidadsat As String = "CREATE TABLE `tipoincapacidadsat` (
                                                      `Id` int(11) NOT NULL,
                                                      `TipoIncapacidad` varchar(10) NOT NULL DEFAULT '',
                                                      `Descripcion` varchar(50) NOT NULL DEFAULT ''
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertatipoincapacidadsat
    Public varinsertatipoincapacidadsat As String = "INSERT INTO `tipoincapacidadsat` (`Id`, `TipoIncapacidad`, `Descripcion`) VALUES
                                                        (1, '01', 'Riesgo de trabajo'),
                                                        (2, '02', 'Enfermedad en general'),
                                                        (3, '03', 'Maternidad');"

    'tiponomina
    Public vartablatiponomina As String = "CREATE TABLE `tiponomina` (
                                              `Id` int(11) NOT NULL,
                                              `clave` varchar(10) NOT NULL DEFAULT '',
                                              `descripcion` varchar(50) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertatiponomina
    Public varinsertatiponomina As String = "INSERT INTO `tiponomina` (`Id`, `clave`, `descripcion`) VALUES
                                                (1, 'E', 'Nómina extraordinaria'),
                                                (2, 'O', 'Nómina ordinaria');"

    'otrospagos
    Public vartablaotrospagos As String = "CREATE TABLE `otrospagos` (
                                              `Id` int(11) NOT NULL,
                                              `clave` varchar(10) DEFAULT '',
                                              `descripcion` varchar(255) DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertaotrospagos
    Public varinsertaotrospagos As String = "INSERT INTO `otrospagos` (`Id`, `clave`, `descripcion`) VALUES
                (1, '001', 'Reintegro de ISR pagado en exceso (siempre que no haya sido enterado al SAT).'),
                (2, '002', 'Subsidio para el empleo (efectivamente entregado al trabajador).'),
                (3, '003', 'Viáticos (entregados al trabajador).'),
                (4, '004', 'Aplicación de saldo a favor por compensación anual.'),
                (5, '005', 'Reintegro de ISR retenido en exceso de ejercicio anterior (siempre que no haya sido enterado al SAT).'),
                (6, '006', 'Alimentos en bienes (Servicios de comedor y comida) Art 94 último párrafo LISR.'),
                (7, '007', 'ISR ajustado por subsidio.'),
                (8, '008', 'Subsidio efectivamente entregado que no correspondía (Aplica sólo cuando haya ajuste al cierre de mes en relación con el Apéndice 7 de la guía de llenado de nómina).'),
                (9, '009', 'Reembolso de descuentos efectuados para el crédito de vivienda.'),
                (10, '999', 'Pagos distintos a los listados y que no deben considerarse como ingreso por sueldos, salarios o ingresos asimilados.');"
    'tipopercepcioncontable

    Public vartablatipopercepcioncontable As String = "CREATE TABLE `tipo_percepcion_contable` (
                                                          `Id` int(11) NOT NULL,
                                                          `atpc_id` varchar(10) DEFAULT '',
                                                          `atpc_descripcion` varchar(255) DEFAULT '',
                                                          `atpc_gravada` varchar(255) DEFAULT '',
                                                          `atpc_numerico1` int(11) DEFAULT '0',
                                                          `atpc_numerico2` int(11) DEFAULT '0',
                                                          `atpc_texto1` varchar(50) DEFAULT '',
                                                          `atpc_texto2` varchar(50) DEFAULT '',
                                                          `atpc_fecha` date DEFAULT NULL,
                                                          `atpc_hora` time DEFAULT NULL
                                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
"

    'insertvarinsertatipopercepcioncontable
    Public varinsertatipopercepcioncontable As String = "INSERT INTO `tipo_percepcion_contable` (`Id`, `atpc_id`, `atpc_descripcion`, `atpc_gravada`, `atpc_numerico1`, `atpc_numerico2`, `atpc_texto1`, `atpc_texto2`, `atpc_fecha`, `atpc_hora`) VALUES
                                    (1, '001', 'Sueldos, Salarios  Rayas y Jornales', '', 0, 0, '', '', NULL, NULL),
                                    (2, '002', 'Gratificación Anual (Aguinaldo)', '', 0, 0, '', '', NULL, NULL),
                                    (3, '003', 'Participación de los Trabajadores en las Utilidades PTU', '', 0, 0, '', '', NULL, NULL),
                                    (4, '004', 'Reembolso de Gastos Médicos Dentales y Hospitalarios', '', 0, 0, '', '', NULL, NULL),
                                    (5, '005', 'Fondo de Ahorro', '', 0, 0, '', '', NULL, NULL),
                                    (6, '006', 'Caja de ahorro', '', 0, 0, '', '', NULL, NULL),
                                    (7, '009', 'Contribuciones a Cargo del Trabajador Pagadas por el Patrón', '', 0, 0, '', '', NULL, NULL),
                                    (8, '010', 'Premios por puntualidad', '', 0, 0, '', '', NULL, NULL),
                                    (9, '011', 'Prima de Seguro de vida', '', 0, 0, '', '', NULL, NULL),
                                    (10, '012', 'Seguro de Gastos Médicos Mayores', '', 0, 0, '', '', NULL, NULL),
                                    (11, '013', 'Cuotas Sindicales Pagadas por el Patrón', '', 0, 0, '', '', NULL, NULL),
                                    (12, '014', 'Subsidios por incapacidad', '', 0, 0, '', '', NULL, NULL),
                                    (13, '015', 'Becas para trabajadores y/o hijos', '', 0, 0, '', '', NULL, NULL),
                                    (14, '019', 'Horas extra', '', 0, 0, '', '', NULL, NULL),
                                    (15, '020', 'Prima dominical', '', 0, 0, '', '', NULL, NULL),
                                    (16, '021', 'Prima vacacional', '', 0, 0, '', '', NULL, NULL),
                                    (17, '022', 'Prima por antigüedad', '', 0, 0, '', '', NULL, NULL),
                                    (18, '023', 'Pagos por separación', '', 0, 0, '', '', NULL, NULL),
                                    (19, '024', 'Seguro de retiro', '', 0, 0, '', '', NULL, NULL),
                                    (20, '025', 'Indemnizaciones', '', 0, 0, '', '', NULL, NULL),
                                    (21, '026', 'Reembolso por funeral', '', 0, 0, '', '', NULL, NULL),
                                    (22, '027', 'Cuotas de seguridad social pagadas por el patrón', '', 0, 0, '', '', NULL, NULL),
                                    (23, '028', 'Comisiones', '', 0, 0, '', '', NULL, NULL),
                                    (24, '029', 'Vales de despensa', '', 0, 0, '', '', NULL, NULL),
                                    (25, '030', 'Vales de restaurante', '', 0, 0, '', '', NULL, NULL),
                                    (26, '031', 'Vales de gasolina', '', 0, 0, '', '', NULL, NULL),
                                    (27, '032', 'Vales de ropa', '', 0, 0, '', '', NULL, NULL),
                                    (28, '033', 'Ayuda para renta', '', 0, 0, '', '', NULL, NULL),
                                    (29, '034', 'Ayuda para artículos escolares', '', 0, 0, '', '', NULL, NULL),
                                    (30, '035', 'Ayuda para anteojos', '', 0, 0, '', '', NULL, NULL),
                                    (31, '036', 'Ayuda para transporte', '', 0, 0, '', '', NULL, NULL),
                                    (32, '037', 'Ayuda para gastos de funeral', '', 0, 0, '', '', NULL, NULL),
                                    (33, '038', 'Otros ingresos por salarios', '', 0, 0, '', '', NULL, NULL),
                                    (34, '039', 'Jubilaciones, pensiones o haberes de retiro', '', 0, 0, '', '', NULL, NULL),
                                    (35, '044', 'Jubilaciones, pensiones o haberes de retiro en parcialidades', '', 0, 0, '', '', NULL, NULL),
                                    (36, '045', 'Ingresos en acciones o títulos valor que representan bienes', '', 0, 0, '', '', NULL, NULL),
                                    (37, '048', 'Habitación', '', 0, 0, '', '', NULL, NULL),
                                    (38, '049', 'Premios por asistencia', '', 0, 0, '', '', NULL, NULL),
                                    (39, '050', 'Viáticos', '', 0, 0, '', '', NULL, NULL);"

    'tipodeduccioncontable
    Public vartablatipodeduccioncontable As String = "CREATE TABLE `tipo_deduccion_contable` (
                                                      `Id` int(11) NOT NULL,
                                                      `atdc_id` varchar(10) DEFAULT NULL,
                                                      `atdc_descripcion` varchar(255) DEFAULT '',
                                                      `atdc_comentario` varchar(255) DEFAULT '',
                                                      `atdc_gravada` int(11) DEFAULT '0',
                                                      `atdc_numerico1` int(11) DEFAULT '0',
                                                      `atdc_numerico2` int(11) DEFAULT '0',
                                                      `atdc_texto1` varchar(255) DEFAULT 'X',
                                                      `atdc_texto2` varchar(255) DEFAULT 'X',
                                                      `atdc_fecha` date DEFAULT NULL,
                                                      `atdc_hora` time DEFAULT NULL
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertadeduccioncontable

    Public varinsertatipodeduccioncontable As String = "INSERT INTO `tipo_deduccion_contable` (`Id`, `atdc_id`, `atdc_descripcion`, `atdc_comentario`, `atdc_gravada`, `atdc_numerico1`, `atdc_numerico2`, `atdc_texto1`, `atdc_texto2`, `atdc_fecha`, `atdc_hora`) VALUES
                                        (1, '001', 'Seguridad social', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (2, '002', 'ISR', '', 0, 0, 0, '', '', '2014-01-01', '08:00:00'),
                                        (3, '003', 'Aportaciones a retiro, cesantía en edad avanzada y vejez.', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (4, '004', 'Otros', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (5, '005', 'Aportaciones a Fondo de vivienda', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (6, '006', 'Descuento por incapacidad', 'Sumatoria de los valores de los atributos Descuento del nodo Incapacidad', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (7, '007', 'Pensión alimenticia', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (8, '008', 'Renta', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (9, '009', 'Préstamos provenientes del Fondo Nacional de la Vivienda para los Trabajadores', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (10, '010', 'Pago por crédito de vivienda', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (11, '011', 'Pago de abonos INFONACOT', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (12, '012', 'Anticipo de salarios', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (13, '013', 'Pagos hechos con exceso al trabajador', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (14, '014', 'Errores', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (15, '015', 'Pérdidas', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (16, '016', 'Averías', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (17, '017', 'Adquisición de artículos producidos por la empresa o establecimiento', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (18, '018', 'Cuotas para la constitución y fomento de sociedades cooperativas y de cajas de ahorro', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (19, '019', 'Cuotas sindicales', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
                                        (20, '020', 'Ausencia (Ausentismo)', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00'),
        (21, '021', 'Cuotas obrero patronales', '', 0, 0, 0, 'X', 'X', '2014-01-01', '08:00:00');"

    'riesgopuesto
    Public vartablariesgopuesto As String = "CREATE TABLE `riesgo_puesto` (
                                                  `Id` int(11) NOT NULL,
                                                  `Rp_id` varchar(10) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertariesgopuesto
    Public varinsertariesgopuesto As String = "INSERT INTO `riesgo_puesto` (`Id`, `Rp_id`, `Descripcion`) VALUES
                                                    (1, '1', 'Clase I'),
                                                    (2, '2', 'Clase II'),
                                                    (3, '3', 'Clase III'),
                                                    (4, '4', 'Clase III'),
                                                    (5, '5', 'Clase V'),
                                                    (6, '99', 'No aplica');"

    'tipocontrato

    Public vartablatipocontrato As String = "CREATE TABLE `tipo_contrato` (
                                                  `Id` int(11) NOT NULL,
                                                  `Tc_id` varchar(10) NOT NULL DEFAULT '',
                                                  `Tc_nombre` varchar(100) NOT NULL DEFAULT '',
                                                  `Tc_numerico1` varchar(50) NOT NULL DEFAULT '',
                                                  `Tc_texto1` varchar(50) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertatipocontrato
    Public varinsertatipocontrato As String = "INSERT INTO `tipo_contrato` (`Id`, `Tc_id`, `Tc_nombre`, `Tc_numerico1`, `Tc_texto1`) VALUES
                                                    (1, '01', 'Contrato de trabajo por tiempo indeterminado', '', ''),
                                                    (2, '02', 'Contrato de trabajo para obra determinada', '', ''),
                                                    (3, '03', 'Contrato de trabajo por tiempo determinado', '', ''),
                                                    (4, '04', 'Contrato de trabajo por temporada', '', ''),
                                                    (5, '05', 'Contrato de trabajo sujeto a prueba', '', ''),
                                                    (6, '06', 'Contrato de trabajo con capacitación inicial', '', ''),
                                                    (7, '07', 'Modalidad de contratación por pago de hora laborada', '', ''),
                                                    (8, '08', 'Modalidad de trabajo por comisión laboral', '', ''),
                                                    (9, '09', 'Modalidades de contratación donde no existe relación de trabajo', '', ''),
                                                    (10, '10', 'Jubilación, pensión, retiro.', '', ''),
                                                    (11, '99', 'Otro contrato', '', '');"

    'tipo_pago
    Public vartablatipojornada As String = "CREATE TABLE `tipo_jornada` (
                                              `Id` int(11) NOT NULL,
                                              `Tj_id` varchar(10) NOT NULL DEFAULT '',
                                              `tj_nombre` varchar(100) NOT NULL DEFAULT '',
                                              `tj_numerico1` varchar(50) NOT NULL DEFAULT '',
                                              `tj_texto1` varchar(50) NOT NULL DEFAULT '',
                                              `Campo1` int(11) NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertatipojornada

    Public varinsertatipojornada As String = "INSERT INTO `tipo_jornada` (`Id`, `Tj_id`, `tj_nombre`, `tj_numerico1`, `tj_texto1`, `Campo1`) VALUES
                                                (1, '01', 'Diurna', '', '', 0),
                                                (2, '02', 'Nocturna', '', '', 0),
                                                (3, '03', 'Mixta', '', '', 0),
                                                (4, '04', 'Por hora', '', '', 0),
                                                (5, '05', 'Reducida', '', '', 0),
                                                (6, '06', 'Continuada', '', '', 0),
                                                (7, '07', 'Partida', '', '', 0),
                                                (8, '08', 'Por turnos', '', '', 0),
                                                (9, '99', 'Otra Jornada', '', '', 0);"

    'periodicidadpago

    Public vartablaperiodicidadpago As String = "CREATE TABLE `periodicidad_pago` (
                                                      `Id` int(11) NOT NULL,
                                                      `Pp_id` varchar(10) DEFAULT '',
                                                      `Pp_nombre` varchar(100) DEFAULT '',
                                                      `Pp_numerico1` varchar(100) DEFAULT '',
                                                      `pp_texto1` varchar(100) DEFAULT ''
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertaperiodicidadpago

    Public varinsertaperiodicidadpago As String = "INSERT INTO `periodicidad_pago` (`Id`, `Pp_id`, `Pp_nombre`, `Pp_numerico1`, `pp_texto1`) VALUES
                                                        (1, '01', 'Diario', '', ''),
                                                        (2, '02', 'Semanal', '', ''),
                                                        (3, '03', 'Catorcenal', '', ''),
                                                        (4, '04', 'Quincenal', '', ''),
                                                        (5, '05', 'Mensual', '', ''),
                                                        (6, '06', 'Bimestral', '', ''),
                                                        (7, '07', 'Unidad obra', '', ''),
                                                        (8, '08', 'Comisión', '', ''),
                                                        (9, '09', 'Precio alzado', '', ''),
                                                        (10, '10', 'Decenal', '', ''),
                                                        (11, '99', 'Otra Periodicidad', '', '');"

    'regimencontrataciontrabajador
    Public vartablaregimencontrataciontrabajador As String = "CREATE TABLE `regimen_contratacion_trabajador` (
                                                                  `Id` int(11) NOT NULL,
                                                                  `Cat_id` varchar(10) DEFAULT '',
                                                                  `Rct_id` varchar(10) DEFAULT '',
                                                                  `Rct_nombre` varchar(255) DEFAULT '',
                                                                  `Rct_descripcion` varchar(255) DEFAULT '',
                                                                  `Rct_numerico1` int(11) DEFAULT '0',
                                                                  `Rct_numerico2` int(11) DEFAULT '0',
                                                                  `Rct_texto1` varchar(50) DEFAULT '',
                                                                  `Rct_texto2` varchar(50) DEFAULT '',
                                                                  `Rct_fecha` datetime DEFAULT NULL,
                                                                  `Rct_Hora` datetime DEFAULT NULL
                                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'insertaregimencontrataciontrabajador 
    Public varinsertaregimencontrataciontrabajador As String = "INSERT INTO `regimen_contratacion_trabajador` (`Id`, `Cat_id`, `Rct_id`, `Rct_nombre`, `Rct_descripcion`, `Rct_numerico1`, `Rct_numerico2`, `Rct_texto1`, `Rct_texto2`, `Rct_fecha`, `Rct_Hora`) VALUES
            (1, '02', '02', 'Sueldos', 'Sueldos', 0, 0, '', '', NULL, NULL),
            (2, '03', '03', 'Jubilados', 'Jubilados', 0, 0, '', '', NULL, NULL),
            (3, '04', '04', 'Pensionados', 'Pensionados', 0, 0, '', '', NULL, NULL),
            (4, '05', '05', 'Asimilados Miembros Sociedades Cooperativas Produccion', 'Asimilados Miembros Sociedades Cooperativas Produccion', 0, 0, '', '', NULL, NULL),
            (5, '06', '06', 'Asimilados Integrantes Sociedades Asociaciones Civiles', 'Asimilados Integrantes Sociedades Asociaciones Civiles', 0, 0, '', '', NULL, NULL),
            (6, '07', '07', 'Asimilados Miembros consejos', 'Asimilados Miembros consejos', 0, 0, '', '', NULL, NULL),
            (7, '08', '08', 'Asimilados comisionistas', 'Asimilados comisionistas', 0, 0, '', '', NULL, NULL),
            (8, '09', '09', 'Asimilados Honorarios', 'Asimilados Honorarios', 0, 0, '', '', NULL, NULL),
            (9, '10', '10', 'Asimilados acciones', 'Asimilados acciones', 0, 0, '', '', NULL, NULL),
            (10, '11', '11', 'Asimilados otros', 'Asimilados otros', 0, 0, '', '', NULL, NULL),
            (11, '12', '12', 'Jubilados o Pensionados', 'Jubilados o Pensionados', 0, 0, '', '', NULL, NULL),
            (12, '13', '13', 'Indemnización o Separación', 'Indemnización o Separación', 0, 0, '', '', NULL, NULL),
            (13, '99', '99', 'Otro Regimen', 'Otro Regimen', 0, 0, '', '', NULL, NULL);"

    'habitacion
    Public vartablahabitacion As String = "CREATE TABLE `habitacion` (
                                              `IdHabitacion` int(11) NOT NULL,
                                              `N_Habitacion` varchar(50) DEFAULT '',
                                              `Ubicacion` varchar(255) DEFAULT '',
                                              `Tipo` varchar(255) DEFAULT '',
                                              `Estado` varchar(100) DEFAULT '',
                                              `Caracteristicas` varchar(255) DEFAULT '',
                                              `Tiempo` int(11) DEFAULT '0',
                                              `Horas` int(11) DEFAULT '0',
                                              `PrecioH` float DEFAULT '0',
                                              `PreDia` float DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    'detallehotelprecios
    Public vartabladetallehotelprecios As String = "CREATE TABLE `detallehotelprecios` (
                                                  `Id` int(11) NOT NULL,
                                                  `Nombre` varchar(100) DEFAULT '',
                                                  `Horas` float NOT NULL DEFAULT '0',
                                                  `Precio` float NOT NULL DEFAULT '0'
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'detallehotel
    Public vartabladetallehotel As String = "CREATE TABLE `detallehotel` (
                                              `Id` int(11) NOT NULL,
                                              `Habitacion` varchar(80) DEFAULT '',
                                              `Tipo` varchar(80) DEFAULT '',
                                              `Estado` varchar(80) DEFAULT '',
                                              `Horas` float DEFAULT '0',
                                              `Precio` float DEFAULT '0',
                                              `Cliente` varchar(255) DEFAULT '',
                                              `Telefono` varchar(12) DEFAULT '',
                                              `FEntrada` datetime DEFAULT NULL,
                                              `FSalida` date DEFAULT NULL,
                                              `Caracteristicas` varchar(255) DEFAULT '',
                                              `Status` varchar(255) DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'control-servicios-det
    Public vartablacontrolserviciosdet As String = "CREATE TABLE `control_servicios_det` (
                                                      `Id` int(11) NOT NULL,
                                                      `Id_cs` int(11) NOT NULL DEFAULT '0',
                                                      `Proceso` varchar(250) NOT NULL DEFAULT '',
                                                      `Entrega` date NOT NULL,
                                                      `Status` int(1) NOT NULL DEFAULT '0',
                                                      `Comentario` text NOT NULL,
                                                      `Entregado` date NOT NULL
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    'control-servicios
    Public vartablacontrolservicios As String = "CREATE TABLE `control_servicios` (
                                                  `Id` int(11) NOT NULL,
                                                  `Codigo` varchar(250) NOT NULL DEFAULT '',
                                                  `Nombre` varchar(250) NOT NULL DEFAULT '',
                                                  `Folio` int(11) NOT NULL DEFAULT '0',
                                                  `Encargado` varchar(100) NOT NULL DEFAULT '',
                                                  `Inicio` date NOT NULL,
                                                  `Termino` date NOT NULL,
                                                  `Status` int(1) NOT NULL DEFAULT '0',
                                                  `Comentario` text NOT NULL,
                                                  `Usuario` varchar(100) NOT NULL DEFAULT '',
                                                  `Entregado` date NOT NULL,
                                                  `ComentarioVen` varchar(255) DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'histaasigpc
    Public vartablahistasigpc As String = "CREATE TABLE `histasigpc` (
                                              `Id` int(11) NOT NULL,
                                              `Clave` varchar(80) DEFAULT '',
                                              `Nombre` varchar(100) DEFAULT '',
                                              `Tipo` varchar(80) DEFAULT '',
                                              `Procedencia` varchar(100) DEFAULT '',
                                              `NumHrs` float DEFAULT '0',
                                              `Total` float DEFAULT '0',
                                              `NumPC` int(11) DEFAULT '0',
                                              `HorEnt` varchar(50) DEFAULT '',
                                              `HorSal` datetime DEFAULT NULL,
                                              `Fecha` date DEFAULT NULL
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'repcomandas
    Public vartablarepcomandas As String = "CREATE TABLE `rep_comandas` (
                                              `IDC` int(11) NOT NULL,
                                              `Id` int(11) DEFAULT '0',
                                              `NMESA` varchar(50) DEFAULT '',
                                              `Codigo` varchar(20) DEFAULT '',
                                              `Nombre` varchar(70) DEFAULT '',
                                              `UVenta` varchar(20) DEFAULT '',
                                              `Cantidad` float DEFAULT '0',
                                              `CostVR` float DEFAULT '0',
                                              `CostVP` float DEFAULT '0',
                                              `CostVUE` float DEFAULT '0',
                                              `Precio` float DEFAULT '0',
                                              `Total` float DEFAULT '0',
                                              `PrecioSinIVA` float DEFAULT '0',
                                              `TotalSinIVA` float DEFAULT '0',
                                              `Fecha` date DEFAULT NULL,
                                              `Comisionista` varchar(50) DEFAULT '',
                                              `Facturado` int(11) DEFAULT '0',
                                              `Depto` varchar(50) DEFAULT '',
                                              `Grupo` varchar(70) DEFAULT '',
                                              `comensal` varchar(50) DEFAULT '',
                                              `Status` varchar(50) DEFAULT '',
                                              `Comentario` varchar(255) DEFAULT '',
                                              `GPrint` varchar(50) DEFAULT '',
                                              `CUsuario` varchar(50) DEFAULT '',
                                              `Total_comensales` varchar(50) DEFAULT '',
                                              `EstatusT` int(11) DEFAULT '0',
                                              `Hr` time DEFAULT NULL,
                                              `EntregaT` time DEFAULT NULL
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'refaccionaria
    Public vartablarefaccionaria As String = "CREATE TABLE `refaccionaria` (
                                              `Id` int(11) NOT NULL,
                                              `CodigoPro` varchar(50) DEFAULT '',
                                              `NumParte` varchar(50) DEFAULT '',
                                              `CodBarra` varchar(50) DEFAULT '',
                                              `Nombre` varchar(255) DEFAULT '',
                                              `Marca` varchar(50) DEFAULT '',
                                              `Modelo` varchar(100) DEFAULT '',
                                              `Medida` varchar(50) DEFAULT '',
                                              `Observaciones` varchar(255) DEFAULT '',
                                              `Ubicacion` varchar(50) DEFAULT '',
                                              `Servicio` varchar(80) DEFAULT '',
                                              `Ano` varchar(20) DEFAULT '',
                                              `Npiezas` varchar(20) DEFAULT '',
                                              `IdVehiculo` int(11) DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'vehiculo
    Public vartablavehiculo As String = "CREATE TABLE `vehiculo` (
                                          `IdVehiculo` int(11) NOT NULL,
                                          `Placa` varchar(20) DEFAULT '',
                                          `Descripcion` varchar(255) DEFAULT '',
                                          `Marca` varchar(80) DEFAULT '',
                                          `Submarca` varchar(80) DEFAULT '',
                                          `Modelo` varchar(50) DEFAULT '',
                                          `Cilindros` varchar(50) DEFAULT '',
                                          `Desplazamiento` varchar(50) DEFAULT '',
                                          `Version` varchar(50) DEFAULT '',
                                          `StatusT` int(11) DEFAULT '0',
                                          `Cliente` varchar(255) DEFAULT '',
                                          `NEconomico` varchar(100) DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public vartablavehiculo2 As String = "CREATE TABLE `vehiculo2` (
                                              `Id` int(11) NOT NULL,
                                              `Marca` varchar(70) DEFAULT '',
                                              `Modelo` varchar(150) DEFAULT '',
                                              `Ano` varchar(50) DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'comandasveh
    Public vartablacomandasveh As String = "CREATE TABLE `comandasveh` (
                              `Id` int(11) NOT NULL,
                              `IdVehiculo` int(11) DEFAULT '0',
                              `Vehiculo` varchar(150) DEFAULT '',
                              `Placa` varchar(50) DEFAULT '',
                              `Cliente` varchar(255) DEFAULT '',
                              `Codigo` varchar(50) DEFAULT '',
                              `Nombre` varchar(255) DEFAULT '',
                              `NParte` varchar(50) DEFAULT '',
                              `Marca` varchar(80) DEFAULT '',
                              `Precio` float DEFAULT '0',
                              `Fecha` date DEFAULT NULL
                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'preferencia


    'AbonoE
    Public vartablaabonoe As String = "CREATE TABLE IF NOT EXISTS `abonoe` (
                                          `Id` int(11) NOT NULL,
                                          `NumRemision` varchar(80) NOT NULL DEFAULT '',
                                          `NumFactura` varchar(80) NOT NULL DEFAULT '',
                                          `NumPedido` varchar(100) NOT NULL DEFAULT '',
                                          `IdProv` int(11) NOT NULL DEFAULT '0',
                                          `Proveedor` varchar(255) NOT NULL DEFAULT '',
                                          `Concepto` varchar(100) NOT NULL DEFAULT '',
                                          `Fecha` date NOT NULL,
                                          `Hora` time NOT NULL,
                                          `FechaCompleta` datetime NOT NULL,
                                          `Cargo` float NOT NULL DEFAULT '0',
                                          `Abono` float NOT NULL DEFAULT '0',
                                          `Saldo` float NOT NULL DEFAULT '0',
                                          `FormaPago` varchar(80) NOT NULL DEFAULT '',
                                          `Monto` double NOT NULL DEFAULT '0',
                                          `Efectivo` float NOT NULL DEFAULT '0',
                                          `Tarjeta` float NOT NULL DEFAULT '0',
                                          `Transfe` float NOT NULL DEFAULT '0',
                                          `Otro` float NOT NULL DEFAULT '0',
                                          `Banco` varchar(100) NOT NULL DEFAULT '',
                                          `Referencia` varchar(20) NOT NULL DEFAULT '',
                                          `Comentario` varchar(255) NOT NULL DEFAULT '',
                                          `CuentaRep` varchar(100) NOT NULL DEFAULT '',
                                          `BancoRep` varchar(100) NOT NULL DEFAULT '',
                                          `Usuario` varchar(100) NOT NULL DEFAULT '',
                                          `Corte` int(1) NOT NULL DEFAULT '0',
                                          `CorteU` int(1) NOT NULL DEFAULT '0',
                                          `Cargado` int(1) NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'AbonoI
    Public vartablaabonoi As String = "CREATE TABLE IF NOT EXISTS `abonoi` (
                                      `Id` int(11) NOT NULL,
                                      `NumFolio` int(11) NOT NULL DEFAULT '0',
                                      `IdCliente` int(11) NOT NULL DEFAULT '0',
                                      `Cliente` varchar(250) NOT NULL DEFAULT '',
                                      `Concepto` varchar(100) NOT NULL DEFAULT '',
                                      `Fecha` date NOT NULL,
                                      `Hora` time NOT NULL,
                                      `FechaCompleta` datetime NOT NULL,
                                      `Cargo` float NOT NULL DEFAULT '0',
                                      `Abono` float NOT NULL DEFAULT '0',
                                      `Saldo` float NOT NULL DEFAULT '0',
                                      `FormaPago` varchar(250) NOT NULL DEFAULT '',
                                      `Monto` float NOT NULL DEFAULT '0',                                      
                                      `Banco` varchar(100) NOT NULL DEFAULT '',
                                      `Referencia` varchar(50) NOT NULL DEFAULT '',                                      
                                      `Usuario` varchar(100) NOT NULL DEFAULT '',
                                      `Corte` int(1) NOT NULL DEFAULT '0',
                                      `CorteU` int(1) NOT NULL DEFAULT '0',
                                      `Cargado` int(1) NOT NULL DEFAULT '0',
                                      `MontoSF` float NOT NULL DEFAULT '0',
                                      `CargadoAndroid` int(1) NOT NULL DEFAULT '0',
                                      `FolioAndroid` varchar(100) NOT NULL DEFAULT '',
                                      `Comentario` text NOT NULL,
                                      `CuentaC` varchar(250) NOT NULL DEFAULT '',
                                      `BRecepcion` varchar(250) NOT NULL DEFAULT '',
                                      `Propina` float NOT NULL DEFAULT '0',
                                      `Comisiones` float NOT NULL DEFAULT '0',
                                      `Mesero` varchar(100) NOT NULL DEFAULT '',
                                      `Descuento` float NOT NULL DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Acreedores
    Public vartablaAcreedores As String = "CREATE TABLE IF NOT EXISTS `acreedores` (
                                      `IdAcreedor` int(11) NOT NULL,
                                      `Nombre` varchar(255) NOT NULL DEFAULT '',
                                      `RazonS` varchar(255) NOT NULL DEFAULT '',
                                      `RFC` varchar(50) NOT NULL DEFAULT '',
                                      `Calle` varchar(250) NOT NULL DEFAULT '',
                                      `Colonia` varchar(250) NOT NULL DEFAULT '',
                                      `CP` varchar(20) NOT NULL DEFAULT '',
                                      `Delegacion` varchar(250) NOT NULL DEFAULT '',
                                      `Entidad` varchar(250) NOT NULL DEFAULT '',
                                      `Telefono` varchar(20) NOT NULL DEFAULT '',
                                      `Correo` varchar(150) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Alumnos
    Public vartablalumnos As String = "CREATE TABLE `alumnos` (
                                      `Id` int(11) NOT NULL,
                                      `Nombre` varchar(250) DEFAULT '',
                                      `Matricula` varchar(100) DEFAULT '',
                                      `Telefono` varchar(150) DEFAULT '',
                                      `Tutor` varchar(250) DEFAULT '',
                                      `Contacto` varchar(150) DEFAULT '',
                                      `Calle` varchar(250) DEFAULT '',
                                      `N_Int` varchar(100) DEFAULT '',
                                      `N_Ext` varchar(100) DEFAULT '',
                                      `Colonia` varchar(250) DEFAULT '',
                                      `CP` varchar(20) DEFAULT '',
                                      `Delegacion` varchar(250) DEFAULT '',
                                      `Estado` varchar(250) DEFAULT '',
                                      `Id_Grupo` int(11) DEFAULT '0',
                                      `Grupo` varchar(250) DEFAULT '', 
                                      `Lunes` int(11) DEFAULT '0', `Martes` int(11) DEFAULT '0', `Miercoles` int(11) DEFAULT '0', `Jueves` int(11) DEFAULT '0', `Viernes` int(11) DEFAULT '0', `Sabado` int(11) DEFAULT '0', `Domingo` int(11) DEFAULT '0',
                                      `Inscripcion` DATE NOT NULL,
                                      `F_Nacimiento` DATE NOT NULL,
                                      `F_Inicio` DATE NOT NULL,
                                      `Comentario` text NOT NULL,
                                      `Curso` varchar(255) NOT NULL DEFAULT '',
                                      `Baja` varchar(20) NOT NULL DEFAULT '',
                                      `Status` INT(1) NOT NULL DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'AsigPC
    Public vartablaasigpc As String = "CREATE TABLE `asigpc` (
                                          `Id` int(11) NOT NULL,
                                          `Clave` varchar(50) DEFAULT '',
                                          `Nombre` varchar(255) DEFAULT '',
                                          `Tipo` varchar(80) DEFAULT '',
                                          `Procedencia` varchar(80) DEFAULT '',
                                          `Carrera` varchar(80) DEFAULT '',
                                          `Semestre` varchar(80) DEFAULT '',
                                          `NumPC` int(11) DEFAULT '0',
                                          `HorEnt` datetime DEFAULT NULL,
                                          `HorSal` time DEFAULT NULL,
                                          `Fecha` date DEFAULT NULL,
                                          `Resta` float DEFAULT '0',
                                          `TotPagar` float DEFAULT '0',
                                          `Ocupada` int(11) DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Asistencia
    Public vartablaasistencia As String = "CREATE TABLE IF NOT EXISTS `asistencia` (
                                      `Id` int(11) NOT NULL,
                                      `NumEmp` int(11) NOT NULL DEFAULT '0',
                                      `Nombre` varchar(250) NOT NULL DEFAULT '0',
                                      `Hora` time NOT NULL,
                                      `Fecha` date NOT NULL,
                                      `Estatus` varchar(50) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public vartablaasistenciagym As String = "CREATE TABLE IF NOT EXISTS `asistenciagym` (
                                      `Id` int(11) NOT NULL,
                                      `NumEmp` int(11) NOT NULL DEFAULT '0',
                                      `Nombre` varchar(250) NOT NULL DEFAULT '0',
                                      `Hora` time NOT NULL,
                                      `Fecha` date NOT NULL,
                                      `Estatus` varchar(50) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Auditoria
    Public vartablaauditoria As String = "CREATE TABLE IF NOT EXISTS `auditoria` (
                                      `Id` int(11) NOT NULL,
                                      `Movimiento` varchar(250) NOT NULL DEFAULT '',
                                      `Usuario` varchar(50) NOT NULL DEFAULT '',
                                      `Formulario` varchar(100) NOT NULL DEFAULT '',
                                      `Concepto` text NOT NULL,
                                      `Fecha` date NOT NULL,
                                      `Hora` time NOT NULL
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'AuxCompras
    Public vartablaauxcompras As String = "CREATE TABLE IF NOT EXISTS `auxcompras` (
                                      `Id` int(11) NOT NULL,
                                      `Rem` varchar(80) NOT NULL DEFAULT '',
                                      `Fac` varchar(80) NOT NULL DEFAULT '',
                                      `Ped` varchar(80) NOT NULL DEFAULT '',
                                      `Proveedor` varchar(250) NOT NULL DEFAULT '',
                                      `Codigo` varchar(50) NOT NULL DEFAULT '',
                                      `Nombre` varchar(250) NOT NULL DEFAULT '',
                                      `Unidad` varchar(30) NOT NULL DEFAULT '',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `Precio` float NOT NULL DEFAULT '0',
                                      `Total` float NOT NULL DEFAULT '0',
                                      `Caducidad` varchar(50) NOT NULL DEFAULT '',
                                      `Lote` varchar(50) NOT NULL DEFAULT '',
                                      `CP` varchar(50) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'AuxComprasSeries
    Public vartablaauxcomprasseries As String = "CREATE TABLE IF NOT EXISTS `auxcomprasseries` (
                                      `Id` int(11) NOT NULL,
                                      `Rem` varchar(80) NOT NULL DEFAULT '',
                                      `Fac` varchar(80) NOT NULL DEFAULT '',
                                      `Ped` varchar(80) NOT NULL DEFAULT '',
                                      `Proveedor` varchar(250) NOT NULL DEFAULT '',
                                      `Codigo` varchar(50) NOT NULL DEFAULT '',
                                      `Nombre` varchar(250) NOT NULL DEFAULT '',
                                      `Unidad` varchar(30) NOT NULL DEFAULT '',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `Precio` float NOT NULL DEFAULT '0',
                                      `Total` float NOT NULL DEFAULT '0',
                                      `CP` int(1) NOT NULL DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'AuxPedidos
    Public vartablaauxpedidos As String = "CREATE TABLE IF NOT EXISTS `auxpedidos` (
                                      `Id` int(11) NOT NULL,
                                      `Num` varchar(80) NOT NULL DEFAULT '',
                                      `Proveedor` varchar(250) NOT NULL DEFAULT '',
                                      `Total` float NOT NULL DEFAULT '0',
                                      `Codigo` varchar(50) NOT NULL DEFAULT '',
                                      `Nombre` varchar(250) NOT NULL DEFAULT '',
                                      `Unidad` varchar(30) NOT NULL DEFAULT '',
                                      `Precio` float NOT NULL DEFAULT '0',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `Existencia` float NOT NULL DEFAULT '0',
                                      `Minimo` float NOT NULL DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Bancos
    Public vartablabancos As String = "CREATE TABLE IF NOT EXISTS `bancos` (
                                      `Banco` varchar(90) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertabancos As String = "INSERT INTO `bancos` (`Banco`) VALUES
                                        ('BBVA'),
                                        ('HSBC'),
                                        ('AZTECA'),
                                        ('COOPEL'),
                                        ('SCOTIABANCK'),
                                        ('SANTANDER');"



    'Cardex
    Public vartablacardex As String = "CREATE TABLE IF NOT EXISTS `cardex` (
                                      `Id` int(11) NOT NULL,
                                      `Codigo` varchar(50) NOT NULL DEFAULT '',
                                      `Nombre` varchar(255) NOT NULL DEFAULT '',
                                      `Movimiento` varchar(70) NOT NULL DEFAULT '',
                                      `Inicial` float NOT NULL DEFAULT '0',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `Final` float NOT NULL DEFAULT '0',
                                      `Precio` float NOT NULL DEFAULT '0',
                                      `Fecha` datetime NOT NULL,
                                      `Usuario` varchar(50) NOT NULL DEFAULT '',
                                      `Folio` varchar(50) NOT NULL DEFAULT '',
                                      `Tipo` varchar(100) NOT NULL DEFAULT '',
                                      `Cedula` varchar(70) NOT NULL DEFAULT '',
                                      `Receta` varchar(50) NOT NULL DEFAULT '',
                                      `Medico` varchar(200) NOT NULL DEFAULT '',
                                      `Domicilio` text NOT NULL
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CargosAbonos
    Public vartablacargosabonos As String = "CREATE TABLE IF NOT EXISTS `cargosabonos` (
                                      `Nombre` varchar(200) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CartaPorte
    Public vartablacartaporte As String = "CREATE TABLE IF NOT EXISTS `cartaporte` (
                                      `Id` int(11) NOT NULL,
                                      `FolioCarta` int(11) NOT NULL DEFAULT '0',
                                      `EmiNombre` varchar(255) NOT NULL DEFAULT '',
                                      `EmiRFC` varchar(255) NOT NULL DEFAULT '',
                                      `EmiCP` varchar(10) NOT NULL DEFAULT '',
                                      `EmiRegFis` varchar(255) NOT NULL DEFAULT '',
                                      `CliRFC` varchar(50) NOT NULL DEFAULT '',
                                      `CliNombre` varchar(255) NOT NULL DEFAULT '',
                                      `Inter` varchar(255) NOT NULL DEFAULT '',
                                      `OrigNombre` varchar(255) NOT NULL DEFAULT '',
                                      `OrigRFC` varchar(50) NOT NULL DEFAULT '',
                                      `OrigFechaHora` datetime NOT NULL,
                                      `OrigCP` varchar(20) NOT NULL DEFAULT '',
                                      `OrigCalle` varchar(255) NOT NULL DEFAULT '',
                                      `OrigNumExt` varchar(20) NOT NULL DEFAULT '',
                                      `OrigNumInt` varchar(20) NOT NULL DEFAULT '',
                                      `OrigColonia` varchar(255) NOT NULL DEFAULT '',
                                      `OrigEdo` varchar(100) NOT NULL DEFAULT '',
                                      `OrigMun` varchar(100) NOT NULL DEFAULT '',
                                      `TotalDistancia` varchar(100) NOT NULL DEFAULT '',
                                      `DesNombre` varchar(255) NOT NULL DEFAULT '',
                                      `DesRFC` varchar(50) NOT NULL DEFAULT '',
                                      `DesFechaHora` datetime NOT NULL,
                                      `DesCP` varchar(20) NOT NULL DEFAULT '',
                                      `DesPais` varchar(100) NOT NULL DEFAULT '',
                                      `DesCalle` varchar(255) NOT NULL DEFAULT '',
                                      `DesNumExt` varchar(20) NOT NULL DEFAULT '',
                                      `DesNumInt` varchar(20) NOT NULL DEFAULT '',
                                      `DesCol` varchar(255) NOT NULL DEFAULT '',
                                      `DesEdo` varchar(100) NOT NULL DEFAULT '',
                                      `DesMun` varchar(100) NOT NULL DEFAULT '',
                                      `PermisoSCT` varchar(255) NOT NULL DEFAULT '',
                                      `NumPoliza` varchar(255) NOT NULL DEFAULT '',
                                      `NumPermisoSCT` varchar(255) NOT NULL DEFAULT '',
                                      `Aseguradora` varchar(255) NOT NULL DEFAULT '',
                                      `Placa` varchar(50) NOT NULL DEFAULT '',
                                      `Config` varchar(255) NOT NULL DEFAULT '',
                                      `ModeloA` varchar(255) NOT NULL DEFAULT '',
                                      `OpeRFC` varchar(50) NOT NULL DEFAULT '',
                                      `OpeLic` varchar(50) NOT NULL DEFAULT '',
                                      `OpeNombre` varchar(255) NOT NULL DEFAULT '',
                                      `OpeNumExt` varchar(50) NOT NULL DEFAULT '',
                                      `OpeNumInt` varchar(50) NOT NULL DEFAULT '',
                                      `OpeMun` varchar(255) NOT NULL DEFAULT '',
                                      `OpeEdo` varchar(100) NOT NULL DEFAULT '',
                                      `OpeColonia` varchar(100) NOT NULL DEFAULT '',
                                      `OpeCP` varchar(20) NOT NULL DEFAULT '',
                                      `OpeCalle` varchar(100) NOT NULL DEFAULT '',
                                      `TotalMercancias` varchar(150) NOT NULL DEFAULT '',
                                      `Certificado` text NOT NULL,
                                      `UUID` varchar(255) NOT NULL DEFAULT '',
                                      `Sello` text NOT NULL,
                                      `NoCert` varchar(255) NOT NULL DEFAULT '',
                                      `SelloCFD` text NOT NULL,
                                      `NoCertSat` varchar(255) NOT NULL DEFAULT '',
                                      `SelloSat` text NOT NULL,
                                      `FechaTimbrado` date NOT NULL,
                                      `CadenaOriginal` text NOT NULL,
                                      `Estatus` int(11) NOT NULL DEFAULT '0',
                                      `FechaEmi` date NOT NULL,
                                      `OrigColoniaT` varchar(150) NOT NULL DEFAULT '',
                                      `OrigEdoT` varchar(100) NOT NULL DEFAULT '',
                                      `OrigMunT` varchar(100) NOT NULL DEFAULT '',
                                      `DesColT` varchar(100) NOT NULL DEFAULT '',
                                      `DesEdoT` varchar(100) NOT NULL DEFAULT '',
                                      `DesMunT` varchar(100) NOT NULL DEFAULT '',
                                      `OpeColoniaT` varchar(100) NOT NULL DEFAULT '',
                                      `OpeEdoT` varchar(100) NOT NULL DEFAULT '',
                                      `OpeMunT` varchar(100) NOT NULL DEFAULT '',
                                      `TotalPesoM` varchar(100) NOT NULL DEFAULT '',
                                      `DesLocalidad` varchar(100) NOT NULL DEFAULT '',
                                      `TransDEs` varchar(100) NOT NULL DEFAULT '',
                                      `TransImporte` varchar(100) NOT NULL DEFAULT '',
                                      `TransUniMedSat` varchar(255) NOT NULL DEFAULT '',
                                      `TransClaveSat` varchar(255) NOT NULL DEFAULT '',
                                      `NumPed` varchar(255) NOT NULL DEFAULT '',
                                      `FiguraTransporte` varchar(255) NOT NULL DEFAULT '',
                                      `AseguradoraMedAmb` varchar(255) NOT NULL DEFAULT '',
                                      `NumPolizaMedAmb` varchar(255) NOT NULL DEFAULT '',
                                      `PesoBrutoVehicular` varchar(100) NOT NULL DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CartaPorteDet
    Public vartablacartaportedet As String = "CREATE TABLE IF NOT EXISTS `cartaportedet` (
                                      `Id` int(11) NOT NULL,
                                      `IdCarta` int(11) NOT NULL DEFAULT '0',
                                      `FolioCarta` int(11) NOT NULL DEFAULT '0',
                                      `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                      `UniMedSAT` varchar(255) NOT NULL DEFAULT '',
                                      `ProdServSAT` varchar(255) NOT NULL DEFAULT '',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `ValorM` varchar(255) NOT NULL DEFAULT '',
                                      `PesoKg` varchar(255) NOT NULL DEFAULT '',
                                      `NumPed` varchar(255) NOT NULL DEFAULT '',
                                      `UUIDComE` varchar(255) NOT NULL DEFAULT '',
                                      `FracArancelaria` varchar(255) NOT NULL DEFAULT '',
                                      `MatPel` varchar(255) NOT NULL DEFAULT '',
                                      `ClaveMatPel` varchar(255) NOT NULL DEFAULT '',
                                      `DescMatPel` varchar(255) NOT NULL DEFAULT '',
                                      `Embalaje` varchar(255) NOT NULL DEFAULT '',
                                      `ClaveEmbalaje` varchar(255) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CartaPorteDetI
    Public vartablacartaportedeti As String = "CREATE TABLE IF NOT EXISTS `cartaportedeti` (
                                      `Id` int(11) NOT NULL,
                                      `IdCarta` int(11) NOT NULL DEFAULT '0',
                                      `FolioCarta` int(11) NOT NULL DEFAULT '0',
                                      `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                      `UniMedSAT` varchar(255) NOT NULL DEFAULT '',
                                      `ProdServSAT` varchar(255) NOT NULL DEFAULT '',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `ValorM` varchar(255) NOT NULL DEFAULT '',
                                      `PesoKg` varchar(255) NOT NULL DEFAULT '',
                                      `NumPed` varchar(255) NOT NULL DEFAULT '',
                                      `UUIDComE` varchar(255) NOT NULL DEFAULT '',
                                      `FracArancelaria` varchar(255) NOT NULL DEFAULT '',
                                      `MatPel` varchar(255) NOT NULL DEFAULT '',
                                      `ClaveMatPel` varchar(255) NOT NULL DEFAULT '',
                                      `DescMatPel` varchar(255) NOT NULL DEFAULT '',
                                      `Embalaje` varchar(255) NOT NULL DEFAULT '',
                                      `ClaveEmbalaje` varchar(255) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CartaPorteI
    Public vartablacartaportei As String = "CREATE TABLE IF NOT EXISTS `cartaportei` (
                                      `Id` int(11) NOT NULL,
                                      `FolioCarta` int(11) NOT NULL DEFAULT '0',
                                      `Inter` varchar(255) NOT NULL DEFAULT '',
                                      `OrigNombre` varchar(255) NOT NULL DEFAULT '',
                                      `OrigRFC` varchar(255) NOT NULL DEFAULT '',
                                      `OrigFechaHora` datetime NOT NULL,
                                      `OrigCP` varchar(255) NOT NULL DEFAULT '',
                                      `OrigCalle` varchar(255) NOT NULL DEFAULT '',
                                      `OrigNumExt` varchar(255) NOT NULL DEFAULT '',
                                      `OrigNumInt` varchar(255) NOT NULL DEFAULT '',
                                      `OrigColonia` varchar(255) NOT NULL DEFAULT '',
                                      `OrigEdo` varchar(255) NOT NULL DEFAULT '',
                                      `OrigMun` varchar(255) NOT NULL DEFAULT '',
                                      `TotalDistancia` varchar(255) NOT NULL DEFAULT '',
                                      `DesNombre` varchar(255) NOT NULL DEFAULT '',
                                      `DesRFC` varchar(20) NOT NULL DEFAULT '',
                                      `DesFechaHora` datetime NOT NULL,
                                      `DesCP` varchar(255) NOT NULL DEFAULT '',
                                      `DesPais` varchar(100) NOT NULL DEFAULT '',
                                      `DesCalle` varchar(100) NOT NULL DEFAULT '',
                                      `DesNumExt` varchar(100) NOT NULL DEFAULT '',
                                      `DesNumInt` varchar(255) NOT NULL DEFAULT '',
                                      `DesCol` varchar(255) NOT NULL DEFAULT '',
                                      `DesEdo` varchar(255) NOT NULL DEFAULT '',
                                      `DesMun` varchar(200) NOT NULL DEFAULT '',
                                      `PermisoSCTn` varchar(100) NOT NULL DEFAULT '',
                                      `NumPoliza` varchar(255) NOT NULL DEFAULT '',
                                      `NumPermisoSCT` varchar(200) NOT NULL DEFAULT '',
                                      `Aseguradora` varchar(200) NOT NULL DEFAULT '',
                                      `Placa` varchar(255) NOT NULL DEFAULT '',
                                      `Config` varchar(100) NOT NULL DEFAULT '',
                                      `ModeloA` varchar(100) NOT NULL DEFAULT '',
                                      `OpeRFC` varchar(255) NOT NULL DEFAULT '',
                                      `OpeLic` varchar(255) NOT NULL DEFAULT '',
                                      `OpeNombre` varchar(255) NOT NULL DEFAULT '',
                                      `OpeNumExt` varchar(255) NOT NULL DEFAULT '',
                                      `OpeNumInt` varchar(50) NOT NULL DEFAULT '',
                                      `OpeMun` varchar(255) NOT NULL DEFAULT '',
                                      `OpeEdo` varchar(255) NOT NULL DEFAULT '',
                                      `OpeColonia` varchar(50) NOT NULL DEFAULT '',
                                      `OpeCP` varchar(50) NOT NULL DEFAULT '',
                                      `OpeCalle` varchar(255) NOT NULL DEFAULT '',
                                      `TotalMercancias` varchar(50) NOT NULL DEFAULT '',
                                      `Estatus` int(11) NOT NULL DEFAULT '0',
                                      `OrigColoniaT` varchar(255) NOT NULL DEFAULT '',
                                      `OrigEdoT` varchar(100) NOT NULL DEFAULT '',
                                      `OrigMunT` varchar(100) NOT NULL DEFAULT '',
                                      `DesColT` varchar(20) NOT NULL DEFAULT '',
                                      `DesEdoT` varchar(100) NOT NULL DEFAULT '',
                                      `DesMunT` varchar(150) NOT NULL DEFAULT '',
                                      `OpeColoniaT` varchar(255) NOT NULL DEFAULT '',
                                      `OpeEdoT` varchar(255) NOT NULL DEFAULT '',
                                      `OpeMunT` varchar(255) NOT NULL DEFAULT '',
                                      `TotalPesoM` varchar(255) NOT NULL DEFAULT '',
                                      `DesLocalidad` varchar(255) NOT NULL DEFAULT '',
                                      `TransDes` varchar(255) NOT NULL DEFAULT '',
                                      `TransImporte` varchar(255) NOT NULL DEFAULT '',
                                      `TransUniMedSat` varchar(255) NOT NULL DEFAULT '',
                                      `TransClaveSat` varchar(255) NOT NULL DEFAULT '',
                                      `NumPed` varchar(255) NOT NULL DEFAULT '',
                                      `FiguraTransporte` varchar(255) NOT NULL DEFAULT '',
                                      `AseguradoraMedAmb` varchar(150) NOT NULL DEFAULT '',
                                      `NumPolizaMedAmb` varchar(100) NOT NULL DEFAULT '',
                                      `PesoBrutoVehicular` varchar(100) NOT NULL DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Clientes
    Public vartablaclientes As String = "CREATE TABLE  `clientes` (
                                      `Id` int(11) NOT NULL,
                                      `Nombre` varchar(255) NOT NULL DEFAULT '',
                                      `RazonSocial` varchar(255) NOT NULL DEFAULT '',
                                      `Tipo` varchar(100) NOT NULL DEFAULT '',
                                      `RFC` varchar(50) NOT NULL DEFAULT '',
                                      `Telefono` varchar(100) NOT NULL DEFAULT '',
                                      `Correo` varchar(100) NOT NULL DEFAULT '',
                                      `Credito` float NOT NULL DEFAULT '0',
                                      `DiasCred` float NOT NULL DEFAULT '0',
                                      `Comisionista` varchar(255) NOT NULL DEFAULT '',
                                      `Suspender` int(1) NOT NULL DEFAULT '0',
                                      `Calle` varchar(255) NOT NULL DEFAULT '',
                                      `Colonia` varchar(250) NOT NULL DEFAULT '',
                                      `CP` varchar(50) NOT NULL DEFAULT '',
                                      `Delegacion` varchar(250) NOT NULL DEFAULT '',
                                      `Entidad` varchar(100) NOT NULL DEFAULT '',
                                      `Pais` varchar(100) NOT NULL DEFAULT '',
                                      `RegFis` varchar(255) NOT NULL DEFAULT '',
                                      `NInterior` varchar(50) NOT NULL DEFAULT '',
                                      `NExterior` varchar(50) NOT NULL DEFAULT '',
                                      `CargadoAndroid` int(1) NOT NULL DEFAULT '0',
                                      `Cargado` int(1) NOT NULL DEFAULT '0',
                                      `Template` longtext NOT NULL DEFAULT '',
                                      `FingerIndex` varchar(250) NOT NULL DEFAULT '',
                                      `SaldoFavor` float NOT NULL DEFAULT '0',
                                      `Observaciones` varchar(150) NOT NULL DEFAULT '',
                                      `Id_Tienda` int(11) NOT NULL DEFAULT '0',
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Comanda1
    Public vartablacomandas1 As String = "CREATE TABLE `comanda1` (
                                              `Id` int(11) NOT NULL,
                                              `Folio` int(11) DEFAULT '0',
                                              `IdCliente` int(11) DEFAULT '0',
                                              `Nombre` varchar(255) DEFAULT '',
                                              `Direccion` varchar(150) DEFAULT '',
                                              `Subtotal` float DEFAULT '0',
                                              `IVA` float DEFAULT '0',
                                              `Totales` float DEFAULT '0',
                                              `Descuento` float DEFAULT '0',
                                              `Devolucion` float DEFAULT '0',
                                              `ACuenta` float DEFAULT '0',
                                              `Resta` float DEFAULT '0',
                                              `Usuario` varchar(50) DEFAULT '',
                                              `FVenta` date DEFAULT NULL,
                                              `HVenta` datetime DEFAULT NULL,
                                              `FPago` date DEFAULT NULL,
                                              `FCancelado` date DEFAULT NULL,
                                              `MontoEfecCanc` float DEFAULT '0',
                                              `Status` varchar(50) DEFAULT '',
                                              `Comisionista` varchar(50) DEFAULT '',
                                              `Facturado` int(11) DEFAULT '0',
                                              `TComensales` int(11) DEFAULT '0',
                                              `Domi` int(11) DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Comandas
    Public vartablacomandas As String = "CREATE TABLE `comandas` (
                                          `IDC` int(11) NOT NULL,
                                          `Id` int(11) DEFAULT '0',
                                          `Nmesa` varchar(80) DEFAULT '',
                                          `Codigo` varchar(10) DEFAULT '',
                                          `Nombre` varchar(255) DEFAULT '',
                                          `UVenta` varchar(20) DEFAULT '',
                                          `Cantidad` float DEFAULT '0',
                                          `CostVR` float DEFAULT '0',
                                          `CostVP` float DEFAULT '0',
                                          `CostVUE` float DEFAULT '0',
                                          `Descuento` float DEFAULT '0',
                                          `Precio` float DEFAULT '0',
                                          `Total` float DEFAULT '0',
                                          `PrecioSinIVA` float DEFAULT '0',
                                          `TotalSinIVA` float DEFAULT '0',
                                          `Fecha` date DEFAULT NULL,
                                          `Comisionista` varchar(50) DEFAULT '',
                                          `Facturado` int(11) DEFAULT '0',
                                          `Depto` varchar(80) DEFAULT '',
                                          `Grupo` varchar(80) DEFAULT '',
                                          `Comensal` varchar(50) DEFAULT '',
                                          `Status` varchar(50) DEFAULT '',
                                          `Comentario` varchar(255) DEFAULT '',
                                          `GPrint` varchar(50) DEFAULT '',
                                          `CUsuario` varchar(50) DEFAULT '',
                                          `Total_comensales` varchar(50) DEFAULT '',
                                          `EstatusT` int(11) DEFAULT '0',
                                          `Hr` time DEFAULT NULL,
                                          `EntregaT` time DEFAULT NULL,
                                          `Estado` int(11) DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Compras
    Public vartablacompras As String = "CREATE TABLE IF NOT EXISTS `compras` (
                                      `Id` int(11) NOT NULL,
                                      `NumRemision` varchar(80) NOT NULL DEFAULT '',
                                      `NumFactura` varchar(80) NOT NULL DEFAULT '',
                                      `NumPedido` varchar(80) NOT NULL DEFAULT '',
                                      `NotaCred` varchar(80) NOT NULL DEFAULT '',
                                      `IdProv` int(11) NOT NULL DEFAULT '0',
                                      `Proveedor` varchar(250) NOT NULL DEFAULT '',
                                      `Sub1` float NOT NULL DEFAULT '0',
                                      `Desc1` float NOT NULL DEFAULT '0',
                                      `Sub2` float NOT NULL DEFAULT '0',
                                      `IVA` float NOT NULL DEFAULT '0',
                                      `Total` float NOT NULL DEFAULT '0',
                                      `Desc2` float NOT NULL DEFAULT '0',
                                      `IEPS` float NOT NULL DEFAULT '0',
                                      `Pagar` float NOT NULL DEFAULT '0',
                                      `ACuenta` float NOT NULL DEFAULT '0',
                                      `Anticipo` float NOT NULL DEFAULT '0',
                                      `Resta` float NOT NULL DEFAULT '0',
                                      `FechaC` datetime NOT NULL,
                                      `FechaP` date NOT NULL,
                                      `FechaNC` varchar(80) NOT NULL DEFAULT '',
                                      `Status` varchar(90) NOT NULL DEFAULT '',
                                      `FechaCancela` varchar(80) NOT NULL DEFAULT '',
                                      `Usuario` varchar(80) NOT NULL DEFAULT '',
                                      `Corte` int(1) NOT NULL DEFAULT '0',
                                      `CorteU` int(1) NOT NULL DEFAULT '0',
                                      `Cargado` int(1) NOT NULL DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'ComprasDet
    Public vartablacomprasdet As String = "CREATE TABLE IF NOT EXISTS `comprasdet` (
                                      `Id` int(11) NOT NULL,
                                      `Id_Compra` int(11) NOT NULL DEFAULT '0',
                                      `NumRemision` varchar(80) NOT NULL DEFAULT '',
                                      `NumFactura` varchar(80) NOT NULL DEFAULT '',
                                      `Proveedor` varchar(250) NOT NULL DEFAULT '',
                                      `Codigo` varchar(50) NOT NULL DEFAULT '',
                                      `Nombre` varchar(250) NOT NULL DEFAULT '',
                                      `UCompra` varchar(50) NOT NULL DEFAULT '',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `Precio` float NOT NULL DEFAULT '0',
                                      `Total` float NOT NULL DEFAULT '0',
                                      `FechaC` datetime NOT NULL,
                                      `Grupo` varchar(150) NOT NULL DEFAULT '',
                                      `Depto` varchar(150) NOT NULL DEFAULT '',
                                      `Caducidad` varchar(50) NOT NULL DEFAULT '',
                                      `Lote` varchar(100) NOT NULL DEFAULT '',
                                      `FolioRep` int(11) NOT NULL DEFAULT '0',
                                      `NotaCred` varchar(80) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CorteCaja
    Public vartablacortecaja As String = "CREATE TABLE IF NOT EXISTS `cortecaja` (
                                          `Id` int(11) NOT NULL,
                                          `NumCorte` int(11) NOT NULL DEFAULT '0',
                                          `Saldo_Ini` float NOT NULL DEFAULT '0',
                                          `Fecha` date NOT NULL,
                                          `Saldo_Fin` float NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CorteUsuario
    Public vartablacorteusuario As String = "CREATE TABLE IF NOT EXISTS `corteusuario` (
                                              `Id` int(11) NOT NULL,
                                              `NumCorte` int(11) NOT NULL DEFAULT '0',
                                              `Saldo_Ini` float NOT NULL DEFAULT '0',
                                              `Calculo` float NOT NULL DEFAULT '0',
                                              `Diferencia` float NOT NULL DEFAULT '0',
                                              `Saldo_Fin` float NOT NULL DEFAULT '0',
                                              `Usuario` varchar(250) NOT NULL DEFAULT '',
                                              `Fecha` datetime NOT NULL
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Costeo
    Public vartablapeps As String = "CREATE TABLE IF NOT EXISTS `costeo` (
                                          `Id` int(11) NOT NULL,
                                          `Fecha` date NOT NULL,
                                          `Hora` time(2) NOT NULL,
                                          `Concepto` varchar(255) NOT NULL DEFAULT '',
                                          `Referencia` varchar(50) NOT NULL DEFAULT '',
                                          `Codigo` varchar(50) NOT NULL DEFAULT '',
                                          `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                          `Unidad` varchar(20) NOT NULL DEFAULT '',
                                          `Entrada` float NOT NULL DEFAULT '0',
                                          `Salida` float NOT NULL DEFAULT '0',
                                          `Saldo` float NOT NULL DEFAULT '0',
                                          `Costo` float NOT NULL DEFAULT '0',
                                          `Precio` float NOT NULL DEFAULT '0',
                                          `Utilidad` float NOT NULL DEFAULT '0',
                                          `Usuario` varchar(50) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CotPed
    Public vartablacotped As String = "CREATE TABLE IF NOT EXISTS `cotped` (
                                              `Folio` int(11) NOT NULL,
                                              `IdCliente` int(11) NOT NULL DEFAULT '0',
                                              `Cliente` varchar(250) NOT NULL DEFAULT '',
                                              `Direccion` varchar(250) NOT NULL DEFAULT '',
                                              `Subtotal` float NOT NULL DEFAULT '0',
                                              `IVA` float NOT NULL DEFAULT '0',
                                              `Totales` float NOT NULL DEFAULT '0',
                                              `ACuenta` float NOT NULL DEFAULT '0',
                                              `Resta` float NOT NULL DEFAULT '0',
                                              `Usuario` varchar(50) NOT NULL DEFAULT '',
                                              `Fecha` date NOT NULL,
                                              `Hora` time NOT NULL,
                                              `Status` varchar(50) NOT NULL DEFAULT '',
                                              `Tipo` varchar(50) NOT NULL DEFAULT '',
                                              `Comentario` text NOT NULL,
                                              `IP` varchar(255) DEFAULT NULL,
                                              `MontoSinDesc` float NOT NULL DEFAULT '0',
                                              `Descto` float NOT NULL DEFAULT '0',
                                              `FPago` date NOT NULL,
                                              `Descuento` float NOT NULL DEFAULT '0',
                                              `Formato` varchar(100) NOT NULL DEFAULT '',
                                              `CargadoAndroid` int(1) NOT NULL DEFAULT '0',
                                              `FolioAndroid` varchar(50) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CotPedDet
    Public vartablaccotpeddet As String = "CREATE TABLE IF NOT EXISTS `cotpeddet` (
                                          `Id` int(11) NOT NULL,
                                          `Folio` int(11) NOT NULL DEFAULT '0',
                                          `Codigo` varchar(50) NOT NULL DEFAULT '',
                                          `Nombre` varchar(255) NOT NULL DEFAULT '',
                                          `Cantidad` float NOT NULL DEFAULT '0',
                                          `Unidad` varchar(50) NOT NULL DEFAULT '',
                                          `CostoV` float NOT NULL DEFAULT '0',
                                          `Precio` float NOT NULL DEFAULT '0',
                                          `Total` float NOT NULL DEFAULT '0',
                                          `PrecioSIVA` float NOT NULL DEFAULT '0',
                                          `TotalSIVA` float NOT NULL DEFAULT '0',
                                          `Fecha` datetime NOT NULL,
                                          `Usuario` varchar(50) NOT NULL DEFAULT '',
                                          `Depto` varchar(100) NOT NULL DEFAULT '',
                                          `Grupo` varchar(100) NOT NULL DEFAULT '',
                                          `CostVR` text NOT NULL,
                                          `Tipo` varchar(50) NOT NULL DEFAULT '',
                                          `Comisionista` varchar(100) NOT NULL DEFAULT '',
                                          `Descuento` float NOT NULL DEFAULT '0',
                                          `Descto` float NOT NULL DEFAULT '0',
                                          `Porc_Descuento` float NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CtMedicos
    Public vartablactmedicos As String = "CREATE TABLE IF NOT EXISTS `ctmedicos` (
                                              `Id` int(11) NOT NULL,
                                              `Cedula` varchar(80) NOT NULL DEFAULT '',
                                              `Nombre` varchar(255) NOT NULL DEFAULT '',
                                              `Domicilio` text NOT NULL
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'CuentasBancarias
    Public vartablacuentasbancarias As String = "CREATE TABLE `cuentasbancarias` (
                                            `Id` int(11) NOT NULL,
                                            `CuentaBan` varchar(50) DEFAULT '',
                                             `Banco` varchar(80) DEFAULT '',
                                            `Titular` varchar(100) DEFAULT ''
                                         ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'DatosNegocio
    Public vartabladatosnegocio As String = "CREATE TABLE IF NOT EXISTS `datosnegocio` (
                                          `Emisor_id` int(11) NOT NULL,
                                          `Em_RazonSocial` varchar(255) NOT NULL DEFAULT '',
                                          `Em_NombreNegocio` varchar(255) NOT NULL DEFAULT '',
                                          `Em_rfc` varchar(50) NOT NULL DEFAULT '',
                                          `Emp_curp` varchar(50) NOT NULL DEFAULT '',
                                          `Em_mail` varchar(100) NOT NULL DEFAULT '',
                                          `Em_usuario` varchar(50) NOT NULL DEFAULT '',
                                          `Em_calle` varchar(150) NOT NULL DEFAULT '',
                                          `Em_NumExterior` varchar(20) NOT NULL DEFAULT '',
                                          `Em_NumInterior` varchar(20) NOT NULL DEFAULT '',
                                          `Em_colonia` varchar(100) NOT NULL DEFAULT '',
                                          `Em_Municipio` varchar(100) NOT NULL DEFAULT '',
                                          `Em_Estado` varchar(100) NOT NULL DEFAULT '',
                                          `Em_Pais` varchar(50) NOT NULL DEFAULT '',
                                          `Em_CP` varchar(20) NOT NULL DEFAULT '',
                                          `Em_Tipo` varchar(255) NOT NULL DEFAULT '',
                                          `Em_Posicion` int(11) NOT NULL DEFAULT '0',
                                          `Em_Tel` varchar(50) NOT NULL DEFAULT '',
                                          `Em_Expedir` varchar(50) NOT NULL DEFAULT '',
                                          `Em_RFiscal` int(11) NOT NULL DEFAULT '0',
                                          `Em_Actividad` text NOT NULL,
                                          `emi_logo` varchar(255) NOT NULL DEFAULT '',  
                                          `CargadoAndroid` int(1) NOT NULL DEFAULT '0',
                                          `emi_folio_inicial` varchar(255) NOT NULL DEFAULT '',
                                          `Emi_cer` varchar(255) NOT NULL DEFAULT '',
                                          `Emi_key` varchar(255) NOT NULL DEFAULT '',
                                          `Emi_pfx` varchar(50) NOT NULL DEFAULT '',
                                          `Emi_psw` varchar(150) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public vartabladatosprosepago As String = "CREATE TABLE IF NOT EXISTS `datosprosepago` (
                                          `Id` int(11) NOT NULL,
                                          `Terminal` varchar(255) NOT NULL DEFAULT '',
                                          `Clave` varchar(255) NOT NULL DEFAULT '',
                                          `Solicitud` varchar(50) NOT NULL DEFAULT '',
                                          `Resultado` varchar(50) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'detalle_factura
    Public vartabladdetalle_factura As String = "CREATE TABLE IF NOT EXISTS `detalle_factura` (
                                              `id_prod` varchar(255) NOT NULL DEFAULT '',
                                              `descripcion` varchar(255) NOT NULL DEFAULT '',
                                              `unidad` varchar(50) NOT NULL DEFAULT '',
                                              `cantidad` double NOT NULL DEFAULT '0',
                                              `preciou` double NOT NULL DEFAULT '0',
                                              `totaliva` double NOT NULL DEFAULT '0',
                                              `porceniva` double NOT NULL DEFAULT '0',
                                              `descuento` double NOT NULL DEFAULT '0',
                                              `ret_iva` double NOT NULL DEFAULT '0',
                                              `ieps` double NOT NULL DEFAULT '0',
                                              `descripcion_larga` text NOT NULL,
                                              `cliente` int(11) NOT NULL DEFAULT '0',
                                              `factura` int(11) NOT NULL DEFAULT '0',
                                              `totalsiva` double NOT NULL DEFAULT '0',
                                              `orden` int(11) NOT NULL DEFAULT '0',
                                              `clvsat` varchar(255) NOT NULL DEFAULT '',
                                              `isr` double NOT NULL DEFAULT '0',
                                              `ieps_porcentaje` varchar(255) NOT NULL DEFAULT '',
                                              `ieps_TasaoCuota` varchar(255) NOT NULL DEFAULT '',
                                              `ret_iva_perc` varchar(255) NOT NULL DEFAULT '',
                                              `ip_loc` varchar(255) NOT NULL DEFAULT '',
                                              `FechaCad` varchar(255) NOT NULL DEFAULT '',
                                              `LoteCad` varchar(255) NOT NULL DEFAULT '',
                                              `ValorM` varchar(255) NOT NULL DEFAULT '',
                                              `PesoKg` varchar(255) NOT NULL DEFAULT '',
                                              `NumPed` varchar(255) NOT NULL DEFAULT '',
                                              `UUIDComE` varchar(255) NOT NULL DEFAULT '',
                                              `FracArancelaria` varchar(255) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Deudores
    Public vartabladeudores As String = "CREATE TABLE IF NOT EXISTS `deudores` (
                                          `IdDeudor` int(11) NOT NULL,
                                          `Nombre` varchar(255) NOT NULL DEFAULT '',
                                          `RazonS` varchar(255) NOT NULL DEFAULT '',
                                          `RFC` varchar(50) NOT NULL DEFAULT '',
                                          `Calle` varchar(150) NOT NULL DEFAULT '',
                                          `Colonia` varchar(150) NOT NULL DEFAULT '',
                                          `CP` varchar(20) NOT NULL DEFAULT '',
                                          `Delegacion` varchar(100) NOT NULL DEFAULT '',
                                          `Entidad` varchar(100) NOT NULL DEFAULT '',
                                          `Telefono` varchar(20) NOT NULL DEFAULT '',
                                          `Correo` varchar(100) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Devoluciones
    Public vartabladevoluciones As String = "CREATE TABLE `devoluciones` (
                                                  `Id` int(11) NOT NULL,
                                                  `Folio` int(11) NOT NULL DEFAULT '0',
                                                  `Codigo` varchar(50) NOT NULL DEFAULT '',
                                                  `Nombre` varchar(255) NOT NULL DEFAULT '',
                                                  `Cantidad` float NOT NULL DEFAULT '0',
                                                  `UVenta` varchar(50) NOT NULL DEFAULT '',
                                                  `CostVR` float NOT NULL DEFAULT '0',
                                                  `CostVP` float NOT NULL DEFAULT '0',
                                                  `CostoVUE` float NOT NULL DEFAULT '0',
                                                  `Precio` float NOT NULL DEFAULT '0',
                                                  `Total` float NOT NULL DEFAULT '0',
                                                  `PrecioSinIVA` float NOT NULL DEFAULT '0',
                                                  `TotalSinIVA` float NOT NULL DEFAULT '0',
                                                  `Fecha` datetime NOT NULL,
                                                  `Comisionista` varchar(50) NOT NULL DEFAULT '',
                                                  `Facturado` varchar(150) NOT NULL DEFAULT '',
                                                  `Depto` varchar(100) NOT NULL DEFAULT '',
                                                  `Grupo` varchar(100) NOT NULL DEFAULT '',
                                                  `ImporteEfec` float NOT NULL DEFAULT '0',
                                                  `NMESA` varchar(80) NOT NULL DEFAULT '',
                                                  `CUsuario` varchar(50) NOT NULL DEFAULT '',
                                                  `Hr` time NOT NULL,
                                                  `TipoMov` varchar(80) NOT NULL DEFAULT '',
                                                  `Cargado` int(1) NOT NULL DEFAULT '0',
                                                  `FolioReporte` int(11) NOT NULL DEFAULT '0'
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Entregas
    Public vartablaentregas As String = "CREATE TABLE IF NOT EXISTS `entregas` (
                                              `Id` int(11) NOT NULL,
                                              `IdCliente` int(11) NOT NULL DEFAULT '0',
                                              `Contador` int(11) NOT NULL DEFAULT '0',
                                              `Domicilio` text NOT NULL
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Extras
    Public vartablaextras As String = "CREATE TABLE `extras` (
                                          `Id` int(11) NOT NULL,
                                          `CodigoAlpha` varchar(10) DEFAULT '',
                                          `Codigo` varchar(10) DEFAULT '',
                                          `Descx` varchar(255) DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Facturas
    Public vartablafacturas As String = "CREATE TABLE IF NOT EXISTS `facturas` (
                                          `nom_id` int(11) NOT NULL,
                                          `nom_id_cliente` int(11) NOT NULL DEFAULT '0',
                                          `nom_razon_social` varchar(255) NOT NULL DEFAULT '',
                                          `nom_rfc_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_reg_fiscal` varchar(255) NOT NULL DEFAULT '',
                                          `nom_actividad_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_calle_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_colonia_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_del_mun_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_cp_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_expedido` varchar(255) NOT NULL DEFAULT '',
                                          `estado_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_nombre_cliente` varchar(255) NOT NULL DEFAULT '',
                                          `nom_calle_cliente` varchar(255) NOT NULL DEFAULT '',
                                          `nom_colonia_cliente` varchar(255) NOT NULL DEFAULT '',
                                          `nom_del_mun_cliente` varchar(255) NOT NULL DEFAULT '',
                                          `nom_rfc_cliente` varchar(200) NOT NULL DEFAULT '',
                                          `nom_folio` int(11) NOT NULL DEFAULT '0',
                                          `nom_fecha_factura` varchar(255) NOT NULL DEFAULT '',
                                          `nom_metodo_pago` varchar(255) NOT NULL DEFAULT '',
                                          `nom_tipo_pago` varchar(255) NOT NULL DEFAULT '',
                                          `nom_folio_sat_uuid` varchar(255) NOT NULL DEFAULT '',
                                          `nom_fecha_folio_sat` varchar(255) NOT NULL DEFAULT '',
                                          `nom_sello_emisor` text NOT NULL,
                                          `nom_sello_sat` text NOT NULL,
                                          `nom_cadena_original` text NOT NULL,
                                          `nom_total_pagado` varchar(255) NOT NULL DEFAULT '',
                                          `nom_no_csd_emp` varchar(255) NOT NULL DEFAULT '',
                                          `nom_no_csd_sat` varchar(255) NOT NULL DEFAULT '',
                                          `estatus_fac` int(11) NOT NULL DEFAULT '0',
                                          `id_evento` int(11) NOT NULL DEFAULT '0',
                                          `n_ext_cliente` varchar(255) NOT NULL DEFAULT '',
                                          `edo_cli` varchar(255) NOT NULL DEFAULT '',
                                          `descripcion` text NOT NULL,
                                          `descuento` double NOT NULL DEFAULT '0',
                                          `iva` double NOT NULL DEFAULT '0',
                                          `preciopaq` double NOT NULL DEFAULT '0',
                                          `id_emisor` double NOT NULL DEFAULT '0',
                                          `nom_ivaret` float NOT NULL DEFAULT '0',
                                          `nom_numcuenta` varchar(255) NOT NULL DEFAULT '',
                                          `nom_mdescuento` varchar(255) NOT NULL DEFAULT '',
                                          `nom_leyenda` text NOT NULL,
                                          `fecha` varchar(50) NOT NULL DEFAULT '',
                                          `nom_isr` double NOT NULL DEFAULT '0',
                                          `nom_cpago` varchar(255) NOT NULL DEFAULT '',
                                          `nom_status` int(11) NOT NULL DEFAULT '0',
                                          `UsoCFDI` varchar(255) NOT NULL DEFAULT '',
                                          `CartaPorte` int(11) NOT NULL DEFAULT '0',
                                          `regfis_cliente` varchar(255) NOT NULL DEFAULT '',
                                          `nom_numext_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_numint_empresa` varchar(255) NOT NULL DEFAULT '',
                                          `nom_comercial_cli` varchar(255) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'FechaCobros
    Public vartablafechacobros As String = "CREATE TABLE `fechacobros` (
                                      `Id` int(11) NOT NULL,
                                      `Inicia` int(11) DEFAULT '0',
                                      `Termina` int(11) DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'FormaPagoSat
    Public vartablaformapagosat As String = "CREATE TABLE IF NOT EXISTS `formapagosat` (
                                          `Id` int(11) NOT NULL,
                                          `ClavePago` varchar(20) NOT NULL DEFAULT '',
                                          `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaformapagosat As String = "INSERT INTO `formapagosat` (`Id`, `ClavePago`, `Descripcion`) VALUES
                                        (1, '01', 'Efectivo'),
                                        (2, '02', 'Cheque nominativo'),
                                        (3, '03', 'Transferencia electrónica de fondos'),
                                        (4, '04', 'Tarjeta de crédito'),
                                        (5, '05', 'Monedero electrónico'),
                                        (6, '06', 'Dinero electrónico'),
                                        (7, '08', 'Vales de despensa'),
                                        (8, '12', 'Dación en pago'),
                                        (9, '13', 'Pago por subrogación'),
                                        (10, '14', 'Pago por consignación'),
                                        (11, '15', 'Condonación'),
                                        (12, '17', 'Compensación'),
                                        (13, '23', 'Novación'),
                                        (14, '24', 'Confusión'),
                                        (15, '25', 'Remisión de deuda'),
                                        (16, '26', 'Prescripción o caducidad'),
                                        (17, '27', 'A satisfacci?n del acreedor'),
                                        (18, '28', 'Tarjeta de débito'),
                                        (19, '29', 'Tarjeta de servicios'),
                                        (20, '30', 'Aplicación de anticipos'),
                                        (21, '99', 'Por definir');"



    ''FormasPago
    Public vartablaformaspago As String = "CREATE TABLE IF NOT EXISTS `formaspago` (
                                              `Id` int(11) NOT NULL,
                                              `FormaPago` varchar(255) NOT NULL DEFAULT '',
                                              `Valor` varchar(255) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Formatos
    Public vartablaformatos As String = "CREATE TABLE IF NOT EXISTS `formatos` (
                                          `Id` int(11) NOT NULL,
                                          `Facturas` varchar(50) NOT NULL DEFAULT '',
                                          `NotasCred` varchar(150) NOT NULL DEFAULT '',
                                          `NumPart` int(11) NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public varinsertaformatos As String = "INSERT INTO `formatos` (`Id`,`Facturas`, `NotasCred`, `NumPart`) VALUES
                                                ('1','Entregas', '27/06/2023', 1),
                                                ('2','Papos', '', 0),
                                                ('3','PROVE_Ser', 'Gmail', 0),
                                                ('4','Server_SMTP', 'smtp.gmail.com', 0),
                                                ('5','LogoG', 'LogoN.jpg', 0),
                                                ('6','LogoFac', 'logo.jpg', 0),
                                                ('7','LogoE', '', 0),
                                                ('8','TipoLogo', 'SIN', 0),
                                                ('9','TamImpre', '80', 0),
                                                ('10','Moneda', 'PESO', 0),
                                                ('11','Simbolo', '$', 0),
                                                ('12','Abreviatura', 'MXN', 0),
                                                ('13','Modo', 'CAJA', 0),
                                                ('14','TipoPrecio', 'NORMAL', 0),
                                                ('15','Audita', '', 0),
                                                ('16','Mdescuento', '10', 0),
                                                ('17','Libreria', '0', 0),
                                                ('18','Medida_Eti', '', 0),
                                                ('19','FechaCosteo', '10/10/2022', 0),
                                                ('20','CorteCiego', '0', 0),
                                                ('21','Mod_Prod', '', 0),
                                                ('22','Mod_Comp', '', 0),
                                                ('23','Mod_Asis', '20/06/2023', 1),
                                                ('24','MinimoA', '0', 0),
                                                ('25','Acumula', '0', 0),
                                                ('26','AutoFac', '1', 0),
                                                ('27','Series', '0', 0),
                                                ('28','Desglosa', '1', 0),
                                                ('29','Costeo', 'PEPS', 1),
                                                ('30','CodAutoma', '', 0),
                                                ('31','RFC_Emisor', '', 0),
                                                ('32','SHIBOLETH', '', 0),
                                                ('33','SERIE_FACT_EL', 'A', 0),
                                                ('34','Partes', '0', 0),
                                                ('35','SERIE_NC_EL', 'B', 0),
                                                ('36','FOLIOfacINI', '1', 0),
                                                ('37','FOLIOfacFIN', '9999', 0),
                                                ('38','FolioNtaCredIni', '1', 0),
                                                ('39','FILE_CERT', '', 0),
                                                ('40','FILE_KEY', '', 0),
                                                ('41','Pto_Mail', '587', 0),
                                                ('42','Mail_Emi', '', 0),
                                                ('43','Shibboleth_ML', '', 0),
                                                ('44','Aute_Server_SMTP', '1', 0),
                                                ('45','SSL', '1', 0),
                                                ('46','ENV_DOC', '0', 0),
                                                ('47','InventarioDirecto', 'SI', 0),
                                                ('48','TPapelV', 'TICKET', 0),
                                                ('49','ImpreT', 'Enviar a OneNote 2013', 0),
                                                ('50','SHIBBOLETH', '0', 1),
                                                ('51','Desc_Ventas', '0', 0),
                                                ('52','TPapelCP', 'TICKET', 0),
                                                ('53','Franquicia', '0', 0),
                                                ('54','TomaContra', '0', 0),
                                                ('55','Restaurante', '0', 0),
                                                ('56','ToleBillar', '0', 0),
                                                ('57','TipoCobroBillar', 'HORA', 0),
                                                ('58','SinNumComensal', '0', 0),
                                                ('59','Propina', '0', 0),
                                                ('60','Refaccionaria', '0', 0),
                                                ('61','Telefonia', '0', 0),
                                                ('62','Hoteles', '0', 0),
                                                ('63','Nomina', '0', 0),
                                                ('64','OriLogoE', '0', 0),
                                                ('65','Control_Servicios', '0', 0),
                                                ('66','Whatsapp', '0', 0),
                                                ('67','Produccion', '0', 0),
                                                ('68','LinkAuto', '0', 0),
                                                ('69','ActuClientesNube', '0', 0),
                                                ('70','Pollos', '0', 0),
                                                ('71','ToleHabi', '0', 0),
                                                ('72','Pto-Bascula', '0', 0),
                                                ('73','TBascula', '0', 0),
                                                ('74','Bascula', 'SBascula', 0),
                                                ('75','Prefijo', '0', 0),
                                                ('76','Codigo', '0', 0),
                                                ('77','Peso', '0', 0),
                                                ('78','Taller', '0', 0),
                                                ('79','MesasPropias', '0', 0),
                                                ('80','Copa', '0', 0),
                                                ('81','IMG_PDF', '0', 0),
                                                ('82','SinNumCoemensal', '0', 0),
                                                ('83','Mapeo', '0', 0),
                                                ('84','SalidaHab', '0', 0),
                                                ('85','PrecioDia', '0', 0),
                                                ('86','Cuartos', '0', 0),
                                                ('87','CobroExacto', '0', 0);"



    'Gastos
    Public vartablagastos As String = "CREATE TABLE IF NOT EXISTS `gastos` (
                                          `Gasto` varchar(150) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Grupos
    Public vartablagrupos As String = "CREATE TABLE `grupos` (                                      
                                      `Id` int(11) NOT NULL,
                                      `Nombre` varchar(250) DEFAULT '',
                                      `Inicio` varchar(255) DEFAULT '',
                                      `Termino` varchar(250) DEFAULT '',
                                      `Cupo` float DEFAULT '0'                                    
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'HEResultados
    Public vartablaheresultados As String = "CREATE TABLE IF NOT EXISTS `heresultados` (
                                      `Codigo` varchar(50) NOT NULL DEFAULT '',
                                      `PDesc` varchar(255) NOT NULL DEFAULT '',
                                      `InvIni` float NOT NULL DEFAULT '0',
                                      `Compra` float NOT NULL DEFAULT '0',
                                      `CantDev` float NOT NULL DEFAULT '0',
                                      `InvFin` float NOT NULL DEFAULT '0',
                                      `Cvta` float NOT NULL DEFAULT '0',
                                      `PPrecio` float NOT NULL DEFAULT '0',
                                      `VtaTotal` float NOT NULL DEFAULT '0',
                                      `CostoTotal` float NOT NULL DEFAULT '0',
                                      `C_InvIni` float NOT NULL DEFAULT '0',
                                      `C_Compras` float NOT NULL DEFAULT '0',
                                      `C_Dev` float NOT NULL DEFAULT '0',
                                      `C_Vtas` float NOT NULL DEFAULT '0',
                                      `C_Utilidad` float NOT NULL DEFAULT '0',
                                      `C_Costo` float NOT NULL DEFAULT '0',
                                      `C_InvFin` float NOT NULL DEFAULT '0',
                                      `Folio_Rep` int(11) NOT NULL DEFAULT '0',
                                      `Fecha_Rep` varchar(50) NOT NULL DEFAULT '',
                                      `Fecha_Ini` varchar(50) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'HistAsigPC
    Public vartablahisasigpc As String = "CREATE TABLE `histasigpc` (
                                          `Id` int(11) NOT NULL,
                                          `Clave` varchar(80) DEFAULT '',
                                          `Nombre` varchar(100) DEFAULT '',
                                          `Tipo` varchar(80) DEFAULT '',
                                          `Procedencia` varchar(100) DEFAULT '',
                                          `NumHrs` float DEFAULT '0',
                                          `Total` float DEFAULT '0',
                                          `NumPC` int(11) DEFAULT '0',
                                          `HorEnt` varchar(50) DEFAULT '',
                                          `HorSal` datetime DEFAULT NULL,
                                          `Fecha` date DEFAULT NULL
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Horarios
    Public vartablahorarios As String = "CREATE TABLE IF NOT EXISTS `horarios` (
                                              `IdUsu` int(11) NOT NULL,
                                              `Monday` int(1) NOT NULL DEFAULT '0',
                                              `Tuesday` int(1) NOT NULL DEFAULT '0',
                                              `Wednesday` int(1) NOT NULL DEFAULT '0',
                                              `Thursday` int(1) NOT NULL DEFAULT '0',
                                              `Friday` int(1) NOT NULL DEFAULT '0',
                                              `Saturday` int(1) NOT NULL DEFAULT '0',
                                              `Sunday` int(1) NOT NULL DEFAULT '0',
                                              `HE` time NOT NULL,
                                              `HS` time NOT NULL,
                                              `TE` float NOT NULL DEFAULT '0',
                                              `TS` float NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'ImpuestosSat
    Public vartablaimpuestosat As String = "CREATE TABLE IF NOT EXISTS `impuestosat` (
                                          `Id` int(11) NOT NULL,
                                          `ClaveImpuesto` varchar(50) NOT NULL DEFAULT '',
                                          `Descripcion` varchar(100) NOT NULL DEFAULT '',
                                          `Retencion` varchar(50) NOT NULL DEFAULT '',
                                          `Traslado` varchar(50) NOT NULL DEFAULT '',
                                          `LocFed` varchar(50) NOT NULL DEFAULT '',
                                          `Entidad` varchar(50) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaimpuestosat As String = "INSERT INTO `impuestosat` (`Id`, `ClaveImpuesto`, `Descripcion`, `Retencion`, `Traslado`, `LocFed`, `Entidad`) VALUES
                                            (1, '001', 'ISR', 'Si', 'No', 'Federal', ''),
                                            (2, '002', 'IVA', 'Si', 'Si', 'Federal', ''),
                                            (3, '003', 'IEPS', 'Si', 'Si', 'Federal', '');"



    'IVA
    Public vartablaiva As String = "CREATE TABLE IF NOT EXISTS `iva` (
                                              `Id` int(11) NOT NULL,
                                              `IVA` float NOT NULL DEFAULT '0',
                                              `[Default]` float NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaiva As String = "INSERT INTO `iva` (`Id`, `IVA`, `[Default]`) VALUES
                                                (1, 0.16, 0),
                                                (2, 0, 0);"

    Public vartablaloginrecargas As String = "CREATE TABLE IF NOT EXISTS `loginrecargas` (
                                              `Id` int(11) NOT NULL,
                                              `numero` varchar(255) NOT NULL DEFAULT '',
                                              `usuario` varchar(255) NOT NULL DEFAULT '',
                                              `password` varchar(255) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


    Public vartablaliberacion As String = "CREATE TABLE IF NOT EXISTS `liberacion` (
                                              `Id` int(11) NOT NULL,
                                              `Codigo` varchar(255) NOT NULL DEFAULT '',
                                              `Valor` int(11) NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'Kits
    Public vartablakits As String = "CREATE TABLE IF NOT EXISTS `kits` (
                                  `Cod` varchar(50) NOT NULL DEFAULT '',
                                  `Nombre` varchar(255) NOT NULL DEFAULT '',
                                  `Codigo` varchar(50) NOT NULL DEFAULT '',
                                  `Descrip` varchar(255) NOT NULL DEFAULT '',
                                  `UVenta` varchar(50) NOT NULL DEFAULT '',
                                  `Cantidad` float NOT NULL DEFAULT '0',
                                  `Grupo` varchar(255) NOT NULL DEFAULT '',
                                  `PPrecio` float NOT NULL DEFAULT '0',
                                  `CTotal` float NOT NULL DEFAULT '0',
                                  `Fecha` DATE NOT NULL
                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'LoteCaducidad
    Public vartablalotecaducidad As String = "CREATE TABLE IF NOT EXISTS `lotecaducidad` (
                                              `Id` int(11) NOT NULL,
                                              `Codigo` varchar(50) NOT NULL DEFAULT '',
                                              `Lote` varchar(80) NOT NULL DEFAULT '',
                                              `Caducidad` date NOT NULL,
                                              `Cantidad` float NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


    Public vartablamembresiasgym As String = "CREATE TABLE IF NOT EXISTS `membresiasgym` (
                                      `Id` int(11) NOT NULL,
                                      `Cliente` varchar(250) NOT NULL DEFAULT '',
                                      `Producto` varchar(250) NOT NULL DEFAULT '',
                                      `Precio` float NOT NULL DEFAULT '0',
                                      `Inicio` date NOT NULL,
                                      `Fin`  date NOT NULL
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Merma
    Public vartablamerma As String = "CREATE TABLE IF NOT EXISTS `merma` (
                                      `Id` int(11) NOT NULL,
                                      `Codigo` varchar(50) NOT NULL DEFAULT '',
                                      `Nombre` varchar(255) NOT NULL DEFAULT '',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `Unidad` varchar(50) NOT NULL DEFAULT '',
                                      `Fecha` datetime NOT NULL,
                                      `Depto` varchar(100) NOT NULL DEFAULT '',
                                      `Grupo` varchar(100) NOT NULL DEFAULT '',
                                      `Usuario` varchar(50) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Mesa
    Public vartablamesa As String = "CREATE TABLE `mesa` (
                                      `IdMesa` int(11) NOT NULL,
                                      `Nombre_mesa` varchar(150) DEFAULT '',
                                      `Temporal` int(11) DEFAULT '0',
                                      `Status` varchar(50) DEFAULT '',
                                      `Contabiliza` int(11) DEFAULT '0',
                                      `Precio` float DEFAULT '0',
                                      `Orden` int(11) DEFAULT '0',
                                      `TempNom` varchar(100) DEFAULT '',
                                      `IdEmpleado` int(11) DEFAULT '0',
                                      `Mesero` varchar(50) DEFAULT '',
                                      `Ubicacion` varchar(80) DEFAULT '',
                                      `X` int(11) DEFAULT '0',
                                      `Y` int(11) DEFAULT '0',
                                      `Tipo` varchar(50) DEFAULT '',
                                      `Impresion` int(11) DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'MesasxEmpleados
    Public vartablamesasempleados As String = "CREATE TABLE `mesasxempleados` (
                                        `IdMesa` int(11) NOT NULL,
                                        `Mesa` varchar(80) DEFAULT '',
                                        `IdEmpleado` int(11) DEFAULT '0',
                                        `Grupo` varchar(50) DEFAULT '',
                                        `Temporal` int(11) DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'MesesSat
    Public vartablamesessat As String = "CREATE TABLE IF NOT EXISTS `mesessat` (
                                      `iD` int(11) NOT NULL,
                                      `Clave` varchar(50) NOT NULL DEFAULT '',
                                      `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertamesessat As String = "INSERT INTO `mesessat` (`iD`, `Clave`, `Descripcion`) VALUES
                                    (1, '01', 'Enero'),
                                    (2, '02', 'Febrero'),
                                    (3, '03', 'Marzo'),
                                    (4, '04', 'Abril'),
                                    (5, '05', 'Mayo'),
                                    (6, '06', 'Junio'),
                                    (7, '07', 'Julio'),
                                    (8, '08', 'Agosto'),
                                    (9, '09', 'Septiembre'),
                                    (10, '10', 'Octubre'),
                                    (11, '11', 'Noviembre'),
                                    (12, '12', 'Diciembre'),
                                    (13, '13', 'Enero-Febrero'),
                                    (14, '14', 'Marzo-Abril'),
                                    (15, '15', 'Mayo-Junio'),
                                    (16, '16', 'Julio-Agosto'),
                                    (17, '17', 'Septiembre-Octubre'),
                                    (18, '18', 'Noviembre-Diciembre');"



    'MetodoPagoSat
    Public vartablametodopagosat As String = "CREATE TABLE IF NOT EXISTS `metodopagosat` (
                                          `Id` int(11) NOT NULL,
                                          `ClaveMetPag` varchar(50) NOT NULL DEFAULT '',
                                          `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertametodopagosat As String = "INSERT INTO `metodopagosat` (`Id`, `ClaveMetPag`, `Descripcion`) VALUES
                                            (1, 'PUE', 'Pago en una sola exhibición'),
                                            (2, 'PPD', 'Pago en parcialidades o diferido');"



    'MiProd
    Public vartablamiprod As String = "CREATE TABLE `miprod` (
                                              `CodigoP` varchar(10) NOT NULL DEFAULT '',
                                              `DescripP` varchar(255) NOT NULL DEFAULT '',
                                              `UVentaP` varchar(10) NOT NULL DEFAULT '',
                                              `CantidadP` float NOT NULL DEFAULT '0',
                                              `Codigo` varchar(10) NOT NULL DEFAULT '',
                                              `Descrip` varchar(255) NOT NULL DEFAULT '',
                                              `UVenta` varchar(10) NOT NULL DEFAULT '',
                                              `Cantidad` float NOT NULL DEFAULT '0',
                                              `Grupo` varchar(80) NOT NULL DEFAULT '',
                                              `Lote` varchar(80) NOT NULL DEFAULT '',
                                              `Precio` double DEFAULT '0',
                                              `PrecioIVA` double DEFAULT '0',
                                              `Fase` varchar(50) DEFAULT '',
                                              `Teorico` double DEFAULT '0',
                                              `RealT` varchar(50) DEFAULT '',
                                              `Comentario` text
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'ModEntregas
    Public vartablamodentregas As String = "CREATE TABLE IF NOT EXISTS `modentregas` (
                                      `Id` int(11) NOT NULL,
                                      `Valor` int(11) NOT NULL DEFAULT '0',
                                      `Folio` int(11) NOT NULL DEFAULT '0',
                                      `Codigo` varchar(10) NOT NULL DEFAULT '',
                                      `Producto` varchar(255) NOT NULL DEFAULT '',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `Fecha` varchar(50) DEFAULT '',
                                      `Chofer` varchar(100) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'ModEntregasDet
    Public vartablamodentregasdet As String = "CREATE TABLE IF NOT EXISTS `modentregasdet` (
                                              `Id` int(11) NOT NULL,
                                              `FolioEntrega` int(11) NOT NULL DEFAULT '0',
                                              `Codigo` varchar(10) NOT NULL DEFAULT '',
                                              `Producto` varchar(255) NOT NULL DEFAULT '',
                                              `Cantidad` float NOT NULL DEFAULT '0',
                                              `FolioVenta` int(11) NOT NULL DEFAULT '0',
                                              `Precio` float NOT NULL DEFAULT '0',
                                              `Total` float NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'ModPrecios
    Public vartablamodprecios As String = "CREATE TABLE IF NOT EXISTS `modprecios` (
                                              `Id` int(11) NOT NULL,
                                              `Codigo` varchar(10) NOT NULL DEFAULT '',
                                              `Nombre` varchar(255) NOT NULL DEFAULT '',
                                              `Tipo` varchar(80) NOT NULL DEFAULT '',
                                              `Anterior` float NOT NULL DEFAULT '0',
                                              `Nuevo` float NOT NULL DEFAULT '0',
                                              `Fecha` date NOT NULL,
                                              `Hora` time(2) NOT NULL,
                                              `Usuario` varchar(50) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Monedero
    Public vartablamonedero As String = "CREATE TABLE IF NOT EXISTS `monedero` (
                                              `Id` int(11) NOT NULL,
                                              `Folio` varchar(20) NOT NULL DEFAULT '',
                                              `IdCliente` int(11) NOT NULL DEFAULT '0',
                                              `Cliente` varchar(255) NOT NULL DEFAULT '',
                                              `Saldo` float NOT NULL DEFAULT '0',
                                              `Alta` date NOT NULL,
                                              `Barras` varchar(50) NOT NULL DEFAULT '',
                                              `Porcentaje` float NOT NULL DEFAULT '0',
                                              `Actualiza` date NOT NULL,
                                              `Cargado` int(1) NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'MovCuenta
    Public vartablamovcuenta As String = "CREATE TABLE IF NOT EXISTS `movcuenta` (
                                          `Id` int(11) NOT NULL,
                                          `Tipo` varchar(80) NOT NULL DEFAULT '',
                                          `Banco` varchar(80) NOT NULL DEFAULT '',
                                          `Referencia` varchar(100) NOT NULL DEFAULT '',
                                          `Concepto` varchar(100) NOT NULL DEFAULT '',
                                          `Total` float NOT NULL DEFAULT '0',
                                          `Retiro` float NOT NULL DEFAULT '0',
                                          `Deposito` float NOT NULL DEFAULT '0',
                                          `Fecha` date NOT NULL,
                                          `Hora` time NOT NULL,
                                          `Folio` varchar(70) NOT NULL DEFAULT '',
                                          `Comentario` varchar(70) NOT NULL DEFAULT '',
                                          `Cuenta` varchar(70) NOT NULL DEFAULT '',
                                          `BancoCuenta` varchar(70) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'MovMonedero
    Public vartablamovmonedero As String = "CREATE TABLE IF NOT EXISTS `movmonedero` (
                                          `Id` int(11) NOT NULL,
                                          `Monedero` varchar(80) NOT NULL DEFAULT '',
                                          `Concepto` varchar(100) NOT NULL DEFAULT '',
                                          `Abono` float NOT NULL DEFAULT '0',
                                          `Cargo` float NOT NULL DEFAULT '0',
                                          `Saldo` float NOT NULL DEFAULT '0',
                                          `Fecha` date NOT NULL,
                                          `Hora` time(2) NOT NULL,
                                          `Folio` int(11) NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Nomina
    'Public vartablanomina As String = "CREATE TABLE IF NOT EXISTS `nomina` (
    '                                  `Id` int(11) NOT NULL,
    '                                  `IdEmpleado` int(11) NOT NULL DEFAULT '0',
    '                                  `Nombre` varchar(255) NOT NULL DEFAULT '',
    '                                  `Area` varchar(50) NOT NULL DEFAULT '',
    '                                  `Puesto` varchar(50) NOT NULL DEFAULT '',
    '                                  `Fecha` date NOT NULL,
    '                                  `Sueldo` float NOT NULL DEFAULT '0',
    '                                  `Descuento` float NOT NULL DEFAULT '0',
    '                                  `Horas` float NOT NULL DEFAULT '0',
    '                                  `OtrosD` float NOT NULL DEFAULT '0',
    '                                  `OtrosP` float NOT NULL DEFAULT '0',
    '                                  `SueldoNeto` float NOT NULL DEFAULT '0',
    '                                  `Desde` date NOT NULL,
    '                                  `Hasta` date NOT NULL,
    '                                  `Usuario` varchar(50) NOT NULL DEFAULT '',
    '                                  `Corte` int(2) NOT NULL DEFAULT '0',
    '                                  `CorteU` int(2) NOT NULL DEFAULT '0'
    '                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


    'Nomina
    Public vartablanomina As String = "CREATE TABLE IF NOT EXISTS `nomina` (
                                      `Id` int(11) NOT NULL,
                                      `nom_id_empleado` int(11) NOT NULL DEFAULT '0',
                                      `nom_razon_social` varchar(255) NOT NULL DEFAULT '',
                                      `nom_rfc_empresa` varchar(50) NOT NULL DEFAULT '',
                                      `nom_reg_fiscal` varchar(250) NOT NULL DEFAULT '',
                                      `nom_actividad_empresa` varchar(255) NOT NULL DEFAULT '',
                                      `nom_calle_empresa` varchar(50) NOT NULL DEFAULT '',
                                      `nom_colonia_empresa` varchar(250) NOT NULL DEFAULT '',
                                      `nom_del_mun_empresa` varchar(255) NOT NULL DEFAULT '',
                                      `nom_cp_empresa` varchar(50) NOT NULL DEFAULT '',
                                      `nom_expedido` varchar(250) NOT NULL DEFAULT '',
                                      `nom_nombre_empleado` varchar(255) NOT NULL DEFAULT '',
                                      `nom_calle_empleado` varchar(50) NOT NULL DEFAULT '',
                                      `nom_colonia_empleado` varchar(250) NOT NULL DEFAULT '',
                                      `nom_del_mun_empleado` varchar(255) NOT NULL DEFAULT '',
                                      `nom_tipo_contrato` varchar(50) NOT NULL DEFAULT '',
                                      `nom_jornada` varchar(250) NOT NULL DEFAULT '',
                                      `nom_rfc_empleado` varchar(255) NOT NULL DEFAULT '',
                                      `nom_curp` varchar(50) NOT NULL DEFAULT '',
                                      `nom_nss` varchar(250) NOT NULL DEFAULT '',
                                      `nom_fecha_ing` varchar(255) NOT NULL DEFAULT '',
                                      `nom_antiguedad` varchar(50) NOT NULL DEFAULT '',
                                      `nom_salario` varchar(250) NOT NULL DEFAULT '',
                                      `nom_folio` int(11) NOT NULL DEFAULT '0',
                                      `nom_fecha_nomina` varchar(250) NOT NULL DEFAULT '',
                                      `nom_periodo_del` varchar(255) NOT NULL DEFAULT '',
                                      `nom_periodo_al` varchar(50) NOT NULL DEFAULT '',
                                      `nom_dias_pagados` varchar(250) NOT NULL DEFAULT '',
                                      `nom_metodo_pago` varchar(255) NOT NULL DEFAULT '',
                                      `nom_tipo_pago` varchar(50) NOT NULL DEFAULT '',
                                      `nom_num_empleado` varchar(250) NOT NULL DEFAULT '',
                                      `nom_departamento` varchar(255) NOT NULL DEFAULT '',
                                      `nom_puesto` varchar(50) NOT NULL DEFAULT '',
                                      `nom_folio_sat_uuid` varchar(250) NOT NULL DEFAULT '',
                                      `nom_fecha_folio_sat` varchar(255) NOT NULL DEFAULT '',
                                      `nom_sello_emisor` varchar(50) NOT NULL DEFAULT '',
                                      `nom_sello_sat` varchar(250) NOT NULL DEFAULT '',
                                      `nom_cadena_original` varchar(255) NOT NULL DEFAULT '',
                                      `nom_percepcion_gravado` varchar(50) NOT NULL DEFAULT '',
                                      `nom_percepcion_exento` varchar(250) NOT NULL DEFAULT '',
                                      `nom_deduccion` varchar(255) NOT NULL DEFAULT '',
                                      `nom_total_pagado` varchar(50) NOT NULL DEFAULT '',
                                      `nom_status` int(11) NOT NULL DEFAULT '0',
                                      `nom_no_csd_emp` varchar(255) NOT NULL DEFAULT '',
                                      `nom_no_csd_sat` varchar(50) NOT NULL DEFAULT '',
                                      `nom_otrospag` varchar(250) NOT NULL DEFAULT '',
                                      `nom_tipo_nomina` varchar(255) NOT NULL DEFAULT '',
                                      `nom_Fecha_Emision` varchar(50) NOT NULL DEFAULT '',
                                      `Usuario` varchar(250) NOT NULL DEFAULT '',
                                      `CorteU` int(11) DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"




    'Nota
    Public vartablanota As String = "CREATE TABLE IF NOT EXISTS `nota` (
                                      `not_cve` int(11) NOT NULL,
                                      `not_nota` text NOT NULL
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'OtrosGastos
    Public vartablaotrosgastos As String = "CREATE TABLE IF NOT EXISTS `otrosgastos` (
                                              `Id` int(11) NOT NULL,
                                              `Tipo` varchar(50) NOT NULL DEFAULT '',
                                              `Concepto` varchar(255) NOT NULL DEFAULT '',
                                              `Folio` varchar(50) NOT NULL DEFAULT '',
                                              `Fecha` date NOT NULL,
                                              `FormaPago` varchar(50) NOT NULL DEFAULT '',
                                              `Monto` double NOT NULL DEFAULT '0',
                                              `Efectivo` float NOT NULL DEFAULT '0',
                                              `Tarjeta` float NOT NULL DEFAULT '0',
                                              `Transfe` float NOT NULL DEFAULT '0',
                                              `Subtotal` double NOT NULL DEFAULT '0',
                                              `IVA` double NOT NULL DEFAULT '0',
                                              `Total` float NOT NULL DEFAULT '0',
                                              `Nota` text NOT NULL,
                                              `Banco` varchar(50) DEFAULT '',
                                              `Referencia` varchar(50) DEFAULT '',
                                              `Comentario` varchar(255) DEFAULT '',
                                              `CuentaC` varchar(50) DEFAULT '',
                                              `BancoC` varchar(50) DEFAULT '',
                                              `Usuario` varchar(50) NOT NULL DEFAULT '',
                                              `CorteU` int(2) NOT NULL DEFAULT '0',
                                              `Corte` int(2) NOT NULL DEFAULT '0',
                                              `Modelo` varchar(100) NOT NULL DEFAULT '',
                                              `Placas` varchar(100) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public vartablaordentrabajo As String = "CREATE TABLE `ordentrabajo` (
                                                  `Id` int(11) NOT NULL,
                                                  `Codigo` varchar(50) NOT NULL DEFAULT '',
                                                  `CodBarra` varchar(100) NOT NULL DEFAULT '',
                                                  `CodBarra1` varchar(100) NOT NULL DEFAULT '',
                                                  `CodBarra2` varchar(100) NOT NULL DEFAULT '',
                                                  `CodBarra3` varchar(100) NOT NULL DEFAULT '',
                                                  `Nombre` varchar(250) NOT NULL DEFAULT '',
                                                  `NombreLargo` varchar(250) NOT NULL DEFAULT '',
                                                  `ProvPri` varchar(250) NOT NULL DEFAULT '',
                                                  `ProvEme` varchar(250) NOT NULL DEFAULT '',
                                                  `ProvRes` int(1) NOT NULL DEFAULT '0',
                                                  `UCompra` varchar(50) NOT NULL DEFAULT '',
                                                  `UVenta` varchar(50) NOT NULL DEFAULT '',
                                                  `UMinima` varchar(50) NOT NULL DEFAULT '',
                                                  `MCD` float NOT NULL DEFAULT '0',
                                                  `Multiplo` float NOT NULL DEFAULT '0',
                                                  `Departamento` varchar(250) NOT NULL DEFAULT '',
                                                  `Grupo` varchar(250) NOT NULL DEFAULT '',
                                                  `Ubicacion` varchar(250) NOT NULL DEFAULT '',
                                                  `Min` float NOT NULL DEFAULT '0',
                                                  `Max` float NOT NULL DEFAULT '0',
                                                  `Comision` float NOT NULL DEFAULT '0',
                                                  `PrecioCompra` float NOT NULL DEFAULT '0',
                                                  `PrecioVenta` float NOT NULL DEFAULT '0',
                                                  `PrecioVenta2` float NOT NULL DEFAULT '0',
                                                  `PrecioVentaIVA` float NOT NULL DEFAULT '0',
                                                  `PrecioDomicilio` float DEFAULT '0',
                                                  `PrecioDomicilioIVA` float DEFAULT '0',
                                                  `PorcMin` float NOT NULL DEFAULT '0',
                                                  `PorcMin2` float NOT NULL DEFAULT '0',
                                                  `PreMin` float NOT NULL DEFAULT '0',
                                                  `PreMin2` float NOT NULL DEFAULT '0',
                                                  `IVA` float NOT NULL DEFAULT '0',
                                                  `Existencia` float NOT NULL DEFAULT '0',
                                                  `Porcentaje` float NOT NULL DEFAULT '0',
                                                  `Porcentaje2` float NOT NULL DEFAULT '0',
                                                  `Fecha` date NOT NULL,
                                                  `PorcMay` float NOT NULL DEFAULT '0',
                                                  `PorcMay2` float NOT NULL DEFAULT '0',
                                                  `PorcMM` float NOT NULL DEFAULT '0',
                                                  `PorcMM2` float NOT NULL DEFAULT '0',
                                                  `PorcEsp` float NOT NULL DEFAULT '0',
                                                  `PorcEsp2` float NOT NULL DEFAULT '0',
                                                  `PreMay` float NOT NULL DEFAULT '0',
                                                  `PreMay2` float NOT NULL DEFAULT '0',
                                                  `PreMM` float NOT NULL DEFAULT '0',
                                                  `PreMM2` float NOT NULL DEFAULT '0',
                                                  `PreEsp` float NOT NULL DEFAULT '0',
                                                  `PreEsp2` float NOT NULL DEFAULT '0',
                                                  `CantMin1` float NOT NULL DEFAULT '0',
                                                  `CantMin2` float NOT NULL DEFAULT '0',
                                                  `CantMin3` float NOT NULL DEFAULT '0',
                                                  `CantMin4` float NOT NULL DEFAULT '0',
                                                  `CantMay1` float NOT NULL DEFAULT '0',
                                                  `CantMay2` float NOT NULL DEFAULT '0',
                                                  `CantMay3` float NOT NULL DEFAULT '0',
                                                  `CantMay4` float NOT NULL DEFAULT '0',
                                                  `CantMM1` float NOT NULL DEFAULT '0',
                                                  `CantMM2` float NOT NULL DEFAULT '0',
                                                  `CantMM3` float NOT NULL DEFAULT '0',
                                                  `CantMM4` float NOT NULL DEFAULT '0',
                                                  `CantEsp1` float NOT NULL DEFAULT '0',
                                                  `CantEsp2` float NOT NULL DEFAULT '0',
                                                  `CantEsp3` float NOT NULL DEFAULT '0',
                                                  `CantEsp4` float NOT NULL DEFAULT '0',
                                                  `CantLst1` float NOT NULL DEFAULT '0',
                                                  `CantLst2` float NOT NULL DEFAULT '0',
                                                  `CantLst3` float NOT NULL DEFAULT '0',
                                                  `CantLst4` float NOT NULL DEFAULT '0',
                                                  `pres_vol` int(1) NOT NULL DEFAULT '0',
                                                  `id_tbMoneda` float NOT NULL DEFAULT '0',
                                                  `Promocion` int(1) NOT NULL DEFAULT '0',
                                                  `Descto` float NOT NULL DEFAULT '0',
                                                  `Afecta_exis` int(1) NOT NULL DEFAULT '0',
                                                  `PercentIVAret` float NOT NULL DEFAULT '0',
                                                  `Almacen3` float NOT NULL DEFAULT '0',
                                                  `IIEPS` float NOT NULL DEFAULT '0',
                                                  `InvInicial` float NOT NULL DEFAULT '0',
                                                  `ISR` float NOT NULL DEFAULT '0',
                                                  `InvFinal` float NOT NULL DEFAULT '0',
                                                  `InvInicialCosto` float NOT NULL DEFAULT '0',
                                                  `InvFinalCosto` float NOT NULL DEFAULT '0',
                                                  `ClaveSat` varchar(100) NOT NULL DEFAULT '',
                                                  `UnidadSat` varchar(50) NOT NULL DEFAULT '',
                                                  `Cargado` int(1) NOT NULL DEFAULT '0',
                                                  `CargadoInv` int(1) NOT NULL DEFAULT '0',
                                                  `Uso` varchar(100) NOT NULL DEFAULT '',
                                                  `Color` varchar(100) NOT NULL DEFAULT '',
                                                  `Genero` varchar(100) NOT NULL DEFAULT '',
                                                  `Marca` varchar(100) NOT NULL DEFAULT '',
                                                  `Articulo` varchar(100) NOT NULL DEFAULT '',
                                                  `Dia` float NOT NULL DEFAULT '0',
                                                  `Descu` varchar(50) NOT NULL DEFAULT '0',
                                                  `Status_Promocion` int(1) NOT NULL DEFAULT '0',
                                                  `Porcentaje_Promo` float NOT NULL DEFAULT '0',
                                                  `Fecha_Inicial` date NOT NULL,
                                                  `Fecha_Final` date NOT NULL,
                                                  `Promo_Monedero` float NOT NULL DEFAULT '0',
                                                  `Unico` int(1) NOT NULL DEFAULT '0',
                                                  `N_Serie` varchar(150) NOT NULL DEFAULT '',
                                                  `GPrint` varchar(80) DEFAULT '',
                                                  `Cant_Ent` float DEFAULT '0',
                                                  `E1` int(1) DEFAULT '0',
                                                  `E2` int(1) DEFAULT '0',
                                                  `NumPromo` varchar(50) DEFAULT '0',
                                                  `Modo_Almacen` int(1) DEFAULT '0',
                                                  `F44` float DEFAULT '0',
                                                  `CargadoAndroid` int(11) DEFAULT '0' COMMENT 'para ventas en ruta',
                                                  `Mililitros` float DEFAULT '0',
                                                  `Copas` float DEFAULT '0',
                                                  `Existencia_Suc` int(1) DEFAULT '0',
                                                  `Consecutivo` int(1) DEFAULT '0',
                                                  `PrecioUnitario` varchar(250) DEFAULT '0'
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Parametros
    Public vartablaparametros As String = "CREATE TABLE IF NOT EXISTS `parametros` (
                                          `Id` int(11) NOT NULL,
                                          `Evaluo` int(11) NOT NULL,
                                          `Liberacion` date NOT NULL
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaparametros As String = "INSERT INTO `parametros` (`Id`, `Evaluo`, `Liberacion`) VALUES
                                                    (1, '1', '2023-08-23');"



    'Parcialidades
    Public vartablaparcialidades As String = "CREATE TABLE IF NOT EXISTS `parcialidades` (
                                          `Id` int(11) NOT NULL,
                                          `FolioPar` int(11) NOT NULL DEFAULT '0',
                                          `IdFact` int(11) NOT NULL DEFAULT '0',
                                          `FolioFact` int(11) NOT NULL DEFAULT '0',
                                          `LugarExp` varchar(255) NOT NULL DEFAULT '',
                                          `TipoComprobante` varchar(255) NOT NULL DEFAULT '',
                                          `Total` varchar(255) NOT NULL DEFAULT '',
                                          `Moneda` varchar(255) NOT NULL DEFAULT '',
                                          `Subtotal` varchar(255) NOT NULL DEFAULT '',
                                          `Fecha` varchar(255) NOT NULL DEFAULT '',
                                          `Serie` varchar(255) NOT NULL DEFAULT '',
                                          `EmiRFC` varchar(255) NOT NULL DEFAULT '',
                                          `EmiRazon` varchar(255) NOT NULL DEFAULT '',
                                          `EmiRegimen` varchar(255) NOT NULL DEFAULT '',
                                          `EmiIdDatos` int(11) NOT NULL DEFAULT '0',
                                          `CliRFC` varchar(255) NOT NULL DEFAULT '',
                                          `CliRazon` varchar(255) NOT NULL DEFAULT '',
                                          `CliUsoCFDI` varchar(255) NOT NULL DEFAULT '',
                                          `Importe` varchar(255) NOT NULL DEFAULT '',
                                          `ValorUnitario` varchar(255) NOT NULL DEFAULT '',
                                          `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                          `ClaveUnidad` varchar(255) NOT NULL DEFAULT '',
                                          `NumOperacion` varchar(255) NOT NULL DEFAULT '',
                                          `Monto` varchar(255) NOT NULL DEFAULT '',
                                          `MonedaP` varchar(255) NOT NULL DEFAULT '',
                                          `FormaPago` varchar(255) NOT NULL DEFAULT '',
                                          `FechaPago` varchar(255) NOT NULL DEFAULT '',
                                          `UUID` text NOT NULL,
                                          `Sello` text NOT NULL,
                                          `NoCert` text NOT NULL,
                                          `Certificado` text NOT NULL,
                                          `SelloCFD` text NOT NULL,
                                          `NoCertSat` text NOT NULL,
                                          `SelloSat` text NOT NULL,
                                          `CadenaOriginal` text NOT NULL,
                                          `FechaTimbrado` varchar(100) NOT NULL DEFAULT '',
                                          `RfcProvCertf` varchar(255) NOT NULL DEFAULT '',
                                          `FolioUnido` varchar(255) NOT NULL DEFAULT '',
                                          `CliIdDatos` int(11) NOT NULL DEFAULT '0',
                                          `Estatus_Par` varchar(255) NOT NULL DEFAULT '',
                                          `NumCta` varchar(255) NOT NULL DEFAULT '',
                                          `Comentario` text NOT NULL,
                                          `NumCtaCliente` varchar(255) NOT NULL DEFAULT '',
                                          `CtaRFCCli` varchar(255) NOT NULL DEFAULT '',
                                          `CtaRFCEmi` varchar(255) NOT NULL DEFAULT '',
                                          `Banco` varchar(255) NOT NULL DEFAULT '',
                                          `BancoEmi` varchar(255) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'PARCIALIDADESDETALLE2
    Public vartablaparcialidadesdetalle As String = "CREATE TABLE `parcialidadesdetalle` (
                                                              `Id` int(11) NOT NULL,
                                                              `IdParcialidades` int(11) NOT NULL DEFAULT '0',
                                                              `Folio` varchar(255) NOT NULL DEFAULT '',
                                                              `Serie` varchar(255) NOT NULL DEFAULT '',
                                                              `ImpSaldoIns` varchar(255) NOT NULL DEFAULT '',
                                                              `ImpPagado` varchar(255) NOT NULL DEFAULT '',
                                                              `ImpSaldoAnt` varchar(255) NOT NULL DEFAULT '',
                                                              `NumParcialidades` varchar(255) NOT NULL DEFAULT '',
                                                              `MetodoPago` varchar(255) NOT NULL DEFAULT '',
                                                              `Moneda` varchar(255) NOT NULL DEFAULT '',
                                                              `UUID` varchar(255) NOT NULL DEFAULT '',
                                                              `OpeIva` varchar(50) DEFAULT '',
                                                              `OpeIvaRet` varchar(50) DEFAULT '',
                                                              `OpeIsr` varchar(50) DEFAULT '',
                                                              `OpeIeps` varchar(50) DEFAULT '',
                                                              `OpeIva0` varchar(50) DEFAULT '',
                                                              `IsrPorc` varchar(50) DEFAULT '',
                                                              `IvaRetPorc` varchar(50) DEFAULT '',
                                                              `IepsPorc` varchar(50) DEFAULT '',
                                                              `ieps160` varchar(50) DEFAULT '',
                                                              `ieps53` varchar(50) DEFAULT '',
                                                              `ieps5` varchar(50) DEFAULT '',
                                                              `ieps304` varchar(50) DEFAULT '',
                                                              `ieps3` varchar(50) DEFAULT '',
                                                              `ieps265` varchar(50) DEFAULT '',
                                                              `ieps25` varchar(50) DEFAULT '',
                                                              `ieps09` varchar(50) DEFAULT '',
                                                              `ieps08` varchar(50) DEFAULT '',
                                                              `ieps07` varchar(50) DEFAULT '',
                                                              `ieps06` varchar(50) DEFAULT '',
                                                              `ieps03` varchar(50) DEFAULT '',
                                                              `Baseieps160` varchar(50) DEFAULT '',
                                                              `Baseieps53` varchar(50) DEFAULT '',
                                                              `Baseieps5` varchar(50) DEFAULT '',
                                                              `Baseieps304` varchar(50) DEFAULT '',
                                                              `Baseieps3` varchar(50) DEFAULT '',
                                                              `Baseieps265` varchar(50) DEFAULT '',
                                                              `Baseieps25` varchar(50) DEFAULT '',
                                                              `Baseieps09` varchar(50) DEFAULT '',
                                                              `Baseieps08` varchar(50) DEFAULT '',
                                                              `Baseieps07` varchar(50) DEFAULT '',
                                                              `Baseieps06` varchar(50) DEFAULT '',
                                                              `Baseieps03` varchar(50) DEFAULT '',
                                                              `BaseIVA16` varchar(50) DEFAULT '',
                                                              `BaseISR` varchar(50) DEFAULT '',
                                                              `BaseIVARet` varchar(50) DEFAULT '',
                                                              `BaseIVA0` varchar(50) DEFAULT ''
                                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'ParcialidadesDetalleMULTI
    Public vartablaparcialidadesdetallemulti As String = "CREATE TABLE `parcialidadesdetallemulti` (
                                                                      `Id` int(11) NOT NULL,
                                                                      `IdParcialidades` int(11) NOT NULL DEFAULT '0',
                                                                      `Folio` varchar(255) NOT NULL DEFAULT '',
                                                                      `Serie` varchar(255) NOT NULL DEFAULT '',
                                                                      `ImpSaldoIns` varchar(255) NOT NULL DEFAULT '',
                                                                      `ImpPagado` varchar(255) NOT NULL DEFAULT '',
                                                                      `ImpSaldoAnt` varchar(255) NOT NULL DEFAULT '',
                                                                      `NumParcialidades` varchar(255) NOT NULL DEFAULT '',
                                                                      `MetodoPago` varchar(255) NOT NULL DEFAULT '',
                                                                      `Moneda` varchar(255) NOT NULL DEFAULT '',
                                                                      `UUID` varchar(255) NOT NULL DEFAULT '',
                                                                      `OpeIva` varchar(50) NOT NULL DEFAULT '0',
                                                                      `OpeIvaRet` varchar(50) NOT NULL DEFAULT '0',
                                                                      `OpeIsr` varchar(50) NOT NULL DEFAULT '0',
                                                                      `OpeIeps` varchar(50) NOT NULL DEFAULT '0',
                                                                      `OpeIva0` varchar(50) NOT NULL DEFAULT '0',
                                                                      `IsrPorc` varchar(50) NOT NULL DEFAULT '0',
                                                                      `IvaRetPorc` varchar(50) NOT NULL DEFAULT '0',
                                                                      `IepsPorc` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Ieps160` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps53` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps5` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps304` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps3` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps265` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps25` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps09` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps08` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps07` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps06` varchar(50) NOT NULL DEFAULT '0',
                                                                      `ieps03` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps160` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps53` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps5` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps304` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps3` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps265` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps25` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps09` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps08` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps07` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps06` varchar(50) NOT NULL DEFAULT '0',
                                                                      `Baseieps03` varchar(50) NOT NULL DEFAULT '0',
                                                                      `BaseIVA16` varchar(50) NOT NULL DEFAULT '0',
                                                                      `BaseISR` varchar(50) NOT NULL DEFAULT '0',
                                                                      `BaseIVARet` varchar(50) NOT NULL DEFAULT '0',
                                                                      `BaseIVA0` varchar(50) NOT NULL DEFAULT '0'
                                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    'ParcialidadesMulti
    Public vartablaparcialidadesmulti As String = "CREATE TABLE `parcialidadesmulti` (
                                                                  `Id` int(11) NOT NULL,
                                                                  `FolioPar` int(11) NOT NULL DEFAULT '0',
                                                                  `IdFact` int(11) NOT NULL DEFAULT '0',
                                                                  `FolioFact` int(11) NOT NULL DEFAULT '0',
                                                                  `LugarExp` varchar(255) NOT NULL DEFAULT '',
                                                                  `TipoComprobante` varchar(255) NOT NULL DEFAULT '',
                                                                  `Total` varchar(255) NOT NULL DEFAULT '',
                                                                  `Moneda` varchar(255) NOT NULL DEFAULT '',
                                                                  `Subtotal` varchar(255) NOT NULL DEFAULT '',
                                                                  `Fecha` varchar(255) NOT NULL DEFAULT '',
                                                                  `Serie` varchar(255) NOT NULL DEFAULT '',
                                                                  `EmiRFC` varchar(255) NOT NULL DEFAULT '',
                                                                  `EmiRazon` varchar(255) NOT NULL DEFAULT '',
                                                                  `EmiRegimen` varchar(255) NOT NULL DEFAULT '',
                                                                  `EmiIdDatos` int(11) NOT NULL DEFAULT '0',
                                                                  `CliRFC` varchar(255) NOT NULL DEFAULT '',
                                                                  `CliRazon` varchar(255) NOT NULL DEFAULT '',
                                                                  `CliUsoCFDI` varchar(255) NOT NULL DEFAULT '',
                                                                  `Importe` varchar(255) NOT NULL DEFAULT '',
                                                                  `ValorUnitario` varchar(255) NOT NULL DEFAULT '',
                                                                  `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                                                  `ClaveUnidad` varchar(255) NOT NULL DEFAULT '',
                                                                  `NumOperacion` varchar(255) NOT NULL DEFAULT '',
                                                                  `Monto` varchar(255) NOT NULL DEFAULT '',
                                                                  `MonedaP` varchar(255) NOT NULL DEFAULT '',
                                                                  `FormaPago` varchar(255) NOT NULL DEFAULT '',
                                                                  `FechaPago` varchar(255) NOT NULL DEFAULT '',
                                                                  `UUID` text NOT NULL,
                                                                  `Sello` text NOT NULL,
                                                                  `NoCert` text NOT NULL,
                                                                  `Certificado` text NOT NULL,
                                                                  `SelloCFD` text NOT NULL,
                                                                  `NoCertSat` text NOT NULL,
                                                                  `SelloSat` text NOT NULL,
                                                                  `CadenaOriginal` text NOT NULL,
                                                                  `FechaTimbrado` varchar(100) NOT NULL DEFAULT '',
                                                                  `RfcProvCertf` varchar(255) NOT NULL DEFAULT '',
                                                                  `FolioUnido` varchar(255) NOT NULL DEFAULT '',
                                                                  `CliIdDatos` int(11) NOT NULL DEFAULT '0',
                                                                  `Estatus_Par` varchar(255) NOT NULL DEFAULT '',
                                                                  `NumCta` varchar(255) NOT NULL DEFAULT '',
                                                                  `Comentario` text NOT NULL,
                                                                  `NumCtaCliente` varchar(255) NOT NULL DEFAULT '',
                                                                  `CtaRFCEmi` varchar(255) NOT NULL DEFAULT '',
                                                                  `CtaRFCCli` varchar(255) NOT NULL DEFAULT '',
                                                                  `Banco` varchar(255) NOT NULL DEFAULT '',
                                                                  `BancoEmi` varchar(255) NOT NULL DEFAULT '',
                                                                  `CPCli` varchar(255) NOT NULL DEFAULT '',
                                                                  `CliRegimen` varchar(50) NOT NULL DEFAULT '',
                                                                  `BaseIVA16` varchar(50) NOT NULL DEFAULT '0',
                                                                  `BaseIVA0` varchar(50) NOT NULL DEFAULT '0',
                                                                  `BaseIVARet` varchar(50) NOT NULL DEFAULT ''
                                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


    'Pedidos
    Public vartablapedidos As String = "CREATE TABLE IF NOT EXISTS `pedidos` (
                                                  `Id` int(11) NOT NULL,
                                                  `Num` varchar(255) NOT NULL DEFAULT '',
                                                  `Proveedor` varchar(255) NOT NULL DEFAULT '',
                                                  `Total` float NOT NULL DEFAULT '0',
                                                  `Anticipo` float NOT NULL DEFAULT '0',
                                                  `Fecha` date NOT NULL,
                                                  `Hora` datetime NOT NULL,
                                                  `Status` int(1) NOT NULL DEFAULT '0',
                                                  `Usuario` varchar(50) NOT NULL DEFAULT '',
                                                  `Cargado` int(1) NOT NULL DEFAULT '0',
                                                  `TipoPago` varchar(100) NOT NULL DEFAULT '',
                                                  `Banco` varchar(100) NOT NULL DEFAULT '',
                                                  `Referencia` varchar(200) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1"



    'PedidosDet
    Public vartablapedidosdet As String = "CREATE TABLE IF NOT EXISTS `pedidosdet` (
                                          `Id` int(11) NOT NULL,
                                          `NumPed` varchar(80) NOT NULL DEFAULT '',
                                          `Proveedor` varchar(255) NOT NULL DEFAULT '',
                                          `Codigo` varchar(20) NOT NULL DEFAULT '',
                                          `Nombre` varchar(255) NOT NULL DEFAULT '',
                                          `Unidad` varchar(20) NOT NULL DEFAULT '',
                                          `Precio` float NOT NULL DEFAULT '0',
                                          `Cantidad` float NOT NULL DEFAULT '0',
                                          `Cargado` int(1) NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PeriodicidadSat
    Public vartablaperiodicidadsat As String = "CREATE TABLE IF NOT EXISTS `periodicidadsat` (
                                                  `Id` int(11) NOT NULL,
                                                  `Clave` varchar(50) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaperiodicidadsat As String = "INSERT INTO `periodicidadsat` (`Id`, `Clave`, `Descripcion`) VALUES
                                            (1, '01', 'Diario'),
                                            (2, '02', 'Semanal'),
                                            (3, '03', 'Quincenal'),
                                            (4, '04', 'Mensual'),
                                            (5, '05', 'Bimestral');"



    'Permisos
    Public vartablapermisos As String = "CREATE TABLE IF NOT EXISTS `permisos` (
                                              `Id` int(11) NOT NULL,
                                              `IdEmpleado` int(11) NOT NULL DEFAULT '0',
                                              `Cat_Emp` int(1) NOT NULL DEFAULT '0',
                                              `Cat_Cli` int(1) NOT NULL DEFAULT '0',
                                              `Cat_Prov` int(1) NOT NULL DEFAULT '0',
                                              `Cat_Mone` int(1) NOT NULL DEFAULT '0',
                                              `Asis_Hora` int(1) NOT NULL DEFAULT '0',
                                              `Asis_Hue` int(1) NOT NULL DEFAULT '0',
                                              `Asis_Asis` int(1) NOT NULL DEFAULT '0',
                                              `Asis_Rep` int(1) NOT NULL DEFAULT '0',
                                              `Prod_Prod` int(1) NOT NULL DEFAULT '0',
                                              `Prod_Serv` int(1) NOT NULL DEFAULT '0',
                                              `Prod_Pre` int(1) NOT NULL DEFAULT '0',
                                              `Prod_Prom` int(1) NOT NULL DEFAULT '0',
                                              `Prod_Kits` int(1) NOT NULL DEFAULT '0',
                                              `Comp_Ped` int(1) NOT NULL DEFAULT '0',
                                              `Comp_CPed` int(1) NOT NULL DEFAULT '0',
                                              `Comp_Com` int(1) NOT NULL DEFAULT '0',
                                              `Comp_CCom` int(1) NOT NULL DEFAULT '0',
                                              `Comp_NCred` int(1) NOT NULL DEFAULT '0',
                                              `Comp_CtPag` int(1) NOT NULL DEFAULT '0',
                                              `Comp_Abon` int(1) NOT NULL DEFAULT '0',
                                              `Comp_Anti` int(1) NOT NULL DEFAULT '0',
                                              `Vent_Most` int(1) NOT NULL DEFAULT '0',
                                              `Vent_Touch` int(1) NOT NULL DEFAULT '0',
                                              `Vent_NVen` int(1) NOT NULL DEFAULT '0',
                                              `Vent_Coti` int(1) NOT NULL DEFAULT '0',
                                              `Vent_Pedi` int(1) NOT NULL DEFAULT '0',
                                              `Vent_Devo` int(1) NOT NULL DEFAULT '0',
                                              `Vent_CFol` int(1) NOT NULL DEFAULT '0',
                                              `Vent_Abo` int(1) NOT NULL DEFAULT '0',
                                              `Vent_Canc` int(1) NOT NULL DEFAULT '0',
                                              `Vent_EPrec` int(1) NOT NULL DEFAULT '0',
                                              `Ing_CEmp` int(1) NOT NULL DEFAULT '0',
                                              `Egr_PEmp` int(1) NOT NULL DEFAULT '0',
                                              `Egr_Nom` int(1) NOT NULL DEFAULT '0',
                                              `Egr_Tran` int(1) NOT NULL DEFAULT '0',
                                              `Egr_Otro` int(1) NOT NULL DEFAULT '0',
                                              `Rep_Vent` int(1) NOT NULL DEFAULT '0',
                                              `Rep_VentG` int(1) NOT NULL DEFAULT '0',
                                              `Rep_Comp` int(1) NOT NULL DEFAULT '0',
                                              `Rep_CCob` int(1) NOT NULL DEFAULT '0',
                                              `Rep_CPag` int(1) NOT NULL DEFAULT '0',
                                              `Rep_Ent` int(1) NOT NULL DEFAULT '0',
                                              `Rep_Sal` int(1) NOT NULL DEFAULT '0',
                                              `Rep_Inv` int(1) NOT NULL DEFAULT '0',
                                              `Rep_Aju` int(1) NOT NULL DEFAULT '0',
                                              `List_Pre` int(1) NOT NULL DEFAULT '0',
                                              `List_Pro` int(1) NOT NULL DEFAULT '0',
                                              `List_Fal` int(1) NOT NULL DEFAULT '0',
                                              `Fact_Fact` int(1) NOT NULL DEFAULT '0',
                                              `Fact_Rep` int(1) NOT NULL DEFAULT '0',
                                              `Ad_Perm` int(1) NOT NULL DEFAULT '0',
                                              `Ad_Conf` int(1) NOT NULL DEFAULT '0',
                                              `Ad_Util` int(1) NOT NULL DEFAULT '0',
                                              `Ad_Cort` int(1) NOT NULL DEFAULT '0',
                                              `Ad_Cli` int(1) NOT NULL DEFAULT '0',
                                              `Desocupar` int(1) NOT NULL DEFAULT '0',
                                              `Cambiar` int(1) NOT NULL DEFAULT '0',
                                              `ReimprimirApp` int(1) NOT NULL DEFAULT '0',
                                              `CobAboRem` int(1) NOT NULL DEFAULT '0',
                                              `Rep_Servicios` int(1) NOT NULL DEFAULT '0',
                                              `Rep_CamPrecio` int(1) NOT NULL DEFAULT '0',
                                              `Rep_EstResultado` int(1) NOT NULL DEFAULT '0',
                                              `Rep_Auditoria` int(1) NOT NULL DEFAULT '0',
                                              `cat_Formas` int(1) NOT NULL DEFAULT '0',
                                              `cat_Bancos` int(1) NOT NULL DEFAULT '0',
                                              `cat_Cuentas` int(1) NOT NULL DEFAULT '0',
                                              `PreciosHab` int(1) NOT NULL DEFAULT '0',
                                              `ReimprimirTicket` int(1) NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public varinsertapermisos As String = "INSERT INTO `permisos` (`Id`, `IdEmpleado`, `Cat_Emp`, `Cat_Cli`, `Cat_Prov`, `Cat_Mone`, `Asis_Hora`, `Asis_Hue`, `Asis_Asis`, `Asis_Rep`, `Prod_Prod`, `Prod_Serv`, `Prod_Pre`, `Prod_Prom`, `Prod_Kits`, `Comp_Ped`, `Comp_CPed`, `Comp_Com`, `Comp_CCom`, `Comp_NCred`, `Comp_CtPag`, `Comp_Abon`, `Comp_Anti`, `Vent_Most`, `Vent_Touch`, `Vent_NVen`, `Vent_Coti`, `Vent_Pedi`, `Vent_Devo`, `Vent_CFol`, `Vent_Abo`, `Vent_Canc`, `Vent_EPrec`, `Ing_CEmp`, `Egr_PEmp`, `Egr_Nom`, `Egr_Tran`, `Egr_Otro`, `Rep_Vent`, `Rep_VentG`, `Rep_Comp`, `Rep_CCob`, `Rep_CPag`, `Rep_Ent`, `Rep_Sal`, `Rep_Inv`, `Rep_Aju`, `List_Pre`, `List_Pro`, `List_Fal`, `Fact_Fact`, `Fact_Rep`, `Ad_Perm`, `Ad_Conf`, `Ad_Util`, `Ad_Cort`,`Ad_Cli`,`ReimprimirApp`,`CobAboRem`,`Rep_Servicios`,`Rep_CamPrecio`,`Rep_EstResultado`,`Rep_Auditoria`,`cat_Formas`,`cat_Bancos`,`cat_Cuentas`,`PreciosHab`) VALUES
(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1,1,1,1,1,1,1);"



    'PermisosM
    Public vartablapermisosm As String = "CREATE TABLE `permisosm` (
                                              `Id` int(11) NOT NULL,
                                              `IdEmpleado` int(11) DEFAULT '0',
                                              `Precuenta` int(1) DEFAULT '0',
                                              `CambioM` int(1) DEFAULT '0',
                                              `CancelarM` int(1) DEFAULT '0',
                                              `CortesiaM` int(1) DEFAULT '0',
                                              `JuntarM` int(1) DEFAULT '0',
                                              `CobrarM` int(1) DEFAULT '0',
                                              `Mesas` int(1) DEFAULT '0',
                                              `Propias` int(1) DEFAULT '0',
                                              `Copas` int(1) DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public varinsertapermisosm As String = "INSERT INTO `permisosm` (`Id`, `IdEmpleado`, `Precuenta`, `CambioM`, `CancelarM`, `CortesiaM`, `JuntarM`, `CobrarM`, `Mesas`, `Propias`, `Copas`, `CobroExacto`) VALUES
(1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0);
"




    'PorteClaveSTCC
    Public vartablaporteclavestcc As String = "CREATE TABLE IF NOT EXISTS `porteclavestcc` (
                                          `Id` int(11) NOT NULL,
                                          `Clave` varchar(50) NOT NULL DEFAULT '',
                                          `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaporteclavestcc As String = "INSERT INTO `porteclavestcc` (`Id`, `Clave`, `Descripcion`) VALUES
                                            (1, '01', 'Productos agrícolas'),
                                            (2, '011', 'Cultivos de campo'),
                                            (3, '0112', 'Algodón en bruto'),
                                            (4, '01131', 'Cebada'),
                                            (5, '01132', 'Maíz'),
                                            (6, '01133', 'Avena'),
                                            (7, '01134', 'Arroz'),
                                            (8, '01135', 'Centeno'),
                                            (9, '01136', 'Sorgo'),
                                            (10, '01137', 'Trigo'),
                                            (11, '01139', 'Grano'),
                                            (12, '0114', 'Semillas oleaginosas, nueces y granos'),
                                            (13, '01144', 'Soja'),
                                            (14, '0115', 'Semillas de campo excluidas semillas oleaginosas'),
                                            (15, '0119', 'Cultivos de campo misceláneos'),
                                            (16, '01193', 'Tabaco de hoja'),
                                            (17, '01195', 'Patatas distintas de las dulces'),
                                            (18, '01197', 'Remolacha azucarera'),
                                            (19, '012', 'Frutas frescas y nueces de árbol'),
                                            (20, '0121', 'Frutas cítricas'),
                                            (21, '0122', 'Frutos caducifolios'),
                                            (22, '01221', 'Manzanas'),
                                            (23, '01224', 'Uvas'),
                                            (24, '01226', 'Melocotones'),
                                            (25, '0123', 'Frutas tropicales excluidos cítricos'),
                                            (26, '01232', 'Plátanos'),
                                            (27, '0129', 'Varias frutas frescas y nueces'),
                                            (28, '01295', 'Café verde'),
                                            (29, '013', 'Vegetales frescos'),
                                            (30, '0131', 'Bulbos, raíces y tubérculos'),
                                            (31, '01318', 'Cebollas secas'),
                                            (32, '0133', 'Verduras frescas de hoja'),
                                            (33, '01334', 'Apio'),
                                            (34, '01335', 'Lechuga'),
                                            (35, '0134', 'Semillas de verduras maduras secas, etc.'),
                                            (36, '01341', 'Frijoles maduros secos'),
                                            (37, '01342', 'Guisantes secos'),
                                            (38, '0139', 'Verduras frescas varias'),
                                            (39, '01392', 'Sandías'),
                                            (40, '01394', 'Tomates'),
                                            (41, '01398', 'Melones excluyendo sandías'),
                                            (42, '014', 'Ganadería y ganadería'),
                                            (43, '0141', 'Ganado'),
                                            (44, '01411', 'Vacas'),
                                            (45, '01413', 'Porcinos, jabalíes y cerdos'),
                                            (46, '01414', 'Ovejas y corderos'),
                                            (47, '0142', 'Granja lechera'),
                                            (48, '0143', 'Fibras animales'),
                                            (49, '01431', 'Lana'),
                                            (50, '015', 'Aves de corral'),
                                            (51, '0151', 'Aves de corral vivas'),
                                            (52, '0152', 'Huevos de aves de corral'),
                                            (53, '019', 'Productos agrícolas varios'),
                                            (54, '0191', 'Especialidades hortícolas'),
                                            (55, '0192', 'Especialidades animales'),
                                            (56, '08', 'Productos extranjeros'),
                                            (57, '084', 'Gomas y cortezas, crudas'),
                                            (58, '08423', 'Látex y encías afines'),
                                            (59, '086', 'Productos forestales diversos'),
                                            (60, '09', 'Pescado fresco'),
                                            (61, '091', 'Pescado fresco y productos marinos'),
                                            (62, '0912', 'Pescado y ballena'),
                                            (63, '09131', 'Conchas (ostras, cangrejos, etc.)'),
                                            (64, '098', 'Criaderos de peces, granjas'),
                                            (65, '10', 'Minerales metálicos'),
                                            (66, '101', 'Minerales de hierro'),
                                            (67, '10112', 'Beneficio de mineral de grado'),
                                            (68, '102', 'Minerales de cobre'),
                                            (69, '103', 'Minerales de plomo y zinc'),
                                            (70, '1031', 'Minerales de plomo'),
                                            (71, '1032', 'Minerales de zinc'),
                                            (72, '104', 'Minerales de oro y plata'),
                                            (73, '105', 'Minerales de bauxita y aluminio'),
                                            (74, '106', 'Minerales de manganeso'),
                                            (75, '107', 'Minerales de tungsteno'),
                                            (76, '108', 'Minerales de cromo'),
                                            (77, '109', 'Minerales metálicos misceláneos'),
                                            (78, '11', 'Carbón'),
                                            (79, '111', 'Antracita'),
                                            (80, '11111', 'Antracita cruda'),
                                            (81, '11112', 'Antracita limpia'),
                                            (82, '112', 'Carbón bituminoso y lignito'),
                                            (83, '1121', 'Carbón bituminoso'),
                                            (84, '13', 'Petróleo crudo y gasolina natural'),
                                            (85, '131', 'Petróleo crudo y GNL'),
                                            (86, '132', 'Gasolina natural'),
                                            (87, '14', 'Minerales no metálicos'),
                                            (88, '141', 'Piedra de dimensión, cantera'),
                                            (89, '142', 'Piedra triturada y rota'),
                                            (90, '14211', 'Caliza agrícola'),
                                            (91, '14212', 'Piedra fundente o cales'),
                                            (92, '14219', 'Piedra triturada y rota'),
                                            (93, '144', 'Arena y grava'),
                                            (94, '14411', 'Arena (agregado y lastre)'),
                                            (95, '14412', 'Grava (agregado y lastre)'),
                                            (96, '14413', 'Arena industrial cruda'),
                                            (97, '145', 'Arcilla, cerámica y refractaria'),
                                            (98, '14511', 'Bentonita bruta'),
                                            (99, '14512', 'Arcilla de fuego cruda'),
                                            (100, '14514', 'Bola bruta y arcilla de caolín'),
                                            (101, '147', 'Minerales químicos y fertilizantes'),
                                            (102, '14711', 'Barita cruda'),
                                            (103, '14713', 'Borato crudo, potasa y soda'),
                                            (104, '14714', 'Roca de apatita y fosfato'),
                                            (105, '14715', 'Sal de roca bruta'),
                                            (106, '14716', 'Azufre crudo'),
                                            (107, '149', 'Minerales no metálicos misceláneos'),
                                            (108, '14911', 'Anhidrita bruta y yeso'),
                                            (109, '14913', 'Asfalto y betunes nativos'),
                                            (110, '14914', 'Piedra pómez y pumicita cruda'),
                                            (111, '19', 'Artillería'),
                                            (112, '191', 'Armas, obuses y morteros'),
                                            (113, '192', 'Municiones, más de 30 mm'),
                                            (114, '193', 'Vehículos de combate con orugas completas'),
                                            (115, '194', 'Equipo de avistamiento y control de incendios'),
                                            (116, '195', 'Brazos pequeños, LTE 30 mm'),
                                            (117, '196', 'Munición para armas pequeñas, LTE 30 mm'),
                                            (118, '199', 'Miscelánea de municiones y accesorios'),
                                            (119, '20', 'Productos alimenticios'),
                                            (120, '201', 'Carne y aves de corral'),
                                            (121, '2011', 'Carne, fresca o refrigerada'),
                                            (122, '2012', 'Carne fresca congelada'),
                                            (123, '2013', 'Productos de carne'),
                                            (124, '2014', 'Subproductos animales no comestibles'),
                                            (125, '20141', 'Cueros y pieles, sin curtir'),
                                            (126, '2015', 'Aves frescas aliñadas'),
                                            (127, '2016', 'Aves de corral congeladas'),
                                            (128, '2017', 'Aves procesadas y caza menor'),
                                            (129, '202', 'Productos lácteos'),
                                            (130, '2021', 'Crema de mantequilla'),
                                            (131, '2023', 'Evaporar leche en polvo condensada'),
                                            (132, '2024', 'Helados y postres helados'),
                                            (133, '2025', 'Queso y lácteos especiales prd'),
                                            (134, '2026', 'Leche y nata procesadas'),
                                            (135, '203', 'Alimentos enlatados y en conserva'),
                                            (136, '2031', 'Mariscos enlatados y curados'),
                                            (137, '2032', 'Especialidades enlatadas'),
                                            (138, '2033', 'Frutas, verduras y mermeladas enlatadas'),
                                            (139, '2034', 'Frutas y verduras secas y deshidratadas'),
                                            (140, '2035', 'Frutas y verduras en escabeche, salsas'),
                                            (141, '2036', 'Pescado envasado'),
                                            (142, '2037', 'Frutas, jugos y verduras congeladas'),
                                            (143, '2038', 'Especialidades congeladas'),
                                            (144, '2039', 'Frutas y verduras enlatadas y en conserva'),
                                            (145, '204', 'Productos de molino de grano'),
                                            (146, '2041', 'Molino de harina y otros granos prd'),
                                            (147, '20411', 'Harina de trigo excl. Mezclada'),
                                            (148, '20412', 'Salvado de trigo'),
                                            (149, '20421', 'Pienso preparado para animales'),
                                            (150, '20423', 'Alimentos enlatados para animales'),
                                            (151, '2043', 'Preparaciones de cereales'),
                                            (152, '2044', 'Harina, harina y arroz molidos'),
                                            (153, '2045', 'Harina mezclada y preparada'),
                                            (154, '2046', 'Productos de molienda de maíz húmedo'),
                                            (155, '20461', 'Jarabe de maíz'),
                                            (156, '20462', 'Maicena'),
                                            (157, '20463', 'Azúcar de maíz'),
                                            (158, '20471', 'Alimentos para mascotas no enlatados'),
                                            (159, '20472', 'Alimentos enlatados para mascotas'),
                                            (160, '205', 'Productos de panadería'),
                                            (161, '206', 'Azúcar'),
                                            (162, '2061', 'Prd y subproductos de molino de azúcar'),
                                            (163, '20611', 'Azúcar crudo de caña y remolacha'),
                                            (164, '20616', 'Melazas de azúcar, exc blackstrap'),
                                            (165, '20617', 'Melaza'),
                                            (166, '2062', 'Azúcar refinado de caña y remolacha'),
                                            (167, '20625', 'Subproductos del refino de azúcar'),
                                            (168, '20626', 'Pulpa, melaza, remolacha'),
                                            (169, '207', 'Confitería y prd relacionados'),
                                            (170, '208', 'Bebidas y extractos'),
                                            (171, '20821', 'Cerveza, ale, porter, grueso'),
                                            (172, '20823', 'Cerveceros granos gastados'),
                                            (173, '2083', 'Malta'),
                                            (174, '2084', 'Vinos, brandy, licores'),
                                            (175, '20851', 'Licores destilados y mezclados'),
                                            (176, '20859', 'Destilados de licor'),
                                            (177, '2086', 'Refrescos enlatados'),
                                            (178, '2087', 'Extractos misceláneos sin chocolate'),
                                            (179, '209', 'Preparaciones alimenticias diversas'),
                                            (180, '20911', 'Aceite de algodón'),
                                            (181, '20914', 'Pastel o harina de semillas de algodón'),
                                            (182, '20921', 'Aceite de soja'),
                                            (183, '20923', 'Pastel o harina de soja'),
                                            (184, '2093', 'Aceites vegetales y de nueces'),
                                            (185, '2094', 'Grasas y aceites marinos'),
                                            (186, '2095', 'Café tostado'),
                                            (187, '2096', 'Manteca, aceites de mesa, etc.'),
                                            (188, '2097', 'Hielo, natural o elaborado'),
                                            (189, '2098', 'Macarrones, espaguetis, etc.'),
                                            (190, '21', 'Productos de tabaco'),
                                            (191, '211', 'Cigarrillos'),
                                            (192, '212', 'Puros'),
                                            (193, '213', 'Mascar y fumar tabaco'),
                                            (194, '214', 'Tabaco despalillado y resecado'),
                                            (195, '22', 'Productos textiles para fábricas'),
                                            (196, '221', 'Tejidos anchos de algodón'),
                                            (197, '222', 'Fibra y seda artificiales'),
                                            (198, '223', 'Tejidos anchos de lana'),
                                            (199, '224', 'Tejidos estrechos'),
                                            (200, '225', 'Tejidos de punto'),
                                            (201, '227', 'Revestimientos de suelo, textiles'),
                                            (202, '228', 'Hilo e hilo'),
                                            (203, '229', 'Productos textiles diversos'),
                                            (204, '2296', 'Cordones y tejidos para neumáticos'),
                                            (205, '2297', 'Lana y mohair'),
                                            (206, '2298', 'Cordaje y bramante'),
                                            (207, '23', 'Ropa y otros textiles acabados'),
                                            (208, '231', 'Ropa para hombres y niños'),
                                            (209, '233', 'Ropa para mujeres, niñas y bebés'),
                                            (210, '235', 'Sombrerería, sombreros y gorras'),
                                            (211, '237', 'Artículos de piel'),
                                            (212, '238', 'Ropa y accesorios misceláneos'),
                                            (213, '239', 'Textil fabricado misceláneo'),
                                            (214, '24', 'Madera y productos de madera'),
                                            (215, '241', 'Productos forestales primarios'),
                                            (216, '24114', 'Troncos de madera para pasta'),
                                            (217, '24115', 'Astillas de madera'),
                                            (218, '24116', 'Postes, postes y pilotes de madera'),
                                            (219, '242', 'Aserradero y cepillado prd'),
                                            (220, '2421', 'Stock de madera y dimensiones'),
                                            (221, '24212', 'Corbatas aserradas'),
                                            (222, '2429', 'Varios aserradores y plng mill prd'),
                                            (223, '243', 'Carpintería, chapa, madera contrachapada'),
                                            (224, '2431', 'Carpintería'),
                                            (225, '2432', 'Chapa y madera contrachapada'),
                                            (226, '244', 'Contenedores de madera'),
                                            (227, '249', 'Productos de madera diversos'),
                                            (228, '2491', 'Madera creosotada o tratada con aceite'),
                                            (229, '25', 'Muebles y Accesorios'),
                                            (230, '251', 'Mobiliario de hogar y oficina'),
                                            (231, '253', 'Edificio público y mobiliario rltd'),
                                            (232, '254', 'Tabiques, estanterías, taquillas'),
                                            (233, '259', 'Mobiliario y accesorios varios'),
                                            (234, '26', 'Productos de pulpa y papel'),
                                            (235, '261', 'Productos de pulpa y plantas de celulosa'),
                                            (236, '26111', 'Pulpa'),
                                            (237, '262', 'Papel, excepto papel de construcción'),
                                            (238, '26211', 'Papel prensa'),
                                            (239, '26212', 'Papel para madera molida, sin revestimiento'),
                                            (240, '26213', 'Papel para imprimir'),
                                            (241, '26214', 'Papel de regalo'),
                                            (242, '26217', 'Papel industrial especial'),
                                            (243, '26218', 'Stock de tejido sanitario'),
                                            (244, '263', 'Cartón, pulpbrd y fiberbrd'),
                                            (245, '264', 'Papel y papel convertidos brd prd'),
                                            (246, '2643', 'Bolsas de papel'),
                                            (247, '26471', 'Tejidos sanitarios / salud prd'),
                                            (248, '265', 'Envases de cartón'),
                                            (249, '266', 'Papel de construcción y cartón para edificios'),
                                            (250, '26613', 'Tablero'),
                                            (251, '27', 'Impresos'),
                                            (252, '271', 'Periódicos'),
                                            (253, '272', 'Publicaciones periódicas'),
                                            (254, '273', 'Libros'),
                                            (255, '274', 'Material impreso misceláneo'),
                                            (256, '276', 'Formularios comerciales múltiples'),
                                            (257, '277', 'Tarjetas de felicitación, sellos, etiquetas.'),
                                            (258, '278', 'Libros en blanco, carpetas de hojas sueltas'),
                                            (259, '279', 'Productos de industrias de servicios'),
                                            (260, '28', 'Químicos'),
                                            (261, '281', 'Productos químicos industriales, org / inorg'),
                                            (262, '2812', 'Sodio, ptsm y otros químicos inorgánicos'),
                                            (263, '28123', 'Sodio cpd, exc alcalinos'),
                                            (264, '2813', 'Gases industriales comprimidos'),
                                            (265, '2814', 'Prd crudo de alquitrán de carbón'),
                                            (266, '2816', 'Pigmentos inorgánicos'),
                                            (267, '2818', 'Sustancias químicas orgánicas diversas'),
                                            (268, '28184', 'Alcoholes'),
                                            (269, '2819', 'Varios productos químicos de inorg industriales'),
                                            (270, '28193', 'Ácido sulfurico'),
                                            (271, '282', 'Plásticos y resinas sintéticas'),
                                            (272, '28212', 'Caucho sintético'),
                                            (273, '28213', 'Fibras sintéticas'),
                                            (274, '283', 'Medicamentos y farmacéuticos prd'),
                                            (275, '284', 'Preparaciones de limpieza y jabón'),
                                            (276, '2841', 'Jabón y otros detergentes'),
                                            (277, '285', 'Pinturas, barnices y lacas'),
                                            (278, '286', 'Productos químicos de goma y madera'),
                                            (279, '287', 'Químicos agriculturales'),
                                            (280, '2871', 'Fertilizantes'),
                                            (281, '289', 'Productos químicos misceláneos'),
                                            (282, '2892', 'Explosivos'),
                                            (283, '28991', 'Sal común'),
                                            (284, '29', 'Productos de petróleo y carbón'),
                                            (285, '291', 'Productos de refino de petróleo'),
                                            (286, '29111', 'Gasolina, combustible para aviones, etc.'),
                                            (287, '29112', 'Queroseno'),
                                            (288, '29113', 'Aceite combustible destilado'),
                                            (289, '29114', 'Aceites lubricantes y similares'),
                                            (290, '29115', 'Grasas lubricantes'),
                                            (291, '29116', 'Asfalto, alquitrán y brea'),
                                            (292, '29117', 'Aceite combustible residual'),
                                            (293, '29119', 'Prd de refino de gasolina, nec'),
                                            (294, '2912', 'Gases licuados del petróleo'),
                                            (295, '295', 'Materiales de pavimentación y techado'),
                                            (296, '2951', 'Bloques y mezclas de pavimento de asfalto'),
                                            (297, '2952', 'Fieltro y revestimientos asfálticos'),
                                            (298, '299', 'Varios petróleo y carbón'),
                                            (299, '29911', 'Briquetas de carbón y coque'),
                                            (300, '29913', 'Coque de gasolina sin briquetas'),
                                            (301, '29914', 'Coque producido a partir del carbón'),
                                            (302, '30', 'Productos de caucho y plástico'),
                                            (303, '301', 'Neumáticos y cámaras de aire'),
                                            (304, '302', 'Calzado de caucho y plástico'),
                                            (305, '303', 'Caucho recuperado'),
                                            (306, '304', 'Mangueras y correas de caucho y plástico'),
                                            (307, '306', 'Caucho fabricado misceláneo'),
                                            (308, '307', 'Productos diversos de plástico'),
                                            (309, '31', 'Cuero y productos de cuero'),
                                            (310, '311', 'Cuero'),
                                            (311, '312', 'Cinturones de cuero industriales'),
                                            (312, '313', 'Stock de corte de bota y zapato'),
                                            (313, '314', 'Calzado, excepto caucho o plástico'),
                                            (314, '315', 'Guantes y manoplas de cuero'),
                                            (315, '316', 'Equipaje, bolsos'),
                                            (316, '319', 'Marroquinería miscelánea'),
                                            (317, '32', 'Productos de piedra, arcilla y vidrio'),
                                            (318, '321', 'Vidrio plano'),
                                            (319, '322', 'Vidrio y cristalería'),
                                            (320, '3221', 'Contenedores de vidrio'),
                                            (321, '324', 'Cemento hidráulico'),
                                            (322, '32411', 'Cemento, hydlc, portland, nat'),
                                            (323, '325', 'Productos de arcilla estructural'),
                                            (324, '3251', 'Ladrillos y teja de arcilla estructural'),
                                            (325, '32511', 'Ladrillos y bloques, arcilla y pizarra'),
                                            (326, '3253', 'Baldosas y baldosas de cerámica'),
                                            (327, '3255', 'Refractarios, arcilla y no arcilla.'),
                                            (328, '3259', 'Productos misceláneos de arcilla estructural'),
                                            (329, '32594', 'Teja de arcilla'),
                                            (330, '326', 'Cerámica y productos relacionados'),
                                            (331, '327', 'Hormigón, yeso y yeso prd'),
                                            (332, '3271', 'Prd de hormigón'),
                                            (333, '3274', 'Yeso de cal y cal'),
                                            (334, '3275', 'Productos de yeso'),
                                            (335, '328', 'Cortar piedra y productos de piedra'),
                                            (336, '329', 'Abrasivos, amianto y misceláneas'),
                                            (337, '3291', 'Productos abrasivos'),
                                            (338, '3295', 'Tierras o minerales no metidos'),
                                            (339, '33', 'Productos de metales primarios'),
                                            (340, '331', 'Acerías y laminación prd'),
                                            (341, '33111', 'Arrabio'),
                                            (342, '33112', 'Escoria de horno'),
                                            (343, '33119', 'Horno de coque y blast furn prd'),
                                            (344, '3312', 'Prd de hierro y acero primario'),
                                            (345, '33121', 'Lingote de acero y semiacabado'),
                                            (346, '3313', 'Prd electrometalúrgico'),
                                            (347, '3315', 'Alambre de acero, clavos y púas'),
                                            (348, '332', 'Fundiciones de hierro y acero'),
                                            (349, '33211', 'Tubo de fundición de hierro y acero'),
                                            (350, '333', 'Productos de fundición no ferrosos'),
                                            (351, '3331', 'Cobre, latón o bronce'),
                                            (352, '3332', 'Productos de fundición de plomo'),
                                            (353, '3333', 'Productos de fundición de zinc'),
                                            (354, '3334', 'Productos de fundición de aluminio'),
                                            (355, '335', 'Formas básicas de metales no ferrosos'),
                                            (356, '3351', 'Cobre, latón o bronce'),
                                            (357, '3352', 'Aluminio'),
                                            (358, '3357', 'Metal no ferroso y aislado'),
                                            (359, '336', 'Piezas fundidas no ferrosas'),
                                            (360, '3361', 'Aleación a base de aluminio y alumbre'),
                                            (361, '3362', 'Latón, bronce, cobre y cba'),
                                            (362, '339', 'Productos varios de metales primarios'),
                                            (363, '3391', 'Forjas de hierro y acero'),
                                            (364, '3392', 'Forjas de metales no ferrosos'),
                                            (365, '34', 'Productos de metal fabricados'),
                                            (366, '341', 'Latas de metal'),
                                            (367, '342', 'Cubiertos, herramientas manuales y ferretería'),
                                            (368, '343', 'Fontanería fxtrs y calefacción'),
                                            (369, '3433', 'Equipo de calefacción, exc eléctrico'),
                                            (370, '344', 'Prd metal estructural fabricado'),
                                            (371, '3441', 'Productos metálicos estructurales fabricados'),
                                            (372, '34411', 'Hierro o acero estructural fabricado'),
                                            (373, '345', 'Pernos, tuercas, tornillos, remaches'),
                                            (374, '346', 'Estampado de metal'),
                                            (375, '348', 'Productos diversos de alambre fabricado'),
                                            (376, '349', 'Productos metálicos diversos'),
                                            (377, '3491', 'Contenedores de transporte metálicos'),
                                            (378, '3494', 'Válvulas y accesorios de tubería'),
                                            (379, '35', 'Maquinaria, excepto eléctrica'),
                                            (380, '351', 'Motores y turbinas'),
                                            (381, '352', 'Maquinaria y equipo agrícola'),
                                            (382, '3524', 'Tractores y equipos de jardín'),
                                            (383, '353', 'Construcción, minería y materiales hndlng'),
                                            (384, '3531', 'Maquinaria y equipo de construcción'),
                                            (385, '3532', 'Maquinaria y equipo para minería'),
                                            (386, '3533', 'Maquinaria y equipo para campos petroleros'),
                                            (387, '3537', 'Camiones y tractores industriales'),
                                            (388, '354', 'Maquinaria y equipo para metalurgia'),
                                            (389, '355', 'Maquinaria industrial especial'),
                                            (390, '356', 'Maquinaria industrial general'),
                                            (391, '357', 'Equipo de oficina e informática'),
                                            (392, '358', 'Máquinas de la industria de servicios'),
                                            (393, '359', 'Maquinaria no eléctrica, nec'),
                                            (394, '36', 'Maquina eléctrica, equipo y alimentación'),
                                            (395, '361', 'Equipo de transmisión y distribución eléctrica'),
                                            (396, '362', 'Aparatos industriales eléctricos'),
                                            (397, '363', 'Electrodomésticos'),
                                            (398, '3631', 'Equipo de cocina para el hogar'),
                                            (399, '3632', 'Refrigeradores y congeladores domésticos'),
                                            (400, '3633', 'Equipo de lavandería para el hogar'),
                                            (401, '364', 'Equipo de iluminación y cableado eléctrico'),
                                            (402, '365', 'Aparatos de radio y televisión'),
                                            (403, '366', 'Equipo de comunicación'),
                                            (404, '367', 'Componentes electrónicos'),
                                            (405, '369', 'Varios equipos eléctricos'),
                                            (406, '37', 'Equipo de transporte'),
                                            (407, '371', 'Vehículos de motor y equipar'),
                                            (408, '3711', 'Vehículos de motor ensamblados'),
                                            (409, '37111', 'Carros pasajeros'),
                                            (410, '37112', 'Camiones tractores y camiones'),
                                            (411, '37113', 'Autocares, asd, departamento de bomberos'),
                                            (412, '3712', 'Carrocerías de turismos'),
                                            (413, '3713', 'Carrocerías de camiones y autobuses'),
                                            (414, '3714', 'Piezas de vehículos de motor'),
                                            (415, '37147', 'Partes de carrocería de vehículos de motor'),
                                            (416, '3715', 'Remolques de camiones'),
                                            (417, '372', 'Aeronaves y piezas'),
                                            (418, '373', 'Barcos y embarcaciones'),
                                            (419, '374', 'Equipo de ferrocarril'),
                                            (420, '37422', 'Vagones de tren de mercancías'),
                                            (421, '375', 'Motocicletas, bicicletas y repuestos'),
                                            (422, '376', 'Piezas de vehículos espaciales'),
                                            (423, '379', 'Transporte misceláneo'),
                                            (424, '38', 'Instrumentos y artículos ópticos'),
                                            (425, '381', 'Instrucción de ingeniería, laboratorio y ciencias'),
                                            (426, '382', 'Manómetros, medidores y controles'),
                                            (427, '383', 'Instrumentos ópticos y lentes'),
                                            (428, '384', 'Instrucción quirúrgica, médica y dental'),
                                            (429, '385', 'Productos oftálmicos u ópticos'),
                                            (430, '386', 'Equipo y suministros fotográficos'),
                                            (431, '387', 'Relojes, relojes, dispositivos y piezas'),
                                            (432, '39', 'Productos de fabricación misceláneos'),
                                            (433, '391', 'Joyas, platería y baño'),
                                            (434, '393', 'Instrumentos musicales y partes'),
                                            (435, '394', 'Juguetes, diversión y equipamiento deportivo'),
                                            (436, '3949', 'Artículos deportivos y deportivos'),
                                            (437, '395', 'Bolígrafos, lápices y matl de oficina'),
                                            (438, '396', 'Bisutería, novedades'),
                                            (439, '399', 'Productos manufacturados misceláneos'),
                                            (440, '40', 'Materiales de desecho y desecho'),
                                            (441, '401', 'Despojos mortales'),
                                            (442, '402', 'Desperdicios y desechos, excepto cenizas'),
                                            (443, '4021', 'Chatarra, desechos y relaves de metal'),
                                            (444, '40211', 'Desechos, desechos de hierro y acero'),
                                            (445, '4022', 'Desechos y desechos textiles'),
                                            (446, '4024', 'Desechos y desperdicios de papel'),
                                            (447, '4026', 'Residuos y desechos de caucho y plástico'),
                                            (448, '41', 'Envíos de carga misceláneos'),
                                            (449, '411', 'Envíos de carga misceláneos'),
                                            (450, '41111', 'Conjuntos o kits'),
                                            (451, '41114', 'Artículos, usados, excl códigos'),
                                            (452, '41115', 'Artículos, usados, rtd para reparación'),
                                            (453, '412', 'Productos varios'),
                                            (454, '42', 'Contenedores y remolques vacíos'),
                                            (455, '421', 'Envases vacíos nonrev'),
                                            (456, '422', 'Remolques vacíos'),
                                            (457, '423', 'Ingresos remolques vacíos'),
                                            (458, '44', 'Tráfico de transporte de carga'),
                                            (459, '441', 'Tráfico de transitarios'),
                                            (460, '45', 'Transporte asociado o tráfico similar'),
                                            (461, '451', 'Remitente de tráfico'),
                                            (462, '46', 'Envíos mixtos misceláneos'),
                                            (463, '461', 'Envíos mixtos misceláneos'),
                                            (464, '462', 'Envíos varios mixtos, 2 productos'),
                                            (465, '48', 'Residuos peligrosos');"



    'PorteColonia
    Public vartablaportecolonia As String = "CREATE TABLE IF NOT EXISTS `portecolonia` (
                                                  `Id` int(11) NOT NULL,
                                                  `ClaveColonia` varchar(20) NOT NULL DEFAULT '',
                                                  `CP` varchar(20) NOT NULL DEFAULT '',
                                                  `Nombre` varchar(255) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteConfigAutotrans
    Public vartablaporteconfigautotrans As String = "CREATE TABLE IF NOT EXISTS `porteconfigautotrans` (
                                              `Id` int(11) NOT NULL,
                                              `Clave` varchar(30) NOT NULL DEFAULT '',
                                              `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                              `NumEjes` varchar(20) NOT NULL DEFAULT '',
                                              `NumLlantas` varchar(20) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaporteconfigautotrans As String = "INSERT INTO `porteconfigautotrans` (`Id`, `Clave`, `Descripcion`, `NumEjes`, `NumLlantas`) VALUES
                                                        (1, 'C2', 'Camión Unitario (2 llantas en el eje delantero y 4 llantas en el eje trasero)', '02', '6'),
                                                        (2, 'C3', 'Camión Unitario (2 llantas en el eje delantero y 6 o 8 llantas en los dos ejes traseros)', '03', '8 o 10'),
                                                        (3, 'C2R2', 'Camión-Remolque (6 llantas en el camión y 8 llantas en remolque)', '04', '14'),
                                                        (4, 'C3R2', 'Camión-Remolque (10 llantas en el camión y 8 llantas en remolque)', '05', '18'),
                                                        (5, 'C2R3', 'Camión-Remolque (6 llantas en el camión y 12 llantas en remolque)', '05', '18'),
                                                        (6, 'C3R3', 'Camión-Remolque (10 llantas en el camión y 12 llantas en remolque)', '06', '22'),
                                                        (7, 'T2S1', 'Tractocamión Articulado (6 llantas en el tractocamión, 4 llantas en el semirremolque)', '03', '10'),
                                                        (8, 'T2S2', 'Tractocamión Articulado (6 llantas en el tractocamión, 8 llantas en el semirremolque)', '04', '14'),
                                                        (9, 'T2S3', 'Tractocamión Articulado (6 llantas en el tractocamión, 12 llantas en el semirremolque)', '05', '18'),
                                                        (10, 'T3S1', 'Tractocamión Articulado (10 llantas en el tractocamión, 4 llantas en el semirremolque)', '04', '14'),
                                                        (11, 'T3S2', 'Tractocamión Articulado (10 llantas en el tractocamión, 8 llantas en el semirremolque)', '05', '18'),
                                                        (12, 'T3S3', 'Tractocamión Articulado (10 llantas en el tractocamión, 12 llantas en el semirremolque)', '06', '22'),
                                                        (13, 'T2S1R2', 'Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)', '05', '18'),
                                                        (14, 'T2S2R2', 'Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)', '06', '22'),
                                                        (15, 'T2S1R3', 'Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)', '06', '22'),
                                                        (16, 'T3S1R2', 'Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)', '06', '22'),
                                                        (17, 'T3S1R3', 'Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)', '07', '26'),
                                                        (18, 'T3S2R2', 'Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)', '07', '26'),
                                                        (19, 'T3S2R3', 'Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 12 llantas en el remolque)', '08', '30'),
                                                        (20, 'T3S2R4', 'Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 16 llantas en el remolque)', '09', '34'),
                                                        (21, 'T2S2S2', 'Tractocamión Semirremolque-Semirremolque (6 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)', '06', '22'),
                                                        (22, 'T3S2S2', 'Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)', '07', '26'),
                                                        (23, 'T3S3S2', 'Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 12 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)', '08', '30'),
                                                        (24, 'OTROEV', 'Especializado de Voluminoso', '', ''),
                                                        (25, 'OTROEGP', 'Especializado de Gran Peso', '', ''),
                                                        (26, 'OTROSG', 'Servicio de Grúas', '', '');"



    'PorteDestino
    Public vartablaportedestino As String = "CREATE TABLE IF NOT EXISTS `portedestino` (
                                          `Id` int(11) NOT NULL,
                                          `Destinatario` varchar(255) NOT NULL DEFAULT '',
                                          `RFC` varchar(30) NOT NULL DEFAULT '',
                                          `CP` varchar(20) NOT NULL DEFAULT '',
                                          `Pais` varchar(100) NOT NULL DEFAULT '',
                                          `Calle` varchar(255) NOT NULL DEFAULT '',
                                          `NumE` varchar(20) NOT NULL DEFAULT '',
                                          `NumI` varchar(20) NOT NULL DEFAULT '',
                                          `Colonia` varchar(150) NOT NULL DEFAULT '',
                                          `Edo` varchar(150) NOT NULL DEFAULT '',
                                          `Mun` varchar(100) NOT NULL DEFAULT '',
                                          `Loc` varchar(20) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteEstados
    Public vartablaporteestados As String = "CREATE TABLE IF NOT EXISTS `porteestados` (
                                              `Id` int(11) NOT NULL,
                                              `ClaveEdo` varchar(10) NOT NULL DEFAULT '',
                                              `Pais` varchar(80) NOT NULL DEFAULT '',
                                              `Nombre` varchar(255) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaporteestados As String = "INSERT INTO `porteestados` (`Id`, `ClaveEdo`, `Pais`, `Nombre`) VALUES
                                                (1, 'AGU', 'MEX', 'Aguascalientes'),
                                                (2, 'BC', 'MEX', 'Baja California'),
                                                (3, 'BCS', 'MEX', 'Baja California Sur'),
                                                (4, 'CAM', 'MEX', 'Campeche'),
                                                (5, 'CHP', 'MEX', 'Chiapas'),
                                                (6, 'CHH', 'MEX', 'Chihuahua'),
                                                (7, 'COA', 'MEX', 'Coahuila'),
                                                (8, 'COL', 'MEX', 'Colima'),
                                                (9, 'DIF', 'MEX', 'Ciudad de México'),
                                                (10, 'DUR', 'MEX', 'Durango'),
                                                (11, 'GUA', 'MEX', 'Guanajuato'),
                                                (12, 'GRO', 'MEX', 'Guerrero'),
                                                (13, 'HID', 'MEX', 'Hidalgo'),
                                                (14, 'JAL', 'MEX', 'Jalisco'),
                                                (15, 'MEX', 'MEX', 'Estado de México'),
                                                (16, 'MIC', 'MEX', 'Michoacán'),
                                                (17, 'MOR', 'MEX', 'Morelos'),
                                                (18, 'NAY', 'MEX', 'Nayarit'),
                                                (19, 'NLE', 'MEX', 'Nuevo León'),
                                                (20, 'OAX', 'MEX', 'Oaxaca'),
                                                (21, 'PUE', 'MEX', 'Puebla'),
                                                (22, 'QUE', 'MEX', 'Querétaro'),
                                                (23, 'ROO', 'MEX', 'Quintana Roo'),
                                                (24, 'SLP', 'MEX', 'San Luis Potosí'),
                                                (25, 'SI', 'MEX', 'Sinaloa'),
                                                (26, 'SO', 'MEX', 'Sonora'),
                                                (27, 'TAB', 'MEX', 'Tabasco'),
                                                (28, 'TAM', 'MEX', 'Tamaulipas'),
                                                (29, 'TLA', 'MEX', 'Tlaxcala'),
                                                (30, 'VER', 'MEX', 'Veracruz'),
                                                (31, 'YUC', 'MEX', 'Yucatán'),
                                                (32, 'ZAC', 'MEX', 'Zacatecas'),
                                                (33, 'AL', 'USA', 'Alabama'),
                                                (34, 'AK', 'USA', 'Alaska'),
                                                (35, 'AZ', 'USA', 'Arizona'),
                                                (36, 'AR', 'USA', 'Arkansas'),
                                                (37, 'CA', 'USA', 'California'),
                                                (38, 'NC', 'USA', 'Carolina del Norte'),
                                                (39, 'SC', 'USA', 'Carolina del Sur'),
                                                (40, 'CO', 'USA', 'Colorado'),
                                                (41, 'CT', 'USA', 'Connecticut'),
                                                (42, 'ND', 'USA', 'Dakota del Norte'),
                                                (43, 'SD', 'USA', 'Dakota del Sur'),
                                                (44, 'DE', 'USA', 'Delaware'),
                                                (45, 'FL', 'USA', 'Florida'),
                                                (46, 'GA', 'USA', 'Georgia'),
                                                (47, 'HI', 'USA', 'Hawái'),
                                                (48, 'ID', 'USA', 'Idaho'),
                                                (49, 'IL', 'USA', 'Illinois'),
                                                (50, 'I', 'USA', 'Indiana'),
                                                (51, 'IA', 'USA', 'Iowa'),
                                                (52, 'KS', 'USA', 'Kansas'),
                                                (53, 'KY', 'USA', 'Kentucky'),
                                                (54, 'LA', 'USA', 'Luisiana'),
                                                (55, 'ME', 'USA', 'Maine'),
                                                (56, 'MD', 'USA', 'Maryland'),
                                                (57, 'MA', 'USA', 'Massachusetts'),
                                                (58, 'MI', 'USA', 'Míchigan'),
                                                (59, 'M', 'USA', 'Minnesota'),
                                                (60, 'MS', 'USA', 'Misisipi'),
                                                (61, 'MO', 'USA', 'Misuri'),
                                                (62, 'MT', 'USA', 'Montana'),
                                                (63, 'NE', 'USA', 'Nebraska'),
                                                (64, 'NV', 'USA', 'Nevada'),
                                                (65, 'NJ', 'USA', 'Nueva Jersey'),
                                                (66, 'NY', 'USA', 'Nueva York'),
                                                (67, 'NH', 'USA', 'Nuevo Hampshire'),
                                                (68, 'NM', 'USA', 'Nuevo México'),
                                                (69, 'OH', 'USA', 'Ohio'),
                                                (70, 'OK', 'USA', 'Oklahoma'),
                                                (71, 'OR', 'USA', 'Oregón'),
                                                (72, 'PA', 'USA', 'Pensilvania'),
                                                (73, 'RI', 'USA', 'Rhode Island'),
                                                (74, 'T', 'USA', 'Tennessee'),
                                                (75, 'TX', 'USA', 'Texas'),
                                                (76, 'UT', 'USA', 'Utah'),
                                                (77, 'VT', 'USA', 'Vermont'),
                                                (78, 'VA', 'USA', 'Virginia'),
                                                (79, 'WV', 'USA', 'Virginia Occidental'),
                                                (80, 'WA', 'USA', 'Washington'),
                                                (81, 'WI', 'USA', 'Wisconsin'),
                                                (82, 'WY', 'USA', 'Wyoming'),
                                                (83, 'O', 'CA', 'Ontario '),
                                                (84, 'QC', 'CA', ' Quebec '),
                                                (85, 'NS', 'CA', ' Nueva Escocia'),
                                                (86, 'NB', 'CA', 'Nuevo Brunswick '),
                                                (87, 'MB', 'CA', ' Manitoba'),
                                                (88, 'BC', 'CA', ' Columbia Británica'),
                                                (89, 'PE', 'CA', ' Isla del Príncipe Eduardo'),
                                                (90, 'SK', 'CA', ' Saskatchewan'),
                                                (91, 'AB', 'CA', ' Alberta'),
                                                (92, 'NL', 'CA', ' Terranova y Labrador'),
                                                (93, 'NT', 'CA', ' Territorios del Noroeste'),
                                                (94, 'YT', 'CA', ' Yukón'),
                                                (95, 'U', 'CA', ' Nunavut');"



    'PorteFigura
    Public vartablaportefigura As String = "CREATE TABLE IF NOT EXISTS `portefigura` (
                                              `Id` int(11) NOT NULL,
                                              `Clave` varchar(10) NOT NULL DEFAULT '',
                                              `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaportefigura As String = "INSERT INTO `portefigura` (`Id`, `Clave`, `Descripcion`) VALUES
                                                (1, '01', 'Operador'),
                                                (2, '02', 'Propietario'),
                                                (3, '03', 'Arrendador'),
                                                (4, '04', 'Notificado');"



    'PorteLocalidad
    Public vartablaportelocalidad As String = "CREATE TABLE IF NOT EXISTS `portelocalidad` (
                                              `Id` int(11) NOT NULL,
                                              `ClaveLocalidad` varchar(10) NOT NULL DEFAULT '',
                                              `ClaveEdo` varchar(20) NOT NULL DEFAULT '',
                                              `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteMatPeligrosos
    Public vartablaportematpeligrosos As String = "CREATE TABLE IF NOT EXISTS `portematpeligrosos` (
                                          `Id` int(11) NOT NULL,
                                          `ClaveMatPel` varchar(10) NOT NULL DEFAULT '',
                                          `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaportematpeligrosos As String = "INSERT INTO `portematpeligrosos` (`Id`, `ClaveMatPel`, `Descripcion`) VALUES
                                                (1, 'M0001', 'PICRATO AMÓNICO seco o humedecido con menos del 10 %, en masa, de agua (Producto o material explosivo)'),
                                                (2, 'M0002', 'CARTUCHOS PARA ARMAS, con carga explosiva (Producto o material explosivo)'),
                                                (3, 'M0003', 'CARTUCHOS PARA ARMAS, con carga explosiva (Producto o material explosivo)'),
                                                (4, 'M0004', 'CARTUCHOS PARA ARMAS, con carga explosiva (Producto o material explosivo)'),
                                                (5, 'M0005', 'MUNICIONES INCENDIARIAS con o sin carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (6, 'M0006', 'MUNICIONES INCENDIARIAS con o sin carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (7, 'M0007', 'CARTUCHOS PARA ARMAS, CON PROYECTIL INERTE, o CARTUCHOS PARA ARMAS DE PEQUEÑO CALIBRE (Producto o material explosivo)'),
                                                (8, 'M0008', 'CARTUCHOS DE FOGUEO PARA ARMAS, , o CARTUCHOS DE FOGUEO PARA ARMAS DE PEQUEÑO CALIBRE, o CARTUCHOS SIN CARGA PARA HERRAMIENTAS (Producto o material explosivo)'),
                                                (9, 'M0009', 'MUNICIONES FUMÍGENAS con o sin carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (10, 'M0010', 'MUNICIONES FUMÍGENAS con o sin carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (11, 'M0011', 'MUNICIONES LACRIMÓGENAS con carga dispersora, carga expulsora o carga propulsora  (Producto o material explosivo)'),
                                                (12, 'M0012', 'MUNICIONES LACRIMÓGENAS con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (13, 'M0013', 'MUNICIONES TÓXICAS con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (14, 'M0014', 'MUNICIONES TÓXICAS con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (15, 'M0015', 'PÓLVORA NEGRA (PÓLVORA DE CAÑÓN) en forma de granos o polvo (Producto o material explosivo)'),
                                                (16, 'M0016', 'PÓLVORA NEGRA (PÓLVORA DE CAÑÓN) COMPRIMIDA o PÓLVORA NEGRA (PÓLVORA DE CAÑÓN) EN COMPRIMIDOS (Producto o material explosivo)'),
                                                (17, 'M0017', 'DETONADORES NO ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (18, 'M0018', 'DETONADORES ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (19, 'M0019', 'BOMBAS con carga explosiva (Producto o material explosivo)'),
                                                (20, 'M0020', 'BOMBAS con carga explosiva (Producto o material explosivo)'),
                                                (21, 'M0021', 'BOMBAS con carga explosiva (Producto o material explosivo)'),
                                                (22, 'M0022', 'BOMBAS DE ILUMINACIÓN PARA FOTOGRAFÍA (Producto o material explosivo)'),
                                                (23, 'M0023', 'BOMBAS DE ILUMINACIÓN PARA FOTOGRAFÍA (Producto o material explosivo)'),
                                                (24, 'M0024', 'BOMBAS DE ILUMINACIÓN PARA FOTOGRAFÍA (Producto o material explosivo)'),
                                                (25, 'M0025', 'MULTIPLICADORES sin detonador (Producto o material explosivo)'),
                                                (26, 'M0026', 'CARGAS DISPERSORAS (Producto o material explosivo)'),
                                                (27, 'M0027', 'CEBOS DEL TIPO DE CÁPSULA (Producto o material explosivo)'),
                                                (28, 'M0028', 'CARGAS DE DEMOLICIÓN (Producto o material explosivo)'),
                                                (29, 'M0029', 'CARTUCHOS FULGURANTES (Producto o material explosivo)'),
                                                (30, 'M0030', 'CARTUCHOS FULGURANTES (Producto o material explosivo)'),
                                                (31, 'M0031', 'CARTUCHOS DE SEÑALES (Producto o material explosivo)'),
                                                (32, 'M0032', 'VAINAS DE CARTUCHOS VACÍOS, CON CEBO (Producto o material explosivo)'),
                                                (33, 'M0033', 'CARGAS DE PROFUNDIDAD (Producto o material explosivo)'),
                                                (34, 'M0034', 'CARGAS HUECAS sin detonador (Producto o material explosivo)'),
                                                (35, 'M0035', 'CARGAS EXPLOSIVAS PARA MULTIPLICADORES (Producto o material explosivo)'),
                                                (36, 'M0036', 'MECHA DETONANTE flexible (Producto o material explosivo)'),
                                                (37, 'M0037', 'MECHA DE COMBUSTIÓN RÁPIDA (Producto o material explosivo)'),
                                                (38, 'M0038', 'CORTACABLES CON CARGA EXPLOSIVA (Producto o material explosivo)'),
                                                (39, 'M0039', 'CICLOTRIMETILENTRINITRAMI NA (CICLONITA; RDX; HEXÓGENO) HUMEDECIDA con un mínimo del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (40, 'M0040', 'DETONADORES PARA MUNICIONES (Producto o material explosivo)'),
                                                (41, 'M0041', 'DIAZODINITROFENOL HUMEDECIDO con un mínimo del 40 %, en masa, de agua o de una mezcla de alcohol y agua (Producto o material explosivo)'),
                                                (42, 'M0042', 'DINITRATO DE DIETILENGLICOL DESENSIBILIZADO con un mínimo del 25 %, en masa, de flemador no volátil insoluble en agua (Producto o material explosivo)'),
                                                (43, 'M0043', 'DINITROFENOL seco o humedecido con menos del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (44, 'M0044', 'DINITROFENOLATOS de metales alcalinos, secos o humedecidos con\r\nmenos del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (45, 'M0045', 'DINITRORRESORCINOL seco o humedecido con menos del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (46, 'M0046', 'HEXANITRODIFENILAMINA (DIPICRILAMINA; HEXILO) (Producto o material explosivo)'),
                                                (47, 'M0047', 'EXPLOSIVOS PARA VOLADURAS, TIPO A (Producto o material explosivo)'),
                                                (48, 'M0048', 'EXPLOSIVOS PARA VOLADURAS, TIPO B (Producto o material explosivo)'),
                                                (49, 'M0049', 'EXPLOSIVOS PARA VOLADURAS, TIPO C (Producto o material explosivo)'),
                                                (50, 'M0050', 'EXPLOSIVOS PARA VOLADURAS, TIPO D (Producto o material explosivo)'),
                                                (51, 'M0051', 'BENGALAS DE SUPERFICIE (Producto o material explosivo)'),
                                                (52, 'M0052', 'BENGALAS AÉREAS (Producto o material explosivo)'),
                                                (53, 'M0053', 'PÓLVORA DE DESTELLOS (Producto o material explosivo)'),
                                                (54, 'M0054', 'DISPOSITIVOS EXPLOSIVOS DE FRACTURACIÓN sin detonador, para pozos de petróleo'),
                                                (55, 'M0055', 'MECHA NO DETONANTE (Producto o material explosivo)'),
                                                (56, 'M0056', 'MECHA DETONANTE con envoltura metálica (Producto o material explosivo)'),
                                                (57, 'M0057', 'MECHA DE IGNICIÓN, tubular, con envoltura metálica (Producto o material explosivo)'),
                                                (58, 'M0058', 'MECHA DETONANTE DE EFECTO REDUCIDO, con envoltura metálica (Producto o material explosivo)'),
                                                (59, 'M0059', 'MECHA DE SEGURIDAD (MECHA LENTA o MECHA BICKFORD) (Producto o material explosivo)'),
                                                (60, 'M0060', 'ESPOLETAS DETONANTES (Producto o material explosivo)'),
                                                (61, 'M0061', 'ESPOLETAS DETONANTES (Producto o material explosivo)'),
                                                (62, 'M0062', 'GRANADAS DE EJERCICIOS, de mano o de fusil (Producto o material explosivo)'),
                                                (63, 'M0063', 'GUANILNITROSAMINO- GUANILIDENHIDRAZINA HUMEDECIDA con un mínimo del 30 %, en masa, de agua (Producto o material explosivo)'),
                                                (64, 'M0064', 'GUANILNITROSAMINO- GUANILTETRACENO (TETRACENO) HUMEDECIDO con un mínimo del 30 %, en masa, de agua o de una mezcla de alcohol y agua (Producto o material explosivo)'),
                                                (65, 'M0065', 'HEXOLITA (HEXOTOL) seca o humedecida con menos del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (66, 'M0066', 'INFLAMADORES (Producto o material explosivo)'),
                                                (67, 'M0067', 'DISPOSITIVOS PORTADORES DE CARGAS HUECAS, CARGADOS, para perforación de pozos de petróleo, sin detonador (Producto o material explosivo)'),
                                                (68, 'M0068', 'AZIDA DE PLOMO HUMEDECIDA con un mínimo del 20 %, en masa, de agua o de una mezcla de alcohol y agua (Producto o material explosivo)'),
                                                (69, 'M0069', 'ESTIFNATO DE PLOMO (TRINITRORRESORCINATO DE PLOMO) HUMEDECIDO con un mínimo del 20 %, en masa, de agua o de una mezcla de alcohol y agua (Producto o material explosivo)'),
                                                (70, 'M0070', 'INICIADOR PARA MECHAS DE SEGURIDAD (Producto o material explosivo)'),
                                                (71, 'M0071', 'SALES METÁLICAS DEFLAGRANTES DE DERIVADOS NITRADOS AROMÁTICOS, N.E.P. (Producto o material explosivo)'),
                                                (72, 'M0072', 'HEXANITRATO DE MANITOL (NITROMANITA) HUMEDECIDO con un mínimo del 40 %, en masa, de agua o de una mezcla de alcohol y agua (Producto o material explosivo)'),
                                                (73, 'M0073', 'FULMINATO DE MERCURIO HUMEDECIDO con un mínimo del 20 %, en masa, de agua o de una mezcla de alcohol y agua (Producto o material explosivo)'),
                                                (74, 'M0074', 'MINAS con carga explosiva (Producto o material explosivo)'),
                                                (75, 'M0075', 'MINAS con carga explosiva (Producto o material explosivo)'),
                                                (76, 'M0076', 'MINAS con carga explosiva (Producto o material explosivo)'),
                                                (77, 'M0077', 'NITROGLICERINA DESENSIBILIZADA con un mínimo del 40 %, en masa, de flemador no volátil insoluble en agua (Producto o material explosivo)'),
                                                (78, 'M0078', 'NITROGLICERINA EN SOLUCIÓN ALCOHÓLICA con más del 1 % pero no más del 10 % de nitroglicerina (Producto o material explosivo)'),
                                                (79, 'M0079', 'NITROALMIDÓN seco o humedecido con menos del 20 %, en masa, de agua (Producto o material explosivo)'),
                                                (80, 'M0080', 'NITROUREA (Producto o material explosivo)'),
                                                (81, 'M0081', 'TETRANITRATO DE PENTAERITRITA (TETRANITRATO DE PENTAERITRITOL; PENTRITA; TNPE) HUMEDECIDO con un mínimo del 25 %, en masa, de agua, o TETRANITRATO DE PENTAERITRITA (TETRANITRATO DE PENTAERITRITOL; PENTRITA; TNPE) DESENSIBILIZADO con un mínimo del 15 %, en'),
                                                (82, 'M0082', 'PENTOLITA seca o humedecida con menos del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (83, 'M0083', 'TRINITROANILINA (PICRAMIDA) (Producto o material explosivo)'),
                                                (84, 'M0084', 'TRINITROFENOL (ÁCIDO PÍCRICO) seco o humedecido con menos del 30 %, en masa, de agua (Producto o material explosivo)'),
                                                (85, 'M0085', 'TRINITROCLOROBENCENO (CLORURO DE PICRILO) (Producto o material explosivo)'),
                                                (86, 'M0086', 'GALLETA DE PÓLVORA HUMEDECIDA con un mínimo del 25 %, en masa, de agua (Producto o material explosivo)'),
                                                (87, 'M0087', 'PÓLVORA SIN HUMO (Producto o material explosivo)'),
                                                (88, 'M0088', 'PÓLVORA SIN HUMO (Producto o material explosivo)'),
                                                (89, 'M0089', 'PROYECTILES con carga explosiva (Producto o material explosivo)'),
                                                (90, 'M0090', 'PROYECTILES con carga explosiva (Producto o material explosivo)'),
                                                (91, 'M0091', 'PROYECTILES con carga explosiva (Producto o material explosivo)'),
                                                (92, 'M0092', 'MUNICIONES ILUMINANTES con o sin carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (93, 'M0093', 'CARGAS EXPLOSIVAS DE SEPARACIÓN (Producto o material explosivo)'),
                                                (94, 'M0094', 'REMACHES EXPLOSIVOS'),
                                                (95, 'M0095', 'COHETES con carga explosiva (Producto o material explosivo)'),
                                                (96, 'M0096', 'COHETES con carga explosiva (Producto o material explosivo)'),
                                                (97, 'M0097', 'COHETES con carga explosiva (Producto o material explosivo)'),
                                                (98, 'M0098', 'COHETES con cabeza inerte (Producto o material explosivo)'),
                                                (99, 'M0099', 'MOTORES DE COHETE (Producto o material explosivo)'),
                                                (100, 'M0100', 'MUESTRAS DE EXPLOSIVOS, excepto los explosivos iniciadores (Producto o material explosivo)'),
                                                (101, 'M0101', 'ARTIFICIOS MANUALES DE PIROTECNIA PARA SEÑALES (Producto o material explosivo)'),
                                                (102, 'M0102', 'PETARDOS DE SEÑALES PARA FERROCARRILES, EXPLOSIVOS (Producto o material explosivo)'),
                                                (103, 'M0103', 'PETARDOS DE SEÑALES PARA FERROCARRILES, EXPLOSIVOS (Producto o material explosivo)'),
                                                (104, 'M0104', 'SEÑALES DE SOCORRO para barcos (Producto o material explosivo)'),
                                                (105, 'M0105', 'SEÑALES DE SOCORRO para barcos (Producto o material explosivo)'),
                                                (106, 'M0106', 'SEÑALES FUMÍGENAS (Producto o material explosivo)'),
                                                (107, 'M0107', 'SEÑALES FUMÍGENAS (Producto o material explosivo)'),
                                                (108, 'M0108', 'CARGAS EXPLOSIVAS PARA SONDEOS (Producto o material explosivo)'),
                                                (109, 'M0109', 'TETRANITROANILINA (Producto o material explosivo)'),
                                                (110, 'M0110', 'TRINITROFENILMETILNITRAMI NA (TETRILO) (Producto o material explosivo)'),
                                                (111, 'M0111', 'TRINITROTOLUENO (TNT) seco o humedecido con menos del 30 %, en masa, de agua (Producto o material explosivo)'),
                                                (112, 'M0112', 'TRAZADORES PARA MUNICIONES (Producto o material explosivo)'),
                                                (113, 'M0113', 'TRINITROANISOL (Producto o material explosivo)'),
                                                (114, 'M0114', 'TRINITROBENCENO seco o humedecido con menos del 30 %, en masa, de agua (Producto o material explosivo)'),
                                                (115, 'M0115', 'ÁCIDO TRINITROBENZOICO seco o humedecido con menos del 30 %, en masa, de agua (Producto o material explosivo)'),
                                                (116, 'M0116', 'TRINITRO-m-CRESOL (Producto o material explosivo)'),
                                                (117, 'M0117', 'TRINITRONAFTALENO (Producto o material explosivo)'),
                                                (118, 'M0118', 'TRINITROFENETOL (Producto o material explosivo)'),
                                                (119, 'M0119', 'TRINITRORRESORCINOL (TRINITRORRESORCINA; ÁCIDO ESTÍFNICO) seco o humedecido con menos del 20 %, en masa, de agua o de una mezcla de alcohol y agua (Producto o material explosivo)'),
                                                (120, 'M0120', 'NITRATO DE UREA seco o humedecido con menos del 20 %, en masa, de agua (Producto o material explosivo)'),
                                                (121, 'M0121', 'CABEZAS DE COMBATE PARA TORPEDOS, con carga explosiva (Producto o material explosivo)'),
                                                (122, 'M0122', 'NITRATO AMÓNICO'),
                                                (123, 'M0123', 'AZIDA DE BARIO seca o humedecida con menos del 50 %, en masa, de agua (Producto o material explosivo)'),
                                                (124, 'M0124', 'MULTIPLICADORES CON DETONADOR (Producto o material explosivo)'),
                                                (125, 'M0125', 'CICLOTETRAMETILEN- TETRANITRAMINA (OCTÓGENO; HMX) HUMEDECIDA con un mínimo del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (126, 'M0126', 'DINITRO-o-CRESOLATO SÓDICO seco o humedecido con menos del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (127, 'M0127', 'PICRAMATO SÓDICO seco o humedecido con menos del 20 %, en masa, de agua (Producto o material explosivo)'),
                                                (128, 'M0128', 'PICRAMATO DE CIRCONIO seco\r\nohumedecido con menos del 20 %,\r\nen masa, de agua (Producto o material explosivo)'),
                                                (129, 'M0129', 'CARGAS MOLDEADAS LINEALES FLEXIBLES (Producto o material explosivo)'),
                                                (130, 'M0130', 'COHETES LANZACABOS (Producto o material explosivo)'),
                                                (131, 'M0131', 'COHETES LANZACABOS (Producto o material explosivo)'),
                                                (132, 'M0132', 'EXPLOSIVOS PARA VOLADURAS, TIPO E (Producto o material explosivo)'),
                                                (133, 'M0133', 'CARGAS PROPULSORAS DE ARTILLERÍA (Producto o material explosivo)'),
                                                (134, 'M0134', 'MUNICIONES INCENDIARIAS DE FÓSFORO BLANCO, con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (135, 'M0135', 'MUNICIONES INCENDIARIAS DE FÓSFORO BLANCO, con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (136, 'M0136', 'MUNICIONES FUMÍGENAS DE FÓSFORO BLANCO, con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (137, 'M0137', 'MUNICIONES FUMÍGENAS DE FÓSFORO BLANCO, con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (138, 'M0138', 'MUNICIONES\r\nINCENDIARIAScon líquido o gel, con carga dispersora, carga expulsora\r\no carga propulsora (Producto o material explosivo)'),
                                                (139, 'M0139', 'DISPOSITIVOS ACTIVADOS POR EL AGUA, con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (140, 'M0140', 'DISPOSITIVOS ACTIVADOS POR EL AGUA, con carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (141, 'M0141', 'MOTORES DE COHETE CON LÍQUIDOS HIPERGÓLICOS, con o sin carga expulsora (Producto o material explosivo)'),
                                                (142, 'M0142', 'MUNICIONES ILUMINANTES con o sin carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (143, 'M0143', 'DETONADORES ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (144, 'M0144', 'ESPOLETAS DETONANTES (Producto o material explosivo)'),
                                                (145, 'M0145', 'OCTOLITA (OCTOL) seca o humedecida con menos del 15 %, en masa, de agua (Producto o material explosivo)'),
                                                (146, 'M0146', 'DETONADORES NO ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (147, 'M0147', 'MULTIPLICADORES CON DETONADOR (Producto o material explosivo)'),
                                                (148, 'M0148', 'CARGAS PROPULSORAS (Producto o material explosivo)'),
                                                (149, 'M0149', 'CARGAS PROPULSORAS (Producto o material explosivo)'),
                                                (150, 'M0150', 'CARTUCHOS DE ACCIONAMIENTO (Producto o material explosivo)'),
                                                (151, 'M0151', 'CARTUCHOS DE ACCIONAMIENTO (Producto o material explosivo)'),
                                                (152, 'M0152', 'CARTUCHOS PARA POZOS DE PETRÓLEO (Producto o material explosivo)'),
                                                (153, 'M0153', 'CARTUCHOS PARA POZOS DE PETRÓLEO (Producto o material explosivo)'),
                                                (154, 'M0154', 'CARGAS PROPULSORAS DE ARTILLERÍA (Producto o material explosivo)'),
                                                (155, 'M0155', 'MOTORES DE COHETE (Producto o material explosivo)'),
                                                (156, 'M0156', 'MOTORES DE COHETE (Producto o material explosivo)'),
                                                (157, 'M0157', 'NITROGUANIDINA (PICRITA) seca o humedecida con menos del 20 %, en masa, de agua (Producto o material explosivo)'),
                                                (158, 'M0158', 'MULTIPLICADORES sin detonador (Producto o material explosivo)'),
                                                (159, 'M0159', 'GRANADAS de mano o de fusil, con carga explosiva (Producto o material explosivo)'),
                                                (160, 'M0160', 'GRANADAS de mano o de fusil, con carga explosiva (Producto o material explosivo)'),
                                                (161, 'M0161', 'CABEZAS DE COMBATE PARA COHETES, con carga explosiva (Producto o material explosivo)'),
                                                (162, 'M0162', 'CABEZAS DE COMBATE PARA COHETES, con carga explosiva (Producto o material explosivo)'),
                                                (163, 'M0163', 'CARGAS MOLDEADAS LINEALES FLEXIBLES (Producto o material explosivo)'),
                                                (164, 'M0164', 'MECHA DETONANTE flexible (Producto o material explosivo)'),
                                                (165, 'M0165', 'MECHA DETONANTE con envoltura metálica (Producto o material explosivo)'),
                                                (166, 'M0166', 'BOMBAS con carga explosiva (Producto o material explosivo)'),
                                                (167, 'M0167', 'GRANADAS de mano o de fusil, con carga explosiva (Producto o material explosivo)'),
                                                (168, 'M0168', 'GRANADAS de mano o de fusil, con carga explosiva (Producto o material explosivo)'),
                                                (169, 'M0169', 'MINAS con carga explosiva (Producto o material explosivo)'),
                                                (170, 'M0170', 'COHETES con carga explosiva (Producto o material explosivo)'),
                                                (171, 'M0171', 'CARGAS EXPLOSIVAS PARA SONDEOS (Producto o material explosivo)'),
                                                (172, 'M0172', 'MUNICIONES ILUMINANTES con o sin carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (173, 'M0173', 'BOMBAS DE ILUMINACIÓN PARA FOTOGRAFÍA (Producto o material explosivo)'),
                                                (174, 'M0174', 'MUNICIONES INCENDIARIAS con o sin carga dispersora, carga expulsora o carga propulsora (Producto o material explosivo)'),
                                                (175, 'M0175', 'MUNICIONES LACRIMÓGENAS con carga dispersora, carga expulsora\r\no carga propulsora (Producto o material explosivo)'),
                                                (176, 'M0176', 'MUNICIONES FUMÍGENAS con o sin carga dispersora, carga expulsora\r\no carga propulsora (Producto o material explosivo)'),
                                                (177, 'M0177', 'PÓLVORA DE DESTELLOS (Producto o material explosivo)'),
                                                (178, 'M0178', 'TRAZADORES PARA MUNICIONES (Producto o material explosivo)'),
                                                (179, 'M0179', 'CARTUCHOS DE SEÑALES (Producto o material explosivo)'),
                                                (180, 'M0180', 'SEÑALES FUMÍGENAS (Producto o material explosivo)'),
                                                (181, 'M0181', 'INFLAMADORES (Producto o material explosivo)'),
                                                (182, 'M0182', 'INFLAMADORES (Producto o material explosivo)'),
                                                (183, 'M0183', 'ESPOLETAS DE IGNICIÓN (Producto o material explosivo)'),
                                                (184, 'M0184', 'ESPOLETAS DE IGNICIÓN (Producto o material explosivo)'),
                                                (185, 'M0185', 'GRANADAS DE EJERCICIOS, de mano o de fusil (Producto o material explosivo)'),
                                                (186, 'M0186', 'CEBOS TUBULARES (Producto o material explosivo)'),
                                                (187, 'M0187', 'CEBOS TUBULARES (Producto o material explosivo)'),
                                                (188, 'M0188', 'CARTUCHOS PARA ARMAS, con carga explosiva (Producto o material explosivo)'),
                                                (189, 'M0189', 'MOTORES DE COHETE CON LÍQUIDOS HIPERGÓLICOS, con o sin carga expulsora (Producto o material explosivo)'),
                                                (190, 'M0190', 'CARTUCHOS DE ACCIONAMIENTO (Producto o material explosivo)'),
                                                (191, 'M0191', 'PROYECTILES con carga explosiva (Producto o material explosivo)'),
                                                (192, 'M0192', 'INFLAMADORES (Producto o material explosivo)'),
                                                (193, 'M0193', 'CARTUCHOS DE FOGUEO PARA ARMAS,  (Producto o material explosivo)'),
                                                (194, 'M0194', 'CARTUCHOS DE FOGUEO PARA ARMAS, , o CARTUCHOS DE FOGUEO PARA ARMAS DE PEQUEÑO CALIBRE,  (Producto o material explosivo)'),
                                                (195, 'M0195', 'CARTUCHOS PARA ARMAS, CON PROYECTIL INERTE (Producto o material explosivo)'),
                                                (196, 'M0196', 'TORPEDOS con carga explosiva (Producto o material explosivo)'),
                                                (197, 'M0197', 'TORPEDOS con carga explosiva (Producto o material explosivo)'),
                                                (198, 'M0198', 'EXPLOSIVO PARA VOLADURAS, TIPO B (Producto o material explosivo)'),
                                                (199, 'M0199', 'EXPLOSIVO PARA VOLADURAS, TIPO E (Producto o material explosivo)'),
                                                (200, 'M0200', 'ARTIFICIOS DE PIROTECNIA (Producto o material explosivo)'),
                                                (201, 'M0201', 'ARTIFICIOS DE PIROTECNIA (Producto o material explosivo)'),
                                                (202, 'M0202', 'ARTIFICIOS DE PIROTECNIA (Producto o material explosivo)'),
                                                (203, 'M0203', 'ARTIFICIOS DE PIROTECNIA (Producto o material explosivo)'),
                                                (204, 'M0204', 'ARTIFICIOS DE PIROTECNIA (Producto o material explosivo)'),
                                                (205, 'M0205', 'CARTUCHOS DE FOGUEO PARA ARMAS, o CARTUCHOS DE FOGUEO PARA ARMAS DE PEQUEÑO CALIBRE,  (Producto o material explosivo)'),
                                                (206, 'M0206', 'CARTUCHOS PARA ARMAS, CON PROYECTIL INERTE, o CARTUCHOS PARA ARMAS DE PEQUEÑO CALIBRE (Producto o material explosivo)'),
                                                (207, 'M0207', 'NITROCELULOSA seca o humedecida con menos del 25 %, en masa, de agua (o de alcohol) (Producto o material explosivo)'),
                                                (208, 'M0208', 'NITROCELULOSA no modificada o plastificada con menos del 18 %, en masa, de plastificante (Producto o material explosivo)'),
                                                (209, 'M0209', 'NITROCELULOSA HUMEDECIDA con un mínimo del 25 %, en masa, de alcohol (Producto o material explosivo)'),
                                                (210, 'M0210', 'NITROCELULOSA PLASTIFICADA con un mínimo del 18 %, en masa, de plastificante (Producto o material explosivo)'),
                                                (211, 'M0211', 'PROYECTILES con carga explosiva (Producto o material explosivo)'),
                                                (212, 'M0212', 'PROYECTILES inertes con trazador (Producto o material explosivo)'),
                                                (213, 'M0213', 'PROYECTILES con carga dispersora o carga expulsora (Producto o material explosivo)'),
                                                (214, 'M0214', 'PROYECTILES con carga dispersora o carga expulsora (Producto o material explosivo)'),
                                                (215, 'M0215', 'CARTUCHOS PARA ARMAS, con carga explosiva (Producto o material explosivo)'),
                                                (216, 'M0216', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (217, 'M0217', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (218, 'M0218', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (219, 'M0219', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (220, 'M0220', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (221, 'M0221', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (222, 'M0222', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (223, 'M0223', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (224, 'M0224', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (225, 'M0225', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (226, 'M0226', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (227, 'M0227', 'CONJUNTOS DE DETONADORES NO ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (228, 'M0228', 'CONJUNTOS DE DETONADORES NO ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (229, 'M0229', 'MUNICIONES DE EJERCICIOS (Producto o material explosivo)'),
                                                (230, 'M0230', 'MUNICIONES PARA ENSAYOS (Producto o material explosivo)'),
                                                (231, 'M0231', 'DETONADORES PARA MUNICIONES (Producto o material explosivo)'),
                                                (232, 'M0232', 'DETONADORES PARA MUNICIONES (Producto o material explosivo)'),
                                                (233, 'M0233', 'DETONADORES PARA MUNICIONES (Producto o material explosivo)'),
                                                (234, 'M0234', 'ESPOLETAS DETONANTES (Producto o material explosivo)'),
                                                (235, 'M0235', 'ESPOLETAS DE IGNICIÓN (Producto o material explosivo)'),
                                                (236, 'M0236', 'CABEZAS DE COMBATE PARA COHETES, con carga explosiva (Producto o material explosivo)'),
                                                (237, 'M0237', 'CABEZAS DE COMBATE PARA COHETES, con carga dispersora o carga expulsora (Producto o material explosivo)'),
                                                (238, 'M0238', 'CABEZAS DE COMBATE PARA COHETES, con carga dispersora o carga expulsora (Producto o material explosivo)'),
                                                (239, 'M0239', 'GRANADAS DE EJERCICIOS, de mano o de fusil (Producto o material explosivo)'),
                                                (240, 'M0240', 'ARTIFICIOS MANUALES DE PIROTECNIA PARA SEÑALES (Producto o material explosivo)'),
                                                (241, 'M0241', 'CARGAS EXPLOSIVAS PARA SONDEOS (Producto o material explosivo)'),
                                                (242, 'M0242', 'CARGAS EXPLOSIVAS PARA SONDEOS (Producto o material explosivo)'),
                                                (243, 'M0243', 'CEBOS TUBULARES (Producto o material explosivo)'),
                                                (244, 'M0244', 'CEBOS DEL TIPO DE CÁPSULA (Producto o material explosivo)'),
                                                (245, 'M0245', 'CEBOS DEL TIPO DE CÁPSULA (Producto o material explosivo)'),
                                                (246, 'M0246', 'VAINAS DE CARTUCHOS VACÍOS CON CEBO (Producto o material explosivo)'),
                                                (247, 'M0247', 'OBJETOS PIROFÓRICOS (Producto o material explosivo)'),
                                                (248, 'M0248', 'CARTUCHOS DE ACCIONAMIENTO (Producto o material explosivo)'),
                                                (249, 'M0249', 'COMPONENTES DE CADENAS DE EXPLOSIVOS, N.E.P. (Producto o material explosivo)'),
                                                (250, 'M0250', 'COMPONENTES DE CADENAS DE EXPLOSIVOS, N.E.P. (Producto o material explosivo)'),
                                                (251, 'M0251', 'COMPONENTES DE CADENAS DE EXPLOSIVOS, N.E.P. (Producto o material explosivo)'),
                                                (252, 'M0252', '5-NITROBENZOTRIAZOL (Producto o material explosivo)'),
                                                (253, 'M0253', 'ÁCIDO TRINITRO- BENCENOSULFÓNICO (Producto o material explosivo)'),
                                                (254, 'M0254', 'TRINITROFLUORENONA (Producto o material explosivo)'),
                                                (255, 'M0255', 'TRINITROTOLUENO (TNT) Y TRINITROBENCENO, MEZCLA DE, o TRINITROTOLUENO (TNT) Y HEXANITROESTILBENO, MEZCLA DE (Producto o material explosivo)'),
                                                (256, 'M0256', 'TRINITROTOLUENO (TNT) CON TRINITROBENCENO Y HEXANITROESTILBENO, MEZCLA DE (Producto o material explosivo)'),
                                                (257, 'M0257', 'TRITONAL (Producto o material explosivo)'),
                                                (258, 'M0258', 'CICLOTRIMETILENTRINITRAMI NA (CICLONITA; HEXÓGENO; RDX) Y CICLOTETRAMETILEN-TETRANITRAMINA (OCTÓGENO; HMX), MEZCLA DE, HUMEDECIDAS, con un mínimo del 15 %, en masa, de agua, o CICLOTRIMETILEN-TRINITRAMINA (CICLONITA; HEXÓGENO; RDX) Y CICLOTETRAMETILEN-TET'),
                                                (259, 'M0259', 'HEXANITROESTILBENO (Producto o material explosivo)'),
                                                (260, 'M0260', 'HEXOTONAL (Producto o material explosivo)'),
                                                (261, 'M0261', 'TRINITRORRESORCINOL (TRINITRORRESORCINA; ÁCIDO ESTÍFNICO) HUMEDECIDO con un mínimo del 20 %, en masa, de agua o de una mezcla de alcohol y agua (Producto o material explosivo)'),
                                                (262, 'M0262', 'MOTORES DE COHETE, DE COMBUSTIBLE LÍQUIDO (Producto o material explosivo)'),
                                                (263, 'M0263', 'MOTORES DE COHETE, DE COMBUSTIBLE LÍQUIDO (Producto o material explosivo)'),
                                                (264, 'M0264', 'COHETES DE COMBUSTIBLE LÍQUIDO, con carga explosiva (Producto o material explosivo)'),
                                                (265, 'M0265', 'COHETES DE COMBUSTIBLE LÍQUIDO, con carga explosiva (Producto o material explosivo)'),
                                                (266, 'M0266', 'BOMBAS QUE CONTIENEN UN LÍQUIDO INFLAMABLE, con carga explosiva (Producto o material explosivo)'),
                                                (267, 'M0267', 'BOMBAS QUE CONTIENEN UN LÍQUIDO INFLAMABLE, con carga explosiva (Producto o material explosivo)'),
                                                (268, 'M0268', 'SULFURO DE DIPICRILO seco o humedecido con menos del 10 %, en masa, de agua (Producto o material explosivo)'),
                                                (269, 'M0269', 'PERCLORATO DE AMONIO (Producto o material explosivo)'),
                                                (270, 'M0270', 'BENGALAS AÉREAS (Producto o material explosivo)'),
                                                (271, 'M0271', 'BENGALAS AÉREAS (Producto o material explosivo)'),
                                                (272, 'M0272', 'CARTUCHOS DE SEÑALES (Producto o material explosivo)'),
                                                (273, 'M0273', 'DINITROSOBENCENO (Producto o material explosivo)'),
                                                (274, 'M0274', 'ÁCIDO TETRAZOL-1-ACÉTICO (Producto o material explosivo)'),
                                                (275, 'M0275', 'ESPOLETAS DETONANTES con dispositivos de protección (Producto o material explosivo)'),
                                                (276, 'M0276', 'ESPOLETAS DETONANTES con dispositivos de protección (Producto o material explosivo)'),
                                                (277, 'M0277', 'ESPOLETAS DETONANTES con dispositivos de protección (Producto o material explosivo)'),
                                                (278, 'M0278', 'TETRANITRATO DE PENTAERITRITA (TETRANITRATO DE PENTAERITRITOL; TNPE) con un mínimo del 7 %, en masa, de cera (Producto o material explosivo)'),
                                                (279, 'M0279', 'CARTUCHOS PARA ARMAS, con carga explosiva (Producto o material explosivo)'),
                                                (280, 'M0280', 'CARTUCHOS DE FOGUEO PARA ARMAS  (Producto o material explosivo)'),
                                                (281, 'M0281', 'CARGAS PROPULSORAS DE ARTILLERÍA (Producto o material explosivo)'),
                                                (282, 'M0282', 'CARGAS PROPULSORAS (Producto o material explosivo)'),
                                                (283, 'M0283', 'CARTUCHOS PARA ARMAS, CON PROYECTIL INERTE, o CARTUCHOS PARA ARMAS DE PEQUEÑO CALIBRE (Producto o material explosivo)'),
                                                (284, 'M0284', 'BENGALAS DE SUPERFICIE (Producto o material explosivo)'),
                                                (285, 'M0285', 'BENGALAS DE SUPERFICIE (Producto o material explosivo)'),
                                                (286, 'M0286', 'BENGALAS AÉREAS (Producto o material explosivo)'),
                                                (287, 'M0287', 'BENGALAS AÉREAS (Producto o material explosivo)'),
                                                (288, 'M0288', 'PROYECTILES inertes con trazador (Producto o material explosivo)'),
                                                (289, 'M0289', 'PROYECTILES inertes con trazador (Producto o material explosivo)'),
                                                (290, 'M0290', 'PROYECTILES con carga dispersora o carga expulsora (Producto o material explosivo)'),
                                                (291, 'M0291', 'PROYECTILES con carga dispersora o carga expulsora (Producto o material explosivo)'),
                                                (292, 'M0292', 'OBJETOS PIROTÉCNICOS para usos técnicos (Producto o material explosivo)'),
                                                (293, 'M0293', 'OBJETOS PIROTÉCNICOS para usos técnicos (Producto o material explosivo)'),
                                                (294, 'M0294', 'OBJETOS PIROTÉCNICOS para usos técnicos (Producto o material explosivo)'),
                                                (295, 'M0295', 'OBJETOS PIROTÉCNICOS para usos técnicos (Producto o material explosivo)'),
                                                (296, 'M0296', 'OBJETOS PIROTÉCNICOS para usos técnicos (Producto o material explosivo)'),
                                                (297, 'M0297', 'GALLETA DE PÓLVORA HUMEDECIDA con un mínimo del 17 %, en masa, de alcohol (Producto o material explosivo)'),
                                                (298, 'M0298', 'PROYECTILES con carga dispersora o carga expulsora (Producto o material explosivo)'),
                                                (299, 'M0299', 'PROYECTILES con carga dispersora o carga expulsora (Producto o material explosivo)'),
                                                (300, 'M0300', 'COHETES con carga expulsora (Producto o material explosivo)'),
                                                (301, 'M0301', 'COHETES con carga expulsora (Producto o material explosivo)'),
                                                (302, 'M0302', 'COHETES con carga expulsora (Producto o material explosivo)'),
                                                (303, 'M0303', 'CARGAS HUECAS sin detonador (Producto o material explosivo)'),
                                                (304, 'M0304', 'CARGAS HUECAS sin detonador (Producto o material explosivo)'),
                                                (305, 'M0305', 'CARGAS HUECAS sin detonador (Producto o material explosivo)'),
                                                (306, 'M0306', 'CARGAS EXPLOSIVAS PARA USOS CIVILES sin detonador (Producto o material explosivo)'),
                                                (307, 'M0307', 'CARGAS EXPLOSIVAS PARA USOS CIVILES sin detonador (Producto o material explosivo)'),
                                                (308, 'M0308', 'CARGAS EXPLOSIVAS PARA USOS CIVILES sin detonador (Producto o material explosivo)'),
                                                (309, 'M0309', 'CARGAS EXPLOSIVAS PARA USOS CIVILES, sin detonador (Producto o material explosivo)'),
                                                (310, 'M0310', 'VAINAS COMBUSTIBLES VACÍAS, SIN CEBO (Producto o material explosivo)'),
                                                (311, 'M0311', 'VAINAS COMBUSTIBLES VACÍAS, SIN CEBO (Producto o material explosivo)'),
                                                (312, 'M0312', 'ÁCIDO 5-MERCAPTO- TETRAZOL-1-ACÉTICO (Producto o material explosivo)'),
                                                (313, 'M0313', 'TORPEDOS DE COMBUSTIBLE LÍQUIDO, con o sin carga explosiva (Producto o material explosivo)'),
                                                (314, 'M0314', 'TORPEDOS DE COMBUSTIBLE LÍQUIDO, con cabeza inerte (Producto o material explosivo)'),
                                                (315, 'M0315', 'TORPEDOS con carga explosiva (Producto o material explosivo)'),
                                                (316, 'M0316', 'GRANADAS DE EJERCICIOS, de mano o de fusil (Producto o material explosivo)'),
                                                (317, 'M0317', 'COHETES LANZACABOS (Producto o material explosivo)'),
                                                (318, 'M0318', 'INFLAMADORES (Producto o material explosivo)'),
                                                (319, 'M0319', 'DETONADORES NO ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (320, 'M0320', 'DETONADORES ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (321, 'M0321', 'CARGAS EXPLOSIVAS CON AGLUTINANTE PLÁSTICO'),
                                                (322, 'M0322', 'CARGAS EXPLOSIVAS CON AGLUTINANTE PLÁSTICO'),
                                                (323, 'M0323', 'CARGAS EXPLOSIVAS CON AGLUTINANTE PLÁSTICO'),
                                                (324, 'M0324', 'CARGAS EXPLOSIVAS CON AGLUTINANTE PLÁSTICO'),
                                                (325, 'M0325', 'COMPONENTES DE CADENAS DE EXPLOSIVOS, N.E.P. (Producto o material explosivo)'),
                                                (326, 'M0326', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (327, 'M0327', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (328, 'M0328', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (329, 'M0329', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (330, 'M0330', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (331, 'M0331', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (332, 'M0332', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (333, 'M0333', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (334, 'M0334', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (335, 'M0335', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (336, 'M0336', 'OBJETOS EXPLOSIVOS, N.E.P.'),
                                                (337, 'M0337', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (338, 'M0338', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (339, 'M0339', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (340, 'M0340', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (341, 'M0341', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (342, 'M0342', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (343, 'M0343', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (344, 'M0344', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (345, 'M0345', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (346, 'M0346', 'SUSTANCIAS EXPLOSIVAS MUY INSENSIBLES (SUSTANCIAS EMI), N.E.P. (Producto o material explosivo)'),
                                                (347, 'M0347', 'CICLOTRIMETILEN- TRINITRAMINA (CICLONITA; HEXÓGENO; RDX) DESENSIBILIZADA'),
                                                (348, 'M0348', 'CICLOTETRAMETILEN- TETRANITRAMINA (OCTÓGENO; HMX) DESENSIBILIZADA'),
                                                (349, 'M0349', 'SUSTANCIAS EXPLOSIVAS, N.E.P.'),
                                                (350, 'M0350', 'OBJETOS EXPLOSIVOS EXTREMADAMENTE INSENSIBLES (OBJETOS EEI) (Producto o material explosivo)'),
                                                (351, 'M0351', 'SEÑALES FUMÍGENAS (Producto o material explosivo)'),
                                                (352, 'M0352', 'MUNICIONES DE EJERCICIOS (Producto o material explosivo)'),
                                                (353, 'M0353', 'DINITROGLICOLURILO (DINGU) (Producto o material explosivo)'),
                                                (354, 'M0354', 'NITROTRIAZOLONA (NTO) (Producto o material explosivo)'),
                                                (355, 'M0355', 'CARGAS PROPULSORAS (Producto o material explosivo)'),
                                                (356, 'M0356', 'PETARDOS DE SEÑALES PARA FERROCARRILES, EXPLOSIVOS (Producto o material explosivo)'),
                                                (357, 'M0357', 'PETARDOS DE SEÑALES PARA FERROCARRILES, EXPLOSIVOS (Producto o material explosivo)'),
                                                (358, 'M0358', 'DISPOSITIVOS PORTADORES DE CARGAS HUECAS, CARGADOS, para perforación de pozos de petróleo, sin detonador (Producto o material explosivo)'),
                                                (359, 'M0359', 'PROPULSANTE LÍQUIDO (Producto o material explosivo)'),
                                                (360, 'M0360', 'OCTONAL'),
                                                (361, 'M0361', 'PROPULSANTE LÍQUIDO (Producto o material explosivo)'),
                                                (362, 'M0362', 'PROPULSANTE SÓLIDO (Producto o material explosivo)'),
                                                (363, 'M0363', 'PROPULSANTE SÓLIDO (Producto o material explosivo)'),
                                                (364, 'M0364', 'CONJUNTOS DE DETONADORES, NO ELÉCTRICOS para voladuras (Producto o material explosivo)'),
                                                (365, 'M0365', 'PROPULSANTE SÓLIDO (Producto o material explosivo)'),
                                                (366, 'M0366', 'COHETES con cabeza inerte (Producto o material explosivo)'),
                                                (367, 'M0367', 'DISPOSITIVOS DE SEGURIDAD PIROTÉCNICOS (Producto o material explosivo)'),
                                                (368, 'M0368', '1H-TETRAZOL'),
                                                (369, 'M0369', 'SEÑALES DE SOCORRO para barcos  (Producto o material explosivo)'),
                                                (370, 'M0370', 'SEÑALES DE SOCORRO para barcos  (Producto o material explosivo)'),
                                                (371, 'M0371', 'SEÑALES FUMÍGENAS (Producto o material explosivo)'),
                                                (372, 'M0372', '1-HIDROXIBENZOTRIAZOL, ANHIDRO, seco o humedecido con menos del 20 %, en masa, de agua'),
                                                (373, 'M0373', 'PÓLVORA SIN HUMO (Producto o material explosivo)'),
                                                (374, 'M0374', 'MOTORES DE COHETE (Producto o material explosivo)'),
                                                (375, 'M0375', 'DETONADORES,\r\nELECTRÓNICOS programables para voladuras (Producto o material explosivo)'),
                                                (376, 'M0376', 'DETONADORES,\r\nELECTRÓNICOS programables para voladuras (Producto o material explosivo)'),
                                                (377, 'M0377', 'DETONADORES,\r\nELECTRÓNICOS programables para voladuras (Producto o material explosivo)'),
                                                (378, 'M0378', 'ACETILENO DISUELTO'),
                                                (379, 'M0379', 'AIRE COMPRIMIDO'),
                                                (380, 'M0380', 'AIRE LÍQUIDO REFRIGERADO'),
                                                (381, 'M0381', 'AMONIACO, ANHIDRO'),
                                                (382, 'M0382', 'ARGÓN COMPRIMIDO'),
                                                (383, 'M0383', 'TRIFLUORURO DE BORO'),
                                                (384, 'M0384', 'BROMOTRIFLUORO-METANO (GAS REFRIGERANTE R13B1)'),
                                                (385, 'M0385', 'BUTADIENOS ESTABILIZADOS\r\noMEZCLA ESTABILIZADA DE BUTADIENOS E HIDROCARBUROS, que contienen más del 40 % de butadienos'),
                                                (386, 'M0386', 'BUTANO'),
                                                (387, 'M0387', 'BUTILENO'),
                                                (388, 'M0388', 'DIÓXIDO DE CARBONO'),
                                                (389, 'M0389', 'MONÓXIDO DE CARBONO COMPRIMIDO'),
                                                (390, 'M0390', 'CLORO'),
                                                (391, 'M0391', 'CLORODIFLUOROMETANO (GAS REFRIGERANTE R 22)'),
                                                (392, 'M0392', 'CLOROPENTAFLUORO-ETANO (GAS REFRIGERANTE R 115)'),
                                                (393, 'M0393', '1-CLORO-1,2,2,2-\r\nTETRAFLUOROETANO\r\n(GAS REFRIGERANTE R 124)'),
                                                (394, 'M0394', 'CLOROTRIFLUOROMETANO (GAS REFRIGERANTE R 13)'),
                                                (395, 'M0395', 'GAS DE HULLA COMPRIMIDO'),
                                                (396, 'M0396', 'CIANÓGENO'),
                                                (397, 'M0397', 'CICLOPROPANO'),
                                                (398, 'M0398', 'DICLORODIFLUORO-METANO (GAS REFRIGERANTE R 12)'),
                                                (399, 'M0399', 'DICLOROFLUOROMETANO (GAS REFRIGERANTE R 21)'),
                                                (400, 'M0400', '1,1-DIFLUOROETANO\r\n(GAS REFRIGERANTE R 152a)'),
                                                (401, 'M0401', 'DIMETILAMINA ANHIDRA'),
                                                (402, 'M0402', 'DIMETIL ÉTER (ÉTER DIMETÍLICO)'),
                                                (403, 'M0403', 'ETANO'),
                                                (404, 'M0404', 'ETILAMINA'),
                                                (405, 'M0405', 'CLORURO DE ETILO'),
                                                (406, 'M0406', 'ETILENO LÍQUIDO REFRIGERADO'),
                                                (407, 'M0407', 'ÉTER METILETÍLICO'),
                                                (408, 'M0408', 'ÓXIDO DE ETILENO u ÓXIDO DE ETILENO CON NITRÓGENO hasta una presión total de 1 MPa (10 bar) a 50 °C'),
                                                (409, 'M0409', 'ÓXIDO DE ETILENO Y DIÓXIDO DE CARBONO, MEZCLA DE, con más del 9 % pero no más del 87 % de óxido de etileno'),
                                                (410, 'M0410', 'ABONO EN SOLUCIÓN AMONIACAL que contiene amoniaco libre'),
                                                (411, 'M0411', 'EXTINTORES DE INCENDIOS que contienen gases comprimidos o licuados'),
                                                (412, 'M0412', 'FLÚOR COMPRIMIDO'),
                                                (413, 'M0413', 'HELIO COMPRIMIDO'),
                                                (414, 'M0414', 'BROMURO DE HIDRÓGENO ANHIDRO'),
                                                (415, 'M0415', 'HIDRÓGENO COMPRIMIDO'),
                                                (416, 'M0416', 'CLORURO DE HIDRÓGENO ANHIDRO'),
                                                (417, 'M0417', 'CIANURO DE HIDRÓGENO ESTABILIZADO con menos del 3 % de agua'),
                                                (418, 'M0418', 'FLUORURO DE HIDRÓGENO ANHIDRO'),
                                                (419, 'M0419', 'SULFURO DE HIDRÓGENO'),
                                                (420, 'M0420', 'ISOBUTILENO'),
                                                (421, 'M0421', 'CRIPTÓN COMPRIMIDO'),
                                                (422, 'M0422', 'ENCENDEDORES o RECARGAS DE ENCENDEDORES que contienen gas inflamable'),
                                                (423, 'M0423', 'MEZCLAS DE GASES LICUADOS no inflamables con nitrógeno, dióxido de carbono o aire'),
                                                (424, 'M0424', 'METILACETILENO Y PROPADIENO, MEZCLA ESTABILIZADA DE'),
                                                (425, 'M0425', 'METILAMINA ANHIDRA'),
                                                (426, 'M0426', 'BROMURO DE METILO con un máximo del 2 % de cloropicrina'),
                                                (427, 'M0427', 'CLORURO DE METILO (GAS REFRIGERANTE R 40)'),
                                                (428, 'M0428', 'METILMERCAPTANO'),
                                                (429, 'M0429', 'NEÓN COMPRIMIDO'),
                                                (430, 'M0430', 'NITRÓGENO COMPRIMIDO'),
                                                (431, 'M0431', 'TETRÓXIDO DE DINITRÓGENO (DIÓXIDO DE NITRÓGENO)'),
                                                (432, 'M0432', 'CLORURO DE NITROSILO'),
                                                (433, 'M0433', 'ÓXIDO NITROSO'),
                                                (434, 'M0434', 'GAS DE PETRÓLEO COMPRIMIDO'),
                                                (435, 'M0435', 'OXÍGENO COMPRIMIDO'),
                                                (436, 'M0436', 'OXÍGENO LÍQUIDO REFRIGERADO'),
                                                (437, 'M0437', 'GASES DE PETRÓLEO, LICUADOS'),
                                                (438, 'M0438', 'FOSGENO'),
                                                (439, 'M0439', 'PROPILENO'),
                                                (440, 'M0440', 'GAS REFRIGERANTE, N.E.P.'),
                                                (441, 'M0441', 'DIÓXIDO DE AZUFRE'),
                                                (442, 'M0442', 'HEXAFLUORURO DE AZUFRE'),
                                                (443, 'M0443', 'TETRAFLUOROETILENO ESTABILIZADO'),
                                                (444, 'M0444', 'TRIFLUOROCLOROETILENO ESTABILIZADO (GAS REFRIGERANTE R 1113)'),
                                                (445, 'M0445', 'TRIMETILAMINA ANHIDRA'),
                                                (446, 'M0446', 'BROMURO DE VINILO ESTABILIZADO'),
                                                (447, 'M0447', 'CLORURO DE VINILO ESTABILIZADO'),
                                                (448, 'M0448', 'VINIL METIL ÉTER ESTABILIZADO'),
                                                (449, 'M0449', 'ACETAL'),
                                                (450, 'M0450', 'ACETALDEHÍDO'),
                                                (451, 'M0451', 'ACETONA'),
                                                (452, 'M0452', 'ACEITES DE ACETONA'),
                                                (453, 'M0453', 'ACROLEÍNA ESTABILIZADA'),
                                                (454, 'M0454', 'ACRILONITRILO ESTABILIZADO'),
                                                (455, 'M0455', 'ALCOHOL ALÍLICO'),
                                                (456, 'M0456', 'BROMURO DE ALILO'),
                                                (457, 'M0457', 'CLORURO DE ALILO'),
                                                (458, 'M0458', 'ACETATOS DE AMILO'),
                                                (459, 'M0459', 'PENTANOLES'),
                                                (460, 'M0460', 'AMILAMINA'),
                                                (461, 'M0461', 'CLORURO DE AMILO'),
                                                (462, 'M0462', '1-PENTENO (n-AMILENO)'),
                                                (463, 'M0463', 'FORMIATOS DE AMILO'),
                                                (464, 'M0464', 'n-AMILMETILCETONA'),
                                                (465, 'M0465', 'AMILMERCAPTANO'),
                                                (466, 'M0466', 'NITRATO DE AMILO'),
                                                (467, 'M0467', 'NITRITO DE AMILO'),
                                                (468, 'M0468', 'BENCENO'),
                                                (469, 'M0469', 'BUTANOLES'),
                                                (470, 'M0470', 'ACETATOS DE BUTILO'),
                                                (471, 'M0471', 'n-BUTILAMINA'),
                                                (472, 'M0472', '1-BROMOBUTANO'),
                                                (473, 'M0473', 'CLOROBUTANOS'),
                                                (474, 'M0474', 'FORMIATO DE n-BUTILO'),
                                                (475, 'M0475', 'BUTIRALDEHÍDO'),
                                                (476, 'M0476', 'ACEITE DE ALCANFOR'),
                                                (477, 'M0477', 'DISULFURO DE CARBONO'),
                                                (478, 'M0478', 'ADHESIVOS que contienen líquidos inflamables'),
                                                (479, 'M0479', 'CLOROBENCENO'),
                                                (480, 'M0480', 'ETILENCLORHIDRINA'),
                                                (481, 'M0481', 'DESTILADOS DE ALQUITRÁN DE HULLA, INFLAMABLES'),
                                                (482, 'M0482', 'SOLUCIONES PARA\r\nREVESTIMIENTOS (comprende los tratamientos de superficie o los revestimientos utilizados con fines industriales o de otra índole como revestimiento de bajos de vehículos, de bidones o de toneles)'),
                                                (483, 'M0483', 'CROTONALDEHÍDO o CROTONALDEHÍDO ESTABILIZADO'),
                                                (484, 'M0484', 'CROTONILENO'),
                                                (485, 'M0485', 'CICLOHEXANO'),
                                                (486, 'M0486', 'CICLOPENTANO'),
                                                (487, 'M0487', 'DECAHIDRONAFTALENO'),
                                                (488, 'M0488', 'DIACETONALCOHOL'),
                                                (489, 'M0489', 'DIBUTIL ÉTERES'),
                                                (490, 'M0490', '1,2-DICLOROETILENO'),
                                                (491, 'M0491', 'DICLOROPENTANOS'),
                                                (492, 'M0492', 'ÉTER DIETÍLICO DEL ETILENGLICOL'),
                                                (493, 'M0493', 'DIETILAMINA'),
                                                (494, 'M0494', 'ÉTER DIETÍLICO (ÉTER ETÍLICO)'),
                                                (495, 'M0495', 'DIETILCETONA'),
                                                (496, 'M0496', 'DIISOBUTILCETONA'),
                                                (497, 'M0497', 'DIISOPROPILAMINA'),
                                                (498, 'M0498', 'ÉTER DIISOPROPÍLICO'),
                                                (499, 'M0499', 'DIMETILAMINA EN SOLUCIÓN ACUOSA'),
                                                (500, 'M0500', 'CARBONATO DE DIMETILO'),
                                                (501, 'M0501', 'DIMETILDICLOROSILANO'),
                                                (502, 'M0502', 'DIMETILHIDRAZINA ASIMÉTRICA'),
                                                (503, 'M0503', 'SULFURO DE METILO'),
                                                (504, 'M0504', 'DIOXANO'),
                                                (505, 'M0505', 'DIOXOLANO'),
                                                (506, 'M0506', 'DIVINIL ÉTER ESTABILIZADO'),
                                                (507, 'M0507', 'EXTRACTOS AROMÁTICOS LÍQUIDOS'),
                                                (508, 'M0508', 'ETANOL (ALCOHOL ETÍLICO) o ETANOL EN SOLUCIÓN (ALCOHOL ETÍLICO EN SOLUCIÓN)'),
                                                (509, 'M0509', 'ÉTER MONOETÍLICO DEL ETILENGLICOL'),
                                                (510, 'M0510', 'ACETATO DEL ÉTER MONOETÍLICO DEL ETILENGLICOL'),
                                                (511, 'M0511', 'ACETATO DE ETILO'),
                                                (512, 'M0512', 'ETILBENCENO'),
                                                (513, 'M0513', 'BORATO DE ETILO'),
                                                (514, 'M0514', 'ACETATO DE 2-ETILBUTILO'),
                                                (515, 'M0515', '2-ETILBUTIRALDEHÍDO'),
                                                (516, 'M0516', 'ETIL BUTIL ÉTER'),
                                                (517, 'M0517', 'BUTIRATO DE ETILO'),
                                                (518, 'M0518', 'CLOROACETATO DE ETILO'),
                                                (519, 'M0519', 'CLOROFORMIATO DE ETILO'),
                                                (520, 'M0520', 'ETILDICLOROSILANO'),
                                                (521, 'M0521', 'DICLORURO DE ETILENO'),
                                                (522, 'M0522', 'ETILENIMINA (AZIRIDINA) ESTABILIZADA'),
                                                (523, 'M0523', 'ÉTER MONOMETÍLICO DEL ETILENGLICOL'),
                                                (524, 'M0524', 'ACETATO DEL ÉTER MONOMETÍLICO DEL ETILENGLICOL'),
                                                (525, 'M0525', 'FORMIATO DE ETILO'),
                                                (526, 'M0526', 'ALDEHÍDOS OCTÍLICOS'),
                                                (527, 'M0527', 'LACTATO DE ETILO'),
                                                (528, 'M0528', 'ETIL METIL CETONA (METIL ETIL CETONA)'),
                                                (529, 'M0529', 'NITRITO DE ETILO EN SOLUCIÓ'),
                                                (530, 'M0530', 'PROPIONATO DE ETILO'),
                                                (531, 'M0531', 'ETILTRICLOROSILANO'),
                                                (532, 'M0532', 'EXTRACTOS LÍQUIDOS PARA AROMATIZAR'),
                                                (533, 'M0533', 'FORMALDEHÍDO EN SOLUCIÓN INFLAMABLE'),
                                                (534, 'M0534', 'FURALDEHÍDOS'),
                                                (535, 'M0535', 'ACEITE DE FUSEL'),
                                                (536, 'M0536', 'GASÓLEO o COMBUSTIBLE PARA MOTORES DIESEL o ACEITE MINERAL LIGERO PARA CALEFACCIÓ'),
                                                (537, 'M0537', 'COMBUSTIBLE PARA MOTORES\r\noGASOLINA'),
                                                (538, 'M0538', 'NITROGLICERINA EN\r\nSOLUCIÓN ALCOHÓLICA con un máximo del 1 % de nitroglicerina'),
                                                (539, 'M0539', 'HEPTANOS'),
                                                (540, 'M0540', 'HEXALDEHÍDO'),
                                                (541, 'M0541', 'HEXANOS'),
                                                (542, 'M0542', 'TINTA DE IMPRENTA, inflamable\r\noMATERIALES\r\nRELACIONADOS CON LA TINTA DE IMPRENTA (incluido diluyente de tinta de imprenta o producto reductor), inflamables'),
                                                (543, 'M0543', 'ISOBUTANOL (ALCOHOL ISOBUTÍLICO)'),
                                                (544, 'M0544', 'ACETATO DE ISOBUTILO'),
                                                (545, 'M0545', 'ISOBUTILAMINA'),
                                                (546, 'M0546', 'ISOOCTENOS'),
                                                (547, 'M0547', 'ISOPRENO ESTABILIZADO'),
                                                (548, 'M0548', 'ISOPROPANOL (ALCOHOL ISOPROPÍLICO)'),
                                                (549, 'M0549', 'ACETATO DE ISOPROPILO'),
                                                (550, 'M0550', 'ISOPROPILAMINA'),
                                                (551, 'M0551', 'NITRATO DE ISOPROPILO'),
                                                (552, 'M0552', 'QUEROSENO'),
                                                (553, 'M0553', 'CETONAS LÍQUIDAS, N.E.P.'),
                                                (554, 'M0554', 'MERCAPTANOS LÍQUIDOS, INFLAMABLES, TÓXICOS, N.E.P. o MERCAPTANOS EN MEZCLA LÍQUIDA, INFLAMABLE, TÓXICA, N.E.P.'),
                                                (555, 'M0555', 'ÓXIDO DE MESITILO'),
                                                (556, 'M0556', 'METANOL'),
                                                (557, 'M0557', 'ACETATO DE METILO'),
                                                (558, 'M0558', 'ACETATO DE METILAMILO'),
                                                (559, 'M0559', 'METILAL (DIMETOXIMETANO)'),
                                                (560, 'M0560', 'METILAMINA EN SOLUCIÓN ACUOSA'),
                                                (561, 'M0561', 'BUTIRATO DE METILO'),
                                                (562, 'M0562', 'CLOROFORMIATO DE METILO'),
                                                (563, 'M0563', 'METIL CLOROMETIL ÉTER'),
                                                (564, 'M0564', 'METILDICLOROSILANO'),
                                                (565, 'M0565', 'FORMIATO DE METILO'),
                                                (566, 'M0566', 'METILHIDRAZINA'),
                                                (567, 'M0567', 'METILISOBUTILCETONA'),
                                                (568, 'M0568', 'METILISOPROPENIL-CETONA ESTABILIZADA'),
                                                (569, 'M0569', 'METACRILATO DE METILO MONÓMERO ESTABILIZADO'),
                                                (570, 'M0570', 'PROPIONATO DE METILO'),
                                                (571, 'M0571', 'METILPROPILCETONA'),
                                                (572, 'M0572', 'METILTRICLOROSILANO'),
                                                (573, 'M0573', 'METILVINILCETONA, ESTABILIZADA'),
                                                (574, 'M0574', 'NÍQUEL CARBONILO'),
                                                (575, 'M0575', 'NITROMETANO'),
                                                (576, 'M0576', 'OCTANOS'),
                                                (577, 'M0577', 'PINTURA (incluye pintura, laca, esmalte, colorante, goma laca, barniz, encáustico, apresto líquido y base líquida para lacas) o PRODUCTOS PARA PINTURA (incluye solventes y diluyentes para pinturas)'),
                                                (578, 'M0578', 'PARALDEHÍDO'),
                                                (579, 'M0579', 'PENTANOS líquidos'),
                                                (580, 'M0580', 'PRODUCTOS DE PERFUMERÍA que contengan disolventes inflamables'),
                                                (581, 'M0581', 'PETRÓLEO BRUTO'),
                                                (582, 'M0582', 'DESTILADOS DE PETRÓLEO, N.E.P. o PRODUCTOS DE PETRÓLEO, N.E.P.'),
                                                (583, 'M0583', 'ACEITE DE PINO'),
                                                (584, 'M0584', 'n-PROPANOL (ALCOHOL PROPÍLICO NORMAL)'),
                                                (585, 'M0585', 'PROPIONALDEHÍDO'),
                                                (586, 'M0586', 'ACETATO DE n-PROPILO'),
                                                (587, 'M0587', 'PROPILAMINA'),
                                                (588, 'M0588', '1-CLOROPROPANO'),
                                                (589, 'M0589', '1,2-DICLOROPROPANO'),
                                                (590, 'M0590', 'ÓXIDO DE PROPILENO'),
                                                (591, 'M0591', 'FORMIATOS DE PROPILO'),
                                                (592, 'M0592', 'PIRIDINA'),
                                                (593, 'M0593', 'ACEITE DE COLOFONIA'),
                                                (594, 'M0594', 'DISOLUCIÓN DE CAUCHO'),
                                                (595, 'M0595', 'ACEITE DE ESQUISTO'),
                                                (596, 'M0596', 'METILATO DE SODIO EN SOLUCIÓN alcohólica'),
                                                (597, 'M0597', 'SILICATO DE TETRAETILO'),
                                                (598, 'M0598', 'TINTURAS MEDICINALES'),
                                                (599, 'M0599', 'TOLUENO'),
                                                (600, 'M0600', 'TRICLOROSILANO'),
                                                (601, 'M0601', 'TRIETILAMINA'),
                                                (602, 'M0602', 'TRIMETILAMINA EN SOLUCIÓN ACUOSA, con un máximo del 50 %, en masa, de trimetilamina'),
                                                (603, 'M0603', 'TRIMETILCLOROSILANO'),
                                                (604, 'M0604', 'TREMENTINA'),
                                                (605, 'M0605', 'SUCEDÁNEO DE TREMENTINA'),
                                                (606, 'M0606', 'ACETATO DE VINILO ESTABILIZADO'),
                                                (607, 'M0607', 'VINIL ETIL ÉTER ESTABILIZADO'),
                                                (608, 'M0608', 'CLORURO DE VINILIDENO ESTABILIZADO'),
                                                (609, 'M0609', 'VINIL ISOBUTIL ÉTER ESTABILIZADO'),
                                                (610, 'M0610', 'VINILTRICLOROSILANO'),
                                                (611, 'M0611', 'PRODUCTOS LÍQUIDOS PARA LA CONSERVACIÓN DE LA MADERA'),
                                                (612, 'M0612', 'XILENOS'),
                                                (613, 'M0613', 'CIRCONIO EN SUSPENSIÓN EN UN LÍQUIDO INFLAMABLE'),
                                                (614, 'M0614', 'ALUMINIO EN POLVO, RECUBIERTO'),
                                                (615, 'M0615', 'PICRATO DE AMONIO\r\nHUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                                (616, 'M0616', 'BORNEOL'),
                                                (617, 'M0617', 'RESINATO DE CALCIO'),
                                                (618, 'M0618', 'RESINATO DE CALCIO FUNDIDO'),
                                                (619, 'M0619', 'RESINATO DE COBALTO, PRECIPITADO'),
                                                (620, 'M0620', 'DINITROFENOL HUMEDECIDO con un mínimo del 15 %, en masa, de agua'),
                                                (621, 'M0621', 'DINITROFENOLATOS HUMEDECIDOS con un mínimo del 15 %, en masa, de agua'),
                                                (622, 'M0622', 'DINITRORRESORCINOL (DINITRORRESORCINA) HUMEDECIDO con un mínimo del 15 %, en masa, de agua'),
                                                (623, 'M0623', 'FERROCERIO'),
                                                (624, 'M0624', 'PELÍCULAS DE SOPORTE NITROCELULÓSICO revestido de gelatina, con exclusión de los desechos'),
                                                (625, 'M0625', 'SÓLIDO INFLAMABLE ORGÁNICO, N.E.P.'),
                                                (626, 'M0626', 'HAFNIO EN POLVO,\r\nHUMEDECIDO con un mínimo del 25 % de agua (debe haber un exceso visible de agua): a) producido mecánicamente, en partículas de menos de 53 micrones; b) producido químicamente, en partículas de menos de 840 micrones'),
                                                (627, 'M0627', 'HENO, PAJA o BUSHA (TAMO)'),
                                                (628, 'M0628', 'HEXAMETILENTETRAMINA'),
                                                (629, 'M0629', 'RESINATO DE MANGANESO'),
                                                (630, 'M0630', 'FÓSFOROS DISTINTOS DE LOS DE SEGURIDAD'),
                                                (631, 'M0631', 'METALDEHÍDO'),
                                                (632, 'M0632', 'CERIO, en placas, lingotes o barras'),
                                                (633, 'M0633', 'NAFTALENO BRUTO o NAFTALENO REFINADO'),
                                                (634, 'M0634', 'NITROGUANIDINA (PICRITA) HUMEDECIDA con un mínimo del 20 %, en masa, de agua'),
                                                (635, 'M0635', 'NITROALMIDÓN HUMEDECIDO con un mínimo del 20 %, en masa, de agua'),
                                                (636, 'M0636', 'FÓSFORO AMORFO'),
                                                (637, 'M0637', 'HEPTASULFURO DE FÓSFORO, que no contiene fósforo blanco o amarillo'),
                                                (638, 'M0638', 'PENTASULFURO DE FÓSFORO, que no contiene fósforo blanco o amarillo'),
                                                (639, 'M0639', 'SESQUISULFURO DE FÓSFORO, que no contiene fósforo blanco o amarillo'),
                                                (640, 'M0640', 'TRISULFURO DE FÓSFORO, que no contiene fósforo blanco o amarillo'),
                                                (641, 'M0641', 'TRINITROFENOL (ÁCIDO PÍCRICO) HUMEDECIDO con un mínimo del 30 %, en masa, de agua'),
                                                (642, 'M0642', 'DESECHOS DE CAUCHO o RECORTES DE CAUCHO, en polvo o en gránulos de 840 micrones como máximo y que contienen más del 45 % de caucho'),
                                                (643, 'M0643', 'SILICIO EN POLVO, AMORFO'),
                                                (644, 'M0644', 'PICRATO DE PLATA\r\nHUMEDECIDO con un mínimo del 30 %, en masa, de agua'),
                                                (645, 'M0645', 'DINITRO-o-CRESOLATO DE SODIO HUMEDECIDO con un mínimo del 15 %, en masa, de agua'),
                                                (646, 'M0646', 'PICRAMATO DE SODIO HUMEDECIDO con un mínimo del 20 %, en masa, de agua'),
                                                (647, 'M0647', 'AZUFRE'),
                                                (648, 'M0648', 'TITANIO EN POLVO,\r\nHUMEDECIDO con un mínimo del 25 % de agua (debe haber un exceso visible de agua): a) producido mecánicamente, en partículas de menos de 53 micrones; b) producido químicamente, en partículas de menos de 840 micrones'),
                                                (649, 'M0649', 'FIBRAS o TEJIDOS IMPREGNADOS DE NITROCELULOSA POCO NITRADA, N.E.P.'),
                                                (650, 'M0650', 'TRINITROBENCENO\r\nHUMEDECIDO con un mínimo del\r\n30 %, en masa, de agua'),
                                                (651, 'M0651', 'ÁCIDO TRINITROBENZOICO HUMEDECIDO con un mínimo del\r\n30 %, en masa, de agua'),
                                                (652, 'M0652', 'TRINITROTOLUENO (TNT) HUMEDECIDO con un mínimo del 30 %, en masa, de agua'),
                                                (653, 'M0653', 'NITRATO DE UREA\r\nHUMEDECIDO con un mínimo del 20 %, en masa, de agua'),
                                                (654, 'M0654', 'CIRCONIO EN POLVO,\r\nHUMEDECIDO con un mínimo del 25 % de agua (debe haber un exceso visible de agua): a) producido mecánicamente, en partículas de menos de 53 micrones; b) producido químicamente, en partículas de menos de 840 micrones'),
                                                (655, 'M0655', 'FOSFURO DE CALCIO'),
                                                (656, 'M0656', 'CARBÓN animal o vegetal'),
                                                (657, 'M0657', 'CARBÓN ACTIVADO'),
                                                (658, 'M0658', 'COPRA'),
                                                (659, 'M0659', 'DESECHOS GRASIENTOS DE ALGODÓ'),
                                                (660, 'M0660', 'ALGODÓN HÚMEDO'),
                                                (661, 'M0661', 'p-NITROSODIMETILANILINA'),
                                                (662, 'M0662', 'FIBRAS DE ORIGEN ANIMAL o FIBRAS DE ORIGEN VEGETAL quemadas, húmedas o mojadas'),
                                                (663, 'M0663', 'FIBRAS o TEJIDOS DE ORIGEN ANIMAL o VEGETAL o SINTÉTICOS, N.E.P., impregnados de aceite'),
                                                (664, 'M0664', 'HARINA DE PESCADO (DESECHOS DE PESCADO) NO ESTABILIZADA'),
                                                (665, 'M0665', 'ÓXIDO DE HIERRO AGOTADO o HIERRO ESPONJOSO AGOTADO procedentes de la purificación del gas de hulla'),
                                                (666, 'M0666', 'CATALIZADOR DE METAL HUMEDECIDO con un exceso visible de líquido'),
                                                (667, 'M0667', 'PAPEL TRATADO CON ACEITES NO SATURADOS, incompletamente seco (incluso el papel carbón)'),
                                                (668, 'M0668', 'PENTABORANO'),
                                                (669, 'M0669', 'FÓSFORO BLANCO o\r\nAMARILLO, SECO o BAJO AGUA\r\noEN SOLUCIÓ'),
                                                (670, 'M0670', 'SULFURO DE POTASIO ANHIDRO o SULFURO DE POTASIO con menos del 30 % de agua de cristalización'),
                                                (671, 'M0671', 'METAL PIROFÓRICO, N.E.P., o ALEACIÓN PIROFÓRICA, N.E.P.'),
                                                (672, 'M0672', 'DITIONITO DE SODIO (HIDROSULFITO DE SODIO)'),
                                                (673, 'M0673', 'SULFURO DE SODIO ANHIDRO\r\noSULFURO DE SODIO con menos\r\ndel 30 % de agua de cristalización'),
                                                (674, 'M0674', 'TORTA OLEAGINOSA con más del 1,5 % de aceite y un máximo del 11 % de humedad'),
                                                (675, 'M0675', 'DESECHOS DE LANA, HÚMEDOS'),
                                                (676, 'M0676', 'METALES ALCALINOS, AMALGAMA LÍQUIDA DE,'),
                                                (677, 'M0677', 'AMIDAS DE METALES ALCALINOS'),
                                                (678, 'M0678', 'METALES ALCALINOS, DISPERSIÓN DE, o METALES ALCALINOTÉRREOS, DISPERSIÓN DE'),
                                                (679, 'M0679', 'METALES ALCALINOTÉRREOS, AMALGAMA LÍQUIDA DE'),
                                                (680, 'M0680', 'METALES ALCALINOTÉRREOS, ALEACIÓN DE, N.E.P.'),
                                                (681, 'M0681', 'CARBURO DE ALUMINIO'),
                                                (682, 'M0682', 'ALUMINIOFERROSILICIO EN POLVO');
                                                INSERT INTO `portematpeligrosos` (`Id`, `ClaveMatPel`, `Descripcion`) VALUES
                                                (683, 'M0683', 'ALUMINIO EN POLVO, NO RECUBIERTO'),
                                                (684, 'M0684', 'FOSFURO DE ALUMINIO'),
                                                (685, 'M0685', 'ALUMINIOSILICIO EN POLVO, NO RECUBIERTO'),
                                                (686, 'M0686', 'BARIO'),
                                                (687, 'M0687', 'CALCIO'),
                                                (688, 'M0688', 'CARBURO DE CALCIO'),
                                                (689, 'M0689', 'CIANAMIDA DE CALCIO con más del 0,1 % de carburo de calcio'),
                                                (690, 'M0690', 'HIDRURO DE CALCIO'),
                                                (691, 'M0691', 'SILICIURO DE CALCIO'),
                                                (692, 'M0692', 'CESIO'),
                                                (693, 'M0693', 'FERROSILICIO con el 30 % o más pero menos del 90 % de silicio'),
                                                (694, 'M0694', 'HIDRUROS METÁLICOS QUE REACCIONAN CON EL AGUA, N.E.P.'),
                                                (695, 'M0695', 'HIDRURO DE LITIO Y ALUMINIO'),
                                                (696, 'M0696', 'HIDRURO DE LITIO Y ALUMINIO EN ÉTER'),
                                                (697, 'M0697', 'BOROHIDRURO DE LITIO'),
                                                (698, 'M0698', 'HIDRURO DE LITIO'),
                                                (699, 'M0699', 'LITIO'),
                                                (700, 'M0700', 'LITIOSILICIO'),
                                                (701, 'M0701', 'MAGNESIO EN POLVO o ALEACIONES DE MAGNESIO EN POLVO'),
                                                (702, 'M0702', 'FOSFURO DE MAGNESIO Y ALUMINIO'),
                                                (703, 'M0703', 'POTASIO, ALEACIONES METÁLICAS LÍQUIDAS DE'),
                                                (704, 'M0704', 'METALES ALCALINOS, ALEACIÓN LÍQUIDA DE, N.E.P.'),
                                                (705, 'M0705', 'POTASIO Y SODIO, ALEACIONES LÍQUIDAS DE'),
                                                (706, 'M0706', 'RUBIDIO'),
                                                (707, 'M0707', 'BOROHIDRURO DE SODIO'),
                                                (708, 'M0708', 'HIDRURO DE SODIO'),
                                                (709, 'M0709', 'SODIO'),
                                                (710, 'M0710', 'METILATO DE SODIO'),
                                                (711, 'M0711', 'FOSFURO DE SODIO'),
                                                (712, 'M0712', 'FOSFUROS DE ESTAÑO(IV)'),
                                                (713, 'M0713', 'CINC, CENIZAS DE'),
                                                (714, 'M0714', 'CINC EN POLVO'),
                                                (715, 'M0715', 'HIDRURO DE CIRCONIO'),
                                                (716, 'M0716', 'NITRATO DE ALUMINIO'),
                                                (717, 'M0717', 'DICROMATO DE AMONIO'),
                                                (718, 'M0718', 'PERCLORATO DE AMONIO'),
                                                (719, 'M0719', 'PERSULFATO DE AMONIO'),
                                                (720, 'M0720', 'CLORATO DE BARIO, SÓLIDO'),
                                                (721, 'M0721', 'NITRATO DE BARIO'),
                                                (722, 'M0722', 'PERCLORATO DE BARIO, SÓLIDO'),
                                                (723, 'M0723', 'PERMANGANATO DE BARIO'),
                                                (724, 'M0724', 'PERÓXIDO DE BARIO'),
                                                (725, 'M0725', 'BROMATOS INORGÁNICOS, N.E.P.'),
                                                (726, 'M0726', 'NITRATO DE CESIO'),
                                                (727, 'M0727', 'CLORATO DE CALCIO'),
                                                (728, 'M0728', 'CLORITO DE CALCIO'),
                                                (729, 'M0729', 'NITRATO DE CALCIO'),
                                                (730, 'M0730', 'PERCLORATO DE CALCIO'),
                                                (731, 'M0731', 'PERMANGANATO DE CALCIO'),
                                                (732, 'M0732', 'PERÓXIDO DE CALCIO'),
                                                (733, 'M0733', 'CLORATO Y BORATO, MEZCLA DE'),
                                                (734, 'M0734', 'CLORATO Y CLORURO DE MAGNESIO, MEZCLA SÓLIDA DE'),
                                                (735, 'M0735', 'CLORATOS INORGÁNICOS, N.E.P.'),
                                                (736, 'M0736', 'CLORITOS INORGÁNICOS, N.E.P.'),
                                                (737, 'M0737', 'TRIÓXIDO DE CROMO ANHIDRO'),
                                                (738, 'M0738', 'NITRATO DE DIDIMIO'),
                                                (739, 'M0739', 'NITRATO DE HIERRO(III)'),
                                                (740, 'M0740', 'NITRATO DE GUANIDINA'),
                                                (741, 'M0741', 'NITRATO DE PLOMO'),
                                                (742, 'M0742', 'PERCLORATO DE PLOMO, SÓLIDO'),
                                                (743, 'M0743', 'HIPOCLORITO DE LITIO, SECO o HIPOCLORITO DE LITIO EN MEZCLA'),
                                                (744, 'M0744', 'PERÓXIDO DE LITIO'),
                                                (745, 'M0745', 'BROMATO DE MAGNESIO'),
                                                (746, 'M0746', 'NITRATO DE MAGNESIO'),
                                                (747, 'M0747', 'PERCLORATO DE MAGNESIO'),
                                                (748, 'M0748', 'PERÓXIDO DE MAGNESIO'),
                                                (749, 'M0749', 'NITRATOS INORGÁNICOS, N.E.P.'),
                                                (750, 'M0750', 'SÓLIDO COMBURENTE, N.E.P.'),
                                                (751, 'M0751', 'PERCLORATOS INORGÁNICOS, N.E.P.'),
                                                (752, 'M0752', 'PERMANGANATOS INORGÁNICOS, N.E.P.'),
                                                (753, 'M0753', 'PERÓXIDOS INORGÁNICOS, N.E.P.'),
                                                (754, 'M0754', 'BROMATO DE POTASIO'),
                                                (755, 'M0755', 'CLORATO DE POTASIO'),
                                                (756, 'M0756', 'NITRATO DE POTASIO'),
                                                (757, 'M0757', 'NITRATO DE POTASIO Y NITRITO DE SODIO, MEZCLA DE'),
                                                (758, 'M0758', 'NITRITO DE POTASIO'),
                                                (759, 'M0759', 'PERCLORATO DE POTASIO'),
                                                (760, 'M0760', 'PERMANGANATO DE POTASIO'),
                                                (761, 'M0761', 'PERÓXIDO DE POTASIO'),
                                                (762, 'M0762', 'PERSULFATO DE POTASIO'),
                                                (763, 'M0763', 'NITRATO DE PLATA'),
                                                (764, 'M0764', 'BROMATO DE SODIO'),
                                                (765, 'M0765', 'CLORATO DE SODIO'),
                                                (766, 'M0766', 'CLORITO DE SODIO'),
                                                (767, 'M0767', 'NITRATO DE SODIO'),
                                                (768, 'M0768', 'NITRATO DE SODIO Y NITRATO DE POTASIO, MEZCLA DE'),
                                                (769, 'M0769', 'NITRITO DE SODIO'),
                                                (770, 'M0770', 'PERCLORATO DE SODIO'),
                                                (771, 'M0771', 'PERMANGANATO DE SODIO'),
                                                (772, 'M0772', 'PERÓXIDO DE SODIO'),
                                                (773, 'M0773', 'PERSULFATO DE SODIO'),
                                                (774, 'M0774', 'CLORATO DE ESTRONCIO'),
                                                (775, 'M0775', 'NITRATO DE ESTRONCIO'),
                                                (776, 'M0776', 'PERCLORATO DE ESTRONCIO'),
                                                (777, 'M0777', 'PERÓXIDO DE ESTRONCIO'),
                                                (778, 'M0778', 'TETRANITROMETANO'),
                                                (779, 'M0779', 'UREA-PERÓXIDO DE HIDRÓGENO'),
                                                (780, 'M0780', 'NITRITO DE CINC Y AMONIO'),
                                                (781, 'M0781', 'CLORATO DE CINC'),
                                                (782, 'M0782', 'NITRATO DE CINC'),
                                                (783, 'M0783', 'PERMANGANATO DE CINC'),
                                                (784, 'M0784', 'PERÓXIDO DE CINC'),
                                                (785, 'M0785', 'PICRAMATO DE CIRCONIO HUMEDECIDO con un mínimo del 20 %, en masa, de agua'),
                                                (786, 'M0786', 'CIANHIDRINA DE LA ACETONA, ESTABILIZADA'),
                                                (787, 'M0787', 'ALCALOIDES SÓLIDOS, N.E.P.,\r\noSALES DE ALCALOIDES, SÓLIDAS, N.E.P.'),
                                                (788, 'M0788', 'ISOTIOCIANATO DE ALILO ESTABILIZADO'),
                                                (789, 'M0789', 'ARSENIATO DE AMONIO'),
                                                (790, 'M0790', 'ANILINA'),
                                                (791, 'M0791', 'CLORHIDRATO DE ANILINA'),
                                                (792, 'M0792', 'ANTIMONIO, COMPUESTO INORGÁNICO SÓLIDO DE, N.E.P.'),
                                                (793, 'M0793', 'LACTATO DE ANTIMONIO'),
                                                (794, 'M0794', 'TARTRATO DE ANTIMONIO Y POTASIO'),
                                                (795, 'M0795', 'ÁCIDO ARSÉNICO LÍQUIDO'),
                                                (796, 'M0796', 'ÁCIDO ARSÉNICO SÓLIDO'),
                                                (797, 'M0797', 'BROMURO DE ARSÉNICO'),
                                                (798, 'M0798', 'ARSÉNICO, COMPUESTO LÍQUIDO DE, N.E.P., inorgánico, en particular arseniatos, n.e.p., arsenitos, n.e.p., sulfuros de arsénico, n.e.p., y compuesto orgánico de arsénico, n.e.p.'),
                                                (799, 'M0799', 'ARSÉNICO, COMPUESTO SÓLIDO DE, N.E.P., inorgánico, en particular arseniatos n.e.p., arsenitos n.e.p., sulfuros de arsénico n.e.p. y compuesto orgánico de arsénico n.e.p.'),
                                                (800, 'M0800', 'ARSÉNICO'),
                                                (801, 'M0801', 'PENTÓXIDO DE ARSÉNICO'),
                                                (802, 'M0802', 'TRICLORURO DE ARSÉNICO'),
                                                (803, 'M0803', 'TRIÓXIDO DE ARSÉNICO'),
                                                (804, 'M0804', 'POLVO ARSENICAL'),
                                                (805, 'M0805', 'BARIO, COMPUESTO DE, N.E.P.'),
                                                (806, 'M0806', 'CIANURO DE BARIO'),
                                                (807, 'M0807', 'BERILIO, COMPUESTO DE, N.E.P.'),
                                                (808, 'M0808', 'BERILIO EN POLVO'),
                                                (809, 'M0809', 'BROMOACETONA'),
                                                (810, 'M0810', 'BRUCINA'),
                                                (811, 'M0811', 'AZIDA DE BARIO HUMEDECIDA con un mínimo del 50 %, en masa, de agua'),
                                                (812, 'M0812', 'ÁCIDO CACODÍLICO'),
                                                (813, 'M0813', 'ARSENIATO DE CALCIO'),
                                                (814, 'M0814', 'ARSENIATO DE CALCIO Y ARSENITO DE CALCIO EN MEZCLA SÓLIDA'),
                                                (815, 'M0815', 'CIANURO DE CALCIO'),
                                                (816, 'M0816', 'CLORODINITROBENCENOS LÍQUIDOS'),
                                                (817, 'M0817', 'CLORONITROBENCENOS SÓLIDOS'),
                                                (818, 'M0818', 'CLORHIDRATO DE 4-CLORO-o- TOLUIDINA, SÓLIDO'),
                                                (819, 'M0819', 'CLOROPICRINA'),
                                                (820, 'M0820', 'CLOROPICRINA Y BROMURO DE METILO, MEZCLA DE, con más del 2 % de cloropicrina'),
                                                (821, 'M0821', 'CLOROPICRINA Y CLORURO DE METILO, MEZCLA DE'),
                                                (822, 'M0822', 'CLOROPICRINA EN MEZCLA, N.E.P.'),
                                                (823, 'M0823', 'ACETOARSENITO DE COBRE'),
                                                (824, 'M0824', 'ARSENITO DE COBRE'),
                                                (825, 'M0825', 'CIANURO DE COBRE'),
                                                (826, 'M0826', 'CIANUROS INORGÁNICOS, SÓLIDOS, N.E.P.'),
                                                (827, 'M0827', 'CLORURO DE CIANÓGENO ESTABILIZADO'),
                                                (828, 'M0828', 'DICLOROANILINAS LÍQUIDAS'),
                                                (829, 'M0829', 'o-DICLOROBENCENO'),
                                                (830, 'M0830', 'DICLOROMETANO'),
                                                (831, 'M0831', 'SULFATO DE DIETILO'),
                                                (832, 'M0832', 'SULFATO DE DIMETILO'),
                                                (833, 'M0833', 'DINITROANILINAS'),
                                                (834, 'M0834', 'DINITROBENCENOS LÍQUIDOS'),
                                                (835, 'M0835', 'DINITRO-o-CRESOL'),
                                                (836, 'M0836', 'DINITROFENOL EN SOLUCIÓ'),
                                                (837, 'M0837', 'DINITROTOLUENOS FUNDIDOS'),
                                                (838, 'M0838', 'DESINFECTANTE SÓLIDO, TÓXICO, N.E.P.'),
                                                (839, 'M0839', 'COLORANTE LÍQUIDO, TÓXICO, N.E.P. o MATERIA INTERMEDIA PARA COLORANTES, LÍQUIDA, TÓXICA, N.E.P.'),
                                                (840, 'M0840', 'BROMOACETATO DE ETILO'),
                                                (841, 'M0841', 'ETILENDIAMINA'),
                                                (842, 'M0842', 'DIBROMURO DE ETILENO'),
                                                (843, 'M0843', 'ARSENIATO DE HIERRO(III)'),
                                                (844, 'M0844', 'ARSENITO DE HIERRO(III)'),
                                                (845, 'M0845', 'ARSENIATO DE HIERRO(II)'),
                                                (846, 'M0846', 'TETRAFOSFATO DE HEXAETILO'),
                                                (847, 'M0847', 'TETRAFOSFATO DE HEXAETILO Y GAS COMPRIMIDO, MEZCLA DE'),
                                                (848, 'M0848', 'ÁCIDO CIANHÍDRICO EN SOLUCIÓN ACUOSA (CIANURO DE HIDRÓGENO EN SOLUCIÓN ACUOSA) con un máximo del 20 % de cianuro de hidrógeno'),
                                                (849, 'M0849', 'CIANURO DE HIDRÓGENO ESTABILIZADO con menos del 3 % de agua y absorbido en una materia porosa inerte'),
                                                (850, 'M0850', 'ACETATO DE PLOMO'),
                                                (851, 'M0851', 'ARSENIATOS DE PLOMO'),
                                                (852, 'M0852', 'ARSENITOS DE PLOMO'),
                                                (853, 'M0853', 'CIANURO DE PLOMO'),
                                                (854, 'M0854', 'PÚRPURA DE LONDRES'),
                                                (855, 'M0855', 'ARSENIATO DE MAGNESIO'),
                                                (856, 'M0856', 'ARSENIATO DE MERCURIO(II)'),
                                                (857, 'M0857', 'CLORURO DE MERCURIO(II)'),
                                                (858, 'M0858', 'NITRATO DE MERCURIO(II)'),
                                                (859, 'M0859', 'CIANURO DE MERCURIO Y POTASIO'),
                                                (860, 'M0860', 'NITRATO DE MERCURIO(I)'),
                                                (861, 'M0861', 'ACETATO DE MERCURIO'),
                                                (862, 'M0862', 'CLORURO DE MERCURIO Y AMONIO'),
                                                (863, 'M0863', 'BENZOATO DE MERCURIO'),
                                                (864, 'M0864', 'BROMUROS DE MERCURIO'),
                                                (865, 'M0865', 'CIANURO DE MERCURIO'),
                                                (866, 'M0866', 'GLUCONATO DE MERCURIO'),
                                                (867, 'M0867', 'YODURO DE MERCURIO'),
                                                (868, 'M0868', 'NUCLEATO DE MERCURIO'),
                                                (869, 'M0869', 'OLEATO DE MERCURIO'),
                                                (870, 'M0870', 'ÓXIDO DE MERCURIO'),
                                                (871, 'M0871', 'OXICIANURO DE MERCURIO, DESENSIBILIZADO'),
                                                (872, 'M0872', 'YODURO DE MERCURIO Y POTASIO'),
                                                (873, 'M0873', 'SALICILATO DE MERCURIO'),
                                                (874, 'M0874', 'SULFATO DE MERCURIO'),
                                                (875, 'M0875', 'TIOCIANATO DE MERCURIO'),
                                                (876, 'M0876', 'BROMURO DE METILO Y DIBROMURO DE ETILENO, MEZCLA LÍQUIDA DE'),
                                                (877, 'M0877', 'ACETONITRILO'),
                                                (878, 'M0878', 'MEZCLA ANTIDETONANTE PARA COMBUSTIBLES DE MOTORES'),
                                                (879, 'M0879', 'beta-NAFTILAMINA SÓLIDA'),
                                                (880, 'M0880', 'NAFTILTIOUREA'),
                                                (881, 'M0881', 'NAFTILUREA'),
                                                (882, 'M0882', 'CIANURO DE NÍQUEL'),
                                                (883, 'M0883', 'NICOTINA'),
                                                (884, 'M0884', 'NICOTINA, COMPUESTO SÓLIDO DE, N.E.P., o PREPARADO SÓLIDO A BASE DE NICOTINA, N.E.P.'),
                                                (885, 'M0885', 'CLORHIDRATO DE NICOTINA, LÍQUIDO o EN SOLUCIÓ'),
                                                (886, 'M0886', 'SALICILATO DE NICOTINA'),
                                                (887, 'M0887', 'SULFATO DE NICOTINA, EN SOLUCIÓ'),
                                                (888, 'M0888', 'TARTRATO DE NICOTINA'),
                                                (889, 'M0889', 'ÓXIDO NÍTRICO COMPRIMIDO'),
                                                (890, 'M0890', 'NITROANILINAS (o-, m-, p-)'),
                                                (891, 'M0891', 'NITROBENCENO'),
                                                (892, 'M0892', 'NITROFENOLES (o-, m-, p-)'),
                                                (893, 'M0893', 'NITROTOLUENOS LÍQUIDOS'),
                                                (894, 'M0894', 'NITROXILENOS LÍQUIDOS'),
                                                (895, 'M0895', 'PENTACLOROETANO'),
                                                (896, 'M0896', 'PERCLOROMETIL- MERCAPTANO'),
                                                (897, 'M0897', 'FENOL SÓLIDO'),
                                                (898, 'M0898', 'CLORURO DE\r\nFENILCARBILAMINA'),
                                                (899, 'M0899', 'FENILENDIAMINAS (o-, m-, p-)'),
                                                (900, 'M0900', 'ACETATO DE FENILMERCURIO'),
                                                (901, 'M0901', 'ARSENIATO DE POTASIO'),
                                                (902, 'M0902', 'ARSENITO DE POTASIO'),
                                                (903, 'M0903', 'CUPROCIANURO DE POTASIO'),
                                                (904, 'M0904', 'CIANURO DE POTASIO SÓLIDO'),
                                                (905, 'M0905', 'ARSENITO DE PLATA'),
                                                (906, 'M0906', 'CIANURO DE PLATA'),
                                                (907, 'M0907', 'ARSENIATO DE SODIO'),
                                                (908, 'M0908', 'ARSENITO DE SODIO EN SOLUCIÓN ACUOSA'),
                                                (909, 'M0909', 'AZIDA DE SODIO'),
                                                (910, 'M0910', 'CACODILATO DE SODIO'),
                                                (911, 'M0911', 'CIANURO DE SODIO SÓLIDO'),
                                                (912, 'M0912', 'FLUORURO DE SODIO SÓLIDO'),
                                                (913, 'M0913', 'ARSENITO DE ESTRONCIO'),
                                                (914, 'M0914', 'ESTRICNINA o SALES DE ESTRICNINA'),
                                                (915, 'M0915', 'GASES LACRIMÓGENOS, SUSTANCIA LÍQUIDA PARA LA FABRICACIÓN DE, N.E.P.'),
                                                (916, 'M0916', 'CIANUROS DE BROMOBENCILO LÍQUIDOS'),
                                                (917, 'M0917', 'CLOROACETONA ESTABILIZADA'),
                                                (918, 'M0918', 'CLOROACETOFENONA SÓLIDA'),
                                                (919, 'M0919', 'DIFENILAMINO-CLOROARSINA'),
                                                (920, 'M0920', 'DIFENILCLOROARSINA LÍQUIDA'),
                                                (921, 'M0921', 'VELAS LACRIMÓGENAS'),
                                                (922, 'M0922', 'BROMURO DE XILILO, LÍQUIDO'),
                                                (923, 'M0923', '1,1,2,2-TETRACLOROETANO'),
                                                (924, 'M0924', 'DITIOPIROFOSFATO DE TETRAETILO'),
                                                (925, 'M0925', 'TALIO, COMPUESTO DE, N.E.P.'),
                                                (926, 'M0926', 'TOLUIDINAS LÍQUIDAS'),
                                                (927, 'M0927', 'TOLUILEN-2,4-DIAMINA SÓLIDA'),
                                                (928, 'M0928', 'TRICLOROETILENO'),
                                                (929, 'M0929', 'XILIDINAS LÍQUIDAS'),
                                                (930, 'M0930', 'ARSENIATO DE CINC,\r\nARSENITO DE CINC o MEZCLA DE ARSENIATO DE CINC Y ARSENITO DE CINC'),
                                                (931, 'M0931', 'CIANURO DE CINC'),
                                                (932, 'M0932', 'FOSFURO DE CINC'),
                                                (933, 'M0933', 'ANHÍDRIDO ACÉTICO'),
                                                (934, 'M0934', 'BROMURO DE ACETILO'),
                                                (935, 'M0935', 'CLORURO DE ACETILO'),
                                                (936, 'M0936', 'FOSFATO ÁCIDO DE BUTILO'),
                                                (937, 'M0937', 'LÍQUIDO ALCALINO CAÚSTICO N.E.P.'),
                                                (938, 'M0938', 'CLOROFORMIATO DE ALILO'),
                                                (939, 'M0939', 'YODURO DE ALILO'),
                                                (940, 'M0940', 'ALILTRICLOROSILANO ESTABILIZADO'),
                                                (941, 'M0941', 'BROMURO DE ALUMINIO ANHIDRO'),
                                                (942, 'M0942', 'CLORURO DE ALUMINIO ANHIDRO'),
                                                (943, 'M0943', 'HIDROGENODIFLUORURO DE AMONIO SÓLIDO'),
                                                (944, 'M0944', 'AMILTRICLOROSILANO'),
                                                (945, 'M0945', 'CLORURO DE ANISOILO'),
                                                (946, 'M0946', 'PENTACLORURO DE ANTIMONIO LÍQUIDO'),
                                                (947, 'M0947', 'PENTACLORURO DE ANTIMONIO EN SOLUCIÓ'),
                                                (948, 'M0948', 'PENTAFLUORURO DE ANTIMONIO'),
                                                (949, 'M0949', 'TRICLORURO DE ANTIMONIO'),
                                                (950, 'M0950', 'CLORURO DE BENZOILO'),
                                                (951, 'M0951', 'BROMURO DE BENCILO'),
                                                (952, 'M0952', 'CLORURO DE BENCILO'),
                                                (953, 'M0953', 'CLOROFORMIATO DE BENCILO'),
                                                (954, 'M0954', 'HIDROGENODIFLUORUROS SÓLIDOS, N.E.P.'),
                                                (955, 'M0955', 'TRICLORURO DE BORO'),
                                                (956, 'M0956', 'TRIFLUORURO DE BORO Y ÁCIDO ACÉTICO, COMPLEJO LÍQUIDO DE'),
                                                (957, 'M0957', 'TRIFLUORURO DE BORO Y ÁCIDO PROPIÓNICO, COMPLEJO LÍQUIDO DE'),
                                                (958, 'M0958', 'BROMO o BROMO EN SOLUCIÓ'),
                                                (959, 'M0959', 'PENTAFLUORURO DE BROMO'),
                                                (960, 'M0960', 'TRIFLUORURO DE BROMO'),
                                                (961, 'M0961', 'BUTILTRICLOROSILANO'),
                                                (962, 'M0962', 'HIPOCLORITO DE CALCIO SECO\r\noHIPOCLORITO DE CALCIO EN\r\nMEZCLA SECA, con más del 39 % de cloro activo (8,8 % de oxígeno activo)'),
                                                (963, 'M0963', 'TRIFLUORURO DE CLORO'),
                                                (964, 'M0964', 'ÁCIDO CLOROACÉTICO EN SOLUCIÓ'),
                                                (965, 'M0965', 'ÁCIDO CLOROACÉTICO SÓLIDO'),
                                                (966, 'M0966', 'CLORURO DE CLOROACETILO'),
                                                (967, 'M0967', 'CLOROFENILTRICLOROSILANO'),
                                                (968, 'M0968', 'ÁCIDO CLOROSULFÓNICO (con\r\nosin trióxido de azufre)'),
                                                (969, 'M0969', 'ÁCIDO CRÓMICO EN SOLUCIÓ'),
                                                (970, 'M0970', 'FLUORURO DE CROMO(III) SÓLIDO'),
                                                (971, 'M0971', 'FLUORURO DE CROMO(III) EN SOLUCIÓ'),
                                                (972, 'M0972', 'OXICLORURO DE CROMO(VI) (CLORURO DE CROMILO)'),
                                                (973, 'M0973', 'SÓLIDO CORROSIVO, N.E.P.'),
                                                (974, 'M0974', 'LÍQUIDO CORROSIVO, N.E.P.'),
                                                (975, 'M0975', 'CUPRIETILENDIAMINA EN SOLUCIÓ'),
                                                (976, 'M0976', 'CICLOHEXENILTRICLOROSILA NO'),
                                                (977, 'M0977', 'CICLOHEXIL-TRICLOROSILANO'),
                                                (978, 'M0978', 'ÁCIDO DICLOROACÉTICO'),
                                                (979, 'M0979', 'CLORURO DE DICLOROACETILO'),
                                                (980, 'M0980', 'DICLOROFENILTRICLOROSILA NO'),
                                                (981, 'M0981', 'DIETILDICLOROSILANO'),
                                                (982, 'M0982', 'ÁCIDO DIFLUOROFOSFÓRICO ANHIDRO'),
                                                (983, 'M0983', 'DIFENILDICLOROSILANO'),
                                                (984, 'M0984', 'BROMURO DE DIFENILMETILO'),
                                                (985, 'M0985', 'DODECILTRICLOROSILANO'),
                                                (986, 'M0986', 'CLORURO DE HIERO(III) ANHIDRO'),
                                                (987, 'M0987', 'EXTINTORES DE INCENDIOS, CARGAS PARA, líquidos corrosivos'),
                                                (988, 'M0988', 'ÁCIDO FLUOROBÓRICO'),
                                                (989, 'M0989', 'ÁCIDO FLUOROFOSFÓRICO ANHIDRO'),
                                                (990, 'M0990', 'ÁCIDO FLUOROSULFÓNICO'),
                                                (991, 'M0991', 'ÁCIDO FLUOROSILÍCICO'),
                                                (992, 'M0992', 'ÁCIDO FÓRMICO con más del 85 %, en masa, de ácido'),
                                                (993, 'M0993', 'CLORURO DE FUMARILO'),
                                                (994, 'M0994', 'HEXADECIL-TRICLOROSILANO'),
                                                (995, 'M0995', 'ÁCIDO\r\nHEXAFLUOROFOSFÓRICO'),
                                                (996, 'M0996', 'HEXAMETILENDIAMINA EN SOLUCIÓ'),
                                                (997, 'M0997', 'HEXILTRICLOROSILANO'),
                                                (998, 'M0998', 'ÁCIDO FLUORHÍDRICO Y ÁCIDO SULFÚRICO, MEZCLA DE'),
                                                (999, 'M0999', 'ÁCIDO YODHÍDRICO'),
                                                (1000, 'M1000', 'ÁCIDO BROMHÍDRICO'),
                                                (1001, 'M1001', 'ÁCIDO CLORHÍDRICO'),
                                                (1002, 'M1002', 'ÁCIDO FLUORHÍDRICO con un máximo del 60 % de fluoruro de hidrógeno'),
                                                (1003, 'M1003', 'HIPOCLORITOS EN SOLUCIÓ'),
                                                (1004, 'M1004', 'MONOCLORURO DE YODO, SÓLIDO'),
                                                (1005, 'M1005', 'FOSFATO ÁCIDO DE ISOPROPILO'),
                                                (1006, 'M1006', 'SULFATO DE PLOMO con más del 3 % de ácido libre'),
                                                (1007, 'M1007', 'ÁCIDO SULFONÍTRICO EN MEZCLA (ÁCIDO MIXTO) con más del 50 % de ácido nítrico'),
                                                (1008, 'M1008', 'ÁCIDO SULFONÍTRICO EN MEZCLA (ÁCIDO MIXTO) con un máximo del 50 % de ácido nítrico'),
                                                (1009, 'M1009', 'ÁCIDO CLORHÍDRICO Y ÁCIDO NÍTRICO EN MEZCLA'),
                                                (1010, 'M1010', 'NONILTRICLOROSILANO'),
                                                (1011, 'M1011', 'OCTADECIL-TRICLOROSILANO'),
                                                (1012, 'M1012', 'OCTILTRICLOROSILANO'),
                                                (1013, 'M1013', 'ÁCIDO PERCLÓRICO con un máximo del 50 %, en masa, de ácido'),
                                                (1014, 'M1014', 'ÁCIDO FENOLSULFÓNICO LÍQUIDO'),
                                                (1015, 'M1015', 'FENILTRICLOROSILANO'),
                                                (1016, 'M1016', 'ÁCIDO FOSFÓRICO EN SOLUCIÓ'),
                                                (1017, 'M1017', 'PENTACLORURO DE FÓSFORO'),
                                                (1018, 'M1018', 'PENTÓXIDO DE FÓSFORO'),
                                                (1019, 'M1019', 'TRIBROMURO DE FÓSFORO'),
                                                (1020, 'M1020', 'TRICLORURO DE FÓSFORO'),
                                                (1021, 'M1021', 'OXICLORURO DE FÓSFORO'),
                                                (1022, 'M1022', 'HIDROGENODIFLUORURO DE POTASIO, SÓLIDO'),
                                                (1023, 'M1023', 'FLUORURO DE POTASIO SÓLIDO'),
                                                (1024, 'M1024', 'HIDRÓXIDO DE POTASIO SÓLIDO'),
                                                (1025, 'M1025', 'HIDRÓXIDO DE POTASIO EN SOLUCIÓ'),
                                                (1026, 'M1026', 'CLORURO DE PROPIONILO'),
                                                (1027, 'M1027', 'PROPILTRICLOROSILANO'),
                                                (1028, 'M1028', 'CLORURO DE PIROSULFURILO'),
                                                (1029, 'M1029', 'TETRACLORURO DE SILICIO'),
                                                (1030, 'M1030', 'ALUMINATO DE SODIO EN SOLUCIÓ'),
                                                (1031, 'M1031', 'HIDRÓXIDO DE SODIO SÓLIDO'),
                                                (1032, 'M1032', 'HIDRÓXIDO DE SODIO EN SOLUCIÓ'),
                                                (1033, 'M1033', 'MONÓXIDO DE SODIO'),
                                                (1034, 'M1034', 'ÁCIDO SULFONÍTRICO EN MEZCLA (ÁCIDO MIXTO RESIDUAL) con más del 50 % de ácido nítrico'),
                                                (1035, 'M1035', 'CLORURO DE ESTAÑO(IV) ANHIDRO'),
                                                (1036, 'M1036', 'CLORUROS DE AZUFRE'),
                                                (1037, 'M1037', 'TRIÓXIDO DE AZUFRE ESTABILIZADO'),
                                                (1038, 'M1038', 'ÁCIDO SULFÚRICO con más del 51 % de ácido'),
                                                (1039, 'M1039', 'ÁCIDO SULFÚRICO FUMANTE'),
                                                (1040, 'M1040', 'ÁCIDO SULFÚRICO AGOTADO'),
                                                (1041, 'M1041', 'ÁCIDO SULFUROSO'),
                                                (1042, 'M1042', 'CLORURO DE SULFURILO'),
                                                (1043, 'M1043', 'HIDRÓXIDO DE\r\nTETRAMETILAMONIO EN SOLUCIÓ'),
                                                (1044, 'M1044', 'CLORURO DE TIONILO'),
                                                (1045, 'M1045', 'CLORURO DE TIOFOSFORILO'),
                                                (1046, 'M1046', 'TETRACLORURO DE TITANIO'),
                                                (1047, 'M1047', 'ÁCIDO TRICLOROACÉTICO'),
                                                (1048, 'M1048', 'CLORURO DE CINC EN SOLUCIÓ'),
                                                (1049, 'M1049', 'ACETALDEHÍDO DE AMONIO'),
                                                (1050, 'M1050', 'DINITRO-o-CRESOLATO DE AMONIO, SÓLIDO'),
                                                (1051, 'M1051', 'DIÓXIDO DE CARBONO SÓLIDO (HIELO SECO)'),
                                                (1052, 'M1052', 'TETRACLORURO DE CARBONO'),
                                                (1053, 'M1053', 'SULFURO DE POTASIO HIDRATADO con un mínimo del 30 % de agua de cristalización'),
                                                (1054, 'M1054', 'ÁCIDO PROPIÓNICO con un mínimo del 10 % y un máximo del 90 %, en masa, de ácido'),
                                                (1055, 'M1055', 'SULFURO DE SODIO\r\nHIDRATADO con un mínimo del 30 % de agua'),
                                                (1056, 'M1056', 'MEDICAMENTO LÍQUIDO, TÓXICO, N.E.P.'),
                                                (1057, 'M1057', 'BARIO, ALEACIONES PIROFÓRICAS DE'),
                                                (1058, 'M1058', 'CALCIO PIROFÓRICO o CALCIO, ALEACIONES PIROFÓRICAS DE'),
                                                (1059, 'M1059', 'TRAPOS GRASIENTOS'),
                                                (1060, 'M1060', 'DESECHOS TEXTILES HÚMEDOS'),
                                                (1061, 'M1061', 'HEXAFLUOROPROPILENO (GAS REFRIGERANTE R 1216)'),
                                                (1062, 'M1062', 'TETRAFLUORURO DE SILICIO'),
                                                (1063, 'M1063', 'FLUORURO DE VINILO ESTABILIZADO'),
                                                (1064, 'M1064', 'CROTONATO DE ETILO'),
                                                (1065, 'M1065', 'COMBUSTIBLE PARA MOTORES DE TURBINA DE AVIACIÓ'),
                                                (1066, 'M1066', 'NITRATO DE n-PROPILO'),
                                                (1067, 'M1067', 'RESINA, SOLUCIONES DE, inflamables'),
                                                (1068, 'M1068', 'DECABORANO'),
                                                (1069, 'M1069', 'MAGNESIO o ALEACIONES DE MAGNESIO con más del 50 % de magnesio en recortes, gránulos o tiras'),
                                                (1070, 'M1070', 'BOROHIDRURO DE POTASIO'),
                                                (1071, 'M1071', 'HIDRURO DE TITANIO'),
                                                (1072, 'M1072', 'DIÓXIDO DE PLOMO'),
                                                (1073, 'M1073', 'ÁCIDO PERCLÓRICO con más del 50 % pero no más del 72 %, en masa, de ácido'),
                                                (1074, 'M1074', 'ÓXIDO DE BARIO'),
                                                (1075, 'M1075', 'BENCIDINA'),
                                                (1076, 'M1076', 'CLORURO DE BENCILIDENO'),
                                                (1077, 'M1077', 'BROMOCLOROMETANO'),
                                                (1078, 'M1078', 'CLOROFORMO'),
                                                (1079, 'M1079', 'BROMURO DE CIANÓGENO'),
                                                (1080, 'M1080', 'BROMURO DE ETILO'),
                                                (1081, 'M1081', 'ETILDICLOROARSINA'),
                                                (1082, 'M1082', 'HIDRÓXIDO DE FENILMERCURIO'),
                                                (1083, 'M1083', 'NITRATO DE FENILMERCURIO'),
                                                (1084, 'M1084', 'TETRACLOROETILENO'),
                                                (1085, 'M1085', 'YODURO DE ACETILO'),
                                                (1086, 'M1086', 'FOSFATO ÁCIDO DE DIISOOCTILO'),
                                                (1087, 'M1087', 'DESINFECTANTE LÍQUIDO CORROSIVO, N.E.P.'),
                                                (1088, 'M1088', 'ÁCIDO SELÉNICO'),
                                                (1089, 'M1089', 'LODOS ÁCIDOS'),
                                                (1090, 'M1090', 'CAL SODADA con más del 4 % de hidróxido de sodio'),
                                                (1091, 'M1091', 'CLORITOS EN SOLUCIÓ'),
                                                (1092, 'M1092', 'ÓXIDO DE CALCIO'),
                                                (1093, 'M1093', 'DIBORANO'),
                                                (1094, 'M1094', 'CLORURO DE METILO Y CLORURO DE METILENO, MEZCLA DE'),
                                                (1095, 'M1095', 'NEÓN LÍQUIDO REFRIGERADO'),
                                                (1096, 'M1096', 'PROPIONATOS DE BUTILO'),
                                                (1097, 'M1097', 'CICLOHEXANONA'),
                                                (1098, 'M1098', 'ÉTER 2,2''-DICLORODIETÍLICO'),
                                                (1099, 'M1099', 'ACRILATO DE ETILO ESTABILIZADO'),
                                                (1100, 'M1100', 'ISOPROPILBENCENO'),
                                                (1101, 'M1101', 'ACRILATO DE METILO ESTABILIZADO'),
                                                (1102, 'M1102', 'NONANOS'),
                                                (1103, 'M1103', 'PROPILENIMINA ESTABILIZADA'),
                                                (1104, 'M1104', 'PIRROLIDINA'),
                                                (1105, 'M1105', 'DITIONITO DE CALCIO (HIDROSULFITO CÁLCICO)'),
                                                (1106, 'M1106', 'BROMURO DE\r\nMETILMAGNESIO EN ÉTER ETÍLICO'),
                                                (1107, 'M1107', 'DITIONITO POTÁSICO (HIDROSULFITO POTÁSICO)'),
                                                (1108, 'M1108', 'DITIONITO DE CINC (HIDROSULFITO DE CINC)'),
                                                (1109, 'M1109', 'CIRCONIO, DESECHOS DE'),
                                                (1110, 'M1110', 'CIANURO EN SOLUCIÓN, N.E.P.'),
                                                (1111, 'M1111', 'ÁCIDO BROMOACÉTICO EN SOLUCIÓ'),
                                                (1112, 'M1112', 'OXIBROMURO DE FÓSFORO'),
                                                (1113, 'M1113', 'ÁCIDO TIOGLICÓLICO'),
                                                (1114, 'M1114', 'DIBROMODIFLUORO-METANO'),
                                                (1115, 'M1115', 'NITRATO DE AMONIO con un máximo del 0,2 % de sustancias combustibles, incluida toda sustancia orgánica expresada en equivalente de carbono, con exclusión de cualquier otra sustancia añadida'),
                                                (1116, 'M1116', 'FÓSFOROS DE SEGURIDAD (en estuches, cartones o cajas)'),
                                                (1117, 'M1117', 'FÓSFOROS DE CERA VESTA'),
                                                (1118, 'M1118', 'AEROSOLES'),
                                                (1119, 'M1119', 'ARGON LÍQUIDO REFRIGERADO'),
                                                (1120, 'M1120', 'ÓXIDO DE ETILENO Y DIÓXIDO DE CARBONO, MEZCLA DE con un máximo del 9 % de óxido de etileno'),
                                                (1121, 'M1121', 'GAS COMPRIMIDO TÓXICO, INFLAMABLE, N.E.P.'),
                                                (1122, 'M1122', 'GAS COMPRIMIDO INFLAMABLE, N.E.P.'),
                                                (1123, 'M1123', 'GAS COMPRIMIDO TÓXICO, N.E.P.'),
                                                (1124, 'M1124', 'GAS COMPRIMIDO, N.E.P.'),
                                                (1125, 'M1125', 'DEUTERIO COMPRIMIDO'),
                                                (1126, 'M1126', '1,2-DICLORO-1,1,2,2- TETRAFLUOROETANO (GAS REFRIGERANTE R 114)'),
                                                (1127, 'M1127', '1,1-DIFLUOROETILENO (GAS REFRIGERANTE R 1132a)'),
                                                (1128, 'M1128', 'ETANO LÍQUIDO REFRIGERADO'),
                                                (1129, 'M1129', 'ETILENO'),
                                                (1130, 'M1130', 'HELIO LÍQUIDO REFRIGERADO'),
                                                (1131, 'M1131', 'HIDROCARBUROS GASEOSOS COMPRIMIDOS, EN MEZCLA, N.E.P.'),
                                                (1132, 'M1132', 'HIDROCARBUROS GASEOSOS LICUADOS, EN MEZCLA, N.E.P.'),
                                                (1133, 'M1133', 'HIDRÓGENO LÍQUIDO REFRIGERADO'),
                                                (1134, 'M1134', 'INSECTICIDA GASEOSO TÓXICO, N.E.P.'),
                                                (1135, 'M1135', 'INSECTICIDA GASEOSO, N.E.P.'),
                                                (1136, 'M1136', 'ISOBUTANO'),
                                                (1137, 'M1137', 'CRIPTÓN LÍQUIDO REFRIGERADO'),
                                                (1138, 'M1138', 'METANO COMPRIMIDO o GAS NATURAL COMPRIMIDO con alta proporción de metano'),
                                                (1139, 'M1139', 'METANO LÍQUIDO\r\nREFRIGERADO o GAS NATURAL LÍQUIDO REFRIGERADO con alta proporción de metano'),
                                                (1140, 'M1140', 'CLORODIFLUOROMETANO Y CLOROPENTAFLUOROETANO, MEZCLA DE, de punto de ebullición constante, con alrededor del 49 % de clorodifluorometano (GAS REFRIGERANTE R 502)'),
                                                (1141, 'M1141', 'CLORODIFLUOROBROMOMETA NO (GAS REFRIGERANTE\r\nR 12B1)'),
                                                (1142, 'M1142', 'MONÓXIDO DE NITRÓGENO Y TETRAÓXIDO DE DINITRÓGENO EN MEZCLA (ÓXIDO NÍTRICO Y DIÓXIDO DE NITRÓGENO EN MEZCLA)'),
                                                (1143, 'M1143', 'OCTAFLUORO-CICLOBUTANO (GAS REFRIGERANTE RC 318)'),
                                                (1144, 'M1144', 'NITRÓGENO LÍQUIDO REFRIGERADO'),
                                                (1145, 'M1145', 'PROPANO'),
                                                (1146, 'M1146', 'TETRAFLUOROMETANO (GAS REFRIGERANTE R 14 )'),
                                                (1147, 'M1147', '1-CLORO-2,2,2-\r\nTRIFLUOROETANO (GAS REFRIGERANTE R 133a)'),
                                                (1148, 'M1148', 'TRIFLUOROMETANO\r\n(GAS REFRIGERANTE R 23)'),
                                                (1149, 'M1149', 'ALCOHOLES INFLAMABLES, TÓXICOS, N.E.P.'),
                                                (1150, 'M1150', 'ALCOHOLES, N.E.P.'),
                                                (1151, 'M1151', 'ALDEHÍDOS INFLAMABLES, TÓXICOS, N.E.P.'),
                                                (1152, 'M1152', 'ALDEHÍDOS, N.E.P.'),
                                                (1153, 'M1153', 'BENZALDEHÍDO'),
                                                (1154, 'M1154', 'CLOROPRENO ESTABILIZADO'),
                                                (1155, 'M1155', 'LÍQUIDO INFLAMABLE, TÓXICO, N.E.P.'),
                                                (1156, 'M1156', 'LÍQUIDO INFLAMABLE, N.E.P.'),
                                                (1157, 'M1157', 'HIERRO PENTACARBONILO'),
                                                (1158, 'M1158', 'ALQUITRANES LÍQUIDOS, incluso los aglomerantes para carreteras y los asfaltos rebajados'),
                                                (1159, 'M1159', 'CELULOIDE en bloques, barras, rollos, hojas, tubos, etc., excepto los desechos'),
                                                (1160, 'M1160', 'NAFTENATOS DE COBALTO, EN POLVO'),
                                                (1161, 'M1161', 'CELULOIDE, DESECHOS DE'),
                                                (1162, 'M1162', 'DIAMIDA DE MAGNESIO'),
                                                (1163, 'M1163', 'PLÁSTICOS A BASE DE NITROCELULOSA QUE EXPERIMENTAN CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                                (1164, 'M1164', 'CIRCONIO EN POLVO, SECO'),
                                                (1165, 'M1165', 'CIRCONIO SECO, en láminas, tiras\r\noalambre'),
                                                (1166, 'M1166', 'HIDRURO DE MAGNESIO'),
                                                (1167, 'M1167', 'FOSFURO DE MAGNESIO'),
                                                (1168, 'M1168', 'FOSFURO DE POTASIO'),
                                                (1169, 'M1169', 'FOSFURO DE ESTRONCIO'),
                                                (1170, 'M1170', 'PERÓXIDO DE HIDRÓGENO EN SOLUCIÓN ACUOSA con un mínimo del 20 % pero no más del 60 % de peróxido de hidrógeno (estabilizada según sea necesario)'),
                                                (1171, 'M1171', 'PERÓXIDO DE HIDRÓGENO ESTABILIZADO, o PERÓXIDO DE HIDRÓGENO EN SOLUCIÓN ACUOSA ESTABILIZADA con más del 60 % de peróxido de hidrógeno'),
                                                (1172, 'M1172', 'MUNICIONES TÓXICAS NO EXPLOSIVAS, sin carga dispersora ni carga expulsora, sin cebo'),
                                                (1173, 'M1173', 'MUNICIONES LACRIMÓGENAS NO EXPLOSIVAS, sin carga dispersora ni carga expulsora, sin cebo'),
                                                (1174, 'M1174', 'CLOROANILINAS SÓLIDAS'),
                                                (1175, 'M1175', 'CLOROANILINAS LÍQUIDAS'),
                                                (1176, 'M1176', 'CLOROFENOLES SÓLIDOS'),
                                                (1177, 'M1177', 'CLOROFENOLES LÍQUIDOS'),
                                                (1178, 'M1178', 'ÁCIDO CRESÍLICO'),
                                                (1179, 'M1179', 'EPICLORHIDRINA'),
                                                (1180, 'M1180', 'MERCURIO, COMPUESTO LÍQUIDO DE, N.E.P.'),
                                                (1181, 'M1181', 'MERCURIO, COMPUESTO SÓLIDO DE, N.E.P.'),
                                                (1182, 'M1182', 'FENILMERCURIO, COMPUESTO DE, N.E.P.'),
                                                (1183, 'M1183', 'ARSENITO DE SODIO SÓLIDO'),
                                                (1184, 'M1184', 'BOMBAS FUMÍGENAS NO EXPLOSIVAS que contienen un líquido corrosivo, sin dispositivo de cebado'),
                                                (1185, 'M1185', 'HIDRAZINA ANHIDRA'),
                                                (1186, 'M1186', 'HIDRAZINA EN SOLUCIÓN ACUOSA con más del 37 %, en masa, de hidrazina'),
                                                (1187, 'M1187', 'ÁCIDO NÍTRICO, excepto el ácido nítrico fumante rojo, con más del 70 % ácido nítrico'),
                                                (1188, 'M1188', 'ÁCIDO NÍTRICO, excepto el ácido nítrico fumante rojo, con un mínimo del 65 % pero no más del 70 % de ácido nítrico'),
                                                (1189, 'M1189', 'ÁCIDO NÍTRICO, excepto el ácido nítrico fumante rojo, con menos del 65 % de ácido nítrico'),
                                                (1190, 'M1190', 'ÁCIDO NÍTRICO FUMANTE ROJO'),
                                                (1191, 'M1191', 'MONÓXIDO DE POTASIO'),
                                                (1192, 'M1192', 'HIDRÓGENO Y METANO, MEZCLA COMPRIMIDA DE'),
                                                (1193, 'M1193', '1,1,1-TRIFLUOROETANO (GAS REFRIGERANTE R 143a)'),
                                                (1194, 'M1194', 'XENÓ'),
                                                (1195, 'M1195', 'RECIPIENTES PEQUEÑOS QUE CONTIENEN GAS, (CARTUCHOS DE GAS) sin dispositivo de descarga, irrellenables'),
                                                (1196, 'M1196', 'DINITROTOLUENOS LÍQUIDOS'),
                                                (1197, 'M1197', '2,2-DIMETILPROPANO'),
                                                (1198, 'M1198', 'ISOBUTIRALDEHÍDO (ALDEHÍDO ISOBUTÍRICO)'),
                                                (1199, 'M1199', 'CIMENOS'),
                                                (1200, 'M1200', 'DICLOROPROPENOS'),
                                                (1201, 'M1201', 'DICICLOPENTADIENO'),
                                                (1202, 'M1202', 'DIETILBENCENO'),
                                                (1203, 'M1203', 'DIISOBUTILENO, COMPUESTOS ISOMÉRICOS DEL'),
                                                (1204, 'M1204', '2-DIMETILAMINOETANOL'),
                                                (1205, 'M1205', 'DIPENTENO'),
                                                (1206, 'M1206', 'ALCOHOL METILAMÍLICO'),
                                                (1207, 'M1207', 'MORFOLINA'),
                                                (1208, 'M1208', 'ESTIRENO MONÓMERO ESTABILIZADO'),
                                                (1209, 'M1209', 'TETRAHIDROFURANO'),
                                                (1210, 'M1210', 'TRIPROPILENO'),
                                                (1211, 'M1211', 'VALERILALDEHÍDO'),
                                                (1212, 'M1212', 'NITROCELULOSA EN\r\nSOLUCIÓN INFLAMABLE con un máximo del 12,6 %, en masa, de nitrógeno y un máximo del 55 % de nitrocelulosa'),
                                                (1213, 'M1213', 'ABONOS A BASE DE NITRATO DE AMONIO'),
                                                (1214, 'M1214', 'ABONOS A BASE DE NITRATO DE AMONIO'),
                                                (1215, 'M1215', 'AMONIACO EN SOLUCIÓN acuosa de densidad relativa inferior a 0,880 a 15 °C, con más del 35 % pero no más del 50 % de amoniaco'),
                                                (1216, 'M1216', 'ACRILAMIDA SÓLIDA'),
                                                (1217, 'M1217', 'CLORAL ANHIDRO ESTABILIZADO'),
                                                (1218, 'M1218', 'CRESOLES LÍQUIDOS'),
                                                (1219, 'M1219', 'alfa-NAFTILAMINA'),
                                                (1220, 'M1220', 'DIISOCIANATO DE TOLUENO'),
                                                (1221, 'M1221', 'DIETILENTRIAMINA'),
                                                (1222, 'M1222', 'CLORURO DE HIDRÓGENO LÍQUIDO REFRIGERADO'),
                                                (1223, 'M1223', 'DIÓXIDO DE CARBONO LÍQUIDO REFRIGERADO'),
                                                (1224, 'M1224', 'ARSINA'),
                                                (1225, 'M1225', 'DICLOROSILANO'),
                                                (1226, 'M1226', 'DIFLUORURO DE OXÍGENO, COMPRIMIDO'),
                                                (1227, 'M1227', 'FLUORURO DE SULFURILO'),
                                                (1228, 'M1228', 'GERMANO'),
                                                (1229, 'M1229', 'HEXAFLUOROETANO\r\n(GAS REFRIGERANTE R 116)'),
                                                (1230, 'M1230', 'HEXAFLUORURO DE SELENIO'),
                                                (1231, 'M1231', 'HEXAFLUORURO DE TELURIO'),
                                                (1232, 'M1232', 'HEXAFLUORURO DE TUNGSTENO'),
                                                (1233, 'M1233', 'YODURO DE HIDRÓGENO ANHIDRO'),
                                                (1234, 'M1234', 'PENTAFLUORURO DE FÓSFORO'),
                                                (1235, 'M1235', 'FOSFANO'),
                                                (1236, 'M1236', 'PROPADIENO ESTABILIZADO'),
                                                (1237, 'M1237', 'ÓXIDO NITROSO LÍQUIDO REFRIGERADO'),
                                                (1238, 'M1238', 'SELENIURO DE HIDRÓGENO ANHIDRO'),
                                                (1239, 'M1239', 'SILANO'),
                                                (1240, 'M1240', 'SULFURO DE CARBONILO'),
                                                (1241, 'M1241', 'ADIPONITRILO'),
                                                (1242, 'M1242', 'ISOCIANATOS TÓXICOS, N.E.P. o ISOCIANATOS EN SOLUCIÓN, TÓXICOS, N.E.P.'),
                                                (1243, 'M1243', 'HIPOCLORITO DE CALCIO EN MEZCLA SECA con más del 10 % pero no más del 39 % de cloro activo'),
                                                (1244, 'M1244', 'FORMALDEHÍDO EN SOLUCIÓN con un mínimo del 25 % de formaldehído'),
                                                (1245, 'M1245', 'MANEB o PREPARADOS DE MANEB, con un mínimo del 60 % de maneb'),
                                                (1246, 'M1246', 'POLÍMERO EN BOLITAS DILATABLES que desprenden vapores inflamables'),
                                                (1247, 'M1247', 'AMIANTO, ANFIBOL (amosita, tremolita, actinolita, antofilita, crocidolita)'),
                                                (1248, 'M1248', 'PARAFORMALDEHÍDO'),
                                                (1249, 'M1249', 'ANHÍDRIDO FTÁLICO con más del 0,05 % de anhídrido maleico'),
                                                (1250, 'M1250', 'ANHÍDRIDO MALEICO'),
                                                (1251, 'M1251', 'ANHÍDRIDO MALEICO FUNDIDO'),
                                                (1252, 'M1252', 'HARINA DE PESCADO (DESECHOS DE PESCADO) ESTABILIZADA'),
                                                (1253, 'M1253', 'TORTA OLEAGINOSA con un máximo del 1,5 % de aceite y un máximo del 11 % de humedad'),
                                                (1254, 'M1254', 'ÁCIDO ACRÍLICO ESTABILIZADO'),
                                                (1255, 'M1255', 'ÉTER ALILGLICIDÍLICO (ALIL GLICIDIL ÉTER)'),
                                                (1256, 'M1256', 'ANISOL'),
                                                (1257, 'M1257', 'BENZONITRILO'),
                                                (1258, 'M1258', 'CLORURO DE\r\nBENCENOSULFONILO'),
                                                (1259, 'M1259', 'BENZOTRICLORURO'),
                                                (1260, 'M1260', 'METACRILATO DE n-BUTILO ESTABILIZADO'),
                                                (1261, 'M1261', '2-CLOROETANAL'),
                                                (1262, 'M1262', 'CLOROANISIDINAS'),
                                                (1263, 'M1263', 'CLOROBENZO-TRIFLUORUROS'),
                                                (1264, 'M1264', 'CLORUROS DE\r\nCLOROBENCILO, LÍQUIDOS'),
                                                (1265, 'M1265', 'ISOCIANATO DE 3-CLORO-4- METILFENILO, LÍQUIDO'),
                                                (1266, 'M1266', 'CLORONITROANILINAS'),
                                                (1267, 'M1267', 'CLOROTOLUENOS'),
                                                (1268, 'M1268', 'CLOROTOLUIDINAS SÓLIDAS'),
                                                (1269, 'M1269', 'ÁCIDO CROMOSULFÚRICO'),
                                                (1270, 'M1270', 'CICLOHEPTANO'),
                                                (1271, 'M1271', 'CICLOHEPTENO'),
                                                (1272, 'M1272', 'ACETATO DE CICLOHEXILO'),
                                                (1273, 'M1273', 'CICLOPENTANOL'),
                                                (1274, 'M1274', 'CICLOPENTANONA'),
                                                (1275, 'M1275', 'CICLOPENTENO'),
                                                (1276, 'M1276', 'n-DECANO'),
                                                (1277, 'M1277', 'DI-n-BUTILAMINA'),
                                                (1278, 'M1278', 'ÉTER DICLORODIMETÍLICO SIMÉTRICO'),
                                                (1279, 'M1279', 'ISOCIANATOS DE DICLOROFENILO'),
                                                (1280, 'M1280', 'BICICLO[2.2.1]HEPTA-2,5-DIENO ESTABILIZADO (2,5- NORBORNADIENO ESTABILIZADO)'),
                                                (1281, 'M1281', '1,2-DIMETOXIETANO'),
                                                (1282, 'M1282', 'N,N-DIMETILANILINA'),
                                                (1283, 'M1283', 'FÓSFOROS RESISTENTES AL VIENTO'),
                                                (1284, 'M1284', 'CICLOHEXENO'),
                                                (1285, 'M1285', 'POTASIO'),
                                                (1286, 'M1286', '1,2-PROPILENDIAMINA'),
                                                (1287, 'M1287', 'TRIETILENTETRAMINA'),
                                                (1288, 'M1288', 'TRIPROPILAMINA'),
                                                (1289, 'M1289', 'XILENOLES SÓLIDOS'),
                                                (1290, 'M1290', 'CLORURO DE\r\nDIMETILCARBAMOÍLO'),
                                                (1291, 'M1291', 'DIMETILCICLOHEXANOS'),
                                                (1292, 'M1292', 'N,N-DIMETIL-\r\nCICLOHEXILAMINA'),
                                                (1293, 'M1293', 'N,N-DIMETILFORMAMIDA'),
                                                (1294, 'M1294', 'N,N-DIMETILPROPILAMINA'),
                                                (1295, 'M1295', 'CLORURO DE\r\nDIMETILTIOFOSFORILO'),
                                                (1296, 'M1296', '3,3''-IMINOBISPROPILAMINA'),
                                                (1297, 'M1297', 'ETILAMINA EN SOLUCIÓN ACUOSA con un mínimo del 50 % pero no más del 70 % de etilamina'),
                                                (1298, 'M1298', 'ETILAMILCETONA'),
                                                (1299, 'M1299', 'N-ETILANILINA'),
                                                (1300, 'M1300', '2-ETILANILINA'),
                                                (1301, 'M1301', 'N-ETIL-N-BENCILANILINA'),
                                                (1302, 'M1302', '2-ETILBUTANOL'),
                                                (1303, 'M1303', '2-ETILHEXILAMINA'),
                                                (1304, 'M1304', 'METACRILATO DE ETILO ESTABILIZADO'),
                                                (1305, 'M1305', 'n-HEPTENO'),
                                                (1306, 'M1306', 'HEXACLOROBUTADIENO'),
                                                (1307, 'M1307', 'HEXAMETILENDIAMINA SÓLIDA'),
                                                (1308, 'M1308', 'DIISOCIANATO DE HEXAMETILENO'),
                                                (1309, 'M1309', 'HEXANOLES'),
                                                (1310, 'M1310', 'METACRILATO DE ISOBUTILO ESTABILIZADO'),
                                                (1311, 'M1311', 'ISOBUTIRONITRILO'),
                                                (1312, 'M1312', 'ISOCIANATOBENZOTRI- FLUORUROS'),
                                                (1313, 'M1313', 'PENTAMETILHEPTANO'),
                                                (1314, 'M1314', 'ISOHEPTENOS'),
                                                (1315, 'M1315', 'ISOHEXENOS'),
                                                (1316, 'M1316', 'ISOFORONDIAMINA'),
                                                (1317, 'M1317', 'DIISOCIANATO DE ISOFORONA'),
                                                (1318, 'M1318', 'PLOMO, COMPUESTO DE, SOLUBLE, N.E.P.'),
                                                (1319, 'M1319', '4-METIL-4-METOXIPENTAN-2- ONA'),
                                                (1320, 'M1320', 'N-METILANILINA'),
                                                (1321, 'M1321', 'CLOROACETATO DE METILO'),
                                                (1322, 'M1322', 'METILCICLOHEXANO'),
                                                (1323, 'M1323', 'METILCICLOHEXANONA'),
                                                (1324, 'M1324', 'METILCICLOPENTANO'),
                                                (1325, 'M1325', 'DICLOROACETATO DE METILO'),
                                                (1326, 'M1326', '2-METIL-5-ETILPIRIDINA'),
                                                (1327, 'M1327', '2-METILFURANO'),
                                                (1328, 'M1328', '5-METIL-2-HEXANONA'),
                                                (1329, 'M1329', 'ISOPROPENILBENCENO'),
                                                (1330, 'M1330', 'NAFTALENO FUNDIDO'),
                                                (1331, 'M1331', 'ÁCIDO\r\nNITROBENCENOSULFÓNICO'),
                                                (1332, 'M1332', 'NITROBENZO-TRIFLUORUROS LÍQUIDOS'),
                                                (1333, 'M1333', '3-NITRO-4-CLORO- BENZOTRIFLUORURO'),
                                                (1334, 'M1334', 'ÁCIDO NITROSILSULFÚRICO LÍQUIDO'),
                                                (1335, 'M1335', 'OCTADIENO'),
                                                (1336, 'M1336', 'PENTANO-2,4-DIENO'),
                                                (1337, 'M1337', 'FENETIDINAS'),
                                                (1338, 'M1338', 'FENOL FUNDIDO'),
                                                (1339, 'M1339', 'PICOLINAS'),
                                                (1340, 'M1340', 'DIFENILOS POLICLORADOS LÍQUIDOS'),
                                                (1341, 'M1341', 'CUPROCIANURO DE SODIO SÓLIDO'),
                                                (1342, 'M1342', 'CUPROCIANURO DE SODIO EN SOLUCIÓ'),
                                                (1343, 'M1343', 'HIDROGENOSULFURO DE SODIO con menos del 25 % de agua de cristalización'),
                                                (1344, 'M1344', 'HIDROCARBUROS TERPÉNICOS, N.E.P.'),
                                                (1345, 'M1345', 'TETRAETILENPENTAMINA'),
                                                (1346, 'M1346', 'TRICLOROBENCENOS LÍQUIDOS'),
                                                (1347, 'M1347', 'TRICLOROBUTENO'),
                                                (1348, 'M1348', 'FOSFITO DE TRIETILO'),
                                                (1349, 'M1349', 'TRIISOBUTILENO'),
                                                (1350, 'M1350', '1,3,5-TRIMETILBENCENO'),
                                                (1351, 'M1351', 'TRIMETILCICLO-HEXILAMINA'),
                                                (1352, 'M1352', 'TRIMETILHEXAMETILEN- DIAMINAS'),
                                                (1353, 'M1353', 'DIISOCIANATO DE TRIMETILHEXAMETILENO'),
                                                (1354, 'M1354', 'FOSFITO DE TRIMETILO'),
                                                (1355, 'M1355', 'UNDECANO'),
                                                (1356, 'M1356', 'CLORURO DE CINC ANHIDRO'),
                                                (1357, 'M1357', 'ACETALDOXIMA'),
                                                (1358, 'M1358', 'ACETATO DE ALILO'),
                                                (1359, 'M1359', 'ALILAMINA'),
                                                (1360, 'M1360', 'ALIL ETIL ÉTER'),
                                                (1361, 'M1361', 'FORMIATO DE ALILO'),
                                                (1362, 'M1362', 'FENILMERCAPTANO'),
                                                (1363, 'M1363', 'BENZOTRIFLUORURO'),
                                                (1364, 'M1364', '2-BROMOBUTANO'),
                                                (1365, 'M1365', '2-BROMOETIL ETIL ÉTER'),
                                                (1366, 'M1366', '1-BROMO-3-METILBUTANO'),
                                                (1367, 'M1367', 'BROMOMETILPROPANOS'),
                                                (1368, 'M1368', '2-BROMOPENTANO'),
                                                (1369, 'M1369', 'BROMOPROPANOS'),
                                                (1370, 'M1370', '3-BROMOPROPINO'),
                                                (1371, 'M1371', 'BUTANODIONA'),
                                                (1372, 'M1372', 'BUTILMERCAPTANO'),
                                                (1373, 'M1373', 'ACRILATOS DE BUTILO ESTABILIZADOS'),
                                                (1374, 'M1374', 'BUTIL METIL ÉTER'),
                                                (1375, 'M1375', 'NITRITOS DE BUTILO'),
                                                (1376, 'M1376', 'BUTIL VINIL ÉTER ESTABILIZADO'),
                                                (1377, 'M1377', 'CLORURO DE BUTIRILO'),
                                                (1378, 'M1378', 'CLOROMETIL ÉTIL ÉTER'),
                                                (1379, 'M1379', '2-CLOROPROPANO'),
                                                (1380, 'M1380', 'CICLOHEXILAMINA'),
                                                (1381, 'M1381', 'CICLOOCTATETRAENO'),
                                                (1382, 'M1382', 'DIALILAMINA'),
                                                (1383, 'M1383', 'DIALIL ÉTER'),
                                                (1384, 'M1384', 'DIISOBUTILAMINA'),
                                                (1385, 'M1385', '1,1-DICLOROETANO'),
                                                (1386, 'M1386', 'ETILMERCAPTANO'),
                                                (1387, 'M1387', 'n-PROPILBENCENO'),
                                                (1388, 'M1388', 'CARBONATO DE DIETILO'),
                                                (1389, 'M1389', 'alfa-METILVALERALDEHÍDO'),
                                                (1390, 'M1390', 'alfa-PINENO'),
                                                (1391, 'M1391', '1-HEXENO'),
                                                (1392, 'M1392', 'ISOPENTENOS'),
                                                (1393, 'M1393', '1,2-DI-(DIMETILAMINO) ETANO'),
                                                (1394, 'M1394', 'DIETOXIMETANO'),
                                                (1395, 'M1395', '3,3-DIETOXIPROPENO'),
                                                (1396, 'M1396', 'SULFURO DE DIETILO'),
                                                (1397, 'M1397', '2,3-DIHIDROPIRANO'),
                                                (1398, 'M1398', '1,1-DIMETOXIETANO'),
                                                (1399, 'M1399', '2-\r\nDIMETILAMINOACETONITRILO'),
                                                (1400, 'M1400', '1,3-DIMETILBUTILAMINA'),
                                                (1401, 'M1401', 'DIMETILDIETOXISILANO'),
                                                (1402, 'M1402', 'DISULFURO DE DIMETILO'),
                                                (1403, 'M1403', 'DIMETILHIDRAZINA SIMÉTRICA'),
                                                (1404, 'M1404', 'DIPROPILAMINA'),
                                                (1405, 'M1405', 'ÉTER DI-n-PROPÍLICO'),
                                                (1406, 'M1406', 'ISOBUTIRATO DE ETILO'),
                                                (1407, 'M1407', '1-ETILPIPERIDINA'),
                                                (1408, 'M1408', 'FLUOROBENCENO'),
                                                (1409, 'M1409', 'FLUOROTOLUENOS'),
                                                (1410, 'M1410', 'FURANO'),
                                                (1411, 'M1411', '2-YODOBUTANO'),
                                                (1412, 'M1412', 'YODOMETILPROPANOS'),
                                                (1413, 'M1413', 'YODOPROPANOS'),
                                                (1414, 'M1414', 'FORMIATO DE ISOBUTILO'),
                                                (1415, 'M1415', 'PROPIONATO DE ISOBUTILO'),
                                                (1416, 'M1416', 'CLORURO DE ISOBUTIRILO'),
                                                (1417, 'M1417', 'METACRILALDEHÍDO ESTABILIZADO'),
                                                (1418, 'M1418', '3-METIL-2-BUTANONA'),
                                                (1419, 'M1419', 'METIL-terc-BUTILÉTER'),
                                                (1420, 'M1420', '1-METILPIPERIDINA'),
                                                (1421, 'M1421', 'ISOVALERIANATO DE METILO'),
                                                (1422, 'M1422', 'PIPERIDINA'),
                                                (1423, 'M1423', 'PROPANOTIOLES'),
                                                (1424, 'M1424', 'ACETATO DE ISOPROPENILO'),
                                                (1425, 'M1425', 'PROPIONITRILO'),
                                                (1426, 'M1426', 'BUTIRATO DE ISOPROPILO'),
                                                (1427, 'M1427', 'ISOBUTIRATO DE ISOPROPILO'),
                                                (1428, 'M1428', 'CLOROFORMIATO DE ISOPROPILO'),
                                                (1429, 'M1429', 'PROPIONATO DE ISOPROPILO'),
                                                (1430, 'M1430', '1,2,3,6-TETRAHIDRO-PIRIDINA'),
                                                (1431, 'M1431', 'BUTIRONITRILO'),
                                                (1432, 'M1432', 'TETRAHIDROTIOFENO'),
                                                (1433, 'M1433', 'ORTOTITANATO TETRAPROPÍLICO'),
                                                (1434, 'M1434', 'TIOFENO'),
                                                (1435, 'M1435', 'BORATO DE TRIMETILO'),
                                                (1436, 'M1436', 'FLUORURO DE CARBONILO'),
                                                (1437, 'M1437', 'TETRAFLUORURO DE AZUFRE'),
                                                (1438, 'M1438', 'BROMOTRIFLUORO-ETILENO'),
                                                (1439, 'M1439', 'HEXAFLUOROACETONA'),
                                                (1440, 'M1440', 'TRIÓXIDO DE NITRÓGENO'),
                                                (1441, 'M1441', '2-OCTAFLUOROBUTENO (GAS REFRIGERANTE R 1318)'),
                                                (1442, 'M1442', 'OCTAFLUOROPROPANO (GAS REFRIGERANTE R 218)'),
                                                (1443, 'M1443', 'NITRATO DE AMONIO LÍQUIDO (en solución concentrada caliente)'),
                                                (1444, 'M1444', 'CLORATO DE POTASIO EN SOLUCIÓN ACUOSA'),
                                                (1445, 'M1445', 'CLORATO DE SODIO EN SOLUCIÓN ACUOSA'),
                                                (1446, 'M1446', 'CLORATO DE CALCIO EN SOLUCIÓN ACUOSA'),
                                                (1447, 'M1447', 'ALQUILFENOLES SÓLIDOS, N.E.P. (incluidos los homólogos C2 a C12)'),
                                                (1448, 'M1448', 'ANISIDINAS'),
                                                (1449, 'M1449', 'N,N-DIETILANILINA'),
                                                (1450, 'M1450', 'CLORONITROTOLUENOS LÍQUIDOS'),
                                                (1451, 'M1451', 'DIBENCILDICLOROSILANO'),
                                                (1452, 'M1452', 'ETILFENILDICLOROSILANO'),
                                                (1453, 'M1453', 'ÁCIDO TIOACÉTICO'),
                                                (1454, 'M1454', 'METILFENILDICLORO-SILANO'),
                                                (1455, 'M1455', 'CLORURO DE TRIMETILACETILO'),
                                                (1456, 'M1456', 'HIDROGENODIFLUORURO DE SODIO'),
                                                (1457, 'M1457', 'CLORURO DE ESTAÑO(IV) PENTAHIDRATADO'),
                                                (1458, 'M1458', 'TRICLORURO DE TITANIO PIROFÓRICO o TRICLORURO DE TITANIO EN MEZCLA PIROFÓRICA'),
                                                (1459, 'M1459', 'CLORURO DE\r\nTRICLOROACETILO'),
                                                (1460, 'M1460', 'OXITRICLORURO DE VANADIO'),
                                                (1461, 'M1461', 'TETRACLORURO DE VANADIO'),
                                                (1462, 'M1462', 'NITROCRESOLES SÓLIDOS'),
                                                (1463, 'M1463', 'FÓSFORO BLANCO FUNDIDO'),
                                                (1464, 'M1464', 'AZUFRE FUNDIDO'),
                                                (1465, 'M1465', 'TRIFLUORURO DE NITRÓGENO'),
                                                (1466, 'M1466', 'ETILACETILENO ESTABILIZADO'),
                                                (1467, 'M1467', 'FLUORURO DE ETILO\r\n(GAS REFRIGERANTE R 161)'),
                                                (1468, 'M1468', 'FLUORURO DE METILO (GAS REFRIGERANTE R 41)'),
                                                (1469, 'M1469', 'NITRITO DE METILO'),
                                                (1470, 'M1470', '2-CLOROPROPENO'),
                                                (1471, 'M1471', '2,3-DIMETILBUTANO'),
                                                (1472, 'M1472', 'HEXADIENO'),
                                                (1473, 'M1473', '2-METIL-1-BUTENO'),
                                                (1474, 'M1474', '2-METIL-2-BUTENO'),
                                                (1475, 'M1475', 'METILPENTADIENO'),
                                                (1476, 'M1476', 'HIDRURO DE ALUMINIO'),
                                                (1477, 'M1477', 'NITRATO DE BERILIO'),
                                                (1478, 'M1478', 'ÁCIDO DICLOROISOCIANÚRICO SECO o ÁCIDO\r\nDICLOROISOCIANÚRICO,\r\nSALES DEL'),
                                                (1479, 'M1479', 'SUPERÓXIDO DE POTASIO'),
                                                (1480, 'M1480', 'ÁCIDO\r\nTRICLOROISOCIANÚRICO SECO'),
                                                (1481, 'M1481', 'BROMATO DE CINC'),
                                                (1482, 'M1482', 'FENILACETONITRILO LÍQUIDO'),
                                                (1483, 'M1483', 'TETRÓXIDO DE OSMIO'),
                                                (1484, 'M1484', 'ARSANILATO DE SODIO'),
                                                (1485, 'M1485', 'TIOFOSGENO'),
                                                (1486, 'M1486', 'TRICLORURO DE VANADIO'),
                                                (1487, 'M1487', 'ISOTIOCIANATO DE METILO'),
                                                (1488, 'M1488', 'ISOCIANATOS INFLAMABLES, TÓXICOS, N.E.P. o ISOCIANATOS EN SOLUCIÓN, INFLAMABLES, TÓXICOS, N.E.P.'),
                                                (1489, 'M1489', 'ISOCIANATO DE METILO'),
                                                (1490, 'M1490', 'ISOCIANATO DE ETILO'),
                                                (1491, 'M1491', 'ISOCIANATO DE n-PROPILO'),
                                                (1492, 'M1492', 'ISOCIANATO DE ISOPROPILO'),
                                                (1493, 'M1493', 'ISOCIANATO DE terc-BUTILO'),
                                                (1494, 'M1494', 'ISOCIANATO DE n-BUTILO'),
                                                (1495, 'M1495', 'ISOCIANATO DE ISOBUTILO'),
                                                (1496, 'M1496', 'ISOCIANATO DE FENILO'),
                                                (1497, 'M1497', 'ISOCIANATO DE CICLOHEXILO'),
                                                (1498, 'M1498', 'ÉTER DICLORO-ISOPROPÍLICO'),
                                                (1499, 'M1499', 'ETANOLAMINA o\r\nETANOLAMINA EN SOLUCIÓ'),
                                                (1500, 'M1500', 'HEXAMETILENIMINA'),
                                                (1501, 'M1501', 'PENTAFLUORURO DE YODO'),
                                                (1502, 'M1502', 'ANHÍDRIDO PROPIÓNICO'),
                                                (1503, 'M1503', '1,2,3,6-TETRAHIDRO- BENZALDEHÍDO'),
                                                (1504, 'M1504', 'ÓXIDO DE TRIS(1-AZIRIDINIL) FOSFANO EN SOLUCIÓ'),
                                                (1505, 'M1505', 'CLORURO DE VALERILO'),
                                                (1506, 'M1506', 'TETRACLORURO DE CIRCONIO'),
                                                (1507, 'M1507', 'TETRABROMOETANO'),
                                                (1508, 'M1508', 'FLUORURO DE AMONIO'),
                                                (1509, 'M1509', 'SULFATO ÁCIDO DE AMONIO'),
                                                (1510, 'M1510', 'ÁCIDO CLOROPLATÍNICO SÓLIDO'),
                                                (1511, 'M1511', 'PENTACLORURO DE MOLIBDENO'),
                                                (1512, 'M1512', 'SULFATO ÁCIDO DE POTASIO'),
                                                (1513, 'M1513', 'ÁCIDO 2-CLOROPROPIÓNICO'),
                                                (1514, 'M1514', 'AMINOFENOLES (o-, m-, p-)'),
                                                (1515, 'M1515', 'BROMURO DE BROMOACETILO'),
                                                (1516, 'M1516', 'BROMOBENCENO'),
                                                (1517, 'M1517', 'BROMOFORMO'),
                                                (1518, 'M1518', 'TETRABROMURO DE CARBONO'),
                                                (1519, 'M1519', '1-CLORO-1,1-DIFLUOROETANO (GAS REFRIGERANTE R 142 b)'),
                                                (1520, 'M1520', '1,5,9-CICLODODECATRIENO'),
                                                (1521, 'M1521', 'CICLOOCTADIENOS'),
                                                (1522, 'M1522', 'DICETENO ESTABILIZADO'),
                                                (1523, 'M1523', 'METACRILATO 2-DIMETIL- AMINOETÍLICO, ESTABILIZADO'),
                                                (1524, 'M1524', 'ORTOFORMIATO DE ETILO'),
                                                (1525, 'M1525', 'OXALATO DE ETILO'),
                                                (1526, 'M1526', 'FURFURILAMINA'),
                                                (1527, 'M1527', 'ACRILATO DE ISOBUTILO ESTABILIZADO'),
                                                (1528, 'M1528', 'ISOBUTIRATO DE ISOBUTILO'),
                                                (1529, 'M1529', 'ÁCIDO ISOBUTÍRICO'),
                                                (1530, 'M1530', 'ÁCIDO METACRÍLICO ESTABILIZADO'),
                                                (1531, 'M1531', 'TRICLOROACETATO DE METILO'),
                                                (1532, 'M1532', 'METILCLOROSILANO'),
                                                (1533, 'M1533', '4-METILMORFOLINA (N-METILMORFOLINA)'),
                                                (1534, 'M1534', 'METILTETRAHIDRO-FURANO'),
                                                (1535, 'M1535', 'NITRONAFTALENO'),
                                                (1536, 'M1536', 'TERPINOLENO'),
                                                (1537, 'M1537', 'TRIBUTILAMINA'),
                                                (1538, 'M1538', 'HAFNIO EN POLVO SECO'),
                                                (1539, 'M1539', 'TITANIO EN POLVO SECO'),
                                                (1540, 'M1540', 'SUPERÓXIDO DE SODIO'),
                                                (1541, 'M1541', 'PENTAFLUORURO DE CLORO'),
                                                (1542, 'M1542', 'HIDRATO DE\r\nHEXAFLUORACETONA, LÍQUIDO'),
                                                (1543, 'M1543', 'CLORURO DE METILALILO'),
                                                (1544, 'M1544', 'NITROCELULOSA CON un mínimo del 25 %, en masa, de AGUA'),
                                                (1545, 'M1545', 'NITROCELULOSA CON un mínimo del 25 %, en masa, de ALCOHOL y un máximo del 12,6 %, en masa seca, de nitrógeno'),
                                                (1546, 'M1546', 'NITROCELULOSA EN MEZCLA, con un máximo del 12,6 %, en masa seca, de nitrógeno, CON o SIN PLASTIFICANTE, CON o SIN PIGMENTO'),
                                                (1547, 'M1547', 'EPIBROMHIDRINA'),
                                                (1548, 'M1548', '2-METIL-2-PENTANOL'),
                                                (1549, 'M1549', '3-METIL-1-BUTENO'),
                                                (1550, 'M1550', 'ÁCIDO TRICLOROACÉTICO EN SOLUCIÓ'),
                                                (1551, 'M1551', 'DICICLOHEXILAMINA'),
                                                (1552, 'M1552', 'PENTACLOROFENATO DE SODIO'),
                                                (1553, 'M1553', 'CADMIO, COMPUESTO DE'),
                                                (1554, 'M1554', 'ÁCIDOS ALQUILSULFÚRICOS'),
                                                (1555, 'M1555', 'FENILHIDRAZINA'),
                                                (1556, 'M1556', 'CLORATO DE TALIO'),
                                                (1557, 'M1557', 'FOSFATO DE TRICRESILO con más del 3 % de isómero orto'),
                                                (1558, 'M1558', 'OXIBROMURO DE FÓSFORO, FUNDIDO'),
                                                (1559, 'M1559', 'CLORURO DE FENILACETILO'),
                                                (1560, 'M1560', 'TRIÓXIDO DE FÓSFORO'),
                                                (1561, 'M1561', 'PIPERAZINA'),
                                                (1562, 'M1562', 'BROMURO DE ALUMINIO EN SOLUCIÓ'),
                                                (1563, 'M1563', 'CLORURO DE ALUMINIO EN SOLUCIÓ'),
                                                (1564, 'M1564', 'CLORURO DE HIERRO(III) EN SOLUCIÓ'),
                                                (1565, 'M1565', 'ÁCIDOS ALQUILSULFÓNICOS SÓLIDOS o ÁCIDOS ARILSULFÓNICOS SÓLIDOS, con más del 5 % de ácido sulfúrico libre'),
                                                (1566, 'M1566', 'ÁCIDOS ALQUILSULFÓNICOS LÍQUIDOS o ÁCIDOS ARILSULFÓNICOS LÍQUIDOS, con más del 5 % de ácido sulfúrico libre'),
                                                (1567, 'M1567', 'ÁCIDOS ALQUILSULFÓNICOS SÓLIDOS o ÁCIDOS ARILSULFÓNICOS SÓLIDOS, con un máximo del 5 % de ácido sulfúrico libre'),
                                                (1568, 'M1568', 'ÁCIDOS ALQUILSULFÓNICOS LÍQUIDOS o ÁCIDOS ARILSULFÓNICOS LÍQUIDOS, con un máximo del 5 % de ácido sulfúrico libre'),
                                                (1569, 'M1569', 'BENZOQUINONA'),
                                                (1570, 'M1570', 'PLAGUICIDA, SÓLIDO, TÓXICO, N.E.P.'),
                                                (1571, 'M1571', 'CLOROACETATO DE VINILO'),
                                                (1572, 'M1572', 'AMIANTO, CRISOTILO'),
                                                (1573, 'M1573', 'XENÓN LÍQUIDO REFRIGERADO'),
                                                (1574, 'M1574', 'CLOROTRIFLUOROMETANO Y TRIFLUOROMETANO, MEZCLA AZEOTRÓPICA DE, con aproximadamente el 60 % de clorotrifluorometano\r\n(GAS REFRIGERANTE R 503)'),
                                                (1575, 'M1575', 'CICLOBUTANO'),
                                                (1576, 'M1576', 'DICLORODIFLUORO-METANO Y DIFLUOROETANO, MEZCLA AZEOTRÓPICA DE, con aproximadamente el 74 % de diclorodifluorometano\r\n(GAS REFRIGERANTE R 500)'),
                                                (1577, 'M1577', 'CICLOHEPTATRIENO'),
                                                (1578, 'M1578', 'DIETILETERATO DE TRIFLUORURO DE BORO'),
                                                (1579, 'M1579', 'ISOCIANATO DE METOXIMETILO'),
                                                (1580, 'M1580', 'ORTOSILICATO DE METILO'),
                                                (1581, 'M1581', 'DÍMERO DE LA ACROLEÍNA ESTABILIZADO'),
                                                (1582, 'M1582', 'NITROPROPANOS'),
                                                (1583, 'M1583', 'BORATO DE TRIALILO'),
                                                (1584, 'M1584', 'TRIALILAMINA'),
                                                (1585, 'M1585', 'CLORHIDRINA PROPILÉNICA'),
                                                (1586, 'M1586', 'METIL PROPIL ÉTER'),
                                                (1587, 'M1587', 'ALCOHOL METALÍLICO'),
                                                (1588, 'M1588', 'ETIL PROPIL ÉTER'),
                                                (1589, 'M1589', 'BORATO DE TRIISOPROPILO'),
                                                (1590, 'M1590', 'METILCICLOHEXANOLES inflamables'),
                                                (1591, 'M1591', 'VINILTOLUENOS ESTABILIZADOS'),
                                                (1592, 'M1592', 'BENCILDIMETILAMINA'),
                                                (1593, 'M1593', 'BUTIRATOS DE AMILO'),
                                                (1594, 'M1594', 'ACETILMETILCARBINOL'),
                                                (1595, 'M1595', 'GLICIDALDEHÍDO'),
                                                (1596, 'M1596', 'YESCAS SÓLIDAS con un líquido inflamable'),
                                                (1597, 'M1597', 'SILICIURO DE MAGNESIO'),
                                                (1598, 'M1598', 'ÁCIDO CLÓRICO EN SOLUCIÓN ACUOSA con un máximo del 10 % de ácido clórico'),
                                                (1599, 'M1599', 'NITRITOS INORGÁNICOS, N.E.P.'),
                                                (1600, 'M1600', 'FLUOROACETATO DE POTASIO'),
                                                (1601, 'M1601', 'FLUOROACETATO DE SODIO'),
                                                (1602, 'M1602', 'SELENIATOS o SELENITOS'),
                                                (1603, 'M1603', 'ÁCIDO FLUOROACÉTICO'),
                                                (1604, 'M1604', 'BROMOACETATO DE METILO'),
                                                (1605, 'M1605', 'YODURO DE METILO'),
                                                (1606, 'M1606', 'BROMURO DE FENACILO'),
                                                (1607, 'M1607', 'HEXACLORO-\r\nCICLOPENTADIENO'),
                                                (1608, 'M1608', 'MALONONITRILO'),
                                                (1609, 'M1609', '1,2-DIBROMO-3-BUTANONA'),
                                                (1610, 'M1610', '1,3-DICLOROACETONA'),
                                                (1611, 'M1611', '1,1-DICLORO-1-NITROETANO'),
                                                (1612, 'M1612', '4,4''-DIAMINODIFENIL-METANO'),
                                                (1613, 'M1613', 'YODURO DE BENCILO'),
                                                (1614, 'M1614', 'FLUOROSILICATO DE POTASIO'),
                                                (1615, 'M1615', 'QUINOLEÍNA'),
                                                (1616, 'M1616', 'DISULFURO DE SELENIO'),
                                                (1617, 'M1617', 'CLOROACETATO DE SODIO'),
                                                (1618, 'M1618', 'NITROTOLUIDINAS (MONO)'),
                                                (1619, 'M1619', 'HEXACLOROACETONA'),
                                                (1620, 'M1620', 'DIBROMOMETANO'),
                                                (1621, 'M1621', 'BUTILTOLUENOS'),
                                                (1622, 'M1622', 'CLOROACETONITRILO'),
                                                (1623, 'M1623', 'CLOROCRESOLES EN SOLUCIÓ'),
                                                (1624, 'M1624', 'CLORURO CIANÚRICO'),
                                                (1625, 'M1625', 'AMINOPIRIDINAS (o-, m-, p-)'),
                                                (1626, 'M1626', 'AMONIACO EN SOLUCIÓN acuosa de densidad relativa comprendida entre 0,880 y 0,957 a 15 °C, con más del 10 % pero no más del 35 % de amoniaco'),
                                                (1627, 'M1627', '2-AMINO-4-CLOROFENOL'),
                                                (1628, 'M1628', 'FLUOROSILICATO DE SODIO'),
                                                (1629, 'M1629', 'ESTIBINA'),
                                                (1630, 'M1630', 'HIDRÓXIDO DE RUBIDIO EN SOLUCIÓ'),
                                                (1631, 'M1631', 'HIDRÓXIDO DE RUBIDIO'),
                                                (1632, 'M1632', 'HIDRÓXIDO DE LITIO EN SOLUCIÓ'),
                                                (1633, 'M1633', 'HIDRÓXIDO DE LITIO'),
                                                (1634, 'M1634', 'HIDRÓXIDO DE CESIO EN SOLUCIÓ'),
                                                (1635, 'M1635', 'HIDRÓXIDO DE CESIO'),
                                                (1636, 'M1636', 'SULFURO DE AMONIO EN SOLUCIÓ'),
                                                (1637, 'M1637', '3-DIETILAMINO-PROPILAMINA'),
                                                (1638, 'M1638', 'N,N-DIETILETILENDIAMINA'),
                                                (1639, 'M1639', '2-DIETILAMINOETANOL'),
                                                (1640, 'M1640', 'NITRITO DE\r\nDICICLOHEXILAMONIO'),
                                                (1641, 'M1641', '1-BROMO-3-CLOROPROPANO'),
                                                (1642, 'M1642', 'alfa-MONOCLORHIDRINA DEL GLICEROL'),
                                                (1643, 'M1643', 'N,n-BUTIL IMIDAZOL'),
                                                (1644, 'M1644', 'PENTABROMURO DE FÓSFORO'),
                                                (1645, 'M1645', 'TRIBROMURO DE BORO'),
                                                (1646, 'M1646', 'BISULFITOS EN SOLUCIÓN ACUOSA, N.E.P.'),
                                                (1647, 'M1647', 'ANHÍDRIDOS\r\nTETRAHIDROFTÁLICOS con más del 0,05 % de anhídrido maleico'),
                                                (1648, 'M1648', 'ÁCIDO TRIFLUOROACÉTICO'),
                                                (1649, 'M1649', '1-PENTOL'),
                                                (1650, 'M1650', 'DIMETILDIOXANOS'),
                                                (1651, 'M1651', 'BUTILBENCENOS'),
                                                (1652, 'M1652', 'DIPROPILCETONA'),
                                                (1653, 'M1653', 'ACRIDINA'),
                                                (1654, 'M1654', 'RESINATO DE CINC'),
                                                (1655, 'M1655', 'RESINATO DE ALUMINIO'),
                                                (1656, 'M1656', '1,4-BUTINODIOL'),
                                                (1657, 'M1657', 'ALCANFOR sintético'),
                                                (1658, 'M1658', 'BROMATO DE BARIO'),
                                                (1659, 'M1659', 'NITRATO DE CROMO(III)'),
                                                (1660, 'M1660', 'CLORATO DE COBRE'),
                                                (1661, 'M1661', 'NITRATO DE LITIO'),
                                                (1662, 'M1662', 'CLORATO DE MAGNESIO'),
                                                (1663, 'M1663', 'NITRATO DE MANGANESO'),
                                                (1664, 'M1664', 'NITRATO DE NÍQUEL'),
                                                (1665, 'M1665', 'NITRITO DE NÍQUEL'),
                                                (1666, 'M1666', 'NITRATO DE TALIO'),
                                                (1667, 'M1667', 'NITRATO DE CIRCONIO'),
                                                (1668, 'M1668', 'HEXACLOROBENCENO'),
                                                (1669, 'M1669', 'NITROANISOL LÍQUIDO'),
                                                (1670, 'M1670', 'NITROBROMOBENCENOS LÍQUIDOS'),
                                                (1671, 'M1671', 'AMINAS INFLAMABLES, CORROSIVAS, N.E.P. o POLIAMINAS INFLAMABLES, CORROSIVAS, N.E.P.'),
                                                (1672, 'M1672', 'AMINAS LÍQUIDAS,\r\nCORROSIVAS, INFLAMABLES, N.E.P. o POLIAMINAS LÍQUIDAS, CORROSIVAS, INFLAMABLES, N.E.P.'),
                                                (1673, 'M1673', 'AMINAS LÍQUIDAS, CORROSIVAS, N.E.P. o POLIAMINAS LÍQUIDAS, CORROSIVAS, N.E.P.'),
                                                (1674, 'M1674', 'N-BUTILANILINA'),
                                                (1675, 'M1675', 'ANHIDRIDO BUTÍRICO'),
                                                (1676, 'M1676', 'CLOROFORMIATO DE n-PROPILO'),
                                                (1677, 'M1677', 'HIPOCLORITO DE BARIO con más del 22 % de cloro activo'),
                                                (1678, 'M1678', 'CLOROFORMIATOS TÓXICOS, CORROSIVOS, INFLAMABLES, N.E.P.'),
                                                (1679, 'M1679', 'CLOROFORMIATO DE n-BUTILO'),
                                                (1680, 'M1680', 'CLOROFORMIATO DE CICLOBUTILO'),
                                                (1681, 'M1681', 'CLOROFORMIATO DE CLOROMETILO'),
                                                (1682, 'M1682', 'CLOROFORMIATO DE FENILO'),
                                                (1683, 'M1683', 'CLOROFORMIATO DE terc-BUTILCICLOHEXILO'),
                                                (1684, 'M1684', 'CLOROFORMIATO DE 2-ETILHEXILO'),
                                                (1685, 'M1685', 'TETRAMETILSILANO'),
                                                (1686, 'M1686', '1,3-DICLORO-2-PROPANOL'),
                                                (1687, 'M1687', 'CLORURO DE\r\nDIETILTIOFOSFORILO'),
                                                (1688, 'M1688', '1,2-EPOXI-3-ETOXIPROPANO'),
                                                (1689, 'M1689', 'N-ETILBENCILTOLUIDINAS LÍQUIDAS'),
                                                (1690, 'M1690', 'N-ETILTOLUIDINAS'),
                                                (1691, 'M1691', 'PLAGUICIDA A BASE DE CARBAMATO, SÓLIDO, TÓXICO'),
                                                (1692, 'M1692', 'PLAGUICIDA A BASE DE CARBAMATO, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1693, 'M1693', 'PLAGUICIDA ARSENICAL SÓLIDO, TÓXICO'),
                                                (1694, 'M1694', 'PLAGUICIDA ARSENICAL LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1695, 'M1695', 'PLAGUICIDA ORGANOCLORADO, SÓLIDO, TÓXICO'),
                                                (1696, 'M1696', 'PLAGUICIDA ORGANOCLORADO, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1697, 'M1697', 'PLAGUICIDA A BASE DE TRIAZINA, SÓLIDO, TÓXICO'),
                                                (1698, 'M1698', 'PLAGUICIDA A BASE DE TRIAZINA, LÍQUIDO,\r\nINFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1699, 'M1699', 'PLAGUICIDA A BASE DE TIOCARBAMATO, SÓLIDO, TÓXICO'),
                                                (1700, 'M1700', 'PLAGUICIDA A BASE DE TIOCARBAMATO, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1701, 'M1701', 'PLAGUICIDA A BASE DE COBRE, SÓLIDO, TÓXICO'),
                                                (1702, 'M1702', 'PLAGUICIDA A BASE DE COBRE, LÍQUIDO,\r\nINFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1703, 'M1703', 'PLAGUICIDA A BASE DE MERCURIO, SÓLIDO, TÓXICO'),
                                                (1704, 'M1704', 'PLAGUICIDA A BASE DE MERCURIO, LÍQUIDO,\r\nINFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1705, 'M1705', 'PLAGUICIDA A BASE DE NITROFENOLES SUSTITUIDOS, SÓLIDO, TÓXICO'),
                                                (1706, 'M1706', 'PLAGUICIDA A BASE DE NITROFENOLES SUSTITUIDOS, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1707, 'M1707', 'PLAGUICIDA A BASE DE DIPIRIDILO, SÓLIDO, TÓXICO'),
                                                (1708, 'M1708', 'PLAGUICIDA A BASE DE DIPIRIDILO, LÍQUIDO,\r\nINFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1709, 'M1709', 'PLAGUICIDA A BASE DE ORGANOFÓSFORO, SÓLIDO, TÓXICO'),
                                                (1710, 'M1710', 'PLAGUICIDA A BASE DE ORGANOFÓSFORO, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1711, 'M1711', '4-TIAPENTANAL'),
                                                (1712, 'M1712', 'PLAGUICIDA A BASE DE ORGANOESTAÑO, SÓLIDO, TÓXICO'),
                                                (1713, 'M1713', 'PLAGUICIDA A BASE DE ORGANOESTAÑO, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1714, 'M1714', 'ORGANOESTAÑO, COMPUESTO DE, LÍQUIDO, N.E.P.'),
                                                (1715, 'M1715', 'ÁCIDO ACÉTICO GLACIAL o ÁCIDO ACÉTICO EN SOLUCIÓN con más del 80 %, en masa, de ácido'),
                                                (1716, 'M1716', 'ÁCIDO ACÉTICO EN SOLUCIÓN con un mínimo del 50 % pero no más del 80 %, en masa, de ácido'),
                                                (1717, 'M1717', 'ÁCIDO ACÉTICO EN SOLUCIÓN con más del 10 % y menos del 50 %, en masa, de ácido'),
                                                (1718, 'M1718', 'VIRUTAS, TORNEADURAS o RASPADURAS DE METALES FERROSOS en una forma susceptible de calentamiento espontáneo');
                                                INSERT INTO `portematpeligrosos` (`Id`, `ClaveMatPel`, `Descripcion`) VALUES
                                                (1719, 'M1719', 'ACUMULADORES ELÉCTRICOS DE ELECTROLITO LÍQUIDO ÁCIDO'),
                                                (1720, 'M1720', 'ACUMULADORES ELÉCTRICOS DE ELECTROLITO LÍQUIDO ALCALINO'),
                                                (1721, 'M1721', 'ÁCIDO SULFÚRICO con un máximo del 51 % de ácido o ELECTROLITO ÁCIDO PARA BATERÍAS'),
                                                (1722, 'M1722', 'ELECTROLITO ALCALINO PARA ACUMULADORES'),
                                                (1723, 'M1723', 'DICLOROFENILFOSFANO'),
                                                (1724, 'M1724', 'TIODICLOROFENILFOSFINA'),
                                                (1725, 'M1725', 'ACUMULADORES ELÉCTRICOS NO DERRAMABLES DE ELECTROLITO LÍQUIDO'),
                                                (1726, 'M1726', 'COLORANTE LÍQUIDO CORROSIVO, N.E.P. o MATERIA INTERMEDIA PARA COLORANTES, LÍQUIDA, CORROSIVA, N.E.P.'),
                                                (1727, 'M1727', 'CLORURO DE COBRE'),
                                                (1728, 'M1728', 'GALIO'),
                                                (1729, 'M1729', 'HIDRURO DE LITIO, FUNDIDO, SÓLIDO'),
                                                (1730, 'M1730', 'NITRURO DE LITIO'),
                                                (1731, 'M1731', 'MATERIAL MAGNETIZADO'),
                                                (1732, 'M1732', 'MERCURIO'),
                                                (1733, 'M1733', 'LÍQUIDO TÓXICO, ORGÁNICO, N.E.P.'),
                                                (1734, 'M1734', 'SÓLIDO TÓXICO, ORGÁNICO, N.E.P.'),
                                                (1735, 'M1735', 'ALUMINATO DE SODIO SÓLIDO'),
                                                (1736, 'M1736', 'SÓLIDO QUE REACCIONA CON EL AGUA, N.E.P.'),
                                                (1737, 'M1737', 'SUSTANCIA INFECCIOSA PARA EL SER HUMANO'),
                                                (1738, 'M1738', 'N-AMINOETILPIPERAZINA'),
                                                (1739, 'M1739', 'DIHIDROFLUORURO DE AMONIO EN SOLUCIÓ'),
                                                (1740, 'M1740', 'POLISULFURO DE AMONIO EN SOLUCIÓ'),
                                                (1741, 'M1741', 'FOSFATO ÁCIDO DE AMILO'),
                                                (1742, 'M1742', 'ÁCIDO BUTÍRICO'),
                                                (1743, 'M1743', 'FENOL EN SOLUCIÓ'),
                                                (1744, 'M1744', '2-CLOROPIRIDINA'),
                                                (1745, 'M1745', 'ÁCIDO CROTÓNICO SÓLIDO'),
                                                (1746, 'M1746', 'CLOROTIOFORMIATO DE ETILO'),
                                                (1747, 'M1747', 'ÁCIDO CAPROICO'),
                                                (1748, 'M1748', 'LITIOFERROSILICIO'),
                                                (1749, 'M1749', '1,1,1-TRICLOROETANO'),
                                                (1750, 'M1750', 'ÁCIDO FOSFOROSO'),
                                                (1751, 'M1751', 'HIDRURO DE ALUMINIO Y SODIO'),
                                                (1752, 'M1752', 'BISULFATOS EN SOLUCIÓN ACUOSA'),
                                                (1753, 'M1753', 'BUTIRATO DE VINILO ESTABILIZADO'),
                                                (1754, 'M1754', 'ALDOL'),
                                                (1755, 'M1755', 'BUTIRALDOXIMA'),
                                                (1756, 'M1756', 'DI-n-AMILAMINA'),
                                                (1757, 'M1757', 'NITROETANO'),
                                                (1758, 'M1758', 'CALCIOMANGANESO-SILICIO'),
                                                (1759, 'M1759', 'LÍQUIDO PIROFÓRICO ORGÁNICO, N.E.P.'),
                                                (1760, 'M1760', 'SÓLIDO PIROFÓRICO ORGÁNICO, N.E.P.'),
                                                (1761, 'M1761', '3-CLORO-1-PROPANOL'),
                                                (1762, 'M1762', 'TETRÁMERO DEL PROPILENO'),
                                                (1763, 'M1763', 'TRIFLUORURO DE BORO DIHIDRATADO'),
                                                (1764, 'M1764', 'SULFURO DE DIPICRILO HUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                                (1765, 'M1765', 'FLUOROSILICATO DE MAGNESIO'),
                                                (1766, 'M1766', 'FLUOROSILICATO DE AMONIO'),
                                                (1767, 'M1767', 'FLUOROSILICATO DE CINC'),
                                                (1768, 'M1768', 'FLUOROSILICATOS, N.E.P.'),
                                                (1769, 'M1769', 'MÁQUINAS REFRIGERADORAS que contienen gases no inflamables ni tóxicos o amoniaco en solución (ONU 2672)'),
                                                (1770, 'M1770', 'CIRCONIO SECO, en forma de alambre enrollado, de láminas metálicas acabadas o de tiras (de un grosor inferior a 254 micrones pero no inferior a 18 micrones)'),
                                                (1771, 'M1771', 'METAVANADATO DE AMONIO'),
                                                (1772, 'M1772', 'POLIVANADATO DE AMONIO'),
                                                (1773, 'M1773', 'PENTÓXIDO DE VANADIO no fundido'),
                                                (1774, 'M1774', 'VANADATO DE SODIO Y AMONIO'),
                                                (1775, 'M1775', 'METAVANADATO DE POTASIO'),
                                                (1776, 'M1776', 'SULFATO DE HIDROXILAMINA'),
                                                (1777, 'M1777', 'TRICLORURO DE TITANIO EN MEZCLA'),
                                                (1778, 'M1778', 'BOROHIDRURO DE ALUMINIO'),
                                                (1779, 'M1779', 'BOROHIDRURO DE ALUMINIO EN DISPOSITIVOS'),
                                                (1780, 'M1780', 'ANTIMONIO EN POLVO'),
                                                (1781, 'M1781', 'DIBROMOCLOROPROPANOS'),
                                                (1782, 'M1782', 'DIBUTILAMINOETANOL'),
                                                (1783, 'M1783', 'ALCOHOL FURFURÍLICO'),
                                                (1784, 'M1784', 'HEXACLOROFENO'),
                                                (1785, 'M1785', 'RESORCINOL'),
                                                (1786, 'M1786', 'TITANIO, ESPONJA DE, EN GRÁNULOS o EN POLVO'),
                                                (1787, 'M1787', 'OXICLORURO DE SELENIO'),
                                                (1788, 'M1788', 'HIPOCLORITO DE CALCIO HIDRATADO o HIPOCLORITO DE CALCIO HIDRATADO EN MEZCLA, con un mínimo del 5,5 % pero no más del 16 % de agua'),
                                                (1789, 'M1789', 'CATALIZADOR DE METAL SECO'),
                                                (1790, 'M1790', 'SUSTANCIA INFECCIOSA PARA LOS ANIMALES únicamente'),
                                                (1791, 'M1791', 'CLORURO DE BROMO'),
                                                (1792, 'M1792', 'PLAGUICIDA LÍQUIDO, TÓXICO, N.E.P.'),
                                                (1793, 'M1793', 'PLAGUICIDA LÍQUIDO,\r\nTÓXICO, INFLAMABLE, N.E.P., de punto de inflamación no inferior a 23 °C'),
                                                (1794, 'M1794', 'CLOROFENOLATOS LÍQUIDOS o FENOLATOS LÍQUIDOS'),
                                                (1795, 'M1795', 'CLOROFENOLATOS SÓLIDOS o FENOLATOS SÓLIDOS'),
                                                (1796, 'M1796', 'DINITRATO DE ISOSORBIDA EN MEZCLA con un mínimo del 60 % de lactosa, manosa, almidón o fosfato ácido de calcio'),
                                                (1797, 'M1797', 'MATERIALES RADIACTIVOS, BULTOS EXCEPTUADOS-EMBALAJES/ENVASES VACÍOS'),
                                                (1798, 'M1798', 'MATERIALES RADIACTIVOS, BULTOS EXCEPTUADOS-ARTÍCULOS MANUFACTURADOS DE URANIO NATURAL o URANIO NATURAL'),
                                                (1799, 'M1799', 'MATERIALES RADIACTIVOS, BULTOS EXCEPTUADOS- CANTIDADES LIMITADAS DE MATERIALES'),
                                                (1800, 'M1800', 'MATERIALES RADIACTIVOS, BULTOS EXCEPTUADOS-INSTRUMENTOS o ARTÍCULOS'),
                                                (1801, 'M1801', 'MATERIALES RADIACTIVOS, BAJA ACTIVIDAD ESPECÍFICA (BAE-I), no fisionables o fisionables exceptuados'),
                                                (1802, 'M1802', 'MATERIALES RADIACTIVOS, OBJETOS CONTAMINADOS EN LA SUPERFICIE (OCS-I, OCS-II u OCS-III), no fisionables o fisionables exceptuados'),
                                                (1803, 'M1803', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO A, no en forma especial, no fisionables o fisionables exceptuados'),
                                                (1804, 'M1804', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO B(U), no fisionables o fisionables exceptuados'),
                                                (1805, 'M1805', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO B(M), no fisionables o fisionables exceptuados'),
                                                (1806, 'M1806', 'MATERIALES RADIACTIVOS, TRANSPORTADOS EN VIRTUD\r\nDE ARREGLOS ESPECIALES, no\r\nfisionables o fisionables exceptuados'),
                                                (1807, 'M1807', 'LÍQUIDO CORROSIVO INFLAMABLE, N.E.P.'),
                                                (1808, 'M1808', 'SÓLIDO CORROSIVO INFLAMABLE, N.E.P.'),
                                                (1809, 'M1809', 'LÍQUIDO CORROSIVO, TÓXICO, N.E.P.'),
                                                (1810, 'M1810', 'SÓLIDO CORROSIVO, TÓXICO, N.E.P.'),
                                                (1811, 'M1811', 'LÍQUIDO INFLAMABLE, CORROSIVO, N.E.P.'),
                                                (1812, 'M1812', 'SÓLIDO INFLAMABLE,\r\nCORROSIVO, ORGÁNICO, N.E.P.'),
                                                (1813, 'M1813', 'SÓLIDO INFLAMABLE, TÓXICO, ORGÁNICO, N.E.P.'),
                                                (1814, 'M1814', 'LÍQUIDO TÓXICO, CORROSIVO, ORGÁNICO, N.E.P.'),
                                                (1815, 'M1815', 'SÓLIDO TÓXICO, CORROSIVO, ORGÁNICO, N.E.P.'),
                                                (1816, 'M1816', 'LÍQUIDO TÓXICO, INFLAMABLE, ORGÁNICO, N.E.P.'),
                                                (1817, 'M1817', 'SÓLIDO TÓXICO, INFLAMABLE, ORGÁNICO, N.E.P.'),
                                                (1818, 'M1818', 'SULFATO DE VANADILO'),
                                                (1819, 'M1819', '2-CLOROPROPIONATO DE METILO'),
                                                (1820, 'M1820', '2-CLOROPROPIONATO DE ISOPROPILO'),
                                                (1821, 'M1821', '2-CLOROPROPIONATO DE ETILO'),
                                                (1822, 'M1822', 'ÁCIDO TIOLÁCTICO'),
                                                (1823, 'M1823', 'ALCOHOL alfa-\r\nMETILBENCÍLICO LÍQUIDO'),
                                                (1824, 'M1824', '9-FOSFABICICLONONANOS (FOSFANOS DE CICLOOCTADIENO)'),
                                                (1825, 'M1825', 'FLUORANILINAS'),
                                                (1826, 'M1826', '2-TRIFLUOROMETIL-ANILINA'),
                                                (1827, 'M1827', 'TETRAHIDROFURFURIL-AMINA'),
                                                (1828, 'M1828', 'N-METILBUTILAMINA'),
                                                (1829, 'M1829', '2-AMINO-5-\r\nDIETILAMINOPENTANO'),
                                                (1830, 'M1830', 'CLOROACETATO DE ISOPROPILO'),
                                                (1831, 'M1831', '3-TRIFLUOROMETIL-ANILINA'),
                                                (1832, 'M1832', 'HIDROGENOSULFURO DE SODIO HIDRATADO con un mínimo del 25 % de agua de cristalización'),
                                                (1833, 'M1833', 'GRÁNULOS DE MAGNESIO RECUBIERTOS, en partículas de un mínimo de 149 micrones'),
                                                (1834, 'M1834', '5-terc-BUTIL-2,4,6-TRINITRO-m- XILENO (ALMIZCLE XILENO)'),
                                                (1835, 'M1835', 'DIMETILETERATO DE TRIFLUORURO DE BORO'),
                                                (1836, 'M1836', 'TIOGLICOL'),
                                                (1837, 'M1837', 'ÁCIDO SULFÁMICO'),
                                                (1838, 'M1838', 'MANEB ESTABILIZADO o PREPARADOS DE MANEB ESTABILIZADOS contra el calentamiento espontáneo'),
                                                (1839, 'M1839', 'SEMILLAS DE RICINO o HARINA DE RICINO o TORTA DE RICINO o RICINO EN COPOS'),
                                                (1840, 'M1840', 'MATERIALES RADIACTIVOS, HEXAFLUORURO DE URANIO, FISIONABLE'),
                                                (1841, 'M1841', 'MATERIALES RADIACTIVOS, HEXAFLUORURO DE URANIO, no fisionable o fisionable exceptuado'),
                                                (1842, 'M1842', 'ÓXIDO DE ETILENO Y ÓXIDO DE PROPILENO, MEZCLA DE, con un máximo del 30 % de óxido de etileno'),
                                                (1843, 'M1843', 'PERÓXIDO DE HIDRÓGENO EN SOLUCIÓN ACUOSA con un mínimo del 8 % pero menos del 20 % de peróxido de hidrógeno (estabilizada según sea necesario)'),
                                                (1844, 'M1844', 'CLOROSILANOS,\r\nINFLAMABLES, CORROSIVOS, N.E.P.'),
                                                (1845, 'M1845', 'CLOROSILANOS, CORROSIVOS, INFLAMABLES, N.E.P.'),
                                                (1846, 'M1846', 'CLOROSILANOS, CORROSIVOS, N.E.P.'),
                                                (1847, 'M1847', 'CLOROSILANOS QUE REACCIONAN CON EL AGUA, INFLAMABLES, CORROSIVOS, N.E.P.'),
                                                (1848, 'M1848', 'FOSFITO DIBÁSICO DE PLOMO'),
                                                (1849, 'M1849', 'APARATOS DE SALVAMENTO AUTOINFLABLES'),
                                                (1850, 'M1850', 'PLAGUICIDA A BASE DE CARBAMATO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1851, 'M1851', 'PLAGUICIDA A BASE DE CARBAMATO, LÍQUIDO, TÓXICO'),
                                                (1852, 'M1852', 'PLAGUICIDA ARSENICAL, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1853, 'M1853', 'PLAGUICIDA ARSENICAL, LÍQUIDO, TÓXICO'),
                                                (1854, 'M1854', 'PLAGUICIDA ORGANOCLORADO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1855, 'M1855', 'PLAGUICIDA ORGANOCLORADO, LÍQUIDO, TÓXICO'),
                                                (1856, 'M1856', 'PLAGUICIDA A BASE DE TRIAZINA, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1857, 'M1857', 'PLAGUICIDA A BASE DE TRIAZINA, LÍQUIDO, TÓXICO'),
                                                (1858, 'M1858', 'PLAGUICIDA A BASE DE TIOCARBAMATO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1859, 'M1859', 'PLAGUICIDA A BASE DE TIOCARBAMATO, LÍQUIDO, TÓXICO'),
                                                (1860, 'M1860', 'PLAGUICIDA A BASE DE COBRE, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1861, 'M1861', 'PLAGUICIDA A BASE DE COBRE, LÍQUIDO, TÓXICO'),
                                                (1862, 'M1862', 'PLAGUICIDA A BASE DE MERCURIO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1863, 'M1863', 'PLAGUICIDA A BASE DE MERCURIO, LÍQUIDO, TÓXICO'),
                                                (1864, 'M1864', 'PLAGUICIDA A BASE DE NITROFENOLES SUSTITUIDOS, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1865, 'M1865', 'PLAGUICIDA A BASE DE NITROFENOLES SUSTITUIDOS, LÍQUIDO, TÓXICO'),
                                                (1866, 'M1866', 'PLAGUICIDA A BASE DE DIPIRIDILO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1867, 'M1867', 'PLAGUICIDA A BASE DE DIPIRIDILO, LÍQUIDO, TÓXICO'),
                                                (1868, 'M1868', 'PLAGUICIDA A BASE DE ORGANOFÓSFORO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1869, 'M1869', 'PLAGUICIDA A BASE DE ORGANOFÓSFORO, LÍQUIDO, TÓXICO'),
                                                (1870, 'M1870', 'PLAGUICIDA A BASE DE ORGANOESTAÑO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1871, 'M1871', 'PLAGUICIDA A BASE DE ORGANOESTAÑO, LÍQUIDO, TÓXICO'),
                                                (1872, 'M1872', 'PLAGUICIDA LÍQUIDO, INFLAMABLE, TÓXICO, N.E.P., de punto de inflamación inferior a 23 °C'),
                                                (1873, 'M1873', 'ÓXIDO DE 1,2-BUTILENO ESTABILIZADO'),
                                                (1874, 'M1874', '2-METIL-2-HEPTANOTIOL'),
                                                (1875, 'M1875', 'PLAGUICIDA A BASE DE DERIVADOS DE LA CUMARINA, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                                (1876, 'M1876', 'PLAGUICIDA A BASE DE DERIVADOS DE LA CUMARINA, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                                (1877, 'M1877', 'PLAGUICIDA A BASE DE DERIVADOS DE LA CUMARINA, LÍQUIDO, TÓXICO'),
                                                (1878, 'M1878', 'PLAGUICIDA A BASE DE DERIVADOS DE LA CUMARINA, SÓLIDO, TÓXICO'),
                                                (1879, 'M1879', 'ACUMULADORES ELÉCTRICOS SECOS QUE CONTIENEN HIDRÓXIDO DE POTASIO SÓLIDO'),
                                                (1880, 'M1880', 'PLAGUICIDA A BASE DE FOSFURO DE ALUMINIO'),
                                                (1881, 'M1881', 'CICLOHEXILMERCAPTANO'),
                                                (1882, 'M1882', '2-(2-AMINOETOXI)ETANOL'),
                                                (1883, 'M1883', 'n-HEPTALDEHÍDO'),
                                                (1884, 'M1884', 'CLORURO DE\r\nTRIFLUOROACETILO'),
                                                (1885, 'M1885', 'NITROGLICERINA EN SOLUCIÓN ALCOHÓLICA con más del 1 % pero no más del 5 % de nitroglicerina'),
                                                (1886, 'M1886', 'BEBIDAS ALCOHÓLICAS, con más del 70 % de alcohol en volumen'),
                                                (1887, 'M1887', 'BEBIDAS ALCOHÓLICAS, con más del 24 % pero no más del 70 % de alcohol en volumen'),
                                                (1888, 'M1888', 'PINTURA (incluye pintura, laca, esmalte, colorante, goma laca, barniz, betún, encáustico, apresto líquido y base líquida para lacas) o PRODUCTOS PARA PINTURA (incluye compuestos disolventes o reductores de pintura)'),
                                                (1889, 'M1889', 'ÓXIDO DE ETILENO Y DICLORODIFLUOROMETANO, MEZCLA DE, con un máximo del 12,5 % de óxido de etileno'),
                                                (1890, 'M1890', 'MERCAPTANOS LÍQUIDOS, TÓXICOS, INFLAMABLES, N.E.P.\r\noMEZCLA DE MERCAPTANOS'),
                                                (1891, 'M1891', 'APARATOS DE SALVAMENTO NO AUTOINFLABLES que contienen mercancías peligrosas como material accesorio'),
                                                (1892, 'M1892', 'VINILPIRIDINAS ESTABILIZADAS'),
                                                (1893, 'M1893', 'SUSTANCIA SÓLIDA PELIGROSA PARA EL MEDIO AMBIENTE, N.E.P.'),
                                                (1894, 'M1894', 'CERIO, torneaduras o polvo granulado'),
                                                (1895, 'M1895', 'METACRILONITRILO ESTABILIZADO'),
                                                (1896, 'M1896', 'ISOCIANATOS TÓXICOS, INFLAMABLES, N.E.P. o ISOCIANATOS EN SOLUCIÓN, TÓXICOS, INFLAMABLES, N.E.P.'),
                                                (1897, 'M1897', 'SUSTANCIA LÍQUIDA PELIGROSA PARA EL MEDIO AMBIENTE, N.E.P.'),
                                                (1898, 'M1898', 'FLUORURO DE PERCLORILO'),
                                                (1899, 'M1899', 'SÓLIDO CORROSIVO COMBURENTE, N.E.P.'),
                                                (1900, 'M1900', 'SÓLIDO COMBURENTE, CORROSIVO, N.E.P.'),
                                                (1901, 'M1901', 'SÓLIDO TÓXICO, COMBURENTE, N.E.P.'),
                                                (1902, 'M1902', 'SÓLIDO COMBURENTE, TÓXICO, N.E.P.'),
                                                (1903, 'M1903', 'SÓLIDO ORGÁNICO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                                (1904, 'M1904', 'POLVO METÁLICO INFLAMABLE, N.E.P.'),
                                                (1905, 'M1905', 'BATERÍAS DE METAL LITIO (incluidas las baterías de aleación de litio)'),
                                                (1906, 'M1906', 'BATERÍAS DE METAL LITIO INSTALADAS EN UN EQUIPO O BATERÍAS DE METAL LITIO EMBALADAS CON UN EQUIPO (incluidas las baterías de aleación de litio)'),
                                                                                    (1907, 'M1907', '1-METOXI-2-PROPANOL'),
                                    (1908, 'M1908', 'LÍQUIDO CORROSIVO COMBURENTE N.E.P.'),
                                    (1909, 'M1909', 'LÍQUIDO CORROSIVO QUE REACCIONA CON EL AGUA, N.E.P.'),
                                    (1910, 'M1910', 'SÓLIDO CORROSIVO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                    (1911, 'M1911', 'SÓLIDO CORROSIVO QUE REACCIONA CON EL AGUA, N.E.P.'),
                                    (1912, 'M1912', 'SÓLIDO INFLAMABLE, COMBURENTE, N.E.P.'),
                                    (1913, 'M1913', 'LÍQUIDO COMBURENTE, CORROSIVO, N.E.P.'),
                                    (1914, 'M1914', 'LÍQUIDO COMBURENTE, TÓXICO, N.E.P.'),
                                    (1915, 'M1915', 'SÓLIDO COMBURENTE QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                    (1916, 'M1916', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO B'),
                                    (1917, 'M1917', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO B'),
                                    (1918, 'M1918', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO C'),
                                    (1919, 'M1919', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO C'),
                                    (1920, 'M1920', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO D'),
                                    (1921, 'M1921', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO D'),
                                    (1922, 'M1922', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO E'),
                                    (1923, 'M1923', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO E'),
                                    (1924, 'M1924', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO F'),
                                    (1925, 'M1925', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO F'),
                                    (1926, 'M1926', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO B, CON TEMPERATURA REGULADA'),
                                    (1927, 'M1927', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO B, CON TEMPERATURA REGULADA'),
                                    (1928, 'M1928', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO C, CON TEMPERATURA REGULADA'),
                                    (1929, 'M1929', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO C, CON TEMPERATURA REGULADA'),
                                    (1930, 'M1930', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO D, CON TEMPERATURA REGULADA'),
                                    (1931, 'M1931', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO D, CON TEMPERATURA REGULADA'),
                                    (1932, 'M1932', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO E, CON TEMPERATURA REGULADA'),
                                    (1933, 'M1933', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO E, CON TEMPERATURA REGULADA'),
                                    (1934, 'M1934', 'PERÓXIDO ORGÁNICO LÍQUIDO TIPO F, CON TEMPERATURA REGULADA'),
                                    (1935, 'M1935', 'PERÓXIDO ORGÁNICO SÓLIDO TIPO F, CON TEMPERATURA REGULADA'),
                                    (1936, 'M1936', 'SÓLIDO COMBURENTE QUE REACCIONA CON EL AGUA, N.E.P.'),
                                    (1937, 'M1937', 'LÍQUIDO TÓXICO, COMBURENTE, N.E.P.'),
                                    (1938, 'M1938', 'LÍQUIDO TÓXICO QUE REACCIONA CON EL AGUA, N.E.P.'),
                                    (1939, 'M1939', 'SÓLIDO TÓXICO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                    (1940, 'M1940', 'SÓLIDO TÓXICO QUE REACCIONA CON EL AGUA, N.E.P.'),
                                    (1941, 'M1941', 'SÓLIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, CORROSIVO, ORGÁNICO, N.E.P.'),
                                    (1942, 'M1942', 'SÓLIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, COMBURENTE, N.E.P.'),
                                    (1943, 'M1943', 'SÓLIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, TÓXICO, ORGÁNICO, N.E.P.'),
                                    (1944, 'M1944', 'LÍQUIDO QUE REACCIONA CON EL AGUA, CORROSIVO, N.E.P.'),
                                    (1945, 'M1945', 'LÍQUIDO QUE REACCIONA CON EL AGUA, TÓXICO, N.E.P.'),
                                    (1946, 'M1946', 'SÓLIDO QUE REACCIONA CON EL AGUA, CORROSIVO, N.E.P.'),
                                    (1947, 'M1947', 'SÓLIDO QUE REACCIONA CON EL AGUA, INFLAMABLE, N.E.P.'),
                                    (1948, 'M1948', 'SÓLIDO QUE REACCIONA CON EL AGUA, COMBURENTE, N.E.P.'),
                                    (1949, 'M1949', 'SÓLIDO QUE REACCIONA CON EL AGUA, TÓXICO, N.E.P.'),
                                    (1950, 'M1950', 'SÓLIDO QUE REACCIONA CON EL AGUA Y QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                    (1951, 'M1951', 'TRIFLUOROMETANO LÍQUIDO REFRIGERADO'),
                                    (1952, 'M1952', 'SÓLIDO COMBURENTE, INFLAMABLE, N.E.P.'),
                                    (1953, 'M1953', 'ETILENO, ACETILENO Y PROPILENO, MEZCLA LÍQUIDA REFRIGERADA DE, que contiene un mínimo del 71,5% de etileno, con un máximo del 22,5% de acetileno y un máximo del 6% de propileno'),
                                    (1954, 'M1954', 'LÍQUIDO COMBURENTE, N.E.P.'),
                                    (1955, 'M1955', 'ALCALOIDES LÍQUIDOS, N.E.P.\r\noSALES DE ALCALOIDES LÍQUIDAS, N.E.P.'),
                                    (1956, 'M1956', 'ANTIMONIO, COMPUESTO INORGÁNICO LÍQUIDO DE, N.E.P.'),
                                    (1957, 'M1957', 'DESINFECTANTE LÍQUIDO, TÓXICO, N.E.P.'),
                                    (1958, 'M1958', 'COLORANTE SÓLIDO, TÓXICO, N.E.P. o MATERIA INTERMEDIA PARA COLORANTES, SÓLIDA, TÓXICA, N.E.P.'),
                                    (1959, 'M1959', 'NICOTINA, COMPUESTO LÍQUIDO DE, N.E.P., o PREPARADO LÍQUIDO A BASE DE NICOTINA, N.E.P.'),
                                    (1960, 'M1960', 'ALQUILFENOLES LÍQUIDOS, N.E.P. (incluidos los homólogos C2 a C12)'),
                                    (1961, 'M1961', 'ORGANOESTAÑO, COMPUESTO DE, SÓLIDO, N.E.P.'),
                                    (1962, 'M1962', 'COLORANTE SÓLIDO,\r\nCORROSIVO, N.E.P. o MATERIA INTERMEDIA PARA COLORANTES, SÓLIDA, CORROSIVA, N.E.P.'),
                                    (1963, 'M1963', 'LÍQUIDO QUE REACCIONA CON EL AGUA, N.E.P.'),
                                    (1964, 'M1964', 'PERÓXIDO DE HIDRÓGENO Y ÁCIDO PEROXIACÉTICO, EN MEZCLA, con ácido(s), agua y un máximo del 5 % de ácido peroxiacético, ESTABILIZADA'),
                                    (1965, 'M1965', 'DISPOSITIVOS PEQUEÑOS ACCIONADOS POR HIDROCARBUROS GASEOSOS o RECARGAS DE HIDROCARBUROS GASEOSOS PARA DISPOSITIVOS PEQUEÑOS, con dispositivo de descarga'),
                                    (1966, 'M1966', 'DIFENILOS POLIHALOGENADOS LÍQUIDOS o MONOMETILDIFENILMETANOS HALOGENADOS LÍQUIDOS o TERFENILOS POLIHALOGENADOS LÍQUIDOS'),
                                    (1967, 'M1967', 'DIFENILOS\r\nPOLIHALOGENADOS SÓLIDOS o MONOMETILDIFENILMETANOS HALOGENADOS SÓLIDOS o TERFENILOS POLIHALOGENADOS SÓLIDOS'),
                                    (1968, 'M1968', 'PERFLUORO(ÉTER METILVINÍLICO)'),
                                    (1969, 'M1969', 'PERFLUORO(ÉTER ETILVINÍLICO)'),
                                    (1970, 'M1970', 'PENTACLOROFENOL'),
                                    (1971, 'M1971', 'GAS COMPRIMIDO, COMBURENTE, N.E.P.'),
                                    (1972, 'M1972', 'GAS LICUADO, COMBURENTE, N.E.P.'),
                                    (1973, 'M1973', 'GAS LICUADO, REFRIGERADO, N.E.P.'),
                                    (1974, 'M1974', '1,1,1,2-TETRAFLUOROETANO (GAS REFRIGERANTE R 134a)'),
                                    (1975, 'M1975', 'GAS LICUADO TÓXICO, INFLAMABLE, N.E.P.'),
                                    (1976, 'M1976', 'GAS LICUADO INFLAMABLE, N.E.P.'),
                                    (1977, 'M1977', 'GAS LICUADO TÓXICO N.E.P.'),
                                    (1978, 'M1978', 'GAS LICUADO, N.E.P.'),
                                    (1979, 'M1979', 'OBJETOS CON PRESIÓN INTERIOR, NEUMÁTICOS o HIDRAÚLICOS (que contienen gas no inflamable)'),
                                    (1980, 'M1980', 'DEPÓSITO DE COMBUSTIBLE DE GRUPO MOTOR DE CIRCUITO HIDRAÚLICO DE AERONAVE (que contiene una mezcla de hidrazina anhidra y metilhidrazina) (combustible M86)'),
                                    (1981, 'M1981', 'VEHÍCULO PROPULSADO POR GAS INFLAMABLE o VEHÍCULO PROPULSADO POR LÍQUIDO INFLAMABLE o VEHÍCULO CON PILA DE COMBUSTIBLE PROPULSADO POR GAS INFLAMABLE o VEHÍCULO CON PILA DE COMBUSTIBLE PROPULSADO POR LÍQUIDO INFLAMABLE'),
                                    (1982, 'M1982', 'MUESTRA DE GAS INFLAMABLE, A PRESIÓN NORMAL, N.E.P., que no sea líquido refrigerado'),
                                    (1983, 'M1983', 'MUESTRA DE GAS TÓXICO, INFLAMABLE, A PRESIÓN NORMAL, N.E.P., que no sea líquido refrigerado'),
                                    (1984, 'M1984', 'MUESTRA DE GAS TÓXICO,\r\nA PRESIÓN NORMAL, N.E.P., que no sea líquido refrigerado'),
                                    (1985, 'M1985', 'SUBPRODUCTOS DE LA FUNDICIÓN DEL ALUMINIO o SUBPRODUCTOS DE LA REFUNDICIÓN DEL ALUMINIO'),
                                    (1986, 'M1986', 'VEHÍCULO ACCIONADO POR BATERÍA o APARATO ACCIONADO POR BATERÍA'),
                                    (1987, 'M1987', 'TOXINAS EXTRAÍDAS DE UN MEDIO VIVO, LÍQUIDAS, N.E.P.'),
                                    (1988, 'M1988', 'TOXINAS EXTRAÍDAS DE U'),
                                    (1989, 'M1989', 'DISULFURO DE TITANIO'),
                                    (1990, 'M1990', 'SÓLIDO QUE CONTIENE LÍQUIDO INFLAMABLE, N.E.P.'),
                                    (1991, 'M1991', 'SÓLIDO INFLAMABLE ORGÁNICO, FUNDIDO, N.E.P.'),
                                    (1992, 'M1992', 'SÓLIDO INFLAMABLE INORGÁNICO, N.E.P.'),
                                    (1993, 'M1993', 'SÓLIDO INFLAMABLE, TÓXICO, INORGÁNICO, N.E.P.'),
                                    (1994, 'M1994', 'SÓLIDO INFLAMABLE, CORROSIVO, INORGÁNICO, N.E.P.'),
                                    (1995, 'M1995', 'SALES METÁLICAS DE COMPUESTOS ORGÁNICOS, INFLAMABLES, N.E.P.'),
                                    (1996, 'M1996', 'HIDRUROS METÁLICOS INFLAMABLES, N.E.P.'),
                                    (1997, 'M1997', 'LÍQUIDO ORGÁNICO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                    (1998, 'M1998', 'LÍQUIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, TÓXICO, ORGÁNICO, N.E.P.'),
                                    (1999, 'M1999', 'LÍQUIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, CORROSIVO, ORGÁNICO, N.E.P.'),
                                    (2000, 'M2000', 'LÍQUIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, INORGÁNICO, N.E.P.'),
                                    (2001, 'M2001', 'LÍQUIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, TÓXICO, INORGÁNICO, N.E.P.'),
                                    (2002, 'M2002', 'LÍQUIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, CORROSIVO, INORGÁNICO, N.E.P.'),
                                    (2003, 'M2003', 'POLVO METÁLICO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                    (2004, 'M2004', 'SÓLIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, INORGÁNICO, N.E.P.'),
                                    (2005, 'M2005', 'SÓLIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, TÓXICO, INORGÁNICO, N.E.P.'),
                                    (2006, 'M2006', 'SÓLIDO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, CORROSIVO, INORGÁNICO, N.E.P.'),
                                    (2007, 'M2007', 'LÍQUIDO PIROFÓRICO INORGÁNICO N.E.P.'),
                                    (2008, 'M2008', 'SÓLIDO PIROFÓRICO INORGÁNICO, N.E.P.'),
                                    (2009, 'M2009', 'ALCOHOLATOS DE METALES ALCALINOTÉRREOS, N.E.P.'),
                                    (2010, 'M2010', 'ALCOHOLATOS DE METALES ALCALINOS QUE EXPERIMENTAN CALENTAMIENTO ESPONTÁNEO, CORROSIVOS, N.E.P.'),
                                    (2011, 'M2011', 'SUSTANCIA METÁLICA QUE REACCIONA CON EL AGUA, N.E.P.'),
                                    (2012, 'M2012', 'SUSTANCIA METÁLICA QUE REACCIONA CON EL AGUA Y QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                    (2013, 'M2013', 'CLORATOS INORGÁNICOS EN SOLUCIÓN ACUOSA, N.E.P.'),
                                    (2014, 'M2014', 'PERCLORATOS INORGÁNICOS EN SOLUCIÓN ACUOSA, N.E.P.'),
                                    (2015, 'M2015', 'HIPOCLORITOS INORGÁNICOS, N.E.P.'),
                                    (2016, 'M2016', 'BROMATOS INORGÁNICOS EN SOLUCIÓN ACUOSA, N.E.P.'),
                                    (2017, 'M2017', 'PERMANGANATOS INORGÁNICOS EN SOLUCIÓN ACUOSA, N.E.P.'),
                                    (2018, 'M2018', 'PERSULFATOS INORGÁNICOS, N.E.P.'),
                                    (2019, 'M2019', 'PERSULFATOS INORGÁNICOS EN SOLUCIÓN ACUOSA, N.E.P.'),
                                    (2020, 'M2020', 'NITRATOS INORGÁNICOS EN SOLUCIÓN ACUOSA, N.E.P.'),
                                    (2021, 'M2021', 'NITRITOS INORGÁNICOS EN SOLUCIÓN ACUOSA, N.E.P.'),
                                    (2022, 'M2022', 'PENTAFLUOROETANO (GAS REFRIGERANTE R125)'),
                                    (2023, 'M2023', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO B'),
                                    (2024, 'M2024', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO B'),
                                    (2025, 'M2025', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO C'),
                                    (2026, 'M2026', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO C'),
                                    (2027, 'M2027', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO D'),
                                    (2028, 'M2028', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO D'),
                                    (2029, 'M2029', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO E'),
                                    (2030, 'M2030', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO E'),
                                    (2031, 'M2031', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO F'),
                                    (2032, 'M2032', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO F'),
                                    (2033, 'M2033', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO B, CON TEMPERATURA REGULADA'),
                                    (2034, 'M2034', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO B, CON TEMPERATURA REGULADA'),
                                    (2035, 'M2035', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO C, CON TEMPERATURA REGULADA'),
                                    (2036, 'M2036', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO C, CON TEMPERATURA REGULADA'),
                                    (2037, 'M2037', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO D, CON TEMPERATURA REGULADA'),
                                    (2038, 'M2038', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO D, CON TEMPERATURA REGULADA'),
                                    (2039, 'M2039', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO E, CON TEMPERATURA REGULADA'),
                                    (2040, 'M2040', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO E, CON TEMPERATURA REGULADA'),
                                    (2041, 'M2041', 'LÍQUIDO DE REACCIÓN ESPONTÁNEA, TIPO F, CON TEMPERATURA REGULADA'),
                                    (2042, 'M2042', 'SÓLIDO DE REACCIÓN ESPONTÁNEA, TIPO F, CON TEMPERATURA REGULADA'),
                                    (2043, 'M2043', '2-BROMO-2-NITROPROPANO-1,3-DIOL'),
                                    (2044, 'M2044', 'AZODICARBONAMIDA'),
                                    (2045, 'M2045', 'SÓLIDOS QUE CONTIENEN LÍQUIDO TÓXICO, N.E.P.'),
                                    (2046, 'M2046', 'SÓLIDOS QUE CONTIENEN LÍQUIDO CORROSIVO, N.E.P.'),
                                    (2047, 'M2047', 'MICROORGANISMOS MODIFICADOS GENÉTICAMENTE u ORGANISMOS MODIFICADOS GENÉTICAMENTE'),
                                    (2048, 'M2048', 'CLORURO DE\r\nMETANOSULFONILO'),
                                    (2049, 'M2049', 'PEROXOBORATO DE SODIO ANHIDRO'),
                                    (2050, 'M2050', 'MEDICAMENTO LÍQUIDO, INFLAMABLE, TÓXICO, N.E.P.'),
                                    (2051, 'M2051', 'MEDICAMENTO SÓLIDO, TÓXICO, N.E.P.'),
                                    (2052, 'M2052', 'ÁCIDO CLOROACÉTICO FUNDIDO'),
                                    (2053, 'M2053', 'MONONITRATO-5-DE ISOSORBIDA'),
                                    (2054, 'M2054', 'DIFLUOROMETANO\r\n(GAS REFRIGERANTE R32)'),
                                    (2055, 'M2055', 'TRIOXOSILICATO DE DISODIO'),
                                    (2056, 'M2056', 'TRIBUTILFOSFANO'),
                                    (2057, 'M2057', 'HIPOCLORITO DE terc-BUTILO'),
                                    (2058, 'M2058', 'LÍQUIDO A TEMPERATURA ELEVADA, INFLAMABLE, N.E.P., de punto de inflamación superior a 60 °C, a una temperatura igual o superior al punto de inflamación'),
                                    (2059, 'M2059', 'LÍQUIDO A TEMPERATURA ELEVADA, N.E.P., a una temperatura igual o superior a 100 °C e inferior a su punto de inflamación (incluidos los metales fundidos, las sales fundidas, etc.)'),
                                    (2060, 'M2060', 'SÓLIDO A TEMPERATURA ELEVADA, N.E.P., a una temperatura igual o superior a 240 °C'),
                                    (2061, 'M2061', 'AMINAS SÓLIDAS, CORROSIVAS, N.E.P., o POLIAMINAS SÓLIDAS, CORROSIVAS, N.E.P.'),
                                    (2062, 'M2062', 'SÓLIDO CORROSIVO, ÁCIDO, INORGÁNICO, N.E.P.'),
                                    (2063, 'M2063', 'SÓLIDO CORROSIVO, ÁCIDO, ORGÁNICO, N.E.P.'),
                                    (2064, 'M2064', 'SÓLIDO CORROSIVO, BÁSICO, INORGÁNICO, N.E.P.'),
                                    (2065, 'M2065', 'SÓLIDO CORROSIVO, BÁSICO, ORGÁNICO, N.E.P.'),
                                    (2066, 'M2066', 'LÍQUIDO CORROSIVO, ÁCIDO, INORGÁNICO, N.E.P.'),
                                    (2067, 'M2067', 'LÍQUIDO CORROSIVO, ÁCIDO, ORGÁNICO, N.E.P.'),
                                    (2068, 'M2068', 'LÍQUIDO CORROSIVO, BÁSICO, INORGÁNICO, N.E.P.'),
                                    (2069, 'M2069', 'LÍQUIDO CORROSIVO, BÁSICO, ORGÁNICO, N.E.P.'),
                                    (2070, 'M2070', 'DISPOSITIVOS DE SEGURIDAD de iniciación eléctrica'),
                                    (2071, 'M2071', 'BOLSA DE RESINA POLIESTÉRICA, material básico líquido'),
                                    (2072, 'M2072', 'FILTROS DE MEMBRANAS NITROCELULÓSICAS, con un máximo del 12,6 % de nitrógeno, por masa seca'),
                                    (2073, 'M2073', 'ÉTERES, N.E.P.'),
                                    (2074, 'M2074', 'ÉSTERES, N.E.P.'),
                                    (2075, 'M2075', 'NITRILOS INFLAMABLES, TÓXICOS, N.E.P.'),
                                    (2076, 'M2076', 'ALCOHOLATOS EN SOLUCIÓN, N.E.P. en alcohol'),
                                    (2077, 'M2077', 'NITRILOS TÓXICOS, INFLAMABLES, N.E.P.'),
                                    (2078, 'M2078', 'NITRILOS LÍQUIDOS TÓXICOS, N.E.P.'),
                                    (2079, 'M2079', 'CLOROFORMIATOS TÓXICOS, CORROSIVOS, N.E.P.'),
                                    (2080, 'M2080', 'COMPUESTO ORGANOFOSFORADO LÍQUIDO TÓXICO, N.E.P.'),
                                    (2081, 'M2081', 'COMPUESTO ORGANOFOSFORADO TÓXICO, INFLAMABLE, N.E.P.'),
                                    (2082, 'M2082', 'COMPUESTO ORGANOARSENICAL, LÍQUIDO, N.E.P.'),
                                    (2083, 'M2083', 'CARBONILOS METÁLICOS LÍQUIDOS, N.E.P.'),
                                    (2084, 'M2084', 'COMPUESTO ORGANOMETÁLICO LÍQUIDO TÓXICO, , N.E.P.'),
                                    (2085, 'M2085', 'SELENIO, COMPUESTO DE, SÓLIDO, N.E.P.'),
                                    (2086, 'M2086', 'TELURIO, COMPUESTO DE, N.E.P.'),
                                    (2087, 'M2087', 'VANADIO, COMPUESTO DE, N.E.P.'),
                                    (2088, 'M2088', 'LÍQUIDO INFLAMABLE, TÓXICO, CORROSIVO, N.E.P.'),
                                    (2089, 'M2089', 'LÍQUIDO TÓXICO, INORGÁNICO, N.E.P.'),
                                    (2090, 'M2090', 'SÓLIDO TÓXICO, INORGÁNICO, N.E.P.'),
                                    (2091, 'M2091', 'LÍQUIDO TÓXICO, CORROSIVO, INORGÁNICO, N.E.P.'),
                                    (2092, 'M2092', 'SÓLIDO TÓXICO, CORROSIVO, INORGÁNICO, N.E.P.'),
                                    (2093, 'M2093', 'DESECHOS CLÍNICOS, N.E.P.\r\noDESECHOS (BIO)MÉDICOS, N.E.P. o DESECHOS MÉDICOS REGULADOS, N.E.P.'),
                                    (2094, 'M2094', 'BATERÍAS QUE CONTIENEN SODIO o ELEMENTOS DE BATERÍA QUE CONTIENEN SODIO'),
                                    (2095, 'M2095', 'HIDRAZINA EN SOLUCIÓN ACUOSA con un máximo del 37 %, en masa, de hidrazina'),
                                    (2096, 'M2096', 'CIANURO DE HIDRÓGENO EN SOLUCIÓN ALCOHÓLICA, con un máximo del 45 % de cianuro de hidrógeno'),
                                    (2097, 'M2097', 'HIDROCARBUROS LÍQUIDOS, N.E.P.'),
                                    (2098, 'M2098', 'HEPTAFLUOROPROPANO (GAS REFRIGERANTE R 227)'),
                                    (2099, 'M2099', 'ÓXIDO DE ETILENO Y CLOROTETRAFLUORO-ETANO, MEZCLA DE, con un máximo del 8,8 % de óxido de etileno'),
                                    (2100, 'M2100', 'ÓXIDO DE ETILENO Y PENTAFLUOROETANO, MEZCLA DE, con un máximo del 7,9 % de óxido de etileno'),
                                    (2101, 'M2101', 'ÓXIDO DE ETILENO Y TETRAFLUOROETANO, MEZCLA DE, con un máximo del 5,6 % de óxido de etileno'),
                                    (2102, 'M2102', 'ÓXIDO DE ETILENO Y DIÓXIDO DE CARBONO, MEZCLA DE, con más del 87 % de óxido de etileno'),
                                    (2103, 'M2103', 'LÍQUIDO CORROSIVO QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO, N.E.P.'),
                                    (2104, 'M2104', 'ACRILATO 2-\r\nDIMETILAMINOETÍLICO ESTABILIZADO'),
                                    (2105, 'M2105', 'GAS COMPRIMIDO, TÓXICO, OXIDANTE, N.E.P.'),
                                    (2106, 'M2106', 'GAS COMPRIMIDO, TÓXICO, CORROSIVO, N.E.P.'),
                                    (2107, 'M2107', 'GAS COMPRIMIDO, TÓXICO, INFLAMABLE, CORROSIVO, N.E.P.'),
                                    (2108, 'M2108', 'GAS COMPRIMIDO, TÓXICO, OXIDANTE, CORROSIVO, N.E.P.'),
                                    (2109, 'M2109', 'GAS LICUADO, TÓXICO, OXIDANTE, N.E.P.'),
                                    (2110, 'M2110', 'GAS LICUADO, TÓXICO, CORROSIVO, N.E.P.'),
                                    (2111, 'M2111', 'GAS LICUADO, TÓXICO, INFLAMABLE, CORROSIVO, N.E.P'),
                                    (2112, 'M2112', 'GAS LICUADO, TÓXICO, OXIDANTE, CORROSIVO, N.E.P'),
                                    (2113, 'M2113', 'GAS, LÍQUIDO REFRIGERADO, OXIDANTE, N.E.P.'),
                                    (2114, 'M2114', 'GAS, LÍQUIDO REFRIGERADO, INFLAMABLE, N.E.P.'),
                                    (2115, 'M2115', 'PIGMENTOS ORGÁNICOS QUE EXPERIMENTAN UN CALENTAMIENTO ESPONTÁNEO'),
                                    (2116, 'M2116', 'COMPUESTO PARA EL MOLDEADO DE PLÁSTICOS en forma de pasta, hoja o cuerda estirada que desprende vapores inflamables'),
                                    (2117, 'M2117', 'MUESTRA QUÍMICA TÓXICA'),
                                    (2118, 'M2118', 'EQUIPO QUÍMICO o BOTIQUÍN DE URGENCIA'),
                                    (2119, 'M2119', '2-AMINO-4,6-DINITROFENOL, HUMEDECIDO con una proporción de agua, en masa, con un mínimo del 20 %'),
                                    (2120, 'M2120', 'SOLUCIÓN ACUOSA DE AMONIACO, con una densidad relativa menor de 0,880 a 15 °C, con más del 50 % de amoiíaco'),
                                    (2121, 'M2121', 'NITROGLICERINA EN MEZCLA, DESENSIBILIZADA, SÓLIDA, N.E.P. con más del 2 % pero no más del 10 %, en masa, de nitroglicerina'),
                                    (2122, 'M2122', 'BOROHIDRURO DE SODIO Y SOLUCIÓN DE HIDRÓXIDO DE SODIO con un máximo del 12 % de borohidruro de sodio y un máximo del 40 %, en masa, de hidróxido de sodio'),
                                    (2123, 'M2123', 'MATERIALES RADIACTIVOS, BAJA ACTIVIDAD ESPECÍFICA (BAE-II), no fisionables o fisionables exceptuados'),
                                    (2124, 'M2124', 'MATERIALES RADIACTIVOS, BAJA ACTIVIDAD ESPECÍFICA (BAE-III), no fisionables o fisionables exceptuados'),
                                    (2125, 'M2125', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO C, no fisionables o fisionables exceptuados'),
                                    (2126, 'M2126', 'MATERIALES RADIACTIVOS, BAJA ACTIVIDAD ESPECÍFICA (BAE-II), FISIONABLES'),
                                    (2127, 'M2127', 'MATERIALES RADIACTIVOS, BAJA ACTIVIDAD ESPECÍFICA (BAE-III), FISIONABLES'),
                                    (2128, 'M2128', 'MATERIALES RADIACTIVOS, OBJETOS CONTAMINADOS EN LA SUPERFICIE (OCS-I u OCS-II), FISIONABLES'),
                                    (2129, 'M2129', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO A, FISIONABLES, no en forma especial'),
                                    (2130, 'M2130', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO B(U), FISIONABLES'),
                                    (2131, 'M2131', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO B(M), FISIONABLES'),
                                    (2132, 'M2132', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO C, FISIONABLES'),
                                    (2133, 'M2133', 'MATERIALES RADIACTIVOS, TRANSPORTADOS EN VIRTUD DE ARREGLOS ESPECIALES, FISIONABLES'),
                                    (2134, 'M2134', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO A, EN FORMA ESPECIAL, no fisionables\r\nofisionables exceptuados'),
                                    (2135, 'M2135', 'MATERIALES RADIACTIVOS, BULTOS DEL TIPO A, EN FORMA ESPECIAL, FISIONABLES'),
                                    (2136, 'M2136', 'LÍQUIDO REGULADO PARA AVIACIÓN, N.E.P.'),
                                    (2137, 'M2137', 'SÓLIDO REGULADO PARA AVIACIÓN, N.E.P.'),
                                    (2138, 'M2138', 'MERCAPTANOS, LÍQUIDOS, INFLAMABLES, N.E.P., o MERCAPTANOS EN MEZCLA, LÍQUIDA, INFLAMABLE, N.E.P.'),
                                    (2139, 'M2139', 'GAS REFRIGERANTE R 404A'),
                                    (2140, 'M2140', 'GAS REFRIGERANTE R 407A'),
                                    (2141, 'M2141', 'GAS REFRIGERANTE R 407B'),
                                    (2142, 'M2142', 'GAS REFRIGERANTE R 407C'),
                                    (2143, 'M2143', 'DIÓXIDO DE TIOUREA'),
                                    (2144, 'M2144', 'XANTATOS'),
                                    (2145, 'M2145', 'NITROGLICERINA EM MEZCLA, DESENSIBILIZADA, LÍQUIDA, INFLAMABLE, N.E.P., con un máximo del 30 %, en masa, de nitroglicerina'),
                                    (2146, 'M2146', 'TETRANITRATO DE PENTAERITRITA (TETRANITRATO DE PENTAERITRITOL; PENTRITA; TNPE), EN MEZCLA, DESENSIBILIZADO, SÓLIDO, N.E.P., con más del 10 % pero no más del 20 %, en masa, de TNPE'),
                                    (2147, 'M2147', 'PLAGUICIDA DERIVADO DEL ÁCIDO FENOXIACÉTICO, SÓLIDO, TÓXICO'),
                                    (2148, 'M2148', 'PLAGUICIDA DERIVADO DEL ÁCIDO FENOXIACÉTICO, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                    (2149, 'M2149', 'PLAGUICIDA DERIVADO DEL ÁCIDO FENOXIACÉTICO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación igual o superior a 23 °C'),
                                    (2150, 'M2150', 'PLAGUICIDA DERIVADO DEL ÁCIDO FENOXIACÉTICO, LÍQUIDO, TÓXICO'),
                                    (2151, 'M2151', 'PLAGUICIDA PIRETROIDEO, SÓLIDO, TÓXICO'),
                                    (2152, 'M2152', 'PLAGUICIDA PIRETROIDEO, LÍQUIDO, INFLAMABLE, TÓXICO, de punto de inflamación inferior a 23 °C'),
                                    (2153, 'M2153', 'PLAGUICIDA PIRETROIDEO, LÍQUIDO, TÓXICO, INFLAMABLE, de punto de inflamación no inferior a 23 °C'),
                                    (2154, 'M2154', 'PLAGUICIDA PIRETROIDEO, LÍQUIDO, TÓXICO'),
                                    (2155, 'M2155', 'GAS INSECTICIDA, INFLAMABLE, N.E.P.'),
                                    (2156, 'M2156', 'GAS INSECTICIDA, TÓXICO, INFLAMABLE, N.E.P.'),
                                    (2157, 'M2157', 'GENERADOR QUÍMICO DE OXÍGENO (Producto o material explosivo)'),
                                    (2158, 'M2158', 'NITROGLICERINA EN MEZCLA, DESENSIBILIZADA, LÍQUIDA, N.E.P., con un máximo del 30 %, en masa, de nitroglicerina'),
                                    (2159, 'M2159', 'MÁQUINAS REFRIGERADORAS que contienen gas líquido inflamable, no tóxico'),
                                    (2160, 'M2160', 'UNIDAD DE TRANSPORTE SOMETIDA A FUMIGACIÓ'),
                                    (2161, 'M2161', 'FIBRAS DE ORIGEN VEGETAL, SECAS'),
                                    (2162, 'M2162', 'CLOROSILANOS TÓXICOS CORROSIVOS, N.E.P'),
                                    (2163, 'M2163', 'CLOROSILANOS TÓXICOS CORROSIVOS INFLAMABLES, N.E.P'),
                                    (2164, 'M2164', 'MERCANCÍAS PELIGROSAS EN ARTÍCULOS o MERCANCÍAS PELIGROSAS EN MAQUINARIA\r\noMERCANCÍAS PELIGROSAS EN APARATOS'),
                                    (2165, 'M2165', 'TRINITROFENOL (ÁCIDO PÍCRICO) HUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                    (2166, 'M2166', 'TRINITROCLOROBENCENO (CLORURO DE PICRILO) HUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                    (2167, 'M2167', 'TRINITROTOLUENO (TNT) HUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                    (2168, 'M2168', 'TRINITROBENCENO\r\nHUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                    (2169, 'M2169', 'ÁCIDO TRINITROBENZOICO HUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                    (2170, 'M2170', 'DINITRO-o-CRESOLATO DE SODIO HUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                    (2171, 'M2171', 'NITRATO DE UREA\r\nHUMEDECIDO con un mínimo del 10 %, en masa, de agua'),
                                    (2172, 'M2172', '2-METILBUTANAL'),
                                    (2173, 'M2173', 'SUSTANCIA BIOLÓGICA, CATEGORÍA B'),
                                    (2174, 'M2174', 'ACETILENO EXENTO DE SOLVENTE'),
                                    (2175, 'M2175', 'NITRATO DE AMONIO, EN EMULSIÓN, SUSPENSIÓN o GEL, explosivos intermediarios para voladuras'),
                                    (2176, 'M2176', '4-NITROFENILHIDRAZINA con un mínimo del 30 %, en masa, de agua'),
                                    (2177, 'M2177', 'PERBORATO DE SODIO MONOHIDRATADO'),
                                    (2178, 'M2178', 'CARBONATO DE SODIO PEROXIHIDRATADO'),
                                    (2179, 'M2179', 'EXPLOSIVO DESENSIBILIZADO, LÍQUIDO, N.E.P.'),
                                    (2180, 'M2180', 'EXPLOSIVO DESENSIBILIZADO, SÓLIDO, N.E.P.'),
                                    (2181, 'M2181', 'LÍQUIDO TÓXICO POR INHALACIÓN, N.E.P., con una CL50 inferior o igual a 200 ml/m3 y con concentración saturada de vapor superior o igual a 500 CL50'),
                                    (2182, 'M2182', 'LÍQUIDO TÓXICO POR INHALACIÓN, N.E.P., con una CL50 inferior o igual a 1000 ml/m3 y con concentración saturada de vapor superior o igual a 10 CL50'),
                                    (2183, 'M2183', 'LÍQUIDO TÓXICO POR INHALACIÓN, INFLAMABLE, N.E.P., con una CL50 inferior o igual a 200 ml/m3 y con concentración saturada de vapor superior o igual a 500 CL50'),
                                    (2184, 'M2184', 'LÍQUIDO TÓXICO POR INHALACIÓN, INFLAMABLE, N.E.P., con una CL50 inferior o igual a 1000 ml/m3 y con concentración saturada de vapor superior o igual a 10 CL50'),
                                    (2185, 'M2185', 'LÍQUIDO TÓXICO POR INHALACIÓN, HIDRORREACTIVO, N.E.P., con una CL50 inferior o igual a 200 ml/m3 y con concentración saturada de vapor superior o igual a 500 CL50'),
                                    (2186, 'M2186', 'LÍQUIDO TÓXICO POR INHALACIÓN, HIDRORREACTIVO, N.E.P., con una CL50 inferior o igual a 1000 ml/m3 y con concentración saturada de vapor superior o igual a 10 CL50'),
                                    (2187, 'M2187', 'LÍQUIDO TÓXICO POR INHALACIÓN, COMBURENTE, N.E.P., con una CL50 inferior o igual a 200 ml/m3 y con concentración saturada de vapor superior o igual a 500 CL50'),
                                    (2188, 'M2188', 'LÍQUIDO TÓXICO POR INHALACIÓN, COMBURENTE, N.E.P., con una CL50 inferior o igual a 1000 ml/m3 y con concentración saturada de vapor superior o igual a 10 CL50'),
                                    (2189, 'M2189', 'LÍQUIDO TÓXICO POR INHALACIÓN, CORROSIVO, N.E.P., con una CL50 inferior o igual a 200 ml/m3 y con concentración saturada de vapor superior o igual a 500 CL50'),
                                    (2190, 'M2190', 'LÍQUIDO TÓXICO POR INHALACIÓN, CORROSIVO, N.E.P., con una CL50 inferior o igual a 1000 ml/m3 y con concentración saturada de vapor superior o igual a 10 CL50'),
                                    (2191, 'M2191', 'SUSTANCIA\r\nORGANOMETÁLICA, SÓLIDA, PIROFÓRICA'),
                                    (2192, 'M2192', 'SUSTANCIA\r\nORGANOMETÁLICA, LÍQUIDA, PIROFÓRICA'),
                                    (2193, 'M2193', 'SUSTANCIA ORGANOMETÁLICA, SÓLIDA, PIROFÓRICA, HIDRORREACTIVA'),
                                    (2194, 'M2194', 'SUSTANCIA ORGANOMETÁLICA, LÍQUIDA, PIROFÓRICA, HIDRORREACTIVA'),
                                    (2195, 'M2195', 'SUSTANCIA\r\nORGANOMETÁLICA, SÓLIDA, HIDRORREACTIVA'),
                                    (2196, 'M2196', 'SUSTANCIA ORGANOMETÁLICA, SÓLIDA, HIDRORREACTIVA, INFLAMABLE'),
                                    (2197, 'M2197', 'SUSTANCIA ORGANOMETÁLICA, SÓLIDA, HIDRORREACTIVA, QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO'),
                                    (2198, 'M2198', 'SUSTANCIA\r\nORGANOMETÁLICA, LÍQUIDA, HIDRORREACTIVA'),
                                    (2199, 'M2199', 'SUSTANCIA ORGANOMETÁLICA, LÍQUIDA, HIDRORREACTIVA, INFLAMABLE'),
                                    (2200, 'M2200', 'SUSTANCIA ORGANOMETÁLICA, SÓLIDA, QUE EXPERIMENTA CALENTAMIENTO ESPONTÁNEO'),
                                    (2201, 'M2201', 'METALES ALCALINOS, AMALGAMA SÓLIDA DE'),
                                    (2202, 'M2202', 'METALES ALCALINOTÉRREOS, AMALGAMA SÓLIDA DE'),
                                    (2203, 'M2203', 'POTASIO METÁLICO, ALEACIONES SÓLIDAS DE'),
                                    (2204, 'M2204', 'POTASIO Y SODIO, ALEACIONES SÓLIDAS DE'),
                                    (2205, 'M2205', 'CLORATO DE BARIO EN SOLUCIÓ'),
                                    (2206, 'M2206', 'PERCLORATO DE BARIO EN SOLUCIÓ'),
                                    (2207, 'M2207', 'CLORATO Y CLORURO DE MAGNESIO EN SOLUCIÓN, MEZCLA DE'),
                                    (2208, 'M2208', 'PERCLORATO DE PLOMO EN SOLUCIÓ'),
                                    (2209, 'M2209', 'CLORONITROBENCENOS LÍQUIDOS'),
                                    (2210, 'M2210', 'CLORHIDRATO DE 4-CLORO-o- TOLUIDINA EN SOLUCIÓ'),
                                    (2211, 'M2211', 'beta-NAFTILAMINA EN SOLUCIÓ'),
                                    (2212, 'M2212', 'ÁCIDO FÓRMICO con un mínimo del 10 % pero no más del 85 %, en masa, de ácido'),
                                    (2213, 'M2213', 'ÁCIDO FÓRMICO con un mínimo del 5 % y un máximo del 10 %, en masa, de ácido'),
                                    (2214, 'M2214', 'CIANURO DE POTASIO EN SOLUCIÓ'),
                                    (2215, 'M2215', 'CIANURO DE SODIO EN SOLUCIÓ'),
                                    (2216, 'M2216', 'FLUORURO DE SODIO EN SOLUCIÓ'),
                                    (2217, 'M2217', 'CLOROACETOFENONA LÍQUIDA'),
                                    (2218, 'M2218', 'BROMURO DE XILILO, SÓLIDO'),
                                    (2219, 'M2219', 'TOLUILEN-2,4 -DIAMINA EN SOLUCIÓ'),
                                    (2220, 'M2220', 'TRIFLUORURO DE BORO Y ÁCIDO ACÉTICO, COMPLEJO SÓLIDO DE'),
                                    (2221, 'M2221', 'TRIFLUORURO DE BORO Y ÁCIDO PROPIÓNICO, COMPLEJO SÓLIDO DE'),
                                    (2222, 'M2222', 'HIDRÓGENODIFLUORURO DE POTASIO EN SOLUCIÓ'),
                                    (2223, 'M2223', 'FLUORURO DE POTASIO EN SOLUCIÓ'),
                                    (2224, 'M2224', 'HIDRÓXIDO DE\r\nTETRAMETILAMONIO SÓLIDO'),
                                    (2225, 'M2225', 'DINITRO-o-CRESOLATO DE AMONIO EN SOLUCIÓ'),
                                    (2226, 'M2226', 'ÁCIDO BROMOACÉTICO SÓLIDO'),
                                    (2227, 'M2227', 'ACRILAMIDA EN SOLUCIÓ'),
                                    (2228, 'M2228', 'CLORUROS DE\r\nCLOROBENCILO, SÓLIDOS'),
                                    (2229, 'M2229', 'ISOCIANATO DE 3-CLORO-4- METILFENILO, SÓLIDO'),
                                    (2230, 'M2230', 'CLOROTOLUIDINAS LÍQUIDAS'),
                                    (2231, 'M2231', 'XILENOLES LÍQUIDOS'),
                                    (2232, 'M2232', 'NITROBENZOTRIFLUORUROS SÓLIDOS'),
                                    (2233, 'M2233', 'DIFENILOS POLICLORADOS SÓLIDOS'),
                                    (2234, 'M2234', 'NITROCRESOLES LÍQUIDOS'),
                                    (2235, 'M2235', 'HIDRATO DE\r\nHEXAFLUORACETONA, SÓLIDO'),
                                    (2236, 'M2236', 'CLOROCRESOLES SÓLIDOS'),
                                    (2237, 'M2237', 'ALCOHOL alfa-\r\nMETILBENCÍLICO SÓLIDO'),
                                    (2238, 'M2238', 'NITRILOS SÓLIDOS TÓXICOS, N.E.P.'),
                                    (2239, 'M2239', 'SELENIO, COMPUESTO DE, LÍQUIDO, N.E.P.'),
                                    (2240, 'M2240', 'CLORODINITROBENCENOS SÓLIDOS'),
                                    (2241, 'M2241', 'DICLOROANILINAS SÓLIDAS'),
                                    (2242, 'M2242', 'DINITROBENCENOS SÓLIDOS'),
                                    (2243, 'M2243', 'CLORHIDRATO DE NICOTINA SÓLIDO'),
                                    (2244, 'M2244', 'SULFATO DE NICOTINA SÓLIDO'),
                                    (2245, 'M2245', 'NITROTOLUENOS SÓLIDOS'),
                                    (2246, 'M2246', 'NITROXILENOS SÓLIDOS'),
                                    (2247, 'M2247', 'GASES LACRIMÓGENOS, SUSTANCIA SÓLIDA PARA LA FABRICACIÓN DE, N.E.P.'),
                                    (2248, 'M2248', 'CIANUROS DE BROMOBENCILO SÓLIDOS'),
                                    (2249, 'M2249', 'DIFENILCLOROARSINA SÓLIDA'),
                                    (2250, 'M2250', 'TOLUIDINAS SÓLIDAS'),
                                    (2251, 'M2251', 'XILIDINAS SÓLIDAS'),
                                    (2252, 'M2252', 'ÁCIDO FOSFÓRICO SÓLIDO'),
                                    (2253, 'M2253', 'DINITROTOLUENOS SÓLIDOS'),
                                    (2254, 'M2254', 'CRESOLES SÓLIDOS'),
                                    (2255, 'M2255', 'ÁCIDO NITROSILSULFÚRICO SÓLIDO'),
                                    (2256, 'M2256', 'CLORONITROTOLUENOS SÓLIDOS'),
                                    (2257, 'M2257', 'NITROANISOL SÓLIDO'),
                                    (2258, 'M2258', 'NITROBROMOBENCENOS SÓLIDOS'),
                                    (2259, 'M2259', 'N-ETILBENCILTOLUIDINAS SÓLIDAS'),
                                    (2260, 'M2260', 'TOXINAS EXTRAÍDAS DE UN MEDIO VIVO, SÓLIDAS, N.E.P.'),
                                    (2261, 'M2261', 'ÁCIDO PROPIÓNICO con un mínimo del 90 %, en masa, de ácido'),
                                    (2262, 'M2262', 'COMPUESTO\r\nORGANOFOSFORADO SÓLIDO TÓXICO, N.E.P.'),
                                    (2263, 'M2263', 'COMPUESTO\r\nORGANOARSENICAL, SÓLIDO, N.E.P.'),
                                    (2264, 'M2264', 'CARBONILOS METÁLICOS, SÓLIDOS, N.E.P.'),
                                    (2265, 'M2265', 'COMPUESTO\r\nORGANOMETÁLICO SÓLIDO TÓXICO, N.E.P.'),
                                    (2266, 'M2266', 'COMPUESTO\r\nORGANOMETÁLICO SÓLIDO TÓXICO, SÓLIDO, N.E.P.'),
                                    (2267, 'M2267', 'HIDRÓGENO EN UN DISPOSITIVO DE ALMACENAMIENTO CON HIDRURO METÁLICO o HIDRÓGENO EN UN DISPOSITIVO DE ALMACENAMIENTO CON HIDRURO METÁLICO INSTALADO EN UN EQUIPO o HIDRÓGENO EN UN DISPOSITIVO DE ALMACENAMIENTO CON HIDRURO METÁLICO EMBALADO CON UN EQUIPO'),
                                    (2268, 'M2268', 'PINTURAS INFLAMABLES, CORROSIVAS (incluidos pinturas, lacas, esmaltes, colores, goma laca, barnices, bruñidores, encáusticos, bases líquidas para lacas) o MATERIAL INFLAMABLE, CORROSIVO RELACIONADO CON PINTURAS (incluidos disolventes y diluyentes para pin'),
                                    (2269, 'M2269', 'PINTURAS CORROSIVAS, INFLAMABLES (incluidos pinturas, lacas, esmaltes, colores, goma laca, barnices, bruñidores, encáusticos, bases líquidas para lacas) o MATERIAL CORROSIVO, INFLAMABLE RELACIONADO CON PINTURAS (incluidos disolventes y diluyentes para pin'),
                                    (2270, 'M2270', 'HIDROGENODIFLUORUROS EN SOLUCIÓN, N.E.P.'),
                                    (2271, 'M2271', 'ÁCIDO CROTÓNICO LÍQUIDO'),
                                    (2272, 'M2272', 'CARTUCHOS PARA PILAS DE COMBUSTIBLE o CARTUCHOS PARA PILAS DE COMBUSTIBLE INSTALADOS EN UN EQUIPO o CARTUCHOS PARA PILAS DE COMBUSTIBLE EMBALADOS CON UN EQUIPO, que contienen líquidos inflamables'),
                                    (2273, 'M2273', '1-HIDROXIBENZOTRIAZOL MONOHIDRATADO'),
                                    (2274, 'M2274', 'ETANOL Y GASOLINA, MEZCLA DE, o ETANOL Y COMBUSTIBLE PARA MOTORES, MEZCLA DE, con más del 10 % de etanol'),
                                    (2275, 'M2275', 'CARTUCHOS PARA PILAS DE COMBUSTIBLE o CARTUCHOS PARA PILAS DE COMBUSTIBLE INSTALADOS EN UN EQUIPO o CARTUCHOS PARA PILAS DE COMBUSTIBLE CONTENIDOS EN UN EQUIPO, que contienen sustancias que reaccionan con el agua'),
                                    (2276, 'M2276', 'CARTUCHOS PARA PILAS DE COMBUSTIBLE o CARTUCHOS PARA PILAS DE COMBUSTIBLE INSTALADOS EN UN EQUIPO o CARTUCHOS PARA PILAS DE COMBUSTIBLE EMBALADOS CON UN EQUIPO, que contienen gas licuado inflamable'),
                                    (2277, 'M2277', 'CARTUCHOS PARA PILAS DE COMBUSTIBLE o CARTUCHOS PARA PILAS DE COMBUSTIBLE INSTALADOS EN UN EQUIPO o CARTUCHOS PARA PILAS DE COMBUSTIBLE EMBALADOS CON UN EQUIPO, que contienen gas licuado inflamable'),
                                    (2278, 'M2278', 'CARTUCHOS PARA PILAS DE COMBUSTIBLE o CARTUCHOS PARA PILAS DE COMBUSTIBLE INSTALADOS EN UN EQUIPO o CARTUCHOS PARA PILAS DE COMBUSTIBLE CONTENIDOS EN UN EQUIPO, que contienen hidrógeno en un hidruro metálico'),
                                    (2279, 'M2279', 'BATERÍAS DE IÓN LITIO (incluidas las baterías poliméricas de ión litio)'),
                                    (2280, 'M2280', 'BATERÍAS DE IÓN LITIO INSTALADAS EN UN EQUIPO o BATERÍAS DE IÓN LITIO EMBALADAS CON UN EQUIPO (incluidas las baterías poliméricas de ión litio)'),
                                    (2281, 'M2281', 'METALES ALCALINOS, DISPERSIÓN DE, INFLAMABLE\r\noMETALES ALCALINOTÉRREOS,\r\nDISPERSIÓN DE, INFLAMABLE'),
                                    (2282, 'M2282', 'MEZCLA ANTIDETONANTE PARA COMBUSTIBLES DE MOTORES, INFLAMABLE'),
                                    (2283, 'M2283', 'HIDRAZINA EN SOLUCIÓN ACUOSA, INFLAMABLE, con más del 37 %, en masa, de hidrazina'),
                                    (2284, 'M2284', 'HIPOCLORITO DE CALCIO SECO, CORROSIVO o HIPOCLORITO DE CALCIO EN MEZCLA SECA, CORROSIVO, con más del 39 % de cloro activo (8,8 % de oxígeno activo)'),
                                    (2285, 'M2285', 'HIPOCLORITO DE CALCIO EN MEZCLA SECA, CORROSIVO, con más del 10 % pero no más del 39 % de cloro activo'),
                                    (2286, 'M2286', 'HIPOCLORITO DE CALCIO, HIDRATADO, CORROSIVO o HIPOCLORITO DE CALCIO HIDRATADO EN MEZCLA, CORROSIVO, con un mínimo del 5,5 % pero no más del 16 % de agua'),
                                    (2287, 'M2287', 'LÍQUIDO TÓXICO POR INHALACIÓN, INFLAMABLE, CORROSIVO, N.E.P., con una CL50 inferior o igual a 200 ml /m3 y con concentración saturada de vapor superior o igual a 500 CL50'),
                                    (2288, 'M2288', 'LÍQUIDO TÓXICO POR INHALACIÓN, INFLAMABLE, CORROSIVO, N.E.P., con una CL50 inferior o igual a 1000 ml/m3 y con concentración saturada de vapor superior o igual a 10 CL50'),
                                    (2289, 'M2289', 'LÍQUIDO TÓXICO POR INHALACIÓN, HIDRORREACTIVO, INFLAMABLE, N.E.P., con una CL50 inferior o igual a 200 ml/m3 y con concentración saturada de vapor superior o igual a 500 CL50'),
                                    (2290, 'M2290', 'LÍQUIDO TÓXICO POR INHALACIÓN, HIDRORREACTIVO, INFLAMABLE, N.E.P., con una CL50 inferior o igual a 1000 ml/m3 y con concentración saturada de vapor superior o igual a 10 CL50'),
                                    (2291, 'M2291', 'PETRÓLEO BRUTO ÁCIDO, INFLAMABLE, TÓXICO'),
                                    (2292, 'M2292', 'YODO'),
                                    (2293, 'M2293', 'BATERÍAS DE NÍQUEL- HIDRURO METÁLICO'),
                                    (2294, 'M2294', 'HARINA DE KRILL'),
                                    (2295, 'M2295', 'MONOCLORURO DE YODO LÍQUIDO'),
                                    (2296, 'M2296', 'CONDENSADOR ELÉCTRICO DE DOBLE CAPA (con una capacidad de almacenamiento de energía superior a 0,3 Wh)'),
                                    (2297, 'M2297', 'PRODUCTO QUÍMICO A PRESIÓN, N.E.P.'),
                                    (2298, 'M2298', 'PRODUCTO QUÍMICO A PRESIÓN, INFLAMABLE, N.E.P.'),
                                    (2299, 'M2299', 'PRODUCTO QUÍMICO A PRESIÓN, TÓXICO, N.E.P.'),
                                    (2300, 'M2300', 'PRODUCTO QUÍMICO A PRESIÓN, CORROSIVO, N.E.P.'),
                                    (2301, 'M2301', 'PRODUCTO QUÍMICO A PRESIÓN, INFLAMABLE, TÓXICO, N.E.P.'),
                                    (2302, 'M2302', 'PRODUCTO QUÍMICO A PRESIÓN, INFLAMABLE, CORROSIVO, N.E.P.'),
                                    (2303, 'M2303', 'MERCURIO CONTENIDO EN OBJETOS MANUFACTURADOS'),
                                    (2304, 'M2304', 'HEXAFLUORURO DE URANIO, MATERIALES RADIACTIVOS, BULTOS EXCEPTUADOS, menos de 0,1 kg por bulto, no fisionable o fisionable exceptuado'),
                                    (2305, 'M2305', 'CONDENSADOR ASIMÉTRICO (con una capacidad de almacenamiento de energía superior a 0,3 Wh)'),
                                    (2306, 'M2306', 'EMBALAJES/ENVASES DESECHADOS, VACÍOS, SIN LIMPIAR'),
                                    (2307, 'M2307', 'GAS ADSORBIDO INFLAMABLE, N.E.P.'),
                                    (2308, 'M2308', 'GAS ADSORBIDO, N.E.P.'),
                                    (2309, 'M2309', 'GAS ADSORBIDO TÓXICO, N.E.P.'),
                                    (2310, 'M2310', 'GAS ADSORBIDO COMBURENTE, N.E.P.'),
                                    (2311, 'M2311', 'GAS ADSORBIDO TÓXICO, INFLAMABLE, N.E.P.'),
                                    (2312, 'M2312', 'GAS ADSORBIDO TÓXICO, COMBURENTE, N.E.P.'),
                                    (2313, 'M2313', 'GAS ADSORBIDO TÓXICO, CORROSIVO, N.E.P.'),
                                    (2314, 'M2314', 'GAS ADSORBIDO TÓXICO, INFLAMABLE, CORROSIVO, N.E.P.'),
                                    (2315, 'M2315', 'GAS ADSORBIDO TÓXICO, COMBURENTE, CORROSIVO, N.E.P.'),
                                    (2316, 'M2316', 'TRIFLUORURO DE BORO ADSORBIDO'),
                                    (2317, 'M2317', 'CLORO ADSORBIDO'),
                                    (2318, 'M2318', 'TETRAFLUORURO DE SILICIO ADSORBIDO'),
                                    (2319, 'M2319', 'ARSINA ADSORBIDA'),
                                    (2320, 'M2320', 'GERMANO ADSORBIDO'),
                                    (2321, 'M2321', 'PENTAFLUORURO DE FÓSFORO ADSORBIDO'),
                                    (2322, 'M2322', 'FOSFANO ADSORBIDO'),
                                    (2323, 'M2323', 'SELENIURO DE HIDRÓGENO ADSORBIDO'),
                                    (2324, 'M2324', 'BOLSA DE RESINA\r\nPOLIESTÉRICA, material básico sólido'),
                                    (2325, 'M2325', 'MOTOR DE COMBUSTIÓN INTERNA PROPULSADO POR LÍQUIDO INFLAMABLE o MOTOR CON PILA DE COMBUSTIBLE PROPULSADO POR LÍQUIDO INFLAMABLE o MAQUINARIA DE COMBUSTIÓN INTERNA PROPULSADA POR LÍQUIDO INFLAMABLE o MAQUINARIA CON PILA DE COMBUSTIBLE PROPULSADA POR LÍQUID'),
                                    (2326, 'M2326', 'MOTOR DE COMBUSTIÓN INTERNA PROPULSADO POR GAS INFLAMABLE o MOTOR CON PILA DE COMBUSTIBLE PROPULSADO POR GAS INFLAMABLE o MAQUINARIA DE COMBUSTIÓN INTERNA PROPULSADA POR GAS INFLAMABLE o MAQUINARIA CON PILA DE COMBUSTIBLE PROPULSADA POR GAS INFLAMABLE'),
                                    (2327, 'M2327', 'MOTOR DE COMBUSTIÓN INTERNA o MAQUINARIA DE COMBUSTIÓN INTERNA'),
                                    (2328, 'M2328', 'SUSTANCIA POLIMERIZANTE, SÓLIDA, ESTABILIZADA, N.E.P.'),
                                    (2329, 'M2329', 'SUSTANCIA POLIMERIZANTE, LÍQUIDA, ESTABILIZADA, N.E.P.'),
                                    (2330, 'M2330', 'SUSTANCIA POLIMERIZANTE, SÓLIDA, CON TEMPERATURA REGULADA, N.E.P.'),
                                    (2331, 'M2331', 'SUSTANCIA POLIMERIZANTE, LÍQUIDA, CON TEMPERATURA REGULADA, N.E.P.'),
                                    (2332, 'M2332', 'SÓLIDO TÓXICO, INFLAMABLE, INORGÁNICO, N.E.P.'),
                                    (2333, 'M2333', 'BATERÍAS DE LITIO INSTALADAS EN LA UNIDAD DE TRANSPORTE baterías de ión litio o baterías de litio metálico'),
                                    (2334, 'M2334', 'ARTÍCULOS QUE CONTIENEN GASES INFLAMABLES, N.E.P.'),
                                    (2335, 'M2335', 'ARTÍCULOS QUE CONTIENEN GASES NO INFLAMABLES, NO TÓXICOS, N.E.P.'),
                                    (2336, 'M2336', 'ARTÍCULOS QUE CONTIENEN GASES TÓXICOS, N.E.P.'),
                                    (2337, 'M2337', 'ARTÍCULOS QUE CONTIENEN LÍQUIDOS INFLAMABLES, N.E.P.'),
                                    (2338, 'M2338', 'ARTÍCULOS QUE CONTIENEN SÓLIDOS INFLAMABLES, N.E.P.'),
                                    (2339, 'M2339', 'ARTÍCULOS QUE CONTIENEN SUSTANCIAS QUE PRESENTAN RIESGO DE COMBUSTIÓN ESPONTÁNEA, N.E.P.'),
                                    (2340, 'M2340', 'ARTÍCULOS QUE CONTIENEN SUSTANCIAS QUE, EN CONTACTO CON EL AGUA, DESPRENDEN GASES INFLAMABLES, N.E.P.'),
                                    (2341, 'M2341', 'ARTÍCULOS QUE CONTIENEN SUSTANCIAS COMBURENTES, N.E.P.'),
                                    (2342, 'M2342', 'ARTÍCULOS QUE CONTIENEN PERÓXIDOS ORGÁNICOS, N.E.P.'),
                                    (2343, 'M2343', 'ARTÍCULOS QUE CONTIENEN SUSTANCIAS TÓXICAS, N.E.P.'),
                                    (2344, 'M2344', 'ARTÍCULOS QUE CONTIENEN SUSTANCIAS CORROSIVAS, N.E.P.'),
                                    (2345, 'M2345', 'ARTÍCULOS QUE CONTIENEN MERCANCÍAS PELIGROSAS DIVERSAS, N.E.P.'),
                                    (2346, 'M2346', 'DESECHOS MÉDICOS, DE CATEGORÍA A, QUE AFECTAN A LAS PERSONAS, sólidos o DESECHOS MÉDICOS, DE CATEGORÍA A, QUE AFECTAN A LOS ANIMALES únicamente, sólidos ');"



    'PorteMercancia
    Public vartablaportemercancia As String = "CREATE TABLE IF NOT EXISTS `portemercancia` (
                                                  `Id` int(11) NOT NULL,
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                                  `UniMedSAT` varchar(30) NOT NULL DEFAULT '',
                                                  `ProdServSAT` varchar(30) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteMunicipios
    Public vartablaportemunicipios As String = "CREATE TABLE IF NOT EXISTS `portemunicipios` (
                                                  `Id` int(11) NOT NULL,
                                                  `ClaveMun` varchar(10) NOT NULL DEFAULT '',
                                                  `ClaveEdo` varchar(10) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(150) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteOperador
    Public vartablaporteoperador As String = "CREATE TABLE IF NOT EXISTS `porteoperador` (
                                                  `Id` int(11) NOT NULL,
                                                  `Nombre` varchar(100) NOT NULL DEFAULT '',
                                                  `RFC` varchar(50) NOT NULL DEFAULT '',
                                                  `Licencia` varchar(50) NOT NULL DEFAULT '',
                                                  `Sueldo` varchar(50) NOT NULL DEFAULT '',
                                                  `CP` varchar(20) NOT NULL DEFAULT '',
                                                  `Calle` varchar(100) NOT NULL DEFAULT '',
                                                  `NumE` varchar(10) NOT NULL DEFAULT '',
                                                  `NumI` varchar(10) NOT NULL DEFAULT '',
                                                  `Colonia` varchar(150) NOT NULL DEFAULT '',
                                                  `Edo` varchar(100) NOT NULL DEFAULT '',
                                                  `Mun` varchar(100) NOT NULL DEFAULT '',
                                                  `Facebook` varchar(80) NOT NULL DEFAULT '',
                                                  `Telefono` varchar(20) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteOrigen
    Public vartablaporteorigen As String = "CREATE TABLE IF NOT EXISTS `porteorigen` (
                                                  `Id` int(11) NOT NULL,
                                                  `Remitente` varchar(150) NOT NULL DEFAULT '',
                                                  `RFC` varchar(50) NOT NULL DEFAULT '',
                                                  `CP` varchar(10) NOT NULL DEFAULT '',
                                                  `Calle` varchar(100) NOT NULL DEFAULT '',
                                                  `NumExt` varchar(10) NOT NULL DEFAULT '',
                                                  `NumInt` varchar(10) NOT NULL DEFAULT '',
                                                  `Colonia` varchar(100) NOT NULL DEFAULT '',
                                                  `Edo` varchar(100) NOT NULL DEFAULT '',
                                                  `Mun` varchar(100) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PortePais
    Public vartablaportepais As String = "CREATE TABLE IF NOT EXISTS `portepais` (
                                          `Id` int(11) NOT NULL,
                                          `ClavePais` varchar(30) NOT NULL DEFAULT '',
                                          `Nombre` varchar(100) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteProducto
    Public vartablaporteproducto As String = "CREATE TABLE IF NOT EXISTS `porteproducto` (
                                          `Id` int(11) NOT NULL,
                                          `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                          `ValorUnitario` varchar(50) NOT NULL DEFAULT '',
                                          `UniMedSat` varchar(100) NOT NULL DEFAULT '',
                                          `ClaveSat` varchar(100) NOT NULL DEFAULT '',
                                          `NomClaveSat` varchar(100) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteProductoSat
    Public vartablaporteproductosat As String = "CREATE TABLE IF NOT EXISTS `porteproductosat` (
                                                  `Id` int(11) NOT NULL,
                                                  `ClaveProdSat` varchar(20) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PortePropietario
    Public vartablaportepropietario As String = "CREATE TABLE IF NOT EXISTS `portepropietario` (
                                                  `Id` int(11) NOT NULL,
                                                  `Nombre` varchar(150) NOT NULL DEFAULT '',
                                                  `RFC` varchar(20) NOT NULL DEFAULT '',
                                                  `Licencia` varchar(20) NOT NULL DEFAULT '',
                                                  `Tipo` varchar(50) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteTipoCarga
    Public vartablaportetipocarga As String = "CREATE TABLE IF NOT EXISTS `portetipocarga` (
                                                  `Id` int(11) NOT NULL,
                                                  `Clave` varchar(10) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(100) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaportetipocarga As String = "INSERT INTO `portetipocarga` (`Id`, `Clave`, `Descripcion`) VALUES
                                                    (1, 'CGS', 'Carga General Suelta'),
                                                    (2, 'CGC', 'Carga General Contenerizada'),
                                                    (3, 'GMN', 'Gran Mineral'),
                                                    (4, 'GAG', 'Granel Agrícola'),
                                                    (5, 'OFL', 'Otros Fluidos'),
                                                    (6, 'PYD', 'Petróleo y Derivados');"



    'PorteTipoCarro
    Public vartablaportetipocarro As String = "CREATE TABLE IF NOT EXISTS `portetipocarro` (
                                                  `Id` int(11) NOT NULL,
                                                  `Clave` varchar(10) NOT NULL DEFAULT '',
                                                  `Tipo` varchar(150) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaportetipocarro As String = "INSERT INTO `portetipocarro` (`Id`, `Clave`, `Tipo`, `Descripcion`) VALUES
                                                (1, 'TC01', 'Furgón', ''),
                                                (2, 'TC02', 'Góndola', ''),
                                                (3, 'TC03', 'Tolva', ''),
                                                (4, 'TC04', 'Tanque', ''),
                                                (5, 'TC05', 'Tipo\r\nPlataforma Intermodal', 'Se utiliza cuando se transportan contenedores.'),
                                                (6, 'Clave TC06', 'Plataforma Especializada', 'Se utiliza para transportar mercancías de gran peso o volumen'),
                                                (7, 'TC07', 'Plataforma Automotriz', 'Se utiliza cuando se transportan automóviles');"



    'PorteTipoContenedor
    Public vartablaportetipocontenedor As String = "CREATE TABLE IF NOT EXISTS `portetipocontenedor` (
                                                      `Id` int(11) NOT NULL,
                                                      `Clave` varchar(10) NOT NULL DEFAULT '',
                                                      `Tipo` varchar(150) NOT NULL DEFAULT '',
                                                      `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteTipoEmbalaje
    Public vartablaportetipoembalaje As String = "CREATE TABLE IF NOT EXISTS `portetipoembalaje` (
                                                  `Id` int(11) NOT NULL,
                                                  `ClaveDesignacion` varchar(10) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteTipoPermiso
    Public vartablaportetipopermiso As String = "CREATE TABLE IF NOT EXISTS `portetipopermiso` (
                                                  `Id` int(11) NOT NULL,
                                                  `Clave` varchar(10) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteTipoRemolque
    Public vartablaportetiporemolque As String = "CREATE TABLE IF NOT EXISTS `portetiporemolque` (
                                                      `Id` int(11) NOT NULL,
                                                      `ClaveTipoRemolque` varchar(10) NOT NULL DEFAULT '',
                                                      `Remolque` varchar(255) NOT NULL DEFAULT ''
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'PorteTransporte
    Public vartablaportetransporte As String = "CREATE TABLE IF NOT EXISTS `portetransporte` (
                                                      `Id` int(11) NOT NULL,
                                                      `ClaveTransporte` varchar(10) NOT NULL DEFAULT '',
                                                      `Descripcion` varchar(255) NOT NULL DEFAULT ''
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaportetransporte As String = "INSERT INTO `portetransporte` (`Id`, `ClaveTransporte`, `Descripcion`) VALUES
                                                (1, '01', 'Autotransporte Federal'),
                                                (2, '02', 'Transporte Marítimo'),
                                                (3, '03', 'Transporte Aéreo'),
                                                (4, '04', 'Transporte Ferroviario'),
                                                (5, '05', 'Ducto')"



    'PorteUnidadMedEmb
    Public vartablaporteunidadmedemb As String = "CREATE TABLE IF NOT EXISTS `porteunidadmedemb` (
                                                  `Id` int(11) NOT NULL,
                                                  `ClaveUnidad` varchar(10) NOT NULL DEFAULT '',
                                                  `Nombre` varchar(150) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(255) NOT NULL DEFAULT '',
                                                  `Bandera` varchar(30) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Preferencia
    Public vartablapreferencias As String = "CREATE TABLE `preferencia` (
                                              `IdPrefe` int(11) NOT NULL,
                                              `Codigo` varchar(10) DEFAULT '',
                                              `NombrePrefe` varchar(255) DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Procesos_Prod
    Public vartablaprocesos_prod As String = "CREATE TABLE IF NOT EXISTS `procesos_prod` (
                                              `Id` int(11) NOT NULL,
                                              `Proceso` varchar(255) NOT NULL DEFAULT '',
                                              `Codigo` varchar(20) NOT NULL DEFAULT '',
                                              `Nombre` varchar(255) NOT NULL DEFAULT '',
                                              `Cantidad` float NOT NULL DEFAULT '0',
                                              `Lote` varchar(30) NOT NULL DEFAULT '',
                                              `Encargado` varchar(50) NOT NULL DEFAULT '',
                                              `Usuario` varchar(50) NOT NULL DEFAULT '',
                                              `Status` int(1) NOT NULL DEFAULT '0',
                                              `Fecha` datetime NOT NULL
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Productos
    Public vartablaproductos As String = "CREATE TABLE `productos` (
                                                  `Id` int(11) NOT NULL,
                                                  `Codigo` varchar(50) NOT NULL DEFAULT '',
                                                  `CodBarra` varchar(100) NOT NULL DEFAULT '',
                                                  `CodBarra1` varchar(100) NOT NULL DEFAULT '',
                                                  `CodBarra2` varchar(100) NOT NULL DEFAULT '',
                                                  `CodBarra3` varchar(100) NOT NULL DEFAULT '',
                                                  `Nombre` varchar(250) NOT NULL DEFAULT '',
                                                  `NombreLargo` varchar(250) NOT NULL DEFAULT '',
                                                  `ProvPri` varchar(250) NOT NULL DEFAULT '',
                                                  `ProvEme` varchar(250) NOT NULL DEFAULT '',
                                                  `ProvRes` int(1) NOT NULL DEFAULT '0',
                                                  `UCompra` varchar(50) NOT NULL DEFAULT '',
                                                  `UVenta` varchar(50) NOT NULL DEFAULT '',
                                                  `UMinima` varchar(50) NOT NULL DEFAULT '',
                                                  `MCD` float NOT NULL DEFAULT '0',
                                                  `Multiplo` float NOT NULL DEFAULT '0',
                                                  `Departamento` varchar(250) NOT NULL DEFAULT '',
                                                  `Grupo` varchar(250) NOT NULL DEFAULT '',
                                                  `Ubicacion` varchar(250) NOT NULL DEFAULT '',
                                                  `Min` float NOT NULL DEFAULT '0',
                                                  `Max` float NOT NULL DEFAULT '0',
                                                  `Comision` float NOT NULL DEFAULT '0',
                                                  `PrecioCompra` float NOT NULL DEFAULT '0',
                                                  `PrecioVenta` float NOT NULL DEFAULT '0',
                                                  `PrecioVenta2` float NOT NULL DEFAULT '0',
                                                  `PrecioVentaIVA` float NOT NULL DEFAULT '0',
                                                  `PrecioDomicilio` float DEFAULT '0',
                                                  `PrecioDomicilioIVA` float DEFAULT '0',
                                                  `PorcMin` float NOT NULL DEFAULT '0',
                                                  `PorcMin2` float NOT NULL DEFAULT '0',
                                                  `PreMin` float NOT NULL DEFAULT '0',
                                                  `PreMin2` float NOT NULL DEFAULT '0',
                                                  `IVA` float NOT NULL DEFAULT '0',
                                                  `Existencia` float NOT NULL DEFAULT '0',
                                                  `Porcentaje` float NOT NULL DEFAULT '0',
                                                  `Porcentaje2` float NOT NULL DEFAULT '0',
                                                  `Fecha` date NOT NULL,
                                                  `PorcMay` float NOT NULL DEFAULT '0',
                                                  `PorcMay2` float NOT NULL DEFAULT '0',
                                                  `PorcMM` float NOT NULL DEFAULT '0',
                                                  `PorcMM2` float NOT NULL DEFAULT '0',
                                                  `PorcEsp` float NOT NULL DEFAULT '0',
                                                  `PorcEsp2` float NOT NULL DEFAULT '0',
                                                  `PreMay` float NOT NULL DEFAULT '0',
                                                  `PreMay2` float NOT NULL DEFAULT '0',
                                                  `PreMM` float NOT NULL DEFAULT '0',
                                                  `PreMM2` float NOT NULL DEFAULT '0',
                                                  `PreEsp` float NOT NULL DEFAULT '0',
                                                  `PreEsp2` float NOT NULL DEFAULT '0',
                                                  `CantMin1` float NOT NULL DEFAULT '0',
                                                  `CantMin2` float NOT NULL DEFAULT '0',
                                                  `CantMin3` float NOT NULL DEFAULT '0',
                                                  `CantMin4` float NOT NULL DEFAULT '0',
                                                  `CantMay1` float NOT NULL DEFAULT '0',
                                                  `CantMay2` float NOT NULL DEFAULT '0',
                                                  `CantMay3` float NOT NULL DEFAULT '0',
                                                  `CantMay4` float NOT NULL DEFAULT '0',
                                                  `CantMM1` float NOT NULL DEFAULT '0',
                                                  `CantMM2` float NOT NULL DEFAULT '0',
                                                  `CantMM3` float NOT NULL DEFAULT '0',
                                                  `CantMM4` float NOT NULL DEFAULT '0',
                                                  `CantEsp1` float NOT NULL DEFAULT '0',
                                                  `CantEsp2` float NOT NULL DEFAULT '0',
                                                  `CantEsp3` float NOT NULL DEFAULT '0',
                                                  `CantEsp4` float NOT NULL DEFAULT '0',
                                                  `CantLst1` float NOT NULL DEFAULT '0',
                                                  `CantLst2` float NOT NULL DEFAULT '0',
                                                  `CantLst3` float NOT NULL DEFAULT '0',
                                                  `CantLst4` float NOT NULL DEFAULT '0',
                                                  `pres_vol` int(1) NOT NULL DEFAULT '0',
                                                  `id_tbMoneda` float NOT NULL DEFAULT '0',
                                                  `Promocion` int(1) NOT NULL DEFAULT '0',
                                                  `Descto` float NOT NULL DEFAULT '0',
                                                  `Afecta_exis` int(1) NOT NULL DEFAULT '0',
                                                  `PercentIVAret` float NOT NULL DEFAULT '0',
                                                  `Almacen3` float NOT NULL DEFAULT '0',
                                                  `IIEPS` float NOT NULL DEFAULT '0',
                                                  `InvInicial` float NOT NULL DEFAULT '0',
                                                  `ISR` float NOT NULL DEFAULT '0',
                                                  `InvFinal` float NOT NULL DEFAULT '0',
                                                  `InvInicialCosto` float NOT NULL DEFAULT '0',
                                                  `InvFinalCosto` float NOT NULL DEFAULT '0',
                                                  `ClaveSat` varchar(100) NOT NULL DEFAULT '',
                                                  `UnidadSat` varchar(50) NOT NULL DEFAULT '',
                                                  `Cargado` int(1) NOT NULL DEFAULT '0',
                                                  `CargadoInv` int(1) NOT NULL DEFAULT '0',
                                                  `Uso` varchar(100) NOT NULL DEFAULT '',
                                                  `Color` varchar(100) NOT NULL DEFAULT '',
                                                  `Genero` varchar(100) NOT NULL DEFAULT '',
                                                  `Marca` varchar(100) NOT NULL DEFAULT '',
                                                  `Articulo` varchar(100) NOT NULL DEFAULT '',
                                                  `Dia` float NOT NULL DEFAULT '0',
                                                  `Descu` varchar(50) NOT NULL DEFAULT '0',
                                                  `Status_Promocion` int(1) NOT NULL DEFAULT '0',
                                                  `Porcentaje_Promo` float NOT NULL DEFAULT '0',
                                                  `Fecha_Inicial` date NOT NULL,
                                                  `Fecha_Final` date NOT NULL,
                                                  `Promo_Monedero` float NOT NULL DEFAULT '0',
                                                  `Unico` int(1) NOT NULL DEFAULT '0',
                                                  `N_Serie` varchar(150) NOT NULL DEFAULT '',
                                                  `GPrint` varchar(80) DEFAULT '',
                                                  `Cant_Ent` float DEFAULT '0',
                                                  `E1` int(1) DEFAULT '0',
                                                  `E2` int(1) DEFAULT '0',
                                                  `NumPromo` varchar(50) DEFAULT '0',
                                                  `Modo_Almacen` int(1) DEFAULT '0',
                                                  `F44` float DEFAULT '0',
                                                  `CargadoAndroid` int(11) DEFAULT '0' COMMENT 'para ventas en ruta',
                                                  `Mililitros` float DEFAULT '0',
                                                  `Copas` float DEFAULT '0'
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'ProMasVen
    Public vartablapromasven As String = "CREATE TABLE IF NOT EXISTS `promasven` (
                                          `Cod` varchar(50) NOT NULL DEFAULT '',
                                          `Cant` float NOT NULL DEFAULT '0',
                                          `Descrip` varchar(250) NOT NULL DEFAULT '',
                                          `Unidad` varchar(50) NOT NULL DEFAULT '',
                                          `Inicio` date NOT NULL,
                                          `Final` date NOT NULL
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Promociones
    Public vartablapromociones As String = "CREATE TABLE `promociones` (
                                              `Id` int(11) NOT NULL,
                                              `CodigoAlpha` varchar(10) DEFAULT '',
                                              `Codigo` varchar(10) DEFAULT '',
                                              `Descx` varchar(255) DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Proveedores
    Public vartablaproveedores As String = "CREATE TABLE IF NOT EXISTS `proveedores` (
                                          `Id` int(11) NOT NULL,
                                          `NComercial` varchar(250) NOT NULL DEFAULT '',
                                          `Compania` varchar(250) NOT NULL DEFAULT '',
                                          `RFC` varchar(100) NOT NULL DEFAULT '',
                                          `CURP` varchar(100) NOT NULL DEFAULT '',
                                          `Calle` varchar(250) NOT NULL DEFAULT '',
                                          `Colonia` varchar(250) NOT NULL DEFAULT '',
                                          `CP` varchar(100) NOT NULL DEFAULT '',
                                          `Delegacion` varchar(200) NOT NULL DEFAULT '',
                                          `Entidad` varchar(200) NOT NULL DEFAULT '',
                                          `Telefono` varchar(150) NOT NULL DEFAULT '',
                                          `Facebook` varchar(150) NOT NULL DEFAULT '',
                                          `Correo` varchar(100) NOT NULL DEFAULT '',
                                          `Saldo` float NOT NULL DEFAULT '0',
                                          `Credito` float NOT NULL DEFAULT '0',
                                          `DiasCred` int(11) NOT NULL DEFAULT '0',
                                          `Cargado` int(11) NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    'Recargas telefonicas
    Public vartablarecargas As String = "CREATE TABLE IF NOT EXISTS `recargas` (
                                              `Id` int(11) NOT NULL,
                                              `Nombre` varchar(255) DEFAULT '',
                                              `Codigo` varchar(255) DEFAULT '',
                                              `Descripcion` varchar(255) DEFAULT '',
                                              `Monto` varchar(255) DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


    'RegimenFiscalSat
    Public vartablaregimenfiscalsat As String = "CREATE TABLE IF NOT EXISTS `regimenfiscalsat` (
                                                  `ClaveRegFis` varchar(250) NOT NULL DEFAULT '',
                                                  `Descripcion` varchar(250) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertaregimenfiscalsat As String = "INSERT INTO `regimenfiscalsat` (`ClaveRegFis`, `Descripcion`) VALUES
                                                ('601', 'General de Ley Personas Morales'),
                                                ('603', 'Personas Morales con Fines no Lucrativos'),
                                                ('605', 'Sueldos y Salarios e Ingresos Asimilados a Salarios'),
                                                ('606', 'Arrendamiento'),
                                                ('607', 'Régimen de Enajenación o Adquisición de Bienes'),
                                                ('608', 'Demás ingresos'),
                                                ('610', 'Residentes en el Extranjero sin Establecimiento Permanente en México'),
                                                ('611', 'Ingresos por Dividendos (socios y accionistas)'),
                                                ('612', 'Personas Físicas con Actividades Empresariales y Profesionales'),
                                                ('614', 'Ingresos por intereses'),
                                                ('615', 'Regimen de los ingresos por obtención de premios'),
                                                ('616', 'Sin obligaciones fiscales'),
                                                ('620', 'Sociedades Cooperativas de Producción que optan por diferir sus ingresos'),
                                                ('621', 'Incorporación Fiscal'),
                                                ('622', 'Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras'),
                                                ('623', 'Opcional para Grupos de Sociedades'),
                                                ('624', 'Coordinados'),
                                                ('625', 'Régimen de las Actividades Empresariales con ingresos a través de Plataformas Tecnológicas'),
                                                ('626', 'Régimen Simplificado de Confianza');"



    'Rep_Antib
    Public vartablarep_antib As String = "CREATE TABLE IF NOT EXISTS `rep_antib` (
                                          `Id` int(11) NOT NULL,
                                          `me_id` int(1) NOT NULL DEFAULT '0',
                                          `Folio` int(11) NOT NULL DEFAULT '0',
                                          `Receta` varchar(100) NOT NULL DEFAULT '',
                                          `Status` varchar(100) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Rep_Salidas
    Public vartablarep_salidas As String = "CREATE TABLE IF NOT EXISTS `rep_salidas` (
                                              `Codigo` varchar(50) NOT NULL DEFAULT '',
                                              `Nombre` varchar(250) NOT NULL DEFAULT '',
                                              `Cantidad` float NOT NULL DEFAULT '0',
                                              `Unidad` varchar(50) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'RepFactura
    Public vartablarepfactura As String = "CREATE TABLE IF NOT EXISTS `repfactura` (
                                                  `Cliente` varchar(250) NOT NULL DEFAULT '',
                                                  `RFC` varchar(100) NOT NULL DEFAULT '',
                                                  `CURP` varchar(100) NOT NULL DEFAULT '',
                                                  `CalleNum` varchar(250) NOT NULL DEFAULT '',
                                                  `Colonia` varchar(150) NOT NULL DEFAULT '',
                                                  `CP` varchar(150) NOT NULL DEFAULT '',
                                                  `DelMun` varchar(200) NOT NULL DEFAULT '',
                                                  `EntFed` varchar(200) NOT NULL DEFAULT '',
                                                  `Tel` varchar(100) NOT NULL DEFAULT '',
                                                  `Rems` varchar(150) NOT NULL DEFAULT '',
                                                  `Factura` varchar(150) NOT NULL DEFAULT '',
                                                  `CantLetra` varchar(50) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'RepoMen
    Public vartablarepomen As String = "CREATE TABLE IF NOT EXISTS `repomen` (
                                              `Codigo` varchar(50) NOT NULL DEFAULT '',
                                              `PDesc` varchar(250) NOT NULL DEFAULT '',
                                              `InvIni` float NOT NULL DEFAULT '0',
                                              `Compra` float NOT NULL DEFAULT '0',
                                              `CantDev` float NOT NULL DEFAULT '0',
                                              `InvFin` float NOT NULL DEFAULT '0',
                                              `CVta` float NOT NULL DEFAULT '0',
                                              `PPrecio` float NOT NULL DEFAULT '0',
                                              `VtaTotal` float NOT NULL DEFAULT '0',
                                              `CostoTotal` float NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    Public vartablarepsalidas As String = "CREATE TABLE IF NOT EXISTS `repsalidas` (
                                          `Codigo` varchar(50) NOT NULL DEFAULT '',
                                          `Nombre` varchar(250) NOT NULL DEFAULT '',
                                          `Cantidad` float NOT NULL DEFAULT '0',
                                          `Unidad` varchar(100) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'RutasImpresion
    Public vartablarutasimpresion As String = "CREATE TABLE IF NOT EXISTS `rutasimpresion` (
                                              `Id` int(11) NOT NULL,
                                              `Equipo` varchar(250) NOT NULL DEFAULT '',
                                              `Tipo` varchar(250) NOT NULL DEFAULT '',
                                              `Formato` varchar(250) NOT NULL DEFAULT '',
                                              `Impresora` varchar(250) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"





    'SaldosEmpleados
    Public vartablasaldosempleados As String = "CREATE TABLE IF NOT EXISTS `saldosempleados` (
                                                  `Id` int(11) NOT NULL,
                                                  `Folio` int(11) NOT NULL DEFAULT '0',
                                                  `IdEmpleado` int(11) NOT NULL DEFAULT '0',
                                                  `Nombre` varchar(250) NOT NULL DEFAULT '',
                                                  `Fecha` date NOT NULL,
                                                  `FechaPago` date NOT NULL,
                                                  `FechaPagado` date NOT NULL,
                                                  `Cargo` float NOT NULL DEFAULT '0',
                                                  `Abono` float NOT NULL DEFAULT '0',
                                                  `Tipo` varchar(80) NOT NULL DEFAULT '',
                                                  `Concepto` varchar(150) NOT NULL DEFAULT '',
                                                  `FormaPago` varchar(50) NOT NULL DEFAULT '',
                                                  `Monto` float NOT NULL DEFAULT '0',
                                                  `Nota` varchar(250) NOT NULL DEFAULT '',
                                                  `Banco` varchar(50) NOT NULL DEFAULT '',
                                                  `Referencia` varchar(50) NOT NULL DEFAULT '',
                                                  `Comentario` varchar(255) NOT NULL DEFAULT '',
                                                  `Cuenta` varchar(50) NOT NULL DEFAULT '',
                                                  `BancoC` varchar(50) NOT NULL DEFAULT '',
                                                  `Usuario` varchar(50) NOT NULL DEFAULT '',
                                                  `Corte` int(1) NOT NULL DEFAULT '0',
                                                  `CorteU` int(1) NOT NULL DEFAULT '0',
                                                  `Estado` int(1) NOT NULL DEFAULT '0'
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Series
    Public vartablasseries As String = "CREATE TABLE `series` (
                                                  `Id` int(11) NOT NULL,
                                                  `Codigo` varchar(50) NOT NULL DEFAULT '',
                                                  `Nombre` varchar(255) NOT NULL DEFAULT '',
                                                  `Serie` varchar(100) NOT NULL DEFAULT '',
                                                  `Fecha` datetime NOT NULL,
                                                  `NotaVenta` varchar(100) NOT NULL DEFAULT '',
                                                  `FechaEliminado` varchar(50) NOT NULL DEFAULT '',
                                                  `Status` int(1) DEFAULT '0',
                                                  `Factura` varchar(50) DEFAULT '',
                                                  `FFactura` varchar(50) DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
"

    Public vartablaservicios As String = "CREATE TABLE IF NOT EXISTS `servicios` (
                                                  `Id` int(11) NOT NULL,
                                                  `Nombre` varchar(100) NOT NULL DEFAULT '',
                                                  `Codigo` varchar(100) NOT NULL DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'TAlmacen
    Public vartablatalmacen As String = "CREATE TABLE IF NOT EXISTS `talmacen` (
                                          `IDTAlmacen` int(11) NOT NULL,
                                          `Codigo` varchar(80) NOT NULL DEFAULT '',
                                          `Fecha` varchar(60) NOT NULL DEFAULT '',
                                          `Folio` int(11) NOT NULL DEFAULT '0',
                                          `TipoMov` varchar(150) NOT NULL DEFAULT '',
                                          `Entrada` float NOT NULL DEFAULT '0',
                                          `UndE` varchar(50) NOT NULL DEFAULT '',
                                          `Salida` float NOT NULL DEFAULT '0',
                                          `UndS` varchar(50) NOT NULL DEFAULT '',
                                          `Exist` float NOT NULL DEFAULT '0',
                                          `Costo` float NOT NULL DEFAULT '0',
                                          `Debe` float NOT NULL DEFAULT '0',
                                          `ExiCont` float NOT NULL DEFAULT '0',
                                          `Haber` float NOT NULL DEFAULT '0',
                                          `Saldo` float NOT NULL DEFAULT '0',
                                          `FolioReporte` int(11) NOT NULL DEFAULT '0',
                                          `FechaReporte` varchar(150) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'tb_moneda
    Public vartablatb_moneda As String = "CREATE TABLE IF NOT EXISTS `tb_moneda` (
                                          `Id` int(11) NOT NULL,
                                          `nombre_moneda` varchar(250) NOT NULL DEFAULT '',
                                          `tipo_cambio` float NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertatb_moneda As String = "INSERT INTO `tb_moneda` (`Id`, `nombre_moneda`, `tipo_cambio`) VALUES
                                            (1, 'PESO', 1);"



    'Ticket
    Public vartablaticket As String = "CREATE TABLE IF NOT EXISTS `ticket` (
                                          `Id` int(11) NOT NULL,
                                          `Cab0` varchar(250) NOT NULL DEFAULT '',
                                          `Cab1` varchar(250) NOT NULL DEFAULT '',
                                          `Cab2` varchar(250) NOT NULL DEFAULT '',
                                          `Cab3` varchar(250) NOT NULL DEFAULT '',
                                          `Cab4` varchar(250) NOT NULL DEFAULT '',
                                          `Cab5` varchar(250) NOT NULL DEFAULT '',
                                          `Cab6` varchar(250) NOT NULL DEFAULT '',
                                          `Cab7` varchar(250) NOT NULL DEFAULT '',
                                          `Pie1` text NOT NULL,
                                          `Pie2` text NOT NULL,
                                          `Pie3` text NOT NULL,
                                          `NoPrint` int(1) NOT NULL DEFAULT '0',
                                          `NoPrintCom` int(1) NOT NULL DEFAULT '0',
                                          `Copias` int(11) NOT NULL DEFAULT '0',
                                          `VSE` int(1) NOT NULL DEFAULT '0',
                                          `Pagare` text NOT NULL,
                                          `Comensal` int(1) NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public varinsertaticket As String = "INSERT INTO `ticket` (`Cab0`, `Cab1`, `Cab2`, `Cab3`, `Cab4`, `Cab5`, `Cab6`, `Pie1`, `Pie2`, `Pie3`, `NoPrint`, `Copias`, `VSE`, `Pagare`,`Comensal`) VALUES ('', '', '', '', '', '', '', '', '', '', 0, 1, 0, '',0);"



    'TipoFactorSat
    Public vartablatipofactorsat As String = "CREATE TABLE IF NOT EXISTS `tipofactorsat` (
                                          `Id` int(11) NOT NULL,
                                          `ClaveFactor` varchar(250) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'TiposComprobanteSat
    Public vartablatiposcomprobantesat As String = "CREATE TABLE IF NOT EXISTS `tiposcomprobantesat` (
                                              `Id` int(11) NOT NULL,
                                              `ClaveTipoCompro` varchar(250) NOT NULL DEFAULT '',
                                              `Descripcion` varchar(250) NOT NULL DEFAULT '',
                                              `ValorMax` varchar(250) NOT NULL DEFAULT '',
                                              `FechaIniVig` varchar(250) NOT NULL DEFAULT '',
                                              `FechaFinVig` varchar(250) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertatiposcomprobantesat As String = "INSERT INTO `tiposcomprobantesat` (`Id`, `ClaveTipoCompro`, `Descripcion`, `ValorMax`, `FechaIniVig`, `FechaFinVig`) VALUES
                                                    (1, 'I', 'Ingreso', '200000', '01/01/2017', ''),
                                                    (2, 'E', 'Egreso', '20000000', '01/01/2017', ''),
                                                    (3, 'T', 'Traslado', '0', '01/01/2017', ''),
                                                    (4, 'P', 'Pago', '20000000', '28/04/2017', ''),
                                                    (5, '', 'Nomina', '200000', '01/01/2017', '');"



    'TipoRelacionCFDISat
    Public vartablatiprelacioncfdisat As String = "CREATE TABLE IF NOT EXISTS `tiprelacioncfdisat` (
                                                      `Id` int(11) NOT NULL,
                                                      `ClaveTipoRel` varchar(250) NOT NULL DEFAULT '',
                                                      `Descripcion` varchar(250) NOT NULL DEFAULT ''
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertatiprelacioncfdisat As String = "INSERT INTO `tiprelacioncfdisat` (`Id`, `ClaveTipoRel`, `Descripcion`) VALUES
                                                        (1, '01', 'Nota de crédito de los documentos relacionados'),
                                                        (2, '02', 'Nota de débito de los documentos relacionados'),
                                                        (3, '03', 'Devolución de mercancía sobre facturas o traslados previos'),
                                                        (4, '04', 'Sustitución de los CFDI previos'),
                                                        (5, '05', 'Traslados de mercancias facturados previamente'),
                                                        (6, '06', 'Factura generada por los traslados previos'),
                                                        (7, '07', 'CFDI por aplicación de anticipo');"



    'Transporte
    Public vartablatransporte As String = "CREATE TABLE IF NOT EXISTS `transporte` (
                                                  `Id` int(11) NOT NULL,
                                                  `Modelo` varchar(100) NOT NULL DEFAULT '',
                                                  `Marca` varchar(80) NOT NULL DEFAULT '',
                                                  `Placas` varchar(80) NOT NULL DEFAULT '',
                                                  `Area` varchar(80) NOT NULL DEFAULT '',
                                                  `Chofer` varchar(115) NOT NULL DEFAULT '',
                                                  `Seguro` varchar(50) NOT NULL DEFAULT '',
                                                  `Poliza` varchar(50) NOT NULL DEFAULT '',
                                                  `Vence_Seguro` date NOT NULL,
                                                  `Contacto_Seguro` varchar(50) NOT NULL DEFAULT '',
                                                  `Agente` varchar(70) NOT NULL DEFAULT '',
                                                  `Contacto_Agente` varchar(50) NOT NULL DEFAULT '',
                                                  `Verifica1` varchar(50) NOT NULL DEFAULT '',
                                                  `Verifica2` varchar(50) NOT NULL DEFAULT '',
                                                  `NoCircula` varchar(50) NOT NULL DEFAULT '',
                                                  `Afina_Ant` date NOT NULL,
                                                  `Aceite_Ant` date NOT NULL,
                                                  `Afina_Prox` date NOT NULL,
                                                  `Aceite_Prox` date NOT NULL
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Traslados
    Public vartablatraslados As String = "CREATE TABLE IF NOT EXISTS `traslados` (
                                              `Id` int(11) NOT NULL,
                                              `Folio` int(11) NOT NULL,
                                              `idCliente` int(11) NOT NULL,
                                              `Nombre` varchar(255) NOT NULL DEFAULT '',
                                              `Direccion` varchar(150) NOT NULL DEFAULT '',
                                              `Subtotal` float NOT NULL DEFAULT '0',
                                              `IVA` float NOT NULL DEFAULT '0',
                                              `Totales` float NOT NULL DEFAULT '0',
                                              `Descuento` float NOT NULL DEFAULT '0',
                                              `Devolucion` float NOT NULL DEFAULT '0',
                                              `ACuenta` float NOT NULL DEFAULT '0',
                                              `Resta` float NOT NULL DEFAULT '0',
                                              `Usuario` varchar(50) DEFAULT '',
                                              `FVenta` date NOT NULL,
                                              `HVenta` datetime NOT NULL,
                                              `FPago` date NOT NULL,
                                              `FCancelado` date NOT NULL,
                                              `MontoEfecCanc` float NOT NULL DEFAULT '0',
                                              `Status` varchar(80) NOT NULL DEFAULT '',
                                              `Comisionista` varchar(80) NOT NULL DEFAULT '',
                                              `Facturado` varchar(80) NOT NULL DEFAULT '',
                                              `por_descuento` float NOT NULL DEFAULT '0',
                                              `PAGO_MONEDERO` float NOT NULL DEFAULT '0',
                                              `concepto` varchar(50) NOT NULL DEFAULT '',
                                              `NUM_TRASLADO` int(11) NOT NULL DEFAULT '0',
                                              `email_envio` varchar(100) NOT NULL DEFAULT '',
                                              `Cargado` int(11) NOT NULL DEFAULT '0'
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'TrasladosDet
    Public vartablatrasladosdet As String = "CREATE TABLE IF NOT EXISTS `trasladosdet` (
                                          `Id` int(11) NOT NULL,
                                          `Codigo` varchar(50) NOT NULL DEFAULT '',
                                          `Nombre` varchar(250) NOT NULL DEFAULT '',
                                          `Unidad` varchar(100) NOT NULL DEFAULT '',
                                          `Cantidad` float NOT NULL DEFAULT '0',
                                          `Precio` float NOT NULL DEFAULT '0',
                                          `Total` float NOT NULL DEFAULT '0',
                                          `Existe` float NOT NULL DEFAULT '0',
                                          `Fecha` date NOT NULL,
                                          `Concepto` varchar(150) NOT NULL DEFAULT '',
                                          `Depto` varchar(150) NOT NULL DEFAULT '',
                                          `Grupo` varchar(150) NOT NULL DEFAULT '',
                                          `Folio` int(11) NOT NULL DEFAULT '0',
                                          `CostVR` text NOT NULL
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'UMtblCFDs
    Public vartablaumtblcfds As String = "CREATE TABLE IF NOT EXISTS `umtblcfds` (
                                              `idCFDi` int(11) NOT NULL,
                                              `serie` varchar(20) NOT NULL DEFAULT '',
                                              `folio` varchar(50) NOT NULL DEFAULT '',
                                              `cadenaOriginal` text NOT NULL,
                                              `selloCFD` text NOT NULL,
                                              `version` tinyint(4) NOT NULL DEFAULT '0',
                                              `uuid` varchar(60) NOT NULL DEFAULT '',
                                              `fechaTimbrado` datetime NOT NULL,
                                              `noCertificadoSAT` varchar(30) NOT NULL DEFAULT '',
                                              `selloSAT` varchar(255) NOT NULL DEFAULT '',
                                              `CFD` text NOT NULL,
                                              `CFDi` text NOT NULL,
                                              `CFDXml` text NOT NULL,
                                              `CFDiXml` text NOT NULL,
                                              `CFDiPDF` text NOT NULL,
                                              `Timbrado` int(1) NOT NULL DEFAULT '0',
                                              `email` varchar(250) NOT NULL DEFAULT ''
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'UsoCFDISat
    Public vartablausocfdisat As String = "CREATE TABLE IF NOT EXISTS `usocfdisat` (
                                          `ClaveUsoCFDI` varchar(15) NOT NULL DEFAULT '',
                                          `Descripcion` varchar(250) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertausocfdisat As String = "INSERT INTO `usocfdisat` (`ClaveUsoCFDI`, `Descripcion`) VALUES
                                            ('CN01', 'Nómina'),
                                            ('CP01', 'Pagos'),
                                            ('D01', 'Honorarios médicos, dentales y gastos hospitalarios.'),
                                            ('D02', 'Gastos médicos por incapacidad o discapacidad'),
                                            ('D03', 'Gastos funerales.'),
                                            ('D04', 'Donativos.'),
                                            ('D05', 'Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación).'),
                                            ('D06', 'Aportaciones voluntarias al SAR.'),
                                            ('D07', 'Primas por seguros de gastos médicos.'),
                                            ('D08', 'Gastos de transportación escolar obligatoria.'),
                                            ('D09', 'Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones.'),
                                            ('D10', 'Pagos por servicios educativos (colegiaturas)'),
                                            ('G01', 'Adquisición de mercancias'),
                                            ('G02', 'Devoluciones, descuentos o bonificaciones'),
                                            ('G03', 'Gastos en general'),
                                            ('I01', 'Construcciones'),
                                            ('I02', 'Mobilario y equipo de oficina por inversiones'),
                                            ('I03', 'Equipo de transporte'),
                                            ('I04', 'Equipo de computo y accesorios'),
                                            ('I05', 'Dados, troqueles, moldes, matrices y herramental'),
                                            ('I06', 'Comunicaciones telefónicas'),
                                            ('I07', 'Comunicaciones satelitales'),
                                            ('I08', 'Otra maquinaria y equipo'),
                                            ('S01', 'Sin efectos fiscales.');"



    'UsoComproCFDISat
    Public vartablausocomprocfdisat As String = "CREATE TABLE IF NOT EXISTS `usocomprocfdisat` (
                                                      `Id` int(11) NOT NULL,
                                                      `ClaveUsoCFDI` varchar(250) NOT NULL DEFAULT '',
                                                      `Descripcion` varchar(250) NOT NULL DEFAULT '',
                                                      `PerFis` varchar(250) NOT NULL DEFAULT '',
                                                      `PerMor` varchar(250) NOT NULL DEFAULT '',
                                                      `FechaIniVig` varchar(250) NOT NULL DEFAULT '',
                                                      `FechaFinVig` varchar(250) NOT NULL DEFAULT ''
                                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    Public varinsertausocomprocfdisat As String = "INSERT INTO `usocomprocfdisat` (`Id`, `ClaveUsoCFDI`, `Descripcion`, `PerFis`, `PerMor`, `FechaIniVig`, `FechaFinVig`) VALUES
                                                (1, 'G01', 'Adquisición de mercancías.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (2, 'G02', 'Devoluciones, descuentos o bonificaciones.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (3, 'G03', 'Gastos en general.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (4, 'I01', 'Construcciones.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (5, 'I02', 'Mobiliario y equipo de oficina por inversiones.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (6, 'I03', 'Equipo de transporte.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (7, 'I04', 'Equipo de computo y accesorios.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (8, 'I05', 'Dados, troqueles, moldes, matrices y herramental.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (9, 'I06', 'Comunicaciones telefónicas.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (10, 'I07', 'Comunicaciones satelitales.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (11, 'I08', 'Otra maquinaria y equipo.', 'Sí', 'Sí', '01/01/2022', ''),
                                                (12, 'D01', 'Honorarios médicos, dentales y gastos hospitalarios.', 'Sí', 'No', '01/01/2022', ''),
                                                (13, 'D02', 'Gastos médicos por incapacidad o discapacidad.', 'Sí', 'No', '01/01/2022', ''),
                                                (14, 'D03', 'Gastos funerales.', 'Sí', 'No', '01/01/2022', ''),
                                                (15, 'D04', 'Donativos.', 'Sí', 'No', '01/01/2022', ''),
                                                (16, 'D05', 'Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación).', 'Sí', 'No', '01/01/2022', ''),
                                                (17, 'D06', 'Aportaciones voluntarias al SAR.', 'Sí', 'No', '01/01/2022', ''),
                                                (18, 'D07', 'Primas por seguros de gastos médicos.', 'Sí', 'No', '01/01/2022', ''),
                                                (19, 'D08', 'Gastos de transportación escolar obligatoria.', 'Sí', 'No', '01/01/2022', ''),
                                                (20, 'D09', 'Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones.', 'Sí', 'No', '01/01/2022', ''),
                                                (21, 'D10', 'Pagos por servicios educativos (colegiaturas).', 'Sí', 'No', '01/01/2022', ''),
                                                (22, 'S01', 'Sin efectos fiscales.  ', 'Sí', 'Sí', '01/01/2022', ''),
                                                (23, 'CP01', 'Pagos', 'Sí', 'Sí', '01/01/2022', ''),
                                                (24, 'CN01', 'Nómina', 'Sí', 'No', '01/01/2022', '');"



    'Usuarios
    Public vartablausuarios As String = "CREATE TABLE `usuarios` (
                                          `IdEmpleado` int(11) NOT NULL,
                                          `Nombre` varchar(250) NOT NULL DEFAULT '',
                                          `Alias` varchar(100) NOT NULL DEFAULT '',
                                          `Area` varchar(100) NOT NULL DEFAULT '',
                                          `Puesto` varchar(100) NOT NULL DEFAULT '',
                                          `Departamento` varchar(50) DEFAULT '',
                                          `NSS` varchar(50) NOT NULL DEFAULT '',
                                          `Rfc` varchar(50) DEFAULT '',
                                          `Curp` varchar(50) DEFAULT '',
                                          `Clave` varchar(150) NOT NULL DEFAULT '',
                                          `Ingreso` date NOT NULL,
                                          `Sueldo` float NOT NULL DEFAULT '0',
                                          `Sueldoxdia` float DEFAULT '0',
                                          `Comisionista` int(1) NOT NULL DEFAULT '0',
                                          `Calle` varchar(150) NOT NULL DEFAULT '',
                                          `Colonia` varchar(150) NOT NULL DEFAULT '',
                                          `CP` varchar(50) NOT NULL DEFAULT '',
                                          `Delegacion` varchar(150) NOT NULL DEFAULT '',
                                          `Entidad` varchar(100) NOT NULL DEFAULT '',
                                          `NumExt` varchar(10) DEFAULT '',
                                          `NumInt` varchar(10) DEFAULT '',
                                          `Telefono` varchar(100) NOT NULL DEFAULT '',
                                          `Facebook` varchar(150) NOT NULL DEFAULT '',
                                          `Correo` varchar(200) NOT NULL DEFAULT '',
                                          `Status` varchar(200) NOT NULL DEFAULT '',
                                          `Cargado` int(1) NOT NULL DEFAULT '0',
                                          `Template` longblob NOT NULL,
                                          `Horas` float NOT NULL DEFAULT '0',
                                          `Emp_empresa` int(11) DEFAULT '1' COMMENT 'es el id de datos negocio',
                                          `Emp_Regimen` varchar(10) DEFAULT '' COMMENT 'es el id de regimen contratacion',
                                          `Emp_Periodo` varchar(10) DEFAULT '' COMMENT 'es el id de peridiocidad_pago',
                                          `Emp_Jornada` varchar(10) DEFAULT '' COMMENT 'es el id de tipo_jornada',
                                          `Emp_Contrato` varchar(10) DEFAULT '' COMMENT 'es el id de tipo_contrato',
                                          `Emp_Riesgo` varchar(10) DEFAULT '' COMMENT 'es el id de riesgos',
                                          `Emp_ultimo_timbre` varchar(10) DEFAULT '',
                                          `Estado` varchar(50) DEFAULT '' COMMENT 'la clave de la tabla estados',
                                          `FormaPago` varchar(50) DEFAULT '',
                                          `Banco` varchar(50) DEFAULT '',
                                          `ClaveP` varchar(50) DEFAULT '',
                                          `CuentaP` varchar(50) DEFAULT '',
                                          `CargadoAndroid` int(11) NOT NULL DEFAULT '0'
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"


    Public varinsertausuarios As String = "INSERT INTO `usuarios` (`IdEmpleado`, `Nombre`, `Alias`, `Area`, `Puesto`, `Departamento`, `NSS`, `Rfc`, `Curp`, `Clave`, `Ingreso`, `Sueldo`, `Sueldoxdia`, `Comisionista`, `Calle`, `Colonia`, `CP`, `Delegacion`, `Entidad`, `NumExt`, `NumInt`, `Telefono`, `Facebook`, `Correo`, `Status`, `Cargado`, `Template`, `Horas`, `Emp_empresa`, `Emp_Regimen`, `Emp_Periodo`, `Emp_Jornada`, `Emp_Contrato`, `Emp_Riesgo`, `Estado`, `FormaPago`, `Banco`, `ClaveP`, `CuentaP`) VALUES
(1, 'ADMINISTRADOR', 'ADMIN', 'ADMINISTRACIÓN', 'ADMINISTRACIÓN', '', '', '', '', '1', '2023-07-28', 0, 0, 0, '', '', '', '', '', '0', '0', '', '', '', '1', 1, '', 0, 1, '', '', '', '', '', '', '', '', '', '');"



    'UUIDRelacion
    Public vartablauuidrelacion As String = "CREATE TABLE IF NOT EXISTS `uuidrelacion` (
                                          `Id` int(11) NOT NULL,
                                          `IdFact` int(11) NOT NULL DEFAULT '0',
                                          `UUID` varchar(250) NOT NULL DEFAULT '',
                                          `TipoRelacion` varchar(250) NOT NULL DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'Ventas
    Public vartablaventas As String = "CREATE TABLE IF NOT EXISTS `ventas` (
                                              `Folio` int(11) NOT NULL,
                                              `IdCliente` int(11) NOT NULL DEFAULT '0',
                                              `Cliente` varchar(40) NOT NULL DEFAULT '',
                                              `Direccion` varchar(255) NOT NULL DEFAULT '',
                                              `Subtotal` float NOT NULL DEFAULT '0',
                                              `IVA` float NOT NULL DEFAULT '0',
                                              `Totales` float NOT NULL DEFAULT '0',
                                              `Propina` float NOT NULL DEFAULT '0',
                                              `Descuento` float NOT NULL DEFAULT '0',
                                              `Devolucion` float NOT NULL DEFAULT '0',
                                              `ACuenta` float NOT NULL DEFAULT '0',
                                              `Resta` float NOT NULL DEFAULT '0',
                                              `Usuario` varchar(60) NOT NULL DEFAULT '',
                                              `FVenta` date NOT NULL,
                                              `HVenta` time NOT NULL,
                                              `FPago` varchar(80) NOT NULL DEFAULT '',
                                              `FCancelado` varchar(80) NOT NULL DEFAULT '',
                                              `MontoCance` float NOT NULL DEFAULT '0',
                                              `Status` varchar(50) NOT NULL DEFAULT '',
                                              `Comisionista` varchar(80) NOT NULL DEFAULT '',
                                              `Facturado` int(11) NOT NULL DEFAULT '0',
                                              `Concepto` varchar(150) NOT NULL DEFAULT '',
                                              `N_Traslado` int(11) NOT NULL DEFAULT '0',
                                              `Corte` int(1) NOT NULL DEFAULT '0',
                                              `CorteU` int(1) NOT NULL DEFAULT '0',
                                              `MontoSinDesc` float NOT NULL DEFAULT '0',
                                              `Cargado` int(1) NOT NULL DEFAULT '0',
                                              `FEntrega` varchar(100) NOT NULL DEFAULT '',
                                              `Entrega` int(1) NOT NULL DEFAULT '0',
                                              `Comentario` varchar(255) NOT NULL DEFAULT '',
                                              `CantidadE` float NOT NULL DEFAULT '0',
                                              `StatusE` int(1) NOT NULL DEFAULT '0',
                                              `FolMonedero` varchar(100) NOT NULL DEFAULT '',
                                              `CodFactura` varchar(250) NOT NULL DEFAULT '',
                                              `CargadoF` int(1) NOT NULL DEFAULT '0',
                                              `IP` varchar(250) NOT NULL DEFAULT '',
                                              `Formato` varchar(150) NOT NULL DEFAULT '',
                                              `TComensales` varchar(50) NOT NULL DEFAULT '',
                                              `MntoCortesia` float NOT NULL DEFAULT '0',
                                              `Franquicia` INT(1) NOT NULL DEFAULT '0',
                                              `CargadoAndroid` INT(1) NOT NULL DEFAULT '0',
                                              `FolioAndroid` varchar(100) NOT NULL DEFAULT '',
                                              `HVenta2` varchar(100) NOT NULL DEFAULT '',
                                              `Pedido` int NOT NULL DEFAULT '0',
                                                `Fecha` datetime NOT NULL
                                            ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'VentasDetalle
    Public vartablaventasdetalle As String = "CREATE TABLE IF NOT EXISTS `ventasdetalle` (
                                      `Id` int(11) NOT NULL,
                                      `Folio` int(11) NOT NULL DEFAULT '0',
                                      `Codigo` varchar(100) NOT NULL DEFAULT '',
                                      `Nombre` varchar(250) NOT NULL DEFAULT '',
                                      `Unidad` varchar(50) NOT NULL DEFAULT '',
                                      `Cantidad` float NOT NULL DEFAULT '0',
                                      `CostoVP` float NOT NULL DEFAULT '0',
                                      `CostoVUE` float NOT NULL DEFAULT '0',
                                      `Precio` float NOT NULL DEFAULT '0',
                                      `Total` float NOT NULL DEFAULT '0',
                                      `PrecioSinIVA` double NOT NULL DEFAULT '0',
                                      `TotalSinIVA` double NOT NULL DEFAULT '0',
                                      `Fecha` date NOT NULL,
                                      `Comisionista` varchar(100) NOT NULL DEFAULT '',
                                      `Facturado` varchar(100) NOT NULL DEFAULT '',
                                      `Depto` varchar(150) NOT NULL DEFAULT '',
                                      `Grupo` varchar(150) NOT NULL DEFAULT '',
                                      `CostVR` varchar(255) NOT NULL DEFAULT '',
                                      `Descto` float NOT NULL DEFAULT '0',
                                      `VDCosteo` float NOT NULL DEFAULT '0',
                                      `TotalIEPS` float NOT NULL DEFAULT '0',
                                      `TasaIEPS` float NOT NULL DEFAULT '0',
                                      `Caducidad` varchar(80) NOT NULL DEFAULT '',
                                      `Lote` varchar(100) NOT NULL DEFAULT '',
                                      `CantidadE` float NOT NULL DEFAULT '0',
                                      `Promo_Monedero` float NOT NULL DEFAULT '0',
                                      `Unico` int(1) NOT NULL DEFAULT '0',
                                      `N_Serie` varchar(200) NOT NULL DEFAULT '0',
                                      `Descuento` float NOT NULL DEFAULT '0',
                                      `GPrint` varchar(80) NOT NULL DEFAULT '',
                                      `Porc_Descuento` float NOT NULL DEFAULT '0',
                                      `Precio_Original` float NOT NULL DEFAULT '0',
                                      `Comensal` varchar(80) NOT NULL DEFAULT '',
                                      `Comentario` varchar(255) NOT NULL DEFAULT '',
                                      `Usuario` varchar(100) NOT NULL DEFAULT ''
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    Public vartablacomandas_t As String = "CREATE TABLE `comandas_t` (                 
                                          `Id` int(11) DEFAULT '0',
                                          `Pedido` varchar(80) DEFAULT '',
                                          `Codigo` varchar(10) DEFAULT '',
                                          `Nombre` varchar(255) DEFAULT '',
                                          `Unidad` varchar(20) DEFAULT '',
                                          `Cantidad` float DEFAULT '0',                                          
                                          `Precio` float DEFAULT '0',
                                          `Total` float DEFAULT '0',
                                          `Fecha` date DEFAULT NULL,
                                          `Depto` varchar(80) DEFAULT '',
                                          `Grupo` varchar(80) DEFAULT '',
                                          `Comentario` varchar(255) DEFAULT '',
                                          `GPrint` varchar(50) DEFAULT ''
                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"



    'VtaImpresion
    Public vartablavtaimpresion As String = "  CREATE TABLE `vtaimpresion` (
                                                  `Id` int(11) NOT NULL,
                                                  `Folio` int(11) DEFAULT '0',
                                                  `Codigo` varchar(10) DEFAULT '',
                                                  `Nombre` varchar(255) DEFAULT '',
                                                  `UVenta` varchar(10) DEFAULT '',
                                                  `Cantidad` float DEFAULT '0',
                                                  `CostVR` float DEFAULT '0',
                                                  `CostVP` float DEFAULT '0',
                                                  `CostVUE` float DEFAULT '0',
                                                  `Precio` float DEFAULT '0',
                                                  `Total` float DEFAULT '0',
                                                  `PrecioSinIVA` float DEFAULT '0',
                                                  `TotalSinIVA` float DEFAULT '0',
                                                  `Fecha` date DEFAULT NULL,
                                                  `Comisionista` varchar(50) DEFAULT '',
                                                  `Facturado` int(11) DEFAULT '0',
                                                  `Depto` varchar(50) DEFAULT '',
                                                  `Grupo` varchar(50) DEFAULT '',
                                                  `Comensal` varchar(50) DEFAULT '',
                                                  `Propina` float DEFAULT '0',
                                                  `Mesa` varchar(50) DEFAULT ''
                                                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"







    '/////////////////////////////////////////////////////////////////////////
    'LLAVES PRIMARIAS
    '/////////////////////////////////////////////////////////////////////////
    Public VarKeyprecios As String = "ALTER TABLE `precios` ADD PRIMARY KEY (`Id`);"
    Public VarKeymarcas As String = "ALTER TABLE `marcas` ADD PRIMARY KEY (`Id`);"
    Public VarKeyvehiculo2 As String = "ALTER TABLE `vehiculo2` ADD PRIMARY KEY (`Id`);"
    Public VarKeynominass As String = "ALTER TABLE `nominas` ADD PRIMARY KEY (`Id`);"
    Public VarKeypedidosvendet As String = "ALTER TABLE `pedidosvendet` ADD PRIMARY KEY (`Id`);"
    Public VarKeypedidosven As String = "ALTER TABLE `pedidosven` ADD PRIMARY KEY (`Folio`);"
    Public VarKeydetallehotelprecios As String = "ALTER TABLE `detallehotelprecios` ADD PRIMARY KEY (`Id`);"
    Public varKeypromos As String = "ALTER TABLE `promos` ADD PRIMARY KEY (`Id`);"
    Public varKeyclienteeliminado As String = "ALTER TABLE `clienteeliminado` ADD PRIMARY KEY (`Id`);"
    Public varKeyproductoeliminado As String = "ALTER TABLE `productoeliminado` ADD PRIMARY KEY (`Id`);"
    Public varKeypedidostemporal As String = "ALTER TABLE `pedidostemporal` ADD PRIMARY KEY (`Id`);"
    Public varKeypedidoeliminado As String = "ALTER TABLE `pedidoeliminado` ADD PRIMARY KEY (`Id`);"
    Public varKeydetallenomina As String = "ALTER TABLE `detalle_nomina` ADD PRIMARY KEY (`Id_detalle`);"
    Public varKeyotipoincapacidadsat As String = "ALTER TABLE `tipoincapacidadsat` ADD PRIMARY KEY (`Id`);"
    Public varKeyotiponomina As String = "ALTER TABLE `tiponomina` ADD PRIMARY KEY (`Id`);"
    Public varKeyotrospagos As String = "ALTER TABLE `otrospagos` ADD PRIMARY KEY (`Id`);"
    Public varKeytipopercepcioncontable As String = "ALTER TABLE `tipo_percepcion_contable` ADD PRIMARY KEY (`Id`);"
    Public varKeytipodeduccioncontable As String = "ALTER TABLE `tipo_deduccion_contable` ADD PRIMARY KEY (`Id`);"
    Public varKeyriesgopuesto As String = "ALTER TABLE `riesgo_puesto` ADD PRIMARY KEY (`Id`);"
    Public varKeytipocontrato As String = "ALTER TABLE `tipo_jornada` ADD PRIMARY KEY (`Id`);"
    Public varKeytipojornada As String = "ALTER TABLE `tipo_jornada` ADD PRIMARY KEY (`Id`);"
    Public varKeyperiodicidadpago As String = "ALTER TABLE `periodicidad_pago` ADD PRIMARY KEY (`Id`);"
    Public varKeyregimencontrataciontrabajador As String = "ALTER TABLE `regimen_contratacion_trabajador` ADD PRIMARY KEY (`Id`);"
    Public varKeyhabitacion As String = "ALTER TABLE `habitacion` ADD PRIMARY KEY (`IdHabitacion`);"
    Public varKeydetallehotel As String = "ALTER TABLE `detallehotel` ADD PRIMARY KEY (`Id`);"
    Public varKeycontrolserviciodet As String = "ALTER TABLE `control_servicios_det` ADD PRIMARY KEY (`Id`);"
    Public varKeycontrolservicio As String = "ALTER TABLE `control_servicios` ADD PRIMARY KEY (`Id`);"
    Public varKeyrepcomandas As String = "ALTER TABLE `rep_comandas` ADD PRIMARY KEY (`IDC`);"
    Public varKeyticket As String = "ALTER TABLE `ticket` ADD PRIMARY KEY (`Id`);"
    Public varKeyrefaccionaria As String = "ALTER TABLE `refaccionaria` ADD PRIMARY KEY (`Id`);"
    Public varKeyvehiculo As String = "ALTER TABLE `vehiculo` ADD PRIMARY KEY (`IdVehiculo`);"
    Public varKeycomandasveh As String = "ALTER TABLE `comandasveh` ADD PRIMARY KEY (`Id`);"
    Public varKeypermisosm As String = "ALTER TABLE `permisosm` ADD PRIMARY KEY (`Id`);"
    Public varKeyvtaimpresion As String = "ALTER TABLE `vtaimpresion` ADD PRIMARY KEY (`Id`);"
    Public varKeypromociones As String = "ALTER TABLE `promociones` ADD PRIMARY KEY (`Id`);"
    Public varKeyextras As String = "ALTER TABLE `extras` ADD PRIMARY KEY (`Id`);"
    Public varKeyprefecia As String = "ALTER TABLE `preferencia` ADD PRIMARY KEY (`IdPrefe`);"
    Public varKeyhisasigpc As String = "ALTER TABLE `histasigpc` ADD PRIMARY KEY (`Id`);"
    Public varKeymesa As String = "ALTER TABLE `mesa` ADD PRIMARY KEY (`IdMesa`);"
    Public varKeyasigpc As String = "ALTER TABLE `asigpc` ADD PRIMARY KEY (`Id`);"
    Public varKeyalumnos As String = "ALTER TABLE `alumnos` ADD PRIMARY KEY (`Id`);"
    Public varKeyfechacobros As String = "ALTER TABLE `fechacobros` ADD PRIMARY KEY (`Id`);"
    Public varKeygrupos As String = "ALTER TABLE `grupos` ADD PRIMARY KEY (`Id`);"
    Public varKeymesasempleados As String = "ALTER TABLE `mesasxempleados` ADD PRIMARY KEY (`IdMesa`);"
    Public varKeycomandas1 As String = "ALTER TABLE `comanda1` ADD PRIMARY KEY (`Id`);"
    Public varKeycomandas As String = "ALTER TABLE `comandas` ADD PRIMARY KEY (`IDC`);"
    Public varKeycuentasbancarias As String = "ALTER TABLE `cuentasbancarias` ADD PRIMARY KEY (`Id`);"
    Public varKeyformaspago As String = "ALTER TABLE `formaspago` ADD PRIMARY KEY (`Id`);"
    Public varKeyparametros As String = "ALTER TABLE `parametros` ADD PRIMARY KEY (`Id`);"
    Public varKeyformatos As String = "ALTER TABLE `formatos` ADD PRIMARY KEY (`Id`);"
    Public varKeyabonoe As String = "ALTER TABLE `abonoe` ADD PRIMARY KEY (`Id`);"
    Public varKeyabonoi As String = "ALTER TABLE `abonoi` ADD PRIMARY KEY (`Id`);"
    Public varKeyacreedores As String = "ALTER TABLE `acreedores` ADD PRIMARY KEY (`IdAcreedor`);"
    Public varKeyasistencia As String = "ALTER TABLE `asistencia` ADD PRIMARY KEY (`Id`);"
    Public varKeyasistenciagym As String = "ALTER TABLE `asistenciagym` ADD PRIMARY KEY (`Id`);"
    Public varKeyauditoria As String = "ALTER TABLE `auditoria` ADD PRIMARY KEY (`Id`);"
    Public varKeyauxcompras As String = "ALTER TABLE `auxcompras` ADD PRIMARY KEY (`Id`);"
    Public varKeyauxcomprasseries As String = "ALTER TABLE `auxcomprasseries` ADD PRIMARY KEY (`Id`);"
    Public varKeyauxpedidos As String = "ALTER TABLE `auxpedidos` ADD PRIMARY KEY (`Id`);"
    Public varKeycardex As String = "ALTER TABLE `cardex` ADD PRIMARY KEY (`Id`);"
    Public varKeycartaporte As String = "ALTER TABLE `cartaporte` ADD PRIMARY KEY (`Id`);"
    Public varKeycartaportedet As String = "ALTER TABLE `cartaportedet` ADD PRIMARY KEY (`Id`);"
    Public varKeycartaportei As String = "ALTER TABLE `cartaportei` ADD PRIMARY KEY (`Id`);"
    Public varKeycartaportedeti As String = "ALTER TABLE `cartaportedeti` ADD PRIMARY KEY (`Id`);"
    Public varKeyclientes As String = "ALTER TABLE `clientes` ADD PRIMARY KEY (`Id`);"
    Public varKeycompras As String = "ALTER TABLE `compras` ADD PRIMARY KEY (`Id`);"
    Public varKeycomprasdet As String = "ALTER TABLE `comprasdet` ADD PRIMARY KEY (`Id`), ADD KEY `Id_Compra` (`Id_Compra`), ADD KEY `Folio` (`Id_Compra`);"
    Public varKeycortecaja As String = "ALTER TABLE `cortecaja` ADD PRIMARY KEY (`Id`);"
    Public varKeycorteusuario As String = "ALTER TABLE `corteusuario` ADD PRIMARY KEY (`Id`);"
    Public varKeycotped As String = "ALTER TABLE `cotped` ADD PRIMARY KEY (`Folio`);"
    Public varKeycotpeddet As String = "ALTER TABLE `cotpeddet` ADD PRIMARY KEY (`Id`);"
    Public varKeyctmedicos As String = "ALTER TABLE `ctmedicos` ADD PRIMARY KEY (`Id`);"
    Public varKeydatosnegocio As String = "ALTER TABLE `datosnegocio` ADD PRIMARY KEY (`Emisor_id`);"
    Public varKeydatosprosepago As String = "ALTER TABLE `datosprosepago` ADD PRIMARY KEY (`Id`);"
    Public varKeydeudores As String = "ALTER TABLE `deudores` ADD PRIMARY KEY (`IdDeudor`);"
    Public varKeydevoluciones As String = "ALTER TABLE `devoluciones` ADD PRIMARY KEY (`Id`);"
    Public varKeyentregas As String = "ALTER TABLE `entregas` ADD PRIMARY KEY (`Id`);"
    Public varKeyfacturas As String = "ALTER TABLE `facturas` ADD PRIMARY KEY (`nom_id`);"
    Public varKeyformapagosat As String = "ALTER TABLE `formapagosat` ADD PRIMARY KEY (`Id`);"
    Public varKeyimpuestosat As String = "ALTER TABLE `impuestosat` ADD PRIMARY KEY (`Id`);"
    Public varKeyiva As String = "ALTER TABLE `iva` ADD PRIMARY KEY (`Id`);"
    Public varKeyloginrecargas As String = "ALTER TABLE `loginrecargas` ADD PRIMARY KEY (`Id`);"
    Public varKeyliberacion As String = "ALTER TABLE `liberacion` ADD PRIMARY KEY (`Id`);"
    Public varKeylotecaducidad As String = "ALTER TABLE `lotecaducidad` ADD PRIMARY KEY (`Id`);"
    Public varKeymembresiasgym As String = "ALTER TABLE `membresiasgym` ADD PRIMARY KEY (`Id`);"
    Public varKeymerma As String = "ALTER TABLE `merma` ADD PRIMARY KEY (`Id`);"
    Public varKeymesessat As String = "ALTER TABLE `mesessat` ADD PRIMARY KEY (`iD`);"
    Public varKeymetodopagosat As String = "ALTER TABLE `metodopagosat` ADD PRIMARY KEY (`Id`);"
    Public varKeymodentregas As String = "ALTER TABLE `modentregas` ADD PRIMARY KEY (`Id`);"
    Public varKeymodentregasdet As String = "ALTER TABLE `modentregasdet` ADD PRIMARY KEY (`Id`);"
    Public varKeymodprecios As String = "ALTER TABLE `modprecios` ADD PRIMARY KEY (`Id`);"
    Public varKeymonedero As String = "ALTER TABLE `monedero` ADD PRIMARY KEY (`Id`);"
    Public varKeymovcuenta As String = "ALTER TABLE `movcuenta` ADD PRIMARY KEY (`Id`);"
    Public varKeymovmonedero As String = "ALTER TABLE `movmonedero` ADD PRIMARY KEY (`Id`);"
    Public varKeynomina As String = "ALTER TABLE `nomina` ADD PRIMARY KEY (`Id`);"
    Public varKeynota As String = "ALTER TABLE `nota` ADD PRIMARY KEY (`not_cve`);"
    Public varKeyotrosgastos As String = "ALTER TABLE `otrosgastos` ADD PRIMARY KEY (`Id`);"
    Public varKeyordentrabajo As String = "ALTER TABLE `ordentrabajo` ADD PRIMARY KEY (`Id`);"
    Public varKeyparcialidadesdetalle As String = "ALTER TABLE `parcialidadesdetalle` ADD PRIMARY KEY (`Id`);"
    Public varKeyparcialidadesdetallemulti As String = "ALTER TABLE `parcialidadesdetallemulti` ADD PRIMARY KEY (`Id`);"
    Public varKeyparcialidades As String = "ALTER TABLE `parcialidades` ADD PRIMARY KEY (`Id`);"
    Public varKeyparcialidadesmulti As String = "ALTER TABLE `parcialidadesmulti` ADD PRIMARY KEY (`Id`);"
    Public varKeypedidos As String = "ALTER TABLE `pedidos` ADD PRIMARY KEY (`Id`);"
    Public varKeypedidosdet As String = "ALTER TABLE `pedidosdet` ADD PRIMARY KEY (`Id`);"
    Public varKeypeps As String = "ALTER TABLE `costeo` ADD PRIMARY KEY (`Id`);"
    Public varKeyperiodicidadsat As String = "ALTER TABLE `periodicidadsat` ADD PRIMARY KEY (`Id`);"
    Public varKeypermisos As String = "ALTER TABLE `permisos` ADD PRIMARY KEY (`Id`);"
    Public varKeyproductos As String = "ALTER TABLE `productos` ADD PRIMARY KEY (`Id`);"
    Public varKeyporteclavestcc As String = "ALTER TABLE `porteclavestcc` ADD PRIMARY KEY (`Id`);"
    Public varKeyportecolonia As String = "ALTER TABLE `portecolonia` ADD PRIMARY KEY (`Id`);"
    Public varKeyporteconfigautotrans As String = "ALTER TABLE `porteconfigautotrans` ADD PRIMARY KEY (`Id`);"
    Public varKeyportedestino As String = "ALTER TABLE `portedestino` ADD PRIMARY KEY (`Id`);"
    Public varKeyporteestados As String = "ALTER TABLE `porteestados` ADD PRIMARY KEY (`Id`);"
    Public varKeyportefigura As String = "ALTER TABLE `portefigura` ADD PRIMARY KEY (`Id`);"
    Public varKeyportelocalidad As String = "ALTER TABLE `portelocalidad` ADD PRIMARY KEY (`Id`);"
    Public varKeyportematpeligrosos As String = "ALTER TABLE `portematpeligrosos` ADD PRIMARY KEY (`Id`);"
    Public varKeyportemercancia As String = "ALTER TABLE `portemercancia` ADD PRIMARY KEY (`Id`);"
    Public varKeyportemunicipios As String = "ALTER TABLE `portemunicipios` ADD PRIMARY KEY (`Id`);"
    Public varKeyporteoperador As String = "ALTER TABLE `porteoperador` ADD PRIMARY KEY (`Id`);"
    Public varKeyporteorigen As String = "ALTER TABLE `porteorigen` ADD PRIMARY KEY (`Id`);"
    Public varKeyportepais As String = "ALTER TABLE `portepais` ADD PRIMARY KEY (`Id`);"
    Public varKeyporteproducto As String = "ALTER TABLE `porteproducto` ADD PRIMARY KEY (`Id`);"
    Public varKeyporteproductosat As String = "ALTER TABLE `porteproductosat` ADD PRIMARY KEY (`Id`);"
    Public varKeyportepropietario As String = "ALTER TABLE `portepropietario` ADD PRIMARY KEY (`Id`);"
    Public varKeyportetipocarga As String = "ALTER TABLE `portetipocarga` ADD PRIMARY KEY (`Id`);"
    Public varKeyportetipocarro As String = "ALTER TABLE `portetipocarro` ADD PRIMARY KEY (`Id`);"
    Public varKeyportetipocontenedor As String = "ALTER TABLE `portetipocontenedor` ADD PRIMARY KEY (`Id`);"
    Public varKeyportetipoembalaje As String = "ALTER TABLE `portetipoembalaje` ADD PRIMARY KEY (`Id`);"
    Public varKeyportetipopermiso As String = "ALTER TABLE `portetipopermiso` ADD PRIMARY KEY (`Id`);"
    Public varKeyportetiporemolque As String = "ALTER TABLE `portetiporemolque` ADD PRIMARY KEY (`Id`);"
    Public varKeyportetransporte As String = "ALTER TABLE `portetransporte` ADD PRIMARY KEY (`Id`);"
    Public varKeyporteunidadmedemb As String = "ALTER TABLE `porteunidadmedemb` ADD PRIMARY KEY (`Id`);"
    Public varKeyprocesos_prod As String = "ALTER TABLE `procesos_prod` ADD PRIMARY KEY (`Id`);"
    Public varKeyproveedores As String = "ALTER TABLE `proveedores` ADD PRIMARY KEY (`Id`);"
    Public varKeyrecargas As String = "ALTER TABLE `recargas` ADD PRIMARY KEY (`Id`);"
    Public varKeyrep_antib As String = "ALTER TABLE `rep_antib` ADD PRIMARY KEY (`Id`);"
    Public varKeyrutasimpresion As String = "ALTER TABLE `rutasimpresion` ADD PRIMARY KEY (`Id`);"
    Public varKeysaldosempleados As String = "ALTER TABLE `saldosempleados` ADD PRIMARY KEY (`Id`);"
    Public varKeyseries As String = "ALTER TABLE `series` ADD PRIMARY KEY (`Id`);"
    Public varKeyservicios As String = "ALTER TABLE `servicios` ADD PRIMARY KEY (`Id`);"
    Public varKeytalmacen As String = "ALTER TABLE `talmacen` ADD PRIMARY KEY (`IDTAlmacen`);"
    Public varKeytb_moneda As String = "ALTER TABLE `tb_moneda` ADD PRIMARY KEY (`Id`);"
    Public varKeytipofactorsat As String = "ALTER TABLE `tipofactorsat` ADD PRIMARY KEY (`Id`);"
    Public varKeytiposcomprobantesat As String = "ALTER TABLE `tiposcomprobantesat` ADD PRIMARY KEY (`Id`);"
    Public varKeytiprelacioncfdisat As String = "ALTER TABLE `tiprelacioncfdisat` ADD PRIMARY KEY (`Id`);"
    Public varKeytransporte As String = "ALTER TABLE `transporte` ADD PRIMARY KEY (`Id`);"
    Public varKeytraslados As String = "ALTER TABLE `traslados` ADD PRIMARY KEY (`Id`);"
    Public varKeytrasladosdet As String = "ALTER TABLE `trasladosdet` ADD PRIMARY KEY (`Id`);"
    Public varKeyumtblcfds As String = "ALTER TABLE `umtblcfds` ADD PRIMARY KEY (`idCFDi`);"
    Public varKeyusocomprocfdisat As String = "ALTER TABLE `usocomprocfdisat` ADD PRIMARY KEY (`Id`);"
    Public varKeyusuarios As String = "ALTER TABLE `usuarios` ADD PRIMARY KEY (`IdEmpleado`);"
    Public varKeyuuidrelacion As String = "ALTER TABLE `uuidrelacion` ADD PRIMARY KEY (`Id`);"
    Public varKeyventas As String = "ALTER TABLE `ventas` ADD PRIMARY KEY (`Folio`);"
    Public varKeyventasdetalle As String = "ALTER TABLE `ventasdetalle` ADD PRIMARY KEY (`Id`), ADD KEY `Folio` (`Folio`);"
    Public varKeycomandas_t As String = "ALTER TABLE `comandas_t` ADD PRIMARY KEY (`Id`);"
    Public varKeypreciosrango As String = "ALTER TABLE `precios_rango` ADD PRIMARY KEY (`Id`);"

    '/////////////////////////////////////////////////////////////////////////
    'AUTOINCREMENTO
    '/////////////////////////////////////////////////////////////////////////
    Public varAutoprecios As String = "ALTER TABLE `precios` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomarcas As String = "ALTER TABLE `marcas` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutovehiuclo2 As String = "ALTER TABLE `vehiculo2` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutonominass As String = "ALTER TABLE `nominas` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopedidosvendet As String = "ALTER TABLE `pedidosvendet` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopedidosven As String = "ALTER TABLE `pedidosven` MODIFY `Folio` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutodetallehotelprecios As String = "ALTER TABLE `detallehotelprecios` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopromos As String = "ALTER TABLE `promos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoclienteeliminado As String = "ALTER TABLE `clienteeliminado` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoproductoeliminado As String = "ALTER TABLE `productoeliminado` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopedidostemporal As String = "ALTER TABLE `pedidostemporal` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopedidoeliminado As String = "ALTER TABLE `pedidoeliminado` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutodetallenomina As String = "ALTER TABLE `detalle_nomina` MODIFY `Id_detalle` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopreciosrango As String = "ALTER TABLE `precios_rango` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotipoincapacidadsat As String = "ALTER TABLE `tipoincapacidadsat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotiponomina As String = "ALTER TABLE `tiponomina` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutootrospagos As String = "ALTER TABLE `otrospagos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotipopercepcioncontable As String = "ALTER TABLE `tipo_percepcion_contable` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotipodeduccioncontable As String = "ALTER TABLE `tipo_deduccion_contable` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoriesgopuesto As String = "ALTER TABLE `riesgo_puesto` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotipocontrato As String = "ALTER TABLE `tipo_jornada` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotipojornada As String = "ALTER TABLE `tipo_jornada` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoperiodicidadpago As String = "ALTER TABLE `periodicidad_pago` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoregimencontrataciontrabajador As String = "ALTER TABLE `regimen_contratacion_trabajador` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutohabitacion As String = "ALTER TABLE `habitacion` MODIFY `IdHabitacion` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutodetallehotel As String = "ALTER TABLE `detallehotel` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocontrolserviciodet As String = "ALTER TABLE `control_servicios_det` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocontrolservicio As String = "ALTER TABLE `control_servicios` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutorepcomandas As String = "ALTER TABLE `rep_comandas` MODIFY `IDC` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoticket As String = "ALTER TABLE `ticket` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutorefaccionaria As String = "ALTER TABLE `refaccionaria` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutovehiculo As String = "ALTER TABLE `vehiculo` MODIFY `IdVehiculo` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocomandasveh As String = "ALTER TABLE `comandasveh` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopermisosm As String = "ALTER TABLE `permisosm` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutovtaimpresion As String = "ALTER TABLE `vtaimpresion` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopromociones As String = "ALTER TABLE `promociones` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoextras As String = "ALTER TABLE `extras` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopreferencias As String = "ALTER TABLE `preferencia` MODIFY `IdPrefe` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutohisasigpc As String = "ALTER TABLE `histasigpc` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomesa As String = "ALTER TABLE `mesa` MODIFY `IdMesa` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoasigpc As String = "ALTER TABLE `asigpc` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoalumnos As String = "ALTER TABLE `alumnos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutofechacobros As String = "ALTER TABLE `fechacobros` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutogrupos As String = "ALTER TABLE `grupos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomesasempleados As String = "ALTER TABLE `mesasxempleados` MODIFY `IdMesa` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocomandas_t As String = "ALTER TABLE `comandas_t` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"

    Public varAutocomandas1 As String = "ALTER TABLE `comanda1` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocomandas As String = "ALTER TABLE `comandas` MODIFY `IDC` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocuentasbancarias As String = "ALTER TABLE `cuentasbancarias` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoformapagos As String = "ALTER TABLE `formaspago` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoformatos As String = "ALTER TABLE `formatos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoabonoe As String = "ALTER TABLE `abonoe` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoabonoi As String = "ALTER TABLE `abonoi` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoacreedores As String = "ALTER TABLE `acreedores` MODIFY `IdAcreedor` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoasistencia As String = "ALTER TABLE `asistencia` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoasistenciagym As String = "ALTER TABLE `asistenciagym` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoauditoria As String = "ALTER TABLE `auditoria` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoauxcompras As String = "ALTER TABLE `auxcompras` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoauxcomprasseries As String = "ALTER TABLE `auxcomprasseriesg` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoauxpedidos As String = "ALTER TABLE `auxpedidos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocardex As String = "ALTER TABLE `cardex` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocartaportedet As String = "ALTER TABLE `cartaportedet` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocartaporte As String = "ALTER TABLE `cartaporte` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocartaportei As String = "ALTER TABLE `cartaportei` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocartaportedeti As String = "ALTER TABLE `cartaportedeti` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoclientes As String = "ALTER TABLE `clientes` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocompras As String = "ALTER TABLE `compras` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocomprasdet As String = "ALTER TABLE `comprasdet` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocortecaja As String = "ALTER TABLE `cortecaja` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocorteusuario As String = "ALTER TABLE `corteusuario` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocotped As String = "ALTER TABLE `cotped` MODIFY `Folio` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutocotpeddet As String = "ALTER TABLE `cotpeddet` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoctmedicos As String = "ALTER TABLE `ctmedicos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutodatosnegocio As String = "ALTER TABLE `datosnegocio` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutodatosprosepago As String = "ALTER TABLE `datosprosepago` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutodeudores As String = "ALTER TABLE `deudores` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutodevoluciones As String = "ALTER TABLE `devoluciones` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoentregas As String = "ALTER TABLE `entregas` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutofacturas As String = "ALTER TABLE `facturas` MODIFY `nom_id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoformapagosat As String = "ALTER TABLE `formapagosat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;"
    Public varAutoimpuestosat As String = "ALTER TABLE `impuestosat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;"
    Public varAutoiva As String = "ALTER TABLE `iva` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;;"
    Public varAutologinrecargas As String = "ALTER TABLE `loginrecargas` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoliberacion As String = "ALTER TABLE `liberacion` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutolotecaducidad As String = "ALTER TABLE `lotecaducidad` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomembresiasgym As String = "ALTER TABLE `membresiasgym` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomerma As String = "ALTER TABLE `merma` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomesessat As String = "ALTER TABLE `mesessat` MODIFY `iD` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;"
    Public varAutometodopagosat As String = "ALTER TABLE `metodopagosat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;"
    Public varAutomodentregas As String = "ALTER TABLE `modentregas` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomodentregasdet As String = "ALTER TABLE `modentregasdet` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomodprecios As String = "ALTER TABLE `modprecios` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomonedero As String = "ALTER TABLE `monedero` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomovcuenta As String = "ALTER TABLE `movcuenta` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutomovmonedero As String = "ALTER TABLE `movmonedero` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutonomina As String = "ALTER TABLE `nomina` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutonota As String = "ALTER TABLE `nota` MODIFY `not_cve` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutootrosgastos As String = "ALTER TABLE `otrosgastos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoordentrabajo As String = "ALTER TABLE `ordentrabajo` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoparcialidades As String = "ALTER TABLE `parcialidades` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoparcialidadesmulti As String = "ALTER TABLE `parcialidadesmulti` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoparcialidadesdetalle As String = "ALTER TABLE `parcialidadesdetalle` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoparcialidadesdetallemulti As String = "ALTER TABLE `parcialidadesdetallemulti` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopedidos As String = "ALTER TABLE `pedidos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopedidosdet As String = "ALTER TABLE `pedidosdet` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutopeps As String = "ALTER TABLE `costeo` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoperiodicidadsat As String = "ALTER TABLE `periodicidadsat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;"
    Public varAutopermisos As String = "ALTER TABLE `permisos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;"
    Public varAutoporteclavestcc As String = "ALTER TABLE `porteclavestcc` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=466;"
    Public varAutoportecolonia As String = "ALTER TABLE `portecolonia` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoporteconfigautotrans As String = "ALTER TABLE `porteconfigautotrans` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;"
    Public varAutoportedestino As String = "ALTER TABLE `portedestino` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoporteestados As String = "ALTER TABLE `porteestados` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=96;"
    Public varAutoportefigura As String = "ALTER TABLE `portefigura` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;"
    Public varAutoportelocalidad As String = "ALTER TABLE `portelocalidad` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoportematpeligrosos As String = "ALTER TABLE `portematpeligrosos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2347;"
    Public varAutoportemercancia As String = "ALTER TABLE `portemercancia` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2347;"
    Public varAutoportemunicipios As String = "ALTER TABLE `portemunicipios` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoporteoperador As String = "ALTER TABLE `porteoperador` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoporteorigen As String = "ALTER TABLE `porteorigen` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoportepais As String = "ALTER TABLE `portepais` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoporteproducto As String = "ALTER TABLE `porteproducto` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoporteproductosat As String = "ALTER TABLE `porteproductosat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoportepropietario As String = "ALTER TABLE `portepropietario` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoportetipocarga As String = "ALTER TABLE `portetipocarga` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;"
    Public varAutoportetipocarro As String = "ALTER TABLE `portetipocarro` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;"
    Public varAutoportetipocontenedor As String = "ALTER TABLE `portetipocontenedor` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoportetipoembalaje As String = "ALTER TABLE `portetipoembalaje` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoportetipopermiso As String = "ALTER TABLE `portetipopermiso` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoportetiporemolque As String = "ALTER TABLE `portetiporemolque` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoportetransporte As String = "ALTER TABLE `portetransporte` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;"
    Public varAutoporteunidadmedemb As String = "ALTER TABLE `porteunidadmedemb` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoprocesos_prod As String = "ALTER TABLE `procesos_prod` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoproveedores As String = "ALTER TABLE `proveedores` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutorecargas As String = "ALTER TABLE `recargas` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutorep_antib As String = "ALTER TABLE `rep_antib` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutorutasimpresion As String = "ALTER TABLE `rutasimpresion` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutosaldosempleados As String = "ALTER TABLE `saldosempleados` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoseries As String = "ALTER TABLE `series` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoservicios As String = "ALTER TABLE `servicios` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotalmacen As String = "ALTER TABLE `talmacen` MODIFY `IDTAlmacen` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotb_moneda As String = "ALTER TABLE `tb_moneda` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotipofactorsat As String = "ALTER TABLE `tipofactorsat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotiposcomprobantesat As String = "ALTER TABLE `tiposcomprobantesat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;"
    Public varAutotiprelacioncfdisat As String = "ALTER TABLE `tiprelacioncfdisat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;"
    Public varAutotransporte As String = "ALTER TABLE `transporte` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotraslados As String = "ALTER TABLE `traslados` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutotrasladosdet As String = "ALTER TABLE `trasladosdet` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoumtblcfds As String = "ALTER TABLE `umtblcfds` MODIFY `idCFDi` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutousocomprocfdisat As String = "ALTER TABLE `usocomprocfdisat` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;"
    Public varAutousuarios As String = "ALTER TABLE `usuarios` MODIFY `IdEmpleado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;"
    Public varAutouuidrelacion As String = "ALTER TABLE `uuidrelacion` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoventas As String = "ALTER TABLE `ventas` MODIFY `Folio` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoventasdetalle As String = "ALTER TABLE `ventasdetalle` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    Public varAutoproductos As String = "ALTER TABLE `productos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;"
    '/////////////////////////////////////////////////////////////////////////
    'Foreign key
    '/////////////////////////////////////////////////////////////////////////

    Public varForKcomprasdet As String = "ALTER TABLE `comprasdet` ADD CONSTRAINT `comprasdet_ibfk_1` FOREIGN KEY (`Id_Compra`) REFERENCES `compras` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;"
    Public varForKventasdetalle As String = "ALTER TABLE `ventasdetalle` ADD CONSTRAINT `ventasdetalle_ibfk_1` FOREIGN KEY (`Folio`) REFERENCES `ventas` (`Folio`);"

End Module
