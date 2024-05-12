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
		public static void Main(string[] args)
		{
			Console.Title = "Biblioteca";
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			
			string ruta = "C:/GitHub/biblioteca/ficheros/";
			
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
//						dklaj
						break;
					case '4':
						// Opción: registrar una devolución de libro
						break;
					case '5':
						// Opción: mostrar toda la información
						mostrar_info(ruta);
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
		
		static void mostrar_info(string ruta)
		{
			char resp = '0';
			
			do
			{
				Console.Clear();
				Console.WriteLine("\t* --------------------------------- *");
				Console.WriteLine("\t| Archivos                          |");
				Console.WriteLine("\t* --------------------------------- *");
				Console.WriteLine("\t| 1.\tInformación de usuarios     |");
				Console.WriteLine("\t| 2.\tInformación de libros       |");
				Console.WriteLine("\t| 3.\tInformación de prestamos    |");
				Console.WriteLine("\t| 4.\tInformación de devoluciones |");
//			Console.WriteLine("\t| 5.\tRegresar al menu principal  |");
				Console.WriteLine("\t* --------------------------------- *");
				Console.Write("\n\tSeleccione el archivo que desea leer: ");
				char opcion = Console.ReadKey().KeyChar;
				switch (opcion) {
					case '1':
						// Opción: leer usuarios
						try {
							Console.Clear();
							ruta = ruta + "usuarios.txt";
							Process.Start(ruta);
							ruta = ruta.TrimEnd('u','s','u','a','r','i','o','s','.','t','x','t');
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
							ruta = ruta + "libros.txt";
							Console.Write(ruta);
//							"C:\GitHub\biblioteca\ficheros\libros.txt"
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
							Console.Clear();
							ruta = ruta + "devoluciones.txt";
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
					default:
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Red;
						Console.WriteLine("\n\tDebe ingresar una opción válida");
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
						break;
				}
				
				try {
					Console.Write("\n\tLeer otro archivo [S] / Regresar al menu principal [cualquier tecla]: ");
					resp = Console.ReadKey().KeyChar;
				} catch (Exception e) {
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Red;
					Console.Write("\n\t");
					Console.WriteLine(e.Message);
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ReadKey();
				}
			} while(resp == 'S' || resp == 's');
		}
		
		static Boolean salir()
		{
			try {
				Console.Write("\n\tRegresar al menu [M] / Salir [cualquier tecla]: ");
				char resp = Console.ReadKey().KeyChar;
				
				if (resp == 'M' || resp == 'm') {
					return true;
				} else {
					creditos();
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