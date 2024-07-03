using System;
using MySql.Data.MySqlClient;

namespace final1

{
    class Program
    {
        static string connectionString = "server=localhost;database=final;user=root;password='';";
        MySqlConnection conectado = new MySqlConnection(connectionString);
        static void Main(string[] args)
        {
            Console.WriteLine("Conexión exitosa a la base de datos.");
            while (true)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1 - Trabajar con Clientes");
                Console.WriteLine("2 - Trabajar con Facturas");
                Console.WriteLine("3 - Trabajar con Sucursales");
                Console.WriteLine("4 - Trabajar con Pedidos");
                Console.WriteLine("5 - Trabajar con Productos");
                Console.WriteLine("6 - Trabajar con Proveedores");
                Console.WriteLine("7 - Trabajar con Detalles de Pedido");
                Console.WriteLine("8 - Salir");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuClientes();
                        break;
                    case "2":
                        MenuFacturas();
                        break;
                    case "3":
                        MenuSucursales();
                        break;
                    case "4":
                        MenuPedidos();
                        break;
                    case "5":
                        MenuProductos();
                        break;
                    case "6":
                        MenuProveedores();
                        break;
                    case "7":
                        MenuDetallesPedido();
                        break;
                    case "8":
                      return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void MenuClientes()
        {
            while (true)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1 - Insertar Datos");
                Console.WriteLine("2 - Listar Datos");
                Console.WriteLine("3 - Modificar Datos");
                Console.WriteLine("4 - Eliminar Datos");
                Console.WriteLine("0 - Volver atrás");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarCliente();
                        break;
                    case "2":
                        ListarClientes();
                        break;
                    case "3":
                        ModificarCliente();
                        break;
                    case "4":
                        EliminarCliente();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void InsertarCliente()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 3)
            {
                Console.WriteLine("El nombre es obligatorio y debe tener al menos 3 caracteres.");
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
            }

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(apellido) || apellido.Length < 3)
            {
                Console.WriteLine("El apellido es obligatorio y debe tener al menos 3 caracteres.");
                Console.Write("Apellido: ");
                apellido = Console.ReadLine();
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Clientes (Nombre, Apellido, Email) VALUES (@Nombre, @Apellido, @Email)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Cliente insertado con éxito.");
        }

