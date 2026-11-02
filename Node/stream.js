const fs = require('fs');

// 1. Membuat Readable Stream (Aliran data masuk dari file besar)
const readStream = fs.createReadStream('input_besar.txt', {
  encoding: 'utf8',
  highWaterMark: 16 * 1024 // Ukuran buffer diatur 16 KB per aliran data
});

// 2. Membuat Writable Stream (Aliran data keluar ke file tujuan)
const writeStream = fs.createWriteStream('output_salinan.txt');

// 3. Mengalirkan data (Proses Read & Write Stream berjalan bersamaan)
// Data dialirkan sedikit demi sedikit melalui buffer tanpa memuat seluruh isi file ke RAM
readStream.pipe(writeStream);

// Mengamati jalannya stream lewat event (Opsional)
readStream.on('data', (chunk) => {
  console.log(`[Penerimaan] Menerima data sebesar: ${chunk.length} karakter ke dalam buffer.`);
});

writeStream.on('finish', () => {
  console.log('Proses Stream Selesai! Data berhasil disalin penuh.');
});
