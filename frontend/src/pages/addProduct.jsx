import React, { useState } from "react";
import axios from "../components/base";
import cookie from "react-cookies";
import Nav from "../components/nav";

function AddProduct(props) {
  const [productName, changeProductName] = useState("");
  const [price, changePrice] = useState("");
  const [discount, changeDiscount] = useState("");
  const [quantity, changeQuantity] = useState("");

  const onSubmit = async (e) => {
    e.preventDefault();
    const payload = {
      productName: productName,
      price: price,
      discount: discount,
      quantity: quantity,
    };
    const url = "/product";
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
              <label for='exampleProductName'>ProductName</label>
              <input
                className='form-control'
                id='exampleInputEmail1'
                aria-describedby='productHelp'
                placeholder='ProductName'
                value={productName}
                onChange={(e) => changeProductName(e.target.value)}
              />
            </div>
            <div className='form-group'>
              <label for='exampleInputEmail1'>Price</label>
              <input
                className='form-control'
                id='exampleInputPrice'
                aria-describedby='priceHelp'
                placeholder='Price'
                value={price}
                onChange={(e) => changePrice(e.target.value)}
              />
            </div>
            <div className='form-group'>
              <label for='exampleInputPassword1'>Discount</label>
              <input
                className='form-control'
                id='exampleInputDiscount'
                placeholder='Discount'
                value={discount}
                onChange={(e) => changeDiscount(e.target.value)}
              />
            </div>
            <div className='form-group'>
              <label for='exampleInputPassword1'>Quantity</label>
              <input
                className='form-control'
                id='exampleInputQuantity'
                placeholder='Quantity'
                value={quantity}
                onChange={(e) => changeQuantity(e.target.value)}
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

export default AddProduct;
