import { useEffect, useState } from 'react';
import type { Bowler } from '../types/bowler';

function BowlerTable() {
  // start with an empty array, we'll fill it once the data loads from the API
  const [bowlers, setBowlers] = useState<Bowler[]>([]);

  // useEffect with empty [] means this only runs once when the component first loads
  // without the [] it would run on every render and hammer the server with requests
  useEffect(() => {
    const fetchBowlers = async () => {
      const response = await fetch('/api/bowlers');
      const data = await response.json();
      setBowlers(data);
    };

    fetchBowlers();
  }, []);

  return (
    <table border={1} cellPadding={8}>
      <thead>
        <tr>
          <th>Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        {/* loop through each bowler and render a row for them */}
        {bowlers.map((b, i) => (
          <tr key={i}>
            <td>
              {/* only show the middle initial and period if the bowler actually has one */}
              {b.bowlerFirstName}{' '}
              {b.bowlerMiddleInit ? `${b.bowlerMiddleInit}. ` : ''}
              {b.bowlerLastName}
            </td>
            <td>{b.teamName}</td>
            <td>{b.bowlerAddress}</td>
            <td>{b.bowlerCity}</td>
            <td>{b.bowlerState}</td>
            <td>{b.bowlerZip}</td>
            <td>{b.bowlerPhoneNumber}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default BowlerTable;
