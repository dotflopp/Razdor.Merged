<script setup lang="ts">
import type { RefSymbol } from '@vue/reactivity';
import { onMounted, ref } from 'vue';
import PeerConnection from '@/app/webrtc';

let localVideoRef = ref<HTMLVideoElement | null>(null); 
let remoteVideoRef = ref<HTMLVideoElement | null>(null); 
let cameraRef = ref<HTMLElement|null>(null)
let micRef = ref<HTMLElement|null>(null)

let localStreamSrc: MediaStream
let peerConnection: PeerConnection
let remoteStreamSrc: MediaStream

let cameraBtnStyle = ref<any | null>(null)
let micBtnStyle = ref<any | null>(null)


let initStreamAsync = async () => {

  //видео контент
  if (localVideoRef.value == null) return
  localStreamSrc = await navigator.mediaDevices.getUserMedia({video: true, audio: true})
  localVideoRef.value.srcObject = localStreamSrc;



  peerConnection = new PeerConnection()
  await peerConnection.createPeerConection(localStreamSrc, remoteVideoRef.value!)

  await peerConnection.startCall()

  //регистрация ивентов
  cameraRef?.value?.addEventListener('click', toggleCamera)
  micRef?.value?.addEventListener('click', toggleMic)
}

//заплатка с рег
let toggleCamera = async () => {
    let videoTrack = localStreamSrc.getTracks().find(track => track.kind === 'video')

    if(videoTrack!.enabled){
        videoTrack!.enabled = false
        cameraBtnStyle.value = { backgroundColor: 'rgb(255, 80, 80)' }
    }else{
        videoTrack!.enabled = true
        cameraBtnStyle.value = { backgroundColor: 'rgb(179, 102, 249, .9)' }
    }
}

let toggleMic = async () => {
    let audioTrack = localStreamSrc.getTracks().find(track => track.kind === 'audio')

    if(audioTrack!.enabled){
        audioTrack!.enabled = false
        micBtnStyle.value = { backgroundColor: 'rgb(255, 80, 80)'}
    }else{
        audioTrack!.enabled = true
        micBtnStyle.value = { backgroundColor: 'rgb(179, 102, 249, .9)' }
    }
}
//document.getElementById('camera-btn').addEventListener('click', toggleCamera)
//document.getElementById('mic-btn').addEventListener('click', toggleMic)


onMounted(initStreamAsync)

</script>

<template>
  <!-- контейнер с видео -->
  <div class="videos">
    <video ref="localVideoRef" class="video-player smallFrame"  autoplay playsinline></video>
    <video ref="remoteVideoRef" class="video-player "  autoplay playsinline></video>
  </div>

  <!-- контроллеры -->
  <div id="controls">
    <div ref="cameraRef" class="control-container" id="camera-btn" v-bind:style="cameraBtnStyle">
      <img src="/assets/camera.png" /> 
    </div>

    <div ref="micRef" class="control-container" id="mic-btn" v-bind:style="micBtnStyle">
      <img src="/assets/mic.png" />
    </div>

    <a href="lobby.html">
      <div class="control-container" id="leave-btn">
          <img src="/assets/phone.png" />
      </div>
    </a>
  </div>
</template>


<style lang="css">
*{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

.videos{
    display: grid;
    grid-template-columns: 1fr;
    height: 100vh;
    overflow:hidden;
}

.video-player{
    background-color: black;
    width: 100%;
    height: 100vh;
}
.video-player:first-child {
  object-fit: cover;
}
#user-2{
    display: none;
}

.smallFrame{
    position: fixed;
    top: 20px;
    left: 20px;
    height: 170px;
    width: 300px;
    border-radius: 5px;
    border:2px solid #b366f9;
    -webkit-box-shadow: 3px 3px 15px -1px rgba(0,0,0,0.77);
    box-shadow: 3px 3px 15px -1px rgba(0,0,0,0.77);
    z-index: 999;
}

#controls{
    position: fixed;
    bottom: 20px;
    left: 50%;
    transform:translateX(-50%);
    display: flex;
    gap: 1em;
}


.control-container{
  background-color: rgb(179, 102, 249, .9);
  padding: 20px;
  border-radius: 50%;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
}

.control-container img{
    height: 30px;
    width: 30px;
}

#leave-btn{
    background-color: rgb(255,80,80, 1);
}

@media screen and (max-width:600px) {
        .smallFrame{
            height: 80px;
            width: 120px;
        }

        .control-container img{
            height: 20px;
            width: 20px;
        }
}
</style>