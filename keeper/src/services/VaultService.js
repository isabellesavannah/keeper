import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultService {
  async getVaultsByAccountId() {
    const res = await api.get('account/vaults')
    console.log(res)
    AppState.activeVault = res.data
  }
}
export const vaultService = new VaultService()
