import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./components/pages/Home";
import Search from "./components/pages/Search";
import Random from "./components/pages/Random";
import Error from "./Error";
import Header from "./components/Header";
import "./App.css";

function App() {
  return (
    <Router>
      <div className="App">
        <Header />
        <Routes>
          <Route exact path="/" element={<Home />} />

          <Route exact path="/search" element={<Search />} />

          <Route exact path="/random" element={<Random />} />

          <Route path="*" element={<Error />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
