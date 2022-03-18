import React from 'react'
import './product.css'


//document.getElementById('product' + props.id).click(function () { console.log('pepito') });

const clickHandler = () => {
    console.log('pepe');
}

const mouseOuverHandler = (id) => {
    let pepe = document.getElementById(id);
    console.log(pepe);
}

function Product(props) {



    return (
        <article className="product-style" id={props.id} onClick={clickHandler} onMouseOver={() => mouseOuverHandler(props.id)}>
            <img src={props.img}/>
            <h4>{props.name}</h4>
            <p>{props.price}</p>
        </article>
        )
}

export default Product