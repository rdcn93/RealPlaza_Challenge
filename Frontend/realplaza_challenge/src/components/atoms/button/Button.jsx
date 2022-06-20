import React from 'react'
import './button.css'

const Button = props => {
  return (  
      <div id="button" class="rowForm button">
        <button>{props.title}</button>
      </div>   
  )
}

export default Button