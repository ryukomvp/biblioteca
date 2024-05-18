/*
 * Created by SharpDevelop.
 * User: danie
 * Date: 07/05/2024
 * Time: 14:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;

namespace biblioteca
{
	class Program
	{
		public struct Libros
		{
			public String nombre;
			public String editorial;
			public String autor;
			public String categoria;
			public String publicacion;
		}
		
		public struct Devolucion
		{
			public String nombre; 
			public String libro;
		}
		
		public struct datos
		{
			public String us, clave;
			public String[] campos;
//			public String ruta;
		}
		
		static StreamReader lectura;
		static StreamWriter escribir;
		
		public static void Main(String[] args)
		{
			Console.Title = "Biblioteca";
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			
			String ruta = "C:/GitHub/biblioteca/ficheros/";
			String rutadb = "C:/GitHub/biblioteca/db/";
			
			while (!login(rutadb)){
				// El login se ejecuta mientras retorne falso, cuando retorna true se sale del bucle y sigue el codigo
			}
			
			do
			{
				// Menu principal para seleccionar que función realizar
				switch (menu()) {
					case '1':
						// Opción: registrar un usuario
						break;
					case '2':
						// Opción: registrar un libro
						registrar_libro(ruta, rutadb);
						break;
					case '3':
						// Opción: registrar un prestamo de libro
						break;
					case '4':
						devolucion(ruta, rutadb);// Opción: registrar una devolución de libro
						break;
					case '5':
						// Opción: mostrar toda la información
						mostrar_info(rutadb);
						break;
					case '6':
						// Opción: salir
						creditos();
						Environment.Exit(0);
						break;
					default:
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Red;
						Console.WriteLine("\n\tDebe ingresar una opción válida");
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
						break;
				}
			} while (salir());
			creditos();
		}
		
		static Boolean login(String ruta)
		{
			datos var_datos;
			var_datos.campos = new String[2];
			ruta = ruta + "usuarios.txt";
			String cadena;
			bool resp = false;
//			int n_intentos = 0;
			
			Console.Clear();
			try {
				lectura = File.OpenText(ruta);
				
				Console.Write("\n\tIngrese su usuario: ");
				var_datos.us = Console.ReadLine();
				Console.Write("\tIngrese su clave: ");
				var_datos.clave = Console.ReadLine();
				
				cadena = lectura.ReadLine();
				while (cadena != null && resp != true) {
					var_datos.campos = cadena.Split(',');
					if(var_datos.campos[0].Trim().Equals(var_datos.us) && var_datos.campos[1].Trim().Equals(var_datos.clave)) {
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Green;
						Console.WriteLine("\n\tCredenciales correctas :D");
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ReadKey();
						resp = true;
						return true;
					} else {
						cadena = lectura.ReadLine();
					}
				}
				if (resp == false) {
//					n_intentos = n_intentos + 1;
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("\n\tCredenciales incorrectas D:");
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
//					if (n_intentos < 3) {
//						Console.Write("\tLe quedan {0} intentos", 3-n_intentos);
//					} else if (n_intentos == 3) {
//						Console.Write("\n\tLimite de intentos alcanzado, cerrando el programa");
//						Console.ReadKey();
//						creditos();
//						Environment.Exit(0);
//					}
					Console.ReadKey();
				}
				lectura.Close();
				return false;
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("\n\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ReadKey();
				
				return false;
			}
		}
		
		static char menu()
		{
			Console.Clear();
			Console.WriteLine("\t* --------------------------------- *");
			Console.WriteLine("\t| Menú                              |");
			Console.WriteLine("\t* --------------------------------- *");
			Console.WriteLine("\t| 1.\tRegistrar usuario           |");
			Console.WriteLine("\t| 2.\tRegistrar libro             |");
			Console.WriteLine("\t| 3.\tPrestamo de libro           |");
			Console.WriteLine("\t| 4.\tDevolución de libro         |");
			Console.WriteLine("\t| 5.\tMostrar toda la información |");
			Console.WriteLine("\t| 6.\tSalir                       |");
			Console.WriteLine("\t* --------------------------------- *");
			Console.Write("\n\tSeleccione la acción que desea realizar: ");
			char opcion = Console.ReadKey().KeyChar;
			
			return opcion;
		}
		
		static void registrar_libro(String ruta, String rutadb)
		{
			try
			{
				Libros acceso;
				String opcion;
				ruta = ruta + "libros.txt";
				rutadb = rutadb + "libros.txt";
				
				do
				{
					Console.Clear();
					escribir = new StreamWriter(ruta, true);
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
					Console.WriteLine("\n\t\tRegistrar un libro");
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.WriteLine("\n\tIngresar datos del libro");
					Console.Write("\tNombre: ");
					acceso.nombre = Console.ReadLine();
					Console.Write("\tEditorial: ");
					acceso.editorial = Console.ReadLine();
					Console.Write("\tAutor: ");
					acceso.autor = Console.ReadLine();
					Console.Write("\tCategoria: ");
					acceso.categoria = Console.ReadLine();
					Console.Write("\tAño de publicación: ");
					acceso.publicacion = Console.ReadLine();
					escribir.Write("\n\tNombre: " + acceso.nombre);
					escribir.Write("\n\tEditorial: " + acceso.editorial);
					escribir.Write("\n\tAutor: " + acceso.autor);
					escribir.Write("\n\tCategoría: " + acceso.categoria);
					escribir.Write("\n\tAño de publicación: " + acceso.publicacion);
					escribir.Write("\n\t* -------------------- * -------------------- * -------------------- *");
					Console.ReadKey();
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
					Console.WriteLine("\n\tRegistro exitoso!");
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					escribir.Close();
					// Escribir en el archivo de la base
					escribir = new StreamWriter(rutadb, true);
					escribir.Write("{0},{1},{2},{3},{4}\n", acceso.nombre, acceso.editorial, acceso.autor, acceso.categoria, acceso.publicacion);
					escribir.Close();
					
					Console.Write("\tDesea registrar otro libro [S/N]: ");
					opcion = Console.ReadLine ();
				}
				while (opcion == "S" || opcion == "s");
				Console.Clear();
				Console.Write("\n\tAbriendo el registro de devoluciones...");
				Process.Start(ruta);
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("\n\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ReadKey();
			}
		}
		
		static void devolucion(String ruta, String rutadb)
		{
			try
			{
				Devolucion acceso;
				String opcion;
				ruta = ruta + "devoluciones.txt";
				rutadb = rutadb + "devoluciones.txt";
				
				do
				{
					Console.Clear();
					escribir = new StreamWriter(ruta, true);
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
					Console.WriteLine("\n\t\tRegistro de devolución");
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.WriteLine("\n\tIngresar datos para devolucion de libro");
					Console.Write("\tNombre de la persona: ");
					acceso.nombre = Console.ReadLine();
					Console.Write("\tNombre del libro a devolver: ");
					acceso.libro = Console.ReadLine();
					Console.Write("\tFecha y hora de la devolución: [" + DateTime.Now.ToString() + "]");
					escribir.Write("\n\tNombre de la persona: " + acceso.nombre);
					escribir.Write("\n\tNombre del libro: " + acceso.libro);
					escribir.Write("\n\tFecha y hora de la devolución: [" + DateTime.Now.ToString() + "]");
					escribir.Write("\n\t* -------------------- * -------------------- * -------------------- *");
					Console.ReadKey();
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
					Console.WriteLine("\n\tRegistro exitoso!");
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					escribir.Close();
					// Escribir en el archivo de la base
					escribir = new StreamWriter(rutadb, true);
					escribir.Write("{0},{1},{2}\n", acceso.nombre, acceso.libro, DateTime.Now.ToString());
					escribir.Close();
					
					Console.Write("\tDesea registrar otra devolución [S/N]: ");
					opcion = Console.ReadLine ();
//					if (opcion == "N" || opcion == "n")
//					{
//						Process.Start("C:/GitHub/biblioteca/ficheros/devoluciones.txt");
//					}
				}
				while (opcion == "S" || opcion == "s");
				Console.Clear();
				Console.Write("\n\tAbriendo el registro de devoluciones...");
				Process.Start(ruta);
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("\n\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ReadKey();
			}
		}
		
		static void mostrar_info(String ruta)
		{
			datos var_datos;
//			var_datos.campos = new String[2];
			String linea;
			
			Console.Clear();
			Console.WriteLine("\t* --------------------------------- *");
			Console.WriteLine("\t| Archivos                          |");
			Console.WriteLine("\t* --------------------------------- *");
			Console.WriteLine("\t| 1.\tInformación de usuarios     |");
			Console.WriteLine("\t| 2.\tInformación de libros       |");
			Console.WriteLine("\t| 3.\tInformación de prestamos    |");
			Console.WriteLine("\t| 4.\tInformación de devoluciones |");
			Console.WriteLine("\t| 5.\tRegresar al menu principal  |");
			Console.WriteLine("\t* --------------------------------- *");
			Console.Write("\n\tSeleccione el archivo que desea leer: ");
			char opcion = Console.ReadKey().KeyChar;
			Console.Clear();
			
			switch (opcion) {
				case '1':
					// Opción: leer usuarios
					try {
						ruta = ruta + "usuarios.txt";
						lectura = new StreamReader(ruta);
						Console.Write("\n\t* -------------------- * -------------------- *");
						Console.Write("\n\t| Información de los usuarios registrados     |");
						Console.Write("\n\t* -------------------- * -------------------- *");
						while ((linea = lectura.ReadLine()) != null) {
							var_datos.campos = linea.Split(',');
							imprimir_info("  Usuario", var_datos.campos[0].Trim());
							imprimir_info("  Clave", var_datos.campos[1].Trim());
							Console.Write("\n\t* -------------------- * -------------------- *");
						}
						lectura.Close();
//						var_datos.ruta = "C:/GitHub/biblioteca/db/";
					} catch (Exception e) {
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Red;
						Console.Write("\n\t");
						Console.WriteLine(e.Message);
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ReadKey();
					}
					break;
				case '2':
					// Opción: leer libros
					try {
						ruta = ruta + "libros.txt";
						lectura = new StreamReader(ruta);
						Console.Write("\n\t* -------------------- * -------------------- *");
						Console.Write("\n\t| Información de los libros registrados       |");
						Console.Write("\n\t* -------------------- * -------------------- *");
						while ((linea = lectura.ReadLine()) != null) {
							var_datos.campos = linea.Split(',');
							imprimir_info("  Nombre del libro", var_datos.campos[0].Trim());
							imprimir_info("  Autor", var_datos.campos[1].Trim());
							Console.Write("\n\t* -------------------- * -------------------- *");
						}
						lectura.Close();
//						var_datos.ruta = "C:/GitHub/biblioteca/db/";
					} catch (Exception e) {
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Red;
						Console.Write("\n\t");
						Console.WriteLine(e.Message);
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ReadKey();
					}
					break;
				case '3':
					// Opción: leer prestamos
					try {
						Console.Clear();
						ruta = ruta + "prestamos.txt";
						Process.Start(ruta);
					} catch (Exception e) {
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Red;
						Console.Write("\n\t");
						Console.WriteLine(e.Message);
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ReadKey();
					}
					break;
				case '4':
					// Opción: leer devoluciones
					try {
						ruta = ruta + "devoluciones.txt";
						lectura = new StreamReader(ruta);
						Console.Write("\n\t* -------------------- * -------------------- *");
						Console.Write("\n\t| Información de las devoluciones realizadas  |");
						Console.Write("\n\t* -------------------- * -------------------- *");
						while ((linea = lectura.ReadLine()) != null) {
							var_datos.campos = linea.Split(',');
							imprimir_info("  Persona", var_datos.campos[0].Trim());
							imprimir_info("  Libro devuelto", var_datos.campos[1].Trim());
							imprimir_info("  Fecha de devolución", var_datos.campos[2].Trim());
							Console.Write("\n\t* -------------------- * -------------------- *");
						}
						lectura.Close();
//						var_datos.ruta = "C:/GitHub/biblioteca/db/";
					} catch (Exception e) {
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Red;
						Console.Write("\n\t");
						Console.WriteLine(e.Message);
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ReadKey();
					}
					break;
				case '5':
					Console.Clear();
					break;
				default:
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("\n\tDebe ingresar una opción válida");
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					break;
			}
		}
		
		static void imprimir_info(String a, String b)
		{
			Console.Write("\n\t{0}: ", a);
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.Write("{0}", b);
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
		}
		
		static Boolean salir()
		{
			try {
				Console.Write("\n\tRegresar al menu [M] / Salir [ESC]: ");
				char resp = Console.ReadKey().KeyChar;
				
				if (resp == 'M' || resp == 'm') {
					return true;
				} else {
					return false;
				}
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("\n\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ReadKey();
				
				return false;
			}
		}
		
		static void creditos()
		{
			Console.Clear();
			Console.WriteLine("\n\tGracias por su preferencia.");
			Console.WriteLine("\tIntegrantes:");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("\tAlvarado Orellana, Ricardo Ernesto");
			Console.WriteLine("\tGarcía Flores, Fabricio Alexander");
			Console.WriteLine("\tHernández Castro, Jeffrey Alessandro");
			Console.WriteLine("\tHernández Figueroa, Daniel Alejandro");
			Console.WriteLine("\tMartínez Núñez, José Alberto");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\n\tRepositorio: ");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("https://github.com/ryukomvp/biblioteca");
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine("\n-> Fin del programa");
			Console.ReadKey();
		}
	}
}