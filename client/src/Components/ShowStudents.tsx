import { StudentsDetails } from "../Interfaces/IStudents";
import './CSS/showStudents.css'

interface Props {
  dataByGroup:number | undefined,
  students: StudentsDetails[];
}

export function ShowStudents({students,dataByGroup}: Props) {
  if (!students) {
    return <div>Data not found...</div>
  }

  switch(dataByGroup){
    case 1: students.filter(s => s.numgroup == 1); break;
    case 2: students = students.filter(s => s.numgroup == 2); break;
    case 3: students = students.filter(s => s.numgroup == 3); break;
    default: break;
  }

  return (
    <div>
      <div className="user-card-container">
        <div className="user-card-grid">
          {students.map((user) => (
            <div key={user.studentid} className="user-card">
              <img src={user.photo} alt={user.firstname} className="user-avatar" />
              <div className="user-info">
                <p><b>{user.firstname} {user.lastname}</b></p>
                <p>{user.bootcamp}</p>
                <p><b>TPS</b> {user.tps}</p>
                <p>English <b>{user.english}</b></p>
                <p>Graduated: {user.isgraduated === true ? "Yes" : "No"}</p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  )
}