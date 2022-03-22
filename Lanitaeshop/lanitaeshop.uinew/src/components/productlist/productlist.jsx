import React, { useState } from 'react';
import Product from '../product/product.jsx';
import './productliststyle.css';
import { productlist} from '../products';




//const getproductlist = (list) => {
//    list.map((item) => {
//        return <Product {...item} key={item.id}/>;        
//    });
//};

function ProductList() {


    const [products, setProducts] = React.useState(productlist)

    const removeItems = (id) => {
        let newProductList = products.filter((product) => product.id !== id)
        setProducts(newProductList)
    }

    return (        
        <section className="product-list-style">            
            {products.map((product) => {
                return <Product objet={product} key={product.id} />
                
            })}
           
        </section>
        )    
}

export default ProductList