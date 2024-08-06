import { FC, ReactElement, useState } from "react";
import { SearchButton } from "../../common/button/SearchButton";
import { NumberInput } from "../../common/input/NumberInput";

interface SearchBarProps {
    onSeachButtonPressed: (annualConsupmtion: number) => void;
}

const SearchBar:FC<SearchBarProps> = ({onSeachButtonPressed}) : ReactElement<SearchBarProps> => {
    const [annualConsumption, setAnnualConsumption] = useState<number>(100);
    return (
        <div className="search-bar__container">
            <NumberInput currentValue={annualConsumption} onValueChanged={number => setAnnualConsumption(number)}/>
            <SearchButton onClick={() => onSeachButtonPressed(annualConsumption)}/>
        </div>
    );
}

export {
    SearchBar
}