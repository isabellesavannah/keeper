import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultService {
  async getVaultsByAccountId() {
    const res = await api.get('account/vaults')
    console.log(res)
    AppState.activeVault = res.data
  }

  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.vaults = res.data
    console.log(res.data)
  }

  async createVault(vault) {
    const res = await api.post('api/vaults', vault)
    console.log(res)
    // AppState.reviews = [...AppState.reviews, res.data]
    this.getVaultsByAccountId(vault.id)
  }
}
export const vaultService = new VaultService()
