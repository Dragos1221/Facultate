package Proxy;

import ProjectModels.Oficiu;
import ServiceInterface.IServiceOficii;
import Utils.Request;
import Utils.Response;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingDeque;

public class ReadResponse {


    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;
    private  Boolean finished;
    private IServiceOficii prox;

    private BlockingQueue<Response> qresponse;

    public ReadResponse(Socket connection , ObjectOutputStream ob, ObjectInputStream in ) {
        this.connection = connection;
        output=ob;
        input=in;
        finished=false;
        qresponse = new LinkedBlockingDeque<>();
    }

    public void setServOficii(IServiceOficii ser)
    {
        prox=ser;
    }

    public void startReader(){
        Thread tw=new Thread(new ReaderThread());
        tw.start();
    }

    public Response readResponse()  {
        Response response=null;
        try{
            System.out.println("Daaaa");
            response=qresponse.take();

        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return response;
    }
    public void logout()
    {
        finished=true;
    }


    private class ReaderThread implements Runnable{
        public void run() {
            while(!finished){
                System.out.println("Citesc");
                try {
                    Object response=input.readObject();
                    Response cer = (Response) response;
                    System.out.println("response received "+response);
                    if (cer.getMesaj().equals("Observer")){
                        prox.notifyClients(cer.getListDestinatii());
                    }else{
                        try {
                            qresponse.put(cer);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                    }
                } catch (IOException e) {
                    System.out.println("Reading error "+e);
                    finished=true;
                } catch (ClassNotFoundException e) {
                    System.out.println("Reading error "+e);
                }
            }
        }
    }

}
