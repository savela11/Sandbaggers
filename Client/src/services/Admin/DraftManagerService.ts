import apiClient from '../../utility/apiClient'
import { AxiosResponse } from 'axios'
import { DraftManagerViewData } from '@/types/ViewModels/admin/DraftManagerVm'
import { UpdateDraftStatusDto } from '$types/dto/DraftDto'

const url = 'ADMIN/DraftManager'

class DraftManagerService {
    static async AdminDraftManagerData(): Promise<AxiosResponse<DraftManagerViewData>> {
        return await apiClient.get(`${url}/AdminDraftManagerData`)
    }
    static async UpdateDraftStatus(UpdateDraftStatus: UpdateDraftStatusDto): Promise<AxiosResponse<boolean>> {
        return await apiClient.post(`${url}/UpdateDraftStatus`, UpdateDraftStatus)
    }
}

export default DraftManagerService
