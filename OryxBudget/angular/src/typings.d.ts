/* SystemJS module definition */
declare var module: NodeModule;
interface NodeModule {
  id: string;
}
interface FileReaderEventTarget extends EventTarget {
    result:string
}

interface FileReaderEvent extends Event {
    target: FileReaderEventTarget;
    getMessage():string;
}