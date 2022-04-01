import React, { useState, useEffect } from 'react'
import PropTypes from 'prop-types';
import './product.css'

//const mouseOuverHandler = (id) => {
//    let pepito = id;
    
//    console.log(pepito);
//}

function Product({ productName, productDescription, productPrice, id, imageSource }) {
    
   /* const [product, setProduct] = useState(product);*/
    //const clickHandler = () => {
    //    setProduct({ ...product, name: 'pepe'})
    //}

    //useEffect(() => {
    //    console.log('pepe')
    //})

    //const clickHandler = () => {
    //    setProduct((oldProduct) => {
    //        let newProduct = { ...oldProduct, productPrice: 'pepe' }
    //        return newProduct;
    //    })
    //}
    {/*onClick={clickHandler}*/ }
    return (
        <article className="product-style" id={id}  >
            <img src={imageSource || Product.defaultProps.imageSource}/>
            {/*<img src="https://d3ugyf2ht6aenh.cloudfront.net/stores/001/314/137/products/zenda_blanco2-23c7aa6d9427d10a3516453229634757-480-0.jpg" />*/}
            <h2>{productName}</h2>
            <h4>{productDescription}</h4>
            <p>${productPrice}</p>
        </article>
        )
}

Product.propTypes = {
    productName: PropTypes.string.isRequired,
    productDescription: PropTypes.string.isRequired,
    productPrice: PropTypes.number.isRequired,
    imageSource: PropTypes.string.isRequired
}

Product.defaultProps = {
    productName: 'N/A',
    productDescription: 'N/A',
    productPrice: 0,
    imageSource:'https://upload.wikimedia.org/wikipedia/commons/thumb/1/16/No_image_available_450_x_600.svg/450px-No_image_available_450_x_600.svg.png'
}
export default Product