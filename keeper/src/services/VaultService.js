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
}
export const vaultService = new VaultService()
