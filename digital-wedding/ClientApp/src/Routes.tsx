import {
  BrowserRouter,
  Routes,
  Route,
} from "react-router-dom";
import { NotFoundPage } from "./pages/NotFoundPage";
import { Home } from "./pages/Home";


export const RoutesNav = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  )
} 