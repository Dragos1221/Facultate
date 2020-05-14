package Proxy;

import ProjectModels.Destinatie;
import ServiceInterface.IServiceDestinatie;
import Utils.Request;
import Utils.Response;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.time.LocalDateTime;
import java.util.List;

public class DestinatieProxy implements IServiceDestinatie {
    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;
    private ReadResponse r;

    public DestinatieProxy(ObjectInputStream input, ObjectOutputStream output, Socket connection, ReadResponse r) {
        this.input = input;
        this.output = output;
        this.connection = connection;
        this.r = r;
    }

    @Override
    public int getIdDestinatie(String destinatie, LocalDateTime data) {
        Request req = new Request("getIdDestinatie");
        System.out.println(data.toString());
        req.setDestinatieStr(destinatie);
        req.setLocalDateTime(data.toString());
        try{
            output.writeObject(req);
            output.flush();
            Response resp = r.readResponse();
            if(resp.getMesaj().equals("ok"))
            {
                return resp.getId();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return 0;
    }

    @Override
    public List<Destinatie> returnLista() {
        Request cer = new Request("getListDestinatii");
        try{
            output.writeObject(cer);
            output.flush();
            Response re = r.readResponse();
            if(re.getMesaj().equals("ok"))
            {
                return re.getListDestinatii();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return null;
    }

    @Override
    public Destinatie getDestinatie(int id) {
        Request c = new Request("getDestinatie");
        c.setId(id);
        try{
            output.writeObject(c);
            output.flush();
            Response res = r.readResponse();
            if(res.getMesaj().equals("ok"))
            {
                return res.getDestinatie();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public void update(Destinatie dest) {
        Request request = new Request("Update");
        request.setDestinatie(dest);
        try{
            output.writeObject(request);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
