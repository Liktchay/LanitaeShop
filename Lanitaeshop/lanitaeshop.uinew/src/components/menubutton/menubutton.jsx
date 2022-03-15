import React from 'react';
import './menuButton.css'

function MenuButton(props) {
    
    return (
        <span className="menuButton">
            {props.title}
        </span>
        
        )
    
}

export default MenuButton