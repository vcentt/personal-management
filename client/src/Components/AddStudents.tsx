import { useState, useEffect } from 'react'
import { StudentsDetails } from '../Interfaces/IStudents'
import axios, { AxiosResponse } from 'axios'
import { urlGetStudents } from '../../routes'
import './CSS/addStudents.css'

export function AddStudents() {
    const [newStudent, setStudent] = useState<StudentsDetails>({
        studentid: 0,
        firstname: "",
        lastname: "",
        numgroup: 1,
        bootcamp: "Full Stack Developer",
        isgraduated: false,
        photo: "",
        tps: "",
        english: ""
    });

    const handleFormSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        axios.post(urlGetStudents, newStudent).then((response: AxiosResponse<any>) => {
            console.log(response.data)
        })
    };

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setStudent(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };

    const handleSelectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        const { name, value } = event.target;
        setStudent(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };

    return (
        <form className='container-forum' onSubmit={handleFormSubmit}>
            <div className='input-forum'>
                <label htmlFor="firstname">First Name: </label>
                <input
                    type="text"
                    id="firstname"
                    name="firstname"
                    value={newStudent.firstname}
                    onChange={handleInputChange}
                />
            </div>
            <div className='input-forum'>
                <label htmlFor="lastname">Last Name: </label>
                <input
                    type="text"
                    id="lastname"
                    name="lastname"
                    value={newStudent.lastname}
                    onChange={handleInputChange}
                />
            </div>
            <div className='input-forum'>
                <label htmlFor="numgroup">Group: </label>
                <input
                    type="number"
                    id="numgroup"
                    name="numgroup"
                    value={newStudent.numgroup}
                    onChange={handleInputChange}
                />
            </div>
            <div className='input-forum'>
                <label htmlFor="bootcamp">Bootcamp: </label>
                <select
                    id="bootcamp"
                    name="bootcamp"
                    value={newStudent.bootcamp}
                    onChange={handleSelectChange}
                    >
                    <option value="Full Stack Developer">Full Stack Developer</option>
                    <option value="Software Testing">Software Testing</option>
                    <option value="UX Designer1">UX Designer</option>
                </select>
            </div>
            <div className='input-forum'>
                <label htmlFor="photo">Photo: </label>
                <input
                    type="text"
                    id="photo"
                    name="photo"
                    value={newStudent.photo}
                    onChange={handleInputChange}
                />
            </div>
            <div className='input-forum'>
                <label htmlFor="tps">TPS Name: </label>
                <input
                    type="text"
                    id="tps"
                    name="tps"
                    value={newStudent.tps}
                    onChange={handleInputChange}
                />
            </div>
            <div className='input-forum'>
                <label htmlFor="english">English Level: </label>
                <select
                    id="english"
                    name="english"
                    value={newStudent.english}
                    onChange={handleSelectChange}
                    >
                    <option value="A1">A1</option>
                    <option value="A2">A2</option>
                    <option value="B1">B1</option>
                    <option value="B2">B2</option>
                    <option value="C1">C1</option>
                    <option value="C2">C2</option>
                </select>
            </div>
            <button type="submit">Submit</button>
        </form>
    )
};