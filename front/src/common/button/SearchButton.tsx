import { FC, ReactElement } from "react";

import './style.css'

interface SearchButtonProps  
{
    onClick: () => void;
    
}

const SearchButton:FC<SearchButtonProps> = ({onClick}): ReactElement<SearchButtonProps> => {

    return (
        <button className="search-bar__container-item search-button__button" onClick={() => onClick()}>Compare</button>
    );
}

export {
    SearchButton
}