import { FC, ReactElement } from "react";
import { HeaderList } from "../header-list/HeaderList";
import { NotFound } from "../not-found/NotFound";
import { Product } from "../../model/Product";

import './style.css'

interface TariffCoparisonSectionProps {
    products: Product[]
}

const TariffCoparisonSection: FC<TariffCoparisonSectionProps> = ({ products }): ReactElement<TariffCoparisonSectionProps> => {
    return (
        <div className="tariff-comparison__container">
            {products.length > 0
                ? <HeaderList products={products} />
                : <NotFound />
            }
        </div>
    );
}

export {
    TariffCoparisonSection
}