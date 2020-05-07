package Proxy;

import ProjectModels.Rezervare;
import ServiceInterface.IServiceRezervare;
import Utils.Request;
import Utils.Response;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.List;

public class RezervareProxy implements IServiceRezervare {
    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;
    private ReadResponse r;

    public RezervareProxy(ObjectInputStream input, ObjectOutputStream output, Socket connection, ReadResponse r) {
        this.input = input;
        this.output = output;
        this.connection = connection;
        this.r = r;
    }

    @Override
    public List<Rezervare> getList(int idDestinatie) {
        Request cer = new Request("GetListaRezervari");
        cer.setId(idDestinatie);
        try{
            output.writeObject(cer);
            output.flush();
            Response re = r.readResponse();
            if(re.getMesaj().equals("ok"))
            {
                return re.getList();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public boolean save(Rezervare rez) {
        Request cer = new Request("Save");
        cer.setRezervare(rez);
        try{
            output.writeObject(cer);
            output.flush();
            Response re = r.readResponse();
            if(re.getMesaj().equals("ok"))
            {
                return re.getBol();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return false;
    }
}
