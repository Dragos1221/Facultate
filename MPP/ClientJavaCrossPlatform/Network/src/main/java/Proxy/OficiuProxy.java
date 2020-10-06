package Proxy;

import Observer.IObserver;
import ProjectModels.Destinatie;
import ProjectModels.Oficiu;
import ServiceInterface.IServiceOficii;
import Utils.Request;
import Utils.Response;
import proto.ProjectProto;

import java.io.*;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;


public class OficiuProxy implements IServiceOficii {
    private InputStream input;
    private OutputStream output;
    private Socket connection;
    private ReadResponse r;
    private IObserver client;



    public OficiuProxy(Socket connection, ReadResponse r , OutputStream o , InputStream in) {
        this.connection = connection;
        this.r = r;
        output=o;
        input=in;
    }

    @Override
    public boolean logIn(Oficiu of , IObserver client) {
        this.client = client;
        //Request cer = new Request("Login");
        ProjectProto.User usr = ProjectProto.User.newBuilder().setUsername(of.getUsarname()).setPasswdord(of.getPassword()).build();
        ProjectProto.Request cer=ProjectProto.Request.newBuilder().setMess("Login").setUser(usr).build();
        try{
            cer.writeDelimitedTo(output);
            output.flush();
            ProjectProto.Response re = r.readResponse();
            if(re.getMess().equals("ok"))
            {
                return re.getRBool();
            }
            else
            {
                throw new Exception("Eroare logare");
            }
        } catch (IOException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
        return false;
    }

    public void closeConnection() {
       // Request re = new Request("logout");
        ProjectProto.Request re=ProjectProto.Request.newBuilder().setMess("logout").build();
        try {
           re.writeDelimitedTo(output);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }

        try {
            input.close();
            output.close();
            connection.close();
            client=null;
        } catch (IOException e) {
            e.printStackTrace();
        }

        r.logout();
    }

    @Override
    public void notifyClients(List<Destinatie> r) {
        client.reloList(r);
    }

}
