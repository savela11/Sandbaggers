import apiClient from '../utility/apiClient'
import { AxiosResponse } from 'axios'

import { EventResultsVm, ScrambleChampVm } from "$types/viewModel/EventResultsVm";

const url = '/EventResults'

class EventResultsService {
  static async ScrambleChamps(): Promise<AxiosResponse<ScrambleChampVm[]>> {
    return await apiClient.get(`${url}/ScrambleChamps`)
  }

  static async EventResults(eventID: number): Promise<AxiosResponse<EventResultsVm>> {
    return await apiClient.get(url + `/Results/${eventID}`)
  }
  static async UpdateEventResults(eventResults: EventResultsVm): Promise<AxiosResponse<boolean>> {
    return await apiClient.put(url + `/UpdateEventResults/`, eventResults)
  }
}

export default EventResultsService
