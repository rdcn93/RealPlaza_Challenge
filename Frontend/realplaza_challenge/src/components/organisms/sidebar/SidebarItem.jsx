import React from 'react'
import { Icon } from '@iconify/react';

const SidebarItem = props => {

    const active = props.active ? 'active' : ''

    return (
        <div className="sidebar__item">
            <div className={`sidebar__item-inner ${active}`}>
                
                <i className='icon-flex'><Icon icon={props.icon} /></i>
                <span>
                    {props.title}
                </span>
            </div>
        </div>
    )
}

export default SidebarItem
