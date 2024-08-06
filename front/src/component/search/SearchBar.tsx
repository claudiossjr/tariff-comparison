import { FC, ReactElement, useState } from "react";
import { SearchButton } from "../../common/button/SearchButton";
import { NumberInput } from "../../common/input/NumberInput";

import './style.css'

interface SearchBarProps {
    onSeachButtonPressed: (annualConsupmtion: number) => void;
}

const SearchBar:FC<SearchBarProps> = ({onSeachButtonPressed}) : ReactElement<SearchBarProps> => {
    const [annualConsumption, setAnnualConsumption] = useState<number>(0);
    return (
        <div className="header-search__container-item search-bar__container">
            <NumberInput currentValue={annualConsumption} onValueChanged={number => setAnnualConsumption(number)}/>
            <SearchButton onClick={() => onSeachButtonPressed(annualConsumption)}/>
        </div>
    );
}

export {
    SearchBar
}