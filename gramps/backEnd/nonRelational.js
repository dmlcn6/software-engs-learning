expenses> db.createCollection("users")

expenses> db.users.insertOne({"name": "users1", "income":500, "id": 1, "occupation":"Plumber"})

expenses> db.createCollection("services")

expenses> db.services.insertOne({"id": 1, "name":"Netflix", "category":"Entertainment", "price": 300})

expenses> db.users.updateMany({}, {$set: {services:[]}})

expenses> db.users.updateOne({id: 1}, {$set: {services:[1]}})
