import axios from "axios";
import { Product } from "../model/Product";

class FindProductsService {
    apiClient: any;
    constructor()
    {
        this.apiClient = {};

    }
    async findProducts(annualConsumption: number): Promise<Product[]> {
        try
        {
            const products = await axios.get(`http://localhost:5127/products?annualConsumption=${annualConsumption}`);
            return (products?.data?.products ?? []) as Product[];
        }
        catch (e)
        {
            console.log(e);
            return [] as Product[];
        }
    }
}

export {
    FindProductsService
}