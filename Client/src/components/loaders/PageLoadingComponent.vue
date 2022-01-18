<template>
  <div class="loadingContainer">
    <div class="loader" :style="loadingImg"></div>
    <div class="LoadingText">
      <h6>Loading</h6>
      <div class="lds-ellipsis">
        <div></div>
        <div></div>
        <div></div>
        <div></div>
      </div>
    </div>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "PageLoadingComponent",
  setup(props: any) {

    const loadingImg = {backgroundImage: "url(src/assets/images/GolfBallLoading.png)"}
    return {loadingImg}

  }
})
</script>

<style lang="scss" scoped>
@use "../../assets/styles/globals" as g;

.loadingContainer {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-pack: center;
  -ms-flex-pack: center;
  justify-content: center;
  -webkit-box-align: center;
  -ms-flex-align: center;
  align-items: center;
  height: 100vh;
  background-color: rgba(227, 226, 226, 1);
  animation: isLoading 4s linear;
  animation-fill-mode: forwards;
  z-index: map-get(g.$zIndex, PageLoading);

  .loader {
    position: relative;
    background-color: #516444;
    top: -15%;
    border: 5px solid #f3f3f3;
    border-top: 5px solid #516444;
    border-bottom: 5px solid #516444;
    box-shadow: 2px 4px 10px rgba(0, 0, 0, 0.4);
    border-radius: 50%;
    width: 150px;
    height: 150px;
    background-position: center;
    background-size: 95% 95%;
    background-repeat: no-repeat;
    -webkit-animation: spin 2s cubic-bezier(0.3, 1, 0.3, 1) infinite;

    animation: spin 2s cubic-bezier(0.3, 1, 0.3, 1) infinite;
    animation-fill-mode: forwards;
  }
  .LoadingText {
    display: flex;
    justify-content: center;
    align-items: center;
    position: absolute;
    left: 50%;
    transform: translate(-50%, 15px);
    h6 {
      font-size: 1.6rem;
      color: rgba(0, 0, 0, 0.6);
      margin: 0;
    }
  }
}

@-webkit-keyframes spin {
  0% {
    -webkit-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@keyframes spin {
  0% {
    -webkit-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}

.lds-ellipsis {
  display: inline-block;
  position: relative;
  height: 25px;
  width: auto;
}
.lds-ellipsis div {
  position: absolute;
  bottom: 2px;
  width: 5px;
  height: 5px;
  border-radius: 50%;
  background: #516444;
  animation-timing-function: cubic-bezier(0, 1, 1, 0);
}
.lds-ellipsis div:nth-child(1) {
  left: 6px;
  animation: lds-ellipsis1 1s infinite;
}
.lds-ellipsis div:nth-child(2) {
  left: 6px;
  animation: lds-ellipsis2 1s infinite;
}
.lds-ellipsis div:nth-child(3) {
  left: 26px;
  animation: lds-ellipsis2 1s infinite;
}
.lds-ellipsis div:nth-child(4) {
  left: 45px;
  animation: lds-ellipsis3 1s infinite;
}
@keyframes lds-ellipsis1 {
  0% {
    transform: scale(0);
  }
  100% {
    transform: scale(1);
  }
}
@keyframes lds-ellipsis3 {
  0% {
    transform: scale(1);
  }
  100% {
    transform: scale(0);
  }
}
@keyframes lds-ellipsis2 {
  0% {
    transform: translate(0, 0);
  }
  100% {
    transform: translate(19px, 0);
  }
}
</style>
