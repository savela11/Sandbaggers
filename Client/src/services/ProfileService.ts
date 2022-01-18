import apiClient from '../utility/apiClient'
import { AxiosResponse } from 'axios'
import { UserVm } from '$types/viewModel/UserVm'
import { BetVm } from '$types/viewModel/BetVm'
import { UserProfileData } from '$types/viewModel/UserProfile'
import { UpdateProfileImageDto } from '$types/dto/ProfileDto'

const url = '/profile'

class ProfileService {
  static async UpdateUser(updatedUser: UserVm): Promise<AxiosResponse<UserVm>> {
    return await apiClient.post(`${url}/UpdateUser`, updatedUser)
  }

  static async UploadProfileImage(imageData: any): Promise<AxiosResponse<string>> {
    return await apiClient.post(`${url}/UploadProfileImage/`, imageData, {
      headers: {
        'Content-Type': 'multipart/form-data'
      }
    })
  }

  static async UserProfile(id: string): Promise<AxiosResponse<UserProfileData>> {
    return await apiClient.get(`${url}/UserProfile/${id}`)
  }

  static async UserBets(id: string): Promise<AxiosResponse<BetVm[]>> {
    return await apiClient.get(`${url}/UserBets/${id}`)
  }

  static async UpdateBet(selectedBet: BetVm): Promise<AxiosResponse<BetVm>> {
    return await apiClient.put(`${url}/UpdateBet`, selectedBet)
  }

  static async DeleteBet(bet: BetVm): Promise<AxiosResponse<boolean>> {
    return await apiClient.post(`${url}/DeleteBet`, bet)
  }

  static async UpdateProfileImage(updateProfileImage: UpdateProfileImageDto): Promise<AxiosResponse> {
    return await apiClient.post(`${url}/UpdateProfileImage`, updateProfileImage)
  }
}

export default ProfileService
