import apiClient from '../../utility/apiClient'
import { AxiosResponse } from 'axios'
import { DashboardViewModel } from '@/types/models/ViewModels/DashboardViewModel'
import {UserVm} from "@/types/models/ViewModels/UserVm";

const url = 'v1/Dashboard'

class DashboardService {
    static async DashboardData(): Promise<AxiosResponse<UserVm[]>> {
        return await apiClient.get(`${url}/Get`)
    }

    // static async ActiveBets(): Promise<AxiosResponse<Array<BetVm>>> {
    //     return await apiClient.get(`${url}/ActiveBets`)
    // }
}

export default DashboardService
