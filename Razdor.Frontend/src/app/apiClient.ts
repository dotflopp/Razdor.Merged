interface IGuild {
  id: number
  name: string
  icon: string | null
}

interface IGuildChannel{
  id: number
  name: string
  guildId: number
  type: number
}

interface ISession{
  server: string
  sessionId: string
}

class RestApiClient {

  constructor(private connectionUrl: string){

  }

  async getMyGuilds() : Promise<IGuild[]> {
    const res: Response = await fetch(this.connectionUrl+`guilds/@my`)
    return res.json()
  } 
  
  async getGuildChannels(guildId: number):  Promise<IGuildChannel[]> {
    const res: Response = await fetch(this.connectionUrl+`guilds/${guildId}/channels`);
    return res.json()
  }

  async joinToVoiceChannel(channel: IGuildChannel): Promise<ISession> {
    const res: Response = await fetch(this.connectionUrl+`guilds/${channel.guildId}/channels/${channel.id}/join`, {method: "POST"});
    return res.json()
  }
}


export { RestApiClient }
export type { ISession }
