import React from 'react';

const IndianPlayers = () => {
  const T20players = ['Kohli', 'Rohit', 'Pandya', 'Gill', 'Pant'];
  const RanjiPlayers = ['Pujara', 'Iyer', 'Sundar', 'Jurel', 'Unadkat'];

  // Merge arrays
  const allPlayers = [...T20players, ...RanjiPlayers];

  // Destructuring odd and even players
  const oddPlayers = allPlayers.filter((_, i) => i % 2 === 0);
  const evenPlayers = allPlayers.filter((_, i) => i % 2 !== 0);

  return (
    <div>
      <h2>⚡ Indian Players</h2>
      <h3>Odd Team Players</h3>
      <ul>
        {oddPlayers.map((name, index) => (
          <li key={index}>{name}</li>
        ))}
      </ul>
      <h3>Even Team Players</h3>
      <ul>
        {evenPlayers.map((name, index) => (
          <li key={index}>{name}</li>
        ))}
      </ul>
    </div>
  );
};

export default IndianPlayers;