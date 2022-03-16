import React from 'react'
import MenuButton from '../menubutton/menubutton.jsx'
import './menu.css'

function Menu() {
    return (
        <nav className="menu-style">            
            <MenuButton title='Products'/>
            <MenuButton title='pepe'/>
            <MenuButton title='pepito'/>
            <MenuButton title='cacho' />
        </nav>
        )

}

export default Menu