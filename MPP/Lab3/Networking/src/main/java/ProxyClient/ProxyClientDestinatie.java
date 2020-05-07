package ProxyClient;

import Interfete.IServiceDestinatie;
import ProjectModel.Destinatie;
import Utils.Cerere;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class ProxyClientDestinatie implements IServiceDestinatie {
    private String host;
    private int port;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;

    public ProxyClientDestinatie(String host, int port, ObjectInputStream input, ObjectOutputStream output, Socket connection) {
        this.host = host;
        this.port = port;
        this.input = input;
        this.output = output;
        this.connection = connection;
    }


    @Override
    public int getIdDestinatie(String destinatie, LocalDateTime data) {
        Cerere cer = new Cerere("getIdDestinatie");
        try{
            output.writeObject(cer);
            output.flush();
            output.writeUTF(destinatie);
            output.flush();
            output.writeUTF(data.toString());
            output.flush();
            return input.readInt();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return 0;
    }

    @Override
    public List<Destinatie> returnLista() {
        Cerere cer = new Cerere("getListDestinatii");
        List<Destinatie> list = new ArrayList<>();
        try{
            output.writeObject(cer);
            output.flush();
            int nr = input.readInt();
            for(int i=1;i<=nr;++i)
            {
                Object obj = input.readObject();
                list.add((Destinatie)obj);
            }
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return list;
    }

    @Override
    public Destinatie getDestinatie(int id) {
        Cerere cer = new Cerere("getDestinatie");
        try{
            output.writeObject(cer);
            output.flush();
            output.writeInt(id);
            output.flush();
            Object obj = input.readObject();
            return (Destinatie)obj;
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public void update(Destinatie dest) {
        Cerere cer = new Cerere("Update");
        try{
            output.writeObject(cer);
            output.flush();
            output.writeObject(dest);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
