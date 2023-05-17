import mainlogo from '../../Img/mainlogo.png'
import './CSS/header.css'
export function HeaderG2() {
    return (
        <div className='mainHeader'>
            <img src={mainlogo} className='mainLogo'/>
            <h1 className='mainText'>Students Group 2</h1>
        </div>
    )
}