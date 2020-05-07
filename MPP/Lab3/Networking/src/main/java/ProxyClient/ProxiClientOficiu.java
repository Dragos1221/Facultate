package ProxyClient;

import Interfete.IServiceOficii;
import ProjectModel.Oficiu;
import Utils.Cerere;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;

public class ProxiClientOficiu implements IServiceOficii {
    private String host;
    private int port;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;
    private ReadResponse r;

    private volatile boolean finished;

    public ProxiClientOficiu(String host, int port, ObjectInputStream input, ObjectOutputStream output, Socket connection ,ReadResponse read) {
        this.host = host;
        this.port = port;
        this.input = input;
        this.output = output;
        this.connection = connection;
        r=read;
    }

    private void closeConnection() {
        finished=true;
        try {
            input.close();
            output.close();
            connection.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public boolean logIn(Oficiu of) {

        Cerere cer = new Cerere("Login");
        try {
            output.writeObject(cer);
            output.flush();
            output.writeObject(of);
            output.flush();
           Cerere rr = r.readResponse();
            if(rr.getMesaj().equals("Ok")) {
                Boolean ob = rr.getBol();
                return ob;
            }
            return false;
        } catch (IOException e) {
            e.printStackTrace();
        }
        return false;
    }

}

