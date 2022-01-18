import apiClient from '../../utility/apiClient'
import { AxiosResponse } from 'axios'
import { AdminEventManagerVm, EventVm } from '$types/viewModel/EventVm'
import { CreateEventDto, RegisterUserForEventDto } from '$types/dto/EventDto'

const url = 'ADMIN/EventManager'

class EventManagerService {
    static async EventVmList(): Promise<AxiosResponse<Array<EventVm>>> {
        return await apiClient.get(`${url}/EventList`)
    }

    static async CreateEvent(createEventForm: CreateEventDto): Promise<AxiosResponse<EventVm>> {
        return await apiClient.post(`${url}/CreateEvent`, createEventForm)
    }

    static async GetEventById(id: string): Promise<AxiosResponse<EventVm>> {
        return await apiClient.get(`${url}/GetEventById/${id}`)
    }

    static async UpdateEvent(Event: EventVm): Promise<AxiosResponse> {
        return await apiClient.post(`${url}/UpdateEvent`, Event)
    }

    static async Event(eventId: number): Promise<AxiosResponse<AdminEventManagerVm>> {
        return await apiClient.get(`${url}/Event/${eventId}`)
    }

    static async RegisterUserForEvent(user: RegisterUserForEventDto): Promise<AxiosResponse> {
        return await apiClient.post(`${url}/RegisterUser`, user)
    }

    static async UnRegisterUserFromEvent(registerUserForEventDto: RegisterUserForEventDto): Promise<AxiosResponse> {
        return await apiClient.post(`${url}/UnRegisterUser`, registerUserForEventDto)
    }
}

export default EventManagerService
