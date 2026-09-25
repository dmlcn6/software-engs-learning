const express = require('express');
const app = express();
const PORT = 8000;

app.use(express.json())

app.get('/bingbong',
    (req, res) => {
        res.status(200).send({
            "apiVersion": "1.0.0"
        });
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