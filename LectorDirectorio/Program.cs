using System;
using System.IO;
// variables para el manejo de la interfaz
string path;
bool continuar = true;

// bucle para ejecucion de la lógica
do
{
    Console.Clear();    /* limpieza de la terminal */
    Console.WriteLine(new string('-', 100)); // separador visual
    Console.WriteLine("\n\t\tTALLER DE LENGUAJES 1");   /* titulo */
    // mensaje para pedir el path
    Console.Write("\n\tIngrese el direcorio a examinar (ENTER PARA CANCELAR): ");
    path = Console.ReadLine();  /* guardado de la entrada por teclado */
    // si la entrada es vacia salimos del programa
    if (string.IsNullOrEmpty(path)) break;
    // isntancia para el direcorio ingresado
    DirectoryInfo directorio = new DirectoryInfo(path);
    // lógica para encontrar los directorios y archivos
    if (directorio.Exists)  /* verificacion de la existencia de la direccion */
    {
        // arreglos con los archivod y subdirectorios del path
        FileInfo[] archivos = directorio.GetFiles();    
        DirectoryInfo[] subDirectorios = directorio.GetDirectories();

        Console.WriteLine("\n\t\t---SUBDIRECTORIOS---");
        if (subDirectorios.Length>0)    /* verifico que hayan subdirectorios */
        {
            foreach (DirectoryInfo sub in subDirectorios)   /* recorrido del arreglo con los subdirectorios */
            {
                Console.WriteLine($"\t|--> {sub.Name}");
            }
        }else{
            Console.WriteLine("\n\t\t---VACÍO---"); /* mensaje en caso de no haber subdirectorios */
        }

        Console.WriteLine("\n\t\t---ARCHIVOS---");
        if (archivos.Length > 0)    /* verifico que hayan archivos */
        {
            List<string> InfoArchivo = new List<string>();  /* lista para guardar los datos de los archivos */
            InfoArchivo.Add("NOMBRE , TAMAÑO(BYTES), ULTIMO_ACCESO");   /* columas para la informacion de los archivos */
            Console.WriteLine($"\t| {"NOMBRE",-40}| {"TAMAÑO (bytes)",-40}");    /* impresion con las columnas de informacion */
            Console.WriteLine(new string('-', 90));     /* separador visual */
            foreach (FileInfo file in archivos) /* recorrido del arreglo con la informacion de los archivos */
            {
                Console.WriteLine($"\t| {file.Name,-40}| {file.Length, -13} Bytes");
                InfoArchivo.Add($"{file.Name},{file.Length},{file.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss")}");    /* guardado de los datos en la lista */
            }
            string rutaCsv = "reporte_archivos.csv"; // crea el archivo .cvs
            File.WriteAllLines(rutaCsv,InfoArchivo); /* guardado de los datos en el archivo csv */
        }else{
            Console.WriteLine("\n\t\t---VACÍO---"); /* mensaje en caso de no haber archivos */
        }
    }else{
        Console.WriteLine("\n\t\t---DIRECTORIO INVÁLIDO---"); /* por si el directorio no es valido */
    }

    // bucle para continuar en el programa
    do{
        Console.Write("\n\t\tDesea continuar? (ESC = NO | ENTER = SÍ): ");
        ConsoleKey tecla = Console.ReadKey(true).Key;
        if(tecla == ConsoleKey.Escape || tecla == ConsoleKey.Enter){    /* solo entra si se apreto esc o enter */
            continuar = (tecla == ConsoleKey.Enter) ? true : false; /* le asigno un valor a continuar segun la tecla que se apreto */
            break;
        }
        Console.WriteLine("\n\t\t---OPCIÓN NO VALIDA, REINGRESE---");
    }while(true); /* no es necesario cambiar la condicion pues cuando se cumplae el if se rompe el bucle */
} while (continuar);