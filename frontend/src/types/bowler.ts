// defines the shape of a bowler object coming back from the API
// note: property names are camelCase (lowercase first letter) because that's how
// .NET serializes JSON - if you capitalize them they won't match and you'll get undefined everywhere
export interface Bowler {
  bowlerFirstName: string;
  bowlerMiddleInit: string;
  bowlerLastName: string;
  teamName: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
}
