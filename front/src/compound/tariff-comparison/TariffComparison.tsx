import { FC, ReactElement } from "react";
import { HeaderList } from "../header-list/HeaderList";
import { NotFound } from "../not-found/NotFound";
import { Product } from "../../model/Product";

interface TariffCoparisonSectionProps {
    products: Product[]
}

const TariffCoparisonSection: FC<TariffCoparisonSectionProps> = ({ products }): ReactElement<TariffCoparisonSectionProps> => {
    return (
        <>
            {products.length > 0
                ? <HeaderList products={products} />
                : <NotFound />
            }
        </>
    );
}

export {
    TariffCoparisonSection
}