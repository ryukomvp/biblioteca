/*
 * Created by SharpDevelop.
 * User: danie
 * Date: 07/05/2024
 * Time: 14:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

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
						Console.Write("\n\tDebe ingresar una opción válida");
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
						break;
				}
			} while (salir());
			creditos();
		}
		
		static int menu()
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
				Console.Write("\t");
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				
				return false;
			}
		}
		
		static void creditos()
		{
			Console.Clear();
			Console.WriteLine("\n\tGracias por su preferencia.");
			Console.ForegroundColor = ConsoleColor.DarkGray;
//			Console.WriteLine("\tig:\thttps://www.instagram.com/dnlhernandez_/");
			Console.WriteLine("\trepositorio:\thttps://github.com/ryukomvp/biblioteca");
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine("\n-> Fin del programa.");
			Console.ReadKey();
		}
	}
}