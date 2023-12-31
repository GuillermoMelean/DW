import { useNavigate } from "react-router";
import logo from '../assets/login-bg.jpg'
import { Button } from "../components/ui/button"
import { Label } from "../components/ui/label"
import "../styles/NotFoundPage.css"

export const NotFoundPage = () => {
  const navigate = useNavigate();
  return (
    <div className="NotFoundPage-header" style={{ backgroundImage: `url(${logo})` }}>
      <Label className="text-[150px]">404</Label>
      <Label className="text-3xl">How'd You Get Here?</Label>
      <Label className='mt-2'>It looks like this page doesn't exists - sorry for that!</Label>
      <Button onClick={() => { navigate(-1) }} className='mt-2 bg-white text-black hover:text-white'>Go to back to Main Page</Button>
    </div>
  )
}