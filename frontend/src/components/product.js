import React from "react";
import { Link, useHistory } from "react-router-dom";
import { Card } from "react-bootstrap";
import Rating from "./rating";
import axios from "../components/base";
import cookie from "react-cookies";

const Product = ({ product, handleChanged }) => {
  const { push } = useHistory();
  const onSubmit = async (e) => {
    e.preventDefault();
    const payload = {
      id: product.id,
    };

    const response = await axios.delete(`/product/${payload.id}`);
    console.log(response);
    handleChanged(true);
    push("/");
  };
  return (
    <Card className='my-3 p-3 rounded'>
      <Card.Body>
        <Link to={`/product/${product.id}`}>
          <Card.Title as='div'>
            <strong>{product.productName}</strong>
          </Card.Title>
        </Link>

        <Card.Text as='div'>
          <Rating value={product.price} text={`${product.price} Price`} />
        </Card.Text>
        <Card.Text as='div'>
          <Rating
            value={product.quantity}
            text={`${product.quantity} Quantity`}
          />
        </Card.Text>
        <Card.Text as='div'>
          <Rating
            value={product.discount}
            text={`${product.discount} Discount`}
          />
        </Card.Text>

        <Card.Text as='h3'>${product.price}</Card.Text>
      </Card.Body>
      <button type='button' onClick={onSubmit}>
        Remove
      </button>
    </Card>
  );
};

export default Product;
