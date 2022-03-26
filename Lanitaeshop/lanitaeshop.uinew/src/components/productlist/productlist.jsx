import React, { useState, useEffect } from 'react';
import Product from '../product/product.jsx';
import './productliststyle.css';
import { productlist} from '../products';

function ProductList() {


    const [products, setProducts] = React.useState([])

    const getProducts = async () => {
        const response = await fetch('https://localhost:44375/product/getallproducts',
                                    {
                                        headers: {
                                            "Content-Type": "application/json",                                            
                                        },
                                        method: "get"
                                    });
        const products = await response.json();
        setProducts(products.result_set);
    }

    useEffect(() => {
        getProducts();
    },[])
    
    return (        
        <section className="product-list-style">            
            {products.map((product) => {
                return <Product object={product} key={product.id} />

            })}
           
        </section>
        )    
}

export default ProductList