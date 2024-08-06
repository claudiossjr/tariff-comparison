import { FC, ReactElement } from "react";
import { Product } from "../../../model/Product";

interface ListItemProps {
    item: Product;
}

const ListItem: FC<ListItemProps> = ({item}):ReactElement<ListItemProps> => {
    return (
        <li>
            <div>
                <p>Name: {item.productName}</p>
                <p>Tipo: {item.type}</p>
                <p>Descricao: {item.typeDescription}</p>
                <p>Annual Cost: {item.annualCost}</p>
            </div>
        </li>
    );
}

export {
    ListItem
}