import { FC, ReactElement } from "react";

import './style.css'

interface TitleProps {
    title: string;
}

const Title: FC<TitleProps> = ({ title }): ReactElement<TitleProps> => {
    return (
        <div className="title-component_value">
            <p className="title-component_value">{title}</p>
        </div>
    );
}

export {
    Title
}