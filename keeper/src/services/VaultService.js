import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultService {
  async getVaultsByAccountId() {
    const res = await api.get('account/vaults')
    console.log(res)
    AppState.activeVault = res.data
  }

  async getVaultByVaultId(id) {
    try {
      const res = await api.get('api/vaults/' + id)
      AppState.activeVault = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.vaults = res.data
  }

  async createVault(vault) {
    const res = await api.post('api/vaultkeeps', vault)
    console.log(res)
    // AppState.reviews = [...AppState.reviews, res.data]
    // this.getVaultsByAccountId(vault.id)
  }

  async deleteVault(vaultId) {
    await api.delete('api/vaults/' + vaultId)
    const vaultIndex = AppState.activeVault.findIndex(v => v.id === vaultId)
    AppState.activeVault.splice(vaultIndex, 1)
    // this.getVaultByVaultId()
  }
}
export const vaultService = new VaultService()
