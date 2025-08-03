import React from 'react';

function BlogDetails() {
  const blogs = [
    { id: 'b1', title: 'Getting Started with React', date: '2023-06-10' },
    { id: 'b2', title: 'JSX Tips and Tricks', date: '2023-06-15' },
    { id: 'b3', title: 'React Hooks Deep Dive', date: '2023-06-20' }
  ];

  return (
    <div>
      <h2>📝 Blog Articles</h2>
      <ul>
        {blogs.map((blog) => (
          <li key={blog.id}>
            <strong>{blog.title}</strong> — <em>{blog.date}</em>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default BlogDetails;