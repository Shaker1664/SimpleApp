import React from "react";
import { Link, useHistory } from "react-router-dom";
import { Card } from "react-bootstrap";
import Rating from "./rating";
import axios from "../components/base";

const User = ({ user, handleChanged }) => {
  const { push } = useHistory();
  const onSubmit = async (e) => {
    e.preventDefault();
    const payload = {
      id: user.id,
    };

    const response = await axios.delete(`/user/${payload.id}`);
    console.log(response);
    handleChanged(true);
    push("/user");
  };
  return (
    <Card className='my-3 p-3 rounded'>
      <Card.Body>
        <Link to={`/user/${user.id}`}>
          <Card.Title as='div'>
            <strong>{user.UserName}</strong>
          </Card.Title>
        </Link>

        <Card.Text as='div'>
          <Rating value={user.email} text={`${user.email} Email`} />
        </Card.Text>
      </Card.Body>
      <button type='button' onClick={onSubmit}>
        Remove
      </button>
    </Card>
  );
};

export default User;
