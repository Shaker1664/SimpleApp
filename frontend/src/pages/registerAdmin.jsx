import React, { useState } from "react";
import axios from "../components/base";
import cookie from "react-cookies";
import Nav from "../components/nav";

function RegisterAdmin(props) {
  const [username, changeUserName] = useState("");
  const [email, changeEmail] = useState("");
  const [passWord, changePassWord] = useState("");

  const onSubmit = async (e) => {
    e.preventDefault();
    const payload = {
      username: username,
      email: email,
      password: passWord,
    };
    const url = "/authentication/register";
    const response = await axios.post(url, payload);
    // cookie.save("token", response.data.token, { path: "/" });
    props.history.push("/");
  };

  return (
    <div>
      <Nav />
      <div
        className='d-flex align-items-center justify-content-center'
        style={{ height: "100vh" }}
      >
        <div className='p-3 mb-2 bg-primary text-white'>
          <form onSubmit={onSubmit}>
            <div className='form-group'>
              <label for='exampleInputEmail1'>User Name</label>
              <input
                //type='email'
                className='form-control'
                id='exampleInputEmail1'
                aria-describedby='emailHelp'
                placeholder='User Name'
                value={username}
                onChange={(e) => changeUserName(e.target.value)}
              />
            </div>
            <div className='form-group'>
              <label for='exampleInputEmail1'>Email address</label>
              <input
                type='email'
                className='form-control'
                id='exampleInputEmail1'
                aria-describedby='emailHelp'
                placeholder='Email'
                value={email}
                onChange={(e) => changeEmail(e.target.value)}
              />
            </div>
            <div className='form-group'>
              <label for='exampleInputPassword1'>Password</label>
              <input
                type='password'
                className='form-control'
                id='exampleInputPassword1'
                placeholder='Password'
                value={passWord}
                onChange={(e) => changePassWord(e.target.value)}
              />
            </div>
            <div className='py-3'>
              <button type='submit' className='btn btn-secondary'>
                Submit
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default RegisterAdmin;
