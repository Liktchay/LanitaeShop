import React from 'react';
import Product from '../product/product.jsx';
import './productliststyle.css';
import { productlist} from '../products';




//const getproductlist = (list) => {
//    list.map((item) => {
//        return <Product {...item} key={item.id}/>;        
//    });
//};

function ProductList() {
    
    return (        
        <section className="product-list-style">
            {/*{getproductlist(productlist)};*/}
            {productlist.map((product) => {
                return <Product {...product}  key = {product.id}/>;
            })}
        </section>
        )    
}

export default ProductList