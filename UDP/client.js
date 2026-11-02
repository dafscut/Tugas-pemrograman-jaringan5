const dgram = require('dgram');

// Membuat socket UDP (udp4 = IPv4)
const client = dgram.createSocket('udp4');
const PORT = 41234;
const HOST = '127.0.0.1';

const pesan = Buffer.from('Halo Server, ini pesan via UDP!');

client.send(pesan, PORT, HOST, (err) => {
  if (err) {
    console.error(err);
    client.close();
    return;
  }
  console.log(`[Client] Pesan terkirim ke ${HOST}:${PORT} -> ${pesan}`);
});

// Terima balasan dari server
client.on('message', (msg, rinfo) => {
  console.log(`[Client] Balasan dari ${rinfo.address}:${rinfo.port} -> ${msg}`);
  client.close();
});

client.on('error', (err) => {
  console.error(`[Client] Error: ${err.stack}`);
  client.close();
});
