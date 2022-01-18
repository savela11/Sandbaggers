import apiClient from '../../utility/apiClient'
import { AxiosResponse } from 'axios'
import { BetVm } from "$types/viewModel/BetVm";
import { AcceptedByUserVm } from "$types/viewModel/UserVm";
import { CreateBetDto, UserAcceptsBetDto } from '$types/dto/BetDto'

const url = 'USER/Bet'

class BetService {
  static async GetUserBets(id: string): Promise<AxiosResponse<Array<BetVm>>> {
    return await apiClient.get(`${url}/UserBets/${id}`)
  }
  static async AllActiveBets(): Promise<AxiosResponse<Array<BetVm>>> {
    return await apiClient.get(url + `/ActiveBets`)
  }

  static async UpdateBet(bet: BetVm): Promise<AxiosResponse<void>> {
    return await apiClient.post(url + '/UpdateBet', bet)
  }

  static async CreateBet(bet: CreateBetDto): Promise<AxiosResponse<BetVm>> {
    return await apiClient.post(url + '/CreateBet', bet)
  }

  static async UserAcceptsBet(acceptedBet: UserAcceptsBetDto): Promise<AxiosResponse<AcceptedByUserVm>> {
    return await apiClient.post(url + '/AcceptBet', acceptedBet)
  }

  static async GetBetById(betId: number): Promise<AxiosResponse<BetVm>> {
    return await apiClient.get(`${url}/ById/${betId}`)
  }
  static async BetVmById(betId: number): Promise<AxiosResponse<BetVm>> {
   return await apiClient.get(`${url}/BetVmById/${betId}`)
}

    static async MyBets(userId: string): Promise<AxiosResponse<Array<BetVm>>> {
      return await apiClient.get(`${url}/MyBets/${userId}`)
    }
}

export default BetService
