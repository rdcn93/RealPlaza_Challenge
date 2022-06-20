import React from 'react'
import './input.css'

const Input = props => {
  return (    
      <div class="rowForm">
        <label>{props.description}</label>
        <input type={props.type} placeholder={props.placeholder}/>
      </div>  
  )
}

export default Input