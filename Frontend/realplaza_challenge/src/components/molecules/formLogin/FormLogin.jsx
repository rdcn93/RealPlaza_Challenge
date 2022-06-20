import React from 'react'
import Button from '../../atoms/button/Button'
import Input from '../../atoms/input/Input'

const FormLogin = props => {
  return (
    <div className='form_Container'>
      <Input description="Usuario o Correo" placeholder="user.name@email.com" type="text" />
      <Input description="Contraseña" placeholder="••••••••" type="password"/> <br /> <br />
      <Button title="Iniciar Sesión"/>
    </div>
  )
}

export default FormLogin