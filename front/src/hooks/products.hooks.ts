import { useState } from "react";
import { Product } from "../model/Product"

import { FindProductsService } from "../services/find-products.service";

const UseProducts = () => {
    const [products, setProducts] = useState<Product[]>([]);
    

    const findProducts = async (annualConsumption: number) => {
        const findProductsService = new FindProductsService();
        const p = await findProductsService.findProducts(annualConsumption);
        setProducts(p);
    }

    return {
        products,
        findProducts
    };
}

export {
    UseProducts
}