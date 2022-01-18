import apiClient from '../../utility/apiClient'
import { AxiosResponse } from 'axios'
import { TeamVm } from '$types/viewModel/EventVm'
import { AddOrRemoveTeamCaptainDto,  RemoveTeamFromEventDto } from '$types/dto/TeamDto'

const url = 'ADMIN/TeamManager'

class TeamManagerService {
    static async CreateTeamForEvent(eventId: number): Promise<AxiosResponse<TeamVm>> {
        return await apiClient.post(`${url}/CreateTeam`, { eventId: eventId })
    }

    static async UpdateTeams(teams: Array<TeamVm>): Promise<AxiosResponse<Array<TeamVm>>> {
        return await apiClient.post(`${url}/UpdateTeams`, teams)
    }

    static async RemoveTeamFromEvent(removeTeamFromEvent: RemoveTeamFromEventDto): Promise<AxiosResponse> {
        return await apiClient.post(`${url}/RemoveTeamFromEvent`, removeTeamFromEvent)
    }

    static async RemoveTeamCaptain(removeTeamCaptainDto: AddOrRemoveTeamCaptainDto): Promise<AxiosResponse> {
        return await apiClient.post(`${url}/RemoveTeamCaptain`, removeTeamCaptainDto)
    }

    static async AddTeamCaptain(addRemoveTeamCaptainDto: AddOrRemoveTeamCaptainDto) {
        return await apiClient.post(`${url}/AddTeamCaptain`, addRemoveTeamCaptainDto)
    }
}

export default TeamManagerService
