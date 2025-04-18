# Special merged repository for Foss.Kruzhok open-source

# How to run [Razdor.Android](https://github.com/dotflopp/Razdor.Android)

# Как протестировать?

1) Скачайте стабильную версию андроид приложения [.apk](https://github.com/dotflopp/Razdor.Android/releases/download/v1.0/Razdor.apk)
2) Установите приложение
3) Предоставьте разрешения
4) Создайте новый аккаунт для одного устройства и ещё один для другого. Или же вы можете воспользоваться готовыми тестовыми аккаунтами:
   * `Dan`, пароль: `1234`;
   * `Lukus`, пароль: `1234`
6) Зайдя на главную страницу, вы отправляете запрос на связь с одного устройства на другое. На втором устройстве вы принимаете запрос.
   
# Как создать проект 🛠️

1) Загрузите последнюю версию Android Studio IDE
2) Клонируйте репозиторий
3) Дождитесь завершения сборки gradle
4) Запускайте


# How to run [Razdor.Backend](https://github.com/dotflopp/Razdor.Backend)
## How to test with docker desktop
1) Setup docker
2) Clone repository
3) Go to project directory
4) Build docker image 
```shell
    docker build -t image-name .
```
5) Run container
```
    docker run --rm -p 5154:8080 image-name
```
6) Build and use [frontend](https://github.com/dotflopp/razdor-frontend) or view the available routes on http://**/swagger

If you have any issues with live streaming, please [write it](https://github.com/dotflopp/Razdor.Backend/issues)

### How to deploy on Lan
1) Select the ip of the desired network using ifconfig/ipconfig
2) Run docker container in network
```
    docker run --rm -p 26.201.58.143:5154:8080 image-name
```
WARNING. A firewall may interfere with network detection.

# How to run [Razdor.Frontend](https://github.com/dotflopp/Razdor.Frontend)
1) Clone repository
2) Go to project directory
3) Then write in cmd >npm i
4) And >npm run dev
5) If you need switch address you can do this in src>app>webrtc.ts on line 13 
6) Build and use [Backend](https://github.com/dotflopp/Razdor.Backend)

If you have any issues with live streaming, please [write it](https://github.com/dotflopp/Razdor.Frontend/issues)

# How to run [MediaStreaming test environment](https://github.com/GoodDamn/MediaStreamingAndroid)

## How to test 📱
1) Download stable release [.apk](https://github.com/GoodDamn/MediaStreamingAndroid/releases/download/0.2.3/0.2.3.apk)
2) Install application
3) Grant video recording permission
4) Write your IP-address destination (you can test once with 127.0.0.1 individually). You need to stream to peer client which has the same application.
5) 'Start recording' button means that you can receive live stream video from another client. Click on it.
6) Buttons (0, 1 and etc) below are your available camera ID's for live streaming.
7) Select any camera (0, 1 and etc) and click on it

If you have any issues with live streaming, please [write it](https://github.com/GoodDamn/MediaStreamingAndroid/issues)


## How to build a project 🛠️
1) Download latest Android Studio IDE
2) Clone repository
3) Select folder with Android Studio IDE and open it
4) Wait till gradle building will be completed

### How to change camera capturing settings 📸
Press LShift twice and type `CaptureRequest.kt`. Inside the `default()` function you can change parameters via set() method. See [documentation](https://developer.android.com/reference/android/hardware/camera2/CaptureRequest) with available options

### How to change camera streaming settings 🎥
Press LShift twice and type `MediaFormat.kt`. Inside the `default()` function you can change parameters via setInteger() method. See [documentation](https://developer.android.com/reference/android/media/MediaFormat) with available options
Also, you can change streaming settings inside app with [downloaded stable version .apk](https://github.com/GoodDamn/MediaStreamingAndroid/releases/download/0.2.3/0.2.3.apk). Click on 'options' button and you have:
* capture-rate
* i-frame-interval
* width
* height
* rotation-degrees
* frame-rate
* bitrate

https://github.com/user-attachments/assets/ac01bcaa-0a70-4798-a28c-90818ec7cefb

