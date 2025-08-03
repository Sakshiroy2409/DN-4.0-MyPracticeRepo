import React from 'react';

function App() {
  // Single object
  const featuredOffice = {
    name: 'Workspace Hub',
    rent: 55000,
    address: 'MG Road, Bengaluru'
  };

  // List of offices
  const officeList = [
    { name: 'Startup Studio', rent: 45000, address: 'Koramangala' },
    { name: 'InnovateHub', rent: 75000, address: 'Indiranagar' },
    { name: 'The Foundry', rent: 62000, address: 'HSR Layout' },
    { name: 'WorkNest', rent: 30000, address: 'Whitefield' }
  ];

  // Style generator for rent
  const getRentStyle = (rent) => {
    return {
      color: rent < 60000 ? 'red' : 'green',
      fontWeight: 'bold'
    };
  };

  return (
    <div style={{ textAlign: 'center' }}>
      <h1>🏢 Office Space Rental</h1>

      <h2>Featured Office</h2>
      <img
        src="https://via.placeholder.com/300x200"
        alt="Office"
        style={{ borderRadius: '10px' }}
      />
      <p><strong>Name:</strong> {featuredOffice.name}</p>
      <p><strong>Rent:</strong> ₹<span style={getRentStyle(featuredOffice.rent)}>{featuredOffice.rent}</span></p>
      <p><strong>Address:</strong> {featuredOffice.address}</p>

      <hr />

      <h2>Available Office Spaces</h2>
      <ul style={{ listStyleType: 'none', padding: 0 }}>
        {officeList.map((office, index) => (
          <li key={index} style={{ margin: '20px 0' }}>
            <p><strong>Name:</strong> {office.name}</p>
            <p><strong>Rent:</strong> ₹<span style={getRentStyle(office.rent)}>{office.rent}</span></p>
            <p><strong>Address:</strong> {office.address}</p>
            <hr />
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;