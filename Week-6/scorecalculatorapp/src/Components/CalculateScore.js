import '../Stylesheets/mystyle.css';

function CalculateScore() {
  const name = "Alice";
  const school = "High School";
  const total = 450;
  const goal = 500;
  const avg = total / 5;

  return (
    <div className="score-box">
      <h2>{name} from {school}</h2>
      <p>Total Marks: {total}</p>
      <p>Goal: {goal}</p>
      <p>Average Score: {avg}</p>
    </div>
  );
}

export default CalculateScore;