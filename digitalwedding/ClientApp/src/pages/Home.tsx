import logo from '../assets/logo.svg';
import '../styles/Home.css';
import { Button } from '../components/ui/button';
import bg from '../assets/login-bg.jpg'

export function Home() {
  return (
    <div className="App " style={{ backgroundImage: `url(${bg})` }}>
      <header className="flex justify-center items-center w-full">
        <div className="justify-center items-center row-auto">
          <div className="mt-5 row-auto">
            <div className="bg-white mx-5 border form-wrapper flowers neela-style col-md-12 rounded-lg p-12">
              <h2 className="section-title baseboard">Digital Wedding</h2>
              <h5 className="section-title">Brevemente disponível</h5>
              <p className="text-center">Junte-se a nós e comece a construir o site perfeito para tornar o seu grande dia inesquecível!</p>
            </div>
          </div>
        </div>
      </header>
    </div>
  );
} 