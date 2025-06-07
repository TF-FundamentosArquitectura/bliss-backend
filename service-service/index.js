// === Cómo probar este microservicio ===
// 1. Instala las dependencias:
//    npm install
// 2. Inicia este servicio:
//    node index.js
// 3. Crea un servicio:
//    curl -X POST http://localhost:3020/api/v1/services -H "Content-Type: application/json" -d "{\"companyId\":1,\"categoryId\":2,\"name\":\"Corte de Cabello\",\"description\":\"Servicio de corte profesional\",\"price\":50,\"duration\":30,\"imageUrl\":\"https://ejemplo.com/imagen.jpg\"}"
// =======================================

const express = require('express');
const cors = require('cors');
const mysql = require('mysql2/promise');
const app = express();
const PORT = 3020;

app.use(cors());
app.use(express.json());

const dbConfig = {
  host: 'localhost',
  user: 'root',
  password: 'password',
  database: 'bliss'
};

const router = express.Router();

router.post('/services', async (req, res) => {
  const {
    companyId,
    categoryId,
    name,
    description,
    price,
    duration,
    imageUrl
  } = req.body;

  // Validación básica
  if (
    companyId === undefined ||
    categoryId === undefined ||
    !name ||
    !description ||
    price === undefined ||
    duration === undefined ||
    !imageUrl
  ) {
    return res.status(400).json({ error: 'All fields are required: companyId, categoryId, name, description, price, duration, imageUrl' });
  }

  // Asignar valores por defecto a rating y sales
  const rating = 0;
  const sales = 0;

  try {
    const connection = await mysql.createConnection(dbConfig);

    // Verificar existencia de categoryId en categories
    const [categoryRows] = await connection.execute(
      `SELECT id FROM categories WHERE id = ?`,
      [categoryId]
    );
    if (categoryRows.length === 0) {
      await connection.end();
      return res.status(400).json({ error: `Category with id ${categoryId} does not exist` });
    }

    // Verificar existencia de companyId en companies
    const [companyRows] = await connection.execute(
      `SELECT id FROM companies WHERE id = ?`,
      [companyId]
    );
    if (companyRows.length === 0) {
      await connection.end();
      return res.status(400).json({ error: `Company with id ${companyId} does not exist` });
    }

    const [result] = await connection.execute(
      `INSERT INTO services (company_id, category_id, name, description, price, duration, image_url, rating, sales, created_at, updated_at)
       VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, NOW(), NOW())`,
      [companyId, categoryId, name, description, price, duration, imageUrl, rating, sales]
    );
    const insertedId = result.insertId;
    await connection.end();

    res.status(201).json({
      id: insertedId,
      companyId,
      categoryId,
      name,
      description,
      price,
      duration,
      imageUrl,
      rating,
      sales
    });
  } catch (err) {
    console.error('DB Error:', err);
    res.status(500).json({ error: 'Database error', details: err.message });
  }
});

app.use('/api/v1', router);

app.listen(PORT, () => {
  console.log(`Service Service running on port ${PORT}`);
});