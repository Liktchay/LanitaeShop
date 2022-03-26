import React from 'react';
import ProductList from '../productlist/productlist.jsx';
import AddNewProduct from '../addproduct/addproduct.jsx';
import './main.css';

function Main() {
    return (
        <div className="main-style">
            {/*<ProductList/>*/}
            <AddNewProduct/>
        </div>
    )
}

export default Main