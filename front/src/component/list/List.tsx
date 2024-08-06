import { FC, ReactElement } from "react";
import { ListItem } from "./list-item/ListItem";
import { Product } from "../../model/Product";

interface ListProps {
    products: Product[]
}

const List:FC<ListProps> = ({products}):ReactElement<ListProps> => {
    return (
        <ul>
            {products.map(item => <ListItem item={item} key={item.productName}/>)}
        </ul>
    );
}

export {
    List
}