import { AppState } from '../AppState'
import { api } from './AxiosService'

class ProfileService {
  async getProfileByKeepId(keepId) {
    console.log(keepId)
    const res = await api.get('api/profiles/' + keepId)
    console.log(res)
    AppState.profile = res.data
  }
}

export const profileService = new ProfileService()
