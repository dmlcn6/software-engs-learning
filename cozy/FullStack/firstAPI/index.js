const express = require('express');
const app = express();
const PORT = 8000;

const sql = require('mssql/msnodesqlv8');

const pool = {
  server: "localhost",
  database: "expenses",
  options: {
    trustedConnection: true, // Set to true if using Windows Authentication
    trustServerCertificate: true, // Set to true if using self-signed certificates
  },
   driver: "ODBC Driver 18 for SQL Server", // Uncomment to use specific driver
};

const config1 = {
  server: 'localhost',
  connectionString:
    'Driver={ODBC Driver 18 for SQL Server};' +
    'Server=localhost;' +
    'Database=expenses;' +
    'Trusted_Connection=Yes;' +
    'Encrypt=Yes;' +
    'TrustServerCertificate=Yes;',
  requestTimeout: 30000
};

(async () => {
  try {
    await sql.connect(config1);
    const result = await sql.query`select * from services`;
    console.dir(result);
  } catch (err) {
    console.dir(err);
  }
  finally {
  
  }
})();

app.use(express.json())

app.get('/bingbong',
    (req, res) => {
        res.status(200).send({
            "apiVersion": "1.0.0"
        });
    }
);

app.get(
  '/api/users',
  async (req, res) => {
    try{
      const result = await sql.query`select * from users`;

      res.status(200).send(result);
    }
    catch (error) {
      // log to internal logs
      // log stack trace
      // show generic message to users
      // wont expose data/paths/stack trace
      res.status(500).send({"error": "server not responding"})
    }
  }
);

//post call for api/id
app.post('/bingbong/:id', (req, res) => {

    const {id} = req.params;
    const body = req.body;

    if (!body) {
        res.status(418).send('Get an espresso machine, brokey')
    }

    res.status(200).send({
        "apiVersion": id
    });
    }
);

app.listen(PORT, () => console.log(`We got action on http://localhost:${PORT}`));