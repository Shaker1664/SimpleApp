import React, { useState, useEffect } from "react";
import axios from "../components/base";
import User from "../components/user";
import { Row, Col } from "react-bootstrap";
import Nav from "../components/nav";

function Users(props) {
  const [users, setUsers] = useState([]);
  const [changed, setChanged] = useState(false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      const url = "/user";
      const { data } = await axios.get(url);
      console.log(data);
      setUsers(data);
      setChanged(false);
      setLoading(false);
    };
    fetchData();
  }, [changed]);

  const handleChanged = (data) => {
    setChanged(data);
  };

  if (loading) {
    return "Loading ...";
  }

  return (
    <div>
      <Nav />
      <h1>All Users</h1>
      <Row>
        {users.map((user) => (
          <Col key={user._id} sm={12} md={6} lg={4} lx={3}>
            <User user={user} handleChanged={handleChanged} />
          </Col>
        ))}
      </Row>
    </div>
  );
}

export default Users;
