import { FC, ReactElement } from "react";
import { ListItem } from "./list-item/ListItem";
import { Product } from "../../model/Product";

import './styles.css'

interface ListProps {
    products: Product[]
}

const List:FC<ListProps> = ({products}):ReactElement<ListProps> => {
    return (
        <ul className="list__container">
            {products.map(item => <ListItem item={item} key={item.productName}/>)}
        </ul>
    );
}

export {
    List
}