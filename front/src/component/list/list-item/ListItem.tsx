import { FC, ReactElement } from "react";
import { Product } from "../../../model/Product";

import './styles.css'
import { ItemProperty } from "./item-property/ItemProperty";

interface ListItemProps {
    item: Product;
}

const ListItem: FC<ListItemProps> = ({item}):ReactElement<ListItemProps> => {

    const numberFormat = (value:number) => {
        return new Intl.NumberFormat('de-DE', { style: 'currency', currency: 'EUR' }).format(value);
    }

    return (
        <li className="list-item__container">
            <div className="list-item__wrapper">
                <div className="list-item__item-left">
                    <ItemProperty label="Name" content={item.productName}/>
                    <ItemProperty label="Description" content={item.typeDescription}/>
                </div>
                <div className="list-item__item-right">
                    <ItemProperty label="Annual Cost" content={numberFormat(item.annualCost)}/>
                </div>
            </div>
        </li>
    );
}

export {
    ListItem
}