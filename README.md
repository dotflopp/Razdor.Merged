
# How to run Razdor.Android

# Как протестировать?

1) Скачайте стабильную версию [.apk](https://github.com/dotflopp/Razdor.Android/releases/download/v1.0/Razdor.apk)
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


# Welcome to Razdor.Backend

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

# Welcome to Razdor.Frontend

## How to run 
1) Clone repository
2) Go to project directory
3) Then write in cmd >npm i
4) And >npm run dev
5) If you need switch address you can do this in src>app>webrtc.ts on line 13 
6) Build and use [Backend](https://github.com/dotflopp/Razdor.Backend)

If you have any issues with live streaming, please [write it](https://github.com/dotflopp/Razdor.Frontend/issues)
