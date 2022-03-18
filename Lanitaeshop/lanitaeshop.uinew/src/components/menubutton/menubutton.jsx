import React from 'react';
import './menuButton.css'

function MenuButton(props) {

    return (
        <span className="menuButton" key={props.id}>
            {props.label}
        </span>        
        )
    
}

export default MenuButton