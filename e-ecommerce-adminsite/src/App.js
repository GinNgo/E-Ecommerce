import { ColorModeContext, useMode } from "./theme";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { Route, Routes } from "react-router-dom";
import { useState } from "react";
import TopBar from "./scenes/global/Topbar";
import SideBar from "./scenes/global/Sidebar";
import Dashboard from "./scenes/dashboard/index";
import Category from "./scenes/category";
import Product from "./scenes/product";
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
              <Route path="/product" element={<Product />}></Route>
              {/* 
           
              <Route path="/invoices" element={<Invoices/>}></Route>
              <Route path="/form" element={<Form/>}></Route>
              <Route path="/bar" element={<Bar/>}></Route>
              <Route path="/pie" element={<Pie/>}></Route>
              <Route path="/line" element={<Line/>}></Route>
              <Route path="/faq" element={<FAQ/>}></Route>
              <Route path="/geography" element={<Geography/>}></Route>
              <Route path="/calendar" element={<Calendar/>}></Route> */}
            </Routes>
          </main>
        </div>
      </ThemeProvider>
    </ColorModeContext.Provider>
  );
}

export default App;
