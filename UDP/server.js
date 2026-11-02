const dgram = require('dgram');

// Membuat socket UDP (udp4 = IPv4)
const server = dgram.createSocket('udp4');
const PORT = 41234;

server.on('message', (msg, rinfo) => {
  console.log(`[Server] Pesan dari ${rinfo.address}:${rinfo.port} -> ${msg}`);

  // Kirim balasan ke pengirim
  const balasan = Buffer.from(`Pesan diterima: ${msg}`);
  server.send(balasan, rinfo.port, rinfo.address, (err) => {
    if (err) {
      console.error(err);
      server.close();
    }
  });
});

server.on('listening', () => {
  const addr = server.address();
  console.log(`[Server] UDP listening di ${addr.address}:${addr.port}`);
});

server.on('error', (err) => {
  console.error(`[Server] Error: ${err.stack}`);
  server.close();
});

server.bind(PORT);
