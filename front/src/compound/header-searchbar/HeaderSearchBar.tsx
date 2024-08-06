import { FC, ReactElement } from "react";
import { Header } from "../../component/header/Header";
import { SearchBar } from "../../component/search/SearchBar";

interface HeaderSearchBarProps {
    onSearchFired: (annualConsumption: number) => void
}

const HeaderSearchBar: FC<HeaderSearchBarProps> = ({onSearchFired}): ReactElement<HeaderSearchBarProps> => {
    return (
        <>
            <Header />
            <SearchBar onSeachButtonPressed={(annualConsumption) => onSearchFired(annualConsumption)}/>
        </>
    );
}

export {
    HeaderSearchBar
}