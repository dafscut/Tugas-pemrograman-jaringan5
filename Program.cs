using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using PraktikumStream;

namespace PraktikumStream
{
    public class Program
    {
        private const string JsonFile = "mahasiswa.json";
        private const string XmlFile = "mahasiswa.xml";

        static void Main(string[] args)
        {
            var mahasiswa = new Mahasiswa(
                12345,
                "Budi Santoso",
                "Teknik Informatika",
                new List<string> { "Pemrograman", "Basis Data", "Jaringan" }
            );

            Console.WriteLine("=== OBJEK ASLI ===");
            mahasiswa.TampilkanInfo();

            // ---------- SERIALISASI JSON ----------
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(mahasiswa, jsonOptions);

            // Simpan ke berkas fisik menggunakan stream file
            File.WriteAllText(JsonFile, jsonString);
            Console.WriteLine($"[JSON] Berhasil disimpan ke '{JsonFile}'");
            Console.WriteLine(jsonString);
            Console.WriteLine();

            // ---------- SERIALISASI XML ----------
            string xmlString = SerializeToXml(mahasiswa);

            // Simpan ke berkas fisik menggunakan stream file
            File.WriteAllText(XmlFile, xmlString);
            Console.WriteLine($"[XML] Berhasil disimpan ke '{XmlFile}'");
            Console.WriteLine(xmlString);
            Console.WriteLine();

            // ---------- DESERIALISASI JSON (BACA DARI FILE) ----------
            string jsonDariFile = File.ReadAllText(JsonFile);
            Mahasiswa? mahasiswaDariJson =
                JsonSerializer.Deserialize<Mahasiswa>(jsonDariFile, jsonOptions);

            Console.WriteLine("=== HASIL DESERIALISASI JSON (DARI FILE) ===");
            mahasiswaDariJson?.TampilkanInfo();

            // ---------- DESERIALISASI XML (BACA DARI FILE) ----------
            string xmlDariFile = File.ReadAllText(XmlFile);
            Mahasiswa? mahasiswaDariXml = DeserializeFromXml(xmlDariFile);

            Console.WriteLine("=== HASIL DESERIALISASI XML (DARI FILE) ===");
            mahasiswaDariXml?.TampilkanInfo();

            // ---------- VERIFIKASI ----------
            bool jsonSama = SamaDengan(mahasiswa, mahasiswaDariJson);
            bool xmlSama = SamaDengan(mahasiswa, mahasiswaDariXml);

            Console.WriteLine($"Verifikasi JSON : {(jsonSama ? "SAMA PERSIS" : "BERBEDA")}");
            Console.WriteLine($"Verifikasi XML  : {(xmlSama ? "SAMA PERSIS" : "BERBEDA")}");
        }

        static string SerializeToXml(Mahasiswa mahasiswa)
        {
            var serializer = new XmlSerializer(typeof(Mahasiswa));
            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, mahasiswa);
            return stringWriter.ToString();
        }

        static Mahasiswa? DeserializeFromXml(string xmlString)
        {
            var serializer = new XmlSerializer(typeof(Mahasiswa));
            using var stringReader = new StringReader(xmlString);
            return serializer.Deserialize(stringReader) as Mahasiswa;
        }

        static bool SamaDengan(Mahasiswa asli, Mahasiswa? hasil)
        {
            if (hasil is null) return false;

            return asli.NIM == hasil.NIM
                && asli.Nama == hasil.Nama
                && asli.Jurusan == hasil.Jurusan
                && asli.MataKuliah.SequenceEqual(hasil.MataKuliah);
        }
    }
}
