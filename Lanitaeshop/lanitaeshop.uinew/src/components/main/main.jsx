import React from 'react';
import Product from '../product/product.jsx';
import './main.css';

function Main() {
    return (
        <div className="main-style">
            <Product />
            <Product />
            <Product />
            <Product />
        </div>
    )
}

export default Main