const express = require('express');
const app = express();
const PORT = 8080;


const sql = require('mssql/msnodesqlv8');

const config1 = {
  server: 'localhost',
  connectionString:
    'Driver={ODBC Driver 18 for SQL Server};' +
    'Server=localhost;' +
    'Database=expenses;' +
    'Trusted_Connection=Yes;' +
    'Encrypt=Yes;' +
    'TrustServerCertificate=Yes;',
  requestTimeout: 5000
};
(async () => {
    try {
        await sql.connect(config1);
    } catch (err) {
        console.error(err)
    }
})();

app.use(express.json());


app.get('/api',
    (req, res) => {
        res.status(200).send({
            "apiVersion": "1.0.0"
        });
    }
);

app.get(
    '/api/users',
    async (req, res) => {
        try {
            const result = await sql.query`select * from users`;

            res.status(200).send(result);
        }
        catch{
            
            res.status(500).send({ "error": "go to the devs house and ask him to turn the server bck on (11324 vinces rd, harrisville NY, 20566)" })
        }
    } 
)

/*
app.post('/api/:version', 
    (req, res) => {
        const { version } = req.params;
        const body = req.body;

        if (!body) {
            res.status(418).send('YOU SHALL NOT PASS')
        }

        res.status(200).send({
            "apiVersion": version
        });
    }
)
*/


app.listen(
    PORT,
    () => console.log(`hello, hello, hello http://127.0.0.1:${PORT}`)
);