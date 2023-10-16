import { closeModal, limit, formatedDateToStr, postDayOff } from "./Lib"
export default function Limit(props){
    const newDate =(e)=> {
        limit.date = new Date(e.target.value)
    }

    const newLimit =(e)=> {
        limit.limit = e.target.value
    }

    const post = ()=> {
        postDayOff(limit).then(r=> {
            props.refreshApp(Math.random() * 125 * Math.random())
        }).catch(e=>console.log("Error happened at posting new app: ", e))

        closeModal("limit-modal")
    }

    return (
        <div className="modal-container">
            <div className="modal-title">Appointment Limit</div>

            <div className="row mt-15">
                <div>
                    <label htmlFor="Date_n">Date</label>
                    <input type="date" id="Date_n" name="date" defaultValue={formatedDateToStr()} onChange={newDate}/>
                </div>
                <div className="ms-10">
                    <label htmlFor="Limit">Limit</label>
                    <input type="number" id="Limit" name="limit" onChange={newLimit}/>
                </div>
            </div>

            <div className="row justify-btw modal-action-container mt-15">
                <div className="btn" onClick={()=> closeModal("limit-modal")}>Cancel</div>
                <div className="btn" onClick={post}>Add</div>
            </div>
        </div>
    )
}