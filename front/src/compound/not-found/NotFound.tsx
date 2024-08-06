import { FC, ReactElement } from "react";

import './style.css'

const NotFound: FC = (): ReactElement => {
    return (
        <div className="not-found__container">
            <h1>No products found</h1>
        </div>
    );
}

export {
    NotFound
}