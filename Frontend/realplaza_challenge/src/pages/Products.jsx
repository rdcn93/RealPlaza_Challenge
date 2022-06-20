import React from 'react'
import Table from '../components/molecules/table/Table'
import { Icon } from '@iconify/react';

import ProductsList from '../assets/JsonData/products-list.json'
import Button from '../components/atoms/button/Button';
import axios from 'axios';

const baseURL = "https://localhost:44334/api/product";


const employeeTableHead = [
    'id',
    'tutor',
    'alumno',
    'fecha',
    'hora',
    'curso',
    'modalidad',
    'estado'
]

const renderHead = (item, index) => <th key={index}>{item}</th>

const renderBody = (item, index) => (
    <tr key={index}>
        <td>{item.id}</td>
        <td>{item.tutor}</td>
        <td>{item.alumno}</td>
        <td>{item.fecha}</td>
        <td>{item.hora}</td>
        <td>{item.curso}</td>
        <td>{item.modalidad}</td>
        <td>{item.estado}</td>
        <td className='btns__option'>
            <button className='btn__edit'><i><Icon icon='ci:edit'/></i></button>
            <button className='btn__delete'><i><Icon icon='akar-icons:circle-x'/></i></button>  
        </td>
    </tr>
)
const Products = () => {
    
    return (
        <div>
            <h2 className="page-header">
                Lista de Productos
            </h2>
            <div className="topnav__search">
                <input type="text" placeholder='Buscar producto...' />
                <i className='icon-flex'><Icon icon='bx:search'/></i>
            </div>
            <div className="row">
                <div className="col-12">
                    <div className="card">
                        <div className="card__body">
                            <Table
                                limit='10'
                                headData={employeeTableHead}
                                renderHead={(item, index) => renderHead(item, index)}
                                bodyData={ProductsList}
                                renderBody={(item, index) => renderBody(item, index)}
                            />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Products
