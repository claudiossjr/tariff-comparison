import { FC, ReactElement } from "react";

interface SearchButtonProps  
{
    onClick: () => void;
    
}

const SearchButton:FC<SearchButtonProps> = ({onClick}): ReactElement<SearchButtonProps> => {

    return (
        <button onClick={() => onClick()}>Search</button>
    );
}

export {
    SearchButton
}