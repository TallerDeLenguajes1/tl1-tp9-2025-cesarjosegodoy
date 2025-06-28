using System;
using System.IO;
using System.Text;
Console.WriteLine("Bienvenido ingresa la ruta del archivo");
string ruta = Console.ReadLine() ?? "";

if (File.Exists(ruta))
{
    using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
using (BinaryReader br = new BinaryReader(fs)) //Crear una clase y pasarlo
{
    if (fs.Length >= 128)
    {
        fs.Seek(-128, SeekOrigin.End);
        
        byte[] tag = br.ReadBytes(128);
        
        string inicio = System.Text.Encoding.ASCII.GetString(tag, 0, 3);
        if (inicio == "TAG")
        {
            string titulo = System.Text.Encoding.ASCII.GetString(tag, 3, 30).TrimEnd('\0');
            string artista = System.Text.Encoding.ASCII.GetString(tag, 33, 30).TrimEnd('\0');
            string album = System.Text.Encoding.ASCII.GetString(tag, 63, 30).TrimEnd('\0');
            string anno = System.Text.Encoding.ASCII.GetString(tag, 93, 4).TrimEnd('\0');
            string comentario = System.Text.Encoding.ASCII.GetString(tag, 97, 30).TrimEnd('\0');
            byte genero = tag[127];
           
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Artista: {artista}");
            Console.WriteLine($"Álbum: {album}");
            Console.WriteLine($"Año: {anno}");
            Console.WriteLine($"Comentario: {comentario}");
            Console.WriteLine($"Género (código): {genero}");

        }
        else
        {
            Console.WriteLine("Sin etiqueta ID3v1.");
        }
    }
    else
    {
        Console.WriteLine("Archivo demasiado pequeño.");
    }
}

}