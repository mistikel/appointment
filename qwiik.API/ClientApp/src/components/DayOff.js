import { closeModal, dayoff, formatedDateToStr, postDayOff } from "./Lib"
export default function DayOff(props){
    const newDayOff =(e)=> {
        dayoff.date = new Date(e.target.value)
    }

    const post = ()=> {
        postDayOff(dayoff).then(r=> {
            props.refreshApp(Math.random() * 125 * Math.random())
        }).catch(e=>console.log("Error happened at posting new app: ", e))

        closeModal("day-off-modal")
    }

    return (
        <div className="modal-container">
            <div className="modal-title">Day Off</div>

            <div className="row mt-15">
                <div>
                    <label htmlFor="Date_n">Date</label>
                    <input type="date" id="Date_n" name="date" defaultValue={formatedDateToStr()} onChange={newDayOff}/>
                </div>
            </div>

            <div className="row justify-btw modal-action-container mt-15">
                <div className="btn" onClick={()=> closeModal("day-off-modal")}>Cancel</div>
                <div className="btn" onClick={post}>Add</div>
            </div>
        </div>
    )
}