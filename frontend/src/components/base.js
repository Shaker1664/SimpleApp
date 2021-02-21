import axios from "axios";
import cookie from "react-cookies";

axios.defaults.baseURL = 'http://localhost:5000/api'

if (cookie.load("token")) {
  axios.defaults.headers.common = {'Authorization': `bearer ${cookie.load("token")}`}
}

export default axios;
