
package Proxy;

import ProjectModels.Rezervare;
import ServiceInterface.IServiceRezervare;
import Utils.Request;
import Utils.Response;
import proto.ProjectProto;

import java.io.*;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class RezervareProxy implements IServiceRezervare {
    private InputStream input;
    private OutputStream output;
    private Socket connection;
    private ReadResponse r;

    public RezervareProxy(InputStream input, OutputStream output, Socket connection, ReadResponse r) {
        this.input = input;
        this.output = output;
        this.connection = connection;
        this.r = r;
    }

    @Override
    public List<Rezervare> getList(int idDestinatie) {
        ProjectProto.Request cer=ProjectProto.Request.newBuilder().setId(idDestinatie).setMess("getRezervazri").build();
        //Request cer = new Request("GetListaRezervari");
        //cer.setId(idDestinatie);
        try{
            cer.writeDelimitedTo(output);
            output.flush();
            ProjectProto.Response re = r.readResponse();
            if(re.getMess().equals("ok"))
            {
                List<Rezervare> list = new ArrayList<>();
                for(int i=0;i< re.getListaRezervariCount();++i)
                {
                    list.add(new Rezervare(re.getListaRezervari(i).getIdDestinatie(),re.getListaRezervari(i).getLocuriOcupate(),re.getListaRezervari(i).getNume()));
                }
                return list;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public boolean save(Rezervare rez) {
        //Request cer = new Request("Save");
        //cer.setRezervare(rez);
        ProjectProto.Rezervare rezervare = ProjectProto.Rezervare.newBuilder()
                .setIdDestinatie(rez.getIdDestinatie()).
                        setLocuriOcupate(rez.getLocuri_rezervate()).
                        setNume(rez.getNume()).build();
        ProjectProto.Request cer=ProjectProto.Request.newBuilder().setMess("Save").setRezervare(rezervare).build();
        try{
            cer.writeDelimitedTo(output);
            output.flush();
            ProjectProto.Response re= r.readResponse();
            if(re.getMess().equals("ok"))
            {
                return re.getRBool();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return false;
    }

}

