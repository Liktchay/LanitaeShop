import React, { useState, useReducer, useEffect, useCallback } from 'react';
import PropsType from 'prop-types'
import './addproductstyle.css'

function AddNewProduct() {

    const [product, setProduct] = useState({ name: '', description: '', price: '', stock: '', enable: false, image: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/16/No_image_available_450_x_600.svg/450px-No_image_available_450_x_600.svg.png', source:''})

    const [productList, setProductList] = useState([])

    const inputs = document.querySelectorAll('input')

    const handleSubmit =  (e) => {
        e.preventDefault();      
        if (product.name && product.price && product.stock) {
            const newProduct = { ...product }
            setProductList([...productList, newProduct])
            saveNewProduct(newProduct);
            setProduct({ name: '', description: '', price: '', stock: '', enable: false, image: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/16/No_image_available_450_x_600.svg/450px-No_image_available_450_x_600.svg.png', source: '' })
        }
        else {
            console.log('error')
        }        
    }

    const saveNewProduct = async (product) => {

        const response = await fetch('https://localhost:44375/product/addproduct',
            {
                method: "POST",
                headers: {                    
                    "Content-Type": "application/json"
                },     
                body: JSON.stringify({ 
                            ProductName: product.name,
                            ProductDescription: product.description,
                            ProductPrice: parseInt(product.price),
                            ProductStock: parseInt(product.stock),
                            ProductEnable: product.enable,
                            ImageSource: product.source

                        
                })
            }
        );
        const result = await response.json();
        console.log(result)
    };

    const handleImageChange = (e) => {

        if (e.target.files && e.target.files[0]) {
            let imageFile = e.target.files[0]
            
            const reader = new FileReader()
            reader.onload = x => {
                setProduct({ ...product, image: URL.createObjectURL(e.target.files[0]), source: x.target.result})
            }
            reader.readAsDataURL(imageFile)
        }       
    }

    const handleChange = (e) => {
        const name = e.target.name
        const value = e.target.value
        setProduct({ ...product, [name]: value })
    }
    const handleToggleChange =(e) => {
        const name = e.target.name
        const value = e.target.checked
        setProduct({ ...product, [name]: value })
    }


    useEffect(() => {
        inputs.forEach(el => {
            el.addEventListener('blur', e => {
                if (e.target.value != '') {
                    e.target.classList.add('dirty')
                }
                else {
                    e.target.classList.remove('dirty');
                }
            })
        })
    })

    


    return (
        <article className="product-form-container" >
            <form className="product-form">
                <label className="custom-field">
                    <input type="text" id="product-name-id" name="name" value={product.name} onChange={handleChange} required/>
                    <span className="place-holder" htmlFor="name">Product Name </span>
                </label>
                <label className="custom-field">                    
                    <input type="text" id="product-description-id" name="description" value={product.description} onChange={handleChange} required/>
                    <span className="place-holder" htmlFor="description">Product Description </span>
                </label>
                <label className="custom-field">
                    <input className="currency-input " type="text" id="product-price-id" name="price" value={product.price} onChange={handleChange} required/>
                    <span className="place-holder" htmlFor="price">Price </span>
                    <span className="currency-holder"> $ </span>
                </label>
                <label className="custom-field">
                    <input type="text" id="product-stock-id" name="stock" value={product.stock} onChange={handleChange} required/>
                    <span className="place-holder" htmlFor="stock">Stock </span>
                </label>
                <div className="custom-toggle">
                    <input className="toggle" type="checkbox" id="product-enable-id" name="enable" checked={product.enable} onChange={handleToggleChange} required/>
                    <label className="toggle-text" htmlFor="product-enable-id" >Enable: </label>                    
                </div>
                
                <div className="custom-button" onClick={handleSubmit}>
                    <button className="submit-button" type="submit" >ADD</button>
                </div>
               
            </form>
            <div className="image-form">                
               
                <div className="custom-image-button">
                    <img className="product-image" src={product.image} />
                    <input className="image-upload-button" id="product-image-button" type="file" accept="image/*" onChange={handleImageChange} />
                    <label className="image-upload" htmlFor="product-image-button"> </label>
                </div>
            </div>
            
        </article>
    )
}



export default AddNewProduct