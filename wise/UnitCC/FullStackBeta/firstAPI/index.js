const express = require('express');
const app = express();
const PORT = 8080;

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
