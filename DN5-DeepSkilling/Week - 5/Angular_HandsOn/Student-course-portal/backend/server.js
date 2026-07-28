const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');

const app = express();
app.use(cors());
const port = 3001;

const mongoUri = 'mongodb+srv://231fa04c91r_db_user:FIj0B52D2S3Z3sjH@cognizantdn5.kc9g7ot.mongodb.net/';

mongoose.connect(mongoUri, { useNewUrlParser: true, useUnifiedTopology: true })
  .then(() => console.log('MongoDB connected'))
  .catch(err => console.log(err));

const courseSchema = new mongoose.Schema({
  name: String,
  code: String,
  credits: Number,
  gradeStatus: String
});

const Course = mongoose.model('Course', courseSchema);

app.get('/api/courses', async (req, res) => {
  try {
    const courses = await Course.find();
    res.json(courses);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
});

app.listen(port, () => {
  console.log(`Server is running on port: ${port}`);
});
