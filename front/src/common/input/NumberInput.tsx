import { FC, ReactElement } from "react";

import './style.css'

interface NumberInputProps
{
    onValueChanged : (newValue: number) => void;
    currentValue: number;
}

const NumberInput:FC<NumberInputProps> = ({onValueChanged,  currentValue}): ReactElement<NumberInputProps> => {
    return (
        <input 
            type='number' 
            className="search-bar__container-item number-input__input" 
            onChange={(e) => onValueChanged(!!(e.target.value) ? Math.max(parseFloat(e.target.value),0): 0 ) } 
            placeholder="Annual Consumption kwH"
            min={0}
        />
    );
}

export {
    NumberInput
}