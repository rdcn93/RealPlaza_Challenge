import React from 'react'

// import { Route, Switch } from 'react-router-dom'
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import Login from '../pages/Login'
import Products from '../pages/Products'

const Routes = () => {
    return (
        <Switch>
            <Route path='/' exact component={Login}/>
            <Route path='/productos' component={Products}/>
        </Switch>
    )
}

export default Routes
