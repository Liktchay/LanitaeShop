import React from 'react';
import Menu from '../menu/menu.jsx'
import './header.css'

function Header() {
    return(
        <header className="header-style">
            <div className="pepe">TITULO</div>
            <Menu />
        </header>
    )
}

export default Header