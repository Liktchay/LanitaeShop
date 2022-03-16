import React from 'react';
import './layout.css';
import Header from '../header/header.jsx'
import Main from '../main/main.jsx'

function Layout() {
    return(
        <div className="layout-style">
            <Header />
            <hr></hr>
            <Main />
        </div>
    )
}

export default Layout