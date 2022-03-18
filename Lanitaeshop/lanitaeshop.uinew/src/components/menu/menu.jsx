import React from 'react'
import MenuButton from '../menubutton/menubutton.jsx'
import './menu.css'
import { menuoptions } from '../menuoptions'

function Menu() {
    return (
        <nav className="menu-style">
            {menuoptions.map((item) => {
                return <MenuButton {...item} key={item.id} />
            })}
            
            {/*//<MenuButton title='pepe'/>*/}
            {/*//<MenuButton title='pepito'/>*/}
            {/*//<MenuButton title='cacho' />*/}
        </nav>
        )

}

export default Menu