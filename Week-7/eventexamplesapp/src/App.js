import React from 'react';
import CurrencyConvertor from './CurrencyConvertor';

function App() {
  let count = 0;

  const increment = () => {
    count++;
    console.log('Count:', count);
    alert(`Count is now ${count}`);
  };

  const sayHello = () => {
    console.log("Hello, welcome to Event Handling in React!");
    alert("Hello from React!");
  };

  const handleMultiple = () => {
    increment();
    sayHello();
  };

  const sayWelcome = (message) => {
    alert("Message: " + message);
  };

  const handleClick = (e) => {
    console.log("Synthetic event: ", e);
    alert("I was clicked");
  };

  return (
    <div style={{ textAlign: 'center' }}>
      <h1>🎯 React Event Handling Lab</h1>

      <button onClick={handleMultiple}>Increment & Say Hello</button>
      <br /><br />

      <button onClick={() => sayWelcome("Welcome to the app!")}>Say Welcome</button>
      <br /><br />

      <button onClick={handleClick}>Synthetic Event Button</button>
      <br /><br />

      <CurrencyConvertor />
    </div>
  );
}

export default App;