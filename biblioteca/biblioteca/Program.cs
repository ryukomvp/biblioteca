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
		public struct datos
		{
			public String cadena, us;
			public bool encontrado;
			public String[] campos;
			public char[] separador;
			
			public String ruta;
		}
		
		public static void Main(string[] args)
		{
			Console.Title = "Biblioteca";
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			
//			login(rutadb);
//			Console.ReadKey();
			do
			{
				switch (menu()) {
					case '1':
						// Opción: registrar un usuario
						break;
					case '2':
						// Opción: registrar un libro
						break;
					case '3':
						// Opción: registrar un prestamo de libro
						break;
					case '4':
						// Opción: registrar una devolución de libro
						break;
					case '5':
						// Opción: mostrar toda la información
						mostrar_info();
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
		
		static void login(string ruta)
		{
			StreamReader lectura;
			datos var_datos;
			
			var_datos.encontrado = false;
			var_datos.campos = new String[2];
			var_datos.separador = new char[1];
			var_datos.separador[0] = ',';
			ruta = ruta + "usuarios.txt";
			
			for (int i = 0; i < 1; i++) {
				try {
					lectura = File.OpenText(ruta);
					Console.Write("\n\tIngrese su usuario: ");
					var_datos.us = Console.ReadLine();
					var_datos.cadena = lectura.ReadLine();
					
					while (var_datos.cadena != null) {
						var_datos.campos = var_datos.cadena.Split(var_datos.separador[0]);
						
						if(var_datos.campos[0].Trim().Equals(var_datos.us)) {
							Console.WriteLine("\tImpresión de los datos encontrados...");
							Console.WriteLine("\tUsuario : " + var_datos.campos[0].Trim());
							Console.WriteLine("\tClave : " + var_datos.campos[1].Trim());
							var_datos.encontrado = true;
						} else {
							var_datos.cadena=lectura.ReadLine();
						}
					}
					if (var_datos.encontrado == false) {
						Console.Write("\n\tUsuario no encontrado");
					}
					lectura.Close();
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
		
		static void mostrar_info()
		{
			StreamReader lectura;
			datos var_datos;
			bool fin_registros = false;
			var_datos.campos = new String[2];
			var_datos.separador = new char[1];
			var_datos.separador[0] = ',';
			var_datos.ruta = "C:/GitHub/biblioteca/db/";
			
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
			switch (opcion) {
				case '1':
					// Opción: leer usuarios
					Console.Clear();
					try {
						var_datos.ruta = var_datos.ruta + "usuarios.txt";
						lectura = File.OpenText(var_datos.ruta);
						var_datos.cadena = lectura.ReadLine();
						while (var_datos.cadena != null && fin_registros == false) {
							var_datos.campos = var_datos.cadena.Split(var_datos.separador);
							Console.WriteLine("\tImpresión de los datos encontrados...");
							imprimir("Usuario", var_datos.campos[0].Trim());
							imprimir("Clave", var_datos.campos[1].Trim());
							Console.Write("\n\t*--------------------*--------------------*");
							fin_registros = true;
						}
						lectura.Close();
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
						Console.Clear();
						var_datos.ruta = var_datos.ruta + "libros.txt";
						Process.Start(var_datos.ruta);
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
						var_datos.ruta = var_datos.ruta + "prestamos.txt";
						Process.Start(var_datos.ruta);
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
						Console.Clear();
						var_datos.ruta = var_datos.ruta + "devoluciones.txt";
						Process.Start(var_datos.ruta);
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
		
		static void imprimir(string a, string b)
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
				Console.Write("\n\tRegresar al menu [M] / Salir [cualquier tecla]: ");
				char resp = Console.ReadKey().KeyChar;
				
				if (resp == 'M' || resp == 'm') {
					return true;
				} else {
//					creditos();
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