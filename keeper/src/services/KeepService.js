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

  async deleteKeep(keepId) {
    await api.delete('api/keeps/' + keepId)
    const keepIndex = AppState.activeKeep.findIndex(k => k.id === keepId)
    AppState.activeKeep.splice(keepIndex, 1)
    // this.getKeepsByAccountId()
  }

  async addKeepToVault(newVK) {
    try {
      console.log(newVK)

      const res = await api.post('api/vaultKeeps', newVK)
      newVK = res.data
      this.getKeeps()
      // this.getKeepsByVaultId(newVK.id)
      // go get tasks for new listIdthis
      // go get tasks for Old listId (task)
    } catch (error) {
      console.error(error)
    }
  }

  async deleteKeepFromVault(kvId) {
    await api.delete('api/vaultKeeps/' + kvId)
    this.getKeepsByVaultId(AppState.activeVault.id)
  }
}
export const keepService = new KeepService()
