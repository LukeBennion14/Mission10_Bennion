import { useEffect, useState } from 'react'

interface Bowler {
  bowlerFirstName: string
  bowlerMiddleInit: string
  bowlerLastName: string
  teamName: string
  bowlerAddress: string
  bowlerCity: string
  bowlerState: string
  bowlerZip: string
  bowlerPhoneNumber: string
}

function BowlerTable() {
  const [bowlers, setBowlers] = useState<Bowler[]>([])

  useEffect(() => {
    fetch('/api/bowlers')
      .then((res) => res.json())
      .then((data) => setBowlers(data))
  }, [])

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
        {bowlers.map((b, i) => (
          <tr key={i}>
            <td>{b.bowlerFirstName} {b.bowlerMiddleInit}. {b.bowlerLastName}</td>
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
  )
}

export default BowlerTable
