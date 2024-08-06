import { FC, ReactElement } from "react";
import { Title } from "../../common/title/Title";

interface HeaderProps {

}

const Header: FC<HeaderProps> = (): ReactElement<HeaderProps> => {
    return (
        <>
            <Title title='Tariff Comparison' />
        </>
    );
}

export {
    Header
}