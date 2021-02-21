import { BrowserRouter, Route, Switch } from "react-router-dom";
import LoginPage from './pages/login'
import RegisterPage from './pages/register'
import RegisterAdminPage from './pages/registerAdmin'
import PrivateRoute from './components/privateRoute'
import HomePage from './pages/home';
import UserPage from './pages/users';
import AddUserPage from './pages/addUser';
import ProductPage from './pages/addProduct'
import pageNotFound from "./pages/pageNotFound";

function App() {
  return (
    <BrowserRouter>
    <Switch>
      <Route path="/register" component={RegisterPage} />
      <Route path="/login" component={LoginPage} />
      <Route path="/register-admin" component={RegisterAdminPage} />
      <PrivateRoute path='/' exact component = {HomePage} />
      <PrivateRoute path='/user' exact component = {UserPage} />
      <PrivateRoute path='/user' exact component = {AddUserPage} />
      <PrivateRoute path='/product' exact component = {ProductPage} />
      <Route component={pageNotFound} />
    </Switch>
    </BrowserRouter>
  );
}

export default App;
