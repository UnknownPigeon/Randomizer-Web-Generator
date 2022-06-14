// const path = require('path');
// const cors = require('cors');
// const express = require('express');

// const app = express(); // create express app
// app.use(cors());

// const bodyParser = require('body-parser');
// app.use(bodyParser.json());

// // add middlewares
// const root = require('path').join(__dirname, 'build');
// app.use(express.static(root));

// app.use('/*', (req, res) => {
//   res.sendFile(path.join(__dirname, 'build', 'index.html'));
// });

// // start express server on port 5000
// app.listen(process.env.PORT || 5000, () => {
//   console.log('server started');
// });

if (process.env.NODE_ENV === 'production') {
  require('dotenv').config();
} else {
  require('dotenv').config({
    path: '.env.development',
  });
}
console.log(process.env);

const { initConfig, resolveRootPath, resolveOutputPath } = require('./config');
initConfig();

const url = require('url');
const fs = require('fs');
const path = require('path');
const cors = require('cors');
const express = require('express');
const spawn = require('cross-spawn');
const {
  callGenerator,
  callGeneratorMatchOutput,
  callGeneratorBuf,
} = require('./util');
const { normalizeStringToMax128Bytes } = require('./util/string');

const app = express(); // create express app
app.use(cors());

const bodyParser = require('body-parser');
app.use(bodyParser.json());

let root;
let indexHtmlPath;

// add middlewares
if (process.env.NODE_ENV === 'production') {
  root = path.join(__dirname, '..', 'client', 'build');
  indexHtmlPath = path.join(__dirname, '..', 'client', 'build', 'index.html');
} else {
  // root = path.join(__dirname, 'build');
  // indexHtmlPath = path.join(__dirname, 'build', 'index.html');

  // root = path.join(__dirname, 'packages', 'client');
  // indexHtmlPath = path.join(__dirname, 'packages', 'client', 'index.html');

  const rootDir = resolveRootPath();

  root = path.join(rootDir, 'packages', 'client');
  indexHtmlPath = path.join(root, 'index.html');
}

app.post('/api/generateseed', function (req, res) {
  const { settingsString, seed } = req.body;

  if (!settingsString || typeof settingsString !== 'string') {
    res.status(400).send({ error: 'Malformed request.' });
    return;
  }

  if (seed && typeof seed !== 'string') {
    res.status(400).send({ error: 'Malformed request.' });
    return;
  }

  const seedStr = seed ? normalizeStringToMax128Bytes(seed) : '';
  console.log(`seedStr: '${seedStr}'`);

  callGeneratorMatchOutput(
    ['generate2', settingsString, seedStr],
    (error, data) => {
      if (error) {
        res.status(500).send({ error });
      } else {
        res.send({ data: { id: data } });
      }
    }
  );
});

app.post('/api/final', function (req, res) {
  const { referer } = req.headers;

  const { query } = url.parse(referer, true);

  const { id } = query;

  if (!id) {
    res.status(400).send({ error: 'Bad referer.' });
    return;
  }

  if (typeof id !== 'string' || !/^[0-9a-z-_]+$/i.test(id)) {
    res.status(400).send({ error: 'Invalid id format.' });
    return;
  }

  const { fileCreationSettings } = req.body;

  if (
    !fileCreationSettings ||
    typeof fileCreationSettings !== 'string' ||
    !/^[0-9a-z-_]+$/i.test(fileCreationSettings)
  ) {
    res.status(400).send({ error: 'Invalid fileCreationSettings format.' });
    return;
  }

  callGeneratorBuf(
    ['generate_final_output2', id, 'aBc', fileCreationSettings],
    (error, buffer) => {
      if (error) {
        res.status(500).send({ error });
        return;
      }

      try {
        const index = buffer.indexOf('BYTES:', 0);

        let currIndex = index;
        if (currIndex < 0) {
          res.status(500).send({ error: 'Failed to find BYTES:' });
          return;
        }

        currIndex += 'BYTES:'.length;
        const jsonLen = parseInt(
          buffer.toString('utf8', currIndex, currIndex + 8),
          16
        );
        currIndex += 8;

        const json = JSON.parse(
          buffer.toString('utf8', currIndex, currIndex + jsonLen)
        );
        currIndex += jsonLen;

        const data = [];
        json.forEach(({ name, length }) => {
          data.push({
            name,
            length,
            bytes: buffer
              .subarray(currIndex, currIndex + length)
              .toString('base64'),
          });
          currIndex += length;
        });

        res.send({ data });
      } catch (e) {
        res.status(500).send({ error: e.message });
      }
    }
  );
});

