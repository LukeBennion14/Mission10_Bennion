import Heading from './components/Heading';
import BowlerTable from './components/BowlerTable';
import './App.css';

// main App component - just puts the heading and table together on the page
function App() {
  return (
    <>
      <Heading />
      <BowlerTable />
    </>
  );
}

export default App;
