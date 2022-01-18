
export interface DashboardViewModel {
  sandbaggersWithHandicaps: Array<SandbaggerWithHandicapVm>;
  scrambleChamps: Array<ScrambleChampVm>

}

export interface SandbaggerWithHandicapVm {
  id: string
  fullName: string
  handicap: number
  image: string
}


export interface ScrambleChampVm {
  id: string
  fullName: string
  image: string
}