app.get('/api/creategci', function (req, res) {
  const { referer } = req.headers;

  const { query } = url.parse(referer, true);

  const { id } = query;

  if (!id) {
    res.status(400).send({ error: 'Bad referer.' });
    return;
  }

  const filePath = resolveOutputPath(`seeds/${id}/input.json`);
  if (fs.existsSync(filePath)) {
    const ff = fs.readFileSync(filePath);
    const json = JSON.parse(ff);
    res.send({ data: json });
  } else {
    res.status(404).send({
      error: 'Did not find seed data for provided id.',
    });
  }
});

app.get('/', (req, res) => {
  fs.readFile(indexHtmlPath, function read(err, data) {
    if (err) {
      console.log(err);
      res.status(500).send({ error: 'Internal server error.' });
    } else {
      const excludedChecksList = JSON.parse(callGenerator('print_check_ids'));
      const arr = Object.keys(excludedChecksList).map((key) => {
        return `<li><label><input type='checkbox' data-checkId='${excludedChecksList[key]}'>${key}</label></li>`;
      });

      let msg = data.toString();
      msg = msg.replace('<!-- CHECK_IDS -->', arr.join('\n'));

      const startingItems = [
        [63, 'Progressive Sword'],
        [63, 'Progressive Sword'],
        [63, 'Progressive Sword'],
        [63, 'Progressive Sword'],
        [64, 'Boomerang'],
        [72, 'Lantern'],
        [75, 'Slingshot'],
        [74, 'Progressive Fishing Rod'],
        [74, 'Progressive Fishing Rod'],
        [69, 'Iron Boots'],
        [67, 'Progressive Bow'],
        [81, 'Bomb Bag and Bombs'],
        [49, 'Zora Armor'],
        [68, 'Progressive Clawshot'],
        [68, 'Progressive Clawshot'],
        [50, 'Shadow Crystal'],
        [144, 'Aurus Memo'],
        [145, 'Asheis Sketch'],
        [65, 'Spinner'],
        [66, 'Ball and Chain'],
        [70, 'Progressive Dominion Rod'],
        [70, 'Progressive Dominion Rod'],
        [233, 'Progressive Sky Book'],
        [233, 'Progressive Sky Book'],
        [233, 'Progressive Sky Book'],
        [233, 'Progressive Sky Book'],
        [233, 'Progressive Sky Book'],
        [233, 'Progressive Sky Book'],
        [233, 'Progressive Sky Book'],
        [132, 'Horse Call'],
        [243, 'Gate Keys'],
        [96, 'Empty Bottle'],
      ];

      const startingItemsEls = startingItems.map((item) => {
        return `<li><label><input type='checkbox' data-itemId='${item[0]}'>${item[1]}</label> </li>`;
      });

      msg = msg.replace('<!-- STARTING_ITEMS -->', startingItemsEls.join('\n'));

      res.send(msg);
    }
  });
});

const escapeHtml = (str) =>
  str.replace(
    /[&<>'"]/g,
    (tag) =>
      ({
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        "'": '&#39;',
        '"': '&quot;',
      }[tag])
  );

app.get('/seed', (req, res) => {
  fs.readFile(path.join(root, 'getseed.html'), function read(err, data) {
    if (err) {
      console.log(err);
      res.status(500).send({ error: 'Internal server error.' });
    } else {
      let msg = data.toString();

      const { id } = req.query;

      // const filePath = path.join(__dirname, `seeds/${id}/input.json`);
      const filePath = resolveOutputPath(`seeds/${id}/input.json`);

      if (fs.existsSync(filePath)) {
        const json = JSON.parse(fs.readFileSync(filePath));
        json.seedHash = undefined;
        json.itemPlacement = undefined;
        const fileContents = escapeHtml(JSON.stringify(json));

        msg = msg.replace(
          '<!-- INPUT_JSON_DATA -->',
          `<input id='inputJsonData' type='hidden' value='${fileContents}'>`
        );
      }

      res.send(msg);
    }
  });
});

app.use(express.static(root));

app.use(function (req, res, next) {
  res.status(404);

  const accepts = req.accepts(['text/html', 'application/json']);

  if (accepts === 'applicaton/json') {
    res.json({ error: 'Not found' });
  } else {
    res.type('txt').send('Not found');
  }
});

// start express server on port 5000
app.listen(process.env.PORT || 5000, () => {
  console.log('server started');
});
