import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepService {
  async getKeeps() {
    try {
      const res = await api.get('api/keeps')
      AppState.keeps = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getKeepsByAccountId() {
    const res = await api.get('account/keeps')
    console.log(res)
    AppState.activeKeeps = res.data
  }
}
export const keepService = new KeepService()
