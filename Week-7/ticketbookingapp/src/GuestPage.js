import React from 'react';

function GuestPage() {
  return (
    <div>
      <h2>Welcome, Guest!</h2>
      <p>You can browse flight options, but you need to log in to book tickets.</p>
      <ul>
        <li>✈️ Delhi → Mumbai</li>
        <li>✈️ Bangalore → Chennai</li>
        <li>✈️ Kolkata → Pune</li>
      </ul>
    </div>
  );
}

export default GuestPage;