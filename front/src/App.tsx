import { HeaderSearchBar } from './compound/header-searchbar/HeaderSearchBar';
import { UseProducts } from './hooks/products.hooks';
import { TariffCoparisonSection } from './compound/tariff-comparison/TariffComparison';

import './App.css';

function App() {
  const { products, findProducts } = UseProducts();
  return (
    <div className="app_container">
      <HeaderSearchBar onSearchFired={(value) => findProducts(value)} />
      <TariffCoparisonSection products={products} />
    </div>
  );
}

export default App;
