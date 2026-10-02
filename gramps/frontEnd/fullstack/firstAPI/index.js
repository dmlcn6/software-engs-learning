
const express = require('express');
const app = express();
const PORT = 8000;

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

