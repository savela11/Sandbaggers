import apiClient from '../../utility/apiClient'
import  { AxiosResponse } from 'axios'

const url = '/ADMIN/UserManager'

class UserManagerService {

    static async Test():Promise<AxiosResponse> {
        return await apiClient.get(`/UserById?id=34966226-b781-49f3-892b-90bf35aa66c4`)
    }


    static async AllUsers(): Promise<AxiosResponse> {
        return await apiClient.get(`${url}/AllUsers`)
    }
}

export default UserManagerService
