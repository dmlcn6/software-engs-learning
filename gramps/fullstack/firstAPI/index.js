
const express = require('express');
const app = express();
const PORT = 8000;


const sql = require('mssql/msnodesqlv8');

const config = {
  server: "localhost",
  database: "expenses",
  options: {
    trustedConnection: true, // Set to true if using Windows Authentication
    trustServerCertificate: true, // Set to true if using self-signed certificates
  },
    driver: 'msnodesqlv8',
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
    const result = await sql.query`select * from users`;
    console.dir(result);
  } catch (err) {
    console.error(err);
  }
})();



app.use(express.json());

app.get(
    '/api',
    (req, res) => {
        res.status(200).send({
            "apiVersion": "1.0.0"
        });
    }
);


// post call for api/version
app.post(
    '/api/:version', 
    (req, res) => {
        // grabs version from url params
        const {version} = req.params;

        // grabs body from request
        const body = req.body;

        // if body is null, uhoh
        if (!body) {
            res.status(418).send('lil T pot')
        }

        // else send OK
        res.status(200).send({
            "apiVersion": version
        })
    }
);

app.listen(
    PORT, 
    () => console.log(`hello from http://127.0.0.1:${PORT}`)
);

