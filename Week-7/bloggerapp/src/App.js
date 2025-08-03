import React, { useState } from 'react';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';
import CourseDetails from './CourseDetails';

function App() {
  const [view, setView] = useState('book'); // book | blog | course

  return (
    <div style={{ textAlign: 'center' }}>
      <h1>📚 Blogger App</h1>

      <div>
        <button onClick={() => setView('book')}>Book Details</button>
        <button onClick={() => setView('blog')}>Blog Details</button>
        <button onClick={() => setView('course')}>Course Details</button>
      </div>

      <hr />

      {view === 'book' && <BookDetails />}
      {view === 'blog' && <BlogDetails />}
      {view === 'course' && <CourseDetails />}
    </div>
  );
}

export default App;