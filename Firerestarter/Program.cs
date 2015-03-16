/*
 * Firestarter - Copyright (C) 2011 Petros Kyladitis
 * A command line process killing & restaring tool
 * Developed in SharpDevelop, at C# language, targeted .NET/Mono
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
 
using System;
using System.Diagnostics;
using System.IO;

namespace Firerestarter{
	class Program{
		
		//The filename of this application without the extension '.exe'
		private static string appFilename = Process.GetCurrentProcess().MainModule.ModuleName.TrimEnd(".exe".ToCharArray()) ;
		private static string procnameFile = String.Concat(appFilename, ".ini") ;

		public static void Main(string[] args){			

			string processName ;
			string processExeFile ;			
			
			PrintAppInfo() ;
			
			if(args.Length==1){
				//set the first command line argunet as the process name parameter
				processName = args[0] ;
			}
			else if(File.Exists(procnameFile)){
				//read the first line of the file and parse the string as the process name parameter
				processName = File.ReadAllLines(procnameFile)[0] ;
			}
			else{
				//print the parameters help text, prompt user to press any key and then exit
				PrintHelp() ;
				Pause() ;
				return ;
			}			
			
			Process[] proc = Process.GetProcessesByName(processName) ;			
			
			//if no instance of the specified process founded alive, the notify, pause and exit
			if(proc.Length==0){
				Console.WriteLine(String.Concat("No instance of process called \'", processName, "\' founded alive!")) ;
				Pause() ;
				return ;
			}
			
			//print how many instances of the specified process founded alive
			if(proc.Length>1){
				Console.WriteLine(String.Concat(proc.Length.ToString(), " instances of the process called \'", processName, "\' founded alive.")) ;
			}else{
				Console.WriteLine(String.Concat("One instance of the process called \'", processName, "\' founded alive.")) ;
			}
			
			try{
				//Get the specified process executable path
				processExeFile = proc[0].MainModule.FileName ;
				
				//For all instances founded, start killing them
				for(int i=0; i<proc.Length; i++){
						proc[i].Kill() ;
						proc[i].WaitForExit() ;
						Console.WriteLine(String.Concat("Session no.", proc[i].Id, " terminated.")) ;
				}
				
				//Start the specified process again, by using the proper executable path
				Console.WriteLine(String.Concat("\nExecuting the ", processExeFile, "\nPlease wait...")) ;
				Process.Start(processExeFile) ;
				Console.WriteLine("Done!") ;				
			}
			catch(Exception exc){
				Console.WriteLine(String.Concat("\nThe following error occured!\n",exc.Message)) ;
			}
			
			//Pause() ; //for debugging usage
		}
		
		private static void PrintAppInfo(){
			Console.WriteLine("Firerestarter v.1.0.0\n(C) 2011 - Petros Kyladitis\nA command line process killing & restaring tool.\n\nDeveloped at C#, targeting .NET/Mono framework.\nDistributed under the terms of GNU General Public License\nThis program comes with ABSOLUTELY NO WARRANTY, is free software,\nand you are welcome to redistribute it under certain conditions;\nfor details see the 'readme.txt' file wich distributed with this app\n====================================================================\n") ;		}
		
		private static void PrintHelp(){
			Console.WriteLine(String.Concat("You must specify the name of the process you want to kill & restart by giving it as parameter when executing this application, or by using a file that's having the same filename with this app and .ini as extension\n\nFor example, if you want to restart the Mozilla Firefox\n- at the console, give: '", appFilename, " firefox'\n- or store the process name 'firefox' to a file called '", procnameFile, "' at the same folder with this app, and execute it without parameters.")) ;
		}
		
		private static void Pause(){
			Console.Write("\nPress any key to continue...") ;
			Console.ReadKey() ;			
		}

	}
}