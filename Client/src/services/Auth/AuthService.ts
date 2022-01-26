import axios from 'axios'
import {AxiosResponse} from 'axios'
import {LoginUserDto, RegisterUserDto} from "@/types/dto/AuthDto";
import {LoggedInUserVm} from "@/types/viewmodels/AuthViewModel";
import {ApplicationUserVm} from "@/types/viewmodels/UserVm";
import {vars} from "@/utility/envVars";

const baseURL = import.meta.env.MODE === 'production' ? "/" : vars.devURL;


class AuthService {

    static async allUsers(): Promise<AxiosResponse> {
        return await axios.get(baseURL + '/auth/Test/AllUsers')
    }

    static async registerUser(registerUser: RegisterUserDto): Promise<AxiosResponse<ApplicationUserVm>> {
        return await axios.post(baseURL + '/auth/Registration/Register', registerUser)
    }

    static async loginUser(loginUser: LoginUserDto): Promise<AxiosResponse<LoggedInUserVm>> {
        return await axios.post(baseURL + '/auth/Login', loginUser)
    }

    static async logout(): Promise<void> {
        return await axios.post(baseURL + '/auth/Logout')
    }
}

export default AuthService
