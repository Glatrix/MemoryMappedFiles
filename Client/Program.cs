using System.IO.MemoryMappedFiles;
using System.Text;

namespace Client
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
            mmf = MemoryMappedFile.OpenExisting("vN$8n432", MemoryMappedFileRights.ReadWrite);
            accessor = mmf.CreateViewAccessor();

            byte[] bytes = Read();
            Console.WriteLine(Encoding.Default.GetString(bytes));
            Console.ReadKey();
        }
    }
}