import  {  HubConnectionBuilder, HubConnection, LogLevel, HttpTransportType} from '@microsoft/signalr'; 

class SignalR {
  public connection: HubConnection 
  constructor(url: string) {
    //создаем соединение с signalR
    this.connection = new HubConnectionBuilder()
      .withUrl(url, {
        skipNegotiation: true,  // skipNegotiation as we specify WebSockets
        transport: HttpTransportType.WebSockets
      })
    .configureLogging(LogLevel.Error)
    .build()
  }

  public async startingConnection() {
    await this.connection.start();
  }
  
}

export default SignalR