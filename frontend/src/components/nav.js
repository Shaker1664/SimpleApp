import React from "react";
import { Link } from "react-router-dom";
import cookie from "react-cookies";
const nav = () => {
  return (
    <div>
      <ul
        style={{
          display: "flex",
          justifyContent: "space-around",
          alignItems: "center",
        }}
      >
        <Link to='/'>
          <li>Home</li>
        </Link>
        <Link to='/login'>
          <li>Login</li>
        </Link>
        <Link to='/register'>
          <li>Register</li>
        </Link>
        <Link to='/register-admin'>
          <li>RegisterAdmin</li>
        </Link>

        <Link to='/product'>
          <li>Create Product</li>
        </Link>

        <Link to='/user'>
          <li>Create User</li>
        </Link>
      </ul>
    </div>
  );
};

export default nav;
