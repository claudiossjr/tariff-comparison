import { FC, ReactElement } from "react";
import { Title } from "../../common/title/Title";
import { List } from "../../component/list/List";
import { Product } from "../../model/Product";

interface HeaderListProps {
    products: Product[]
}

const HeaderList: FC<HeaderListProps> = ({products}): ReactElement<HeaderListProps> => {
    return (
        <>
            <Title title='Tariffs Found:' />
            <List products={products}/>
        </>
    );
}

export {
    HeaderList
}