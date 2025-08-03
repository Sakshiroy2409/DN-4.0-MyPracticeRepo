import React from 'react';

function CourseDetails() {
  const courses = [
    { id: 101, name: 'React Basics', duration: '4 weeks' },
    { id: 102, name: 'Advanced React', duration: '6 weeks' },
    { id: 103, name: 'React + Redux', duration: '5 weeks' }
  ];

  return (
    <div>
      <h2>🎓 Course Offerings</h2>
      <ul>
        {courses.map((course) => (
          <li key={course.id}>
            <strong>{course.name}</strong> — {course.duration}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default CourseDetails;