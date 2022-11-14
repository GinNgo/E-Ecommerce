import { ColorModeContext, useMode } from "./theme";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { Route, Routes } from "react-router-dom";
import { useState } from "react";
import TopBar from "./scenes/global/Topbar";
import SideBar from "./scenes/global/Sidebar";
import Dashboard from "./scenes/dashboard/index";
import Category from "./scenes/category";
import Product from "./scenes/product";
import CreateCategory from "./scenes/category/Create";
import UpdateCategory from "./scenes/category/Update";
import DeleteCategory from "./scenes/category/Delete";
import UpdateProduct from "./scenes/product/Update";
import Customer from "./scenes/Customer";
import CreateProduct from "./scenes/product/Create";
import DeleteProduct from "./scenes/product/Delete";
// // import Contacts from './scenes/contacts';
// // import Bar from './scenes/bar';
// // import Form from './scenes/form';
// // import Line from './scenes/line';
// // import Pie from './scenes/pie';
// // import FAQ from './scenes/faq';
// // import Geography from './scenes/geography';
// // import Calendar from './scenes/calendar';

function App() {
  const [theme, colorMode] = useMode();
  const [isSidebar, setIsSidebar] = useState(true);
  return (
    <ColorModeContext.Provider value={colorMode}>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <div className="app">
          <SideBar isSidebar={isSidebar} />
          <main className="content">
            <TopBar setIsSidebar={setIsSidebar} />
            <Routes>
              <Route path="/" element={<Dashboard />}></Route>
              <Route path="/category" element={<Category />}></Route>
              <Route path="/category/create" element={<CreateCategory />} />
              <Route path="/category/update/:id" element={<UpdateCategory />} />
              <Route path="/category/delete" element={<DeleteCategory />} />
              <Route path="/product" element={<Product />}></Route>
              <Route path="/product/create" element={<CreateProduct />} />
              <Route path="/product/update/:id" element={<UpdateProduct />} />
              <Route path="/product/delete" element={<DeleteProduct />} />
              <Route path="/customer" element={<Customer />}></Route>
            </Routes>
          </main>
        </div>
      </ThemeProvider>
    </ColorModeContext.Provider>
  );
}

export default App;
