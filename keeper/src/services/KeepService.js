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
    const res = await api.get('api/profiles/' + id + '/keeps')
    AppState.keeps = res.data
    // console.log(res.data)
  }

  async getKeepsByVaultId(id) {
    const res = await api.get('api/vaults/' + id + '/keeps')
    AppState.keeps = res.data
  }

  async createKeep(keep) {
    const res = await api.post('api/keeps', keep)
    console.log(res)
    // AppState.reviews = [...AppState.reviews, res.data]
    this.getKeepsByAccountId(keep.id)
  }
}
export const keepService = new KeepService()
