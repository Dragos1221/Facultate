package Proxy;

import ProjectModels.Destinatie;
import ProjectModels.Oficiu;
import ServiceInterface.IServiceOficii;
import Utils.Request;
import Utils.Response;
import proto.ProjectProto;

import java.io.*;
import java.net.Socket;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingDeque;

public class ReadResponse {


    private InputStream input;
    private OutputStream output;
    private Socket connection;
    private  Boolean finished;
    private IServiceOficii prox;

    private BlockingQueue<ProjectProto.Response> qresponse;

    public ReadResponse(Socket connection , OutputStream ob, InputStream in ) {
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

    public ProjectProto.Response readResponse()  {
        ProjectProto.Response response=null;
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
                    //Object response=input.readObject();
                    ProjectProto.Response cer = ProjectProto.Response.parseDelimitedFrom(input);
                    System.out.println("response received ");
                    if (cer.getMess().equals("Observer")){
                        List<Destinatie> list = new ArrayList<>();
                        for(int i=1;i<cer.getListaDestinatiiCount();++i)
                        {
                            LocalDateTime t = LocalDateTime.of(cer.getListaDestinatii(i).getAn(),cer.getListaDestinatii(i).getLuna(),
                                    cer.getListaDestinatii(i).getZi(),cer.getListaDestinatii(i).getOra(),cer.getListaDestinatii(i).getMinute());
                            list.add(new Destinatie(cer.getListaDestinatii(i).getId(),t,cer.getListaDestinatii(i).getLocuriDisponibile(),
                                    cer.getListaDestinatii(i).getLocuriOcupate(),cer.getListaDestinatii(i).getDestinatie()));
                        }
                        prox.notifyClients(list);
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
                }
            }
        }
    }

}
