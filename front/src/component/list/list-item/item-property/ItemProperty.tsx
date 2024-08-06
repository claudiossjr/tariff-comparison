import { FC, ReactElement } from "react";

import './styles.css'

interface ItemPropertyProps {
    label: string;
    content: string;
}

const ItemProperty: FC<ItemPropertyProps> = ({label, content}): ReactElement<ItemPropertyProps> => {
    return (
        <div className="item-property__container">
            <span className="item-property__label">{label}</span>
            <p className="list-item__item list-item__item-name">{content}</p>
        </div>
    );
}

export {
    ItemProperty
}