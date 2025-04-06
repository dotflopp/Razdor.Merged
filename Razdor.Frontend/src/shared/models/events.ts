interface EventListener<TEventArgs> {
    (args: TEventArgs): void;
}

export class EventProducer<TEventArgs>{
    private _listeners: Set<EventListener<TEventArgs>>

    constructor(){
        this._listeners = new Set<EventListener<TEventArgs>>
    }

    invoke(args: TEventArgs): void {
        this._listeners.forEach((listener) => {
            listener(args)
        })
    }
    
    addListener(callback: EventListener<TEventArgs>) : void{
        this._listeners.add(callback)
    }
    
    removeListener(callback: EventListener<TEventArgs>): void{
        this._listeners.delete(callback)
    }
}