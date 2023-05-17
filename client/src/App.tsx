import { useState, useEffect } from 'react'
import './App.css'
import { ShowStudents } from './Components/ShowStudents';
import { AddStudents } from './Components/AddStudents';
import { urlGetStudents } from '../routes';
import axios, { AxiosResponse } from 'axios';
import { StudentsDetails } from './Interfaces/IStudents';
import { HeaderAll } from './Components/Headers/HeaderAll';
 
function App() {
  const [data, saveData] = useState<StudentsDetails[]>([]);
  useEffect(() => {
    axios.get(urlGetStudents)
    .then((response: AxiosResponse<any>) => {
      saveData(response.data);
    })
  },[])
  
  const [dataByGroup, setDataByGroup] = useState<number>();
  const toggleByGroupOne = () => {
    setDataByGroup(1)
  }
  const toggleByGroupTwo = () => {
    setDataByGroup(2)
  }
  const toggleByGroupThree = () => {
    setDataByGroup(3)
  }
  const toggleAllGroups = () => {
    setDataByGroup(4)
  }

  const [isComponentVisible, setIsComponentVisible] = useState(false);
  function handleClick() {
    setIsComponentVisible(prevState => !prevState);
  }

  return (
    <div className='container'>
      <header className='header'>
        <HeaderAll group={dataByGroup}/>
        <div className='listgroups-header'>
          <button className='b-header' onClick={toggleByGroupOne}>Group 1</button>
          <button className='b-header' onClick={toggleByGroupTwo}>Group 2</button>
          <button className='b-header' onClick={toggleByGroupThree}>Group 3</button>
          <button className='b-header' onClick={toggleAllGroups}>All</button>

          <button className="br-header b-header" onClick={handleClick}>New Student</button>
          
        </div>

      </header>
      <main>
        {isComponentVisible === true ? <AddStudents/> : <ShowStudents dataByGroup={dataByGroup} students={data}/>}

      </main>
      
      
    </div>
  )
}

export default App
