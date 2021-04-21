import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error(err)
    }
  }

  // async getProfileById(keepId) {
  //   console.log(keepId)
  //   const res = await api.get('api/profiles/' + keepId)
  //   console.log(res)
  //   AppState.profile = res.data
  // }
}

export const accountService = new AccountService()
