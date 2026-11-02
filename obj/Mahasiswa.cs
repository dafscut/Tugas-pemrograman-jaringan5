using System;

namespace PraktikumStream
{
    // Serializable diperlukan khusus untuk beberapa library XML lama,
    // namun baik untuk pendefinisian data contract
    [Serializable]
    public class Mahasiswa
    {
        public int NIM { get; set; }
        public string Nama { get; set; }
        public string Jurusan { get; set; }
        public List<string> MataKuliah { get; set; }

        // Constructor kosong wajib ada untuk proses Deserialisasi XML
        public Mahasiswa() { }

        public Mahasiswa(int nim, string nama, string jurusan, List<string> matkul)
        {
            NIM = nim;
            Nama = nama;
            Jurusan = jurusan;
            MataKuliah = matkul;
        }

        public void TampilkanInfo()
        {
            Console.WriteLine($"NIM     : {NIM}");
            Console.WriteLine($"Nama    : {Nama}");
            Console.WriteLine($"Jurusan : {Jurusan}");
            Console.WriteLine($"Matkul  : {string.Join(", ", MataKuliah)}");
            Console.WriteLine("---------------------------------------------");
        }
    }
}