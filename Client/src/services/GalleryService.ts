import apiClient from '../utility/apiClient'
import { AxiosResponse } from 'axios'
import { EventGalleryVm, GalleryImgVm, GalleryWithNoImageVm } from '$types/viewModel/EventGallery'
import { AddImageToGalleryDto } from '$types/dto/GalleryDtos'

const url = '/Gallery'

class GalleryService {
  static async Galleries(): Promise<AxiosResponse<Array<GalleryWithNoImageVm>>> {
    return await apiClient.get(`${url}/Galleries`)
  }

  static async Gallery(eventId: string): Promise<AxiosResponse<EventGalleryVm>> {
    return await apiClient.get(`${url}/Gallery/${eventId}`)
  }

  static async UploadImage(uploadData: any): Promise<AxiosResponse<string>> {
    return await apiClient.post(`${url}/UploadImageToGallery`, uploadData)
  }

  static async AddImageToGallery(addImageDto: AddImageToGalleryDto): Promise<AxiosResponse<GalleryImgVm>> {
    return await apiClient.post(`${url}/AddImageToGallery`, addImageDto)
  }
}

export default GalleryService
