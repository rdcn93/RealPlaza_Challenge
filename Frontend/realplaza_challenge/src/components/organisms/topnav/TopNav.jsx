import React from "react";
import { Icon } from "@iconify/react";

import "./topnav.css";

import { Link } from "react-router-dom";

import Dropdown from "../../atoms/dropdown/Dropdown";

import ThemeMenu from "../../molecules/thememenu/ThemeMenu";

import notifications from "../../../assets/JsonData/notification.json";

import user_image from "../../../assets/images/User.png";

import user_menu from "../../../assets/JsonData/user_menus.json";

import Logo from "../../../assets/images/Logo-Large.png";
import LogoResponsive from "../../../assets/images/favicon.png";

const curr_user = {
  display_name: "Usuario",
  image: user_image,
};

const renderNotificationItem = (item, index) => (
  <div className="notification-item" key={index}>
    <i className="icon-flex">
      <Icon icon={item.icon} />
    </i>
    <span>{item.content}</span>
  </div>
);

const renderUserToggle = (user) => (
  <div className="topnav__right-user">
    <div className="topnav__right-user__image">
      <img src={user.image} alt="" />
    </div>
    <div className="topnav__right-user__name">{user.display_name}</div>
  </div>
);

const renderUserMenu = (item, index) => (
  <Link to="/" key={index}>
    <div className="notification-item">
      <i className="icon-flex">
        <Icon icon={item.icon} />
      </i>
      <span>{item.content}</span>
    </div>
  </Link>
);

const Topnav = () => {
  return (
    <nav className="topnav">
      <div className="topnav-toggle-container">
        <div className="header-toggle" onClick={onclick}>
          <i className="icon-flex">
            <Icon icon="eva:menu-fill" />
          </i>
        </div>
        <div className="sidebar__logo">
          <img className="desktop__Logo" src={Logo} alt="company logo" />
          <img className="mobile__Logo" src={LogoResponsive} alt="company logo" />
        </div>
      </div>
      <div className="topnav__right">
        <div className="topnav__right-item">
          <Dropdown
            customToggle={() => renderUserToggle(curr_user)}
            contentData={user_menu}
            renderItems={(item, index) => renderUserMenu(item, index)}
          />
        </div>
        <div className="topnav__right-item">
          <Dropdown
            icon="bx:bell"
            badge="12"
            contentData={notifications}
            renderItems={(item, index) => renderNotificationItem(item, index)}
            renderFooter={() => <Link to="/">Ver Todas</Link>}
          />
        </div>
        <div className="topnav__right-item">
          <ThemeMenu />
        </div>
      </div>
    </nav>
  );
};

export default Topnav;
