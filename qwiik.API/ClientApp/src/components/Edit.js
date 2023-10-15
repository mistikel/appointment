import { useEffect, useState } from "react"
import { closeModal, entry, updateAppointment } from "./Lib"

export default function Edit(props){

    const [data, setData] = useState({})

    const editApp =(e)=> {
        const name_ = e.target.name
        let v_ = e.target.value

        if(name_ === "date"){
            v_ = new Date(v_)
        }

        entry[name_] = v_
    }

    const updateApp = ()=>{
        updateAppointment(entry).then(r =>{
            console.log("Updated successfully: ", r)
            props.refreshApp(Math.random() * 248 * Math.random())
        })
        .catch(e=>console.log("Could not update the appointment: ", e))
        closeModal("edit-modal")
    }

    const defaultDate = typeof(entry.date) === "string" ? entry.date.split("T")[0] : ""

    useEffect(()=>{
        setData(entry)
    }, [props.stateListener])
    return (
        <div className="modal-container">
            <div className="modal-title">Edit Appointment</div>

            <div className="mt-15">
                <label htmlFor="Title_e">Title</label> <br/>
                <input type="text" className="mt-5" id="Title_e" maxLength={150} name="title" defaultValue={data.title} onChange={editApp}/>
                <span className="ms-10">0/150</span>
            </div>

            <div className="mt-15">
                <label htmlFor="Description_e">Description</label> <br/>
                <textarea id="Description_e" maxLength={300} className="mt-5" name="description" defaultValue={data.description} cols={102} rows={10} onChange={editApp}></textarea> <br />
                <span className='float-right me-10'>0/300</span>
            </div>

            <div className="row mt-15">
                <div>
                    <label htmlFor="Address_e">Address</label>
                    <input type="text" id="Address_e" name="address" maxLength={100} defaultValue={data.address} onChange={editApp}/>
                </div>
            </div>

            <div className="row mt-15 items-center">
                <div>
                    <label htmlFor="Date_e">Date</label>
                    <input type="date" id="Date_e" name="date" onChange={editApp} defaultValue={defaultDate}/>
                </div>
            </div>

            <div className="row justify-btw modal-action-container mt-15">
                <div className="btn" onClick={()=> closeModal("edit-modal")}>Cancel</div>
                <div className="btn" onClick={updateApp}>Update</div>
            </div>
        </div>
    )
}