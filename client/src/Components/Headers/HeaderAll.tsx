import mainlogo from '../../Img/mainlogo.png'
import './CSS/header.css'

interface Props{
    group: number|undefined;
}
export function HeaderAll({group}:Props) {
    let nameOfGroup = "";
    switch(group){
        case 1: nameOfGroup="Students Group 1"; break;
        case 2: nameOfGroup="Students Group 2"; break;
        case 3: nameOfGroup="Students Group 3"; break;
        default: nameOfGroup="All Groups of Students"; break;
    }

    return (
        <div className='mainHeader'>
            <img src={mainlogo} className='mainLogo'/>
            <h1 className='mainText'>{nameOfGroup}</h1>
        </div>
    )
}