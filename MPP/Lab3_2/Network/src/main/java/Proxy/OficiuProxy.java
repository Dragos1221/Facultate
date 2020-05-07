package Proxy;

import Observer.IObserver;
import ProjectModels.Destinatie;
import ProjectModels.Oficiu;
import ServiceInterface.IServiceOficii;
import Utils.Request;
import Utils.Response;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class OficiuProxy implements IServiceOficii {
    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;
    private ReadResponse r;
    private IObserver client;



    public OficiuProxy(Socket connection, ReadResponse r , ObjectOutputStream o , ObjectInputStream in) {
        this.connection = connection;
        this.r = r;
        output=o;
        input=in;
    }

    @Override
    public boolean logIn(Oficiu of , IObserver client) {
        this.client = client;
        Request cer = new Request("Login");
        cer.setUser(of);
        try{
            output.writeObject(cer);
            output.flush();
            Response re = r.readResponse();
            if(re.getMesaj().equals("ok"))
            {
                return re.getBol();
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
        Request re = new Request("logout");
        try {
            output.writeObject(re);
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
