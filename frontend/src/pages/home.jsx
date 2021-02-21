import React, { useState, useEffect } from "react";
import axios from "../components/base";
import Product from "../components/product";
import { Row, Col } from "react-bootstrap";
import Nav from "../components/nav";

function Home(props) {
  const [products, setProducts] = useState([]);
  const [changed, setChanged] = useState(false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      const url = "/product";
      const { data } = await axios.get(url);
      setProducts(data);
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

      <h1>Latest Products</h1>
      <Row>
        {products.map((product) => (
          <Col key={product._id} sm={12} md={6} lg={4} lx={3}>
            <Product product={product} handleChanged={handleChanged} />
          </Col>
        ))}
      </Row>
    </div>
  );
}

export default Home;
