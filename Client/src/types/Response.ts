export interface IServiceResponse<TD> {
  data: IResponseData<TD>
  status?: number
  statusText?: string
}

export interface IResponseData<TD> {
  data: TD
  message: string | null
  success: boolean
}
