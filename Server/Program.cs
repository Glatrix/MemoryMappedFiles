using System;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace FileMappings
{
    internal class Program
    {
        const int SIZE = 1096;
        static MemoryMappedFile mmf;
        static MemoryMappedViewAccessor accessor;

        static byte[] Read()
        {
            int size = accessor.ReadInt32(0);
            byte[] buffer = new byte[size];
            accessor.ReadArray(4, buffer, 0, size);
            return buffer;
        }

        static void Write(byte[] bytes)
        {
            int size = bytes.Length;
            accessor.Write<Int32>(0, ref size);
            accessor.WriteArray(4, bytes, 0, size);
        }

        static void Main(string[] args)
        {
            // mmf = MemoryMappedFile.CreateFromFile("", FileMode.Open, "vN$8n432");
            mmf = MemoryMappedFile.CreateNew("vN$8n432", SIZE);
            accessor = mmf.CreateViewAccessor();

            Write(Encoding.Default.GetBytes("Hello Maps!! (From C#)"));

            while (true)
            {

            }
        }
    }
}