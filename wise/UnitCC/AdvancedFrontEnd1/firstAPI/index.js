const express = require('express');
const app = express();
const PORT = 8080;


const sql = require('mssql/msnodesqlv8');


    
const pool = {
    server: 'localhost',
    database: 'expenses',
    options: {
        trustedConnection: true, // Set to true if using Windows Authentication
        trustServerCertificate: true, // Set to true if using self-signed certificates
    },
    driver: "ODBC Driver 18 for SQL Server", // Uncomment to use specific driver
};
    
(async () => {
    try {
        // make sure that any items are correctly URL encoded in the connection string
        await sql.connect(pool)
        const result = await sql.query`select * from services`
        console.dir(result)
    } catch (err) {
         console.dir(err)
    }
})()


app.use(express.json());


app.listen(
    PORT, () => console.log(`hello http://127.0.0.1:${PORT}`)
);

app.get('/api', 
    (req, res) => {
        res.status(200).send({
            "apiVersion": "1.0.0"
        });
    }
)

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
