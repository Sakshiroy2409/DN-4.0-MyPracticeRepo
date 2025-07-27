import styles from './CohortDetails.module.css';

function CohortDetails({ name, status }) {
  const titleColor = {
    color: status === 'ongoing' ? 'green' : 'blue'
  };

  return (
    <div className={styles.box}>
      <h3 style={titleColor}>Cohort Status: {status}</h3>
      <dl>
        <dt>Name:</dt>
        <dd>{name}</dd>
      </dl>
    </div>
  );
}

export default CohortDetails;