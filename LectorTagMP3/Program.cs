using System;
using System.IO;

Console.Clear();
string path = "MP3/";
DirectoryInfo carpeta = new DirectoryInfo(path);

if (carpeta.Exists)
{
    FileInfo[] canciones = carpeta.GetFiles("*.mp3");
    if (canciones.Length > 0)
    {
        Console.WriteLine("\n\t\t---LISTA DE CANCIONES---");
        foreach (FileInfo cancion in canciones)
        {
            Console.WriteLine($"\t|--> {cancion.Name}");
        }
    }else
    {
        Console.WriteLine("\n\t\t---Sin Canciones---");
    }
}else{
    Console.WriteLine("\n\t\t---LA CARPETA NO EXISTE----");
}