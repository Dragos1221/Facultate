package ProxyClient;

import Interfete.Observer;
import Utils.Cerere;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingDeque;

public class ReadResponse {
    private String host;
    private int port;


    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;
    private Observer client;

    private BlockingQueue<Cerere> qresponses;
    private volatile boolean finished;

    public ReadResponse(String host, int port, ObjectInputStream input, ObjectOutputStream output, Socket connection , Observer obs) {
        this.host = host;
        this.port = port;
        this.input = input;
        this.output = output;
        this.connection = connection;
        this.client=obs;
        qresponses=new LinkedBlockingDeque<>();
        finished=false;
        startReader();
    }

    private void startReader(){
        Thread tw=new Thread(new ReaderThread());
        tw.start();
    }

    public Cerere readResponse()  {
        Cerere response=null;
        try{
            System.out.println("Daaaa");
            response=qresponses.take();

        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return response;
    }

    private void updateData()
    {
        System.out.println("Am ajuns");
        //client.ceva();
    }

    private class ReaderThread implements Runnable{
        public void run() {
            while(!finished){
                try {
                    Object response=input.readObject();
                    Cerere cer = (Cerere) response;
                    System.out.println("response received "+response);
                    if (cer.getMesaj().equals("Oberver")){
                        cer.setMesaj("dasd");
                    }else{

                        try {
                            qresponses.put((Cerere)response);
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
