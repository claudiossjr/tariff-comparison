import { FC, ReactElement } from "react";

interface TitleProps{
    title: string;
}

const Title:FC<TitleProps> = ({title}): ReactElement<TitleProps> => {
    return (
        <h1>{title}</h1>
    );
}

export {
    Title
}