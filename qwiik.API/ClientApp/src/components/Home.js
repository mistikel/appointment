
import { useEffect, useState } from "react"
import Delete from "./Delete"
import Edit from "./Edit"
import New from "./New"
import Appointment from "./Appointment"
import { getDefault, openModal } from "./Lib"
import DayOff from "./DayOff"
import Limit from "./Limit"

export default function Home(props) {

  const [dataList, setDataList] = useState([])

  const [refreshData, setRefreshData] = useState(0)
  const [stateListener, setStateListener] = useState(0)


  useEffect(() => {
    getDefault().then(data => {
      setDataList(data)
    }).catch(e => console.log("Error inside home: ", e))
  }, [refreshData])
  return (
    <main>
      <h1>Qwiik Appointment Management</h1>
      <div className="add-btn row items-center content-center">
        <div className="btn add" onClick={() => openModal("new-modal")}>+</div>
        <div className="btn" onClick={() => openModal("day-off-modal")}>Day Off</div>
        <div className="btn" onClick={() => openModal("limit-modal")}>Limit</div>
      </div>

      <div className="notifications spacer-20"></div>

      <div className="row underline hdr">
        <div className="column id">#</div>
        <div className="column title">Title</div>
        <div className="column description">Description</div>
        <div className="column date">Date</div>
        <div className="column addr">Adress</div>
        <div className="column edit">Edit</div>
        <div className="column delete">Delete</div>
      </div>

      {
        dataList.length === 0 ?
          <div className="row mt-10 waiting">Loading <div className="loading">...</div></div> :
          dataList?.data?.map(item => <Appointment item={item} key={item.id} stateListener={setStateListener} />)
      }


      <section>
        <section className="modal new-modal hidden">
          <New refreshApp={setRefreshData} />
        </section>

        <section className="modal edit-modal hidden">
          <Edit stateListener={stateListener} refreshApp={setRefreshData} />
        </section>

        <section className="modal delete-modal hidden">
          <Delete stateListener={stateListener} refreshApp={setRefreshData} />
        </section>

        <section className="modal day-off-modal hidden">
          <DayOff stateListener={stateListener} refreshApp={setRefreshData} />
        </section>

        <section className="modal limit-modal hidden">
          <Limit stateListener={stateListener} refreshApp={setRefreshData} />
        </section>
      </section>
    </main>
  )
}