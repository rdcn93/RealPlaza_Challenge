import React from "react";
import LogoCompleto from '../assets/images/Logo-Complete.png'
import Title from "../components/atoms/title/Title";
import "../components/molecules/formLogin/formLogin.css";
import FormLogin from "../components/molecules/formLogin/FormLogin";

const Login = () => {
  return (
    <div className="containerLogin">
      <div className="SliderSection">
        <div>
          <p>Hoy somos la primera y única cadena presente en prácticamente todo el Perú, con <b>21 centros comerciales</b> en 13 ciudades.</p>
          <p>Nos preocupamos por mejorar la calidad de vida de las familias peruanas, creando puntos de encuentro que brinden <b>modernidad, entretenimiento y experiencias únicas</b> en todo el Perú.</p>
        </div>
      </div>

      <div class="LoginSection">
        <div className="container_Login">
          <div className="loginform">
            <img className="Logo" src={LogoCompleto} alt="Real Plaza" />
            <Title title="Plataforma de Gestión"/>
            <FormLogin />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
