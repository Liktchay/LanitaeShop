import React, { useState, useEffect } from 'react'
import './product.css'

//const mouseOuverHandler = (id) => {
//    let pepito = id;
    
//    console.log(pepito);
//}

function Product(props) {
    console.log(props.object)
    const [product, setProduct] = useState( props.object );
    //const clickHandler = () => {
    //    setProduct({ ...product, name: 'pepe'})
    //}

    //useEffect(() => {
    //    console.log('pepe')
    //})

    const clickHandler = () => {
        setProduct((oldProduct) => {
            let newProduct = { ...oldProduct, productPrice: 'pepe' }
            return newProduct;
        })
    }
    return (
        <article className="product-style" id={product.id}  >
            <img src="https://d3ugyf2ht6aenh.cloudfront.net/stores/001/314/137/products/zenda_blanco2-23c7aa6d9427d10a3516453229634757-480-0.jpg" onClick={clickHandler}/>
            <h2>{product.productName}</h2>
            <h4>{product.productDescription}</h4>
            <p>${product.productPrice}</p>
            
            
        </article>
        )
}

export default Product