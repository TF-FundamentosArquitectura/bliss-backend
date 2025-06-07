// === Cómo probar este microservicio ===
// 1. Instala las dependencias:
//    npm install
// 2. Inicia este servicio:
//    node index.js
// 3. Crea una compañía:
//    curl -X POST http://localhost:3040/api/v1/companies -H "Content-Type: application/json" -d "{\"name\":\"Mi Empresa\",\"ruc\":\"12345678901\",\"email\":\"empresa@correo.com\",\"websiteUrl\":\"https://miempresa.com\",\"phoneNumber\":\"987654321\",\"description\":\"Empresa de servicios\"}"
// =======================================

const express = require('express');
const cors = require('cors');
const mysql = require('mysql2/promise');
const app = express();
const PORT = 3040;

app.use(cors());
app.use(express.json());

const dbConfig = {
  host: 'localhost',
  user: 'root',
  password: 'password',
  database: 'bliss'
};

const router = express.Router();

router.post('/companies', async (req, res) => {
  const {
    name,
    ruc,
    email,
    websiteUrl,
    phoneNumber,
    description
  } = req.body;

  if (
    !name ||
    !ruc ||
    !email ||
    !websiteUrl ||
    !phoneNumber ||
    !description
  ) {
    return res.status(400).json({ error: 'All fields are required: name, ruc, email, websiteUrl, phoneNumber, description' });
  }

  try {
    const connection = await mysql.createConnection(dbConfig);
    const [result] = await connection.execute(
      `INSERT INTO companies (name, ruc, email, website_url, phone_number, description, created_at, updated_at)
       VALUES (?, ?, ?, ?, ?, ?, NOW(), NOW())`,
      [name, ruc, email, websiteUrl, phoneNumber, description]
    );
    const insertedId = result.insertId;
    await connection.end();

    res.status(201).json({
      id: insertedId,
      name,
      ruc,
      email,
      websiteUrl,
      phoneNumber,
      description
    });
  } catch (err) {
    console.error('DB Error:', err);
    res.status(500).json({ error: 'Database error', details: err.message });
  }
});

app.use('/api/v1', router);

app.listen(PORT, () => {
  console.log(`Company Service running on port ${PORT}`);
});
