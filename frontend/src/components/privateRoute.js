import React, { Component } from "react";
import { Route, Redirect } from "react-router-dom";
import { withRouter } from "react-router";
import cookie from "react-cookies";

class PrivateRoute extends Component {
  isAuthenticated = () => {
    if (cookie.load("token")) {
        return true;
    }

    return false;
  };

  render() {
    const { children, ...rest } = this.props;

    return (
      <Route
        {...rest}
        render={({ location }) => {
          return this.isAuthenticated() ? (
            children
          ) : (
            <Redirect
              to={{
                pathname: "/login",
                state: { from: location }
              }}
            />
          );
        }}
      />
    );
  }
}


export default PrivateRoute;
