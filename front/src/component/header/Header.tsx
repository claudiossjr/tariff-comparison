import { FC, ReactElement } from "react";
import { Title } from "../../common/title/Title";

import './style.css'

interface HeaderProps{

}

const Header: FC<HeaderProps> = (): ReactElement<HeaderProps> => {
    return (
        <div className="header-search__container-item">
            <Title title='Tariff Comparison' />
        </div>
    );
}

export {
    Header
}