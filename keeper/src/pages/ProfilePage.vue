<template>
  <div class="profilePage">
    <div class="col-12">
      <div class="row justify-content-start  flex-grow">
        <div class="col-2">
          <img class="rounded " :src="state.profile.picture" alt="" />
        </div>
        <div class="col-5">
          <h1>
            {{ state.profile.name }}
          </h1>
        </div>
      </div>
      <div class="row vaulties">
        <div class="col-4">
          <h1>
            Vaults: {{ state.vaults.length }}
          </h1>
        </div>
      </div>
      <div class="row vaulties">
        <vault-component v-for="vault in state.vaults" :key="vault.id" :vault-prop="vault" />
      </div>
      <div class="row keepies">
        <div class="col-4">
          <h1>
            Keeps: {{ state.keeps.length }}
          </h1>
        </div>
      </div>
      <div class="row keepiesC">
        <keep-component v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    })
    onMounted(() => keepService.getKeepsByProfileId(route.params.id))
    onMounted(() => vaultService.getVaultsByProfileId(route.params.id))
    onMounted(() => profileService.getProfileByKeepId(route.params.id))
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.vaulties{
  justify-content: center;
}
.keepies{
  justify-content: center;
}
.keepiesC{
  justify-content: space-evenly;
  align-items: center;
}

</style>
