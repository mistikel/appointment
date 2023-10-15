import { useState } from "react"
import { closeModal, entry, formatedDateToStr, postAppointment } from "./Lib"
export default function New(props){

    const [titleLength, setTitleLength] = useState(0)
    const [desLength, setDesLength] = useState(0)
    const [addrLength, setAddrLength] = useState(0)

    const newApp =(e)=> {
        const name_ = e.target.name
        let v_ = e.target.value

        if(name_ === "title"){
            setTitleLength(v_.length)
        }

        if(name_ === "description"){
            setDesLength(v_.length)
        }

        if(name_ === "address"){
            setAddrLength(v_.length)
        }

        if(name_ === "date"){
            v_ = new Date(v_)
        }

        entry[name_] = v_
    }

    const postApp = ()=> {
        postAppointment(entry).then(r=> {
            props.refreshApp(Math.random() * 125 * Math.random())
        }).catch(e=>console.log("Error happened at posting new app: ", e))

        closeModal("new-modal")
    }

    return (
        <div className="modal-container">
            <div className="modal-title">New Appointment</div>

            <div className="mt-15">
                <label htmlFor="Title_n">Title</label> <br/>
                <input type="text" className="mt-5" id="Title_n" maxLength={150} name="title" onChange={newApp}/>
                <span className="ms-10">{titleLength} / 150</span>
            </div>

            <div className="mt-15">
                <label htmlFor="Description_n">Description</label> <br/>
                <textarea id="Description_n" maxLength={300} className="mt-5" name="description" onChange={newApp} cols={102} rows={10}></textarea> <br />
                <span className='float-right me-10'>{desLength} / 300</span>
            </div>

            <div className="row mt-25">
                <div>
                    <label htmlFor="Address_n">Address</label>
                    <input type="text" id="Address_n" name="address" onChange={newApp} maxLength={100} />
                    <span className=' ms-10'>{addrLength} / 100</span>
                </div>
            </div>

            <div className="row mt-15">
                <div>
                    <label htmlFor="Date_n">Date</label>
                    <input type="date" id="Date_n" name="date" defaultValue={formatedDateToStr()} onChange={newApp}/>
                </div>
            </div>

            <div className="row justify-btw modal-action-container mt-15">
                <div className="btn" onClick={()=> closeModal("new-modal")}>Cancel</div>
                <div className="btn" onClick={postApp}>Add</div>
            </div>
        </div>
    )
}