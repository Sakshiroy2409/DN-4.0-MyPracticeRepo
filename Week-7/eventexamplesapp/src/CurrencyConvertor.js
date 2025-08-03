import React, { useState } from 'react';

function CurrencyConvertor() {
  const [inr, setInr] = useState('');
  const [euro, setEuro] = useState('');

  const handleSubmit = () => {
    if (!inr || isNaN(inr)) {
      alert("Please enter a valid number");
      return;
    }

    const result = (parseFloat(inr) / 90).toFixed(2); // Assuming 1 Euro ≈ ₹90
    setEuro(result);
  };

  return (
    <div>
      <h2>💱 Currency Convertor</h2>
      <input
        type="text"
        placeholder="Enter amount in INR"
        value={inr}
        onChange={(e) => setInr(e.target.value)}
      />
      <br /><br />
      <button onClick={handleSubmit}>Convert to Euro</button>
      <br /><br />
      {euro && <p>€ {euro}</p>}
    </div>
  );
}

export default CurrencyConvertor;