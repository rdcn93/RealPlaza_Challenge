import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';

import { createStore } from 'redux'
import { Provider } from 'react-redux'
import rootReducer from './redux/reducers'

import Login from './pages/Login';
import Layout from './components/organisms/layout/Layout';
import Products from './pages/Products';
import AddProduct from './components/AddProduct';
import ListProducts from './components/ListProducts';
import App from './App';
import { ListFormat } from 'typescript';

const store = createStore(
  rootReducer
)

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <Provider store={store}>
    <React.StrictMode>
      {/* <Layout /> */}
      {/* <App /> */}
      <ListProducts />
      
    </React.StrictMode>
  </Provider>
  
);