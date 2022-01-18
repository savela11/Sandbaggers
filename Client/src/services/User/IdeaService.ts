import apiClient from '../../utility/apiClient'
import { AxiosResponse } from 'axios'
import { IdeaVm } from '$types/viewModel/IdeaVm'
import { AddIdeaDto, GetIdeaDto } from '$types/dto/IdeaDto'

const url = '/USER/Idea'

class IdeaService {
  static async AllIdeas(): Promise<AxiosResponse<IdeaVm[]>> {
    return await apiClient.get(`${url}/AllIdeas`)
  }

  static async AddIdea(createIdea: AddIdeaDto): Promise<AxiosResponse<IdeaVm>> {
    return await apiClient.post(`${url}/AddIdea`, createIdea)
  }

  static async UpdateIdea(idea: IdeaVm): Promise<AxiosResponse<IdeaVm>> {
    return await apiClient.put(`${url}/UpdateIdea`, idea)
  }

  static async Idea(getIdeaDto: GetIdeaDto): Promise<AxiosResponse<IdeaVm>> {
    return await apiClient.post(`${url}/Idea`, getIdeaDto)
  }
}

export default IdeaService
