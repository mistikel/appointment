export const entry = {
    title: "Test title",
    description: "Test description",
    address: "Test address",
    date: new Date(),
    deleted: false,
}

export const dayoff = {
    date: new Date(),
}

export const limit = {
    date: new Date(),
    limit: 10,
}


export const activeId = {
    id: 0
}

const url = "api/appointment"
const dayOffURL = "api/dayoff"
const limitURL = "api/appointmentlimit"

export async function getDefault(){
    const res = await fetch(url)

    if(!res.ok && res.status !== 200){
        notifyUser("Something went wrong, please refresh the page.")
        return []
    }

    const result = await res.json()
    return result
}

export async function getAppointments(filter_){
    const res = await fetch(url,{
        method: "POST",
        body: JSON.stringify(filter_),
        headers: {
            "content-type": "application/json"
        }
    })

    if(!res.ok){
        notifyUser("Something went wrong, please clear filters and try again.")
        return []
    }

    return await res.json()
}

export async function postAppointment(newApp){
    const res = await fetch(url,{
        method: "POST",
        body: JSON.stringify(newApp),
        headers: {
            "content-type": "application/json"
        }
    })

    if(!res.ok){
        notifyUser("We could not create your appointment, please try again.")
        return {msg: res}
    }

    return await res.json()
}

export async function updateAppointment(updateApp){
    const res = await fetch(url + "/" + updateApp.id,{
        method: "PUT",
        body: JSON.stringify(updateApp),
        headers: {
            "content-type": "application/json"
        }
    })

    if(!res.ok){
        notifyUser("We could not update your appointment, please try again.")
        return {msg: res}
    }

    return res
}

export async function deleteAppointment(id){
    const res = await fetch(url + "/" + id, {
        method: "DELETE"
    })

    if(!res.ok){
        notifyUser("Something went wrong, please refresh the page.")
        return {msg: res}
    }

    return res
}

export async function postDayOff(newDayOff){
    const res = await fetch(dayOffURL,{
        method: "POST",
        body: JSON.stringify(newDayOff),
        headers: {
            "content-type": "application/json"
        }
    })

    if(!res.ok){
        notifyUser("We could not create your day off, please try again.")
        return {msg: res}
    }

    return await res.json()
}

export async function postLoimit(limit){
    const res = await fetch(limitURL,{
        method: "POST",
        body: JSON.stringify(limit),
        headers: {
            "content-type": "application/json"
        }
    })

    if(!res.ok){
        notifyUser("We could not create your day off, please try again.")
        return {msg: res}
    }

    return await res.json()
}

export function notifyUser(msg){
    const notificationEl = document.querySelector(".notifications")
    notificationEl.innerHTML = msg ? msg : ""
    if(msg)
    setTimeout(() => {
        notificationEl.innerHTML = ""
    }, 12000);
}

export function openModal(modal){
    const modal_ = document.querySelector("."+modal)
    if(modal_){
        modal_.classList.remove("hidden")
    }
}

export function closeModal(modal){
    const modal_ = document.querySelector("."+modal)
    if(modal_){
        modal_.classList.add("hidden")
    }
}

export function formatedDateToStr(d){
    const nd = d ? new Date(d) : new Date()
    const month_ = nd.getMonth() + 1;
    const monthStr = month_ > 9 ? month_ : 0 + "" + month_;
    const day_ = nd.getDate() > 9 ? nd.getDate() : 0 + "" + nd.getDate();
    return nd.getFullYear() + "-" + monthStr + "-" + day_;
}

export function formatedTimeToStr(d) {
    const nd = d ?  new Date(d) : new Date();
    const hr_ = nd.getHours() < 9 ? 0 + '' + nd.getHours() : nd.getHours()
    const min_ = nd.getMinutes() < 9 ? 0 + '' + nd.getMinutes() : nd.getMinutes()
    return hr_ + ':' + min_
}
