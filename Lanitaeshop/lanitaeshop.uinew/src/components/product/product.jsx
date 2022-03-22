import React, { useState, useEffect } from 'react'
import './product.css'




//document.getElementById('product' + props.id).click(function () { console.log('pepito') });




const mouseOuverHandler = (id) => {
    let pepito = id;
    
    console.log(pepito);
}

function Product(props) {
    /*console.log(props.objet)*/
    const [product, setProduct] = useState( props.objet );
    //const clickHandler = () => {
    //    setProduct({ ...product, name: 'pepe'})
    //}

    useEffect(() => {
        console.log('pepe')
    })

    const clickHandler = () => {
        setProduct((oldProduct) => {
            let newProduct = { ...oldProduct, price: 'pepe' }
            return newProduct;
        })
    }
    return (
        <article className="product-style" id={product.id}  onMouseOver={() => mouseOuverHandler(product.id)}>
            <img src={product.img} onClick={clickHandler}/>
            <h4>{product.name}</h4>
            <p>{product.price}</p>
            <button>pepe</button>
            
        </article>
        )
}

export default Product