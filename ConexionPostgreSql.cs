using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

namespace control
{
    public class ConexionPostgreSql
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5433;User Id=admin;Password=123;Database=postgres;");


        public void Conectar()
        {
            conn.Open();
            //MessageBox.Show("Si se conecto");
        }
        public void desconectar()
        {
            conn.Close();
        }
        public bool inicioSeccion(string user, string password)
        {
            string cadena = "SELECT id_usuario,password From restaurante.usuario Where  id_usuario = " + user + " and activo=TRUE;";
            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader reader;
            bool validacion = false;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    int get_usuario = reader.GetInt32(0);
                    string get_password = reader["password"].ToString();

                    

                    if (get_usuario.ToString() == user && get_password == password)
                    {
                        validacion = true;
                    }
                    
                }
                reader.Close();
            }
            catch (Exception)
            {
                validacion = false;
            }
            
            return validacion;
        }
        //registrar usuarios
        public int registroUsuario(string nombre, string rfc, string direccion, string seguro)
        {
            int id_usuario = 0;
            //otener el ultimo registro
            string cadena = "SELECT MAX(id_usuario) FROM restaurante.usuario";
            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                try
                {
                    id_usuario = reader.GetInt32(0);
                }
                catch (Exception)
                {
                    id_usuario = 0;
                }

                reader.Close();
                id_usuario = id_usuario + 1;
                string cadena2 = "INSERT INTO restaurante.usuario VALUES('" + id_usuario + "','" + rfc + "','" + direccion + "','" + seguro + "','123','" + nombre + "',TRUE);";
                cmd = new NpgsqlCommand(cadena2, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(cadena2);
            }
            return id_usuario;
        }
        public DataTable consultar()
        {
            string query = "SELECT id_usuario,rfc,direccion,seguro,nombre FROM restaurante.usuario where activo=TRUE;";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public DataTable consultar(string id_usuario)
        {
            string query = "select nombre,direccion,rfc,seguro from restaurante.usuario where id_usuario=" + id_usuario + ";";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public void baja_user(string id_user)
        {
            string cadena = "Update restaurante.usuario set activo=FALSE where id_usuario=" + id_user + ";";
            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conn);
            cmd.ExecuteNonQuery();
        }
        public int nuevo_producto(string nombre, string compania, decimal precio, string proveedor, string stock)
        {

            int id_producto = 0;
            //otener el ultimo registro
            string cadena = "SELECT MAX(id_producto) FROM restaurante.tipo_producto;";
            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                try
                {
                    id_producto = reader.GetInt32(0);
                }
                catch (Exception)
                {
                    id_producto = 0;
                }

                reader.Close();
                id_producto = id_producto + 1;
                string cadena2 = "INSERT INTO restaurante.tipo_producto VALUES('" + nombre + "','" + id_producto + "','" + precio + "','" + proveedor + "','" + compania + "','" + stock + "',TRUE);";
                cmd = new NpgsqlCommand(cadena2, conn);
                cmd.ExecuteNonQuery();
            }

            return id_producto;

        }

        public bool ingresar_producto(int id_producto, int cantidad, int dia, int mes, int year)
        {
            bool validacion = false;
            int id_lote = 0;
            //otener el ultimo registro
            string cadena = "SELECT MAX(id_lote) FROM restaurante.lote";
            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                try
                {
                    id_lote = reader.GetInt32(0);
                }
                catch (Exception)
                {
                    id_lote = 0;
                }

                reader.Close();
                string cadena2 = "select id_producto from restaurante.tipo_producto where id_producto =" + id_producto + ";";
                NpgsqlCommand cmd2 = new NpgsqlCommand(cadena2, conn);
                NpgsqlDataReader reader2;
                reader2 = cmd.ExecuteReader();
                if (reader2.Read())
                {
                    try
                    {
                        reader2.Close();
                        id_lote = id_lote + 1;
                        string cadena3 = "INSERT INTO restaurante.lote VALUES('" + id_lote + "','" + cantidad + "','" + id_producto + "','" + dia + "/" + mes + "/" + year + "');";
                        NpgsqlCommand cmd3 = new NpgsqlCommand(cadena3, conn);
                        cmd3.ExecuteNonQuery();
                        validacion = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ingrese todos los datos");
                    }

                }

            }
            return validacion;
        }
        public int aux_stock(int id_producto)
        {
            int cantidad = 0;
           // MessageBox.Show(id_producto.ToString());
            string cadena = "SELECT sum(lote.cantidad) FROM restaurante.tipo_producto JOIN restaurante.lote ON id_producto = f_tipo where id_producto = '"+id_producto +"'  Group by tipo_producto.nombre; ";
            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                 cantidad = reader.GetInt32(0);
            }
            
            reader.Close();
            return cantidad;
        }
        public DataTable stock()
        {

            //ya tenemos el valor

            string query = "select id_producto,stock_m,nombre from restaurante.tipo_producto where activo=TRUE;";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            DataTable tabla2 = new DataTable();
            tabla2.Columns.Add("nombre");
            tabla2.Columns.Add("id_producto");
            tabla2.Columns.Add("cantidad");
            tabla2.Columns.Add("stock_m");
            datos.Fill(tabla);
            int cantcol = tabla.Rows.Count;
            int x = 0;

            while (x < cantcol)
            {

                string id = tabla.Rows[x]["id_producto"].ToString();
                string stock = tabla.Rows[x]["stock_m"].ToString();
                string nombre = tabla.Rows[x]["nombre"].ToString();
                int stock2 = Convert.ToInt32(stock);
             //   MessageBox.Show(id);
                int cantidad = aux_stock(Convert.ToInt32(id));
                if (cantidad <= stock2)
                {
                    tabla2.Rows.Add(new object[] { nombre, id, cantidad, stock });
                }
                x++;
            }

            return tabla2;
        }
        public void cambio_password(string id_usuario, string actual, string cambio)
        {
            bool validacion = inicioSeccion(id_usuario, actual);
            if (validacion)
            {
                string query = "Update restaurante.usuario set password= '" + cambio + "' Where id_usuario = " + id_usuario + "; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("El cambio se realizo de manera correcta");

            }
            else
            {
                MessageBox.Show("Ingrese datos correctos");
            }
        }
        public DataTable listado_productos()
        {
            string query = " SELECT * from restaurante.tipo_producto;";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public DataTable busqueda_lotes(int id_producto)
        {
            string query = " SELECT tipo_producto.nombre, lote.cantidad,lote.fecha_c, lote.id_lote FROM restaurante.tipo_producto JOIN restaurante.lote ON id_producto = f_tipo where id_producto = " + id_producto + "; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public DataTable suma_productos()
        {
            string query = "SELECT tipo_producto.nombre, sum(lote.cantidad) FROM restaurante.tipo_producto JOIN restaurante.lote ON id_producto = f_tipo Group by tipo_producto.nombre; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public int aux_salida()
        {
            int id_salida = 0;
            string cadena = "SELECT MAX(id_salida) FROM restaurante.salida";
            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                try
                {
                    id_salida = reader.GetInt32(0);
                }
                catch (Exception)
                {
                    id_salida = 0;
                }
                id_salida = id_salida + 1;

                reader.Close();
            }


                return id_salida;
        }
        public void salida(int id_producto, int cantidad, string cadena)
        {
            int id_salida;
            int cantidad2 = 0;
            int id_usuario = Convert.ToInt32(cadena);
            string quary = "SELECT lote.id_lote,lote.cantidad FROM restaurante.tipo_producto JOIN restaurante.lote ON id_producto = f_tipo where id_producto = " + id_producto + " and cantidad> " + cantidad + " ORDER BY fecha_c;";
            NpgsqlCommand cmd = new NpgsqlCommand(quary, conn);
            NpgsqlDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    int get_idlote = reader.GetInt32(0);
                    int get_cantidad = reader.GetInt32(1);
                    reader.Close();

                    id_salida = aux_salida();
                    MessageBox.Show(id_salida.ToString());

                   
                    //codigo de salida de producto
                    string sal = "INSERT INTO restaurante.salida VALUES('" + id_salida+ "','" + id_usuario + "','" + get_idlote + "','" + cantidad + "');";
                    cmd = new NpgsqlCommand(sal, conn);
                    cmd.ExecuteNonQuery();
                    int nuevo = get_cantidad - cantidad;
                    string actualizar = "Update restaurante.lote set cantidad= " + nuevo + " Where id_lote = " + get_idlote + "; ";
                    cmd = new NpgsqlCommand(actualizar, conn);
                    cmd.ExecuteNonQuery();
                    string impresion = "Puede tomar sus piezas del lote " + get_idlote + ".";
                    MessageBox.Show(impresion);

                }
            

            }
            catch (Exception)
            {
                MessageBox.Show("No exisite un lote con las piezas suficientes");
            }
            
            

        }
        public DataTable ver_salidas(int id_usuario)
        {
            string query = "Select  usuario.nombre, salida.id_salida, salida.id_lote, salida.cantidad From restaurante.usuario Join restaurante.salida ON salida.id_usuario = '"+id_usuario+"' where salida.id_usuario = usuario.id_usuario; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public DataTable caducar()
        {
            DateTime thisDay = DateTime.Today;
            thisDay.AddDays(20);
            //para los dias
            string query = "select tipo_producto.nombre, lote.id_lote,lote.fecha_c,lote.cantidad from restaurante.lote JOIN restaurante.tipo_producto ON id_producto = f_tipo; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);

            var miDataTable = new DataTable();
            miDataTable.Columns.Add("nombre");
            miDataTable.Columns.Add("id_lote");
            miDataTable.Columns.Add("fecha_c");
            miDataTable.Columns.Add("cantidad");
            int nrorows = tabla.Rows.Count;
            int contador = 0;
            while (contador < nrorows)
            {
                
               
                string nombre = tabla.Rows[contador]["nombre"].ToString();
                string id_lote = tabla.Rows[contador]["id_lote"].ToString();
                string fecha_c = tabla.Rows[contador]["fecha_c"].ToString();
                string cantidad = tabla.Rows[contador]["cantidad"].ToString();
                MessageBox.Show(fecha_c.ToString());
                string format = "MM/dd/yyyy";
                DateTime dateTime = DateTime.ParseExact(fecha_c, format, CultureInfo.InvariantCulture);

                //int resultado=thisDay.Subtract(fech).Days;
                //MessageBox.Show(resultado.ToString());



                //fecha.Subtract(thisDay).Days;
                /*if () {

                    miDataTable.Rows.Add(new object[] { nombre, id_lote, fecha_c, cantidad });

                }//ya sabes*/
                contador = contador + 1;

            }


            return miDataTable;

        }

        public void modificar_user(string id_usuario,string nombre,string dirrecion,string rfc,string seguro)
        {
            //comprobar que los datos esten llenos
            if (nombre.Length > 0)
            {
                string query = "Update restaurante.usuario set nombre= '" + nombre + "' Where id_usuario = " + id_usuario + "; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            if (dirrecion.Length > 0)
            {
                string query = "Update restaurante.usuario set direccion= '" + dirrecion+ "' Where id_usuario = " + id_usuario + "; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
               
            }
            if (rfc.Length > 0)
            {
                string query = "Update restaurante.usuario set rfc= '" + rfc + "' Where id_usuario = " + id_usuario + "; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
              
            }
            if (seguro.Length > 0)
            {
                string query = "Update restaurante.usuario set seguro= '" + seguro + "' Where id_usuario = " + id_usuario + "; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();

            }
        }
        public DataTable mostrar_producto(int id_producto)
        {
            string query = "Select nombre, precio, proveedor, nombre_company, stock_m from restaurante.tipo_producto  where id_producto = "+ id_producto+"; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public void modificar_producto(int id_producto,string nombre,string precio,string proveedor,string compania,string minimo)
        {
            if (nombre.Length > 0)
            {
                string query = "Update restaurante.tipo_producto set nombre= '" + nombre + "' Where id_producto = " + id_producto + "; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            if (precio.Length > 0)
            {
                try
                {
                    decimal precio_final = Convert.ToDecimal(precio);
                    string query = "Update restaurante.tipo_producto set precio= '" + precio_final + "' Where id_producto = " + id_producto+ "; ";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ingrese un valor numerico para el precio");
                }
            }
            if (proveedor.Length > 0)
            {
                string query = "Update restaurante.tipo_producto set proveedor= '" + proveedor + "' Where id_producto = " + id_producto + "; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            if (compania.Length > 0)
            {
                string query = "Update restaurante.tipo_producto set nombre_company= '" + proveedor + "' Where id_producto = " + id_producto + "; ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            if (minimo.Length > 0)
            {
                try
                {
                    int stock = Convert.ToInt32(minimo);
                    string query = "Update restaurante.tipo_producto set stock_m= '" + stock + "' Where id_producto = " + id_producto + "; ";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ingrese un valor numerico en estock minimo");
                }
            }


        }

    }
}
