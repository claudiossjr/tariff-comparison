import { FC, ReactElement } from "react";

interface NumberInputProps
{
    onValueChanged : (newValue: number) => void;
    currentValue: number;
}

const NumberInput:FC<NumberInputProps> = ({onValueChanged,  currentValue}): ReactElement<NumberInputProps> => {
    return (
        <input type='number' className="number-input__input" onChange={(e) => onValueChanged(parseFloat(e.target.value))} value={currentValue} />
    );
}

export {
    NumberInput
}