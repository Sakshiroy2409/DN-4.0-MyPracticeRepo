import React from 'react';

function UserPage() {
  return (
    <div>
      <h2>Welcome, User!</h2>
      <p>You can now book your tickets.</p>
      <ul>
        <li>
          ✈️ Delhi → Mumbai
          <button style={{ marginLeft: '10px' }}>Book</button>
        </li>
        <li>
          ✈️ Bangalore → Chennai
          <button style={{ marginLeft: '10px' }}>Book</button>
        </li>
        <li>
          ✈️ Kolkata → Pune
          <button style={{ marginLeft: '10px' }}>Book</button>
        </li>
      </ul>
    </div>
  );
}

export default UserPage;