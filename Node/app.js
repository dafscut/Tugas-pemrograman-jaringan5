// SISI PENGIRIM: OOP OBJECT & SERIALISASI

// 1. Objek di Memori Pengirim (Platform-Dependent)
const userObjectPengirim = {
  nama: "Rans",
  foto: "profil_rans.png",
  daftarRiwayat: ["Login", "Beli Buku", "Logout"]
};

console.log("--- DI MEMORI PENGIRIM ---");
console.log("Tipe Data Asli:", typeof userObjectPengirim);
console.log("Isi Nama Objek:", userObjectPengirim.nama);

// 2. PROSES SERIALISASI (Mengubah objek menjadi format teks JSON agar bisa ditransmisikan)
const dataStreamText = JSON.stringify(userObjectPengirim);

console.log("--- DATA DI STREAM TRANSMISI (Bebas Platform) ---");
console.log("Format Teks yang Mengalir di Jaringan:", dataStreamText);
console.log("Tipe Data Sekarang:", typeof dataStreamText); // Berubah jadi string/teks

// SISI PENERIMA: DESERIALISASI

// 3. PROSES DESERIALISASI (Menyusun kembali teks JSON dari jaringan menjadi objek utuh di memori penerima)
const userObjectPenerima = JSON.parse(dataStreamText);

console.log("--- DI MEMORI PENERIMA ---");
console.log("Tipe Data Setelah Dirakit Kembali:", typeof userObjectPenerima);
console.log("Isi Nama Objek yang Diterima:", userObjectPenerima.nama);
