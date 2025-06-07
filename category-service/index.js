// === Cómo probar este microservicio ===
// 1. Instala las dependencias:
//    npm install
// 2. Inicia este servicio:
//    node index.js
// 3. Crea una categoría:
//    curl -X POST http://localhost:3040/api/v1/categories -H "Content-Type: application/json" -d "{\"name\":\"Corte\",\"description\":\"Servicios de corte de cabello\"}"
// =======================================

const express = require('express');
const cors = require('cors');
const mysql = require('mysql2/promise');
const app = express();
const PORT = 3030;

app.use(cors());
app.use(express.json());

const dbConfig = {
  host: 'localhost',
  user: 'root',
  password: 'password',
  database: 'bliss'
};

const router = express.Router();

router.post('/categories', async (req, res) => {
  const { name, description } = req.body;

  if (!name || !description) {
    return res.status(400).json({ error: 'All fields are required: name, description' });
  }

  try {
    const connection = await mysql.createConnection(dbConfig);
    const [result] = await connection.execute(
      `INSERT INTO categories (name, description, created_at, updated_at) VALUES (?, ?, NOW(), NOW())`,
      [name, description]
    );
    const insertedId = result.insertId;
    await connection.end();

    res.status(201).json({
      id: insertedId,
      name,
      description
    });
  } catch (err) {
    console.error('DB Error:', err);
    res.status(500).json({ error: 'Database error', details: err.message });
  }
});

app.use('/api/v1', router);

app.listen(PORT, () => {
  console.log(`Category Service running on port ${PORT}`);
});
