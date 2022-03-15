import React from 'react';
import ReactDOM from 'react-dom';
import Layout from './components/layout/layout.jsx'

function Index() {
    return (
        <section>
            <Layout/>
        </section>
    );
}

ReactDOM.render(<Index/>, document.getElementById('root'))