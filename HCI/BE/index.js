const express = require('express'),
  process = require('./requests/process');
  var cors = require('cors');

const app = express();
const port = 3000;

app.use(cors());
app.use('/process', process);

app.listen(port, () => {
  console.log(`Started listening at http://localhost:${port}`)
});