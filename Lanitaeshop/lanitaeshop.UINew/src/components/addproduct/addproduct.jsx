import React, { useState, useReducer } from 'react';
import './addproductstyle.css'

function AddNewProduct() {

    const [product, setProduct] = useState({ name: '', description: '', price: 0, stock: 0, enable: false})

    const [productList, setProductList] = useState([])

    const handleSubmit = (e) => {
        e.preventDefault();      
        if (product.name && product.price && product.stock) {
            const newProduct = { ...product }
            setProductList([...productList, newProduct])
            setProduct({ name: '', description: '', price: 0, stock: 0, enable: false })
        }
        else {
            console.log('error')
        }        
    }

    const handleChange = (e) => {
        const name = e.target.name
        const value = e.target.value
        setProduct({ ...product, [name]: value })
    }

    return (
        <article class="product-form-container" >
            <form class="product-form">
                <div>
                    <label htmlFor="name">Product Name: </label>
                    <input type="text" id="product-name-id" name="name" value={product.name} onChange={handleChange} />
                </div>
                <div>
                    <label htmlFor="description">Product Description: </label>
                    <input type="text" id="product-description-id" name="description" value={product.description} onChange={handleChange} />
                </div>
                <div>
                    <label htmlFor="price">Price: </label>
                    <input type="number" id="product-price-id" name="price" value={product.price} onChange={handleChange} />
                </div>
                <div>
                    <label htmlFor="stock">Stock: </label>
                    <input type="number" id="product-stock-id" name="stock" value={product.stock} onChange={handleChange} />
                </div>
                <div>
                    <label htmlFor="enable">Enable: </label>
                    <input type="checkbox" id="product-enable-id" name="enable" checked={product.enable} onChange={handleChange} />
                </div>
                <button type="submit" onClick={handleSubmit}>Add new product</button>
            </form>
            {
                productList.map((product) => {
                    console.log(product)
                    const { name, description, price, stock, enable } = product
                    return (
                        <div>
                            <p> {name}</p>
                            <p> {description}</p>
                            <p> {price}</p>
                            <p> {stock}</p>
                            <p> {enable}</p>
                        </div>
                    )
                })
             }
        </article>
    )
}


export default AddNewProduct