import apiClient from '../../utility/apiClient'
import { AxiosResponse } from 'axios'
import { ContactVm } from '$types/viewModel/ContactVm'


const url = 'USER/Contact'


class ContactService {
    static async Contacts(): Promise<AxiosResponse<Array<ContactVm>>> {
        return await apiClient.get(url + `/ContactList`)
    }

}


export default ContactService
