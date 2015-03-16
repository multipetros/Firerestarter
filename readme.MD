# Firerestarter v.1.0
Copyright (C) 2011, Petros Kyladitis  
A command line process killing & restaring tool for .NET/Mono framework

## Intoduction
I'm a Firefox fun, from the days of 'Firebird'.
And I also believe that internet should be open, public and accessible. 

Anyway, some times, when I try to open the Firefox, the process of before 'closed' browser still alive, prompted me about that and the only way to 
reopen the browser is by hitting 'alt+ctrl+del', open the task manager, find the process and terminated it manualy. That's so annoying I think... 

So, I made the Firerestarter. A tiny tool, written in C#, targeting the .Net/Mono framework, that do the 'dirty' job for us. It can be used for any programm you want, not only for Mozilla Firefox. For more details about its usage see the 'Program Usage' section above.

## Program usage
To run this programm you must specify the name of the process you want to kill  and restart by giving it as parameter when executing this application, or by using a file that's having the same filename with this app and .ini as extension.

For example, if you want to restart the Mozilla Firefox:  

 * at the console, give: `Firerestarter firefox`  
 * or store the process name `firefox` to a file called `Firestarter.ini` at the same folder with this app, and execute it without parameters.

## License
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or
any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

You should have received a copy of the GNU General Public License along with this program. If not, see <http://www.gnu.org/licenses/>.