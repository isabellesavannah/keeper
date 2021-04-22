<template>
  <div class="vaultPage row w-100 justify-content-center">
    <div class="col">
      <!-- <router-link :to="{ name: 'Account' }" class="nav-link"> -->
      <i class="fa fa-trash text-danger" @click="deleteVault" v-if="state.vault.creatorId == state.account.id" aria-hidden="true"></i>
      <!-- </router-link> -->
      {{ state.vault.name }}
    </div>
    <keep-component v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { useRoute, useRouter } from 'vue-router'
import { vaultService } from '../services/VaultService'
import swal from 'sweetalert2'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const router = useRouter()
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account)
    })
    onMounted(() => keepService.getKeepsByVaultId(route.params.id))
    onMounted(() => vaultService.getVaultByVaultId(route.params.id))
    return {
      state,
      deleteVault() {
        swal.fire({
          title: 'Are you sure you want to delete this vault?',
          icon: 'warning',
          buttons: true,
          dangerMode: true
        })
          .then((willDelete) => {
            if (willDelete.isConfirmed) {
              swal.fire({
                icon: 'success'
              })
              vaultService.deleteVault(state.vault.id)
              router.push({ name: 'Account' })
            } else {
              swal.fire('Cancelled')
            }
          })
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
