import { HeaderSearchBar } from './compound/header-searchbar/HeaderSearchBar';
import { HeaderList } from './compound/header-list/HeaderList';
import { NotFound } from './compound/not-found/NotFound';

import './App.css';
import { UseProducts } from './hooks/products.hooks';

function App() {
  const { products, findProducts } = UseProducts();
  return (
    <>
      <HeaderSearchBar onSearchFired={(value) => findProducts(value)} />
      <hr />
      {console.log(products)}
      {products.length > 0
        ? <HeaderList products={products} />
        : <NotFound />
      }
    </>
  );
}

export default App;