        static void ListarClientes()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Clientes";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ClienteId: {reader["ClienteId"]}, Nombre: {reader["Nombre"]}, Apellido: {reader["Apellido"]}, Email: {reader["Email"]}");
                    }
                }
            }
        }

        static void ModificarCliente()
        {
            Console.Write("ID del Cliente a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nuevo Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Nuevo Email: ");
            string email = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email WHERE ClienteId = @ClienteId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@ClienteId", id);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Cliente modificado con éxito.");
        }

        static void EliminarCliente()
        {
            Console.Write("ID del Cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Clientes WHERE ClienteId = @ClienteId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", id);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Cliente eliminado con éxito.");
        }

        static void MenuFacturas()
        {
            while (true)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1 - Insertar Datos");
                Console.WriteLine("2 - Listar Datos");
                Console.WriteLine("3 - Modificar Datos");
                Console.WriteLine("4 - Eliminar Datos");
                Console.WriteLine("0 - Volver atrás");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarFactura();
                        break;
                    case "2":
                        ListarFacturas();
                        break;
                    case "3":
                        ModificarFactura();
                        break;
                    case "4":
                        EliminarFactura();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void InsertarFactura()
        {
            Console.Write("ID del Cliente: ");
            int clienteID = int.Parse(Console.ReadLine());
            Console.Write("Fecha (YYYY-MM-DD): ");
            string fecha = Console.ReadLine();
            Console.Write("Monto: ");
            decimal monto = decimal.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Facturas (ClienteID, Fecha, Monto) VALUES (@ClienteID, @Fecha, @Monto)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Monto", monto);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Factura insertada con éxito.");
        }

        static void ListarFacturas()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Facturas";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"FacturaId: {reader["FacturaId"]}, ClienteID: {reader["ClienteID"]}, Fecha: {reader["Fecha"]}, Monto: {reader["Monto"]}");
                    }
                }
            }
        }

        static void ModificarFactura()
        {
            Console.Write("ID de la Factura a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo ClienteID: ");
            int clienteID = int.Parse(Console.ReadLine());
            Console.Write("Nueva Fecha (YYYY-MM-DD): ");
            string fecha = Console.ReadLine();
            Console.Write("Nuevo Monto: ");
            decimal monto = decimal.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Facturas SET ClienteID = @ClienteID, Fecha = @Fecha, Monto = @Monto WHERE FacturaId = @FacturaId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Monto", monto);
                    cmd.Parameters.AddWithValue("@FacturaId", id);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Factura modificada con éxito.");
        }

        static void EliminarFactura()
        {
            Console.Write("ID de la Factura a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Facturas WHERE FacturaId = @FacturaId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FacturaId", id);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Factura eliminada con éxito.");
        }

        static void MenuSucursales()
        {
            while (true)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1 - Insertar Datos");
                Console.WriteLine("2 - Listar Datos");
                Console.WriteLine("3 - Modificar Datos");
                Console.WriteLine("4 - Eliminar Datos");
                Console.WriteLine("0 - Volver atrás");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarSucursal();
                        break;
                    case "2":
                        ListarSucursales();
                        break;
                    case "3":
                        ModificarSucursal();
                        break;
                    case "4":
                        EliminarSucursal();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void InsertarSucursal()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ubicación: ");
            string ubicacion = Console.ReadLine();
            while (ubicacion.Length < 10)
            {
                Console.WriteLine("La dirección debe tener al menos 10 caracteres.");
                Console.Write("Ubicación: ");
                ubicacion = Console.ReadLine();
            }
            Console.Write("Email: ");
            string mail = Console.ReadLine();
            while (!mail.Contains("@") || !mail.Contains(".") || mail.IndexOf('@') > mail.LastIndexOf('.'))
            {
                Console.WriteLine("El email debe ser válido (contener '@' y un punto después del '@').");
                Console.Write("Email: ");
                mail = Console.ReadLine();
            }
            Console.Write("Estado (activo = 1, inactivo = 0): ");
            bool estado = Console.ReadLine() == "1";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Sucursales (Nombre, Ubicacion, Mail, Estado) VALUES (@Nombre, @Ubicacion, @Mail, @Estado)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Ubicacion", ubicacion);
                    cmd.Parameters.AddWithValue("@Mail", mail);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Sucursal insertada con éxito.");
            }
        }

        static void ListarSucursales()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Sucursales";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"SucursalId: {reader["SucursalId"]}, Nombre: {reader["Nombre"]}, Ubicación: {reader["Ubicacion"]}");
                    }
                }
            }
        }

        static void ModificarSucursal()
        {
            Console.Write("ID de la Sucursal a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nueva Ubicación: ");
            string ubicacion = Console.ReadLine();
            while (ubicacion.Length < 10)
            {
                Console.WriteLine("La dirección debe tener al menos 10 caracteres.");
                Console.Write("Nueva Ubicación: ");
                ubicacion = Console.ReadLine();
            }
            Console.Write("Nuevo Email: ");
            string mail = Console.ReadLine();
            while (!mail.Contains("@") || !mail.Contains(".") || mail.IndexOf('@') > mail.LastIndexOf('.'))
            {
                Console.WriteLine("El email debe ser válido (contener '@' y un punto después del '@').");
                Console.Write("Nuevo Email: ");
                mail = Console.ReadLine();
            }
            Console.Write("Estado (activo = 1, inactivo = 0): ");
            bool estado = Console.ReadLine() == "1";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Sucursales SET Nombre = @Nombre, Ubicacion = @Ubicacion, Mail = @Mail, Estado = @Estado WHERE SucursalId = @SucursalId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SucursalId", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Ubicacion", ubicacion);
                    cmd.Parameters.AddWithValue("@Mail", mail);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Sucursal modificada con éxito.");
            }
        }


        static void EliminarSucursal()
        {
            Console.Write("ID de la Sucursal a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Sucursales WHERE SucursalId = @SucursalId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SucursalId", id);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Sucursal eliminada con éxito.");
        }
        static void MenuPedidos()
        {
            while (true)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1 - Insertar Datos");
                Console.WriteLine("2 - Listar Datos");
                Console.WriteLine("3 - Modificar Datos");
                Console.WriteLine("4 - Eliminar Datos");
                Console.WriteLine("0 - Volver atrás");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarPedido();
                        break;
                    case "2":
                        ListarPedidos();
                        break;
                    case "3":
                        ModificarPedido();
                        break;
                    case "4":
                        EliminarPedido();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void InsertarPedido()
        {
            Console.Write("ID del Proveedor: ");
            int proveedorID = int.Parse(Console.ReadLine());
            Console.Write("ID de la Sucursal: ");
            int sucursalID = int.Parse(Console.ReadLine());
            Console.Write("Fecha (YYYY-MM-DD HH:MM:SS): ");
            string fecha = Console.ReadLine();
            Console.Write("Total: ");
            decimal total = decimal.Parse(Console.ReadLine());

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Pedido_Compra (Id_Proveedor, Id_Sucursal, Fecha_Hora, Total) VALUES (@Id_Proveedor, @Id_Sucursal, @Fecha_Hora, @Total)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id_Proveedor", proveedorID);
                        cmd.Parameters.AddWithValue("@Id_Sucursal", sucursalID);
                        cmd.Parameters.AddWithValue("@Fecha_Hora", fecha);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Pedido insertado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar pedido: {ex.Message}");
            }
        }

        static void ListarPedidos()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Pedido_Compra";
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"PedidoId: {reader["Id"]}, ProveedorId: {reader["Id_Proveedor"]}, SucursalId: {reader["Id_Sucursal"]}, Fecha: {reader["Fecha_Hora"]}, Total: {reader["Total"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar pedidos: {ex.Message}");
            }
        }

        static void ModificarPedido()
        {
            Console.Write("ID del Pedido a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo ID del Proveedor: ");
            int proveedorID = int.Parse(Console.ReadLine());
            Console.Write("Nuevo ID de la Sucursal: ");
            int sucursalID = int.Parse(Console.ReadLine());
            Console.Write("Nueva Fecha (YYYY-MM-DD HH:MM:SS): ");
            string fecha = Console.ReadLine();
            Console.Write("Nuevo Total: ");
            decimal total = decimal.Parse(Console.ReadLine());

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Pedido_Compra SET Id_Proveedor = @Id_Proveedor, Id_Sucursal = @Id_Sucursal, Fecha_Hora = @Fecha_Hora, Total = @Total WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Id_Proveedor", proveedorID);
                        cmd.Parameters.AddWithValue("@Id_Sucursal", sucursalID);
                        cmd.Parameters.AddWithValue("@Fecha_Hora", fecha);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Pedido modificado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar pedido: {ex.Message}");
            }
        }

        static void EliminarPedido()
        {
            Console.Write("ID del Pedido a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Pedido_Compra WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Pedido eliminado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar pedido: {ex.Message}");
            }
        }
        static void MenuProductos()
        {
            while (true)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1 - Insertar Datos");
                Console.WriteLine("2 - Listar Datos");
                Console.WriteLine("3 - Modificar Datos");
                Console.WriteLine("4 - Eliminar Datos");
                Console.WriteLine("0 - Volver atrás");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarProducto();
                        break;
                    case "2":
                        ListarProductos();
                        break;
                    case "3":
                        ModificarProducto();
                        break;
                    case "4":
                        EliminarProducto();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void InsertarProducto()
        {
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();
            while (string.IsNullOrEmpty(descripcion))
            {
                Console.WriteLine("La descripción es obligatoria.");
                Console.Write("Descripción: ");
                descripcion = Console.ReadLine();
            }

            Console.Write("Cantidad Mínima: ");
            int cantidadMinima = int.Parse(Console.ReadLine());
            while (cantidadMinima <= 1)
            {
                Console.WriteLine("La cantidad mínima debe ser mayor a 1.");
                Console.Write("Cantidad Mínima: ");
                cantidadMinima = int.Parse(Console.ReadLine());
            }

            Console.Write("Precio de Compra: ");
            decimal precioCompra = decimal.Parse(Console.ReadLine());
            while (precioCompra <= 0)
            {
                Console.WriteLine("El precio de compra debe ser un número positivo.");
                Console.Write("Precio de Compra: ");
                precioCompra = decimal.Parse(Console.ReadLine());
            }

            Console.Write("Precio de Venta: ");
            decimal precioVenta = decimal.Parse(Console.ReadLine());
            while (precioVenta <= 0)
            {
                Console.WriteLine("El precio de venta debe ser un número positivo.");
                Console.Write("Precio de Venta: ");
                precioVenta = decimal.Parse(Console.ReadLine());
            }

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine();
            Console.Write("Marca: ");
            string marca = Console.ReadLine();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Productos (Descripcion, Cantidad_minima, Precio_compra, Precio_venta, Categoria, Marca) VALUES (@Descripcion, @Cantidad_minima, @Precio_compra, @Precio_venta, @Categoria, @Marca)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Cantidad_minima", cantidadMinima);
                    cmd.Parameters.AddWithValue("@Precio_compra", precioCompra);
                    cmd.Parameters.AddWithValue("@Precio_venta", precioVenta);
                    cmd.Parameters.AddWithValue("@Categoria", categoria);
                    cmd.Parameters.AddWithValue("@Marca", marca);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Producto insertado con éxito.");
            }
        }


        static void ListarProductos()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Productos";
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ProductoId: {reader["Id"]}, Descripción: {reader["Descripcion"]}, Cantidad Mínima: {reader["Cantidad_minima"]}, Precio de Compra: {reader["Precio_compra"]}, Precio de Venta: {reader["Precio_venta"]}, Categoría: {reader["Categoria"]}, Marca: {reader["Marca"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar productos: {ex.Message}");
            }
        }

        static void ModificarProducto()
        {
            Console.Write("ID del Producto a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nueva Descripción: ");
            string descripcion = Console.ReadLine();
            while (string.IsNullOrEmpty(descripcion))
            {
                Console.WriteLine("La descripción es obligatoria.");
                Console.Write("Nueva Descripción: ");
                descripcion = Console.ReadLine();
            }

            Console.Write("Nueva Cantidad Mínima: ");
            int cantidadMinima = int.Parse(Console.ReadLine());
            while (cantidadMinima <= 1)
            {
                Console.WriteLine("La cantidad mínima debe ser mayor a 1.");
                Console.Write("Nueva Cantidad Mínima: ");
                cantidadMinima = int.Parse(Console.ReadLine());
            }

            Console.Write("Nuevo Precio de Compra: ");
            decimal precioCompra = decimal.Parse(Console.ReadLine());
            while (precioCompra <= 0)
            {
                Console.WriteLine("El precio de compra debe ser un número positivo.");
                Console.Write("Nuevo Precio de Compra: ");
                precioCompra = decimal.Parse(Console.ReadLine());
            }

            Console.Write("Nuevo Precio de Venta: ");
            decimal precioVenta = decimal.Parse(Console.ReadLine());
            while (precioVenta <= 0)
            {
                Console.WriteLine("El precio de venta debe ser un número positivo.");
                Console.Write("Nuevo Precio de Venta: ");
                precioVenta = decimal.Parse(Console.ReadLine());
            }

            Console.Write("Nueva Categoría: ");
            string categoria = Console.ReadLine();
            Console.Write("Nueva Marca: ");
            string marca = Console.ReadLine();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Productos SET Descripcion = @Descripcion, Cantidad_minima = @Cantidad_minima, Precio_compra = @Precio_compra, Precio_venta = @Precio_venta, Categoria = @Categoria, Marca = @Marca WHERE Id = @Id";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Cantidad_minima", cantidadMinima);
                    cmd.Parameters.AddWithValue("@Precio_compra", precioCompra);
                    cmd.Parameters.AddWithValue("@Precio_venta", precioVenta);
                    cmd.Parameters.AddWithValue("@Categoria", categoria);
                    cmd.Parameters.AddWithValue("@Marca", marca);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Producto modificado con éxito.");
            }
        }


        static void EliminarProducto()
        {
            Console.Write("ID del Producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Productos WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Producto eliminado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto: {ex.Message}");
            }
        }
        static void MenuDetallesPedido()
        {
            while (true)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1 - Insertar Detalle de Pedido");
                Console.WriteLine("2 - Listar Detalles de Pedido");
                Console.WriteLine("3 - Modificar Detalle de Pedido");
                Console.WriteLine("4 - Eliminar Detalle de Pedido");
                Console.WriteLine("0 - Volver atrás");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarDetallePedido();
                        break;
                    case "2":
                        ListarDetallesPedido();
                        break;
                    case "3":
                        ModificarDetallePedido();
                        break;
                    case "4":
                        EliminarDetallePedido();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void InsertarDetallePedido()
        {
            Console.Write("ID del Pedido: ");
            int pedidoId = int.Parse(Console.ReadLine());
            Console.Write("ID del Producto: ");
            int productoId = int.Parse(Console.ReadLine());
            Console.Write("Cantidad del Producto: ");
            int cantidadProducto = int.Parse(Console.ReadLine());
            Console.Write("Subtotal: ");
            decimal subtotal = decimal.Parse(Console.ReadLine());

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Detalle_Pedido (Id_pedido, Id_Producto, Cantidad_producto, Subtotal) VALUES (@Id_pedido, @Id_Producto, @Cantidad_producto, @Subtotal)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id_pedido", pedidoId);
                        cmd.Parameters.AddWithValue("@Id_Producto", productoId);
                        cmd.Parameters.AddWithValue("@Cantidad_producto", cantidadProducto);
                        cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Detalle del pedido insertado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar detalle del pedido: {ex.Message}");
            }
        }

        static void ListarDetallesPedido()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Detalle_Pedido";
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"DetalleId: {reader["Id"]}, PedidoId: {reader["Id_pedido"]}, ProductoId: {reader["Id_Producto"]}, Cantidad: {reader["Cantidad_producto"]}, Subtotal: {reader["Subtotal"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar detalles de pedidos: {ex.Message}");
            }
        }
        static void ModificarDetallePedido()
        {
            Console.Write("ID del Detalle de Pedido a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo ID del Pedido: ");
            int pedidoId = int.Parse(Console.ReadLine());
            Console.Write("Nuevo ID del Producto: ");
            int productoId = int.Parse(Console.ReadLine());
            Console.Write("Nueva Cantidad del Producto: ");
            int cantidadProducto = int.Parse(Console.ReadLine());
            Console.Write("Nuevo Subtotal: ");
            decimal subtotal = decimal.Parse(Console.ReadLine());

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Detalle_Pedido SET Id_pedido = @Id_pedido, Id_Producto = @Id_Producto, Cantidad_producto = @Cantidad_producto, Subtotal = @Subtotal WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Id_pedido", pedidoId);
                        cmd.Parameters.AddWithValue("@Id_Producto", productoId);
                        cmd.Parameters.AddWithValue("@Cantidad_producto", cantidadProducto);
                        cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Detalle del pedido modificado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar detalle del pedido: {ex.Message}");
            }
        }
        static void EliminarDetallePedido()
        {
            Console.Write("ID del Detalle de Pedido a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Detalle_Pedido WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Detalle del pedido eliminado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar detalle del pedido: {ex.Message}");
            }
        }
        static void MenuProveedores()
        {
            while (true)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1 - Insertar Proveedor");
                Console.WriteLine("2 - Listar Proveedores");
                Console.WriteLine("3 - Modificar Proveedor");
                Console.WriteLine("4 - Eliminar Proveedor");
                Console.WriteLine("0 - Volver atrás");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarProveedor();
                        break;
                    case "2":
                        ListarProveedores();
                        break;
                    case "3":
                        ModificarProveedor();
                        break;
                    case "4":
                        EliminarProveedor();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
        static void InsertarProveedor()
        {
            Console.Write("Razón Social: ");
            string razonSocial = Console.ReadLine();
            Console.Write("Tipo de Documento: ");
            string tipoDocumento = Console.ReadLine();
            Console.Write("Número de Documento: ");
            string numeroDocumento = Console.ReadLine();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Email: ");
            string mail = Console.ReadLine();
            Console.Write("Celular: ");
            string celular = Console.ReadLine();
            Console.Write("Estado (activo = 1, inactivo = 0): ");
            bool estado = Console.ReadLine() == "1";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Proveedor (RazonSocial, TipoDocumento, NumeroDocumento, Direccion, Mail, Celular, Estado) VALUES (@RazonSocial, @TipoDocumento, @NumeroDocumento, @Direccion, @Mail, @Celular, @Estado)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@RazonSocial", razonSocial);
                    cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Mail", mail);
                    cmd.Parameters.AddWithValue("@Celular", celular);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Proveedor insertado con éxito.");
            }
        }
        static void ListarProveedores()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Proveedor";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Razón Social: {reader["RazonSocial"]}, Tipo Documento: {reader["TipoDocumento"]}, Número Documento: {reader["NumeroDocumento"]}, Dirección: {reader["Direccion"]}, Email: {reader["Mail"]}, Celular: {reader["Celular"]}, Estado: {reader["Estado"]}");
                    }
                }
            }
        }
        static void ModificarProveedor()
        {
            Console.Write("ID del Proveedor a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nueva Razón Social: ");
            string razonSocial = Console.ReadLine();
            Console.Write("Nuevo Tipo de Documento: ");
            string tipoDocumento = Console.ReadLine();
            Console.Write("Nuevo Número de Documento: ");
            string numeroDocumento = Console.ReadLine();
            Console.Write("Nueva Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Nuevo Email: ");
            string mail = Console.ReadLine();
            Console.Write("Nuevo Celular: ");
            string celular = Console.ReadLine();
            Console.Write("Estado (activo = 1, inactivo = 0): ");
            bool estado = Console.ReadLine() == "1";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Proveedor SET RazonSocial = @RazonSocial, TipoDocumento = @TipoDocumento, NumeroDocumento = @NumeroDocumento, Direccion = @Direccion, Mail = @Mail, Celular = @Celular, Estado = @Estado WHERE Id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@RazonSocial", razonSocial);
                    cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Mail", mail);
                    cmd.Parameters.AddWithValue("@Celular", celular);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Proveedor modificado con éxito.");
            }
        }
        static void EliminarProveedor()
        {
            Console.Write("ID del Proveedor a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Proveedor WHERE Id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Proveedor eliminado con éxito.");
            }
        }


    }
}

