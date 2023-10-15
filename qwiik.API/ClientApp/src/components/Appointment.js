import { activeId, entry, openModal } from "./Lib";


export default function Appointment(props) {

    const handlingDelete = (id) =>{
        activeId.id = id
        // update state
        props.stateListener(Math.random() * 848 * Math.random())
        //open edit modal
        openModal("delete-modal")
    }

    const handlingEdit = (row)=>{
        Object.assign(entry, row)
        // update state
        props.stateListener(Math.random() * 548 * Math.random())
        //open edit modal
        openModal("edit-modal")
    }

    return (
        <div className="row py-5 underline" key={props.item.id}>
            <div className="column id">{props.item.id}</div>
            <div className="column title">{props.item.title}</div>
            <div className="column description">{props.item.description}</div>
            <div className="column date">{props.item.date.split("T")[0]}</div>
            <div className="column addr">{props.item.address}</div>
            <div className="column edit">
                <div className="btn edit" onClick={()=> handlingEdit(props.item)}>Edit</div>
            </div>
            <div className="column delete">
                <div className="btn delete" onClick={()=> handlingDelete(props.item.id)}>Delete</div>
            </div>
        </div>
    )
}