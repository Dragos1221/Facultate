package ProxyClient;

import Interfete.IServiceRezervare;
import ProjectModel.Rezervare;
import Utils.Cerere;
import com.sun.org.apache.xpath.internal.operations.Bool;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class ProxiClientRezervare implements IServiceRezervare {
    private String host;
    private int port;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;

    public ProxiClientRezervare(String host, int port, ObjectInputStream input, ObjectOutputStream output, Socket connection) {
        this.host = host;
        this.port = port;
        this.input = input;
        this.output = output;
        this.connection = connection;
    }

    @Override
    public List<Rezervare> getList(int idDestinatie) {
        Cerere cer = new Cerere("GetListaRezervari");
        Rezervare rez;
        List<Rezervare> list = new ArrayList<>();
        try{
            output.writeObject(cer);
            output.flush();
            output.writeInt(idDestinatie);
            output.flush();
            int nr=input.readInt();
            for(int i=1;i<=nr;++i)
            {
                Object obj = input.readObject();
                rez=(Rezervare) obj;
                list.add(rez);
            }
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return list;
    }

    @Override
    public boolean save(Rezervare rez) {
        Cerere  cer =new Cerere("Save");
        try {
            output.writeObject(cer);
            output.flush();
            output.writeObject(rez);
            output.flush();
            Object raspuns = input.readBoolean();
            return (Boolean) raspuns;
        } catch (IOException e) {
            e.printStackTrace();
        }
        return false;
    }
}
