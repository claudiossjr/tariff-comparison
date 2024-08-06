import { FC, ReactElement } from "react";
import { Header } from "../../component/header/Header";
import { SearchBar } from "../../component/search/SearchBar";

import './style.css'
interface HeaderSearchBarProps {
    onSearchFired: (annualConsumption: number) => void
}

const HeaderSearchBar: FC<HeaderSearchBarProps> = ({onSearchFired}): ReactElement<HeaderSearchBarProps> => {
    return (
        <div className="header-search__container">
            <Header />
            <SearchBar onSeachButtonPressed={(annualConsumption) => onSearchFired(annualConsumption)}/>
        </div>
    );
}

export {
    HeaderSearchBar
}