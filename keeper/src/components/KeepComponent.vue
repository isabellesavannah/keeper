<template>
  <div class="keepComponent col-4 card m-4 img-fluid keepC flex-stretch" data-toggle="modal" :data-target="`#keepModal` + keepProp.id">
    <img class="card-img" :src="keepProp.img" alt="Card image">
    <div class="card-img-overlay">
      <h3 class="text-white">
        {{ keepProp.name }}
      </h3>
      <div v-if="keepProp.creator">
        <p>{{ keepProp.id }}</p>
        <p>{{ keepProp.creator.name }}</p>
      </div>
    </div>
  </div>
  <div class="modal fade"
       :id="'keepModal' + keepProp.id"
       tabindex="-1"
       role="dialog"
       aria-hidden="true"
  >
    <div class="modal-dialog card" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <div class="col-7">
            <img class="img-fluid m-2 mb-3" :src="keepProp.img" alt="">
            <i class="fa fa-save m-2"></i><span>{{ keepProp.keeps }}</span>
            <select id="lists" class="m-3" @change="addKeepToVault()" v-model="state.newVaultKeep.vaultId">
              <option v-for="vault in state.vaults" :key="vault.id" :value="vault.id">
                {{ vault.name }}
              </option>
            </select>
          </div>
          <div class="col-4">
            <h3>{{ keepProp.name }}</h3>
            <p>{{ keepProp.description }}</p>
          </div>
          <div class="col-1">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
        </div>
        <div class="modal-footer">
          <div class="row ">
            <div class="col-4 deletebtn">
              <button @click="deleteKeepFromVault" v-if="state.account.id == state.activeVault.creatorId" aria-hidden="true">
                Remove From Vault
              </button>
            </div>
          </div>
          <div class="col-4 w-100">
            <i class="fa fa-trash text-danger" @click="deleteKeep" v-if="keepProp.creatorId == state.account.id" aria-hidden="true" data-dismiss="modal"></i>
            <router-link v-if="keepProp.creatorId != state.account.id" :to="{ name: 'ProfilePage', params: { id: keepProp.creatorId } }" class="nav-link" data-dismiss="modal">
              <img class="img-fluid picc" data-dismiss="modal" :src="keepProp.creator.picture" alt="">
            </router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import swal from 'sweetalert2'
// import { vaultService } from '../services/VaultService'

export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const route = useRoute()
    // const router = useRouter()
    const state = reactive({
      account: computed(() => AppState.account),
      keepProp: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      newVaultKeep: { vaultId: null },
      activeVault: computed(() => AppState.activeVault)
    })
    onMounted(() => {

    })

    return {
      state,
      route,
      deleteKeep() {
        swal.fire({
          title: 'Are you sure you want to delete this keep?',
          icon: 'warning',
          buttons: true,
          dangerMode: true
        })
          .then((willDelete) => {
            if (willDelete.isConfirmed) {
              swal.fire({
                icon: 'success'
              })
              keepService.deleteKeep(props.keepProp.id)
            } else {
              swal.fire('Cancelled')
            }
          })
      },
      async addKeepToVault() {
        try {
          state.newVaultKeep.keepId = props.keepProp.id
          await keepService.addKeepToVault(state.newVaultKeep)
        } catch (error) {
          console.error(error)
        }
      },
      async deleteKeepFromVault() {
        swal.fire({
          title: 'Are you sure you want to remove this keep from your vault?',
          icon: 'warning',
          buttons: true,
          dangerMode: true
        })
          .then((willDelete) => {
            if (willDelete.isConfirmed) {
              swal.fire({
                icon: 'success'
              })
              keepService.deleteKeepFromVault(props.keepProp.vaultKeepId)
            } else {
              swal.fire('Cancelled')
            }
          })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.modal-dialog{
  max-width:70vw;
  max-height:40vh;
}
.keepC{
min-height: 23vh;
max-height: 43vh;
}
.picc{
  max-height: 5vh;
}
// .deletebtn{
//   float: left;
// }

</style>
