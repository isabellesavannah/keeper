<template>
  <div class="about text-center">
    <div class="row justify-content-start m-3">
      <div class="col-2">
        <img class="rounded" :src="state.account.picture" alt="" />
      </div>
      <div class="col-5">
        <h1>
          {{ state.account.name }}
        </h1>
      </div>
    </div>
    <div class="row justify-content-start">
      <div class="col-4">
        <h1>
          Vaults: {{ state.vaults.length }}
          <i class="fa fa-plus text-success" aria-hidden="true" @click="state.showForm = !state.showForm"></i>
        </h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-4 card" v-if="state.showForm">
        <h3>Create a Vault!</h3>
        <form @submit.prevent="createVault">
          <div class="form-group">
            <input type="text"
                   class="form-control"
                   aria-describedby="helpId"
                   v-model="state.newVault.name"
            >
            <input type="text"
                   class="form-control"
                   aria-describedby="helpId"
                   v-model="state.newVault.description"
            >
            <input type="checkbox" v-model="state.newVault.isPublic">
          </div>
          <button type="submit" class="btn btn-info">
            Create Vault
          </button>
        </form>
      </div>
    </div>
    <div class="row">
      <vault-component v-for="vault in state.vaults" :key="vault.id" :vault-prop="vault" />
    </div>
    <div class="row">
      <div class="col-5">
        <h1>
          Keeps: {{ state.keeps.length }}
          <i class="fa fa-plus text-success" aria-hidden="true" @click="state.showKForm = !state.showKForm"></i>
        </h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-4 card" v-if="state.showKForm">
        <h3>Create a Keep!</h3>
        <form @submit.prevent="createKeep">
          <div class="form-group">
            <input type="text"
                   class="form-control"
                   aria-describedby="helpId"
                   v-model="state.newKeep.name"
            >
            <input type="text"
                   class="form-control"
                   aria-describedby="helpId"
                   v-model="state.newKeep.description"
            >
            <input type="text"
                   class="form-control"
                   aria-describedby="helpId"
                   v-model="state.newKeep.img"
            >
          </div>
          <button type="submit" class="btn btn-info">
            Create Keep
          </button>
        </form>
      </div>
    </div>
    <div class="row">
      <keep-component v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
// import { useRoute } from 'vue-router'
export default {
  name: 'Account',
  setup() {
    // const route = useRoute
    const state = reactive({
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.activeVault),
      // actK: computed(() => AppState.keeps),
      showForm: false,
      showKForm: false,
      newVault: {},
      newKeep: {}
    })
    onMounted(() => keepService.getKeepsByAccountId())
    onMounted(() => vaultService.getVaultsByAccountId())
    return {
      state,
      createVault() {
        console.log(state.newVault)
        // state.newVault.id = route.params.id
        vaultService.createVault(state.newVault)
        state.newVault = {}
        state.showForm = false
      },
      createKeep() {
        console.log(state.newKeep)
        // state.newKeep.id = route.params.id
        keepService.createKeep(state.newKeep)
        state.newKeep = {}
        state.showKForm = false
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
