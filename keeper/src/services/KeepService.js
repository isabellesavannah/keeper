import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepService {
  async getKeeps() {
    try {
      const res = await api.get('api/keeps')
      AppState.keeps = res.data
      console.log(res.data)
    } catch (error) {
      console.error(error)
    }
  }

  async getKeepsByAccountId() {
    const res = await api.get('account/keeps')
    AppState.activeKeep = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get('profile/keeps' + id)
    AppState.activeKeep = res.data
    console.log(res.data)
  }

  async getKeepsByVaultId(id) {
    const res = await api.get('api/vault/' + id + '/keeps')
    AppState.activeKeep = res.data
  }
}
export const keepService = new KeepService()
