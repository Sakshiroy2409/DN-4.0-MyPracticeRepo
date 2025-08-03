import React from 'react';

const ListofPlayers = () => {
  const players = [
    { name: 'Virat Kohli', score: 85 },
    { name: 'Rohit Sharma', score: 42 },
    { name: 'Shubman Gill', score: 74 },
    { name: 'MS Dhoni', score: 66 },
    { name: 'Hardik Pandya', score: 95 },
    { name: 'Ravindra Jadeja', score: 55 },
    { name: 'KL Rahul', score: 78 },
    { name: 'Jasprit Bumrah', score: 40 },
    { name: 'Rishabh Pant', score: 81 },
    { name: 'Mohammed Siraj', score: 69 },
    { name: 'Yuzvendra Chahal', score: 31 }
  ];

  const highScorers = players.filter(player => player.score >= 70);

  return (
    <div>
      <h2>🏏 List of Players (Score ≥ 70)</h2>
      <ul>
        {highScorers.map((player, index) => (
          <li key={index}>
            {player.name} - {player.score}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ListofPlayers;