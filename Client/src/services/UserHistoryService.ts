import apiClient from '../utility/apiClient'
import { AxiosResponse } from 'axios'
import { UserHistoryVm } from "$types/viewModel/UserHistoryVm";

const url = '/Sandbagger'

export default class UserHistoryService {

  public static async sandBaggerWithHistory(id: string): Promise<AxiosResponse<UserHistoryVm>> {
    return await apiClient.get(`${url}/SandbaggerWithHistory/${id}`)
  }
}
