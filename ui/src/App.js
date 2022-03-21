import logo from './logo.svg';
import './App.css';
import {
  BrowserRouter,
  Routes,
  Route,
  Outlet,
} from "react-router-dom";
import CarOffers from './components/CarOffers';
import Customers from './components/Customers'
import { NavigationBar } from './NavigationBar';
import 'bootstrap/dist/css/bootstrap.min.css';

function MainLayout() {
  return (
    <div className="App">
      <NavigationBar />
      <div className='main-content'>
        <Outlet />
      </div>
    </div>)
}

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<MainLayout />} >
          <Route path="/caroffers" element={<CarOffers />}>
          </Route>
          <Route path="/customers" element={<Customers />}>
          </Route>
          <Route path="/" element={<div>Home</div>}>
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;


